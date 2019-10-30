using Docker.DotNet;
using Docker.DotNet.Models;
using Docker.Registry.DotNet;
using Docker.Registry.DotNet.Authentication;
using Docker.Registry.DotNet.Models;
using ICSharpCode.SharpZipLib.Tar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PublishShinyApp
{
    public partial class Form1 : Form
    {
        IRegistryClient _baseRegistryClient = default;
        IRegistryClient _targetRegistryClient = default;
        DockerClient _localEngineClient = default;
        string _runningContainerId = string.Empty;

        public Form1()
        {
            InitializeComponent();
            _localEngineClient = new DockerClientConfiguration(new Uri("npipe://./pipe/docker_engine")).CreateClient();
        }

        private void chkAnonymous_CheckedChanged(object sender, EventArgs e)
        {
            var Sender = sender as CheckBox;
            TextBox UserNameBox = Sender.Name == chkBaseAnonymous.Name
                ? txtBaseUserName
                : txtTargetUserName;
            TextBox PasswordBox = Sender.Name == chkBaseAnonymous.Name
                ? txtBasePassword
                : txtTargetPassword;

            UserNameBox.Enabled = PasswordBox.Enabled = !Sender.Checked;
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            Cursor PreviousCursor = this.Cursor;
            Cursor = Cursors.WaitCursor;
            Button Sender = sender as Button;
            GroupBox grp = default;
            ComboBox comboEndpoint = default;
            CheckBox chkAnonymous = default;
            TextBox txtUserName = default;
            TextBox txtPassword = default;

            if (Sender == btnBaseLogin)
            {
                grp = grpBaseRegistry;
                comboEndpoint = comboBaseRegistry;
                chkAnonymous = chkBaseAnonymous;
                txtUserName = txtBaseUserName;
                txtPassword = txtBasePassword;
                _baseRegistryClient = null;
            }
            else
            {
                grp = grpTargetRegistry;
                comboEndpoint = comboTargetRegistry;
                chkAnonymous = chkTargetAnonymous;
                txtUserName = txtTargetUserName;
                txtPassword = txtTargetPassword;
                _targetRegistryClient = null;
            }

            if (Sender.Text == "Logout")
            {
                foreach (var control in grp.Controls)
                {
                    if (control.GetType() == typeof(ListBox))
                    {
                        ((ListBox)control).Items.Clear();
                    }

                    if (control.GetType() == typeof(TextBox))
                    {
                        ((TextBox)control).Text = "";
                    }
                    // ...
                }

                _baseRegistryClient = null;
                Sender.Text = "Login";
                comboEndpoint.Focus();
            }
            else
            {
                var configuration = new RegistryClientConfiguration(comboEndpoint.SelectedItem?.ToString() ?? comboEndpoint.Text);

                AuthenticationProvider authenticationProvider;

                if (chkAnonymous.Checked)
                {
                    authenticationProvider = new AnonymousOAuthAuthenticationProvider();
                }
                else
                {
                    authenticationProvider = new PasswordOAuthAuthenticationProvider(txtUserName.Text, txtPassword.Text);
                }

                var client = configuration.CreateClient(authenticationProvider);

                try
                {
                    await client.System.PingAsync();
                }
                catch (UnauthorizedAccessException ex)
                {
                    // authentication failed
                    MessageBox.Show($"Authentication failed with {ex.Message}", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Cursor = PreviousCursor;
                    return;
                }
                catch (RegistryConnectionException ex)
                {
                    // connection failed
                    MessageBox.Show($"Unable to connect, exception {ex.Message})", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Cursor = PreviousCursor;
                    return;
                }

                Sender.Text = "Logout";
                if (Sender == btnBaseLogin)
                {
                    _baseRegistryClient = client;
                }
                else
                {
                    _targetRegistryClient = client;
                }
            }

            Cursor = PreviousCursor;
        }

        private void btnApplicationFolder_Click(object sender, EventArgs e)
        {
            lblApplicationFolder.Text = string.Empty;
            DialogResult result = folderBrowserDialog1.ShowDialog();

            lblApplicationFolder.Text = folderBrowserDialog1.SelectedPath;
        }

        private async void comboBaseRepository_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstTags.Items.Clear();

            var tags = await _baseRegistryClient.Tags.ListImageTagsAsync(comboBaseRepository.SelectedItem.ToString(), new ListImageTagsParameters());

            foreach (var tag in tags.Tags)
            {
                lstTags.Items.Add(tag);
            }
        }

        private async void btnBuild_Click(object sender, EventArgs e)
        {
            if (_baseRegistryClient == null ||
                string.IsNullOrWhiteSpace(comboBaseRepository.Text) ||
                lstTags.SelectedIndex < 0
                )
            {
                MessageBox.Show("something is not prepared");
                return;
            }

            List<string> dockerFileLines = new List<string>();
            dockerFileLines.Add($"FROM {comboBaseRepository.Text}:{lstTags.SelectedItem.ToString()}");
            dockerFileLines.Add(@"RUN apt-get update && apt-get install libcurl4-openssl-dev libv8-3.14-dev -y &&\");
            dockerFileLines.Add("    mkdir -p /var/lib/shiny-server/bookmarks/shiny");
            dockerFileLines.Add("COPY *.R /srv/shiny-server/");
            if (lstPackages.Items.Count > 0)
            {
                List<string> packageList = new List<string>();
                foreach (var item in lstPackages.Items)
                {
                    packageList.Add($"'{item.ToString()}'");
                }
                string packages = string.Join(",", packageList);
                dockerFileLines.Add($"RUN R -e \"install.packages(c({packages}))\"");
            }
            dockerFileLines.Add("RUN chmod -R 755 /srv/shiny-server/");
            dockerFileLines.Add("EXPOSE 3838");
            dockerFileLines.Add("CMD [\"/usr/bin/shiny-server.sh\"]");

            File.WriteAllLines(Path.Combine(lblApplicationFolder.Text, "dockerfile"), dockerFileLines);

            Directory.SetCurrentDirectory(lblApplicationFolder.Text);

            // The contents of the application have to be put in a tar file
            DirectoryInfo directoryOfFilesToBeTarred = new DirectoryInfo(lblApplicationFolder.Text);
            FileInfo[] filesInDirectory = directoryOfFilesToBeTarred.GetFiles();
            String tarArchiveName = Path.Combine(lblApplicationFolder.Text, "mytararchive.tar");
            using (TarArchive tarArchive = TarArchive.CreateOutputTarArchive(File.Create(tarArchiveName), TarBuffer.DefaultBlockFactor))
            {
                foreach (FileInfo fileToBeTarred in filesInDirectory)
                {
                    TarEntry entry = TarEntry.CreateEntryFromFile(fileToBeTarred.FullName);
                    tarArchive.WriteEntry(entry, true);
                }
            }

            string dockerfile = Path.Combine(lblApplicationFolder.Text, "dockerfile").Replace(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);

            try
            {
                using (Stream result = await _localEngineClient.Images.BuildImageFromDockerfileAsync(
                                                                new FileStream(tarArchiveName, FileMode.Open),
                                                                new ImageBuildParameters { Tags = new List<string> { $"{comboTargetRegistry.Text}/{txtTargetTag.Text}" } }))
                {
                    using (FileStream writer = new FileStream(Path.Combine(lblApplicationFolder.Text, "output.file").Replace(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar), FileMode.Create))
                    {
                        int bytesread = 0;
                        do
                        {
                            byte[] buffer = new byte[1000];
                            bytesread = result.Read(buffer, 0, 1000);
                            writer.Write(buffer, 0, bytesread);
                            writer.Flush();
                        }
                        while (bytesread > 0);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception with message {ex.Message}");
            }

            File.Delete(tarArchiveName);
        }

        private void btnAddPackage_Click(object sender, EventArgs e)
        {
            lstPackages.Items.Add(txtAddPackage.Text);
        }

        private async void btnPush_Click(object sender, EventArgs e)
        {
            if (_targetRegistryClient == null || string.IsNullOrWhiteSpace(txtTargetTag.Text))
            {
                MessageBox.Show("something is not prepared");
                return;
            }

            await _localEngineClient.Images.PushImageAsync($"{comboTargetRegistry.Text}/{txtTargetTag.Text}", new ImagePushParameters { }, new AuthConfig { }, new ProgressToDebug());
        }

        private async void btnRun_Click(object sender, EventArgs e)
        {
            PortBinding binding = new PortBinding { HostPort = "3838", HostIP = "localhost" };
            var exposedPorts = new Dictionary<string, EmptyStruct> { { "3838", default(EmptyStruct) } };
            //var onePortBinding = new KeyValuePair<string, IList<PortBinding>>("3838", new List<PortBinding> { binding });

            var hostConfig = new HostConfig
            {
                PortBindings = new Dictionary<string,IList<PortBinding>> {
                    { "3838", new List<PortBinding> { binding } }
                }
            };

            CreateContainerResponse rsp = await _localEngineClient.Containers.CreateContainerAsync(
                new CreateContainerParameters {
                    ExposedPorts = exposedPorts,
                    HostConfig = hostConfig,
                    Image = $"{comboTargetRegistry.Text}/{txtTargetTag.Text}" 
                });

            Debug.WriteLine($"Created container with id {rsp.ID}");
            foreach (string warning in rsp.Warnings)
            {
                Debug.WriteLine($"    Created container warning {warning}");
            }

            await _localEngineClient.Containers.StartContainerAsync(rsp.ID, new ContainerStartParameters { });

            _runningContainerId = rsp.ID;
        }

        private async void btnKill_Click(object sender, EventArgs e)
        {
            await _localEngineClient.Containers.KillContainerAsync(_runningContainerId, new ContainerKillParameters { });

            await _localEngineClient.Containers.RemoveContainerAsync(_runningContainerId, new ContainerRemoveParameters());
            _runningContainerId = string.Empty;
        }
    }

    internal class ProgressToDebug : IProgress<JSONMessage>
    {
        //internal Action<Message> _onCalled;

        void IProgress<JSONMessage>.Report(JSONMessage value)
        {
            Debug.WriteLine(value.Status);
            //_onCalled(value);
        }
    }
}

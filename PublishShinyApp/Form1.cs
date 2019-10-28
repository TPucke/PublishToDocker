using Docker.Registry.DotNet;
using Docker.Registry.DotNet.Authentication;
using Docker.Registry.DotNet.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        
        public Form1()
        {
            InitializeComponent();
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
                    MessageBox.Show("Authentication failed", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Cursor = PreviousCursor;
                    return;
                }
                catch (RegistryConnectionException ex)
                {
                    // connection failed
                    MessageBox.Show("Unable to connect", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnBuild_Click(object sender, EventArgs e)
        {
            if (_baseRegistryClient == null ||
                _targetRegistryClient == null ||
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
            dockerFileLines.Add( "    mkdir -p /var/lib/shiny-server/bookmarks/shiny");
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
        }

        private void btnAddPackage_Click(object sender, EventArgs e)
        {
            lstPackages.Items.Add(txtAddPackage.Text);
        }
    }
}

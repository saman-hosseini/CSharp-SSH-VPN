using System;
using System.Windows.Forms;
using Microsoft.Win32;

namespace ssh_vpn
{
    public partial class SettingsForm : Form
    {
        private bool _isLoading = false;
        private string _currentProfile = "";
        private string _currentForwardPortName = "";
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            using (var appKey = Registry.CurrentUser.CreateSubKey(Consts.RegKey.KeyName))
            {
                var profile = txt_profile.Text;
                appKey.SetValue(Consts.RegKey.Profile, profile);
                using (var profileKey = appKey.CreateSubKey(profile))
                {
                    profileKey.SetValue(Consts.RegKey.IP, txt_ip.Text);
                    profileKey.SetValue(Consts.RegKey.Port, txt_port.Value);
                    profileKey.SetValue(Consts.RegKey.Username, txt_username.Text);
                    profileKey.SetValue(Consts.RegKey.Password, txt_password.Text);

                    MessageBox.Show("Successfully saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }

        private void btn_forwardportsave_Click(object sender, EventArgs e)
        {
            using (var appKey = Registry.CurrentUser.OpenSubKey(Consts.RegKey.KeyName, true))
            {
                var profile = txt_profile.Text;
                using (var profileKey = appKey.OpenSubKey(profile, true))
                {
                    using (var forwardportKey = profileKey.CreateSubKey(txt_forwardportname.Text, true))
                    {
                        forwardportKey.SetValue(Consts.RegKey.BoundHost, txt_boundhost.Text);
                        forwardportKey.SetValue(Consts.RegKey.BoundPort, txt_boundport.Value);
                        forwardportKey.SetValue(Consts.RegKey.RemoteHost, txt_remotehost.Text);
                        forwardportKey.SetValue(Consts.RegKey.RemotePort, txt_remoteport.Value);

                        MessageBox.Show("Successfully saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            LoadSettings();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            using (var appKey = Registry.CurrentUser.OpenSubKey(Consts.RegKey.KeyName))
            {
                if (appKey == null)
                {
                    return;
                }
                _currentProfile = appKey.GetValue(Consts.RegKey.Profile) as string;
            }
            LoadSettings();
        }

        private void lst_profile_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lst_profile.SelectedItem == null)
            {
                return;
            }
            _currentProfile = lst_profile.SelectedItem.ToString();
            txt_profile.Text = _currentProfile;
            LoadSettings();
        }

        private void SettingsForm_Shown(object sender, EventArgs e)
        {
            lst_profile.Focus();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (lst_profile.SelectedItem == null)
            {
                return;
            }
            var selectedProfile = lst_profile.SelectedItem.ToString();
            using (var appKey = Registry.CurrentUser.OpenSubKey(Consts.RegKey.KeyName, true))
            {
                if (appKey == null)
                {
                    return;
                }
                var activeProfile = appKey.GetValue(Consts.RegKey.Profile) as string;
                if (selectedProfile == activeProfile)
                {
                    MessageBox.Show("Active Profile can not be deleted.", "Waning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                appKey.DeleteSubKey(selectedProfile);
            }

            LoadSettings();
        }

        private void lst_forwardedport_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lst_forwardedport.SelectedItem == null)
            {
                return;
            }
            _currentForwardPortName = lst_forwardedport.SelectedItem.ToString();
            txt_forwardportname.Text = _currentForwardPortName;
            LoadSettings();
        }

        private void LoadSettings()
        {
            if (_isLoading)
            {
                return;
            }
            _isLoading = true;

            try
            {
                lst_profile.Items.Clear();
                lst_forwardedport.Items.Clear();
                txt_forwardportname.Text = "";
                txt_boundhost.Text = "";
                txt_remotehost.Text = "";
                txt_boundport.Value = 1080;
                txt_remoteport.Value = 1080;

                using (var appKey = Registry.CurrentUser.OpenSubKey(Consts.RegKey.KeyName))
                {
                    if (appKey == null)
                    {
                        return;
                    }
                    txt_profile.Text = _currentProfile;
                    var profiles = appKey.GetSubKeyNames();
                    if (profiles.Length > 0)
                    {
                        lst_profile.Items.AddRange(profiles);
                        lst_profile.SelectedIndex = lst_profile.Items.IndexOf(_currentProfile);
                    }

                    using (var profileKey = appKey.OpenSubKey(_currentProfile))
                    {
                        int port = 22;
                        txt_ip.Text = profileKey.GetValue(Consts.RegKey.IP) as string;

                        if (int.TryParse(profileKey.GetValue(Consts.RegKey.Port) as string, out port))
                        {
                            txt_port.Value = port;
                        }

                        txt_username.Text = profileKey.GetValue(Consts.RegKey.Username) as string;
                        txt_password.Text = profileKey.GetValue(Consts.RegKey.Password) as string;

                        var forwardPorts = profileKey.GetSubKeyNames();
                        if (forwardPorts.Length > 0)
                        {
                            lst_forwardedport.Items.AddRange(forwardPorts);
                            lst_forwardedport.SelectedIndex = lst_forwardedport.Items.IndexOf(_currentForwardPortName);

                            using (var forwardedportNameKey = profileKey.OpenSubKey(_currentForwardPortName))
                            {
                                if (forwardedportNameKey == null)
                                {
                                    return;
                                }
                                int boundPort = 1080;
                                int remotePort = 1080;

                                txt_boundhost.Text = forwardedportNameKey.GetValue(Consts.RegKey.BoundHost) as string;
                                txt_remotehost.Text = forwardedportNameKey.GetValue(Consts.RegKey.RemoteHost) as string;

                                if (int.TryParse(forwardedportNameKey.GetValue(Consts.RegKey.BoundPort) as string, out boundPort))
                                {
                                    txt_boundport.Value = boundPort;
                                }
                                if (int.TryParse(forwardedportNameKey.GetValue(Consts.RegKey.RemotePort) as string, out remotePort))
                                {
                                    txt_remoteport.Value = remotePort;
                                }
                            }
                        }
                    }
                }
            }
            finally
            {
                _isLoading = false;
            }
            return;
        }
    }
}

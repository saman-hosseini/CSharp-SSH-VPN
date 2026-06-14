using System;
using System.Windows.Forms;
using Microsoft.Win32;

namespace ssh_vpn
{
    public partial class SettingsForm : Form
    {
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

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            using (var appKey = Registry.CurrentUser.OpenSubKey(Consts.RegKey.KeyName))
            {
                if (appKey == null)
                {
                    return;
                }
                var profile = appKey.GetValue(Consts.RegKey.Profile) as string;
                txt_profile.Text = profile;
                var profiles = appKey.GetSubKeyNames();
                if (profiles.Length > 0)
                {
                    lst_profile.Items.AddRange(profiles);
                    lst_profile.SelectedIndex = lst_profile.Items.IndexOf(profile);
                }

                using (var profileKey = appKey.OpenSubKey(profile))
                {
                    int port = 22;

                    txt_ip.Text = profileKey.GetValue(Consts.RegKey.IP) as string;

                    if (int.TryParse(profileKey.GetValue(Consts.RegKey.Port) as string, out port))
                    {
                        txt_port.Value = port;
                    }

                    txt_username.Text = profileKey.GetValue(Consts.RegKey.Username) as string;
                    txt_password.Text = profileKey.GetValue(Consts.RegKey.Password) as string;
                }
            }
        }

        private void lst_profile_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lst_profile.SelectedItem == null)
            {
                return;
            }
            var profile = lst_profile.SelectedItem.ToString();
            txt_profile.Text = profile;
            using (var appKey = Registry.CurrentUser.OpenSubKey(Consts.RegKey.KeyName))
            {
                if (appKey == null)
                {
                    return;
                }

                using (var profileKey = appKey.OpenSubKey(profile))
                {
                    int port = 22;

                    txt_ip.Text = profileKey.GetValue(Consts.RegKey.IP) as string;

                    if (int.TryParse(profileKey.GetValue(Consts.RegKey.Port) as string, out port))
                    {
                        txt_port.Value = port;
                    }

                    txt_username.Text = profileKey.GetValue(Consts.RegKey.Username) as string;
                    txt_password.Text = profileKey.GetValue(Consts.RegKey.Password) as string;
                }
            }
        }

        private void SettingsForm_Shown(object sender, EventArgs e)
        {
            lst_profile.Focus();
        }
    }
}

using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Win32;
using Renci.SshNet;


namespace ssh_vpn
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SystemEvents.SessionEnding += new SessionEndingEventHandler(SystemEvents_SessionEnding);
        }

        SshClient sshClient = new SshClient("0.0.0.0", 22, "0000", "0000");
        ForwardedPortLocal pfHttp = new ForwardedPortLocal("127.0.0.1", (uint)9000, "127.0.0.1", (uint)3128);
        ForwardedPortLocal pfDockerRepository = new ForwardedPortLocal("127.0.0.1", (uint)5001, "192.168.100.51", (uint)5000);
        ForwardedPortLocal pfCloudDB = new ForwardedPortLocal("127.0.0.1", (uint)5002, "192.168.200.250", (uint)2830);
        ForwardedPortLocal pfPlatformDB = new ForwardedPortLocal("127.0.0.1", (uint)5003, "192.168.200.250", (uint)2831);
        ForwardedPortLocal pfKamailioDB = new ForwardedPortLocal("127.0.0.1", (uint)5004, "10.10.255.253", (uint)22);
        ForwardedPortLocal pfAstrisk = new ForwardedPortLocal("127.0.0.1", (uint)5005, "192.168.80.6", (uint)5038);
        //ForwardedPortLocal pfMySQL = new ForwardedPortLocal("127.0.0.1", (uint)3306, "192.168.80.7", (uint)3306);

        void Connect()
        {
            btnToggle.Text = "Connecting...";

            string ip = registery_get_data(Consts.RegKey.IP);
            string username = registery_get_data(Consts.RegKey.Username);
            string password = registery_get_data(Consts.RegKey.Password);
            int port;

            if (!int.TryParse(registery_get_data(Consts.RegKey.Port), out port)) port = 22;

            if (ip == "" || username == "" || password == "")
            {
                MessageBox.Show("Error : You should set SSH server settings...", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Invoke((MethodInvoker)delegate
                {
                    btnOpenSettings_Click(null, null);
                    btnToggle.Text = "Connect";
                });
                return;
            }


            ThreadPool.QueueUserWorkItem(new WaitCallback((state) =>
            {
                sshClient = new SshClient(ip, port, username, password);

                try
                {
                    sshClient.Connect();
                    sshClient.AddForwardedPort(pfHttp);
                    pfHttp.Start();
                    sshClient.AddForwardedPort(pfDockerRepository);
                    pfDockerRepository.Start();
                    sshClient.AddForwardedPort(pfCloudDB);
                    pfCloudDB.Start();
                    sshClient.AddForwardedPort(pfPlatformDB);
                    pfPlatformDB.Start();
                    sshClient.AddForwardedPort(pfKamailioDB);
                    pfKamailioDB.Start();
                    sshClient.AddForwardedPort(pfAstrisk);
                    pfAstrisk.Start();
                    //sshClient.AddForwardedPort(pfMySQL);
                    //pfMySQL.Start();

                    Invoke((MethodInvoker)delegate
                    {
                        lblStatus.BackColor = Color.Green;
                        lblStatus.Text = "Connected      00:00:00";
                        btnToggle.Text = "Disconnect";

                        timer_check_status.Enabled = true;
                        timer_check_status.Start();
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error : " + ex.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Invoke((MethodInvoker)delegate { btnToggle.Text = "Connect"; });
                }
                finally
                {
                    Invoke((MethodInvoker)delegate { btnToggle.Enabled = true; });
                }
            }));
        }

        void Disconnect()
        {
            btnToggle.Text = "Disconnecting...";

            pfHttp.Stop();
            pfDockerRepository.Stop();
            pfCloudDB.Stop();
            pfPlatformDB.Stop();
            pfKamailioDB.Stop();
            pfAstrisk.Stop();
            //pfMySQL.Stop();
            sshClient.Disconnect();

            btnToggle.Text = "Connect";
            lblStatus.BackColor = Color.Red;
            lblStatus.Text = "Not Connected";

            timer_check_status.Enabled = false;
            timer_check_status.Stop();
            seconds = 0;

            btnToggle.Enabled = true;
        }


        private void btnToggle_Click(object sender, EventArgs e)
        {
            btnToggle.Enabled = false;
            Cursor.Current = Cursors.WaitCursor;

            if (sshClient.IsConnected)
                Disconnect();

            else Connect();

            Cursor.Current = Cursors.Default;
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!sshClient.IsConnected) return;

            DialogResult result = MessageBox.Show("Do you really wish to exit? the connection will be stopped.", "Exit Program?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
                e.Cancel = true;
            else
                Disconnect();

        }
        private void SystemEvents_SessionEnding(object sender, SessionEndingEventArgs e)
        {
            if (sshClient.IsConnected)
                btnToggle_Click(null, null);

            Application.Exit();
        }

        private void btnOpenSettings_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.ShowDialog();
        }

        bool back_status = false;
        int seconds = 0;
        private void timer_check_status_Tick(object sender, EventArgs e)
        {
            if (!sshClient.IsConnected && sshClient.IsConnected != back_status)
            {
                Disconnect();

                notifyIcon1.Icon = SystemIcons.Warning;
                notifyIcon1.ShowBalloonTip(10);
            }
            else if (sshClient.IsConnected && sshClient.IsConnected != back_status)
            {
                seconds = 0;
                lblStatus.Text = "Connected      00:00:00";
            }
            else if (sshClient.IsConnected)
            {
                seconds++;

                int hours = seconds / 3600;
                int minutes = (seconds % 3600) / 60;
                int remainingSeconds = seconds % 60;
                lblStatus.Text = "Connected      " + hours.ToString("D2") + ":" + minutes.ToString("D2") + ":" + remainingSeconds.ToString("D2");
            }

            back_status = sshClient.IsConnected;
        }

        private string registery_get_data(string name)
        {
            using (var appKey = Registry.CurrentUser.OpenSubKey(Consts.RegKey.KeyName))
            {
                if (appKey == null)
                {
                    return "";
                }
                var profile = appKey.GetValue(Consts.RegKey.Profile) as string;
                lbl_profile.Text = profile;
                using (var profileKey = appKey.OpenSubKey(profile))
                {
                    if (profileKey == null)
                    {
                        return "";
                    }
                    return profileKey.GetValue(name) as string;
                }
            }
        }
    }

}

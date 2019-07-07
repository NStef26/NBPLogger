using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NBP.Logger.CassandraClient;
using NBP.Logger.DTO;
using NBP.Logger.RedisClient;
using StackExchange.Redis;

namespace NBP.Logger.User
{
    public partial class MainForm : Form
    {
        Client RedisClient;
        delegate void LastDelegate(object sender, EventArgs e);
        LastDelegate LastMethodInvoked;
        object LastSender;
        EventArgs LastEvent;
        Timer Timer;

        public MainForm()
        {
            InitializeComponent();
            RedisClient = new Client();
            Init();
        }

        private void Init()
        {
            //initializing timer for auto-refresh which ticks on 10s
            //runs auto-refresh on what is selected from radio group
            Timer = new Timer();
            Timer.Interval = 1000 * 10;
            Timer.Tick += Timer_Tick;

            dtpFrom.Format = DateTimePickerFormat.Custom;
            dtpFrom.CustomFormat = "dd.MM.yyyy HH:mm";

            dtpTo.Format = DateTimePickerFormat.Custom;
            dtpTo.CustomFormat = "dd.MM.yyyy HH:mm";
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (cBoxAutoRefresh.Checked)
            {
                if (rBtnRefreshMail.Checked)
                {
                    var mailsCached = RedisClient.GetAllMails()
                        .OrderByDescending(o=> o.TimeStamp)
                        .ThenByDescending(o=>o.Password)
                        .ToList();

                    if (mailsCached.Count == 0)
                    {
                        dgv.DataSource = DataProvider.Transform(DataProvider.GetAllMails())
                            .OrderByDescending(o => o.TimeStamp)
                            .ThenByDescending(o => o.Password)
                            .ToList();
                    }
                    else
                    {
                        dgv.DataSource = mailsCached;
                    }
                    SetColumnsMail();
                    var mails = DataProvider.Transform(DataProvider.GetAllMails());
                    RedisClient.PublishMore(mails.Cast<BasicLogger>().ToList());
                }
                if (rBtnRefreshMobile.Checked)
                {
                    var mobilesCached = RedisClient.GetAllMobiles()
                        .OrderByDescending(o => o.TimeStamp)
                        .ThenByDescending(o => o.Password)
                        .ToList();

                    if (mobilesCached.Count == 0)
                    {
                        dgv.DataSource = DataProvider.Transform(DataProvider.GetAllMobiles())
                            .OrderByDescending(o => o.TimeStamp)
                            .ThenByDescending(o => o.Password)
                            .ToList();
                    }
                    else
                    {
                        dgv.DataSource = mobilesCached;
                    }
                    SetColumnsMobile();
                    var mobiles = DataProvider.Transform(DataProvider.GetAllMobiles());
                    RedisClient.PublishMore(mobiles.Cast<BasicLogger>().ToList());
                }
                if (rBtnRefreshUsername.Checked)
                {
                    var usersCached = RedisClient.GetAllUsernames()
                        .OrderByDescending(o => o.TimeStamp)
                        .ThenByDescending(o => o.Password)
                        .ToList();

                    if (usersCached.Count == 0)
                    {
                        dgv.DataSource = DataProvider.Transform(DataProvider.GetAllUsernames())
                            .OrderByDescending(o => o.TimeStamp)
                            .ThenByDescending(o => o.Password)
                            .ToList();
                    }
                    else
                    {
                        dgv.DataSource = usersCached;
                    }
                    SetColumnsUsername();
                    var users = DataProvider.Transform(DataProvider.GetAllUsernames());
                    RedisClient.PublishMore(users.Cast<BasicLogger>().ToList());
                }
            }
        }

        private void SetColumnsMail()
        {
            dgv.Columns["TimeStamp"].DisplayIndex = 0;
            dgv.Columns["Mail"].DisplayIndex = 1;
            dgv.Columns["Password"].DisplayIndex = 2;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }
        private void SetColumnsMobile()
        {
            dgv.Columns["TimeStamp"].DisplayIndex = 0;
            dgv.Columns["MobileNumber"].DisplayIndex = 1;
            dgv.Columns["Password"].DisplayIndex = 2;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }
        private void SetColumnsUsername()
        {
            dgv.Columns["TimeStamp"].DisplayIndex = 0;
            dgv.Columns["Username"].DisplayIndex = 1;
            dgv.Columns["Password"].DisplayIndex = 2;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        private void btnMail_Click(object sender, EventArgs e)
        {
            LastMethodInvoked = new LastDelegate(btnMail_Click);
            LastSender = sender;
            LastEvent = e;

            var mailsCached = RedisClient.GetAllMails()
                .OrderByDescending(o => o.TimeStamp)
                .ThenByDescending(o => o.Password)
                .ToList();

            if (mailsCached.Count == 0)
            {
                dgv.DataSource = DataProvider.Transform(DataProvider.GetAllMails())
                    .OrderByDescending(o => o.TimeStamp)
                    .ThenByDescending(o => o.Password)
                    .ToList();
            }
            else
            {
                dgv.DataSource = mailsCached;
            }
            SetColumnsMail();
            var mails = DataProvider.Transform(DataProvider.GetAllMails());
            RedisClient.PublishMore(mails.Cast<BasicLogger>().ToList());
        }

        private void btnMobile_Click(object sender, EventArgs e)
        {
            LastMethodInvoked = new LastDelegate(btnMobile_Click);
            LastSender = sender;
            LastEvent = e;

            var mobilesCached = RedisClient.GetAllMobiles()
                .OrderByDescending(o => o.TimeStamp)
                .ThenByDescending(o => o.Password)
                .ToList();

            if (mobilesCached.Count == 0)
            {
                dgv.DataSource = DataProvider.Transform(DataProvider.GetAllMobiles())
                    .OrderByDescending(o => o.MobileNumber)
                    .ThenByDescending(o => o.MobileNumber)
                    .ToList();
            }
            else
            {
                dgv.DataSource = mobilesCached;
            }
            SetColumnsMobile();
            var mobiles = DataProvider.Transform(DataProvider.GetAllMobiles());
            RedisClient.PublishMore(mobiles.Cast<BasicLogger>().ToList());
        }

        private void btnUsername_Click(object sender, EventArgs e)
        {
            LastMethodInvoked = new LastDelegate(btnUsername_Click);
            LastSender = sender;
            LastEvent = e;

            var usersCached = RedisClient.GetAllUsernames()
                .OrderByDescending(o => o.TimeStamp)
                .ThenByDescending(o => o.Username)
                .ToList();

            if (usersCached.Count == 0)
            {
                dgv.DataSource = DataProvider.Transform(DataProvider.GetAllUsernames())
                    .OrderByDescending(o => o.TimeStamp)
                    .ThenByDescending(o => o.Password)
                    .ToList();
            }
            else
            {
                dgv.DataSource = usersCached;
            }
            SetColumnsUsername();
            var users = DataProvider.Transform(DataProvider.GetAllUsernames());
            RedisClient.PublishMore(users.Cast<BasicLogger>().ToList());
        }

        private void btnTime_Click(object sender, EventArgs e)
        {
            LastMethodInvoked = new LastDelegate(btnTime_Click);
            LastSender = sender;
            LastEvent = e;

            if (rBtnMail.Checked)
            {
                var mails = DataProvider.Transform(DataProvider.GetMails(dtpFrom.Value, dtpTo.Value))
                    .OrderByDescending(o => o.TimeStamp)
                    .ThenByDescending(o => o.Password)
                    .ToList();

                if (mails.Count == 0)
                {
                    ShowMessageBox("Traženi upit nije pronašao nijednu vrednost sa zadatim kriterijumima.");
                    return;
                }
                dgv.DataSource = mails;
                SetColumnsMail();
            }
            if (rBtnMobile.Checked)
            {
                var mobiles = DataProvider.Transform(DataProvider.GetMobiles(dtpFrom.Value, dtpTo.Value))
                    .OrderByDescending(o => o.TimeStamp)
                    .ThenByDescending(o => o.Password)
                    .ToList();

                if (mobiles.Count == 0)
                {
                    ShowMessageBox("Traženi upit nije pronašao nijednu vrednost sa zadatim kriterijumima.");
                    return;
                }
                dgv.DataSource = mobiles;
                SetColumnsMobile();

            }
            if (rBtnUsername.Checked)
            {
                var users = DataProvider.Transform(DataProvider.GetUsernames(dtpFrom.Value, dtpTo.Value))
                    .OrderByDescending(o => o.TimeStamp)
                    .ThenByDescending(o => o.Password)
                    .ToList();

                if (users.Count == 0)
                {
                    ShowMessageBox("Traženi upit nije pronašao nijednu vrednost sa zadatim kriterijumima.");
                    return;
                }
                dgv.DataSource = users;
                SetColumnsUsername();
            }
        }

        private void ShowMessageBox(string text)
        {
            MessageBox.Show(text, "Obaveštenje", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LastMethodInvoked.DynamicInvoke(LastSender, LastEvent);
        }

        private void cBoxAutoRefresh_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxAutoRefresh.Checked)
            {           
                Timer.Start();
            }
            else
            {
                Timer.Stop();
            }
        }

        private void tBoxCQL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bool t = DataProvider.ExecuteQuery(tBoxCQL.Text);
                if (t)
                {
                    MessageBox.Show("Traženi upit je uspešno izvršen.", "Obaveštenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    ShowMessageBox("Traženi upit nije uspešno izvršen.");
                }
            }
        }

        private void btnTimeDelete_Click(object sender, EventArgs e)
        {
            int count = 0;
            if (rBtnMail.Checked)
            {
                RedisClient.DeleteMailsFromTo(dtpFrom.Value, dtpTo.Value);
                count = DataProvider.DeleteMailsFromTo(dtpFrom.Value, dtpTo.Value);
            }
            if (rBtnMobile.Checked)
            {
                RedisClient.DeleteMobilesFromTo(dtpFrom.Value, dtpTo.Value);
                count = DataProvider.DeleteMobilesFromTo(dtpFrom.Value, dtpTo.Value);
            }
            if (rBtnUsername.Checked)
            {
                RedisClient.DeleteUsernamesFromTo(dtpFrom.Value, dtpTo.Value);
                count = DataProvider.DeleteUsernamesFromTo(dtpFrom.Value, dtpTo.Value);
            }
            if (count == -1)
            {
                ShowMessageBox("Traženi upit je izvršen sa greškom.");
            }
            if (count > 0)
            {
                string message = "Traženi upit je uspešno izvršen.\n Obrisano je " + count.ToString() + " redova.";
                MessageBox.Show(message, "Obaveštenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                ShowMessageBox("Nije bilo vrednosti sa zadatim datumima.");
            }
        }

        private void btnDeleteMails_Click(object sender, EventArgs e)
        {
            RedisClient.DeleteAllMails();
            DataProvider.DeleteAllMails();
            MessageBox.Show("Uspešno su izbrisani svi mejlovi.", "Obaveštenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDeleteMobiles_Click(object sender, EventArgs e)
        {
            RedisClient.DeleteAllMobiles();
            DataProvider.DeleteAllMobiles();
            MessageBox.Show("Uspešno su izbrisani svi mobilni telefoni.", "Obaveštenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDeleteUsernames_Click(object sender, EventArgs e)
        {
            RedisClient.DeleteAllUsernames();
            DataProvider.DeleteAllUsernames();
            MessageBox.Show("Uspešno su izbrisani svi korisnički nalozi.", "Obaveštenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

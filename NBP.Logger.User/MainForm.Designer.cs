namespace NBP.Logger.User
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgv = new System.Windows.Forms.DataGridView();
            this.btnMobile = new System.Windows.Forms.Button();
            this.btnMail = new System.Windows.Forms.Button();
            this.btnUsername = new System.Windows.Forms.Button();
            this.gBoxCassandra = new System.Windows.Forms.GroupBox();
            this.tBoxCQL = new System.Windows.Forms.TextBox();
            this.gBoxRefresh = new System.Windows.Forms.GroupBox();
            this.rBtnRefreshMobile = new System.Windows.Forms.RadioButton();
            this.rBtnRefreshUsername = new System.Windows.Forms.RadioButton();
            this.rBtnRefreshMail = new System.Windows.Forms.RadioButton();
            this.cBoxAutoRefresh = new System.Windows.Forms.CheckBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.gBoxTime = new System.Windows.Forms.GroupBox();
            this.btnTimeDelete = new System.Windows.Forms.Button();
            this.rBtnMobile = new System.Windows.Forms.RadioButton();
            this.rBtnUsername = new System.Windows.Forms.RadioButton();
            this.rBtnMail = new System.Windows.Forms.RadioButton();
            this.btnTime = new System.Windows.Forms.Button();
            this.lblDo = new System.Windows.Forms.Label();
            this.lblOd = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblError = new System.Windows.Forms.Label();
            this.gBoxDelete = new System.Windows.Forms.GroupBox();
            this.btnDeleteMails = new System.Windows.Forms.Button();
            this.btnDeleteUsernames = new System.Windows.Forms.Button();
            this.btnDeleteMobiles = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.gBoxCassandra.SuspendLayout();
            this.gBoxRefresh.SuspendLayout();
            this.gBoxTime.SuspendLayout();
            this.gBoxDelete.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.AllowUserToOrderColumns = true;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(12, 97);
            this.dgv.Name = "dgv";
            this.dgv.Size = new System.Drawing.Size(853, 468);
            this.dgv.TabIndex = 0;
            // 
            // btnMobile
            // 
            this.btnMobile.Location = new System.Drawing.Point(87, 19);
            this.btnMobile.Name = "btnMobile";
            this.btnMobile.Size = new System.Drawing.Size(75, 23);
            this.btnMobile.TabIndex = 1;
            this.btnMobile.Text = "Mobile";
            this.btnMobile.UseVisualStyleBackColor = true;
            this.btnMobile.Click += new System.EventHandler(this.btnMobile_Click);
            // 
            // btnMail
            // 
            this.btnMail.Location = new System.Drawing.Point(6, 19);
            this.btnMail.Name = "btnMail";
            this.btnMail.Size = new System.Drawing.Size(75, 23);
            this.btnMail.TabIndex = 2;
            this.btnMail.Text = "Mail";
            this.btnMail.UseVisualStyleBackColor = true;
            this.btnMail.Click += new System.EventHandler(this.btnMail_Click);
            // 
            // btnUsername
            // 
            this.btnUsername.Location = new System.Drawing.Point(168, 19);
            this.btnUsername.Name = "btnUsername";
            this.btnUsername.Size = new System.Drawing.Size(75, 23);
            this.btnUsername.TabIndex = 3;
            this.btnUsername.Text = "Username";
            this.btnUsername.UseVisualStyleBackColor = true;
            this.btnUsername.Click += new System.EventHandler(this.btnUsername_Click);
            // 
            // gBoxCassandra
            // 
            this.gBoxCassandra.Controls.Add(this.btnMail);
            this.gBoxCassandra.Controls.Add(this.btnUsername);
            this.gBoxCassandra.Controls.Add(this.btnMobile);
            this.gBoxCassandra.Location = new System.Drawing.Point(893, 220);
            this.gBoxCassandra.Name = "gBoxCassandra";
            this.gBoxCassandra.Size = new System.Drawing.Size(258, 62);
            this.gBoxCassandra.TabIndex = 4;
            this.gBoxCassandra.TabStop = false;
            this.gBoxCassandra.Text = "Učitati sve:";
            // 
            // tBoxCQL
            // 
            this.tBoxCQL.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F);
            this.tBoxCQL.Location = new System.Drawing.Point(12, 17);
            this.tBoxCQL.Multiline = true;
            this.tBoxCQL.Name = "tBoxCQL";
            this.tBoxCQL.Size = new System.Drawing.Size(682, 38);
            this.tBoxCQL.TabIndex = 5;
            this.tBoxCQL.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tBoxCQL_KeyDown);
            // 
            // gBoxRefresh
            // 
            this.gBoxRefresh.Controls.Add(this.rBtnRefreshMobile);
            this.gBoxRefresh.Controls.Add(this.rBtnRefreshUsername);
            this.gBoxRefresh.Controls.Add(this.rBtnRefreshMail);
            this.gBoxRefresh.Controls.Add(this.cBoxAutoRefresh);
            this.gBoxRefresh.Controls.Add(this.btnRefresh);
            this.gBoxRefresh.Location = new System.Drawing.Point(887, 97);
            this.gBoxRefresh.Name = "gBoxRefresh";
            this.gBoxRefresh.Size = new System.Drawing.Size(258, 86);
            this.gBoxRefresh.TabIndex = 7;
            this.gBoxRefresh.TabStop = false;
            // 
            // rBtnRefreshMobile
            // 
            this.rBtnRefreshMobile.AutoSize = true;
            this.rBtnRefreshMobile.Location = new System.Drawing.Point(91, 54);
            this.rBtnRefreshMobile.Name = "rBtnRefreshMobile";
            this.rBtnRefreshMobile.Size = new System.Drawing.Size(56, 17);
            this.rBtnRefreshMobile.TabIndex = 10;
            this.rBtnRefreshMobile.TabStop = true;
            this.rBtnRefreshMobile.Text = "Mobile";
            this.rBtnRefreshMobile.UseVisualStyleBackColor = true;
            // 
            // rBtnRefreshUsername
            // 
            this.rBtnRefreshUsername.AutoSize = true;
            this.rBtnRefreshUsername.Location = new System.Drawing.Point(163, 54);
            this.rBtnRefreshUsername.Name = "rBtnRefreshUsername";
            this.rBtnRefreshUsername.Size = new System.Drawing.Size(73, 17);
            this.rBtnRefreshUsername.TabIndex = 9;
            this.rBtnRefreshUsername.TabStop = true;
            this.rBtnRefreshUsername.Text = "Username";
            this.rBtnRefreshUsername.UseVisualStyleBackColor = true;
            // 
            // rBtnRefreshMail
            // 
            this.rBtnRefreshMail.AutoSize = true;
            this.rBtnRefreshMail.Location = new System.Drawing.Point(22, 54);
            this.rBtnRefreshMail.Name = "rBtnRefreshMail";
            this.rBtnRefreshMail.Size = new System.Drawing.Size(44, 17);
            this.rBtnRefreshMail.TabIndex = 8;
            this.rBtnRefreshMail.TabStop = true;
            this.rBtnRefreshMail.Text = "Mail";
            this.rBtnRefreshMail.UseVisualStyleBackColor = true;
            // 
            // cBoxAutoRefresh
            // 
            this.cBoxAutoRefresh.AutoSize = true;
            this.cBoxAutoRefresh.Location = new System.Drawing.Point(114, 21);
            this.cBoxAutoRefresh.Name = "cBoxAutoRefresh";
            this.cBoxAutoRefresh.Size = new System.Drawing.Size(83, 17);
            this.cBoxAutoRefresh.TabIndex = 1;
            this.cBoxAutoRefresh.Text = "Auto-refresh";
            this.cBoxAutoRefresh.UseVisualStyleBackColor = true;
            this.cBoxAutoRefresh.CheckedChanged += new System.EventHandler(this.cBoxAutoRefresh_CheckedChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(18, 19);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(63, 24);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // gBoxTime
            // 
            this.gBoxTime.Controls.Add(this.btnTimeDelete);
            this.gBoxTime.Controls.Add(this.rBtnMobile);
            this.gBoxTime.Controls.Add(this.rBtnUsername);
            this.gBoxTime.Controls.Add(this.rBtnMail);
            this.gBoxTime.Controls.Add(this.btnTime);
            this.gBoxTime.Controls.Add(this.lblDo);
            this.gBoxTime.Controls.Add(this.lblOd);
            this.gBoxTime.Controls.Add(this.dtpTo);
            this.gBoxTime.Controls.Add(this.dtpFrom);
            this.gBoxTime.Location = new System.Drawing.Point(887, 416);
            this.gBoxTime.Name = "gBoxTime";
            this.gBoxTime.Size = new System.Drawing.Size(258, 149);
            this.gBoxTime.TabIndex = 8;
            this.gBoxTime.TabStop = false;
            this.gBoxTime.Text = "Odredi po vremenu:";
            // 
            // btnTimeDelete
            // 
            this.btnTimeDelete.Location = new System.Drawing.Point(167, 110);
            this.btnTimeDelete.Name = "btnTimeDelete";
            this.btnTimeDelete.Size = new System.Drawing.Size(75, 23);
            this.btnTimeDelete.TabIndex = 8;
            this.btnTimeDelete.Text = "Izbriši";
            this.btnTimeDelete.UseVisualStyleBackColor = true;
            this.btnTimeDelete.Click += new System.EventHandler(this.btnTimeDelete_Click);
            // 
            // rBtnMobile
            // 
            this.rBtnMobile.AutoSize = true;
            this.rBtnMobile.Location = new System.Drawing.Point(87, 19);
            this.rBtnMobile.Name = "rBtnMobile";
            this.rBtnMobile.Size = new System.Drawing.Size(56, 17);
            this.rBtnMobile.TabIndex = 7;
            this.rBtnMobile.TabStop = true;
            this.rBtnMobile.Text = "Mobile";
            this.rBtnMobile.UseVisualStyleBackColor = true;
            // 
            // rBtnUsername
            // 
            this.rBtnUsername.AutoSize = true;
            this.rBtnUsername.Location = new System.Drawing.Point(159, 19);
            this.rBtnUsername.Name = "rBtnUsername";
            this.rBtnUsername.Size = new System.Drawing.Size(73, 17);
            this.rBtnUsername.TabIndex = 6;
            this.rBtnUsername.TabStop = true;
            this.rBtnUsername.Text = "Username";
            this.rBtnUsername.UseVisualStyleBackColor = true;
            // 
            // rBtnMail
            // 
            this.rBtnMail.AutoSize = true;
            this.rBtnMail.Location = new System.Drawing.Point(18, 19);
            this.rBtnMail.Name = "rBtnMail";
            this.rBtnMail.Size = new System.Drawing.Size(44, 17);
            this.rBtnMail.TabIndex = 5;
            this.rBtnMail.TabStop = true;
            this.rBtnMail.Text = "Mail";
            this.rBtnMail.UseVisualStyleBackColor = true;
            // 
            // btnTime
            // 
            this.btnTime.Location = new System.Drawing.Point(43, 110);
            this.btnTime.Name = "btnTime";
            this.btnTime.Size = new System.Drawing.Size(75, 23);
            this.btnTime.TabIndex = 4;
            this.btnTime.Text = "Pronađi";
            this.btnTime.UseVisualStyleBackColor = true;
            this.btnTime.Click += new System.EventHandler(this.btnTime_Click);
            // 
            // lblDo
            // 
            this.lblDo.AutoSize = true;
            this.lblDo.Location = new System.Drawing.Point(13, 90);
            this.lblDo.Name = "lblDo";
            this.lblDo.Size = new System.Drawing.Size(24, 13);
            this.lblDo.TabIndex = 3;
            this.lblDo.Text = "Do:";
            // 
            // lblOd
            // 
            this.lblOd.AutoSize = true;
            this.lblOd.Location = new System.Drawing.Point(13, 64);
            this.lblOd.Name = "lblOd";
            this.lblOd.Size = new System.Drawing.Size(24, 13);
            this.lblOd.TabIndex = 2;
            this.lblOd.Text = "Od:";
            // 
            // dtpTo
            // 
            this.dtpTo.Location = new System.Drawing.Point(43, 84);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(200, 20);
            this.dtpTo.TabIndex = 1;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Location = new System.Drawing.Point(43, 57);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(200, 20);
            this.dtpFrom.TabIndex = 0;
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Location = new System.Drawing.Point(12, 64);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 13);
            this.lblError.TabIndex = 9;
            this.lblError.Visible = false;
            // 
            // gBoxDelete
            // 
            this.gBoxDelete.Controls.Add(this.btnDeleteMails);
            this.gBoxDelete.Controls.Add(this.btnDeleteUsernames);
            this.gBoxDelete.Controls.Add(this.btnDeleteMobiles);
            this.gBoxDelete.Location = new System.Drawing.Point(887, 317);
            this.gBoxDelete.Name = "gBoxDelete";
            this.gBoxDelete.Size = new System.Drawing.Size(258, 62);
            this.gBoxDelete.TabIndex = 10;
            this.gBoxDelete.TabStop = false;
            this.gBoxDelete.Text = "Izbrisati sve:";
            // 
            // btnDeleteMails
            // 
            this.btnDeleteMails.Location = new System.Drawing.Point(6, 19);
            this.btnDeleteMails.Name = "btnDeleteMails";
            this.btnDeleteMails.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteMails.TabIndex = 2;
            this.btnDeleteMails.Text = "Mail";
            this.btnDeleteMails.UseVisualStyleBackColor = true;
            this.btnDeleteMails.Click += new System.EventHandler(this.btnDeleteMails_Click);
            // 
            // btnDeleteUsernames
            // 
            this.btnDeleteUsernames.Location = new System.Drawing.Point(168, 19);
            this.btnDeleteUsernames.Name = "btnDeleteUsernames";
            this.btnDeleteUsernames.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteUsernames.TabIndex = 3;
            this.btnDeleteUsernames.Text = "Username";
            this.btnDeleteUsernames.UseVisualStyleBackColor = true;
            this.btnDeleteUsernames.Click += new System.EventHandler(this.btnDeleteUsernames_Click);
            // 
            // btnDeleteMobiles
            // 
            this.btnDeleteMobiles.Location = new System.Drawing.Point(87, 19);
            this.btnDeleteMobiles.Name = "btnDeleteMobiles";
            this.btnDeleteMobiles.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteMobiles.TabIndex = 1;
            this.btnDeleteMobiles.Text = "Mobile";
            this.btnDeleteMobiles.UseVisualStyleBackColor = true;
            this.btnDeleteMobiles.Click += new System.EventHandler(this.btnDeleteMobiles_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1167, 577);
            this.Controls.Add(this.gBoxDelete);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.gBoxTime);
            this.Controls.Add(this.gBoxRefresh);
            this.Controls.Add(this.tBoxCQL);
            this.Controls.Add(this.gBoxCassandra);
            this.Controls.Add(this.dgv);
            this.Name = "MainForm";
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.gBoxCassandra.ResumeLayout(false);
            this.gBoxRefresh.ResumeLayout(false);
            this.gBoxRefresh.PerformLayout();
            this.gBoxTime.ResumeLayout(false);
            this.gBoxTime.PerformLayout();
            this.gBoxDelete.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Button btnMobile;
        private System.Windows.Forms.Button btnMail;
        private System.Windows.Forms.Button btnUsername;
        private System.Windows.Forms.GroupBox gBoxCassandra;
        private System.Windows.Forms.TextBox tBoxCQL;
        private System.Windows.Forms.GroupBox gBoxRefresh;
        private System.Windows.Forms.CheckBox cBoxAutoRefresh;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.GroupBox gBoxTime;
        private System.Windows.Forms.Label lblDo;
        private System.Windows.Forms.Label lblOd;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.RadioButton rBtnMobile;
        private System.Windows.Forms.RadioButton rBtnUsername;
        private System.Windows.Forms.RadioButton rBtnMail;
        private System.Windows.Forms.Button btnTime;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.RadioButton rBtnRefreshMobile;
        private System.Windows.Forms.RadioButton rBtnRefreshUsername;
        private System.Windows.Forms.RadioButton rBtnRefreshMail;
        private System.Windows.Forms.Button btnTimeDelete;
        private System.Windows.Forms.GroupBox gBoxDelete;
        private System.Windows.Forms.Button btnDeleteMails;
        private System.Windows.Forms.Button btnDeleteUsernames;
        private System.Windows.Forms.Button btnDeleteMobiles;
    }
}
﻿
namespace SignalRClient
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
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelCenter = new System.Windows.Forms.Panel();
            this.tabControlChat = new System.Windows.Forms.TabControl();
            this.panelCenterTop = new System.Windows.Forms.Panel();
            this.btnJoinChat = new System.Windows.Forms.Button();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.tlpConnection = new System.Windows.Forms.TableLayoutPanel();
            this.lblProtocol = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.tbPath = new System.Windows.Forms.TextBox();
            this.nudPort = new System.Windows.Forms.NumericUpDown();
            this.lblPassword = new System.Windows.Forms.Label();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.lblPath = new System.Windows.Forms.Label();
            this.cbProtocol = new System.Windows.Forms.ComboBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblPort = new System.Windows.Forms.Label();
            this.lblIp = new System.Windows.Forms.Label();
            this.tbIp = new System.Windows.Forms.TextBox();
            this.panelMain.SuspendLayout();
            this.panelCenter.SuspendLayout();
            this.panelCenterTop.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.tlpConnection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPort)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.panelCenter);
            this.panelMain.Controls.Add(this.panelBottom);
            this.panelMain.Controls.Add(this.panelTop);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(800, 450);
            this.panelMain.TabIndex = 1;
            // 
            // panelCenter
            // 
            this.panelCenter.Controls.Add(this.tabControlChat);
            this.panelCenter.Controls.Add(this.panelCenterTop);
            this.panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenter.Enabled = false;
            this.panelCenter.Location = new System.Drawing.Point(0, 83);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Size = new System.Drawing.Size(800, 330);
            this.panelCenter.TabIndex = 2;
            // 
            // tabControlChat
            // 
            this.tabControlChat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlChat.Location = new System.Drawing.Point(0, 36);
            this.tabControlChat.Name = "tabControlChat";
            this.tabControlChat.SelectedIndex = 0;
            this.tabControlChat.Size = new System.Drawing.Size(800, 294);
            this.tabControlChat.TabIndex = 1;
            // 
            // panelCenterTop
            // 
            this.panelCenterTop.Controls.Add(this.btnJoinChat);
            this.panelCenterTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCenterTop.Location = new System.Drawing.Point(0, 0);
            this.panelCenterTop.Name = "panelCenterTop";
            this.panelCenterTop.Size = new System.Drawing.Size(800, 36);
            this.panelCenterTop.TabIndex = 0;
            // 
            // btnJoinChat
            // 
            this.btnJoinChat.Location = new System.Drawing.Point(13, 7);
            this.btnJoinChat.Name = "btnJoinChat";
            this.btnJoinChat.Size = new System.Drawing.Size(75, 23);
            this.btnJoinChat.TabIndex = 0;
            this.btnJoinChat.Text = "加入聊天室";
            this.btnJoinChat.UseVisualStyleBackColor = true;
            this.btnJoinChat.Click += new System.EventHandler(this.btnJoinChat_Click);
            // 
            // panelBottom
            // 
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 413);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(800, 37);
            this.panelBottom.TabIndex = 1;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.btnDisconnect);
            this.panelTop.Controls.Add(this.btnConnect);
            this.panelTop.Controls.Add(this.tlpConnection);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(800, 83);
            this.panelTop.TabIndex = 0;
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(651, 43);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(75, 23);
            this.btnDisconnect.TabIndex = 4;
            this.btnDisconnect.Text = "登出";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(651, 13);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 3;
            this.btnConnect.Text = "連線";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // tlpConnection
            // 
            this.tlpConnection.ColumnCount = 6;
            this.tlpConnection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tlpConnection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpConnection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpConnection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpConnection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpConnection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpConnection.Controls.Add(this.lblProtocol, 0, 0);
            this.tlpConnection.Controls.Add(this.tbPassword, 5, 1);
            this.tlpConnection.Controls.Add(this.tbPath, 1, 1);
            this.tlpConnection.Controls.Add(this.nudPort, 5, 0);
            this.tlpConnection.Controls.Add(this.lblPassword, 4, 1);
            this.tlpConnection.Controls.Add(this.tbUserName, 3, 1);
            this.tlpConnection.Controls.Add(this.lblPath, 0, 1);
            this.tlpConnection.Controls.Add(this.cbProtocol, 1, 0);
            this.tlpConnection.Controls.Add(this.lblUserName, 2, 1);
            this.tlpConnection.Controls.Add(this.lblPort, 4, 0);
            this.tlpConnection.Controls.Add(this.lblIp, 2, 0);
            this.tlpConnection.Controls.Add(this.tbIp, 3, 0);
            this.tlpConnection.Location = new System.Drawing.Point(12, 12);
            this.tlpConnection.Name = "tlpConnection";
            this.tlpConnection.RowCount = 2;
            this.tlpConnection.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpConnection.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpConnection.Size = new System.Drawing.Size(611, 54);
            this.tlpConnection.TabIndex = 1;
            // 
            // lblProtocol
            // 
            this.lblProtocol.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblProtocol.AutoSize = true;
            this.lblProtocol.Location = new System.Drawing.Point(12, 6);
            this.lblProtocol.Name = "lblProtocol";
            this.lblProtocol.Size = new System.Drawing.Size(55, 15);
            this.lblProtocol.TabIndex = 0;
            this.lblProtocol.Text = "Protocol";
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(473, 30);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(118, 23);
            this.tbPassword.TabIndex = 11;
            this.tbPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbIp_KeyPress);
            // 
            // tbPath
            // 
            this.tbPath.Location = new System.Drawing.Point(73, 30);
            this.tbPath.Name = "tbPath";
            this.tbPath.Size = new System.Drawing.Size(121, 23);
            this.tbPath.TabIndex = 7;
            this.tbPath.Text = "chatHub";
            this.tbPath.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbIp_KeyPress);
            // 
            // nudPort
            // 
            this.nudPort.Location = new System.Drawing.Point(473, 3);
            this.nudPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudPort.Name = "nudPort";
            this.nudPort.Size = new System.Drawing.Size(120, 23);
            this.nudPort.TabIndex = 5;
            this.nudPort.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.nudPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbIp_KeyPress);
            // 
            // lblPassword
            // 
            this.lblPassword.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(436, 33);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(31, 15);
            this.lblPassword.TabIndex = 10;
            this.lblPassword.Text = "密碼";
            // 
            // tbUserName
            // 
            this.tbUserName.Location = new System.Drawing.Point(273, 30);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(144, 23);
            this.tbUserName.TabIndex = 9;
            this.tbUserName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbIp_KeyPress);
            // 
            // lblPath
            // 
            this.lblPath.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(35, 33);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(32, 15);
            this.lblPath.TabIndex = 6;
            this.lblPath.Text = "Path";
            // 
            // cbProtocol
            // 
            this.cbProtocol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProtocol.FormattingEnabled = true;
            this.cbProtocol.Location = new System.Drawing.Point(73, 3);
            this.cbProtocol.Name = "cbProtocol";
            this.cbProtocol.Size = new System.Drawing.Size(121, 23);
            this.cbProtocol.TabIndex = 1;
            // 
            // lblUserName
            // 
            this.lblUserName.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(236, 33);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(31, 15);
            this.lblUserName.TabIndex = 8;
            this.lblUserName.Text = "帳號";
            // 
            // lblPort
            // 
            this.lblPort.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(437, 6);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(30, 15);
            this.lblPort.TabIndex = 4;
            this.lblPort.Text = "Port";
            // 
            // lblIp
            // 
            this.lblIp.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblIp.AutoSize = true;
            this.lblIp.Location = new System.Drawing.Point(250, 6);
            this.lblIp.Name = "lblIp";
            this.lblIp.Size = new System.Drawing.Size(17, 15);
            this.lblIp.TabIndex = 2;
            this.lblIp.Text = "IP";
            // 
            // tbIp
            // 
            this.tbIp.Location = new System.Drawing.Point(273, 3);
            this.tbIp.MaxLength = 50;
            this.tbIp.Name = "tbIp";
            this.tbIp.PlaceholderText = "請輸入Server IP";
            this.tbIp.Size = new System.Drawing.Size(144, 23);
            this.tbIp.TabIndex = 3;
            this.tbIp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbIp_KeyPress);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelMain);
            this.Name = "MainForm";
            this.Text = "SignalR聊天室";
            this.panelMain.ResumeLayout(false);
            this.panelCenter.ResumeLayout(false);
            this.panelCenterTop.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.tlpConnection.ResumeLayout(false);
            this.tlpConnection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPort)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelCenter;
        private System.Windows.Forms.TabControl tabControlChat;
        private System.Windows.Forms.Panel panelCenterTop;
        private System.Windows.Forms.Button btnJoinChat;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.TableLayoutPanel tlpConnection;
        private System.Windows.Forms.Label lblProtocol;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.TextBox tbPath;
        private System.Windows.Forms.NumericUpDown nudPort;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox tbUserName;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.ComboBox cbProtocol;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Label lblIp;
        private System.Windows.Forms.TextBox tbIp;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnConnect;
    }
}
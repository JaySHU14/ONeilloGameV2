namespace ONeilloGameV2
{
    partial class Form1
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informationPanelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.speakToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoPanel = new System.Windows.Forms.Panel();
            this.labelPlayer2Score = new System.Windows.Forms.Label();
            this.labelPlayer1Score = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.statusLabel1 = new System.Windows.Forms.Label();
            this.menuStrip.SuspendLayout();
            this.infoPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(539, 28);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameMenuItem,
            this.saveGameToolStripMenuItem});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(62, 24);
            this.gameToolStripMenuItem.Text = "Game";
            // 
            // newGameMenuItem
            // 
            this.newGameMenuItem.Name = "newGameMenuItem";
            this.newGameMenuItem.Size = new System.Drawing.Size(224, 26);
            this.newGameMenuItem.Text = "New Game";
            this.newGameMenuItem.Click += new System.EventHandler(this.newGameMenuItem_Click);
            // 
            // saveGameToolStripMenuItem
            // 
            this.saveGameToolStripMenuItem.Name = "saveGameToolStripMenuItem";
            this.saveGameToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.saveGameToolStripMenuItem.Text = "Save Game";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.informationPanelToolStripMenuItem,
            this.speakToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(76, 24);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // informationPanelToolStripMenuItem
            // 
            this.informationPanelToolStripMenuItem.Checked = true;
            this.informationPanelToolStripMenuItem.CheckOnClick = true;
            this.informationPanelToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.informationPanelToolStripMenuItem.Name = "informationPanelToolStripMenuItem";
            this.informationPanelToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.informationPanelToolStripMenuItem.Text = "Information Panel";
            this.informationPanelToolStripMenuItem.Click += new System.EventHandler(this.informationPanelToolStripMenuItem_Click);
            // 
            // speakToolStripMenuItem
            // 
            this.speakToolStripMenuItem.Name = "speakToolStripMenuItem";
            this.speakToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.speakToolStripMenuItem.Text = "Speak";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // infoPanel
            // 
            this.infoPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.infoPanel.Controls.Add(this.statusLabel1);
            this.infoPanel.Controls.Add(this.labelPlayer2Score);
            this.infoPanel.Controls.Add(this.labelPlayer1Score);
            this.infoPanel.Controls.Add(this.textBox2);
            this.infoPanel.Controls.Add(this.textBox1);
            this.infoPanel.Location = new System.Drawing.Point(16, 564);
            this.infoPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.infoPanel.Name = "infoPanel";
            this.infoPanel.Size = new System.Drawing.Size(507, 108);
            this.infoPanel.TabIndex = 1;
            // 
            // labelPlayer2Score
            // 
            this.labelPlayer2Score.AutoSize = true;
            this.labelPlayer2Score.Location = new System.Drawing.Point(371, 66);
            this.labelPlayer2Score.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPlayer2Score.Name = "labelPlayer2Score";
            this.labelPlayer2Score.Size = new System.Drawing.Size(43, 16);
            this.labelPlayer2Score.TabIndex = 3;
            this.labelPlayer2Score.Text = "Score";
            // 
            // labelPlayer1Score
            // 
            this.labelPlayer1Score.AutoSize = true;
            this.labelPlayer1Score.Location = new System.Drawing.Point(44, 66);
            this.labelPlayer1Score.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPlayer1Score.Name = "labelPlayer1Score";
            this.labelPlayer1Score.Size = new System.Drawing.Size(43, 16);
            this.labelPlayer1Score.TabIndex = 2;
            this.labelPlayer1Score.Text = "Score";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(327, 38);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(149, 22);
            this.textBox2.TabIndex = 1;
            this.textBox2.Text = "Player #2";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(48, 38);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(149, 22);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "Player #1";
            // 
            // statusLabel1
            // 
            this.statusLabel1.AutoSize = true;
            this.statusLabel1.Location = new System.Drawing.Point(166, 18);
            this.statusLabel1.Name = "statusLabel1";
            this.statusLabel1.Size = new System.Drawing.Size(44, 16);
            this.statusLabel1.TabIndex = 4;
            this.statusLabel1.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 690);
            this.Controls.Add(this.infoPanel);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.infoPanel.ResumeLayout(false);
            this.infoPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newGameMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informationPanelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem speakToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Panel infoPanel;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label labelPlayer2Score;
        private System.Windows.Forms.Label labelPlayer1Score;
        private System.Windows.Forms.Label statusLabel1;
    }
}


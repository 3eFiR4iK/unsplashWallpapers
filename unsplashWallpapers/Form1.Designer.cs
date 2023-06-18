namespace unsplashWallpapers
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.addTagInput = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tagSelector = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.settingsDownloadPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.settingsInterval = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.settingsApiKey = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.settingsInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // addTagInput
            // 
            this.addTagInput.Location = new System.Drawing.Point(14, 28);
            this.addTagInput.Name = "addTagInput";
            this.addTagInput.Size = new System.Drawing.Size(262, 23);
            this.addTagInput.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(282, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Добавить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.addTagInput);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(25, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(363, 70);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Добавить тег";
            // 
            // tagSelector
            // 
            this.tagSelector.FormattingEnabled = true;
            this.tagSelector.ItemHeight = 15;
            this.tagSelector.Location = new System.Drawing.Point(39, 123);
            this.tagSelector.Name = "tagSelector";
            this.tagSelector.Size = new System.Drawing.Size(262, 109);
            this.tagSelector.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(307, 123);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Удалить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.settingsDownloadPath);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.settingsInterval);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.settingsApiKey);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Location = new System.Drawing.Point(25, 278);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(363, 275);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Настройки";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(309, 160);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(28, 23);
            this.button4.TabIndex = 8;
            this.button4.Text = "...";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(176, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Папка для сохранения файлов";
            // 
            // settingsDownloadPath
            // 
            this.settingsDownloadPath.Location = new System.Drawing.Point(21, 161);
            this.settingsDownloadPath.Name = "settingsDownloadPath";
            this.settingsDownloadPath.Size = new System.Drawing.Size(282, 23);
            this.settingsDownloadPath.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(197, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Через сколько менять обои (мин.)";
            // 
            // settingsInterval
            // 
            this.settingsInterval.Location = new System.Drawing.Point(21, 105);
            this.settingsInterval.Name = "settingsInterval";
            this.settingsInterval.Size = new System.Drawing.Size(120, 23);
            this.settingsInterval.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Unsplash ApiKey";
            // 
            // settingsApiKey
            // 
            this.settingsApiKey.Location = new System.Drawing.Point(21, 50);
            this.settingsApiKey.Name = "settingsApiKey";
            this.settingsApiKey.Size = new System.Drawing.Size(316, 23);
            this.settingsApiKey.TabIndex = 1;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(282, 246);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 0;
            this.button3.Text = "Сохранить";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipText = "wallpappers";
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 650);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.tagSelector);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Unsplash auto wallpappers";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.settingsInterval)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TextBox addTagInput;
        private Button button1;
        private GroupBox groupBox1;
        private ListBox tagSelector;
        private Button button2;
        private GroupBox groupBox2;
        private Label label1;
        private TextBox settingsApiKey;
        private Button button3;
        private System.Windows.Forms.Timer timer1;
        private Label label2;
        private NumericUpDown settingsInterval;
        private FolderBrowserDialog folderBrowserDialog1;
        private TextBox settingsDownloadPath;
        private Button button4;
        private Label label3;
        private NotifyIcon notifyIcon1;
    }
}
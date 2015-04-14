namespace WindowsFormsApplication3
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.SNTextBox = new System.Windows.Forms.TextBox();
            this.InterfaceTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.deviceInfoPanel = new System.Windows.Forms.Panel();
            this.errorDevicePanel = new System.Windows.Forms.Panel();
            this.errorLabel = new System.Windows.Forms.Label();
            this.errorTextBox = new System.Windows.Forms.TextBox();
            this.propertiesDevicePanel = new System.Windows.Forms.Panel();
            this.signalLevelTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.signalLevelProgressBar = new System.Windows.Forms.ProgressBar();
            this.frequencyTrackBar = new System.Windows.Forms.TrackBar();
            this.FrequencyLabel = new System.Windows.Forms.Label();
            this.frequencyUDBox = new System.Windows.Forms.NumericUpDown();
            this.timerConnection = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.statusBar = new System.Windows.Forms.ToolStripLabel();
            this.deviceInfoPanel.SuspendLayout();
            this.errorDevicePanel.SuspendLayout();
            this.propertiesDevicePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.frequencyTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frequencyUDBox)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(478, 11);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(148, 54);
            this.button1.TabIndex = 0;
            this.button1.Text = "Connect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SNTextBox
            // 
            this.SNTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SNTextBox.Location = new System.Drawing.Point(104, 5);
            this.SNTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SNTextBox.Name = "SNTextBox";
            this.SNTextBox.Size = new System.Drawing.Size(357, 26);
            this.SNTextBox.TabIndex = 1;
            // 
            // InterfaceTextBox
            // 
            this.InterfaceTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InterfaceTextBox.Location = new System.Drawing.Point(104, 33);
            this.InterfaceTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.InterfaceTextBox.Name = "InterfaceTextBox";
            this.InterfaceTextBox.Size = new System.Drawing.Size(357, 26);
            this.InterfaceTextBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(4, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "SN:";
            this.label1.UseWaitCursor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(4, 36);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Interface:";
            this.label2.UseWaitCursor = true;
            // 
            // deviceInfoPanel
            // 
            this.deviceInfoPanel.Controls.Add(this.InterfaceTextBox);
            this.deviceInfoPanel.Controls.Add(this.SNTextBox);
            this.deviceInfoPanel.Controls.Add(this.label2);
            this.deviceInfoPanel.Controls.Add(this.label1);
            this.deviceInfoPanel.Location = new System.Drawing.Point(4, 6);
            this.deviceInfoPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.deviceInfoPanel.Name = "deviceInfoPanel";
            this.deviceInfoPanel.Size = new System.Drawing.Size(470, 64);
            this.deviceInfoPanel.TabIndex = 5;
            this.deviceInfoPanel.Visible = false;
            // 
            // errorDevicePanel
            // 
            this.errorDevicePanel.Controls.Add(this.errorLabel);
            this.errorDevicePanel.Controls.Add(this.errorTextBox);
            this.errorDevicePanel.Location = new System.Drawing.Point(8, 6);
            this.errorDevicePanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.errorDevicePanel.Name = "errorDevicePanel";
            this.errorDevicePanel.Size = new System.Drawing.Size(466, 64);
            this.errorDevicePanel.TabIndex = 6;
            this.errorDevicePanel.Visible = false;
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.errorLabel.ForeColor = System.Drawing.Color.OrangeRed;
            this.errorLabel.Location = new System.Drawing.Point(4, 22);
            this.errorLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(48, 20);
            this.errorLabel.TabIndex = 3;
            this.errorLabel.Text = "Error:";
            this.errorLabel.Click += new System.EventHandler(this.label4_Click);
            // 
            // errorTextBox
            // 
            this.errorTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.errorTextBox.Location = new System.Drawing.Point(104, 5);
            this.errorTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.errorTextBox.Multiline = true;
            this.errorTextBox.Name = "errorTextBox";
            this.errorTextBox.Size = new System.Drawing.Size(357, 54);
            this.errorTextBox.TabIndex = 1;
            this.errorTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // propertiesDevicePanel
            // 
            this.propertiesDevicePanel.Controls.Add(this.signalLevelTextBox);
            this.propertiesDevicePanel.Controls.Add(this.label4);
            this.propertiesDevicePanel.Controls.Add(this.signalLevelProgressBar);
            this.propertiesDevicePanel.Controls.Add(this.frequencyTrackBar);
            this.propertiesDevicePanel.Controls.Add(this.FrequencyLabel);
            this.propertiesDevicePanel.Controls.Add(this.frequencyUDBox);
            this.propertiesDevicePanel.Location = new System.Drawing.Point(4, 75);
            this.propertiesDevicePanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.propertiesDevicePanel.Name = "propertiesDevicePanel";
            this.propertiesDevicePanel.Size = new System.Drawing.Size(622, 143);
            this.propertiesDevicePanel.TabIndex = 7;
            // 
            // signalLevelTextBox
            // 
            this.signalLevelTextBox.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.signalLevelTextBox.Location = new System.Drawing.Point(474, 100);
            this.signalLevelTextBox.Name = "signalLevelTextBox";
            this.signalLevelTextBox.Size = new System.Drawing.Size(148, 26);
            this.signalLevelTextBox.TabIndex = 5;
            this.signalLevelTextBox.UseWaitCursor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Signal Level";
            this.label4.UseWaitCursor = true;
            // 
            // signalLevelProgressBar
            // 
            this.signalLevelProgressBar.BackColor = System.Drawing.SystemColors.Control;
            this.signalLevelProgressBar.ForeColor = System.Drawing.Color.GreenYellow;
            this.signalLevelProgressBar.Location = new System.Drawing.Point(104, 100);
            this.signalLevelProgressBar.Maximum = 900;
            this.signalLevelProgressBar.Name = "signalLevelProgressBar";
            this.signalLevelProgressBar.Size = new System.Drawing.Size(357, 23);
            this.signalLevelProgressBar.Step = 1;
            this.signalLevelProgressBar.TabIndex = 3;
            // 
            // frequencyTrackBar
            // 
            this.frequencyTrackBar.LargeChange = 10;
            this.frequencyTrackBar.Location = new System.Drawing.Point(104, 45);
            this.frequencyTrackBar.Name = "frequencyTrackBar";
            this.frequencyTrackBar.Size = new System.Drawing.Size(507, 45);
            this.frequencyTrackBar.TabIndex = 2;
            this.frequencyTrackBar.ValueChanged += new System.EventHandler(this.frequencyTrackBar_ValueChanged);
            // 
            // FrequencyLabel
            // 
            this.FrequencyLabel.AutoSize = true;
            this.FrequencyLabel.Location = new System.Drawing.Point(4, 40);
            this.FrequencyLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.FrequencyLabel.Name = "FrequencyLabel";
            this.FrequencyLabel.Size = new System.Drawing.Size(88, 20);
            this.FrequencyLabel.TabIndex = 1;
            this.FrequencyLabel.Text = "Frequency:";
            // 
            // frequencyUDBox
            // 
            this.frequencyUDBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.frequencyUDBox.Location = new System.Drawing.Point(314, 11);
            this.frequencyUDBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.frequencyUDBox.Name = "frequencyUDBox";
            this.frequencyUDBox.Size = new System.Drawing.Size(147, 26);
            this.frequencyUDBox.TabIndex = 0;
            this.frequencyUDBox.ValueChanged += new System.EventHandler(this.frequencyUDBox_ValueChanged);
            // 
            // timerConnection
            // 
            this.timerConnection.Interval = 500;
            this.timerConnection.Tick += new System.EventHandler(this.timerConnection_Tick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusBar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 224);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(631, 25);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // statusBar
            // 
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(0, 22);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(631, 249);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.deviceInfoPanel);
            this.Controls.Add(this.propertiesDevicePanel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.errorDevicePanel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "WINRADIO Test";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.deviceInfoPanel.ResumeLayout(false);
            this.deviceInfoPanel.PerformLayout();
            this.errorDevicePanel.ResumeLayout(false);
            this.errorDevicePanel.PerformLayout();
            this.propertiesDevicePanel.ResumeLayout(false);
            this.propertiesDevicePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.frequencyTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frequencyUDBox)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void label4_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox SNTextBox;
        private System.Windows.Forms.TextBox InterfaceTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel deviceInfoPanel;
        private System.Windows.Forms.Panel errorDevicePanel;
        private System.Windows.Forms.TextBox errorTextBox;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.Panel propertiesDevicePanel;
        private System.Windows.Forms.NumericUpDown frequencyUDBox;
        private System.Windows.Forms.Label FrequencyLabel;
        private System.Windows.Forms.TrackBar frequencyTrackBar;
        private System.Windows.Forms.Timer timerConnection;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ProgressBar signalLevelProgressBar;
        private System.Windows.Forms.TextBox signalLevelTextBox;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel statusBar;
    }
}


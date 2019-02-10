namespace ItsHotInHere
{
  partial class Main
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
      this.components = new System.ComponentModel.Container();
      this.temperatureProcessedBox = new System.Windows.Forms.PictureBox();
      this.thresholdTrackbar = new System.Windows.Forms.TrackBar();
      this.tempResult = new System.Windows.Forms.TextBox();
      this.videoSourcePlayer = new AForge.Controls.VideoSourcePlayer();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.erodeTrackbar = new System.Windows.Forms.TrackBar();
      this.psmCombo = new System.Windows.Forms.ComboBox();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.grayTrackbar = new System.Windows.Forms.TrackBar();
      this.detectTimer = new System.Windows.Forms.Timer(this.components);
      this.updateDbTimer = new System.Windows.Forms.Timer(this.components);
      this.label5 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.humidityProcessedBox = new System.Windows.Forms.PictureBox();
      this.humidityResult = new System.Windows.Forms.TextBox();
      this.temperatureButton = new System.Windows.Forms.Button();
      this.humidityButton = new System.Windows.Forms.Button();
      this.label7 = new System.Windows.Forms.Label();
      this.label8 = new System.Windows.Forms.Label();
      this.tempConfidence = new System.Windows.Forms.Label();
      this.humidityConfidence = new System.Windows.Forms.Label();
      this.historyTextBox = new System.Windows.Forms.TextBox();
      this.label9 = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.temperatureProcessedBox)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.thresholdTrackbar)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.erodeTrackbar)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.grayTrackbar)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.humidityProcessedBox)).BeginInit();
      this.SuspendLayout();
      // 
      // temperatureProcessedBox
      // 
      this.temperatureProcessedBox.Location = new System.Drawing.Point(12, 340);
      this.temperatureProcessedBox.Name = "temperatureProcessedBox";
      this.temperatureProcessedBox.Size = new System.Drawing.Size(250, 225);
      this.temperatureProcessedBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.temperatureProcessedBox.TabIndex = 2;
      this.temperatureProcessedBox.TabStop = false;
      // 
      // thresholdTrackbar
      // 
      this.thresholdTrackbar.Location = new System.Drawing.Point(542, 88);
      this.thresholdTrackbar.Name = "thresholdTrackbar";
      this.thresholdTrackbar.Size = new System.Drawing.Size(287, 45);
      this.thresholdTrackbar.TabIndex = 3;
      this.thresholdTrackbar.TickStyle = System.Windows.Forms.TickStyle.None;
      // 
      // tempResult
      // 
      this.tempResult.Font = new System.Drawing.Font("Consolas", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.tempResult.Location = new System.Drawing.Point(12, 571);
      this.tempResult.Multiline = true;
      this.tempResult.Name = "tempResult";
      this.tempResult.ReadOnly = true;
      this.tempResult.Size = new System.Drawing.Size(250, 116);
      this.tempResult.TabIndex = 4;
      // 
      // videoSourcePlayer
      // 
      this.videoSourcePlayer.Location = new System.Drawing.Point(12, 12);
      this.videoSourcePlayer.Name = "videoSourcePlayer";
      this.videoSourcePlayer.Size = new System.Drawing.Size(506, 266);
      this.videoSourcePlayer.TabIndex = 5;
      this.videoSourcePlayer.Text = "videoSourcePlayer1";
      this.videoSourcePlayer.VideoSource = null;
      this.videoSourcePlayer.NewFrame += new AForge.Controls.VideoSourcePlayer.NewFrameHandler(this.videoSourcePlayer_NewFrame);
      this.videoSourcePlayer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.videoSourcePlayer_MouseDown);
      this.videoSourcePlayer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.videoSourcePlayer_MouseMove);
      this.videoSourcePlayer.MouseUp += new System.Windows.Forms.MouseEventHandler(this.VideoSourcePlayer_MouseUp);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(550, 72);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(54, 13);
      this.label1.TabIndex = 6;
      this.label1.Text = "Threshold";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(550, 136);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(35, 13);
      this.label2.TabIndex = 7;
      this.label2.Text = "Erode";
      // 
      // erodeTrackbar
      // 
      this.erodeTrackbar.Location = new System.Drawing.Point(542, 152);
      this.erodeTrackbar.Name = "erodeTrackbar";
      this.erodeTrackbar.Size = new System.Drawing.Size(287, 45);
      this.erodeTrackbar.TabIndex = 8;
      this.erodeTrackbar.TickStyle = System.Windows.Forms.TickStyle.None;
      // 
      // psmCombo
      // 
      this.psmCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.psmCombo.FormattingEnabled = true;
      this.psmCombo.Location = new System.Drawing.Point(542, 203);
      this.psmCombo.Name = "psmCombo";
      this.psmCombo.Size = new System.Drawing.Size(276, 21);
      this.psmCombo.TabIndex = 9;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(550, 184);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(30, 13);
      this.label3.TabIndex = 10;
      this.label3.Text = "PSM";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(550, 8);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(29, 13);
      this.label4.TabIndex = 11;
      this.label4.Text = "Gray";
      // 
      // grayTrackbar
      // 
      this.grayTrackbar.Location = new System.Drawing.Point(542, 24);
      this.grayTrackbar.Name = "grayTrackbar";
      this.grayTrackbar.Size = new System.Drawing.Size(287, 45);
      this.grayTrackbar.TabIndex = 12;
      this.grayTrackbar.TickStyle = System.Windows.Forms.TickStyle.None;
      // 
      // detectTimer
      // 
      this.detectTimer.Interval = 2000;
      this.detectTimer.Tick += new System.EventHandler(this.DetectTimer_Tick);
      // 
      // updateDbTimer
      // 
      this.updateDbTimer.Interval = 300000;
      this.updateDbTimer.Tick += new System.EventHandler(this.UpdateDbTimer_Tick);
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(12, 324);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(67, 13);
      this.label5.TabIndex = 13;
      this.label5.Text = "Temperature";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(265, 324);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(47, 13);
      this.label6.TabIndex = 14;
      this.label6.Text = "Humidity";
      // 
      // humidityProcessedBox
      // 
      this.humidityProcessedBox.Location = new System.Drawing.Point(268, 340);
      this.humidityProcessedBox.Name = "humidityProcessedBox";
      this.humidityProcessedBox.Size = new System.Drawing.Size(250, 225);
      this.humidityProcessedBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.humidityProcessedBox.TabIndex = 15;
      this.humidityProcessedBox.TabStop = false;
      // 
      // humidityResult
      // 
      this.humidityResult.Font = new System.Drawing.Font("Consolas", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.humidityResult.Location = new System.Drawing.Point(268, 571);
      this.humidityResult.Multiline = true;
      this.humidityResult.Name = "humidityResult";
      this.humidityResult.ReadOnly = true;
      this.humidityResult.Size = new System.Drawing.Size(250, 116);
      this.humidityResult.TabIndex = 16;
      // 
      // temperatureButton
      // 
      this.temperatureButton.BackColor = System.Drawing.Color.Red;
      this.temperatureButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.temperatureButton.ForeColor = System.Drawing.Color.Yellow;
      this.temperatureButton.Location = new System.Drawing.Point(12, 284);
      this.temperatureButton.Name = "temperatureButton";
      this.temperatureButton.Size = new System.Drawing.Size(250, 23);
      this.temperatureButton.TabIndex = 17;
      this.temperatureButton.Text = "Select temperature";
      this.temperatureButton.UseVisualStyleBackColor = false;
      this.temperatureButton.Click += new System.EventHandler(this.TemperatureButton_Click);
      // 
      // humidityButton
      // 
      this.humidityButton.BackColor = System.Drawing.Color.Blue;
      this.humidityButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.humidityButton.ForeColor = System.Drawing.Color.Yellow;
      this.humidityButton.Location = new System.Drawing.Point(268, 284);
      this.humidityButton.Name = "humidityButton";
      this.humidityButton.Size = new System.Drawing.Size(250, 23);
      this.humidityButton.TabIndex = 18;
      this.humidityButton.Text = "Select humidity";
      this.humidityButton.UseVisualStyleBackColor = false;
      this.humidityButton.Click += new System.EventHandler(this.HumidityButton_Click);
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(9, 694);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(64, 13);
      this.label7.TabIndex = 19;
      this.label7.Text = "Confidence:";
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(265, 694);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(64, 13);
      this.label8.TabIndex = 20;
      this.label8.Text = "Confidence:";
      // 
      // tempConfidence
      // 
      this.tempConfidence.AutoSize = true;
      this.tempConfidence.Location = new System.Drawing.Point(70, 694);
      this.tempConfidence.Name = "tempConfidence";
      this.tempConfidence.Size = new System.Drawing.Size(19, 13);
      this.tempConfidence.TabIndex = 21;
      this.tempConfidence.Text = "??";
      // 
      // humidityConfidence
      // 
      this.humidityConfidence.AutoSize = true;
      this.humidityConfidence.Location = new System.Drawing.Point(326, 694);
      this.humidityConfidence.Name = "humidityConfidence";
      this.humidityConfidence.Size = new System.Drawing.Size(19, 13);
      this.humidityConfidence.TabIndex = 22;
      this.humidityConfidence.Text = "??";
      // 
      // historyTextBox
      // 
      this.historyTextBox.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.historyTextBox.Location = new System.Drawing.Point(542, 340);
      this.historyTextBox.Multiline = true;
      this.historyTextBox.Name = "historyTextBox";
      this.historyTextBox.ReadOnly = true;
      this.historyTextBox.Size = new System.Drawing.Size(287, 347);
      this.historyTextBox.TabIndex = 23;
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Location = new System.Drawing.Point(542, 321);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(39, 13);
      this.label9.TabIndex = 24;
      this.label9.Text = "History";
      // 
      // Main
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(850, 768);
      this.Controls.Add(this.label9);
      this.Controls.Add(this.historyTextBox);
      this.Controls.Add(this.humidityConfidence);
      this.Controls.Add(this.tempConfidence);
      this.Controls.Add(this.label8);
      this.Controls.Add(this.label7);
      this.Controls.Add(this.humidityButton);
      this.Controls.Add(this.temperatureButton);
      this.Controls.Add(this.humidityResult);
      this.Controls.Add(this.humidityProcessedBox);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.grayTrackbar);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.psmCombo);
      this.Controls.Add(this.erodeTrackbar);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.videoSourcePlayer);
      this.Controls.Add(this.tempResult);
      this.Controls.Add(this.thresholdTrackbar);
      this.Controls.Add(this.temperatureProcessedBox);
      this.Name = "Main";
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
      this.Text = "Main";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
      ((System.ComponentModel.ISupportInitialize)(this.temperatureProcessedBox)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.thresholdTrackbar)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.erodeTrackbar)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.grayTrackbar)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.humidityProcessedBox)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.PictureBox temperatureProcessedBox;
    private System.Windows.Forms.TrackBar thresholdTrackbar;
    private System.Windows.Forms.TextBox tempResult;
    private AForge.Controls.VideoSourcePlayer videoSourcePlayer;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TrackBar erodeTrackbar;
    private System.Windows.Forms.ComboBox psmCombo;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TrackBar grayTrackbar;
    private System.Windows.Forms.Timer detectTimer;
    private System.Windows.Forms.Timer updateDbTimer;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.PictureBox humidityProcessedBox;
    private System.Windows.Forms.TextBox humidityResult;
    private System.Windows.Forms.Button temperatureButton;
    private System.Windows.Forms.Button humidityButton;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Label tempConfidence;
    private System.Windows.Forms.Label humidityConfidence;
    private System.Windows.Forms.TextBox historyTextBox;
    private System.Windows.Forms.Label label9;
  }
}
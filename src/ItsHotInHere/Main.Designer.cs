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
      this.processedBox = new System.Windows.Forms.PictureBox();
      this.thresholdTrackbar = new System.Windows.Forms.TrackBar();
      this.resultTextBox = new System.Windows.Forms.TextBox();
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
      ((System.ComponentModel.ISupportInitialize)(this.processedBox)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.thresholdTrackbar)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.erodeTrackbar)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.grayTrackbar)).BeginInit();
      this.SuspendLayout();
      // 
      // processedBox
      // 
      this.processedBox.Location = new System.Drawing.Point(12, 243);
      this.processedBox.Name = "processedBox";
      this.processedBox.Size = new System.Drawing.Size(400, 225);
      this.processedBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.processedBox.TabIndex = 2;
      this.processedBox.TabStop = false;
      // 
      // thresholdTrackbar
      // 
      this.thresholdTrackbar.Location = new System.Drawing.Point(478, 56);
      this.thresholdTrackbar.Name = "thresholdTrackbar";
      this.thresholdTrackbar.Size = new System.Drawing.Size(287, 45);
      this.thresholdTrackbar.TabIndex = 3;
      // 
      // resultTextBox
      // 
      this.resultTextBox.Font = new System.Drawing.Font("Consolas", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.resultTextBox.Location = new System.Drawing.Point(418, 243);
      this.resultTextBox.Multiline = true;
      this.resultTextBox.Name = "resultTextBox";
      this.resultTextBox.ReadOnly = true;
      this.resultTextBox.Size = new System.Drawing.Size(347, 225);
      this.resultTextBox.TabIndex = 4;
      // 
      // videoSourcePlayer
      // 
      this.videoSourcePlayer.Location = new System.Drawing.Point(12, 12);
      this.videoSourcePlayer.Name = "videoSourcePlayer";
      this.videoSourcePlayer.Size = new System.Drawing.Size(400, 225);
      this.videoSourcePlayer.TabIndex = 5;
      this.videoSourcePlayer.Text = "videoSourcePlayer1";
      this.videoSourcePlayer.VideoSource = null;
      this.videoSourcePlayer.NewFrame += new AForge.Controls.VideoSourcePlayer.NewFrameHandler(this.videoSourcePlayer_NewFrame);
      this.videoSourcePlayer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.videoSourcePlayer_MouseDown);
      this.videoSourcePlayer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.videoSourcePlayer_MouseMove);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(423, 60);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(54, 13);
      this.label1.TabIndex = 6;
      this.label1.Text = "Threshold";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(443, 102);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(35, 13);
      this.label2.TabIndex = 7;
      this.label2.Text = "Erode";
      // 
      // erodeTrackbar
      // 
      this.erodeTrackbar.Location = new System.Drawing.Point(478, 98);
      this.erodeTrackbar.Name = "erodeTrackbar";
      this.erodeTrackbar.Size = new System.Drawing.Size(287, 45);
      this.erodeTrackbar.TabIndex = 8;
      // 
      // psmCombo
      // 
      this.psmCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.psmCombo.FormattingEnabled = true;
      this.psmCombo.Location = new System.Drawing.Point(489, 144);
      this.psmCombo.Name = "psmCombo";
      this.psmCombo.Size = new System.Drawing.Size(276, 21);
      this.psmCombo.TabIndex = 9;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(447, 147);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(30, 13);
      this.label3.TabIndex = 10;
      this.label3.Text = "PSM";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(448, 16);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(29, 13);
      this.label4.TabIndex = 11;
      this.label4.Text = "Gray";
      // 
      // grayTrackbar
      // 
      this.grayTrackbar.Location = new System.Drawing.Point(478, 12);
      this.grayTrackbar.Name = "grayTrackbar";
      this.grayTrackbar.Size = new System.Drawing.Size(287, 45);
      this.grayTrackbar.TabIndex = 12;
      // 
      // Main
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(777, 512);
      this.Controls.Add(this.grayTrackbar);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.psmCombo);
      this.Controls.Add(this.erodeTrackbar);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.videoSourcePlayer);
      this.Controls.Add(this.resultTextBox);
      this.Controls.Add(this.thresholdTrackbar);
      this.Controls.Add(this.processedBox);
      this.Name = "Main";
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
      this.Text = "Main";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
      ((System.ComponentModel.ISupportInitialize)(this.processedBox)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.thresholdTrackbar)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.erodeTrackbar)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.grayTrackbar)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.PictureBox processedBox;
    private System.Windows.Forms.TrackBar thresholdTrackbar;
    private System.Windows.Forms.TextBox resultTextBox;
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
  }
}
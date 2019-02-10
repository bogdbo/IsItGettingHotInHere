using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Tesseract;

namespace ItsHotInHere
{
  public partial class Main : Form
  {
    protected internal TesseractEngine TesseractEngine;

    private Rectangle tempSelection;
    private Rectangle normalizedTempSelection;
    private Rectangle humiditySelection;
    private Rectangle normalizedHumiditySelection;

    public Main()
    {
      InitializeComponent();

      StartWebcam();
      SetupTesseract();
      SetupTrackbars();
      SetupComboBox();
    }

    private void SetupComboBox()
    {
      foreach (var pageSegMode in Enum.GetNames(typeof(PageSegMode)))
      {
        psmCombo.Items.Add(pageSegMode);
      }

      psmCombo.SelectedIndex = Settings.Default.psm;
    }

    private void SetupTrackbars()
    {
      thresholdTrackbar.SetRange(3, 1003);
      thresholdTrackbar.Value = Settings.Default.threshold;
      thresholdTrackbar.SmallChange = 8;
      thresholdTrackbar.LargeChange = 32;

      erodeTrackbar.SetRange(1, 20);
      erodeTrackbar.SmallChange = 1;
      erodeTrackbar.LargeChange = 3;
      erodeTrackbar.Value = Settings.Default.erode;

      grayTrackbar.SetRange(1, 100);
      grayTrackbar.Value = Settings.Default.gray;
    }

    private void SetupTesseract()
    {
      TesseractEngine = new TesseractEngine(
        @"./tessdata",
        "digital",
        EngineMode.Default,
        Enumerable.Empty<string>(),
        new Dictionary<string, object>
        {
          {"tessedit_char_whitelist", ".0123456789"},
        }, false);
    }

    private void StartWebcam()
    {
      var devices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
      if (devices.Count == 0)
      {
        MessageBox.Show("No camera found");
      }

      // create video source
      VideoCaptureDevice videoSource = new VideoCaptureDevice(devices[0].MonikerString);

      // open it
      OpenVideoSource(videoSource);
    }

    private string Detect(IImage img)
    {
      try
      {
        var mode = (PageSegMode)Enum.Parse(typeof(PageSegMode), (string)psmCombo.SelectedItem);
        using (var page = TesseractEngine.Process(img.Bitmap, mode))
        {
          return page.GetText();
        }
      }
      catch (Exception e)
      {
        MessageBox.Show(e.Message);
      }

      return String.Empty;
    }

    private void OpenVideoSource(IVideoSource source)
    {
      // set busy cursor
      this.Cursor = Cursors.WaitCursor;

      // stop current video source
      CloseCurrentVideoSource();

      // start new video source
      videoSourcePlayer.VideoSource = source;
      videoSourcePlayer.Start();

      this.Cursor = Cursors.Default;
    }

    private void CloseCurrentVideoSource()
    {
      if (videoSourcePlayer.VideoSource != null)
      {
        videoSourcePlayer.SignalToStop();
        videoSourcePlayer.WaitForStop();

        // wait ~ 3 seconds
        for (int i = 0; i < 10; i++)
        {
          if (!videoSourcePlayer.IsRunning)
            break;
          System.Threading.Thread.Sleep(100);
        }

        if (videoSourcePlayer.IsRunning)
        {
          videoSourcePlayer.Stop();
        }

        videoSourcePlayer.VideoSource = null;
      }
    }

    private DateTime detectTimestamp = DateTime.Now;
    protected internal TimeSpan DetectEverySeconds = TimeSpan.FromSeconds(2);

    private void videoSourcePlayer_NewFrame(object sender, ref Bitmap image)
    {
      using (Graphics g = Graphics.FromImage(image))
      {
        if (tempSelection.Width != 0 && tempSelection.Height != 0)
        {
          using (Pen pen = new Pen(Color.Red, 5))
          {
            normalizedTempSelection = NormalizeRectangle(tempSelection, image);
            g.DrawRectangle(pen, normalizedTempSelection);
          }
        }
      }

      //videoSourcePlayer.Invoke((MethodInvoker)(() =>
      // {
      //   // this needs to be odd value otherwise crash
      //   var value = thresholdTrackbar.Value % 2 == 0 ? thresholdTrackbar.Value + 1 : thresholdTrackbar.Value;

      //   var currentVideoFrame = videoSourcePlayer.GetCurrentVideoFrame();
      //   // video stream still initializing
      //   if (currentVideoFrame == null)
      //   {
      //     return;
      //   }

      //   if (tempSelection.Width == 0 && tempSelection.Height == 0)
      //   {
      //     return;
      //   }

      //   var croppedImage = currentVideoFrame.Clone(normalizedTempSelection, currentVideoFrame.PixelFormat);
      //   var cvImage = new Image<Bgr, byte>(croppedImage);

      //   var processed = cvImage
      //     .SmoothBilatral(5, 5, 5)
      //     .Convert<Gray, byte>()
      //     .ThresholdAdaptive(new Gray(255), AdaptiveThresholdType.GaussianC, ThresholdType.Binary, value,
      //       new Gray(grayTrackbar.Value))
      //     .Erode(erodeTrackbar.Value);

      //   processedBox.Image = processed.Bitmap;
      //   // detect every second instead of every frame to avoid killing CPU
      //   if (DateTime.Now - detectTimestamp >= DetectEverySeconds)
      //   {
      //     detectTimestamp = DateTime.Now;
      //     resultTextBox.Text = Detect(processed);
      //   }
      // })
      //);
    }

    private void SaveSettings()
    {
      Settings.Default.erode = erodeTrackbar.Value;
      Settings.Default.threshold = thresholdTrackbar.Value;
      Settings.Default.gray = grayTrackbar.Value;
      Settings.Default.psm = psmCombo.SelectedIndex;
      Settings.Default.Save();
    }

    private void Main_FormClosing(object sender, FormClosingEventArgs e)
    {
      SaveSettings();
    }

    private void Main_FormClosed(object sender, FormClosedEventArgs e)
    {
      CloseCurrentVideoSource();
    }

    private Rectangle NormalizeRectangle(Rectangle original, Bitmap image)
    {
      var widthRatio =  (double)image.Width / videoSourcePlayer.Width;
      var heightRatio = (double)image.Height / videoSourcePlayer.Height;

      return new Rectangle(
        (int) (original.X * widthRatio),
        (int) (original.Y * heightRatio),
        (int) (original.Width * widthRatio),
        (int) (original.Height * heightRatio)
      );
    }

    private void videoSourcePlayer_MouseMove(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Left)
      {
        tempSelection = new Rectangle(tempSelection.Left, tempSelection.Top, e.X - tempSelection.Left, e.Y - tempSelection.Top);
      }

      this.Invalidate();
    }

    private void videoSourcePlayer_MouseDown(object sender, MouseEventArgs e)
    {
      tempSelection = new Rectangle(e.X, e.Y, 0, 0);
      humiditySelection = new Rectangle(e.X, e.Y, 0, 0);
    }
  }
}

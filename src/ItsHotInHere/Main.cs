using AForge.Video;
using AForge.Video.DirectShow;
using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Firebase.Database;
using Firebase.Database.Query;
using Tesseract;

namespace ItsHotInHere
{
  public partial class Main : Form
  {
    protected FirebaseClient firebase;
    protected internal TesseractEngine TesseractEngine;

    private Rectangle tempSelection;
    private Rectangle normalizedTempSelection;
    private Rectangle humiditySelection;
    private Rectangle normalizedHumiditySelection;

    private bool isSelectingTemperature;
    private bool isSelectingHumidity;
    private const int SelectionWidth = 5;
    private List<History> history = new List<History>();


    public Main()
    {
      InitializeComponent();

      StartWebcam();
      SetupTesseract();
      SetupTrackbars();
      SetupComboBox();
      StartTimers();
      StartFirebase();
    }

    private async void StartFirebase()
    {
      if (string.IsNullOrEmpty(Settings.Default.firebaseSecret))
      {
        MessageBox.Show("no firebaseSecret");
        return;
      }

      firebase = new FirebaseClient("https://isithotinhere-2ae8b.firebaseio.com/", new FirebaseOptions
      {
        AuthTokenAsyncFactory = () => Task.FromResult(Settings.Default.firebaseSecret),
      });
    }

    private void StartTimers()
    {
      detectTimer.Start();
      updateDbTimer.Start();
    }

    private void StopTimers()
    {
      detectTimer.Stop();
      updateDbTimer.Stop();
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
        "digital+letsgodigital+letsgodigital2",
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

    private (string, float) Detect(Bitmap img)
    {
      try
      {
        var mode = (PageSegMode)Enum.Parse(typeof(PageSegMode), (string)psmCombo.SelectedItem);
        using (var page = TesseractEngine.Process(img, mode))
        {
          return (page.GetText(), page.GetMeanConfidence());
        }
      }
      catch (Exception e)
      {
        MessageBox.Show(e.Message);
      }

      return (String.Empty, 0);
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

    private void videoSourcePlayer_NewFrame(object sender, ref Bitmap image)
    {
      using (Graphics g = Graphics.FromImage(image))
      {
        if (tempSelection.Width != 0 && tempSelection.Height != 0)
        {
          using (Pen pen = new Pen(Color.Red, SelectionWidth))
          {
            normalizedTempSelection = NormalizeRectangle(tempSelection, image);
            g.DrawRectangle(pen, normalizedTempSelection);
          }
        }

        if (humiditySelection.Width != 0 && humiditySelection.Height != 0)
        {
          using (Pen pen = new Pen(Color.Blue, SelectionWidth))
          {
            normalizedHumiditySelection = NormalizeRectangle(humiditySelection, image);
            g.DrawRectangle(pen, normalizedHumiditySelection);
          }
        }

      }
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
      StopTimers();
      SaveSettings();
    }

    private void Main_FormClosed(object sender, FormClosedEventArgs e)
    {
      CloseCurrentVideoSource();
    }

    private Rectangle NormalizeRectangle(Rectangle original, Image image)
    {
      var widthRatio = (double)image.Width / videoSourcePlayer.Width;
      var heightRatio = (double)image.Height / videoSourcePlayer.Height;

      return new Rectangle(
        (int)(original.X * widthRatio),
        (int)(original.Y * heightRatio),
        (int)(original.Width * widthRatio),
        (int)(original.Height * heightRatio)
      );
    }

    private void videoSourcePlayer_MouseMove(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Left)
      {
        if (isSelectingTemperature)
        {
          tempSelection = new Rectangle(
            tempSelection.Left,
            tempSelection.Top,
            Math.Max(0, e.X - tempSelection.Left),
            Math.Max(0, e.Y - tempSelection.Top)
          );
        }

        if (isSelectingHumidity)
        {
          humiditySelection = new Rectangle(
            humiditySelection.Left,
            humiditySelection.Top,
            Math.Max(0, e.X - humiditySelection.Left),
            Math.Max(0, e.Y - humiditySelection.Top)
          );
        }
      }

      Invalidate();
    }

    private void videoSourcePlayer_MouseDown(object sender, MouseEventArgs e)
    {
      if (isSelectingTemperature)
      {
        tempSelection = new Rectangle(e.X, e.Y, 0, 0);
      }

      if (isSelectingHumidity)
      {
        humiditySelection = new Rectangle(e.X, e.Y, 0, 0);
      }
    }

    private void DetectTimer_Tick(object sender, EventArgs e)
    {
      var currentVideoFrame = videoSourcePlayer.GetCurrentVideoFrame();
      // video stream still initializing
      if (currentVideoFrame == null)
      {
        return;
      }

      var result = DetectSelection(currentVideoFrame, normalizedTempSelection);
      if (result != null)
      {
        temperatureProcessedBox.Image = result.Image;
        tempResult.Text = result.Text;
        tempConfidence.Text = $"{result.Confidence}%";
        AddHistory(new History(Type.Temp, result.Text.Trim(), result.Confidence));
      }

      result = DetectSelection(currentVideoFrame, normalizedHumiditySelection);
      if (result != null)
      {
        humidityProcessedBox.Image = result.Image;
        humidityResult.Text = result.Text;
        humidityConfidence.Text = $"{result.Confidence}%";
        AddHistory(new History(Type.Humidity, result.Text.Trim(), result.Confidence));
      }

      UpdateHistoryTextbox();
    }

    private void AddHistory(History hist)
    {
      history.Insert(0, hist);
      history = history.Take(300).ToList();
    }

    private void UpdateHistoryTextbox()
    {
      historyTextBox.Text = string.Join(Environment.NewLine,
        history.Take(25).Select(h =>
          $"[{h.Type.ToString()[0]}] {h.Time:HH:m:s}: (c: {Math.Round(h.Conf, 2)}%) {h.Text.Trim()}"));
    }

    private DetectResult DetectSelection(Bitmap currentVideoFrame, Rectangle selection)
    {
      if (selection.Width == 0 && selection.Height == 0)
      {
        return null;
      }

      // image contains borders so need to crop them out
      var rectangle = new Rectangle(
        selection.X + SelectionWidth,
        selection.Y + SelectionWidth,
        selection.Width - 2 * SelectionWidth, // not sure why tf it has to be 2 times :\
        selection.Height - 2 * SelectionWidth);
      var croppedImage = currentVideoFrame.Clone(rectangle, currentVideoFrame.PixelFormat);

      // this seems to improve detection

      // this needs to be an odd value
      var value = thresholdTrackbar.Value % 2 == 0 ? thresholdTrackbar.Value + 1 : thresholdTrackbar.Value;

      var cvImage = new Image<Bgr, byte>(croppedImage);

      var processed = cvImage
        .SmoothBilatral(5, 5, 5)
        .Convert<Gray, byte>()
        .ThresholdAdaptive(new Gray(255), AdaptiveThresholdType.GaussianC, ThresholdType.Binary, value,
          new Gray(grayTrackbar.Value))
        .Erode(erodeTrackbar.Value);

      var imageWithWiteBorders = AddWhiteBorder(processed.Bitmap, 50);

      var (text, confidence) = Detect(imageWithWiteBorders);
      return new DetectResult
      {
        Image = imageWithWiteBorders,
        Text = text,
        Confidence = confidence
      };

    }

    private Bitmap AddWhiteBorder(Image bmp, int size)
    {
      var imageWithBorder = new Bitmap(bmp.Width + 2 * size, bmp.Height + 2 * size);
      using (var g = Graphics.FromImage(imageWithBorder))
      {
        g.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, 0, imageWithBorder.Width, imageWithBorder.Height));
        g.DrawImage(bmp, new Point(size, size));
      }

      return imageWithBorder;
    }

    private void TemperatureButton_Click(object sender, EventArgs e)
    {
      isSelectingTemperature = true;
      Cursor = Cursors.Cross;
    }

    private void HumidityButton_Click(object sender, EventArgs e)
    {
      isSelectingHumidity = true;
      Cursor = Cursors.Cross;
    }

    private void VideoSourcePlayer_MouseUp(object sender, MouseEventArgs e)
    {
      isSelectingHumidity = false;
      isSelectingTemperature = false;
      Cursor = Cursors.Default;
    }

    private async void UpdateDbTimer_Tick(object sender, EventArgs e)
    {
      (History temp, History humidity) = FindBestMatches();
      if (temp == null && humidity == null)
      {
        return;
      }

      try
      {
        await firebase
          .Child("Measurements")
          .PostAsync(new
          {
            Temp = temp?.Text,
            TempConf = temp?.Conf,
            Humidity = humidity?.Text,
            HumidityConf = humidity?.Conf,
            Source = "Horea",
            Date = DateTime.Now.ToString("O")
          });
      }
      catch
      {
        // ignored
      }
    }

    private (History, History) FindBestMatches()
    {
      if (history == null)
      {
        return (null, null);
      }

      var bestHumidity = history.Where(h => h.Type == Type.Humidity).OrderByDescending(h => h.Conf).FirstOrDefault();
      var bestTemp = history.Where(h => h.Type == Type.Temp).OrderByDescending(h => h.Conf).FirstOrDefault();

      return (bestTemp, bestHumidity);
    }
  }

  class DetectResult
  {
    public Bitmap Image { get; set; }
    public string Text { get; set; }
    public double Confidence { get; set; }
  }

  enum Type
  {
    Temp,
    Humidity
  }

  class History
  {
    public DateTime Time { get; }
    public string Text { get; }
    public double Conf { get; }
    public Type Type { get; }

    public History(Type type, string text, double conf)
    {
      Time = DateTime.Now;
      Type = type;
      Text = text;
      Conf = conf;
    }
  }
}

using System;
using System.Windows.Forms;

namespace ItsHotInHere
{
  internal class Program
  {
    [STAThread]
    private static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Main mainForm = new Main { FormBorderStyle = FormBorderStyle.FixedToolWindow };
      Application.Run(mainForm);
    }
  }
}
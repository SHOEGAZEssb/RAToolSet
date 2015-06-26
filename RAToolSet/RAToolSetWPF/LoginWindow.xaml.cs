using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Input;

namespace RAToolSetWPF
{
  /// <summary>
  /// Interaction logic for LoginWindow.xaml
  /// </summary>
  public partial class LoginWindow : Window
  {
    public LoginWindow()
    {
      InitializeComponent();
    }

    /// <summary>
    /// Opens the page where the user can find his API key.
    /// </summary>
    private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
    {
      Process.Start("http://retroachievements.org/APIDemo.php");
    }

    /// <summary>
    /// Checks the entered infos.
    /// </summary>
    private void Button_Click(object sender, RoutedEventArgs e)
    {
      if (CheckInput())
      {
        SaveSettings();
        Close();
      }
      else
        MessageBox.Show("Invalid username or API key!");
    }

    /// <summary>
    /// Saves the correct settings.
    /// </summary>
    private void SaveSettings()
    {
      RAToolSetWPF.Properties.Settings.Default.Username = txtBoxUsername.Text;
      RAToolSetWPF.Properties.Settings.Default.APIKey = txtBoxAPIKey.Text;
      RAToolSetWPF.Properties.Settings.Default.Save();
    }

    /// <summary>
    /// Checks if the infos entered by the user are correct.
    /// </summary>
    /// <returns>True if infos are correct, otherwise false.</returns>
    private bool CheckInput()
    {
      var request = WebRequest.Create("http://retroachievements.org/API/API_" + APIFunction.GetConsoleIDs + ".php?z=" + txtBoxUsername.Text + "&y=" + txtBoxAPIKey.Text);

      request.Proxy = new WebProxy();
      string text;
      var response = (HttpWebResponse)request.GetResponse();

      using (var sr = new StreamReader(response.GetResponseStream()))
      {
        text = sr.ReadToEnd();
      }

      if(text == "Invalid API Key")
      {
        return false;
      }

      return true;
    }
  }
}
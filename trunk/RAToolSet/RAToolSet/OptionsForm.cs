using System;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace RAToolSet
{
  /// <summary>
  /// Represetns a form where the user can enter his username and api key.
  /// </summary>
  public partial class OptionsForm : Form
  {
    /// <summary>
    /// Ctor.
    /// </summary>
    public OptionsForm()
    {
      InitializeComponent();
      textBoxUsername.Text = RAToolSet.Properties.Settings.Default.Username;
      textBoxAPIKey.Text = RAToolSet.Properties.Settings.Default.APIKey;
    }

    /// <summary>
    /// Closes the form if the input is valid, or closes the application if not.
    /// </summary>
    private void btnCancel_Click(object sender, EventArgs e)
    {
      if (CheckInput(RAToolSet.Properties.Settings.Default.Username, RAToolSet.Properties.Settings.Default.APIKey))
        this.Close();
      else
        Application.Exit();
    }

    /// <summary>
    /// Checks if the entered info is valid and saves them.
    /// </summary>
    private void btnOK_Click(object sender, EventArgs e)
    {
      if(!CheckInput(textBoxUsername.Text, textBoxAPIKey.Text))
        MessageBox.Show("Invalid username or API key.");
      else
      {
        RAToolSet.Properties.Settings.Default.Username = textBoxUsername.Text;
        RAToolSet.Properties.Settings.Default.APIKey = textBoxAPIKey.Text;
        RAToolSet.Properties.Settings.Default.Save();
        MessageBox.Show("Username and API key successfully set!");
        this.Close();
      }
    }

    /// <summary>
    /// Checks if the entered infos are valid.
    /// </summary>
    /// <param name="username">Username to check.</param>
    /// <param name="apiKey">API key to check.</param>
    /// <returns>True if input is valid, false if not.</returns>
    private bool CheckInput(string username, string apiKey)
    {
      var request = WebRequest.Create("http://retroachievements.org/API/API_" + APIFunction.GetAchievementCount + ".php?z=" + username + "&y=" +apiKey + "&i=0");
      request.Proxy = new WebProxy();
      string text;
      var response = (HttpWebResponse)request.GetResponse();

      using (var sr = new StreamReader(response.GetResponseStream()))
      {
        text = sr.ReadToEnd();
      }

      if (text == "Invalid API Key")
        return false;
      else
        return true;
    }
  }
}
using System.Windows.Forms;

namespace RAToolSet
{
  /// <summary>
  /// Displays the rich presence script of a game.
  /// </summary>
  public partial class RichPresenceForm : Form
  {
    /// <summary>
    /// Ctor.
    /// </summary>
    /// <param name="richPresence">Rich presence script to display.</param>
    public RichPresenceForm(string richPresence)
    {
      InitializeComponent();
      textBoxRichPresence.Text = richPresence;
    }
  }
}

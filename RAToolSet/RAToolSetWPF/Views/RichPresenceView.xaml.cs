using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RAToolSetWPF
{
  /// <summary>
  /// Interaction logic for RichPresenceView.xaml
  /// </summary>
  public partial class RichPresenceView : Window
  {
    /// <summary>
    /// Ctor.
    /// </summary>
    /// <param name="richPresence">Rich presence script to show.</param>
    public RichPresenceView(string richPresence)
    {
      InitializeComponent();
      textBlock.Text = richPresence;
    }
  }
}
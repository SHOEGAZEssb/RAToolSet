using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RAToolSet
{
  /// <summary>
  /// Displays the images of a game.
  /// </summary>
  public partial class ImageForm : Form
  {
    private Game _g;

    /// <summary>
    /// Ctor.
    /// </summary>
    /// <param name="g">GameInfo to get images from.</param>
    public ImageForm(Game g)
    {
      InitializeComponent();
      _g = g;
      getImagesWorker.RunWorkerAsync();
    }

    /// <summary>
    /// Fetches and displays the images from the GameInfo.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void getImagesWorker_DoWork(object sender, DoWorkEventArgs e)
    {
      _g.FetchImages();
      pictureBoxIcon.Image = _g.ImageIcon;
      pictureBoxTitle.Image = _g.ImageTitle;
      pictureBoxIngame.Image = _g.ImageIngame;
      pictureBoxBoxArt.Image = _g.ImageBoxArt;
    }
  }
}

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
  public partial class ImageForm : Form
  {
    private GameInfo _g;

    public ImageForm(GameInfo g)
    {
      InitializeComponent();
      _g = g;
      getImagesWorker.RunWorkerAsync();
    }

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

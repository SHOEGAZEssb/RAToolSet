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
    public ImageForm(Image imageIcon, Image imageTitle, Image imageIngame, Image imageBoxArt)
    {
      InitializeComponent();

      pictureBoxIcon.Image = imageIcon;
      pictureBoxTitle.Image = imageTitle;
      pictureBoxIngame.Image = imageIngame;
      pictureBoxBoxArt.Image = imageBoxArt;
    }
  }
}

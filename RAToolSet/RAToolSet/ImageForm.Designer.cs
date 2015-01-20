namespace RAToolSet
{
  partial class ImageForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.pictureBoxIcon = new System.Windows.Forms.PictureBox();
      this.pictureBoxTitle = new System.Windows.Forms.PictureBox();
      this.pictureBoxIngame = new System.Windows.Forms.PictureBox();
      this.pictureBoxBoxArt = new System.Windows.Forms.PictureBox();
      this.getImagesWorker = new System.ComponentModel.BackgroundWorker();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTitle)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIngame)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBoxArt)).BeginInit();
      this.SuspendLayout();
      // 
      // pictureBoxIcon
      // 
      this.pictureBoxIcon.Location = new System.Drawing.Point(12, 12);
      this.pictureBoxIcon.Name = "pictureBoxIcon";
      this.pictureBoxIcon.Size = new System.Drawing.Size(159, 156);
      this.pictureBoxIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.pictureBoxIcon.TabIndex = 0;
      this.pictureBoxIcon.TabStop = false;
      // 
      // pictureBoxTitle
      // 
      this.pictureBoxTitle.Location = new System.Drawing.Point(507, 12);
      this.pictureBoxTitle.Name = "pictureBoxTitle";
      this.pictureBoxTitle.Size = new System.Drawing.Size(159, 156);
      this.pictureBoxTitle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.pictureBoxTitle.TabIndex = 1;
      this.pictureBoxTitle.TabStop = false;
      // 
      // pictureBoxIngame
      // 
      this.pictureBoxIngame.Location = new System.Drawing.Point(342, 12);
      this.pictureBoxIngame.Name = "pictureBoxIngame";
      this.pictureBoxIngame.Size = new System.Drawing.Size(159, 156);
      this.pictureBoxIngame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.pictureBoxIngame.TabIndex = 2;
      this.pictureBoxIngame.TabStop = false;
      // 
      // pictureBoxBoxArt
      // 
      this.pictureBoxBoxArt.Location = new System.Drawing.Point(177, 12);
      this.pictureBoxBoxArt.Name = "pictureBoxBoxArt";
      this.pictureBoxBoxArt.Size = new System.Drawing.Size(159, 156);
      this.pictureBoxBoxArt.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.pictureBoxBoxArt.TabIndex = 3;
      this.pictureBoxBoxArt.TabStop = false;
      // 
      // getImagesWorker
      // 
      this.getImagesWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.getImagesWorker_DoWork);
      // 
      // ImageForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(678, 185);
      this.Controls.Add(this.pictureBoxBoxArt);
      this.Controls.Add(this.pictureBoxIngame);
      this.Controls.Add(this.pictureBoxTitle);
      this.Controls.Add(this.pictureBoxIcon);
      this.Name = "ImageForm";
      this.Text = "ImageForm";
      ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTitle)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIngame)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBoxArt)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.PictureBox pictureBoxIcon;
    private System.Windows.Forms.PictureBox pictureBoxTitle;
    private System.Windows.Forms.PictureBox pictureBoxIngame;
    private System.Windows.Forms.PictureBox pictureBoxBoxArt;
    private System.ComponentModel.BackgroundWorker getImagesWorker;
  }
}
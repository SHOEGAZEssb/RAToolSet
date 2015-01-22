namespace RAToolSet
{
  partial class RichPresenceForm
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
      this.textBoxRichPresence = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // textBoxRichPresence
      // 
      this.textBoxRichPresence.Dock = System.Windows.Forms.DockStyle.Fill;
      this.textBoxRichPresence.Location = new System.Drawing.Point(0, 0);
      this.textBoxRichPresence.Multiline = true;
      this.textBoxRichPresence.Name = "textBoxRichPresence";
      this.textBoxRichPresence.ReadOnly = true;
      this.textBoxRichPresence.Size = new System.Drawing.Size(638, 471);
      this.textBoxRichPresence.TabIndex = 0;
      // 
      // RichPresenceForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(638, 471);
      this.Controls.Add(this.textBoxRichPresence);
      this.Name = "RichPresenceForm";
      this.Text = "RichPresenceForm";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox textBoxRichPresence;
  }
}
namespace RAToolSet
{
  partial class OptionsForm
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
      this.lblUsername = new System.Windows.Forms.Label();
      this.textBoxUsername = new System.Windows.Forms.TextBox();
      this.lblAPIKey = new System.Windows.Forms.Label();
      this.textBoxAPIKey = new System.Windows.Forms.TextBox();
      this.btnOK = new System.Windows.Forms.Button();
      this.btnCancel = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // lblUsername
      // 
      this.lblUsername.AutoSize = true;
      this.lblUsername.Location = new System.Drawing.Point(12, 9);
      this.lblUsername.Name = "lblUsername";
      this.lblUsername.Size = new System.Drawing.Size(58, 13);
      this.lblUsername.TabIndex = 0;
      this.lblUsername.Text = "Username:";
      // 
      // textBoxUsername
      // 
      this.textBoxUsername.Location = new System.Drawing.Point(15, 25);
      this.textBoxUsername.Name = "textBoxUsername";
      this.textBoxUsername.Size = new System.Drawing.Size(396, 20);
      this.textBoxUsername.TabIndex = 1;
      // 
      // lblAPIKey
      // 
      this.lblAPIKey.AutoSize = true;
      this.lblAPIKey.Location = new System.Drawing.Point(12, 62);
      this.lblAPIKey.Name = "lblAPIKey";
      this.lblAPIKey.Size = new System.Drawing.Size(48, 13);
      this.lblAPIKey.TabIndex = 2;
      this.lblAPIKey.Text = "API Key:";
      // 
      // textBoxAPIKey
      // 
      this.textBoxAPIKey.Location = new System.Drawing.Point(15, 78);
      this.textBoxAPIKey.Name = "textBoxAPIKey";
      this.textBoxAPIKey.Size = new System.Drawing.Size(396, 20);
      this.textBoxAPIKey.TabIndex = 3;
      // 
      // btnOK
      // 
      this.btnOK.Location = new System.Drawing.Point(255, 104);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new System.Drawing.Size(75, 23);
      this.btnOK.TabIndex = 4;
      this.btnOK.Text = "OK";
      this.btnOK.UseVisualStyleBackColor = true;
      this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
      // 
      // btnCancel
      // 
      this.btnCancel.Location = new System.Drawing.Point(336, 104);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(75, 23);
      this.btnCancel.TabIndex = 5;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
      // 
      // OptionsForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(423, 132);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.btnOK);
      this.Controls.Add(this.textBoxAPIKey);
      this.Controls.Add(this.lblAPIKey);
      this.Controls.Add(this.textBoxUsername);
      this.Controls.Add(this.lblUsername);
      this.Name = "OptionsForm";
      this.Text = "OptionsForm";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label lblUsername;
    private System.Windows.Forms.TextBox textBoxUsername;
    private System.Windows.Forms.Label lblAPIKey;
    private System.Windows.Forms.TextBox textBoxAPIKey;
    private System.Windows.Forms.Button btnOK;
    private System.Windows.Forms.Button btnCancel;
  }
}
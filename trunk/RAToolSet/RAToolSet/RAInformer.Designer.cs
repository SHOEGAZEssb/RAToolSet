namespace RAToolSet
{
  partial class RAInformer
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
      this.getGameInfoWorker = new System.ComponentModel.BackgroundWorker();
      this.getConsolesWorker = new System.ComponentModel.BackgroundWorker();
      this.getGameListWorker = new System.ComponentModel.BackgroundWorker();
      this.panel1 = new System.Windows.Forms.Panel();
      this.lblSelectGame = new System.Windows.Forms.Label();
      this.comboBoxConsole = new System.Windows.Forms.ComboBox();
      this.lblSelectConsole = new System.Windows.Forms.Label();
      this.comboBoxGame = new System.Windows.Forms.ComboBox();
      this.label2 = new System.Windows.Forms.Label();
      this.panel2 = new System.Windows.Forms.Panel();
      this.tabControl1 = new System.Windows.Forms.TabControl();
      this.tabPageGameInspector = new System.Windows.Forms.TabPage();
      this.lblReleaseContent = new System.Windows.Forms.Label();
      this.lblGenreContent = new System.Windows.Forms.Label();
      this.lblDeveloperContent = new System.Windows.Forms.Label();
      this.lblPublisherContent = new System.Windows.Forms.Label();
      this.lblReleased = new System.Windows.Forms.Label();
      this.lblGenre = new System.Windows.Forms.Label();
      this.lblDeveloper = new System.Windows.Forms.Label();
      this.lblPublisher = new System.Windows.Forms.Label();
      this.linklblImages = new System.Windows.Forms.LinkLabel();
      this.lblImages = new System.Windows.Forms.Label();
      this.lblFlagsContent = new System.Windows.Forms.Label();
      this.lblFlags = new System.Windows.Forms.Label();
      this.linklblForumPost = new System.Windows.Forms.LinkLabel();
      this.lblForumPost = new System.Windows.Forms.Label();
      this.lblTitleContent = new System.Windows.Forms.Label();
      this.lblTitle = new System.Windows.Forms.Label();
      this.lblIDContent = new System.Windows.Forms.Label();
      this.lblID = new System.Windows.Forms.Label();
      this.tabPage2 = new System.Windows.Forms.TabPage();
      this.statusStrip1 = new System.Windows.Forms.StatusStrip();
      this.lblProgress = new System.Windows.Forms.ToolStripStatusLabel();
      this.panel1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.tabControl1.SuspendLayout();
      this.tabPageGameInspector.SuspendLayout();
      this.statusStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // getGameInfoWorker
      // 
      this.getGameInfoWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.getGameInfoWorker_DoWork);
      // 
      // getConsolesWorker
      // 
      this.getConsolesWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.getConsolesWorker_DoWork);
      // 
      // getGameListWorker
      // 
      this.getGameListWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.getGameListWorker_DoWork);
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.lblSelectGame);
      this.panel1.Controls.Add(this.comboBoxConsole);
      this.panel1.Controls.Add(this.lblSelectConsole);
      this.panel1.Controls.Add(this.comboBoxGame);
      this.panel1.Controls.Add(this.label2);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(598, 31);
      this.panel1.TabIndex = 1;
      // 
      // lblSelectGame
      // 
      this.lblSelectGame.AutoSize = true;
      this.lblSelectGame.Location = new System.Drawing.Point(253, 9);
      this.lblSelectGame.Name = "lblSelectGame";
      this.lblSelectGame.Size = new System.Drawing.Size(71, 13);
      this.lblSelectGame.TabIndex = 56;
      this.lblSelectGame.Text = "Select Game:";
      // 
      // comboBoxConsole
      // 
      this.comboBoxConsole.Enabled = false;
      this.comboBoxConsole.FormattingEnabled = true;
      this.comboBoxConsole.Location = new System.Drawing.Point(100, 6);
      this.comboBoxConsole.Name = "comboBoxConsole";
      this.comboBoxConsole.Size = new System.Drawing.Size(121, 21);
      this.comboBoxConsole.TabIndex = 55;
      this.comboBoxConsole.SelectedIndexChanged += new System.EventHandler(this.comboBoxConsole_SelectedIndexChanged);
      // 
      // lblSelectConsole
      // 
      this.lblSelectConsole.AutoSize = true;
      this.lblSelectConsole.Location = new System.Drawing.Point(13, 9);
      this.lblSelectConsole.Name = "lblSelectConsole";
      this.lblSelectConsole.Size = new System.Drawing.Size(81, 13);
      this.lblSelectConsole.TabIndex = 54;
      this.lblSelectConsole.Text = "Select Console:";
      // 
      // comboBoxGame
      // 
      this.comboBoxGame.Enabled = false;
      this.comboBoxGame.FormattingEnabled = true;
      this.comboBoxGame.Location = new System.Drawing.Point(330, 6);
      this.comboBoxGame.Name = "comboBoxGame";
      this.comboBoxGame.Size = new System.Drawing.Size(256, 21);
      this.comboBoxGame.TabIndex = 53;
      this.comboBoxGame.SelectedIndexChanged += new System.EventHandler(this.comboBoxGame_SelectedIndexChanged);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(13, 7);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(35, 13);
      this.label2.TabIndex = 52;
      this.label2.Text = "label2";
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.statusStrip1);
      this.panel2.Controls.Add(this.tabControl1);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel2.Location = new System.Drawing.Point(0, 31);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(598, 271);
      this.panel2.TabIndex = 2;
      // 
      // tabControl1
      // 
      this.tabControl1.Controls.Add(this.tabPageGameInspector);
      this.tabControl1.Controls.Add(this.tabPage2);
      this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tabControl1.Location = new System.Drawing.Point(0, 0);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new System.Drawing.Size(598, 271);
      this.tabControl1.TabIndex = 1;
      // 
      // tabPageGameInspector
      // 
      this.tabPageGameInspector.Controls.Add(this.lblReleaseContent);
      this.tabPageGameInspector.Controls.Add(this.lblGenreContent);
      this.tabPageGameInspector.Controls.Add(this.lblDeveloperContent);
      this.tabPageGameInspector.Controls.Add(this.lblPublisherContent);
      this.tabPageGameInspector.Controls.Add(this.lblReleased);
      this.tabPageGameInspector.Controls.Add(this.lblGenre);
      this.tabPageGameInspector.Controls.Add(this.lblDeveloper);
      this.tabPageGameInspector.Controls.Add(this.lblPublisher);
      this.tabPageGameInspector.Controls.Add(this.linklblImages);
      this.tabPageGameInspector.Controls.Add(this.lblImages);
      this.tabPageGameInspector.Controls.Add(this.lblFlagsContent);
      this.tabPageGameInspector.Controls.Add(this.lblFlags);
      this.tabPageGameInspector.Controls.Add(this.linklblForumPost);
      this.tabPageGameInspector.Controls.Add(this.lblForumPost);
      this.tabPageGameInspector.Controls.Add(this.lblTitleContent);
      this.tabPageGameInspector.Controls.Add(this.lblTitle);
      this.tabPageGameInspector.Controls.Add(this.lblIDContent);
      this.tabPageGameInspector.Controls.Add(this.lblID);
      this.tabPageGameInspector.Location = new System.Drawing.Point(4, 22);
      this.tabPageGameInspector.Name = "tabPageGameInspector";
      this.tabPageGameInspector.Padding = new System.Windows.Forms.Padding(3);
      this.tabPageGameInspector.Size = new System.Drawing.Size(590, 245);
      this.tabPageGameInspector.TabIndex = 0;
      this.tabPageGameInspector.Text = "Game Inspector";
      this.tabPageGameInspector.UseVisualStyleBackColor = true;
      // 
      // lblReleaseContent
      // 
      this.lblReleaseContent.AutoSize = true;
      this.lblReleaseContent.Location = new System.Drawing.Point(89, 186);
      this.lblReleaseContent.Name = "lblReleaseContent";
      this.lblReleaseContent.Size = new System.Drawing.Size(35, 13);
      this.lblReleaseContent.TabIndex = 64;
      this.lblReleaseContent.Text = "label6";
      // 
      // lblGenreContent
      // 
      this.lblGenreContent.AutoSize = true;
      this.lblGenreContent.Location = new System.Drawing.Point(89, 164);
      this.lblGenreContent.Name = "lblGenreContent";
      this.lblGenreContent.Size = new System.Drawing.Size(35, 13);
      this.lblGenreContent.TabIndex = 63;
      this.lblGenreContent.Text = "label5";
      // 
      // lblDeveloperContent
      // 
      this.lblDeveloperContent.AutoSize = true;
      this.lblDeveloperContent.Location = new System.Drawing.Point(89, 141);
      this.lblDeveloperContent.Name = "lblDeveloperContent";
      this.lblDeveloperContent.Size = new System.Drawing.Size(35, 13);
      this.lblDeveloperContent.TabIndex = 62;
      this.lblDeveloperContent.Text = "label4";
      // 
      // lblPublisherContent
      // 
      this.lblPublisherContent.AutoSize = true;
      this.lblPublisherContent.Location = new System.Drawing.Point(89, 119);
      this.lblPublisherContent.Name = "lblPublisherContent";
      this.lblPublisherContent.Size = new System.Drawing.Size(35, 13);
      this.lblPublisherContent.TabIndex = 61;
      this.lblPublisherContent.Text = "label3";
      // 
      // lblReleased
      // 
      this.lblReleased.AutoSize = true;
      this.lblReleased.Location = new System.Drawing.Point(5, 186);
      this.lblReleased.Name = "lblReleased";
      this.lblReleased.Size = new System.Drawing.Size(75, 13);
      this.lblReleased.TabIndex = 60;
      this.lblReleased.Text = "Release Date:";
      // 
      // lblGenre
      // 
      this.lblGenre.AutoSize = true;
      this.lblGenre.Location = new System.Drawing.Point(5, 164);
      this.lblGenre.Name = "lblGenre";
      this.lblGenre.Size = new System.Drawing.Size(39, 13);
      this.lblGenre.TabIndex = 59;
      this.lblGenre.Text = "Genre:";
      // 
      // lblDeveloper
      // 
      this.lblDeveloper.AutoSize = true;
      this.lblDeveloper.Location = new System.Drawing.Point(5, 141);
      this.lblDeveloper.Name = "lblDeveloper";
      this.lblDeveloper.Size = new System.Drawing.Size(59, 13);
      this.lblDeveloper.TabIndex = 58;
      this.lblDeveloper.Text = "Developer:";
      // 
      // lblPublisher
      // 
      this.lblPublisher.AutoSize = true;
      this.lblPublisher.Location = new System.Drawing.Point(5, 119);
      this.lblPublisher.Name = "lblPublisher";
      this.lblPublisher.Size = new System.Drawing.Size(53, 13);
      this.lblPublisher.TabIndex = 57;
      this.lblPublisher.Text = "Publisher:";
      // 
      // linklblImages
      // 
      this.linklblImages.AutoSize = true;
      this.linklblImages.Location = new System.Drawing.Point(50, 95);
      this.linklblImages.Name = "linklblImages";
      this.linklblImages.Size = new System.Drawing.Size(34, 13);
      this.linklblImages.TabIndex = 56;
      this.linklblImages.TabStop = true;
      this.linklblImages.Text = "Show";
      this.linklblImages.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklblImages_LinkClicked);
      // 
      // lblImages
      // 
      this.lblImages.AutoSize = true;
      this.lblImages.Location = new System.Drawing.Point(5, 95);
      this.lblImages.Name = "lblImages";
      this.lblImages.Size = new System.Drawing.Size(44, 13);
      this.lblImages.TabIndex = 55;
      this.lblImages.Text = "Images:";
      // 
      // lblFlagsContent
      // 
      this.lblFlagsContent.AutoSize = true;
      this.lblFlagsContent.Location = new System.Drawing.Point(46, 73);
      this.lblFlagsContent.Name = "lblFlagsContent";
      this.lblFlagsContent.Size = new System.Drawing.Size(35, 13);
      this.lblFlagsContent.TabIndex = 54;
      this.lblFlagsContent.Text = "label3";
      // 
      // lblFlags
      // 
      this.lblFlags.AutoSize = true;
      this.lblFlags.Location = new System.Drawing.Point(5, 73);
      this.lblFlags.Name = "lblFlags";
      this.lblFlags.Size = new System.Drawing.Size(35, 13);
      this.lblFlags.TabIndex = 53;
      this.lblFlags.Text = "Flags:";
      // 
      // linklblForumPost
      // 
      this.linklblForumPost.AutoSize = true;
      this.linklblForumPost.Location = new System.Drawing.Point(75, 51);
      this.linklblForumPost.Name = "linklblForumPost";
      this.linklblForumPost.Size = new System.Drawing.Size(30, 13);
      this.linklblForumPost.TabIndex = 52;
      this.linklblForumPost.TabStop = true;
      this.linklblForumPost.Text = "Click";
      this.linklblForumPost.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklblForumPost_LinkClicked);
      // 
      // lblForumPost
      // 
      this.lblForumPost.AutoSize = true;
      this.lblForumPost.Location = new System.Drawing.Point(5, 51);
      this.lblForumPost.Name = "lblForumPost";
      this.lblForumPost.Size = new System.Drawing.Size(63, 13);
      this.lblForumPost.TabIndex = 51;
      this.lblForumPost.Text = "Forum Post:";
      // 
      // lblTitleContent
      // 
      this.lblTitleContent.AutoSize = true;
      this.lblTitleContent.Location = new System.Drawing.Point(48, 29);
      this.lblTitleContent.Name = "lblTitleContent";
      this.lblTitleContent.Size = new System.Drawing.Size(35, 13);
      this.lblTitleContent.TabIndex = 50;
      this.lblTitleContent.Text = "label4";
      // 
      // lblTitle
      // 
      this.lblTitle.AutoSize = true;
      this.lblTitle.Location = new System.Drawing.Point(5, 29);
      this.lblTitle.Name = "lblTitle";
      this.lblTitle.Size = new System.Drawing.Size(30, 13);
      this.lblTitle.TabIndex = 49;
      this.lblTitle.Text = "Title:";
      // 
      // lblIDContent
      // 
      this.lblIDContent.AutoSize = true;
      this.lblIDContent.Location = new System.Drawing.Point(32, 7);
      this.lblIDContent.Name = "lblIDContent";
      this.lblIDContent.Size = new System.Drawing.Size(35, 13);
      this.lblIDContent.TabIndex = 48;
      this.lblIDContent.Text = "label3";
      // 
      // lblID
      // 
      this.lblID.AutoSize = true;
      this.lblID.Location = new System.Drawing.Point(5, 7);
      this.lblID.Name = "lblID";
      this.lblID.Size = new System.Drawing.Size(21, 13);
      this.lblID.TabIndex = 47;
      this.lblID.Text = "ID:";
      // 
      // tabPage2
      // 
      this.tabPage2.Location = new System.Drawing.Point(4, 22);
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage2.Size = new System.Drawing.Size(590, 256);
      this.tabPage2.TabIndex = 1;
      this.tabPage2.Text = "tabPage2";
      this.tabPage2.UseVisualStyleBackColor = true;
      // 
      // statusStrip1
      // 
      this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblProgress});
      this.statusStrip1.Location = new System.Drawing.Point(0, 249);
      this.statusStrip1.Name = "statusStrip1";
      this.statusStrip1.Size = new System.Drawing.Size(598, 22);
      this.statusStrip1.TabIndex = 2;
      this.statusStrip1.Text = "statusStrip1";
      // 
      // lblProgress
      // 
      this.lblProgress.Name = "lblProgress";
      this.lblProgress.Size = new System.Drawing.Size(0, 17);
      // 
      // RAInformer
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(598, 302);
      this.Controls.Add(this.panel2);
      this.Controls.Add(this.panel1);
      this.Name = "RAInformer";
      this.Text = "RetroAchievements Informer";
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.tabControl1.ResumeLayout(false);
      this.tabPageGameInspector.ResumeLayout(false);
      this.tabPageGameInspector.PerformLayout();
      this.statusStrip1.ResumeLayout(false);
      this.statusStrip1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.ComponentModel.BackgroundWorker getGameInfoWorker;
    private System.ComponentModel.BackgroundWorker getConsolesWorker;
    private System.ComponentModel.BackgroundWorker getGameListWorker;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Label lblSelectGame;
    private System.Windows.Forms.ComboBox comboBoxConsole;
    private System.Windows.Forms.Label lblSelectConsole;
    private System.Windows.Forms.ComboBox comboBoxGame;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.TabPage tabPageGameInspector;
    private System.Windows.Forms.Label lblReleaseContent;
    private System.Windows.Forms.Label lblGenreContent;
    private System.Windows.Forms.Label lblDeveloperContent;
    private System.Windows.Forms.Label lblPublisherContent;
    private System.Windows.Forms.Label lblReleased;
    private System.Windows.Forms.Label lblGenre;
    private System.Windows.Forms.Label lblDeveloper;
    private System.Windows.Forms.Label lblPublisher;
    private System.Windows.Forms.LinkLabel linklblImages;
    private System.Windows.Forms.Label lblImages;
    private System.Windows.Forms.Label lblFlagsContent;
    private System.Windows.Forms.Label lblFlags;
    private System.Windows.Forms.LinkLabel linklblForumPost;
    private System.Windows.Forms.Label lblForumPost;
    private System.Windows.Forms.Label lblTitleContent;
    private System.Windows.Forms.Label lblTitle;
    private System.Windows.Forms.Label lblIDContent;
    private System.Windows.Forms.Label lblID;
    private System.Windows.Forms.TabPage tabPage2;
    private System.Windows.Forms.StatusStrip statusStrip1;
    private System.Windows.Forms.ToolStripStatusLabel lblProgress;
  }
}


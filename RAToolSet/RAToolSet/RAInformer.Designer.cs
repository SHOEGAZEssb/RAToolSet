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
      this.statusStrip1 = new System.Windows.Forms.StatusStrip();
      this.lblProgress = new System.Windows.Forms.ToolStripStatusLabel();
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
      this.tabPageAchievementInspector = new System.Windows.Forms.TabPage();
      this.comboBoxAchievement = new System.Windows.Forms.ComboBox();
      this.lblSelectAchievement = new System.Windows.Forms.Label();
      this.lblAchID = new System.Windows.Forms.Label();
      this.lblNumAwarded = new System.Windows.Forms.Label();
      this.lblNumAwardedHardcore = new System.Windows.Forms.Label();
      this.lblAchTitle = new System.Windows.Forms.Label();
      this.lblDescription = new System.Windows.Forms.Label();
      this.lblPoints = new System.Windows.Forms.Label();
      this.lblTrueRatio = new System.Windows.Forms.Label();
      this.lblAuthor = new System.Windows.Forms.Label();
      this.lblDateModified = new System.Windows.Forms.Label();
      this.lblDateCreated = new System.Windows.Forms.Label();
      this.lblMemAddr = new System.Windows.Forms.Label();
      this.lblDateEarned = new System.Windows.Forms.Label();
      this.lblDateEarnedHardcore = new System.Windows.Forms.Label();
      this.lblAchIDContent = new System.Windows.Forms.Label();
      this.lblNumAwardedContent = new System.Windows.Forms.Label();
      this.lblNumAwardedHardcoreContent = new System.Windows.Forms.Label();
      this.lblAchTitleContent = new System.Windows.Forms.Label();
      this.lblDescriptionContent = new System.Windows.Forms.Label();
      this.lblPointsContent = new System.Windows.Forms.Label();
      this.lblTrueRatioContent = new System.Windows.Forms.Label();
      this.lblAuthorContent = new System.Windows.Forms.Label();
      this.lblDateModifiedContent = new System.Windows.Forms.Label();
      this.lblDateCreatedContent = new System.Windows.Forms.Label();
      this.lblMemAddrContent = new System.Windows.Forms.Label();
      this.lblDateEarnedContent = new System.Windows.Forms.Label();
      this.lblDateEarnedHardcoreContent = new System.Windows.Forms.Label();
      this.lblRichPresence = new System.Windows.Forms.Label();
      this.linkLabelRichPresence = new System.Windows.Forms.LinkLabel();
      this.panel1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.statusStrip1.SuspendLayout();
      this.tabControl1.SuspendLayout();
      this.tabPageGameInspector.SuspendLayout();
      this.tabPageAchievementInspector.SuspendLayout();
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
      this.panel1.Size = new System.Drawing.Size(669, 31);
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
      this.panel2.Size = new System.Drawing.Size(669, 276);
      this.panel2.TabIndex = 2;
      // 
      // statusStrip1
      // 
      this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblProgress});
      this.statusStrip1.Location = new System.Drawing.Point(0, 254);
      this.statusStrip1.Name = "statusStrip1";
      this.statusStrip1.Size = new System.Drawing.Size(669, 22);
      this.statusStrip1.TabIndex = 2;
      this.statusStrip1.Text = "statusStrip1";
      // 
      // lblProgress
      // 
      this.lblProgress.Name = "lblProgress";
      this.lblProgress.Size = new System.Drawing.Size(0, 17);
      // 
      // tabControl1
      // 
      this.tabControl1.Controls.Add(this.tabPageGameInspector);
      this.tabControl1.Controls.Add(this.tabPageAchievementInspector);
      this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tabControl1.Location = new System.Drawing.Point(0, 0);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new System.Drawing.Size(669, 276);
      this.tabControl1.TabIndex = 1;
      // 
      // tabPageGameInspector
      // 
      this.tabPageGameInspector.Controls.Add(this.linkLabelRichPresence);
      this.tabPageGameInspector.Controls.Add(this.lblRichPresence);
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
      this.tabPageGameInspector.Size = new System.Drawing.Size(661, 250);
      this.tabPageGameInspector.TabIndex = 0;
      this.tabPageGameInspector.Text = "Game Inspector";
      this.tabPageGameInspector.UseVisualStyleBackColor = true;
      // 
      // lblReleaseContent
      // 
      this.lblReleaseContent.AutoSize = true;
      this.lblReleaseContent.Location = new System.Drawing.Point(99, 186);
      this.lblReleaseContent.Name = "lblReleaseContent";
      this.lblReleaseContent.Size = new System.Drawing.Size(35, 13);
      this.lblReleaseContent.TabIndex = 64;
      this.lblReleaseContent.Text = "label6";
      // 
      // lblGenreContent
      // 
      this.lblGenreContent.AutoSize = true;
      this.lblGenreContent.Location = new System.Drawing.Point(99, 164);
      this.lblGenreContent.Name = "lblGenreContent";
      this.lblGenreContent.Size = new System.Drawing.Size(35, 13);
      this.lblGenreContent.TabIndex = 63;
      this.lblGenreContent.Text = "label5";
      // 
      // lblDeveloperContent
      // 
      this.lblDeveloperContent.AutoSize = true;
      this.lblDeveloperContent.Location = new System.Drawing.Point(99, 141);
      this.lblDeveloperContent.Name = "lblDeveloperContent";
      this.lblDeveloperContent.Size = new System.Drawing.Size(35, 13);
      this.lblDeveloperContent.TabIndex = 62;
      this.lblDeveloperContent.Text = "label4";
      // 
      // lblPublisherContent
      // 
      this.lblPublisherContent.AutoSize = true;
      this.lblPublisherContent.Location = new System.Drawing.Point(99, 119);
      this.lblPublisherContent.Name = "lblPublisherContent";
      this.lblPublisherContent.Size = new System.Drawing.Size(35, 13);
      this.lblPublisherContent.TabIndex = 61;
      this.lblPublisherContent.Text = "label3";
      // 
      // lblReleased
      // 
      this.lblReleased.AutoSize = true;
      this.lblReleased.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblReleased.Location = new System.Drawing.Point(5, 186);
      this.lblReleased.Name = "lblReleased";
      this.lblReleased.Size = new System.Drawing.Size(88, 13);
      this.lblReleased.TabIndex = 60;
      this.lblReleased.Text = "Release Date:";
      // 
      // lblGenre
      // 
      this.lblGenre.AutoSize = true;
      this.lblGenre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblGenre.Location = new System.Drawing.Point(5, 164);
      this.lblGenre.Name = "lblGenre";
      this.lblGenre.Size = new System.Drawing.Size(45, 13);
      this.lblGenre.TabIndex = 59;
      this.lblGenre.Text = "Genre:";
      // 
      // lblDeveloper
      // 
      this.lblDeveloper.AutoSize = true;
      this.lblDeveloper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblDeveloper.Location = new System.Drawing.Point(5, 141);
      this.lblDeveloper.Name = "lblDeveloper";
      this.lblDeveloper.Size = new System.Drawing.Size(69, 13);
      this.lblDeveloper.TabIndex = 58;
      this.lblDeveloper.Text = "Developer:";
      // 
      // lblPublisher
      // 
      this.lblPublisher.AutoSize = true;
      this.lblPublisher.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblPublisher.Location = new System.Drawing.Point(5, 119);
      this.lblPublisher.Name = "lblPublisher";
      this.lblPublisher.Size = new System.Drawing.Size(63, 13);
      this.lblPublisher.TabIndex = 57;
      this.lblPublisher.Text = "Publisher:";
      // 
      // linklblImages
      // 
      this.linklblImages.AutoSize = true;
      this.linklblImages.Location = new System.Drawing.Point(99, 95);
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
      this.lblImages.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblImages.Location = new System.Drawing.Point(5, 95);
      this.lblImages.Name = "lblImages";
      this.lblImages.Size = new System.Drawing.Size(51, 13);
      this.lblImages.TabIndex = 55;
      this.lblImages.Text = "Images:";
      // 
      // lblFlagsContent
      // 
      this.lblFlagsContent.AutoSize = true;
      this.lblFlagsContent.Location = new System.Drawing.Point(99, 73);
      this.lblFlagsContent.Name = "lblFlagsContent";
      this.lblFlagsContent.Size = new System.Drawing.Size(35, 13);
      this.lblFlagsContent.TabIndex = 54;
      this.lblFlagsContent.Text = "label3";
      // 
      // lblFlags
      // 
      this.lblFlags.AutoSize = true;
      this.lblFlags.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblFlags.Location = new System.Drawing.Point(5, 73);
      this.lblFlags.Name = "lblFlags";
      this.lblFlags.Size = new System.Drawing.Size(41, 13);
      this.lblFlags.TabIndex = 53;
      this.lblFlags.Text = "Flags:";
      // 
      // linklblForumPost
      // 
      this.linklblForumPost.AutoSize = true;
      this.linklblForumPost.Location = new System.Drawing.Point(99, 51);
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
      this.lblForumPost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblForumPost.Location = new System.Drawing.Point(5, 51);
      this.lblForumPost.Name = "lblForumPost";
      this.lblForumPost.Size = new System.Drawing.Size(74, 13);
      this.lblForumPost.TabIndex = 51;
      this.lblForumPost.Text = "Forum Post:";
      // 
      // lblTitleContent
      // 
      this.lblTitleContent.AutoSize = true;
      this.lblTitleContent.Location = new System.Drawing.Point(99, 29);
      this.lblTitleContent.Name = "lblTitleContent";
      this.lblTitleContent.Size = new System.Drawing.Size(35, 13);
      this.lblTitleContent.TabIndex = 50;
      this.lblTitleContent.Text = "label4";
      // 
      // lblTitle
      // 
      this.lblTitle.AutoSize = true;
      this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblTitle.Location = new System.Drawing.Point(5, 29);
      this.lblTitle.Name = "lblTitle";
      this.lblTitle.Size = new System.Drawing.Size(36, 13);
      this.lblTitle.TabIndex = 49;
      this.lblTitle.Text = "Title:";
      // 
      // lblIDContent
      // 
      this.lblIDContent.AutoSize = true;
      this.lblIDContent.Location = new System.Drawing.Point(99, 7);
      this.lblIDContent.Name = "lblIDContent";
      this.lblIDContent.Size = new System.Drawing.Size(35, 13);
      this.lblIDContent.TabIndex = 48;
      this.lblIDContent.Text = "label3";
      // 
      // lblID
      // 
      this.lblID.AutoSize = true;
      this.lblID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblID.Location = new System.Drawing.Point(5, 7);
      this.lblID.Name = "lblID";
      this.lblID.Size = new System.Drawing.Size(24, 13);
      this.lblID.TabIndex = 47;
      this.lblID.Text = "ID:";
      // 
      // tabPageAchievementInspector
      // 
      this.tabPageAchievementInspector.Controls.Add(this.lblDateEarnedHardcoreContent);
      this.tabPageAchievementInspector.Controls.Add(this.lblDateEarnedContent);
      this.tabPageAchievementInspector.Controls.Add(this.lblMemAddrContent);
      this.tabPageAchievementInspector.Controls.Add(this.lblDateCreatedContent);
      this.tabPageAchievementInspector.Controls.Add(this.lblDateModifiedContent);
      this.tabPageAchievementInspector.Controls.Add(this.lblAuthorContent);
      this.tabPageAchievementInspector.Controls.Add(this.lblTrueRatioContent);
      this.tabPageAchievementInspector.Controls.Add(this.lblPointsContent);
      this.tabPageAchievementInspector.Controls.Add(this.lblDescriptionContent);
      this.tabPageAchievementInspector.Controls.Add(this.lblAchTitleContent);
      this.tabPageAchievementInspector.Controls.Add(this.lblNumAwardedHardcoreContent);
      this.tabPageAchievementInspector.Controls.Add(this.lblNumAwardedContent);
      this.tabPageAchievementInspector.Controls.Add(this.lblAchIDContent);
      this.tabPageAchievementInspector.Controls.Add(this.lblDateEarnedHardcore);
      this.tabPageAchievementInspector.Controls.Add(this.lblDateEarned);
      this.tabPageAchievementInspector.Controls.Add(this.lblMemAddr);
      this.tabPageAchievementInspector.Controls.Add(this.lblDateCreated);
      this.tabPageAchievementInspector.Controls.Add(this.lblDateModified);
      this.tabPageAchievementInspector.Controls.Add(this.lblAuthor);
      this.tabPageAchievementInspector.Controls.Add(this.lblTrueRatio);
      this.tabPageAchievementInspector.Controls.Add(this.lblPoints);
      this.tabPageAchievementInspector.Controls.Add(this.lblDescription);
      this.tabPageAchievementInspector.Controls.Add(this.lblAchTitle);
      this.tabPageAchievementInspector.Controls.Add(this.lblNumAwardedHardcore);
      this.tabPageAchievementInspector.Controls.Add(this.lblNumAwarded);
      this.tabPageAchievementInspector.Controls.Add(this.lblAchID);
      this.tabPageAchievementInspector.Controls.Add(this.comboBoxAchievement);
      this.tabPageAchievementInspector.Controls.Add(this.lblSelectAchievement);
      this.tabPageAchievementInspector.Location = new System.Drawing.Point(4, 22);
      this.tabPageAchievementInspector.Name = "tabPageAchievementInspector";
      this.tabPageAchievementInspector.Padding = new System.Windows.Forms.Padding(3);
      this.tabPageAchievementInspector.Size = new System.Drawing.Size(661, 250);
      this.tabPageAchievementInspector.TabIndex = 1;
      this.tabPageAchievementInspector.Text = "Achievement Inspector";
      this.tabPageAchievementInspector.UseVisualStyleBackColor = true;
      // 
      // comboBoxAchievement
      // 
      this.comboBoxAchievement.FormattingEnabled = true;
      this.comboBoxAchievement.Location = new System.Drawing.Point(442, 5);
      this.comboBoxAchievement.Name = "comboBoxAchievement";
      this.comboBoxAchievement.Size = new System.Drawing.Size(213, 21);
      this.comboBoxAchievement.TabIndex = 4;
      this.comboBoxAchievement.SelectedIndexChanged += new System.EventHandler(this.comboBoxAchievement_SelectedIndexChanged);
      // 
      // lblSelectAchievement
      // 
      this.lblSelectAchievement.AutoSize = true;
      this.lblSelectAchievement.Location = new System.Drawing.Point(331, 8);
      this.lblSelectAchievement.Name = "lblSelectAchievement";
      this.lblSelectAchievement.Size = new System.Drawing.Size(105, 13);
      this.lblSelectAchievement.TabIndex = 3;
      this.lblSelectAchievement.Text = "Select Achievement:";
      // 
      // lblAchID
      // 
      this.lblAchID.AutoSize = true;
      this.lblAchID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblAchID.Location = new System.Drawing.Point(6, 8);
      this.lblAchID.Name = "lblAchID";
      this.lblAchID.Size = new System.Drawing.Size(24, 13);
      this.lblAchID.TabIndex = 5;
      this.lblAchID.Text = "ID:";
      // 
      // lblNumAwarded
      // 
      this.lblNumAwarded.AutoSize = true;
      this.lblNumAwarded.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblNumAwarded.Location = new System.Drawing.Point(6, 25);
      this.lblNumAwarded.Name = "lblNumAwarded";
      this.lblNumAwarded.Size = new System.Drawing.Size(85, 13);
      this.lblNumAwarded.TabIndex = 6;
      this.lblNumAwarded.Text = "NumAwarded:";
      // 
      // lblNumAwardedHardcore
      // 
      this.lblNumAwardedHardcore.AutoSize = true;
      this.lblNumAwardedHardcore.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblNumAwardedHardcore.Location = new System.Drawing.Point(6, 42);
      this.lblNumAwardedHardcore.Name = "lblNumAwardedHardcore";
      this.lblNumAwardedHardcore.Size = new System.Drawing.Size(137, 13);
      this.lblNumAwardedHardcore.TabIndex = 7;
      this.lblNumAwardedHardcore.Text = "NumAwardedHardcore:";
      // 
      // lblAchTitle
      // 
      this.lblAchTitle.AutoSize = true;
      this.lblAchTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblAchTitle.Location = new System.Drawing.Point(6, 59);
      this.lblAchTitle.Name = "lblAchTitle";
      this.lblAchTitle.Size = new System.Drawing.Size(36, 13);
      this.lblAchTitle.TabIndex = 8;
      this.lblAchTitle.Text = "Title:";
      // 
      // lblDescription
      // 
      this.lblDescription.AutoSize = true;
      this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblDescription.Location = new System.Drawing.Point(6, 76);
      this.lblDescription.Name = "lblDescription";
      this.lblDescription.Size = new System.Drawing.Size(75, 13);
      this.lblDescription.TabIndex = 9;
      this.lblDescription.Text = "Description:";
      // 
      // lblPoints
      // 
      this.lblPoints.AutoSize = true;
      this.lblPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblPoints.Location = new System.Drawing.Point(6, 93);
      this.lblPoints.Name = "lblPoints";
      this.lblPoints.Size = new System.Drawing.Size(46, 13);
      this.lblPoints.TabIndex = 10;
      this.lblPoints.Text = "Points:";
      // 
      // lblTrueRatio
      // 
      this.lblTrueRatio.AutoSize = true;
      this.lblTrueRatio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblTrueRatio.Location = new System.Drawing.Point(6, 110);
      this.lblTrueRatio.Name = "lblTrueRatio";
      this.lblTrueRatio.Size = new System.Drawing.Size(71, 13);
      this.lblTrueRatio.TabIndex = 11;
      this.lblTrueRatio.Text = "True Ratio:";
      // 
      // lblAuthor
      // 
      this.lblAuthor.AutoSize = true;
      this.lblAuthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblAuthor.Location = new System.Drawing.Point(6, 127);
      this.lblAuthor.Name = "lblAuthor";
      this.lblAuthor.Size = new System.Drawing.Size(48, 13);
      this.lblAuthor.TabIndex = 12;
      this.lblAuthor.Text = "Author:";
      // 
      // lblDateModified
      // 
      this.lblDateModified.AutoSize = true;
      this.lblDateModified.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblDateModified.Location = new System.Drawing.Point(6, 144);
      this.lblDateModified.Name = "lblDateModified";
      this.lblDateModified.Size = new System.Drawing.Size(87, 13);
      this.lblDateModified.TabIndex = 13;
      this.lblDateModified.Text = "Last Modified:";
      // 
      // lblDateCreated
      // 
      this.lblDateCreated.AutoSize = true;
      this.lblDateCreated.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblDateCreated.Location = new System.Drawing.Point(6, 161);
      this.lblDateCreated.Name = "lblDateCreated";
      this.lblDateCreated.Size = new System.Drawing.Size(75, 13);
      this.lblDateCreated.TabIndex = 14;
      this.lblDateCreated.Text = "Created On:";
      // 
      // lblMemAddr
      // 
      this.lblMemAddr.AutoSize = true;
      this.lblMemAddr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblMemAddr.Location = new System.Drawing.Point(6, 178);
      this.lblMemAddr.Name = "lblMemAddr";
      this.lblMemAddr.Size = new System.Drawing.Size(117, 13);
      this.lblMemAddr.TabIndex = 15;
      this.lblMemAddr.Text = "Memory Conditions:";
      // 
      // lblDateEarned
      // 
      this.lblDateEarned.AutoSize = true;
      this.lblDateEarned.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblDateEarned.Location = new System.Drawing.Point(6, 195);
      this.lblDateEarned.Name = "lblDateEarned";
      this.lblDateEarned.Size = new System.Drawing.Size(82, 13);
      this.lblDateEarned.TabIndex = 16;
      this.lblDateEarned.Text = "Date Earned:";
      // 
      // lblDateEarnedHardcore
      // 
      this.lblDateEarnedHardcore.AutoSize = true;
      this.lblDateEarnedHardcore.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblDateEarnedHardcore.Location = new System.Drawing.Point(6, 213);
      this.lblDateEarnedHardcore.Name = "lblDateEarnedHardcore";
      this.lblDateEarnedHardcore.Size = new System.Drawing.Size(138, 13);
      this.lblDateEarnedHardcore.TabIndex = 17;
      this.lblDateEarnedHardcore.Text = "Date Earned Hardcore:";
      // 
      // lblAchIDContent
      // 
      this.lblAchIDContent.AutoSize = true;
      this.lblAchIDContent.Location = new System.Drawing.Point(150, 8);
      this.lblAchIDContent.Name = "lblAchIDContent";
      this.lblAchIDContent.Size = new System.Drawing.Size(35, 13);
      this.lblAchIDContent.TabIndex = 18;
      this.lblAchIDContent.Text = "label1";
      // 
      // lblNumAwardedContent
      // 
      this.lblNumAwardedContent.AutoSize = true;
      this.lblNumAwardedContent.Location = new System.Drawing.Point(150, 25);
      this.lblNumAwardedContent.Name = "lblNumAwardedContent";
      this.lblNumAwardedContent.Size = new System.Drawing.Size(35, 13);
      this.lblNumAwardedContent.TabIndex = 19;
      this.lblNumAwardedContent.Text = "label3";
      // 
      // lblNumAwardedHardcoreContent
      // 
      this.lblNumAwardedHardcoreContent.AutoSize = true;
      this.lblNumAwardedHardcoreContent.Location = new System.Drawing.Point(150, 42);
      this.lblNumAwardedHardcoreContent.Name = "lblNumAwardedHardcoreContent";
      this.lblNumAwardedHardcoreContent.Size = new System.Drawing.Size(35, 13);
      this.lblNumAwardedHardcoreContent.TabIndex = 20;
      this.lblNumAwardedHardcoreContent.Text = "label4";
      // 
      // lblAchTitleContent
      // 
      this.lblAchTitleContent.AutoSize = true;
      this.lblAchTitleContent.Location = new System.Drawing.Point(150, 59);
      this.lblAchTitleContent.Name = "lblAchTitleContent";
      this.lblAchTitleContent.Size = new System.Drawing.Size(35, 13);
      this.lblAchTitleContent.TabIndex = 21;
      this.lblAchTitleContent.Text = "label5";
      // 
      // lblDescriptionContent
      // 
      this.lblDescriptionContent.AutoSize = true;
      this.lblDescriptionContent.Location = new System.Drawing.Point(150, 76);
      this.lblDescriptionContent.Name = "lblDescriptionContent";
      this.lblDescriptionContent.Size = new System.Drawing.Size(35, 13);
      this.lblDescriptionContent.TabIndex = 22;
      this.lblDescriptionContent.Text = "label6";
      // 
      // lblPointsContent
      // 
      this.lblPointsContent.AutoSize = true;
      this.lblPointsContent.Location = new System.Drawing.Point(150, 93);
      this.lblPointsContent.Name = "lblPointsContent";
      this.lblPointsContent.Size = new System.Drawing.Size(35, 13);
      this.lblPointsContent.TabIndex = 23;
      this.lblPointsContent.Text = "label7";
      // 
      // lblTrueRatioContent
      // 
      this.lblTrueRatioContent.AutoSize = true;
      this.lblTrueRatioContent.Location = new System.Drawing.Point(150, 110);
      this.lblTrueRatioContent.Name = "lblTrueRatioContent";
      this.lblTrueRatioContent.Size = new System.Drawing.Size(35, 13);
      this.lblTrueRatioContent.TabIndex = 24;
      this.lblTrueRatioContent.Text = "label8";
      // 
      // lblAuthorContent
      // 
      this.lblAuthorContent.AutoSize = true;
      this.lblAuthorContent.Location = new System.Drawing.Point(150, 127);
      this.lblAuthorContent.Name = "lblAuthorContent";
      this.lblAuthorContent.Size = new System.Drawing.Size(35, 13);
      this.lblAuthorContent.TabIndex = 25;
      this.lblAuthorContent.Text = "label9";
      // 
      // lblDateModifiedContent
      // 
      this.lblDateModifiedContent.AutoSize = true;
      this.lblDateModifiedContent.Location = new System.Drawing.Point(150, 144);
      this.lblDateModifiedContent.Name = "lblDateModifiedContent";
      this.lblDateModifiedContent.Size = new System.Drawing.Size(41, 13);
      this.lblDateModifiedContent.TabIndex = 26;
      this.lblDateModifiedContent.Text = "label10";
      // 
      // lblDateCreatedContent
      // 
      this.lblDateCreatedContent.AutoSize = true;
      this.lblDateCreatedContent.Location = new System.Drawing.Point(150, 161);
      this.lblDateCreatedContent.Name = "lblDateCreatedContent";
      this.lblDateCreatedContent.Size = new System.Drawing.Size(41, 13);
      this.lblDateCreatedContent.TabIndex = 27;
      this.lblDateCreatedContent.Text = "label11";
      // 
      // lblMemAddrContent
      // 
      this.lblMemAddrContent.AutoSize = true;
      this.lblMemAddrContent.Location = new System.Drawing.Point(150, 178);
      this.lblMemAddrContent.Name = "lblMemAddrContent";
      this.lblMemAddrContent.Size = new System.Drawing.Size(41, 13);
      this.lblMemAddrContent.TabIndex = 28;
      this.lblMemAddrContent.Text = "label12";
      // 
      // lblDateEarnedContent
      // 
      this.lblDateEarnedContent.AutoSize = true;
      this.lblDateEarnedContent.Location = new System.Drawing.Point(150, 195);
      this.lblDateEarnedContent.Name = "lblDateEarnedContent";
      this.lblDateEarnedContent.Size = new System.Drawing.Size(41, 13);
      this.lblDateEarnedContent.TabIndex = 29;
      this.lblDateEarnedContent.Text = "label13";
      // 
      // lblDateEarnedHardcoreContent
      // 
      this.lblDateEarnedHardcoreContent.AutoSize = true;
      this.lblDateEarnedHardcoreContent.Location = new System.Drawing.Point(150, 213);
      this.lblDateEarnedHardcoreContent.Name = "lblDateEarnedHardcoreContent";
      this.lblDateEarnedHardcoreContent.Size = new System.Drawing.Size(41, 13);
      this.lblDateEarnedHardcoreContent.TabIndex = 30;
      this.lblDateEarnedHardcoreContent.Text = "label14";
      // 
      // lblRichPresence
      // 
      this.lblRichPresence.AutoSize = true;
      this.lblRichPresence.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblRichPresence.Location = new System.Drawing.Point(5, 208);
      this.lblRichPresence.Name = "lblRichPresence";
      this.lblRichPresence.Size = new System.Drawing.Size(94, 13);
      this.lblRichPresence.TabIndex = 65;
      this.lblRichPresence.Text = "Rich Presence:";
      // 
      // linkLabelRichPresence
      // 
      this.linkLabelRichPresence.AutoSize = true;
      this.linkLabelRichPresence.Location = new System.Drawing.Point(99, 208);
      this.linkLabelRichPresence.Name = "linkLabelRichPresence";
      this.linkLabelRichPresence.Size = new System.Drawing.Size(34, 13);
      this.linkLabelRichPresence.TabIndex = 66;
      this.linkLabelRichPresence.TabStop = true;
      this.linkLabelRichPresence.Text = "Show";
      this.linkLabelRichPresence.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelRichPresence_LinkClicked);
      // 
      // RAInformer
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(669, 307);
      this.Controls.Add(this.panel2);
      this.Controls.Add(this.panel1);
      this.Name = "RAInformer";
      this.Text = "RetroAchievements Informer";
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.statusStrip1.ResumeLayout(false);
      this.statusStrip1.PerformLayout();
      this.tabControl1.ResumeLayout(false);
      this.tabPageGameInspector.ResumeLayout(false);
      this.tabPageGameInspector.PerformLayout();
      this.tabPageAchievementInspector.ResumeLayout(false);
      this.tabPageAchievementInspector.PerformLayout();
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
    private System.Windows.Forms.TabPage tabPageAchievementInspector;
    private System.Windows.Forms.StatusStrip statusStrip1;
    private System.Windows.Forms.ToolStripStatusLabel lblProgress;
    private System.Windows.Forms.ComboBox comboBoxAchievement;
    private System.Windows.Forms.Label lblSelectAchievement;
    private System.Windows.Forms.Label lblDateEarnedHardcoreContent;
    private System.Windows.Forms.Label lblDateEarnedContent;
    private System.Windows.Forms.Label lblMemAddrContent;
    private System.Windows.Forms.Label lblDateCreatedContent;
    private System.Windows.Forms.Label lblDateModifiedContent;
    private System.Windows.Forms.Label lblAuthorContent;
    private System.Windows.Forms.Label lblTrueRatioContent;
    private System.Windows.Forms.Label lblPointsContent;
    private System.Windows.Forms.Label lblDescriptionContent;
    private System.Windows.Forms.Label lblAchTitleContent;
    private System.Windows.Forms.Label lblNumAwardedHardcoreContent;
    private System.Windows.Forms.Label lblNumAwardedContent;
    private System.Windows.Forms.Label lblAchIDContent;
    private System.Windows.Forms.Label lblDateEarnedHardcore;
    private System.Windows.Forms.Label lblDateEarned;
    private System.Windows.Forms.Label lblMemAddr;
    private System.Windows.Forms.Label lblDateCreated;
    private System.Windows.Forms.Label lblDateModified;
    private System.Windows.Forms.Label lblAuthor;
    private System.Windows.Forms.Label lblTrueRatio;
    private System.Windows.Forms.Label lblPoints;
    private System.Windows.Forms.Label lblDescription;
    private System.Windows.Forms.Label lblAchTitle;
    private System.Windows.Forms.Label lblNumAwardedHardcore;
    private System.Windows.Forms.Label lblNumAwarded;
    private System.Windows.Forms.Label lblAchID;
    private System.Windows.Forms.Label lblRichPresence;
    private System.Windows.Forms.LinkLabel linkLabelRichPresence;
  }
}


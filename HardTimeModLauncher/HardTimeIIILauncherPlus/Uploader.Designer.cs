namespace HardTimeIIILauncherPlus
{
	// Token: 0x0200000B RID: 11
	//[global::System.Runtime.CompilerServices.NullableContext(1)]
	//[global::System.Runtime.CompilerServices.Nullable(0)]
	public partial class Uploader : global::System.Windows.Forms.Form
	{
		// Token: 0x06000059 RID: 89 RVA: 0x00006400 File Offset: 0x00004600
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00006420 File Offset: 0x00004620
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			new global::System.ComponentModel.ComponentResourceManager(typeof(global::HardTimeIIILauncherPlus.Uploader));
			this.mainPanel = new global::System.Windows.Forms.TableLayoutPanel();
			this.modSelect = new global::System.Windows.Forms.ListView();
			this.ctxItems = new global::System.Windows.Forms.ContextMenuStrip(this.components);
			this.deleteToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.viewSteamPageToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.btnCreate = new global::System.Windows.Forms.Button();
			this.editorPanel = new global::System.Windows.Forms.Panel();
			this.tableLayoutPanel1 = new global::System.Windows.Forms.TableLayoutPanel();
			this.label9 = new global::System.Windows.Forms.Label();
			this.modAuthor = new global::System.Windows.Forms.TextBox();
			this.modVersion = new global::System.Windows.Forms.TextBox();
			this.label8 = new global::System.Windows.Forms.Label();
			this.tagList = new global::System.Windows.Forms.Panel();
			this.modTags = new global::System.Windows.Forms.TextBox();
			this.modChangeNote = new global::System.Windows.Forms.TextBox();
			this.modDescription = new global::System.Windows.Forms.TextBox();
			this.openFolder = new global::System.Windows.Forms.Button();
			this.statusText = new global::System.Windows.Forms.Label();
			this.submit = new global::System.Windows.Forms.Button();
			this.label6 = new global::System.Windows.Forms.Label();
			this.modVisibility = new global::System.Windows.Forms.ComboBox();
			this.label5 = new global::System.Windows.Forms.Label();
			this.label4 = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.modPath = new global::System.Windows.Forms.TextBox();
			this.label2 = new global::System.Windows.Forms.Label();
			this.modTitle = new global::System.Windows.Forms.TextBox();
			this.label1 = new global::System.Windows.Forms.Label();
			this.modImage = new global::System.Windows.Forms.PictureBox();
			this.progressBar1 = new global::System.Windows.Forms.ProgressBar();
			this.pathFolder = new global::System.Windows.Forms.FolderBrowserDialog();
			this.mainPanel.SuspendLayout();
			this.ctxItems.SuspendLayout();
			this.editorPanel.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.modImage).BeginInit();
			base.SuspendLayout();
			this.mainPanel.ColumnCount = 2;
			this.mainPanel.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 33.33333f));
			this.mainPanel.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 66.66667f));
			this.mainPanel.Controls.Add(this.modSelect, 0, 0);
			this.mainPanel.Controls.Add(this.btnCreate, 0, 1);
			this.mainPanel.Controls.Add(this.editorPanel, 1, 0);
			this.mainPanel.Controls.Add(this.progressBar1, 1, 1);
			this.mainPanel.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.mainPanel.Location = new global::System.Drawing.Point(0, 0);
			this.mainPanel.Margin = new global::System.Windows.Forms.Padding(3, 2, 3, 2);
			this.mainPanel.Name = "mainPanel";
			this.mainPanel.RowCount = 2;
			this.mainPanel.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Percent, 100f));
			this.mainPanel.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Absolute, 40f));
			this.mainPanel.Size = new global::System.Drawing.Size(978, 694);
			this.mainPanel.TabIndex = 0;
			this.modSelect.BackColor = global::System.Drawing.Color.Black;
			this.modSelect.ContextMenuStrip = this.ctxItems;
			this.modSelect.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.modSelect.ForeColor = global::System.Drawing.Color.White;
			this.modSelect.FullRowSelect = true;
			this.modSelect.Location = new global::System.Drawing.Point(3, 2);
			this.modSelect.Margin = new global::System.Windows.Forms.Padding(3, 2, 3, 2);
			this.modSelect.MultiSelect = false;
			this.modSelect.Name = "modSelect";
			this.modSelect.Size = new global::System.Drawing.Size(319, 650);
			this.modSelect.Sorting = global::System.Windows.Forms.SortOrder.Ascending;
			this.modSelect.TabIndex = 2;
			this.modSelect.UseCompatibleStateImageBehavior = false;
			this.modSelect.View = global::System.Windows.Forms.View.List;
			this.modSelect.SelectedIndexChanged += new global::System.EventHandler(this.modSelect_SelectedIndexChanged);
			this.ctxItems.ImageScalingSize = new global::System.Drawing.Size(24, 24);
			this.ctxItems.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.deleteToolStripMenuItem, this.viewSteamPageToolStripMenuItem });
			this.ctxItems.Name = "ctxItems";
			this.ctxItems.Size = new global::System.Drawing.Size(249, 68);
			this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
			this.deleteToolStripMenuItem.Size = new global::System.Drawing.Size(248, 32);
			this.deleteToolStripMenuItem.Text = "❌ Delete";
			this.deleteToolStripMenuItem.Click += new global::System.EventHandler(this.deleteToolStripMenuItem_Click);
			this.viewSteamPageToolStripMenuItem.Name = "viewSteamPageToolStripMenuItem";
			this.viewSteamPageToolStripMenuItem.Size = new global::System.Drawing.Size(248, 32);
			this.viewSteamPageToolStripMenuItem.Text = "\ud83c\udf10 View Steam Page";
			this.viewSteamPageToolStripMenuItem.Click += new global::System.EventHandler(this.viewSteamPageToolStripMenuItem_Click);
			this.btnCreate.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.btnCreate.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.btnCreate.ForeColor = global::System.Drawing.Color.White;
			this.btnCreate.Location = new global::System.Drawing.Point(3, 656);
			this.btnCreate.Margin = new global::System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnCreate.Name = "btnCreate";
			this.btnCreate.Size = new global::System.Drawing.Size(319, 36);
			this.btnCreate.TabIndex = 3;
			this.btnCreate.Text = "Create Item";
			this.btnCreate.UseVisualStyleBackColor = true;
			this.btnCreate.Click += new global::System.EventHandler(this.btnCreate_Click);
			this.editorPanel.BackColor = global::System.Drawing.Color.FromArgb(16, 63, 16);
			this.editorPanel.Controls.Add(this.tableLayoutPanel1);
			this.editorPanel.Controls.Add(this.tagList);
			this.editorPanel.Controls.Add(this.modTags);
			this.editorPanel.Controls.Add(this.modChangeNote);
			this.editorPanel.Controls.Add(this.modDescription);
			this.editorPanel.Controls.Add(this.openFolder);
			this.editorPanel.Controls.Add(this.statusText);
			this.editorPanel.Controls.Add(this.submit);
			this.editorPanel.Controls.Add(this.label6);
			this.editorPanel.Controls.Add(this.modVisibility);
			this.editorPanel.Controls.Add(this.label5);
			this.editorPanel.Controls.Add(this.label4);
			this.editorPanel.Controls.Add(this.label3);
			this.editorPanel.Controls.Add(this.modPath);
			this.editorPanel.Controls.Add(this.label2);
			this.editorPanel.Controls.Add(this.modTitle);
			this.editorPanel.Controls.Add(this.label1);
			this.editorPanel.Controls.Add(this.modImage);
			this.editorPanel.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.editorPanel.Enabled = false;
			this.editorPanel.ForeColor = global::System.Drawing.Color.White;
			this.editorPanel.Location = new global::System.Drawing.Point(328, 2);
			this.editorPanel.Margin = new global::System.Windows.Forms.Padding(3, 2, 3, 2);
			this.editorPanel.Name = "editorPanel";
			this.editorPanel.Size = new global::System.Drawing.Size(647, 650);
			this.editorPanel.TabIndex = 4;
			this.tableLayoutPanel1.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 50f));
			this.tableLayoutPanel1.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 50f));
			this.tableLayoutPanel1.Controls.Add(this.label9, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.modAuthor, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.modVersion, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.label8, 0, 0);
			this.tableLayoutPanel1.Location = new global::System.Drawing.Point(12, 390);
			this.tableLayoutPanel1.Margin = new global::System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Absolute, 39f));
			this.tableLayoutPanel1.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel1.Size = new global::System.Drawing.Size(626, 75);
			this.tableLayoutPanel1.TabIndex = 21;
			this.label9.AutoSize = true;
			this.label9.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.label9.Location = new global::System.Drawing.Point(316, 0);
			this.label9.Name = "label9";
			this.label9.Size = new global::System.Drawing.Size(307, 39);
			this.label9.TabIndex = 22;
			this.label9.Text = "Version";
			this.label9.TextAlign = global::System.Drawing.ContentAlignment.BottomLeft;
			this.modAuthor.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.modAuthor.BackColor = global::System.Drawing.Color.FromArgb(191, 255, 191);
			this.modAuthor.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.modAuthor.Location = new global::System.Drawing.Point(3, 42);
			this.modAuthor.Margin = new global::System.Windows.Forms.Padding(3, 2, 3, 2);
			this.modAuthor.MaxLength = int.MaxValue;
			this.modAuthor.Name = "modAuthor";
			this.modAuthor.Size = new global::System.Drawing.Size(307, 31);
			this.modAuthor.TabIndex = 4;
			this.modVersion.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.modVersion.BackColor = global::System.Drawing.Color.FromArgb(191, 255, 191);
			this.modVersion.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.modVersion.Location = new global::System.Drawing.Point(316, 42);
			this.modVersion.Margin = new global::System.Windows.Forms.Padding(3, 2, 3, 2);
			this.modVersion.MaxLength = int.MaxValue;
			this.modVersion.Name = "modVersion";
			this.modVersion.Size = new global::System.Drawing.Size(307, 31);
			this.modVersion.TabIndex = 3;
			this.label8.AutoSize = true;
			this.label8.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.label8.Location = new global::System.Drawing.Point(3, 0);
			this.label8.Name = "label8";
			this.label8.Size = new global::System.Drawing.Size(307, 39);
			this.label8.TabIndex = 20;
			this.label8.Text = "Author";
			this.label8.TextAlign = global::System.Drawing.ContentAlignment.BottomLeft;
			this.tagList.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left;
			this.tagList.Location = new global::System.Drawing.Point(9, 80);
			this.tagList.Margin = new global::System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tagList.Name = "tagList";
			this.tagList.Size = new global::System.Drawing.Size(0, 32);
			this.tagList.TabIndex = 19;
			this.modTags.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.modTags.AutoCompleteCustomSource.AddRange(new string[]
			{
				"Arenas", "Audio", "Characters", "Costumes", "Furniture", "Libraries", "Misc", "Moves", "Overrides", "Textures",
				"Themes", "Tools", "Weapons"
			});
			this.modTags.AutoCompleteMode = global::System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.modTags.AutoCompleteSource = global::System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.modTags.BackColor = global::System.Drawing.Color.FromArgb(191, 255, 191);
			this.modTags.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.modTags.Location = new global::System.Drawing.Point(12, 293);
			this.modTags.Margin = new global::System.Windows.Forms.Padding(3, 2, 3, 2);
			this.modTags.MaxLength = int.MaxValue;
			this.modTags.Name = "modTags";
			this.modTags.ScrollBars = global::System.Windows.Forms.ScrollBars.Both;
			this.modTags.Size = new global::System.Drawing.Size(626, 31);
			this.modTags.TabIndex = 18;
			this.modTags.TextChanged += new global::System.EventHandler(this.modTags_TextChanged);
			this.modTags.Leave += new global::System.EventHandler(this.modTags_Leave);
			this.modChangeNote.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.modChangeNote.BackColor = global::System.Drawing.Color.FromArgb(191, 255, 191);
			this.modChangeNote.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.modChangeNote.Location = new global::System.Drawing.Point(12, 495);
			this.modChangeNote.Margin = new global::System.Windows.Forms.Padding(3, 2, 3, 2);
			this.modChangeNote.MaxLength = int.MaxValue;
			this.modChangeNote.Multiline = true;
			this.modChangeNote.Name = "modChangeNote";
			this.modChangeNote.ScrollBars = global::System.Windows.Forms.ScrollBars.Both;
			this.modChangeNote.Size = new global::System.Drawing.Size(623, 80);
			this.modChangeNote.TabIndex = 17;
			this.modChangeNote.Leave += new global::System.EventHandler(this.modItems_Leave);
			this.modDescription.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.modDescription.BackColor = global::System.Drawing.Color.FromArgb(191, 255, 191);
			this.modDescription.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.modDescription.Location = new global::System.Drawing.Point(12, 172);
			this.modDescription.Margin = new global::System.Windows.Forms.Padding(3, 2, 3, 2);
			this.modDescription.MaxLength = int.MaxValue;
			this.modDescription.Multiline = true;
			this.modDescription.Name = "modDescription";
			this.modDescription.ScrollBars = global::System.Windows.Forms.ScrollBars.Both;
			this.modDescription.Size = new global::System.Drawing.Size(626, 92);
			this.modDescription.TabIndex = 16;
			this.modDescription.Leave += new global::System.EventHandler(this.modItems_Leave);
			this.openFolder.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right;
			this.openFolder.BackColor = global::System.Drawing.Color.FromArgb(63, 191, 63);
			this.openFolder.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.openFolder.ForeColor = global::System.Drawing.Color.Black;
			this.openFolder.Location = new global::System.Drawing.Point(602, 106);
			this.openFolder.Margin = new global::System.Windows.Forms.Padding(3, 2, 3, 2);
			this.openFolder.Name = "openFolder";
			this.openFolder.Size = new global::System.Drawing.Size(36, 40);
			this.openFolder.TabIndex = 15;
			this.openFolder.Text = "\ud83d\udcc2";
			this.openFolder.UseVisualStyleBackColor = false;
			this.openFolder.Click += new global::System.EventHandler(this.openFolder_Click);
			this.statusText.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left;
			this.statusText.AutoSize = true;
			this.statusText.Location = new global::System.Drawing.Point(218, 599);
			this.statusText.Name = "statusText";
			this.statusText.Size = new global::System.Drawing.Size(112, 25);
			this.statusText.TabIndex = 14;
			this.statusText.Text = "Status: None";
			this.submit.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left;
			this.submit.BackColor = global::System.Drawing.Color.FromArgb(63, 191, 63);
			this.submit.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.submit.ForeColor = global::System.Drawing.Color.Black;
			this.submit.Location = new global::System.Drawing.Point(12, 586);
			this.submit.Margin = new global::System.Windows.Forms.Padding(3, 2, 3, 2);
			this.submit.Name = "submit";
			this.submit.Size = new global::System.Drawing.Size(200, 50);
			this.submit.TabIndex = 13;
			this.submit.Text = "Submit";
			this.submit.UseVisualStyleBackColor = false;
			this.submit.Click += new global::System.EventHandler(this.submit_Click);
			this.label6.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left;
			this.label6.AutoSize = true;
			this.label6.Location = new global::System.Drawing.Point(12, 468);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(116, 25);
			this.label6.TabIndex = 11;
			this.label6.Text = "Change Note";
			this.modVisibility.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.modVisibility.BackColor = global::System.Drawing.Color.FromArgb(191, 255, 191);
			this.modVisibility.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.modVisibility.FlatStyle = global::System.Windows.Forms.FlatStyle.Popup;
			this.modVisibility.FormattingEnabled = true;
			this.modVisibility.Items.AddRange(new object[] { "Public", "Friends Only", "Private", "Unlisted" });
			this.modVisibility.Location = new global::System.Drawing.Point(12, 353);
			this.modVisibility.Margin = new global::System.Windows.Forms.Padding(3, 2, 3, 2);
			this.modVisibility.Name = "modVisibility";
			this.modVisibility.Size = new global::System.Drawing.Size(626, 33);
			this.modVisibility.TabIndex = 10;
			this.modVisibility.Leave += new global::System.EventHandler(this.modItems_Leave);
			this.label5.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left;
			this.label5.AutoSize = true;
			this.label5.Location = new global::System.Drawing.Point(9, 326);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(77, 25);
			this.label5.TabIndex = 9;
			this.label5.Text = "Visibility";
			this.label4.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left;
			this.label4.AutoSize = true;
			this.label4.Location = new global::System.Drawing.Point(9, 266);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(47, 25);
			this.label4.TabIndex = 7;
			this.label4.Text = "Tags";
			this.label3.AutoSize = true;
			this.label3.Location = new global::System.Drawing.Point(9, 144);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(102, 25);
			this.label3.TabIndex = 5;
			this.label3.Text = "Description";
			this.modPath.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.modPath.BackColor = global::System.Drawing.Color.FromArgb(191, 255, 191);
			this.modPath.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.modPath.Location = new global::System.Drawing.Point(129, 108);
			this.modPath.Margin = new global::System.Windows.Forms.Padding(3, 2, 3, 2);
			this.modPath.MaxLength = int.MaxValue;
			this.modPath.Name = "modPath";
			this.modPath.Size = new global::System.Drawing.Size(464, 31);
			this.modPath.TabIndex = 4;
			this.modPath.Leave += new global::System.EventHandler(this.modItems_Leave);
			this.label2.AutoSize = true;
			this.label2.Location = new global::System.Drawing.Point(129, 81);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(46, 25);
			this.label2.TabIndex = 3;
			this.label2.Text = "Path";
			this.modTitle.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.modTitle.BackColor = global::System.Drawing.Color.FromArgb(191, 255, 191);
			this.modTitle.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.modTitle.Location = new global::System.Drawing.Point(129, 39);
			this.modTitle.Margin = new global::System.Windows.Forms.Padding(3, 2, 3, 2);
			this.modTitle.MaxLength = int.MaxValue;
			this.modTitle.Name = "modTitle";
			this.modTitle.Size = new global::System.Drawing.Size(509, 31);
			this.modTitle.TabIndex = 2;
			this.modTitle.Leave += new global::System.EventHandler(this.modItems_Leave);
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(129, 8);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(44, 25);
			this.label1.TabIndex = 1;
			this.label1.Text = "Title";
			this.modImage.BackColor = global::System.Drawing.Color.FromArgb(0, 31, 0);
			this.modImage.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.modImage.Location = new global::System.Drawing.Point(9, 8);
			this.modImage.Margin = new global::System.Windows.Forms.Padding(3, 2, 3, 2);
			this.modImage.Name = "modImage";
			this.modImage.Size = new global::System.Drawing.Size(113, 133);
			this.modImage.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.modImage.TabIndex = 0;
			this.modImage.TabStop = false;
			this.modImage.Click += new global::System.EventHandler(this.modImage_Click);
			this.progressBar1.BackColor = global::System.Drawing.Color.FromArgb(191, 255, 191);
			this.progressBar1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.progressBar1.Location = new global::System.Drawing.Point(328, 656);
			this.progressBar1.Margin = new global::System.Windows.Forms.Padding(3, 2, 3, 2);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new global::System.Drawing.Size(647, 36);
			this.progressBar1.TabIndex = 5;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(10f, 25f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.Black;
			base.ClientSize = new global::System.Drawing.Size(978, 694);
			base.Controls.Add(this.mainPanel);
			base.Icon = global::System.Drawing.Icon.ExtractAssociatedIcon(global::System.Windows.Forms.Application.ExecutablePath);
			base.Margin = new global::System.Windows.Forms.Padding(3, 2, 3, 2);
			this.MinimumSize = new global::System.Drawing.Size(1000, 750);
			base.Name = "Uploader";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Uploader";
			base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.Uploader_FormClosing);
			base.Load += new global::System.EventHandler(this.Uploader_Load);
			this.mainPanel.ResumeLayout(false);
			this.ctxItems.ResumeLayout(false);
			this.editorPanel.ResumeLayout(false);
			this.editorPanel.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.modImage).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000044 RID: 68
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000045 RID: 69
		private global::System.Windows.Forms.TableLayoutPanel mainPanel;

		// Token: 0x04000046 RID: 70
		private global::System.Windows.Forms.ListView modSelect;

		// Token: 0x04000047 RID: 71
		private global::System.Windows.Forms.Button btnCreate;

		// Token: 0x04000048 RID: 72
		private global::System.Windows.Forms.Panel editorPanel;

		// Token: 0x04000049 RID: 73
		private global::System.Windows.Forms.TextBox modTitle;

		// Token: 0x0400004A RID: 74
		private global::System.Windows.Forms.Label label1;

		// Token: 0x0400004B RID: 75
		private global::System.Windows.Forms.PictureBox modImage;

		// Token: 0x0400004C RID: 76
		private global::System.Windows.Forms.TextBox modPath;

		// Token: 0x0400004D RID: 77
		private global::System.Windows.Forms.Label label2;

		// Token: 0x0400004E RID: 78
		private global::System.Windows.Forms.Label label3;

		// Token: 0x0400004F RID: 79
		private global::System.Windows.Forms.Label label4;

		// Token: 0x04000050 RID: 80
		private global::System.Windows.Forms.ComboBox modVisibility;

		// Token: 0x04000051 RID: 81
		private global::System.Windows.Forms.Label label5;

		// Token: 0x04000052 RID: 82
		private global::System.Windows.Forms.Label statusText;

		// Token: 0x04000053 RID: 83
		private global::System.Windows.Forms.Button submit;

		// Token: 0x04000054 RID: 84
		private global::System.Windows.Forms.Label label6;

		// Token: 0x04000055 RID: 85
		private global::System.Windows.Forms.ProgressBar progressBar1;

		// Token: 0x04000056 RID: 86
		private global::System.Windows.Forms.Button openFolder;

		// Token: 0x04000057 RID: 87
		private global::System.Windows.Forms.TextBox modChangeNote;

		// Token: 0x04000058 RID: 88
		private global::System.Windows.Forms.TextBox modDescription;

		// Token: 0x04000059 RID: 89
		private global::System.Windows.Forms.TextBox modTags;

		// Token: 0x0400005A RID: 90
		private global::System.Windows.Forms.Panel tagList;

		// Token: 0x0400005B RID: 91
		private global::System.Windows.Forms.FolderBrowserDialog pathFolder;

		// Token: 0x0400005C RID: 92
		private global::System.Windows.Forms.Label label8;

		// Token: 0x0400005D RID: 93
		private global::System.Windows.Forms.Label label9;

		// Token: 0x0400005E RID: 94
		private global::System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;

		// Token: 0x0400005F RID: 95
		private global::System.Windows.Forms.TextBox modAuthor;

		// Token: 0x04000060 RID: 96
		private global::System.Windows.Forms.TextBox modVersion;

		// Token: 0x04000061 RID: 97
		private global::System.Windows.Forms.ContextMenuStrip ctxItems;

		// Token: 0x04000062 RID: 98
		private global::System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;

		// Token: 0x04000063 RID: 99
		private global::System.Windows.Forms.ToolStripMenuItem viewSteamPageToolStripMenuItem;
	}
}

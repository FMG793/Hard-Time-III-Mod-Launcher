namespace HardTimeIIILauncherPlus
{
	// Token: 0x02000008 RID: 8
	//[global::System.Runtime.CompilerServices.NullableContext(1)]
	//[global::System.Runtime.CompilerServices.Nullable(0)]
	public partial class MainForm : global::System.Windows.Forms.Form
	{
		// Token: 0x0600002A RID: 42 RVA: 0x00003A55 File Offset: 0x00001C55
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00003A74 File Offset: 0x00001C74
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			new global::System.ComponentModel.ComponentResourceManager(typeof(global::HardTimeIIILauncherPlus.MainForm));
			this.listBoxMain = new global::System.Windows.Forms.CheckedListBox();
			this.mainPanel = new global::System.Windows.Forms.TableLayoutPanel();
			this.btnExtra = new global::System.Windows.Forms.Button();
			this.label3 = new global::System.Windows.Forms.Label();
			this.btnRunUploader = new global::System.Windows.Forms.Button();
			this.btnRunVanilla = new global::System.Windows.Forms.Button();
			this.txtConsole = new global::System.Windows.Forms.RichTextBox();
			this.btnRunModded = new global::System.Windows.Forms.Button();
			this.label1 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.ctxExtra = new global::System.Windows.Forms.ContextMenuStrip(this.components);
			this.openModFolderToolStripMenuItem1 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.openModFolderToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.openSaveFolderToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.mainPanel.SuspendLayout();
			this.ctxExtra.SuspendLayout();
			base.SuspendLayout();
			this.listBoxMain.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.listBoxMain.BackColor = global::System.Drawing.Color.FromArgb(16, 16, 64);
			this.listBoxMain.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.listBoxMain.CheckOnClick = true;
			this.mainPanel.SetColumnSpan(this.listBoxMain, 2);
			this.listBoxMain.ForeColor = global::System.Drawing.Color.White;
			this.listBoxMain.FormattingEnabled = true;
			this.listBoxMain.Location = new global::System.Drawing.Point(487, 36);
			this.listBoxMain.Margin = new global::System.Windows.Forms.Padding(4);
			this.listBoxMain.Name = "listBoxMain";
			this.listBoxMain.ScrollAlwaysVisible = true;
			this.listBoxMain.Size = new global::System.Drawing.Size(293, 452);
			this.listBoxMain.Sorted = true;
			this.listBoxMain.TabIndex = 0;
			this.listBoxMain.ThreeDCheckBoxes = true;
			this.listBoxMain.SelectedIndexChanged += new global::System.EventHandler(this.listBoxMain_SelectedValueChanged);
			this.mainPanel.BackColor = global::System.Drawing.Color.Black;
			this.mainPanel.ColumnCount = 4;
			this.mainPanel.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 33.33332f));
			this.mainPanel.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 33.33334f));
			this.mainPanel.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 33.33334f));
			this.mainPanel.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Absolute, 58f));
			this.mainPanel.Controls.Add(this.btnExtra, 3, 2);
			this.mainPanel.Controls.Add(this.label3, 0, 3);
			this.mainPanel.Controls.Add(this.btnRunUploader, 2, 2);
			this.mainPanel.Controls.Add(this.btnRunVanilla, 1, 2);
			this.mainPanel.Controls.Add(this.listBoxMain, 2, 1);
			this.mainPanel.Controls.Add(this.txtConsole, 0, 1);
			this.mainPanel.Controls.Add(this.btnRunModded, 0, 2);
			this.mainPanel.Controls.Add(this.label1, 0, 0);
			this.mainPanel.Controls.Add(this.label2, 2, 0);
			this.mainPanel.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.mainPanel.ForeColor = global::System.Drawing.Color.White;
			this.mainPanel.Location = new global::System.Drawing.Point(0, 0);
			this.mainPanel.Margin = new global::System.Windows.Forms.Padding(4);
			this.mainPanel.Name = "mainPanel";
			this.mainPanel.RowCount = 4;
			this.mainPanel.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Absolute, 32f));
			this.mainPanel.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Percent, 100f));
			this.mainPanel.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Absolute, 50f));
			this.mainPanel.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Absolute, 32f));
			this.mainPanel.Size = new global::System.Drawing.Size(784, 575);
			this.mainPanel.TabIndex = 1;
			this.btnExtra.BackColor = global::System.Drawing.Color.Black;
			this.btnExtra.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.btnExtra.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.btnExtra.ForeColor = global::System.Drawing.Color.FromArgb(127, 127, 255);
			this.btnExtra.Location = new global::System.Drawing.Point(729, 497);
			this.btnExtra.Margin = new global::System.Windows.Forms.Padding(4);
			this.btnExtra.Name = "btnExtra";
			this.btnExtra.Size = new global::System.Drawing.Size(51, 42);
			this.btnExtra.TabIndex = 9;
			this.btnExtra.Text = "...";
			this.btnExtra.UseVisualStyleBackColor = false;
			this.btnExtra.Click += new global::System.EventHandler(this.btnExtra_Click);
			this.label3.AutoSize = true;
			this.mainPanel.SetColumnSpan(this.label3, 4);
			this.label3.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.label3.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.label3.Location = new global::System.Drawing.Point(4, 543);
			this.label3.Margin = new global::System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(776, 32);
			this.label3.TabIndex = 8;
			this.label3.Text = "Hard Time III Mod Launcher v[UNKNOWN]";
			this.label3.TextAlign = global::System.Drawing.ContentAlignment.BottomLeft;
			this.btnRunUploader.BackColor = global::System.Drawing.Color.Black;
			this.btnRunUploader.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.btnRunUploader.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.btnRunUploader.ForeColor = global::System.Drawing.Color.FromArgb(255, 127, 127);
			this.btnRunUploader.Location = new global::System.Drawing.Point(487, 497);
			this.btnRunUploader.Margin = new global::System.Windows.Forms.Padding(4);
			this.btnRunUploader.Name = "btnRunUploader";
			this.btnRunUploader.Size = new global::System.Drawing.Size(234, 42);
			this.btnRunUploader.TabIndex = 5;
			this.btnRunUploader.Text = "Run Uploader";
			this.btnRunUploader.UseVisualStyleBackColor = false;
			this.btnRunUploader.Click += new global::System.EventHandler(this.btnRunUploader_Click);
			this.btnRunVanilla.BackColor = global::System.Drawing.Color.Black;
			this.btnRunVanilla.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.btnRunVanilla.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.btnRunVanilla.ForeColor = global::System.Drawing.Color.FromArgb(255, 255, 127);
			this.btnRunVanilla.Location = new global::System.Drawing.Point(245, 497);
			this.btnRunVanilla.Margin = new global::System.Windows.Forms.Padding(4);
			this.btnRunVanilla.Name = "btnRunVanilla";
			this.btnRunVanilla.Size = new global::System.Drawing.Size(234, 42);
			this.btnRunVanilla.TabIndex = 3;
			this.btnRunVanilla.Text = "Run Vanilla";
			this.btnRunVanilla.UseVisualStyleBackColor = false;
			this.btnRunVanilla.Click += new global::System.EventHandler(this.btnRunVanilla_Click);
			this.txtConsole.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.txtConsole.BackColor = global::System.Drawing.Color.Black;
			this.txtConsole.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.mainPanel.SetColumnSpan(this.txtConsole, 2);
			this.txtConsole.ForeColor = global::System.Drawing.Color.White;
			this.txtConsole.Location = new global::System.Drawing.Point(4, 36);
			this.txtConsole.Margin = new global::System.Windows.Forms.Padding(4);
			this.txtConsole.Name = "txtConsole";
			this.txtConsole.ReadOnly = true;
			this.txtConsole.Size = new global::System.Drawing.Size(475, 453);
			this.txtConsole.TabIndex = 1;
			this.txtConsole.Text = "";
			this.btnRunModded.BackColor = global::System.Drawing.Color.Black;
			this.btnRunModded.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.btnRunModded.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.btnRunModded.ForeColor = global::System.Drawing.Color.FromArgb(127, 255, 127);
			this.btnRunModded.Location = new global::System.Drawing.Point(4, 497);
			this.btnRunModded.Margin = new global::System.Windows.Forms.Padding(4);
			this.btnRunModded.Name = "btnRunModded";
			this.btnRunModded.Size = new global::System.Drawing.Size(233, 42);
			this.btnRunModded.TabIndex = 2;
			this.btnRunModded.Text = "Run Modded";
			this.btnRunModded.UseVisualStyleBackColor = false;
			this.btnRunModded.Click += new global::System.EventHandler(this.btnRunModded_Click);
			this.label1.AutoSize = true;
			this.label1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.label1.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.label1.Location = new global::System.Drawing.Point(4, 0);
			this.label1.Margin = new global::System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(233, 32);
			this.label1.TabIndex = 6;
			this.label1.Text = "Console";
			this.label1.TextAlign = global::System.Drawing.ContentAlignment.BottomLeft;
			this.label2.AutoSize = true;
			this.label2.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.label2.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.label2.Location = new global::System.Drawing.Point(487, 0);
			this.label2.Margin = new global::System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(234, 32);
			this.label2.TabIndex = 7;
			this.label2.Text = "Enabled Mods";
			this.label2.TextAlign = global::System.Drawing.ContentAlignment.BottomLeft;
			this.ctxExtra.ImageScalingSize = new global::System.Drawing.Size(24, 24);
			this.ctxExtra.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.openModFolderToolStripMenuItem1, this.openModFolderToolStripMenuItem, this.openSaveFolderToolStripMenuItem, this.aboutToolStripMenuItem });
			this.ctxExtra.Name = "ctxExtra";
			this.ctxExtra.Size = new global::System.Drawing.Size(183, 92);
			this.openModFolderToolStripMenuItem1.Name = "openModFolderToolStripMenuItem1";
			this.openModFolderToolStripMenuItem1.Size = new global::System.Drawing.Size(182, 22);
			this.openModFolderToolStripMenuItem1.Text = "\ud83d\udcc2 Open Mod Folder";
			this.openModFolderToolStripMenuItem1.Click += new global::System.EventHandler(this.openModFolder);
			this.openModFolderToolStripMenuItem.Name = "openModFolderToolStripMenuItem";
			this.openModFolderToolStripMenuItem.Size = new global::System.Drawing.Size(182, 22);
			this.openModFolderToolStripMenuItem.Text = "\ud83d\udcc2 Open Save Folder";
			this.openModFolderToolStripMenuItem.Click += new global::System.EventHandler(this.openSaveFolder);
			this.openSaveFolderToolStripMenuItem.Name = "openSaveFolderToolStripMenuItem";
			this.openSaveFolderToolStripMenuItem.Size = new global::System.Drawing.Size(182, 22);
			this.openSaveFolderToolStripMenuItem.Text = "\ud83c\udf10 Help";
			this.openSaveFolderToolStripMenuItem.Click += new global::System.EventHandler(this.showHelp);
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new global::System.Drawing.Size(182, 22);
			this.aboutToolStripMenuItem.Text = "❓ About";
			this.aboutToolStripMenuItem.Click += new global::System.EventHandler(this.showAbout);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(7f, 15f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(784, 575);
			base.Controls.Add(this.mainPanel);
			this.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Bold);
			base.Icon = global::System.Drawing.Icon.ExtractAssociatedIcon(global::System.Windows.Forms.Application.ExecutablePath);
			base.Margin = new global::System.Windows.Forms.Padding(4);
			this.MinimumSize = new global::System.Drawing.Size(800, 590);
			base.Name = "MainForm";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Hard Time III Launcher Plus";
			base.Load += new global::System.EventHandler(this.MainForm_Load);
			this.mainPanel.ResumeLayout(false);
			this.mainPanel.PerformLayout();
			this.ctxExtra.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x04000017 RID: 23
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000018 RID: 24
		private global::System.Windows.Forms.CheckedListBox listBoxMain;

		// Token: 0x04000019 RID: 25
		private global::System.Windows.Forms.TableLayoutPanel mainPanel;

		// Token: 0x0400001A RID: 26
		private global::System.Windows.Forms.RichTextBox txtConsole;

		// Token: 0x0400001B RID: 27
		private global::System.Windows.Forms.Button btnRunVanilla;

		// Token: 0x0400001C RID: 28
		private global::System.Windows.Forms.Button btnRunModded;

		// Token: 0x0400001D RID: 29
		private global::System.Windows.Forms.Button btnRunUploader;

		// Token: 0x0400001E RID: 30
		private global::System.Windows.Forms.Label label1;

		// Token: 0x0400001F RID: 31
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000020 RID: 32
		private global::System.Windows.Forms.Label label3;

		// Token: 0x04000021 RID: 33
		private global::System.Windows.Forms.Button btnExtra;

		// Token: 0x04000022 RID: 34
		private global::System.Windows.Forms.ContextMenuStrip ctxExtra;

		// Token: 0x04000023 RID: 35
		private global::System.Windows.Forms.ToolStripMenuItem openModFolderToolStripMenuItem;

		// Token: 0x04000024 RID: 36
		private global::System.Windows.Forms.ToolStripMenuItem openSaveFolderToolStripMenuItem;

		// Token: 0x04000025 RID: 37
		private global::System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;

		// Token: 0x04000026 RID: 38
		private global::System.Windows.Forms.ToolStripMenuItem openModFolderToolStripMenuItem1;
	}
}

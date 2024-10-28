namespace HardTimeIIILauncherPlus
{
	// Token: 0x02000006 RID: 6
	//[global::System.Runtime.CompilerServices.NullableContext(1)]
	//[global::System.Runtime.CompilerServices.Nullable(0)]
	internal partial class About : global::System.Windows.Forms.Form
	{
		// Token: 0x0600000D RID: 13 RVA: 0x0000228A File Offset: 0x0000048A
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600000E RID: 14 RVA: 0x000022AC File Offset: 0x000004AC
		private void InitializeComponent()
		{
			new global::System.ComponentModel.ComponentResourceManager(typeof(global::HardTimeIIILauncherPlus.About));
			this.tableLayoutPanel = new global::System.Windows.Forms.TableLayoutPanel();
			this.logoPictureBox = new global::System.Windows.Forms.PictureBox();
			this.labelProductName = new global::System.Windows.Forms.Label();
			this.labelVersion = new global::System.Windows.Forms.Label();
			this.labelCopyright = new global::System.Windows.Forms.Label();
			this.labelCompanyName = new global::System.Windows.Forms.Label();
			this.textBoxDescription = new global::System.Windows.Forms.TextBox();
			this.okButton = new global::System.Windows.Forms.Button();
			this.tableLayoutPanel.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.logoPictureBox).BeginInit();
			base.SuspendLayout();
			this.tableLayoutPanel.ColumnCount = 2;
			this.tableLayoutPanel.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 33f));
			this.tableLayoutPanel.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 67f));
			this.tableLayoutPanel.Controls.Add(this.logoPictureBox, 0, 0);
			this.tableLayoutPanel.Controls.Add(this.labelProductName, 1, 0);
			this.tableLayoutPanel.Controls.Add(this.labelVersion, 1, 1);
			this.tableLayoutPanel.Controls.Add(this.labelCopyright, 1, 2);
			this.tableLayoutPanel.Controls.Add(this.labelCompanyName, 1, 3);
			this.tableLayoutPanel.Controls.Add(this.textBoxDescription, 1, 4);
			this.tableLayoutPanel.Controls.Add(this.okButton, 1, 5);
			this.tableLayoutPanel.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel.Location = new global::System.Drawing.Point(15, 17);
			this.tableLayoutPanel.Margin = new global::System.Windows.Forms.Padding(5, 6, 5, 6);
			this.tableLayoutPanel.Name = "tableLayoutPanel";
			this.tableLayoutPanel.RowCount = 6;
			this.tableLayoutPanel.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Percent, 10f));
			this.tableLayoutPanel.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Percent, 10f));
			this.tableLayoutPanel.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Percent, 10f));
			this.tableLayoutPanel.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Percent, 10f));
			this.tableLayoutPanel.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Percent, 50f));
			this.tableLayoutPanel.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Percent, 10f));
			this.tableLayoutPanel.Size = new global::System.Drawing.Size(695, 510);
			this.tableLayoutPanel.TabIndex = 0;
			this.logoPictureBox.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.logoPictureBox.Image = global::System.Drawing.Icon.ExtractAssociatedIcon(global::System.Windows.Forms.Application.ExecutablePath).ToBitmap();
			this.logoPictureBox.Location = new global::System.Drawing.Point(5, 6);
			this.logoPictureBox.Margin = new global::System.Windows.Forms.Padding(5, 6, 5, 6);
			this.logoPictureBox.Name = "logoPictureBox";
			this.tableLayoutPanel.SetRowSpan(this.logoPictureBox, 6);
			this.logoPictureBox.Size = new global::System.Drawing.Size(219, 498);
			this.logoPictureBox.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.logoPictureBox.TabIndex = 12;
			this.logoPictureBox.TabStop = false;
			this.labelProductName.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.labelProductName.Location = new global::System.Drawing.Point(239, 0);
			this.labelProductName.Margin = new global::System.Windows.Forms.Padding(10, 0, 5, 0);
			this.labelProductName.MaximumSize = new global::System.Drawing.Size(0, 33);
			this.labelProductName.Name = "labelProductName";
			this.labelProductName.Size = new global::System.Drawing.Size(451, 33);
			this.labelProductName.TabIndex = 19;
			this.labelProductName.Text = "Product Name";
			this.labelProductName.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.labelVersion.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.labelVersion.Location = new global::System.Drawing.Point(239, 51);
			this.labelVersion.Margin = new global::System.Windows.Forms.Padding(10, 0, 5, 0);
			this.labelVersion.MaximumSize = new global::System.Drawing.Size(0, 33);
			this.labelVersion.Name = "labelVersion";
			this.labelVersion.Size = new global::System.Drawing.Size(451, 33);
			this.labelVersion.TabIndex = 0;
			this.labelVersion.Text = "Version";
			this.labelVersion.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.labelCopyright.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.labelCopyright.Location = new global::System.Drawing.Point(239, 102);
			this.labelCopyright.Margin = new global::System.Windows.Forms.Padding(10, 0, 5, 0);
			this.labelCopyright.MaximumSize = new global::System.Drawing.Size(0, 33);
			this.labelCopyright.Name = "labelCopyright";
			this.labelCopyright.Size = new global::System.Drawing.Size(451, 33);
			this.labelCopyright.TabIndex = 21;
			this.labelCopyright.Text = "Copyright";
			this.labelCopyright.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.labelCompanyName.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.labelCompanyName.Location = new global::System.Drawing.Point(239, 153);
			this.labelCompanyName.Margin = new global::System.Windows.Forms.Padding(10, 0, 5, 0);
			this.labelCompanyName.MaximumSize = new global::System.Drawing.Size(0, 33);
			this.labelCompanyName.Name = "labelCompanyName";
			this.labelCompanyName.Size = new global::System.Drawing.Size(451, 33);
			this.labelCompanyName.TabIndex = 22;
			this.labelCompanyName.Text = "Company Name";
			this.labelCompanyName.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.textBoxDescription.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.textBoxDescription.Location = new global::System.Drawing.Point(239, 210);
			this.textBoxDescription.Margin = new global::System.Windows.Forms.Padding(10, 6, 5, 6);
			this.textBoxDescription.Multiline = true;
			this.textBoxDescription.Name = "textBoxDescription";
			this.textBoxDescription.ReadOnly = true;
			this.textBoxDescription.ScrollBars = global::System.Windows.Forms.ScrollBars.Both;
			this.textBoxDescription.Size = new global::System.Drawing.Size(451, 243);
			this.textBoxDescription.TabIndex = 23;
			this.textBoxDescription.TabStop = false;
			this.textBoxDescription.Text = "Description";
			this.okButton.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right;
			this.okButton.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.okButton.Location = new global::System.Drawing.Point(565, 465);
			this.okButton.Margin = new global::System.Windows.Forms.Padding(5, 6, 5, 6);
			this.okButton.Name = "okButton";
			this.okButton.Size = new global::System.Drawing.Size(125, 39);
			this.okButton.TabIndex = 24;
			this.okButton.Text = "&OK";
			base.AcceptButton = this.okButton;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(10f, 25f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(725, 544);
			base.Controls.Add(this.tableLayoutPanel);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Margin = new global::System.Windows.Forms.Padding(5, 6, 5, 6);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "About";
			base.Padding = new global::System.Windows.Forms.Padding(15, 17, 15, 17);
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "About";
			this.tableLayoutPanel.ResumeLayout(false);
			this.tableLayoutPanel.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.logoPictureBox).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000003 RID: 3
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000004 RID: 4
		private global::System.Windows.Forms.TableLayoutPanel tableLayoutPanel;

		// Token: 0x04000005 RID: 5
		private global::System.Windows.Forms.PictureBox logoPictureBox;

		// Token: 0x04000006 RID: 6
		private global::System.Windows.Forms.Label labelProductName;

		// Token: 0x04000007 RID: 7
		private global::System.Windows.Forms.Label labelVersion;

		// Token: 0x04000008 RID: 8
		private global::System.Windows.Forms.Label labelCopyright;

		// Token: 0x04000009 RID: 9
		private global::System.Windows.Forms.Label labelCompanyName;

		// Token: 0x0400000A RID: 10
		private global::System.Windows.Forms.TextBox textBoxDescription;

		// Token: 0x0400000B RID: 11
		private global::System.Windows.Forms.Button okButton;
	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using Steamworks;

namespace HardTimeIIILauncherPlus
{
	// Token: 0x0200000B RID: 11
	//[NullableContext(1)]
	//[Nullable(0)]
	public partial class Uploader : Form
	{
		// Token: 0x0600003F RID: 63 RVA: 0x00004924 File Offset: 0x00002B24
		public Uploader(MainForm f)
		{
			this.InitializeComponent();
			this.f = f;
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00004B5C File Offset: 0x00002D5C
		private void Uploader_Load(object sender, EventArgs e)
		{
			this.Font = new Font(this.Font.FontFamily, (float)Screen.PrimaryScreen.Bounds.Height / 160f, FontStyle.Bold);
			base.Width = Screen.PrimaryScreen.Bounds.Width * 2 / 3;
			base.Height = Screen.PrimaryScreen.Bounds.Height * 2 / 3;
			base.CenterToScreen();
			this.OriginalTags = new AutoCompleteStringCollection();
			this.OriginalTags.AddRange(new string[]
			{
				"Arenas", "Audio", "Characters", "Cheats", "Costumes", "Furniture", "Libraries", "Misc", "Moves", "Overrides",
				"Promos", "Textures", "Themes", "Tools", "Tweaks", "Weapons"
			});
			if (!Directory.Exists(Path.GetDirectoryName(Uploader.ModDataPath)))
			{
				Directory.CreateDirectory(Path.GetDirectoryName(Uploader.ModDataPath));
			}
			if (!File.Exists(Uploader.ModDataPath))
			{
				File.WriteAllText(Uploader.ModDataPath, "[]");
			}
			this.Mods = JsonConvert.DeserializeObject<List<ModData>>(File.ReadAllText(Uploader.ModDataPath)) ?? new List<ModData>();
			this.downloadItemResultCallback = Callback<DownloadItemResult_t>.Create(new Callback<DownloadItemResult_t>.DispatchDelegate(this.OnDownloadComplete));
			AppId_t appId_t = new AppId_t(3009850U);
			if (!SteamAPI.Init())
			{
				this.f.Fatal("Steam API failed to initialize.\r\nPlease make sure Steam is running and you are logged in, then try again.\r\nIf you are still having issues, try restarting Steam.", null);
			}
			if (SteamAPI.RestartAppIfNecessary(appId_t))
			{
				this.f.Write("Restarting app...", null);
				return;
			}
			if (!SteamApps.BIsSubscribedApp(appId_t))
			{
				this.f.Fatal("Hard Time III is not purchased.\r\nPlease purchase Hard Time III and try again.", null);
			}
			this.f.Write("Steam API initialized successfully.", new Color?(Color.FromName("lime")));
			UGCQueryHandle_t ugcqueryHandle_t = SteamUGC.CreateQueryUserUGCRequest(SteamUser.GetSteamID().GetAccountID(), EUserUGCList.k_EUserUGCList_Published, EUGCMatchingUGCType.k_EUGCMatchingUGCType_Items_ReadyToUse, EUserUGCListSortOrder.k_EUserUGCListSortOrder_CreationOrderDesc, appId_t, appId_t, 1U);
			SteamUGC.SetReturnLongDescription(ugcqueryHandle_t, true);
			SteamUGC.SetReturnMetadata(ugcqueryHandle_t, true);
			SteamUGC.SetReturnChildren(ugcqueryHandle_t, true);
			SteamUGC.SetReturnAdditionalPreviews(ugcqueryHandle_t, true);
			SteamUGC.SetReturnTotalOnly(ugcqueryHandle_t, false);
			SteamAPICall_t steamAPICall_t = SteamUGC.SendQueryUGCRequest(ugcqueryHandle_t);
			this.qc = CallResult<SteamUGCQueryCompleted_t>.Create(new CallResult<SteamUGCQueryCompleted_t>.APIDispatchDelegate(this.OnQueryComplete));
			this.qc.Set(steamAPICall_t, null);
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
			timer.Interval = 100;
			timer.Tick += this.Tick;
			timer.Start();
			this.TheTimer = timer;
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00004E03 File Offset: 0x00003003
		private void Tick(object sender, EventArgs e)
		{
			base.Invoke(delegate
			{
				SteamAPI.RunCallbacks();
				object cu = this._cu;
				lock (cu)
				{
					if (this.CurrentUpload != null)
					{
						ulong num;
						ulong num2;
						switch (SteamUGC.GetItemUpdateProgress(this.CurrentUpload.Value, out num, out num2))
						{
						case EItemUpdateStatus.k_EItemUpdateStatusPreparingConfig:
						{
							Control control = this.statusText;
							DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(33, 2);
							defaultInterpolatedStringHandler.AppendLiteral("Status: Preparing config... (");
							defaultInterpolatedStringHandler.AppendFormatted<ulong>(num);
							defaultInterpolatedStringHandler.AppendLiteral(" / ");
							defaultInterpolatedStringHandler.AppendFormatted<ulong>(num2);
							defaultInterpolatedStringHandler.AppendLiteral(")");
							control.Text = defaultInterpolatedStringHandler.ToStringAndClear();
							break;
						}
						case EItemUpdateStatus.k_EItemUpdateStatusPreparingContent:
						{
							Control control2 = this.statusText;
							DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(34, 2);
							defaultInterpolatedStringHandler.AppendLiteral("Status: Preparing content... (");
							defaultInterpolatedStringHandler.AppendFormatted<ulong>(num);
							defaultInterpolatedStringHandler.AppendLiteral(" / ");
							defaultInterpolatedStringHandler.AppendFormatted<ulong>(num2);
							defaultInterpolatedStringHandler.AppendLiteral(")");
							control2.Text = defaultInterpolatedStringHandler.ToStringAndClear();
							break;
						}
						case EItemUpdateStatus.k_EItemUpdateStatusUploadingContent:
						{
							Control control3 = this.statusText;
							DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(34, 2);
							defaultInterpolatedStringHandler.AppendLiteral("Status: Uploading content... (");
							defaultInterpolatedStringHandler.AppendFormatted<ulong>(num);
							defaultInterpolatedStringHandler.AppendLiteral(" / ");
							defaultInterpolatedStringHandler.AppendFormatted<ulong>(num2);
							defaultInterpolatedStringHandler.AppendLiteral(")");
							control3.Text = defaultInterpolatedStringHandler.ToStringAndClear();
							break;
						}
						case EItemUpdateStatus.k_EItemUpdateStatusUploadingPreviewFile:
						{
							Control control4 = this.statusText;
							DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(39, 2);
							defaultInterpolatedStringHandler.AppendLiteral("Status: Uploading preview file... (");
							defaultInterpolatedStringHandler.AppendFormatted<ulong>(num);
							defaultInterpolatedStringHandler.AppendLiteral(" / ");
							defaultInterpolatedStringHandler.AppendFormatted<ulong>(num2);
							defaultInterpolatedStringHandler.AppendLiteral(")");
							control4.Text = defaultInterpolatedStringHandler.ToStringAndClear();
							break;
						}
						case EItemUpdateStatus.k_EItemUpdateStatusCommittingChanges:
						{
							Control control5 = this.statusText;
							DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(35, 2);
							defaultInterpolatedStringHandler.AppendLiteral("Status: Committing changes... (");
							defaultInterpolatedStringHandler.AppendFormatted<ulong>(num);
							defaultInterpolatedStringHandler.AppendLiteral(" / ");
							defaultInterpolatedStringHandler.AppendFormatted<ulong>(num2);
							defaultInterpolatedStringHandler.AppendLiteral(")");
							control5.Text = defaultInterpolatedStringHandler.ToStringAndClear();
							break;
						}
						}
						try
						{
							int num3 = (int)(num * 100UL / num2);
							this.progressBar1.Value = num3;
						}
						catch
						{
						}
					}
				}
			});
		}

		// Token: 0x06000042 RID: 66 RVA: 0x00004E18 File Offset: 0x00003018
		private void OnQueryComplete(SteamUGCQueryCompleted_t t, bool failure)
		{
			if (!failure)
			{
				this.items.Clear();
				this.modSelect.Items.Clear();
				ImageList smallImageList = this.modSelect.SmallImageList;
				if (smallImageList != null)
				{
					smallImageList.Images.Clear();
				}
				this.LocalImages.Clear();
				if (t.m_eResult == EResult.k_EResultOK)
				{
					this.f.Write("Found " + t.m_unTotalMatchingResults.ToString() + " items.", null);
					for (uint num = 0U; num < t.m_unNumResultsReturned; num += 1U)
					{
						SteamUGCDetails_t item = default(SteamUGCDetails_t);
						SteamUGC.GetQueryUGCResult(t.m_handle, num, out item);
						string text;
						if (!SteamUGC.GetQueryUGCPreviewURL(t.m_handle, num, out text, 1024U) || text == string.Empty)
						{
							text = "https://community.akamai.steamstatic.com/public/images/sharedfiles/steam_workshop_default_image.png";
						}
						if (this.modSelect.SmallImageList == null)
						{
							this.modSelect.SmallImageList = new ImageList();
							this.modSelect.SmallImageList.ImageSize = new Size(64, 64);
							this.modSelect.SmallImageList.ColorDepth = ColorDepth.Depth32Bit;
						}
						Image image;
						try
						{
							image = Image.FromStream(new HttpClient().GetStreamAsync(text).Result);
						}
						catch
						{
							try
							{
								image = Image.FromStream(new HttpClient().GetStreamAsync("https://ingoh.net/static/missing.png").Result);
							}
							catch
							{
								Bitmap bitmap = new Bitmap(64, 64);
								using (Graphics graphics = Graphics.FromImage(bitmap))
								{
									graphics.Clear(Color.FromName("magenta"));
									graphics.FillRectangle(Brushes.Black, 32, 0, 32, 32);
									graphics.FillRectangle(Brushes.Black, 0, 32, 32, 32);
								}
								image = bitmap;
							}
						}
						this.modSelect.SmallImageList.Images.Add(image);
						this.LocalImages.Add(item.m_nPublishedFileId.m_PublishedFileId, image);
						int num2 = this.modSelect.SmallImageList.Images.Count - 1;
						ListViewItem listViewItem = this.modSelect.Items.Add(item.m_rgchTitle, num2);
						this.items.Insert(listViewItem.Index, item);
						if (this.Mods.All((ModData m) => m.Id != item.m_nPublishedFileId.m_PublishedFileId))
						{
							string text2 = Path.Combine(Uploader.UploaderPath, item.m_rgchTitle);
							string text3 = text2;
							int num3 = 1;
							while (Directory.Exists(text2))
							{
								text2 = text3 + " (" + num3.ToString() + ")";
								num3++;
							}
							this.Mods.Add(new ModData
							{
								Id = item.m_nPublishedFileId.m_PublishedFileId,
								Title = item.m_rgchTitle,
								Description = this.EnforceLineBreaks(item.m_rgchDescription, Environment.NewLine),
								Tags = item.m_rgchTags,
								Visibility = item.m_eVisibility,
								Path = text2
							});
							this.DownloadTo(item.m_nPublishedFileId.m_PublishedFileId, text2);
						}
					}
					this.SaveMods();
				}
				else
				{
					this.f.Write("Query failed with error: " + t.m_eResult.ToString(), new Color?(Color.FromName("red")));
				}
			}
			else
			{
				this.f.Write("Query failed.", new Color?(Color.FromName("red")));
			}
			this.qc.Dispose();
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00005200 File Offset: 0x00003400
		private void SaveMods()
		{
			File.WriteAllText(Uploader.ModDataPath, JsonConvert.SerializeObject(this.Mods));
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00005218 File Offset: 0x00003418
		private void DownloadTo(ulong mPublishedFileId, string path)
		{
			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}
			ModData modData = this.Mods.First((ModData m) => m.Id == mPublishedFileId);
			if (SteamUGC.DownloadItem(new PublishedFileId_t(mPublishedFileId), true))
			{
				this.f.Write("Downloading " + modData.Title + " to " + path, null);
				this.Downloading.Add(mPublishedFileId, path);
				return;
			}
			this.f.Write("Download failed.", new Color?(Color.FromName("red")));
		}

		// Token: 0x06000045 RID: 69 RVA: 0x000052C8 File Offset: 0x000034C8
		private void OnDownloadComplete(DownloadItemResult_t t)
		{
			object closeLock = this._closeLock;
			lock (closeLock)
			{
				if (this.Closing)
				{
					return;
				}
			}
			if (t.m_eResult == EResult.k_EResultOK || t.m_eResult == EResult.k_EResultFileNotFound)
			{
				this.f.Write("Downloaded " + t.m_nPublishedFileId.m_PublishedFileId.ToString(), null);
				if (!this.Downloading.ContainsKey(t.m_nPublishedFileId.m_PublishedFileId))
				{
					return;
				}
				ModData modData = this.Mods.First((ModData m) => m.Id == t.m_nPublishedFileId.m_PublishedFileId);
				string text = this.Downloading[t.m_nPublishedFileId.m_PublishedFileId];
				this.Downloading.Remove(t.m_nPublishedFileId.m_PublishedFileId);
				ulong num;
				string text2;
				uint num2;
				if (t.m_eResult != EResult.k_EResultFileNotFound && SteamUGC.GetItemInstallInfo(t.m_nPublishedFileId, out num, out text2, 1024U, out num2))
				{
					foreach (string text3 in Directory.GetFiles(text2, "*", SearchOption.AllDirectories))
					{
						string text4 = text3.Replace(text2, "");
						if (text4.StartsWith("\\"))
						{
							text4 = text4.Substring(1);
						}
						string directoryName = Path.GetDirectoryName(text4);
						if (!Directory.Exists(Path.Combine(text, directoryName)))
						{
							Directory.CreateDirectory(Path.Combine(text, directoryName));
						}
						File.Copy(text3, Path.Combine(text, text4));
					}
					modData.Path = text;
					this.SaveMods();
					return;
				}
				modData.Path = text;
				return;
			}
			else
			{
				this.f.Write("Download failed with error: " + t.m_eResult.ToString(), new Color?(Color.FromName("red")));
				this.Downloading.Remove(t.m_nPublishedFileId.m_PublishedFileId);
			}
		}

		// Token: 0x06000046 RID: 70 RVA: 0x00005504 File Offset: 0x00003704
		private void modSelect_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.modSelect.SelectedItems.Count != 1)
			{
				return;
			}
			this._selection = this.modSelect.SelectedItems[0].Index;
			if (this.Downloading.Count > 0 && this.Downloading.ContainsKey(this.items[this._selection].m_nPublishedFileId.m_PublishedFileId))
			{
				MessageBox.Show("Please wait for the download to finish before editing this mod.", "Download in progress", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}
			this.Tags.Clear();
			ModData modData = this.Mods.First((ModData m) => m.Id == this.items[this._selection].m_nPublishedFileId.m_PublishedFileId);
			this.modPath.Text = "";
			if (this.ShouldOverride(this._selection))
			{
				SteamUGCDetails_t steamUGCDetails_t = this.items[this._selection];
				this.modTitle.Text = steamUGCDetails_t.m_rgchTitle;
				this.modDescription.Text = this.EnforceLineBreaks(steamUGCDetails_t.m_rgchDescription, Environment.NewLine);
				this.modTags.Text = steamUGCDetails_t.m_rgchTags;
				this.FormatTags(true);
				this.modImage.Image = this.LocalImages[modData.Id];
				this.modVisibility.SelectedIndex = (int)steamUGCDetails_t.m_eVisibility;
				this.modPath.Text = modData.Path;
				if (File.Exists(Path.Combine(modData.Path, "manifest.txt")))
				{
					MainForm.Manifest manifest = new MainForm.Manifest();
					manifest.Load(Path.Combine(modData.Path, "manifest.txt"));
					this.modAuthor.Text = manifest.Author;
					this.modVersion.Text = manifest.Version;
				}
				this.SaveModData();
			}
			else
			{
				this.modTitle.Text = modData.Title;
				this.modDescription.Text = this.EnforceLineBreaks(modData.Description, Environment.NewLine);
				this.modTags.Text = modData.Tags;
				this.FormatTags(true);
				this.modImage.Image = this.LocalImages[modData.Id];
				this.modVisibility.SelectedIndex = (int)modData.Visibility;
				this.modPath.Text = modData.Path;
				if (modData.Author == string.Empty)
				{
					if (File.Exists(Path.Combine(modData.Path, "manifest.txt")))
					{
						MainForm.Manifest manifest2 = new MainForm.Manifest();
						manifest2.Load(Path.Combine(modData.Path, "manifest.txt"));
						this.modAuthor.Text = manifest2.Author;
						this.modVersion.Text = manifest2.Version;
					}
					else
					{
						this.modAuthor.Text = "";
						this.modVersion.Text = "1.0.0";
					}
				}
				else
				{
					this.modAuthor.Text = modData.Author;
					this.modVersion.Text = modData.Version;
				}
			}
			if (Directory.Exists(modData.Path))
			{
				if (File.Exists(Path.Combine(modData.Path, "icon.png")) || File.Exists(Path.Combine(modData.Path, "icon.gif")))
				{
					string text = (File.Exists(Path.Combine(modData.Path, "icon.png")) ? "icon.png" : "icon.gif");
					this.modImage.Image = Image.FromFile(Path.Combine(modData.Path, text));
				}
				else
				{
					this.LocalImages[modData.Id].Save(Path.Combine(modData.Path, "icon.png"));
				}
			}
			this.editorPanel.Enabled = true;
		}

		// Token: 0x06000047 RID: 71 RVA: 0x000058AC File Offset: 0x00003AAC
		private bool ShouldOverride(int item)
		{
			ModData modData = this.Mods.First((ModData m) => m.Id == this.items[item].m_nPublishedFileId.m_PublishedFileId);
			SteamUGCDetails_t steamUGCDetails_t = this.items[item];
			return (!(modData.Title == steamUGCDetails_t.m_rgchTitle) || !(this.EnforceLineBreaks(modData.Description, Environment.NewLine) == this.EnforceLineBreaks(steamUGCDetails_t.m_rgchDescription, Environment.NewLine)) || !this.TagEq(modData.Tags, steamUGCDetails_t.m_rgchTags) || modData.Visibility != steamUGCDetails_t.m_eVisibility) && MessageBox.Show("This mod has different data locally than on the workshop. Do you want to override the local data with the workshop data?", "Override local data?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00005970 File Offset: 0x00003B70
		private bool TagEq(string t1, string t2)
		{
			while (t1.Contains(" ,"))
			{
				t1 = t1.Replace(" ,", ",");
			}
			while (t1.Contains(", "))
			{
				t1 = t1.Replace(", ", ",");
			}
			while (t1.Contains("  "))
			{
				t1 = t1.Replace("  ", " ");
			}
			while (t2.Contains(" ,"))
			{
				t2 = t2.Replace(" ,", ",");
			}
			while (t2.Contains(", "))
			{
				t2 = t2.Replace(", ", ",");
			}
			while (t2.Contains("  "))
			{
				t2 = t2.Replace("  ", " ");
			}
			return t1 == t2;
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00005A4C File Offset: 0x00003C4C
		private void FormatTags(bool includeLast = false)
		{
			while (this.modTags.Text.Contains(" ,"))
			{
				this.modTags.Text = this.modTags.Text.Replace(" ,", ",");
			}
			while (this.modTags.Text.Contains(", "))
			{
				this.modTags.Text = this.modTags.Text.Replace(", ", ",");
			}
			while (this.modTags.Text.Contains("  "))
			{
				this.modTags.Text = this.modTags.Text.Replace("  ", " ");
			}
			string[] array = this.modTags.Text.Split(',', StringSplitOptions.None);
			if (!includeLast)
			{
				array = Uploader.SkipLast<string>(array, 1).ToArray<string>();
				if (array.Length == 0)
				{
					return;
				}
			}
			this.tagList.Controls.Clear();
			int num = 0;
			int num2 = 0;
			string[] array2 = (from t in this.Tags.Concat(array).Distinct<string>()
				select t.Trim() into t
				where t.Length > 0
				select t).ToArray<string>();
			for (int i = 0; i < array2.Length; i++)
			{
				if (this.TagAliases.ContainsKey(array2[i]))
				{
					array2[i] = this.TagAliases[array2[i]];
				}
			}
			array2 = array2.Distinct<string>().ToArray<string>();
			this.Tags.Clear();
			string[] array3 = array2;
			for (int j = 0; j < array3.Length; j++)
			{
				string tag = array3[j];
				Label lbl = new Label();
				lbl.Text = "❌" + tag;
				lbl.AutoSize = true;
				lbl.Location = new Point(num, 0);
				lbl.Font = new Font(this.Font.FontFamily, 9f);
				lbl.Click += delegate
				{
					lbl.Dispose();
					this.Tags.Remove(tag);
					this.FormatTags(true);
					this.SaveModData();
				};
				this.tagList.Controls.Add(lbl);
				num += lbl.Width + 5;
				num2 += lbl.Width + 5;
				this.Tags.Add(tag);
			}
			if (!includeLast)
			{
				this.modTags.Text = this.modTags.Text.Split(',', StringSplitOptions.None).Last<string>();
			}
			else
			{
				this.modTags.Text = "";
			}
			this.tagList.Location = new Point(10, this.modTags.Location.Y);
			this.tagList.Width = num2;
			this.modTags.Location = new Point(this.tagList.Location.X + num2, this.modTags.Location.Y);
			this.modTags.Width = this.modTags.Parent.Width - this.modTags.Location.X - 10;
			if (this.modTags.Width < 100)
			{
				this.modTags.Location = new Point(10, this.modTags.Location.Y);
				this.modTags.Width = 100;
				this.tagList.Location = new Point(110, this.tagList.Location.Y);
				this.modTags.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
				return;
			}
			this.modTags.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		}

		// Token: 0x0600004A RID: 74 RVA: 0x00005E5A File Offset: 0x0000405A
		private void modTags_Leave(object sender, EventArgs e)
		{
			this.FormatTags(true);
			this.SaveModData();
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00005E69 File Offset: 0x00004069
		private void modTags_TextChanged(object sender, EventArgs e)
		{
			this.FormatTags(false);
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00005E74 File Offset: 0x00004074
		private void openFolder_Click(object sender, EventArgs e)
		{
			this.pathFolder.SelectedPath = this.modPath.Text;
			if (this.pathFolder.ShowDialog() == DialogResult.OK && Directory.Exists(this.pathFolder.SelectedPath))
			{
				this.modPath.Text = this.pathFolder.SelectedPath;
				this.SaveModData();
			}
		}

		// Token: 0x0600004D RID: 77 RVA: 0x00005ED3 File Offset: 0x000040D3
		private void btnCreate_Click(object sender, EventArgs e)
		{
			base.Invoke(delegate
			{
				string text = Interaction.InputBox("Enter the name of the mod.", "Create mod", "New Mod", -1, -1);
				if (!(text == ""))
				{
					object nqLock = this._nqLock;
					lock (nqLock)
					{
						this.NameQueue.Add(text);
					}
					string text2 = Path.Combine(Uploader.UploaderPath, text);
					int num = 1;
					while (Directory.Exists(text2))
					{
						text2 = Path.Combine(Uploader.UploaderPath, text + " (" + num.ToString() + ")");
						num++;
					}
					Directory.CreateDirectory(text2);
					SteamAPICall_t steamAPICall_t = SteamUGC.CreateItem(SteamUtils.GetAppID(), EWorkshopFileType.k_EWorkshopFileTypeFirst);
					CallResult<CreateItemResult_t>.Create(new CallResult<CreateItemResult_t>.APIDispatchDelegate(this.OnCreateItem)).Set(steamAPICall_t, null);
				}
			});
		}

		// Token: 0x0600004E RID: 78 RVA: 0x00005EE8 File Offset: 0x000040E8
		private void OnCreateItem(CreateItemResult_t t, bool failure)
		{
			if (failure)
			{
				MessageBox.Show("Failed to create item.", "Create Failed", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			if (t.m_eResult == EResult.k_EResultOK)
			{
				object nqLock = this._nqLock;
				string text;
				lock (nqLock)
				{
					text = this.NameQueue[0];
					this.NameQueue.RemoveAt(0);
				}
				UGCUpdateHandle_t ugcupdateHandle_t = SteamUGC.StartItemUpdate(SteamUtils.GetAppID(), t.m_nPublishedFileId);
				SteamUGC.SetItemTitle(ugcupdateHandle_t, text);
				SteamAPICall_t steamAPICall_t = SteamUGC.SubmitItemUpdate(ugcupdateHandle_t, "");
				CallResult<SubmitItemUpdateResult_t>.Create(delegate(SubmitItemUpdateResult_t t, bool failure)
				{
					if (failure)
					{
						MessageBox.Show("Failed to create item.", "Create Failed", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						return;
					}
					if (t.m_eResult == EResult.k_EResultOK)
					{
						AppId_t appId_t = new AppId_t(3009850U);
						MessageBox.Show("Created item: " + this.NameMod(t.m_nPublishedFileId.m_PublishedFileId), "Create Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						UGCQueryHandle_t ugcqueryHandle_t = SteamUGC.CreateQueryUserUGCRequest(SteamUser.GetSteamID().GetAccountID(), EUserUGCList.k_EUserUGCList_Published, EUGCMatchingUGCType.k_EUGCMatchingUGCType_Items_ReadyToUse, EUserUGCListSortOrder.k_EUserUGCListSortOrder_CreationOrderDesc, appId_t, appId_t, 1U);
						SteamUGC.SetReturnLongDescription(ugcqueryHandle_t, true);
						SteamUGC.SetReturnMetadata(ugcqueryHandle_t, true);
						SteamUGC.SetReturnChildren(ugcqueryHandle_t, true);
						SteamUGC.SetReturnAdditionalPreviews(ugcqueryHandle_t, true);
						SteamUGC.SetReturnTotalOnly(ugcqueryHandle_t, false);
						SteamAPICall_t steamAPICall_t2 = SteamUGC.SendQueryUGCRequest(ugcqueryHandle_t);
						this.qc = CallResult<SteamUGCQueryCompleted_t>.Create(new CallResult<SteamUGCQueryCompleted_t>.APIDispatchDelegate(this.OnQueryComplete));
						this.qc.Set(steamAPICall_t2, null);
						return;
					}
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler2 = new DefaultInterpolatedStringHandler(24, 2);
					defaultInterpolatedStringHandler2.AppendLiteral("Failed to create item ");
					defaultInterpolatedStringHandler2.AppendFormatted(this.NameMod(t.m_nPublishedFileId.m_PublishedFileId));
					defaultInterpolatedStringHandler2.AppendLiteral(": ");
					defaultInterpolatedStringHandler2.AppendFormatted<EResult>(t.m_eResult);
					MessageBox.Show(defaultInterpolatedStringHandler2.ToStringAndClear(), "Create Failed", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}).Set(steamAPICall_t, null);
				return;
			}
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(24, 2);
			defaultInterpolatedStringHandler.AppendLiteral("Failed to create item ");
			defaultInterpolatedStringHandler.AppendFormatted(this.NameMod(t.m_nPublishedFileId.m_PublishedFileId));
			defaultInterpolatedStringHandler.AppendLiteral(": ");
			defaultInterpolatedStringHandler.AppendFormatted<EResult>(t.m_eResult);
			MessageBox.Show(defaultInterpolatedStringHandler.ToStringAndClear(), "Create Failed", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}

		// Token: 0x0600004F RID: 79 RVA: 0x00005FF8 File Offset: 0x000041F8
		private void submit_Click(object sender, EventArgs e)
		{
			base.Invoke(delegate
			{
				this.SaveModData();
				if (this._selection >= 0)
				{
					ModData modData = this.Mods.First((ModData m) => m.Id == this.items[this._selection].m_nPublishedFileId.m_PublishedFileId);
					if (modData.Path == string.Empty)
					{
						MessageBox.Show("Please select a path for the mod.", "No path selected", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						return;
					}
					if (modData.Title == string.Empty)
					{
						MessageBox.Show("Please enter a title for the mod.", "No title entered", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						return;
					}
					if (modData.Description == string.Empty)
					{
						MessageBox.Show("Please enter a description for the mod.", "No description entered", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						return;
					}
					if (modData.Author == string.Empty)
					{
						MessageBox.Show("Please enter an author for the mod.", "No author entered", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						return;
					}
					if (modData.Version == string.Empty)
					{
						MessageBox.Show("Please enter a version for the mod.", "No version entered", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						return;
					}
					if (!Directory.Exists(Path.Combine(modData.Path, "plugins")) && !Directory.Exists(Path.Combine(modData.Path, "patchers")))
					{
						MessageBox.Show("Your mod doesn't have a plugins or patchers folder. Make sure you have at least one of these folders.", "No plugins or patchers folder", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						return;
					}
					string text = Path.Combine(modData.Path, "icon.png");
					string text2 = Path.Combine(modData.Path, "icon.gif");
					if (!File.Exists(text) && !File.Exists(text2) && !MessageBox.Show("Your mod doesn't have an icon. Do you want to continue without an icon?", "No icon found", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation).Equals(DialogResult.Yes))
					{
						return;
					}
					if (!File.Exists(text))
					{
						text = text2;
					}
					else if (new FileInfo(text).Length > 1048576L)
					{
						MessageBox.Show("Your icon is too large. Please make sure it's less than 1MB.", "Icon too large", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						return;
					}
					IEnumerable<string> enumerable = from t in this.modTags.Text.Split(',', StringSplitOptions.None)
						where this.OriginalTags.Contains(t.Trim())
						select t;
					if (enumerable.Count<string>() > 0)
					{
						if (MessageBox.Show("Note: The following tags are not official tags: " + enumerable.Aggregate((string a, string b) => a + ", " + b) + ". Do you want to continue?", "Not official tags", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
						{
							return;
						}
					}
					if (File.Exists(Path.Combine(modData.Path, "manifest.txt")))
					{
						File.Delete(Path.Combine(modData.Path, "manifest.txt"));
					}
					MainForm.Manifest manifest = new MainForm.Manifest
					{
						ModName = modData.Title,
						Author = modData.Author,
						Version = modData.Version
					};
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(28, 3);
					defaultInterpolatedStringHandler.AppendLiteral("modName: ");
					defaultInterpolatedStringHandler.AppendFormatted(manifest.ModName);
					defaultInterpolatedStringHandler.AppendLiteral("\nauthor: ");
					defaultInterpolatedStringHandler.AppendFormatted(manifest.Author);
					defaultInterpolatedStringHandler.AppendLiteral("\nversion: ");
					defaultInterpolatedStringHandler.AppendFormatted(manifest.Version);
					string text3 = defaultInterpolatedStringHandler.ToStringAndClear();
					File.WriteAllText(Path.Combine(modData.Path, "manifest.txt"), text3);
					UGCUpdateHandle_t ugcupdateHandle_t = SteamUGC.StartItemUpdate(SteamUtils.GetAppID(), new PublishedFileId_t(modData.Id));
					SteamUGC.SetItemTitle(ugcupdateHandle_t, modData.Title);
					SteamUGC.SetItemDescription(ugcupdateHandle_t, modData.Description);
					SteamUGC.SetItemVisibility(ugcupdateHandle_t, modData.Visibility);
					SteamUGC.SetItemContent(ugcupdateHandle_t, modData.Path);
					SteamUGC.SetItemTags(ugcupdateHandle_t, this.Tags.ToArray());
					if (text != null)
					{
						SteamUGC.SetItemPreview(ugcupdateHandle_t, text);
					}
					CallResult<SubmitItemUpdateResult_t>.Create(delegate(SubmitItemUpdateResult_t t, bool failure)
					{
						if (!failure)
						{
							if (t.m_eResult == EResult.k_EResultOK)
							{
								this.statusText.Text = "Item submitted successfully!";
								MessageBox.Show("Submitted item " + this.NameMod(t.m_nPublishedFileId.m_PublishedFileId), "Submit Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
							}
							else
							{
								this.statusText.Text = "Item submission failed: " + t.m_eResult.ToString();
								DefaultInterpolatedStringHandler defaultInterpolatedStringHandler2 = new DefaultInterpolatedStringHandler(24, 2);
								defaultInterpolatedStringHandler2.AppendLiteral("Failed to submit item ");
								defaultInterpolatedStringHandler2.AppendFormatted(this.NameMod(t.m_nPublishedFileId.m_PublishedFileId));
								defaultInterpolatedStringHandler2.AppendLiteral(": ");
								defaultInterpolatedStringHandler2.AppendFormatted<EResult>(t.m_eResult);
								MessageBox.Show(defaultInterpolatedStringHandler2.ToStringAndClear(), "Submit Failed", MessageBoxButtons.OK, MessageBoxIcon.Hand);
							}
						}
						else
						{
							this.statusText.Text = "Item submission failed.";
							MessageBox.Show("Failed to submit item.", "Submit Failed", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						}
						object cu2 = this._cu;
						lock (cu2)
						{
							this.CurrentUpload = null;
						}
						this.progressBar1.Value = 100;
					}).Set(SteamUGC.SubmitItemUpdate(ugcupdateHandle_t, this.modChangeNote.Text), null);
					object cu = this._cu;
					lock (cu)
					{
						this.CurrentUpload = new UGCUpdateHandle_t?(ugcupdateHandle_t);
					}
				}
			});
		}

		// Token: 0x06000050 RID: 80 RVA: 0x0000600C File Offset: 0x0000420C
		private void modImage_Click(object sender, EventArgs e)
		{
			MessageBox.Show("To change the image, replace the icon.png file in the mod folder.", "Change image", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}

		// Token: 0x06000051 RID: 81 RVA: 0x00006024 File Offset: 0x00004224
		private void Uploader_FormClosing(object sender, FormClosingEventArgs e)
		{
			object closeLock = this._closeLock;
			lock (closeLock)
			{
				if (!this.Closing)
				{
					this.Closing = true;
					this.TheTimer.Stop();
				}
			}
			if (this.Downloading.Count <= 0)
			{
				return;
			}
			using (Dictionary<ulong, string>.Enumerator enumerator = this.Downloading.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					KeyValuePair<ulong, string> item = enumerator.Current;
					this.Mods.RemoveAll((ModData m) => m.Id == item.Key);
				}
			}
			this.SaveMods();
		}

		// Token: 0x06000052 RID: 82 RVA: 0x000060EC File Offset: 0x000042EC
		private void modItems_Leave(object sender, EventArgs e)
		{
			this.SaveModData();
		}

		// Token: 0x06000053 RID: 83 RVA: 0x000060F4 File Offset: 0x000042F4
		private void SaveModData()
		{
			if (this._selection >= 0)
			{
				ModData modData = this.Mods.First((ModData m) => m.Id == this.items[this._selection].m_nPublishedFileId.m_PublishedFileId);
				modData.Title = this.modTitle.Text;
				modData.Description = this.EnforceLineBreaks(this.modDescription.Text, Environment.NewLine);
				string text;
				if (this.Tags.Count <= 0)
				{
					text = "";
				}
				else
				{
					text = this.Tags.Distinct<string>().Aggregate((string a, string b) => a + "," + b);
				}
				modData.Tags = text;
				modData.Visibility = (ERemoteStoragePublishedFileVisibility)this.modVisibility.SelectedIndex;
				modData.Path = this.modPath.Text;
				modData.Author = this.modAuthor.Text;
				modData.Version = this.modVersion.Text;
				this.SaveMods();
			}
		}

		// Token: 0x06000054 RID: 84 RVA: 0x000061E4 File Offset: 0x000043E4
		private string EnforceLineBreaks(string text, string newLine)
		{
			text = text.Replace("\r\n", "\n");
			text = text.Replace("\r", "\n");
			text = text.Replace("\n", newLine);
			return text;
		}

		// Token: 0x06000055 RID: 85 RVA: 0x0000621C File Offset: 0x0000441C
		private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.modSelect.SelectedItems.Count != 1)
			{
				return;
			}
			this._del = this.modSelect.SelectedItems[0].Text;
			ModData modData = this.Mods.First((ModData m) => m.Title == this._del);
			if (MessageBox.Show("Are you sure you want to delete " + this._del + "?", "Delete mod", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
			{
				return;
			}
			this.Mods.Remove(modData);
			this.items.RemoveAt(this.modSelect.SelectedItems[0].Index);
			this.modSelect.Items.Remove(this.modSelect.SelectedItems[0]);
			this.modSelect.SelectedItems.Clear();
			this.editorPanel.Enabled = false;
			this.SaveMods();
			SteamAPICall_t steamAPICall_t = SteamUGC.DeleteItem(new PublishedFileId_t(modData.Id));
			CallResult<DeleteItemResult_t>.Create(delegate(DeleteItemResult_t t, bool failure)
			{
				if (failure)
				{
					MessageBox.Show("Failed to delete item " + this._del + ".", "Delete failed", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					return;
				}
				if (t.m_eResult == EResult.k_EResultOK)
				{
					MessageBox.Show("Deleted item: " + this._del, "Delete success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					return;
				}
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(24, 2);
				defaultInterpolatedStringHandler.AppendLiteral("Failed to delete item ");
				defaultInterpolatedStringHandler.AppendFormatted(this._del);
				defaultInterpolatedStringHandler.AppendLiteral(": ");
				defaultInterpolatedStringHandler.AppendFormatted<EResult>(t.m_eResult);
				MessageBox.Show(defaultInterpolatedStringHandler.ToStringAndClear(), "Delete failed", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}).Set(steamAPICall_t, null);
		}

		// Token: 0x06000056 RID: 86 RVA: 0x00006334 File Offset: 0x00004534
		private string NameMod(ulong id)
		{
			ModData modData = this.Mods.FirstOrDefault((ModData m) => m.Id == id);
			if (modData != null)
			{
				return modData.Title;
			}
			return id.ToString();
		}

		// Token: 0x06000057 RID: 87 RVA: 0x0000637C File Offset: 0x0000457C
		private void viewSteamPageToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.modSelect.SelectedItems.Count == 1)
			{
				ModData modData = this.Mods.First((ModData m) => m.Title == this.modSelect.SelectedItems[0].Text);
				string text = "explorer.exe";
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(30, 1);
				defaultInterpolatedStringHandler.AppendLiteral("steam://url/CommunityFilePage/");
				defaultInterpolatedStringHandler.AppendFormatted<ulong>(modData.Id);
				Process.Start(text, defaultInterpolatedStringHandler.ToStringAndClear());
			}
		}

		// Token: 0x06000058 RID: 88 RVA: 0x000063E9 File Offset: 0x000045E9
		public static IEnumerable<T> SkipLast<T>(IEnumerable<T> source, int count)
		{
			Queue<T> queue = new Queue<T>();
			foreach (T item in source)
			{
				if (queue.Count == count)
				{
					yield return queue.Dequeue();
				}
				queue.Enqueue(item);
				//item = default(T);
			}
			IEnumerator<T> enumerator = null;
			yield break;
			yield break;
		}

		// Token: 0x0400002F RID: 47
		private MainForm f;

		// Token: 0x04000030 RID: 48
		private List<SteamUGCDetails_t> items = new List<SteamUGCDetails_t>();

		// Token: 0x04000031 RID: 49
		private CallResult<SteamUGCQueryCompleted_t> qc;

		// Token: 0x04000032 RID: 50
		//[Nullable(2)]
		private AutoCompleteStringCollection OriginalTags;

		// Token: 0x04000033 RID: 51
		private List<string> Tags = new List<string>();

		// Token: 0x04000034 RID: 52
		private int _selection = -1;

		// Token: 0x04000035 RID: 53
		public List<ModData> Mods = new List<ModData>();

		// Token: 0x04000036 RID: 54
		public Dictionary<ulong, Image> LocalImages = new Dictionary<ulong, Image>();

		// Token: 0x04000037 RID: 55
		private static string UploaderPath = Path.Combine(new DirectoryInfo(Process.GetCurrentProcess().MainModule.FileName).Parent.FullName, "Uploader");

		// Token: 0x04000038 RID: 56
		private static string ModDataPath = Path.Combine(Uploader.UploaderPath, "Mods.json");

		// Token: 0x04000039 RID: 57
		private Callback<DownloadItemResult_t> downloadItemResultCallback;

		// Token: 0x0400003A RID: 58
		private Dictionary<ulong, string> Downloading = new Dictionary<ulong, string>();

		// Token: 0x0400003B RID: 59
		private object _cu = new object();

		// Token: 0x0400003C RID: 60
		private UGCUpdateHandle_t? CurrentUpload;

		// Token: 0x0400003D RID: 61
		private new bool Closing;

		// Token: 0x0400003E RID: 62
		private object _closeLock = new object();

		// Token: 0x0400003F RID: 63
		private System.Windows.Forms.Timer TheTimer;

		// Token: 0x04000040 RID: 64
		private Dictionary<string, string> TagAliases = new Dictionary<string, string>
		{
			{ "Arena", "Arenas" },
			{ "Character", "Characters" },
			{ "Cheat", "Cheats" },
			{ "Costume", "Costumes" },
			{ "Library", "Libraries" },
			{ "Miscellaneous", "Misc" },
			{ "Move", "Moves" },
			{ "Override", "Overrides" },
			{ "Promo", "Promos" },
			{ "Meeting", "Promos" },
			{ "Conversation", "Promos" },
			{ "Texture", "Textures" },
			{ "Theme", "Themes" },
			{ "Tool", "Tools" },
			{ "Tweak", "Tweaks" },
			{ "Weapon", "Weapons" },
			{ "Wrestler", "Characters" },
			{ "Wrestlers", "Characters" },
			{ "Music", "Themes" },
			{ "Sound", "Audio" },
			{ "Sounds", "Audio" },
			{ "Furnishing", "Furniture" },
			{ "Furnishings", "Furniture" },
			{ "Item", "Furniture" },
			{ "Items", "Furniture" },
			{ "Other", "Misc" }
		};

		// Token: 0x04000041 RID: 65
		private object _nqLock = new object();

		// Token: 0x04000042 RID: 66
		private List<string> NameQueue = new List<string>();

		// Token: 0x04000043 RID: 67
		private string _del;
	}
}

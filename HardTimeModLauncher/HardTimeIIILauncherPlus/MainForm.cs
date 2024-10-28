using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security;
using System.Windows.Forms;
using Steamworks;

namespace HardTimeIIILauncherPlus
{
	// Token: 0x02000008 RID: 8
	//[NullableContext(1)]
	//[Nullable(0)]
	public partial class MainForm : Form
	{
		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000010 RID: 16 RVA: 0x00002A8C File Offset: 0x00000C8C
		internal static MainForm.LauncherData Data
		{
			get
			{
				if (MainForm._data == null)
				{
					MainForm._data = new MainForm.LauncherData();
					MainForm._data.Load();
				}
				return MainForm._data;
			}
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00002AAE File Offset: 0x00000CAE
		public MainForm()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00002ABC File Offset: 0x00000CBC
		public void Write(object str, Color? color = null)
		{
			this.txtConsole.SelectionStart = this.txtConsole.TextLength;
			this.txtConsole.SelectionLength = 0;
			this.txtConsole.SelectionColor = color ?? this.txtConsole.ForeColor;
			this.txtConsole.AppendText(((str != null) ? str.ToString() : null) + "\n");
			this.txtConsole.SelectionColor = this.txtConsole.ForeColor;
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002B4C File Offset: 0x00000D4C
		public void Fatal(object str, Exception e = null)
		{
			this.Write(str, new Color?(Color.FromName("red")));
			if (e == null)
			{
				MessageBox.Show(str.ToString(), "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			else
			{
				MessageBox.Show(((str != null) ? str.ToString() : null) + "\n\n" + e.ToString(), "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			Environment.Exit(1);
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00002BB8 File Offset: 0x00000DB8
		private void MainForm_Load(object sender, EventArgs e)
		{
			this.label3.Text = "Hard Time III Mod Launcher Plus v1.0.3 | Steamworks.NET v20.2.0";
			this.Font = new Font(this.Font.FontFamily, (float)Screen.PrimaryScreen.Bounds.Height / 160f, FontStyle.Bold);
			base.Width = Screen.PrimaryScreen.Bounds.Width * 2 / 3;
			base.Height = Screen.PrimaryScreen.Bounds.Height * 2 / 3;
			base.CenterToScreen();
			try
			{
				this.Write("Hard Time III Mod Launcher Plus v1.0.3", null);
				MainForm._bepinexDir = Path.Combine(new DirectoryInfo(Process.GetCurrentProcess().MainModule.FileName).Parent.FullName, "BepInEx", "plugins");
				if (!Directory.Exists(MainForm._bepinexDir))
				{
					Directory.CreateDirectory(MainForm._bepinexDir);
				}
				MainForm._currentModsFile = Path.Combine(MainForm._bepinexDir, "current_mods.txt");
				if (!File.Exists(MainForm._currentModsFile))
				{
					File.Create(MainForm._currentModsFile).Close();
				}
				if (!this.ConfirmedWarning())
				{
					this.ShowWarning();
				}
				AppId_t appId_t = new AppId_t(3009850U);
				if (!SteamAPI.Init())
				{
					this.Fatal("Steam API failed to initialize.\r\nPlease make sure Steam is running and you are logged in, then try again.\r\nIf you are still having issues, try restarting Steam.", null);
				}
				if (SteamAPI.RestartAppIfNecessary(appId_t))
				{
					this.Write("Restarting app...", null);
				}
				else
				{
					if (!SteamApps.BIsSubscribedApp(appId_t))
					{
						this.Fatal("Hard Time III is not purchased.\r\nPlease purchase Hard Time III and try again.", null);
					}
					this.Write("Steam API initialized successfully.", new Color?(Color.FromName("lime")));
					MainForm._subscribedItems = new PublishedFileId_t[SteamUGC.GetNumSubscribedItems()];
					SteamUGC.GetSubscribedItems(MainForm._subscribedItems, (uint)MainForm._subscribedItems.Length);
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler;
					if (MainForm._subscribedItems.Length == 0)
					{
						this.Write("You are not subscribed to any mods.", null);
					}
					else
					{
						defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(28, 1);
						defaultInterpolatedStringHandler.AppendLiteral("You are subscribed to ");
						defaultInterpolatedStringHandler.AppendFormatted<int>(MainForm._subscribedItems.Length);
						defaultInterpolatedStringHandler.AppendLiteral(" mods.");
						this.Write(defaultInterpolatedStringHandler.ToStringAndClear(), null);
						foreach (PublishedFileId_t publishedFileId_t in MainForm._subscribedItems)
						{
							ulong num;
							string text;
							uint num2;
							if (SteamUGC.GetItemInstallInfo(publishedFileId_t, out num, out text, 1024U, out num2))
							{
								string text2 = Path.Combine(text, "manifest.txt");
								MainForm.Manifest manifest = new MainForm.Manifest();
								manifest.Load(text2);
								MainForm._manifests[publishedFileId_t] = manifest;
								MainForm._identifierToId[manifest.Identifier] = publishedFileId_t.m_PublishedFileId;
								if (!MainForm.Data.Mods.ContainsKey(publishedFileId_t.m_PublishedFileId))
								{
									MainForm.Data.Mods[publishedFileId_t.m_PublishedFileId] = new MainForm.LauncherData.ModData
									{
										Id = publishedFileId_t.m_PublishedFileId,
										Enabled = true,
										Installed = false,
										Manifest = manifest,
										_folder = text,
										Downloaded = true
									};
								}
								else
								{
									MainForm.Data.Mods[publishedFileId_t.m_PublishedFileId].Downloaded = true;
								}
							}
						}
					}
					this.ReloadInstalledMods();
					defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(31, 2);
					defaultInterpolatedStringHandler.AppendFormatted<int>(MainForm.Data.NumEnabledMods);
					defaultInterpolatedStringHandler.AppendLiteral(" enabled mods, ");
					defaultInterpolatedStringHandler.AppendFormatted<int>(MainForm.Data.NumInstalledMods);
					defaultInterpolatedStringHandler.AppendLiteral(" installed mods.");
					this.Write(defaultInterpolatedStringHandler.ToStringAndClear(), null);
					int num3 = 0;
					foreach (MainForm.LauncherData.ModData modData in MainForm.Data.Mods.Values)
					{
						if (!modData.Downloaded && modData.Enabled)
						{
							num3++;
							modData.Enabled = false;
						}
					}
					if (num3 > 0)
					{
						defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(65, 1);
						defaultInterpolatedStringHandler.AppendFormatted<int>(num3);
						defaultInterpolatedStringHandler.AppendLiteral(" enabled mods are no longer subscribed to. They will be disabled.");
						this.Write(defaultInterpolatedStringHandler.ToStringAndClear(), null);
					}
					SteamAPI.Shutdown();
				}
			}
			catch (Exception ex)
			{
				this.Write("A fatal error occurred while running the launcher.\r\nPlease report this error to IngoH (@ingoh on Discord, ingohhacks@gmail.com).\r\nError message: " + ex.Message + "\r\nStack trace: " + ex.StackTrace, new Color?(Color.FromName("red")));
				this.TryWriteExplanation(ex);
				this.Fatal("An error occurred while running the launcher.", ex);
			}
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00003054 File Offset: 0x00001254
		private void ReloadInstalledMods()
		{
			foreach (KeyValuePair<PublishedFileId_t, MainForm.Manifest> keyValuePair in MainForm._manifests)
			{
				int num = this.listBoxMain.Items.Add(keyValuePair.Value.Identifier);
				if (MainForm.Data.Mods[keyValuePair.Key.m_PublishedFileId].Enabled)
				{
					if (MainForm.Data.Mods[keyValuePair.Key.m_PublishedFileId].Installed)
					{
						this.listBoxMain.SetItemCheckState(num, CheckState.Checked);
					}
					else
					{
						this.listBoxMain.SetItemCheckState(num, CheckState.Indeterminate);
					}
				}
			}
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00003124 File Offset: 0x00001324
		private void TryWriteExplanation(Exception exception)
		{
			try
			{
				if (!(exception is FileNotFoundException))
				{
					if (!(exception is DirectoryNotFoundException))
					{
						if (!(exception is UnauthorizedAccessException))
						{
							if (!(exception is PathTooLongException))
							{
								if (!(exception is IOException))
								{
									if (!(exception is InvalidOperationException))
									{
										if (!(exception is NotSupportedException))
										{
											if (!(exception is TimeoutException))
											{
												if (!(exception is ArgumentException))
												{
													if (!(exception is SecurityException))
													{
														if (!(exception is NullReferenceException))
														{
															if (!(exception is IndexOutOfRangeException))
															{
																if (!(exception is DivideByZeroException))
																{
																	if (!(exception is OverflowException))
																	{
																		if (!(exception is StackOverflowException))
																		{
																			if (exception is OutOfMemoryException)
																			{
																				this.Write("The system ran out of memory. If you have many programs running, try closing some of them and try again.", new Color?(Color.FromName("blue")));
																			}
																			else
																			{
																				this.Write("An unknown error occurred. This is most likely a bug in the launcher.", new Color?(Color.FromName("blue")));
																			}
																		}
																		else
																		{
																			this.Write("A stack overflow occurred. Wait, stack overflows aren't supposed to be caught by try-catch blocks! How did you do that?", new Color?(Color.FromName("blue")));
																		}
																	}
																	else
																	{
																		this.Write("An overflow occurred. This is most likely a bug in the launcher.", new Color?(Color.FromName("blue")));
																	}
																}
																else
																{
																	this.Write("A division by zero was attempted. This is most likely a bug in the launcher, or maybe you're trying to download an empty file.", new Color?(Color.FromName("blue")));
																}
															}
															else
															{
																this.Write("An index was out of range. This is most likely a bug in the launcher.", new Color?(Color.FromName("blue")));
															}
														}
														else
														{
															this.Write("A null reference was encountered. This is most likely a bug in the launcher.", new Color?(Color.FromName("blue")));
														}
													}
													else
													{
														this.Write("A security error occurred. Check that the launcher has the required permissions to access the game files.", new Color?(Color.FromName("blue")));
													}
												}
												else
												{
													this.Write("An argument was invalid. This is most likely a bug in the launcher.", new Color?(Color.FromName("blue")));
												}
											}
											else
											{
												this.Write("A timeout occurred. Make sure you have a stable internet connection and try again.", new Color?(Color.FromName("blue")));
											}
										}
										else
										{
											this.Write("An operation is not supported. This is most likely a bug in the launcher.", new Color?(Color.FromName("blue")));
										}
									}
									else
									{
										this.Write("An invalid operation was performed. This is most likely a bug in the launcher.", new Color?(Color.FromName("blue")));
									}
								}
								else
								{
									this.Write("An I/O error occurred. This is either a bug in the launcher or caused by manual modifications to mod files.", new Color?(Color.FromName("blue")));
								}
							}
							else
							{
								this.Write("A path was too long. That's it. You'll have to move the game to a shorter path.", new Color?(Color.FromName("blue")));
							}
						}
						else
						{
							this.Write("Access to a file or directory was denied. This could have multiple causes, including the file being in use by another program or the launcher not having the required permissions.", new Color?(Color.FromName("blue")));
						}
					}
					else
					{
						this.Write("A directory was not found. This is either a bug in the launcher or caused by manual modifications to mod files.", new Color?(Color.FromName("blue")));
					}
				}
				else
				{
					this.Write("A file was not found. This is either a bug in the launcher or caused by manual modifications to mod files.", new Color?(Color.FromName("blue")));
				}
			}
			catch (Exception)
			{
				this.Write("An error occurred while trying to explain the error. Turns out, explaining errors is hard.", new Color?(Color.FromName("blue")));
			}
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00003414 File Offset: 0x00001614
		public bool ConfirmedWarning()
		{
			return File.Exists("warning.confirmed");
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00003420 File Offset: 0x00001620
		public void ShowWarning()
		{
			this.Write("WARNING:\r\nThis launcher will install mods from the Steam Workshop.\r\nThese mods are not officially supported by the game's developer.\r\nIt is possible that these mods may cause issues with the game.\r\nGame updates will likely break some mods. Make sure to check for updates to your mods after game updates.\r\nIt is recommended that you backup your save files before using this launcher.\r\nThe HTCCL mod will automatically backup your save files. However, it is still recommended that you backup your save files manually.\r\nYou can do backup by copying the Save.bytes file from the following folder:", new Color?(Color.FromName("yellow")));
			this.Write(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "Low", "MDickie", "Hard Time III") ?? "", null);
			this.Write("to a safe location.\r\nDo not report any issues you encounter while using this launcher to the game's developer.\r\nJoin the Hard Time III modding community at https://discord.gg/zWzRCTHMdS or mail to contact@ingoh.net for support.", new Color?(Color.FromName("yellow")));
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00003499 File Offset: 0x00001699
		private void ConfirmWarning()
		{
			File.Create("warning.confirmed").Close();
			File.SetAttributes("warning.confirmed", File.GetAttributes("warning.confirmed") | FileAttributes.Hidden);
		}

		// Token: 0x0600001A RID: 26 RVA: 0x000034C0 File Offset: 0x000016C0
		private void btnRunModded_Click(object sender, EventArgs e)
		{
			this.LaunchModded();
		}

		// Token: 0x0600001B RID: 27 RVA: 0x000034C8 File Offset: 0x000016C8
		private void LaunchModded()
		{
			if (!this.ConfirmedWarning())
			{
				if (MessageBox.Show("Did you read the warning?\nBy clicking 'Yes', you confirm that you understand the risks of using mods and that you will not report any issues you encounter while using mods to the game's developer.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
				{
					return;
				}
				this.ConfirmWarning();
			}
			int numEnabledMods = MainForm.Data.NumEnabledMods;
			List<string> list = new List<string>();
			foreach (MainForm.LauncherData.ModData modData in MainForm.Data.Mods.Values.Where((MainForm.LauncherData.ModData mod) => mod.Installed && !mod.Enabled))
			{
				list.Add(modData.Manifest.Identifier);
			}
			if (list.Count > 0 && MessageBox.Show("The following mods will be removed:\n" + string.Join("\n", list) + "\nAre you sure you want to continue?\nRemoving mods may cause issues with your save files.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
			{
				return;
			}
			int num = 0;
			foreach (MainForm.LauncherData.ModData modData2 in MainForm.Data.Mods.Values)
			{
				if (modData2.Enabled != modData2.Installed)
				{
					if (modData2.Enabled)
					{
						this.Write("Installing " + modData2.Manifest.Identifier + "...", null);
						this.InstallMod(modData2);
					}
					else
					{
						this.Write("Uninstalling " + modData2.Manifest.Identifier + "...", null);
						this.UninstallMod(modData2);
					}
				}
				else if (modData2.Enabled)
				{
					this.CheckForUpdates(modData2);
				}
				num++;
			}
			MainForm.Data.Save();
			MainForm.Run = 2;
			base.Close();
		}

		// Token: 0x0600001C RID: 28 RVA: 0x000036B4 File Offset: 0x000018B4
		private void UninstallMod(MainForm.LauncherData.ModData mod)
		{
			mod.Installed = false;
			if (!Directory.Exists(Path.Combine(MainForm._bepinexDir, mod.Manifest.Identifier)))
			{
				this.Write("Already uninstalled.", null);
				return;
			}
			Directory.Delete(Path.Combine(MainForm._bepinexDir, mod.Manifest.Identifier), true);
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00003714 File Offset: 0x00001914
		private void InstallMod(MainForm.LauncherData.ModData mod)
		{
			MainForm.Manifest manifest = mod.Manifest;
			string folder = mod._folder;
			if (!Directory.Exists(Path.Combine(MainForm._bepinexDir, manifest.Identifier)))
			{
				Directory.CreateDirectory(Path.Combine(MainForm._bepinexDir, manifest.Identifier));
			}
			string text = Path.Combine(MainForm._bepinexDir, manifest.Identifier);
			foreach (string text2 in Directory.GetFiles(folder))
			{
				string fileName = Path.GetFileName(text2);
				string text3 = Path.Combine(text, fileName);
				File.Copy(text2, text3, true);
			}
			string text4 = Path.Combine(folder, "plugins");
			this.CopyAll(text4, text);
			string text5 = Path.Combine(folder, "patchers");
			this.CopyAll(text5, text);
			string text6 = Path.Combine(folder, "config");
			this.CopyAll(text6, text);
			mod.Installed = true;
		}

		// Token: 0x0600001E RID: 30 RVA: 0x000037F0 File Offset: 0x000019F0
		private void CheckForUpdates(MainForm.LauncherData.ModData mod)
		{
			MainForm.Manifest manifest = mod.Manifest;
			string text = Path.Combine(MainForm._bepinexDir, manifest.Identifier);
			MainForm.Manifest manifest2 = new MainForm.Manifest();
			manifest2.Load(Path.Combine(text, "manifest.txt"));
			if (manifest2.Version != manifest.Version)
			{
				this.Write("Updating " + manifest.Identifier + "...", null);
				this.InstallMod(mod);
			}
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00003868 File Offset: 0x00001A68
		private void CopyAll(string source, string target)
		{
			if (Directory.Exists(source))
			{
				Directory.CreateDirectory(target);
				string[] array = Directory.GetDirectories(source, "*", SearchOption.AllDirectories);
				for (int i = 0; i < array.Length; i++)
				{
					Directory.CreateDirectory(array[i].Replace(source, target));
				}
				array = Directory.GetFiles(source, "*", SearchOption.AllDirectories);
				foreach (string text in array)
				{
					File.Copy(text, text.Replace(source, target), true);
				}
			}
		}

		// Token: 0x06000020 RID: 32 RVA: 0x000038DD File Offset: 0x00001ADD
		private void btnRunVanilla_Click(object sender, EventArgs e)
		{
			this.LaunchVanilla();
		}

		// Token: 0x06000021 RID: 33 RVA: 0x000038E5 File Offset: 0x00001AE5
		private void LaunchVanilla()
		{
			MainForm.Run = 1;
			base.Close();
		}

		// Token: 0x06000022 RID: 34 RVA: 0x000038F3 File Offset: 0x00001AF3
		private void btnRunUploader_Click(object sender, EventArgs e)
		{
			this.StartUploader();
		}

		// Token: 0x06000023 RID: 35 RVA: 0x000038FB File Offset: 0x00001AFB
		private void StartUploader()
		{
			new Uploader(this).Show();
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00003908 File Offset: 0x00001B08
		private void listBoxMain_SelectedValueChanged(object sender, EventArgs e)
		{
			int selectedIndex = this.listBoxMain.SelectedIndex;
			if (selectedIndex == -1)
			{
				return;
			}
			object obj = this.listBoxMain.Items[selectedIndex];
			ulong num = MainForm._identifierToId[obj.ToString()];
			MainForm.LauncherData.ModData modData = MainForm.Data.Mods[num];
			modData.Enabled = !modData.Enabled;
			if (modData.Enabled)
			{
				if (!modData.Installed)
				{
					this.listBoxMain.SetItemCheckState(selectedIndex, CheckState.Indeterminate);
				}
				else
				{
					this.listBoxMain.SetItemCheckState(selectedIndex, CheckState.Checked);
				}
			}
			else
			{
				this.listBoxMain.SetItemCheckState(selectedIndex, CheckState.Unchecked);
			}
			((ListBox)sender).ClearSelected();
		}

		// Token: 0x06000025 RID: 37 RVA: 0x000039AF File Offset: 0x00001BAF
		private void btnExtra_Click(object sender, EventArgs e)
		{
			this.ctxExtra.Show(this.btnExtra, new Point(0, this.btnExtra.Height));
		}

		// Token: 0x06000026 RID: 38 RVA: 0x000039D4 File Offset: 0x00001BD4
		private void openSaveFolder(object sender, EventArgs e)
		{
			string text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "Low", "MDickie", "Hard Time III");
			Process.Start("explorer.exe", text);
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00003A10 File Offset: 0x00001C10
		private void openModFolder(object sender, EventArgs e)
		{
			string bepinexDir = MainForm._bepinexDir;
			Process.Start("explorer.exe", bepinexDir);
		}

		// Token: 0x06000028 RID: 40 RVA: 0x00003A2F File Offset: 0x00001C2F
		private void showHelp(object sender, EventArgs e)
		{
			Process.Start("explorer.exe", "https://ingoh.net/mdickie_modding_guide.pdf");
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00003A41 File Offset: 0x00001C41
		private void showAbout(object sender, EventArgs e)
		{
			About about = new About();
			about.ShowDialog(this);
			about.Dispose();
		}

		// Token: 0x0400000C RID: 12
		public const string Version = "1.0.3";

		// Token: 0x0400000D RID: 13
		//[Nullable(2)]
		private static string _bepinexDir;

		// Token: 0x0400000E RID: 14
		//[Nullable(2)]
		private static string _currentModsFile;

		// Token: 0x0400000F RID: 15
		//[Nullable(2)]
		private static PublishedFileId_t[] _subscribedItems;

		// Token: 0x04000010 RID: 16
		private static Dictionary<PublishedFileId_t, MainForm.Manifest> _manifests = new Dictionary<PublishedFileId_t, MainForm.Manifest>();

		// Token: 0x04000011 RID: 17
		private static Dictionary<string, ulong> _identifierToId = new Dictionary<string, ulong>();

		// Token: 0x04000012 RID: 18
		//[Nullable(2)]
		private static MainForm.LauncherData _data;

		// Token: 0x04000013 RID: 19
		public const int DO_NOT_RUN = 0;

		// Token: 0x04000014 RID: 20
		public const int RUN_VANILLA = 1;

		// Token: 0x04000015 RID: 21
		public const int RUN_MODDED = 2;

		// Token: 0x04000016 RID: 22
		public static int Run = 0;

		// Token: 0x0200000C RID: 12
		//[Nullable(0)]
		internal class Manifest
		{
			// Token: 0x17000010 RID: 16
			// (get) Token: 0x06000068 RID: 104 RVA: 0x000087D4 File Offset: 0x000069D4
			// (set) Token: 0x06000069 RID: 105 RVA: 0x000087DC File Offset: 0x000069DC
			internal string ModName { get; set; } = "[Unknown Mod]";

			// Token: 0x17000011 RID: 17
			// (get) Token: 0x0600006A RID: 106 RVA: 0x000087E5 File Offset: 0x000069E5
			// (set) Token: 0x0600006B RID: 107 RVA: 0x000087ED File Offset: 0x000069ED
			internal string Author { get; set; } = "[Unknown Author]";

			// Token: 0x17000012 RID: 18
			// (get) Token: 0x0600006C RID: 108 RVA: 0x000087F6 File Offset: 0x000069F6
			// (set) Token: 0x0600006D RID: 109 RVA: 0x000087FE File Offset: 0x000069FE
			internal string Version { get; set; } = "1.0.0";

			// Token: 0x17000013 RID: 19
			// (get) Token: 0x0600006E RID: 110 RVA: 0x00008808 File Offset: 0x00006A08
			internal string Identifier
			{
				get
				{
					if (this.ModName == "[Unknown Mod]")
					{
						return "[Unknown Mod]";
					}
					if (this.Author == "[Unknown Author]")
					{
						return this.ModName;
					}
					return this.Author + "-" + this.ModName;
				}
			}

			// Token: 0x0600006F RID: 111 RVA: 0x0000885C File Offset: 0x00006A5C
			internal void Load(string path)
			{
				this._path = path;
				if (!File.Exists(path))
				{
					return;
				}
				string[] array = File.ReadAllLines(path);
				for (int i = 0; i < array.Length; i++)
				{
					string[] array2 = array[i].Replace("=", ":").Split(':', StringSplitOptions.None);
					if (array2.Length == 2)
					{
						string text = array2[0].Trim().ToLower().Replace("_", "")
							.Replace(" ", "");
						string text2 = array2[1].Trim();
						if (!(text == "modname"))
						{
							if (!(text == "author"))
							{
								if (text == "version")
								{
									this.Version = text2;
								}
							}
							else
							{
								this.Author = text2;
							}
						}
						else
						{
							this.ModName = text2;
						}
					}
				}
			}

			// Token: 0x04000064 RID: 100
			internal string _path;
		}

		// Token: 0x0200000D RID: 13
		//[Nullable(0)]
		internal class LauncherData
		{
			// Token: 0x17000014 RID: 20
			// (get) Token: 0x06000071 RID: 113 RVA: 0x00008959 File Offset: 0x00006B59
			// (set) Token: 0x06000072 RID: 114 RVA: 0x00008961 File Offset: 0x00006B61
			internal Dictionary<ulong, MainForm.LauncherData.ModData> Mods { get; set; } = new Dictionary<ulong, MainForm.LauncherData.ModData>();

			// Token: 0x17000015 RID: 21
			// (get) Token: 0x06000073 RID: 115 RVA: 0x0000896A File Offset: 0x00006B6A
			// (set) Token: 0x06000074 RID: 116 RVA: 0x00008972 File Offset: 0x00006B72
			internal Dictionary<ulong, MainForm.LauncherData.ModData> DeletedMods { get; set; } = new Dictionary<ulong, MainForm.LauncherData.ModData>();

			// Token: 0x17000016 RID: 22
			// (get) Token: 0x06000075 RID: 117 RVA: 0x0000897B File Offset: 0x00006B7B
			internal int NumMods
			{
				get
				{
					return this.Mods.Count;
				}
			}

			// Token: 0x17000017 RID: 23
			// (get) Token: 0x06000076 RID: 118 RVA: 0x00008988 File Offset: 0x00006B88
			internal int NumEnabledMods
			{
				get
				{
					return this.Mods.Values.Count((MainForm.LauncherData.ModData mod) => mod.Enabled);
				}
			}

			// Token: 0x17000018 RID: 24
			// (get) Token: 0x06000077 RID: 119 RVA: 0x000089B9 File Offset: 0x00006BB9
			internal int NumInstalledMods
			{
				get
				{
					return this.Mods.Values.Count((MainForm.LauncherData.ModData mod) => mod.Installed);
				}
			}

			// Token: 0x06000078 RID: 120 RVA: 0x000089EC File Offset: 0x00006BEC
			internal void Load()
			{
				if (!File.Exists(MainForm._currentModsFile))
				{
					File.Create(MainForm._currentModsFile).Close();
					return;
				}
				string[] array = File.ReadAllLines(MainForm._currentModsFile);
				for (int i = 0; i < array.Length; i++)
				{
					string[] array2 = array[i].Split('|', StringSplitOptions.None);
					if (array2.Length == 5)
					{
						string text = array2[0].Trim();
						string text2 = array2[1].Trim();
						string text3 = array2[2].Trim();
						string text4 = array2[3].Trim();
						string text5 = array2[4].Trim();
						ulong num;
						bool flag;
						bool flag2;
						if (ulong.TryParse(text, out num) && bool.TryParse(text2, out flag) && bool.TryParse(text3, out flag2))
						{
							MainForm.Manifest manifest = new MainForm.Manifest();
							manifest.Load(text4);
							this.Mods.Add(num, new MainForm.LauncherData.ModData
							{
								Id = num,
								Enabled = flag,
								Installed = flag2,
								Manifest = manifest,
								_folder = text5
							});
						}
					}
				}
			}

			// Token: 0x06000079 RID: 121 RVA: 0x00008AE4 File Offset: 0x00006CE4
			internal void Save()
			{
				List<string> list = new List<string>();
				foreach (MainForm.LauncherData.ModData modData in this.Mods.Values.Where((MainForm.LauncherData.ModData mod) => mod.Downloaded))
				{
					List<string> list2 = list;
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(4, 5);
					defaultInterpolatedStringHandler.AppendFormatted<ulong>(modData.Id);
					defaultInterpolatedStringHandler.AppendLiteral("|");
					defaultInterpolatedStringHandler.AppendFormatted<bool>(modData.Enabled);
					defaultInterpolatedStringHandler.AppendLiteral("|");
					defaultInterpolatedStringHandler.AppendFormatted<bool>(modData.Installed);
					defaultInterpolatedStringHandler.AppendLiteral("|");
					defaultInterpolatedStringHandler.AppendFormatted(modData.Manifest._path);
					defaultInterpolatedStringHandler.AppendLiteral("|");
					defaultInterpolatedStringHandler.AppendFormatted(modData._folder);
					list2.Add(defaultInterpolatedStringHandler.ToStringAndClear());
				}
				File.WriteAllLines(MainForm._currentModsFile, list);
			}

			// Token: 0x02000018 RID: 24
			//[Nullable(0)]
			internal class ModData
			{
				// Token: 0x1700001B RID: 27
				// (get) Token: 0x0600009B RID: 155 RVA: 0x00008F5B File Offset: 0x0000715B
				// (set) Token: 0x0600009C RID: 156 RVA: 0x00008F63 File Offset: 0x00007163
				internal ulong Id { get; set; }

				// Token: 0x1700001C RID: 28
				// (get) Token: 0x0600009D RID: 157 RVA: 0x00008F6C File Offset: 0x0000716C
				// (set) Token: 0x0600009E RID: 158 RVA: 0x00008F74 File Offset: 0x00007174
				internal MainForm.Manifest Manifest { get; set; }

				// Token: 0x1700001D RID: 29
				// (get) Token: 0x0600009F RID: 159 RVA: 0x00008F7D File Offset: 0x0000717D
				// (set) Token: 0x060000A0 RID: 160 RVA: 0x00008F85 File Offset: 0x00007185
				internal bool Enabled { get; set; }

				// Token: 0x1700001E RID: 30
				// (get) Token: 0x060000A1 RID: 161 RVA: 0x00008F8E File Offset: 0x0000718E
				// (set) Token: 0x060000A2 RID: 162 RVA: 0x00008F96 File Offset: 0x00007196
				internal bool Installed { get; set; }

				// Token: 0x1700001F RID: 31
				// (get) Token: 0x060000A3 RID: 163 RVA: 0x00008F9F File Offset: 0x0000719F
				// (set) Token: 0x060000A4 RID: 164 RVA: 0x00008FA7 File Offset: 0x000071A7
				internal bool Downloaded { get; set; }

				// Token: 0x04000085 RID: 133
				internal string _folder;
			}
		}
	}
}

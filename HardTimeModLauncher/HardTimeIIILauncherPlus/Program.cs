using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace HardTimeIIILauncherPlus
{
	// Token: 0x0200000A RID: 10
	internal static class Program
	{
		// Token: 0x0600003E RID: 62 RVA: 0x0000486C File Offset: 0x00002A6C
		[STAThread]
		private static void Main()
		{
			if (!File.Exists("steam_api64.dll"))
			{
				string text = Path.Combine("Hard Time III_Data", "Plugins", "x86_64", "steam_api64.dll");
				if (!File.Exists(text))
				{
					MessageBox.Show("Steam API not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					return;
				}
				File.Copy(text, "steam_api64.dll");
				File.SetAttributes("steam_api64.dll", File.GetAttributes("steam_api64.dll") | FileAttributes.Hidden);
			}
			Application.EnableVisualStyles();
			ApplicationConfiguration.Initialize();
			Application.Run(new MainForm());
			if (MainForm.Run == 1)
			{
				Process.Start("explorer.exe", "steam://rungameid/3009850//--doorstop-enable false");
				return;
			}
			if (MainForm.Run == 2)
			{
				Process.Start("explorer.exe", "steam://rungameid/3009850//--doorstop-enable true");
			}
		}
	}
}

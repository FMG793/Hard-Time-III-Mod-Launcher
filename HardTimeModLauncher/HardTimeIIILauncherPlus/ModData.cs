using System;
using System.Runtime.CompilerServices;
using Steamworks;

namespace HardTimeIIILauncherPlus
{
	// Token: 0x02000009 RID: 9
	//[NullableContext(1)]
	//[Nullable(0)]
	public class ModData
	{
		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600002D RID: 45 RVA: 0x00004786 File Offset: 0x00002986
		// (set) Token: 0x0600002E RID: 46 RVA: 0x0000478E File Offset: 0x0000298E
		public ulong Id { get; set; }

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x0600002F RID: 47 RVA: 0x00004797 File Offset: 0x00002997
		// (set) Token: 0x06000030 RID: 48 RVA: 0x0000479F File Offset: 0x0000299F
		public string Title { get; set; } = string.Empty;

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000031 RID: 49 RVA: 0x000047A8 File Offset: 0x000029A8
		// (set) Token: 0x06000032 RID: 50 RVA: 0x000047B0 File Offset: 0x000029B0
		public string Path { get; set; } = string.Empty;

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000033 RID: 51 RVA: 0x000047B9 File Offset: 0x000029B9
		// (set) Token: 0x06000034 RID: 52 RVA: 0x000047C1 File Offset: 0x000029C1
		public string Description { get; set; } = string.Empty;

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000035 RID: 53 RVA: 0x000047CA File Offset: 0x000029CA
		// (set) Token: 0x06000036 RID: 54 RVA: 0x000047D2 File Offset: 0x000029D2
		public string Tags { get; set; } = string.Empty;

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000037 RID: 55 RVA: 0x000047DB File Offset: 0x000029DB
		// (set) Token: 0x06000038 RID: 56 RVA: 0x000047E3 File Offset: 0x000029E3
		public string Author { get; set; } = string.Empty;

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000039 RID: 57 RVA: 0x000047EC File Offset: 0x000029EC
		// (set) Token: 0x0600003A RID: 58 RVA: 0x000047F4 File Offset: 0x000029F4
		public string Version { get; set; } = string.Empty;

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x0600003B RID: 59 RVA: 0x000047FD File Offset: 0x000029FD
		// (set) Token: 0x0600003C RID: 60 RVA: 0x00004805 File Offset: 0x00002A05
		public ERemoteStoragePublishedFileVisibility Visibility { get; set; } = ERemoteStoragePublishedFileVisibility.k_ERemoteStoragePublishedFileVisibilityPrivate;
	}
}

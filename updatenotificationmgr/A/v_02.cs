using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace A
{
	// Token: 0x02000002 RID: 2
	[CompilerGenerated]
	[DebuggerNonUserCode]
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
	internal class v_02
	{
		// Token: 0x06000002 RID: 2 RVA: 0x0000205C File Offset: 0x0000025C
		internal v_02()
		{
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000003 RID: 3 RVA: 0x00002070 File Offset: 0x00000270
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (v_02.v_03 == null)
				{
					v_02.v_03 = new ResourceManager(v_04.v_05(1), typeof(v_02).Assembly);
				}
				return v_02.v_03;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000004 RID: 4 RVA: 0x000020C0 File Offset: 0x000002C0
		// (set) Token: 0x06000005 RID: 5 RVA: 0x000020D4 File Offset: 0x000002D4
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return v_02.v_06;
			}
			set
			{
				v_02.v_06 = value;
			}
		}

		// Token: 0x04000001 RID: 1
		private static ResourceManager v_03;

		// Token: 0x04000002 RID: 2
		private static CultureInfo v_06;
	}
}

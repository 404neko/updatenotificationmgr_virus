using System;
using System.IO;
using System.Reflection;

namespace A
{
	// Token: 0x02000005 RID: 5
	internal class v_00
	{
		// Token: 0x0600000A RID: 10 RVA: 0x00002148 File Offset: 0x00000348
		static v_00()
		{
			AppDomain.CurrentDomain.ResourceResolve += v_00.v_41;
			AppDomain.CurrentDomain.AssemblyResolve += v_00.v_42;
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			string assemblyString = v_00.v_43(executingAssembly);
			v_00.v_44 = Assembly.Load(assemblyString);
		}

		// Token: 0x0600000C RID: 12 RVA: 0x000021B8 File Offset: 0x000003B8
		internal static void v_01()
		{
		}

		// Token: 0x0600000D RID: 13 RVA: 0x000021C8 File Offset: 0x000003C8
		private static Assembly v_42(object v_45, ResolveEventArgs v_13)
		{
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			string text = v_00.v_43(executingAssembly);
			if (v_13.Name.StartsWith(text))
			{
				Stream manifestResourceStream = executingAssembly.GetManifestResourceStream(text);
				byte[] rawAssembly = v_46.v_47(97L, manifestResourceStream);
				return Assembly.Load(rawAssembly);
			}
			return null;
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00002228 File Offset: 0x00000428
		private static string v_43(Assembly v_48)
		{
			string text = v_48.FullName;
			int num = text.IndexOf(',');
			if (num >= 0)
			{
				text = text.Substring(0, num);
			}
			return text + '&';
		}

		// Token: 0x0600000F RID: 15 RVA: 0x0000227C File Offset: 0x0000047C
		private static Assembly v_41(object v_45, ResolveEventArgs v_13)
		{
			if (v_00.v_44 != null)
			{
				foreach (string a in v_00.v_44.GetManifestResourceNames())
				{
					if (a == v_13.Name)
					{
						return v_00.v_44;
					}
				}
				return null;
			}
			return v_00.v_44;
		}

		// Token: 0x04000004 RID: 4
		private static readonly Assembly v_44;
	}
}

using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace A
{
	// Token: 0x02000009 RID: 9
	internal class v_04
	{
		// Token: 0x0600001A RID: 26 RVA: 0x0000C1A4 File Offset: 0x0000A3A4
		static v_04()
		{
			if (v_04.v_49 == null)
			{
				//string text = "dXBkYXRlbm90aWZpY2F0aW9ubWdyJA==";
				//byte[] array = Convert.FromBase64String(text);
				//text = Encoding.UTF8.GetString(array, 0, array.Length);
				Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("updatenotificationmgr&");
				v_04.v_49 = v_46.v_47(97L, manifestResourceStream);
			}
		}

		// Token: 0x0600001C RID: 28 RVA: 0x0000C210 File Offset: 0x0000A410
		internal static string v_05(int v_50)
		{
			int num;
			if ((v_04.v_49[v_50] & 128) == 0)
			{
				num = (int)v_04.v_49[v_50];
				v_50++;
			}
			else if ((v_04.v_49[v_50] & 64) == 0)
			{
				num = ((int)v_04.v_49[v_50] & -129) << 8;
				num |= (int)v_04.v_49[v_50 + 1];
				v_50 += 2;
			}
			else
			{
				num = ((int)v_04.v_49[v_50] & -193) << 24;
				num |= (int)v_04.v_49[v_50 + 1] << 16;
				num |= (int)v_04.v_49[v_50 + 2] << 8;
				num |= (int)v_04.v_49[v_50 + 3];
				v_50 += 4;
			}
			if (num < 1)
			{
				return string.Empty;
			}
			string @string = Encoding.Unicode.GetString(v_04.v_49, v_50, num);
			return string.Intern(@string);
		}

		// Token: 0x0400001E RID: 30
		internal static readonly byte[] v_49;
	}
}

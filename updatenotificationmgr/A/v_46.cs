using System;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Security.Cryptography;

namespace A
{
	// Token: 0x0200000A RID: 10
	internal class v_46
	{
		// Token: 0x0600001D RID: 29 RVA: 0x0000C2F8 File Offset: 0x0000A4F8
		static v_46()
		{
			v_46.v_51 = int.MaxValue;
			v_46.v_52 = int.MinValue;
			v_46.v_53 = new MemoryStream(0);
			v_46.v_54 = new MemoryStream(0);
			v_46.v_55 = new object();
		}

		// Token: 0x0600001F RID: 31 RVA: 0x0000C35C File Offset: 0x0000A55C
		private static string v_43(Assembly v_48)
		{
			string text = v_48.FullName;
			int num = text.IndexOf(',');
			if (num >= 0)
			{
				text = text.Substring(0, num);
			}
			return text;
		}

		// Token: 0x06000020 RID: 32 RVA: 0x0000C3A0 File Offset: 0x0000A5A0
		private static byte[] v_56(Assembly v_48)
		{
			try
			{
				string fullName = v_48.FullName;
				int num = fullName.IndexOf("PublicKeyToken=");
				if (num < 0)
				{
					num = fullName.IndexOf("publickeytoken=");
				}
				if (num < 0)
				{
					return null;
				}
				num += 15;
				if (fullName[num] != 'n')
				{
					if (fullName[num] != 'N')
					{
						string s = fullName.Substring(num, 16);
						long value = long.Parse(s, NumberStyles.HexNumber);
						byte[] bytes = BitConverter.GetBytes(value);
						Array.Reverse(bytes);
						return bytes;
					}
				}
				return null;
			}
			catch
			{
			}
			return null;
		}

		// Token: 0x06000021 RID: 33 RVA: 0x0000C470 File Offset: 0x0000A670
		internal static byte[] v_57(Stream v_58)
		{
			byte[] result;
			lock (v_46.v_55)
			{
				result = v_46.v_59(97L, v_58);
			}
			return result;
		}

		// Token: 0x06000022 RID: 34 RVA: 0x0000C4B0 File Offset: 0x0000A6B0
		internal static byte[] v_47(long v_60, Stream v_58)
		{
			byte[] result;
			try
			{
				result = v_46.v_57(v_58);
			}
			catch
			{
				result = v_46.v_59(97L, v_58);
			}
			return result;
		}

		// Token: 0x06000023 RID: 35 RVA: 0x0000C4E8 File Offset: 0x0000A6E8
		internal static byte[] v_59(long v_60, object v_61)
		{
			Stream stream = v_61 as Stream;
			Stream stream2 = stream;
			MemoryStream memoryStream = null;
			for (int i = 1; i < 4; i++)
			{
				stream.ReadByte();
			}

			ushort num = (ushort)stream.ReadByte();
			num = ~num;
			if ((num & 2) != 0)
			{
				DESCryptoServiceProvider descryptoServiceProvider = new DESCryptoServiceProvider();
				byte[] array = new byte[8];
				stream.Read(array, 0, 8);
				descryptoServiceProvider.IV = array;
				byte[] array2 = new byte[8];
				stream.Read(array2, 0, 8);
				bool flag = true;
				foreach (byte b in array2)
				{
					if (b != 0)
					{

						flag = false;
						IL_C5:
						if (flag)
						{
							array2 = v_46.v_56(Assembly.GetExecutingAssembly());
						}
						descryptoServiceProvider.Key = array2;
						if (v_46.v_53 == null)
						{
							if (v_46.v_51 == 2147483647)
							{
								v_46.v_53.Capacity = (int)stream.Length;
							}
							else
							{
								v_46.v_53.Capacity = v_46.v_51;
							}
						}
						v_46.v_53.Position = 0L;
						ICryptoTransform cryptoTransform = descryptoServiceProvider.CreateDecryptor();
						int inputBlockSize = cryptoTransform.InputBlockSize;
						int outputBlockSize = cryptoTransform.OutputBlockSize;
						byte[] array4 = new byte[cryptoTransform.OutputBlockSize];
						byte[] array5 = new byte[cryptoTransform.InputBlockSize];
						int num2 = (int)stream.Position;
						while ((long)(num2 + inputBlockSize) < stream.Length)
						{
							stream.Read(array5, 0, inputBlockSize);
							int count = cryptoTransform.TransformBlock(array5, 0, inputBlockSize, array4, 0);
							v_46.v_53.Write(array4, 0, count);
							num2 += inputBlockSize;
						}
						stream.Read(array5, 0, (int)(stream.Length - (long)num2));
						byte[] array6 = cryptoTransform.TransformFinalBlock(array5, 0, (int)(stream.Length - (long)num2));
						v_46.v_53.Write(array6, 0, array6.Length);
						stream2 = v_46.v_53;
						stream2.Position = 0L;
						memoryStream = v_46.v_53;
						goto IL_236;
					}
				}

				goto IL_C5;
			}
			IL_236:
			if ((num & 8) != 0)
			{

				if (v_46.v_54 == null)
				{

					if (v_46.v_52 == -2147483648)
					{

						v_46.v_54.Capacity = (int)stream2.Length * 2;
					}
					else
					{
						v_46.v_54.Capacity = v_46.v_52;
					}
				}
				v_46.v_54.Position = 0L;
				DeflateStream deflateStream = new DeflateStream(stream2, CompressionMode.Decompress);
				int num3 = 1000;
				byte[] buffer = new byte[num3];
				int num4;
				do
				{
					num4 = deflateStream.Read(buffer, 0, num3);
					if (num4 > 0)
					{
						v_46.v_54.Write(buffer, 0, num4);
					}
				}
				while (num4 >= num3);

				memoryStream = v_46.v_54;
			}
			if (memoryStream != null)
			{

				return memoryStream.ToArray();
			}
			byte[] array7 = new byte[stream.Length - stream.Position];
			stream.Read(array7, 0, array7.Length);
			return array7;
		}

		// Token: 0x0400001F RID: 31
		private static readonly object v_55;

		// Token: 0x04000020 RID: 32
		private static readonly int v_51;

		// Token: 0x04000021 RID: 33
		private static readonly int v_52;

		// Token: 0x04000022 RID: 34
		private static readonly MemoryStream v_53 = null;

		// Token: 0x04000023 RID: 35
		private static readonly MemoryStream v_54 = null;

		// Token: 0x04000024 RID: 36
		private static readonly byte v_60;
	}
}

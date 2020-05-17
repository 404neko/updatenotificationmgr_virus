using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using A;

namespace WindowsFormsApp_FUD
{
	// Token: 0x02000007 RID: 7
	public partial class Form1 : Form
	{
		// Token: 0x06000016 RID: 22 RVA: 0x0000BCA0 File Offset: 0x00009EA0
		public Form1()
		{
			this.v_62();
		}

		// Token: 0x06000018 RID: 24 RVA: 0x0000BD04 File Offset: 0x00009F04
		private void v_62()
		{
			this.v_63 = new Button();
			this.v_64 = new Button();
			base.SuspendLayout();
			this.v_63.Location = new Point(475, 65);
			this.v_63.Name = v_04.v_05(884068);
			this.v_63.Size = new Size(75, 23);
			this.v_63.TabIndex = 0;
			this.v_63.Text = v_04.v_05(884068);
			this.v_63.UseVisualStyleBackColor = true;
			this.v_64.Location = new Point(464, 113);
			this.v_64.Name = v_04.v_05(884083);
			this.v_64.Size = new Size(75, 23);
			this.v_64.TabIndex = 1;
			this.v_64.Text = v_04.v_05(884083);
			this.v_64.UseVisualStyleBackColor = true;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(616, 192);
			base.Controls.Add(this.v_64);
			base.Controls.Add(this.v_63);
			base.Name = v_04.v_05(884098);
			this.Text = v_04.v_05(884098);
			base.ResumeLayout(false);
		}

		// Token: 0x04000006 RID: 6
		private Button v_63;

		// Token: 0x04000007 RID: 7
		private Button v_64;
	}
}

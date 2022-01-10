/*
 * Created by SharpDevelop.
 * User: vdgp_
 * Date: 08/03/2020
 * Time: 10:44 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Actividad3
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Label label1;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.button5 = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.button6 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.pictureBox1.Location = new System.Drawing.Point(12, 12);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(942, 607);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureBox1MouseClick);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(1006, 54);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(144, 36);
			this.button1.TabIndex = 1;
			this.button1.Text = "Imagen";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(1006, 112);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(144, 37);
			this.button2.TabIndex = 2;
			this.button2.Text = "Kruskal";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.Button2Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(1006, 340);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(143, 39);
			this.button3.TabIndex = 3;
			this.button3.Text = "Animar Prim";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.Button3Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(1006, 221);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(144, 40);
			this.button4.TabIndex = 4;
			this.button4.Text = "Comparar";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.Button4Click);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// listBox1
			// 
			this.listBox1.FormattingEnabled = true;
			this.listBox1.ItemHeight = 16;
			this.listBox1.Location = new System.Drawing.Point(1006, 424);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(136, 164);
			this.listBox1.TabIndex = 5;
			this.listBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListBox1MouseClick);
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(1006, 167);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(144, 34);
			this.button5.TabIndex = 6;
			this.button5.Text = "Prim";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.Button5Click);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(917, 639);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(100, 22);
			this.textBox1.TabIndex = 7;
			this.textBox1.TextChanged += new System.EventHandler(this.TextBox1TextChanged);
			this.textBox1.Leave += new System.EventHandler(this.TextBox1Leave);
			this.textBox1.Validated += new System.EventHandler(this.TextBox1Validated);
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(1006, 285);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(144, 36);
			this.button6.TabIndex = 8;
			this.button6.Text = "Animar Kruskal";
			this.button6.UseVisualStyleBackColor = true;
			this.button6.Click += new System.EventHandler(this.Button6Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(798, 639);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(113, 23);
			this.label1.TabIndex = 9;
			this.label1.Text = "40>Rango<200";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.ClientSize = new System.Drawing.Size(1242, 741);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button6);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.listBox1);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.pictureBox1);
			this.Name = "MainForm";
			this.Text = "Actividad3";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}

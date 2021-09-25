/*
 * Создано в SharpDevelop.
 * Пользователь: misha
 * Дата: 02.08.2017
 * Время: 17:01
 */
namespace ChangeColorCommand
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.ToolStrip toolStripMain;
		private System.Windows.Forms.ToolStripSplitButton btUndo;
		private System.Windows.Forms.ToolStripSplitButton btRedo;
		private System.Windows.Forms.ToolStripButton btColor;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ColorDialog colorDialogMain;
		private System.Windows.Forms.ToolStripButton btNewRect;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.toolStripMain = new System.Windows.Forms.ToolStrip();
			this.btNewRect = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.btUndo = new System.Windows.Forms.ToolStripSplitButton();
			this.btRedo = new System.Windows.Forms.ToolStripSplitButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.btColor = new System.Windows.Forms.ToolStripButton();
			this.colorDialogMain = new System.Windows.Forms.ColorDialog();
			this.toolStripMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStripMain
			// 
			this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.btNewRect,
			this.toolStripSeparator2,
			this.btUndo,
			this.btRedo,
			this.toolStripSeparator1,
			this.btColor});
			this.toolStripMain.Location = new System.Drawing.Point(0, 0);
			this.toolStripMain.Name = "toolStripMain";
			this.toolStripMain.Size = new System.Drawing.Size(439, 25);
			this.toolStripMain.TabIndex = 2;
			this.toolStripMain.Text = "toolStrip1";
			// 
			// btNewRect
			// 
			this.btNewRect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btNewRect.Image = ((System.Drawing.Image)(resources.GetObject("btNewRect.Image")));
			this.btNewRect.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btNewRect.Name = "btNewRect";
			this.btNewRect.Size = new System.Drawing.Size(23, 22);
			this.btNewRect.Text = "New rectangle";
			this.btNewRect.Click += new System.EventHandler(this.btNewRect_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// btUndo
			// 
			this.btUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btUndo.Image = ((System.Drawing.Image)(resources.GetObject("btUndo.Image")));
			this.btUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btUndo.Name = "btUndo";
			this.btUndo.Size = new System.Drawing.Size(52, 22);
			this.btUndo.Text = "Undo";
			this.btUndo.ButtonClick += new System.EventHandler(this.btUndo_ButtonClick);
			this.btUndo.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.btUndo_DropDownItemClicked);
			// 
			// btRedo
			// 
			this.btRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btRedo.Image = ((System.Drawing.Image)(resources.GetObject("btRedo.Image")));
			this.btRedo.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btRedo.Name = "btRedo";
			this.btRedo.Size = new System.Drawing.Size(50, 22);
			this.btRedo.Text = "Redo";
			this.btRedo.ButtonClick += new System.EventHandler(this.btRedo_ButtonClick);
			this.btRedo.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.btRedo_DropDownItemClicked);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// btColor
			// 
			this.btColor.Image = ((System.Drawing.Image)(resources.GetObject("btColor.Image")));
			this.btColor.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btColor.Name = "btColor";
			this.btColor.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.btColor.Size = new System.Drawing.Size(59, 22);
			this.btColor.Text = ":Color";
			this.btColor.Click += new System.EventHandler(this.btColor_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(439, 370);
			this.Controls.Add(this.toolStripMain);
			this.Name = "MainForm";
			this.Text = "ChangeColorCommand";
			this.toolStripMain.ResumeLayout(false);
			this.toolStripMain.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}

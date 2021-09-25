/*
 * Создано в SharpDevelop.
 * Пользователь: misha
 * Дата: 02.08.2017
 * Время: 17:01
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using ChangeColorCommand.DataBase;
using System.Linq;

namespace ChangeColorCommand
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		private Rects rects = new Rects();
		UndoRedoManager manager = new UndoRedoManager();
		
		public MainForm()
		{
			InitializeComponent();
			
			SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint
			         | ControlStyles.OptimizedDoubleBuffer, true);
			
			rects.Changed += rects_Changed;
			manager.StateChanged += manager_StateChanged;
			
			BuildInterface();
		}
		
		private void btColor_Click(object sender, EventArgs e)
		{
			if(colorDialogMain.ShowDialog() == DialogResult.OK)
			{
				var command = new ChangeColorCommand.DataBase.
					ChangeColorCommand(rects, colorDialogMain.Color);
				manager.Execute(command);
			}
		}
		
		private void BuildInterface()
		{
			btRedo.Enabled = manager.CanRedo;
			btUndo.Enabled = manager.CanUndo;
			
			btRedo.DropDownItems.Clear();
			btUndo.DropDownItems.Clear();
			
			btRedo.DropDownItems.AddRange(
				manager.RedoItems.Select(a => new ToolStripMenuItem(a)).ToArray());
			btUndo.DropDownItems.AddRange(
				manager.UndoItems.Select(a => new ToolStripMenuItem(a)).ToArray());
			
			btColor.Enabled = rects.LastRect != null;
		}
		
		#region Event handlers
		
		void btNewRect_Click(object sender, EventArgs e)
		{
			var command = new AddRectangleCommand(new Rect(), rects);
			manager.Execute(command);
		}

		void rects_Changed(object sender, EventArgs e)
		{
			Invalidate();
		}

		void manager_StateChanged(object sender, EventArgs e)
		{
			BuildInterface();
		}
		
		void btUndo_ButtonClick(object sender, EventArgs e)
		{
			manager.Undo();
		}
		
		void btRedo_ButtonClick(object sender, EventArgs e)
		{
			manager.Redo();
		}
		
		void btUndo_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
			int index = btUndo.DropDownItems.IndexOf(e.ClickedItem);
			manager.Undo(index + 1);
		}
		
		void btRedo_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
			int index = btRedo.DropDownItems.IndexOf(e.ClickedItem);
			manager.Redo(index + 1);
		}
		
		private Rect draggedRect;
		private Point newRectLocation;
		private Point startMouseLocation;
		
		protected override void OnPaint(PaintEventArgs e)
		{
			using(var brush = new SolidBrush(Color.Black))
				foreach (var element in rects)
			{
				brush.Color = element.Color;
				e.Graphics.FillRectangle(brush, 
				                         new Rectangle(element.Location, element.Size));
			}
			if(draggedRect != null)
				ControlPaint.DrawFocusRectangle
					(e.Graphics, new Rectangle(newRectLocation, draggedRect.Size));
		}
		
		protected override void OnMouseDown(MouseEventArgs e)
		{
			if(e.Button == MouseButtons.Left)
			{
				foreach(var rect in rects.Reverse())
				{
					if(rect.HitTest(e.Location))
					{
						draggedRect = rect;
						startMouseLocation = e.Location;
						return;
					}
					draggedRect = null;
				}
			}
		}
		
		protected override void OnMouseUp(MouseEventArgs e)
		{
			if(e.Button == MouseButtons.Left)
				if(draggedRect != null)
			{
				var command = new LocationChangeCommand(rects, draggedRect, newRectLocation);
				manager.Execute(command);
				
				draggedRect = null;
				Invalidate();
			}
		}
		
		protected override void OnMouseMove(MouseEventArgs e)
		{
			if(e.Button == MouseButtons.Left)
				if(draggedRect != null)
			{
				newRectLocation = new Point(draggedRect.Location.X + e.X - startMouseLocation.X,
				                            draggedRect.Location.Y + e.Y - startMouseLocation.Y);
				Invalidate();
			}
			
		}
		
		#endregion
	}
}

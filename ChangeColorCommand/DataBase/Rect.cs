/*
 * Создано в SharpDevelop.
 * Пользователь: misha
 * Дата: 02.08.2017
 * Время: 20:06
 */
using System;
using System.Drawing;

namespace ChangeColorCommand.DataBase
{
	/// <summary>
	/// Description of Rect.
	/// </summary>
	public class Rect
	{
		public Point Location {get; set;}
		public Size Size {get; set;}
		public Color Color {get; set;}
		
		public Rect()
		{
			Location = new Point(50, 50);
			Size = new Size(50, 50);
			Color = Color.Cyan;
		}
		
		public bool HitTest(Point p)
		{
			int x = p.X - Location.X;
			int y = p.Y - Location.Y;
			
			return x >= 0 && x < Size.Width && y >= 0 && y < Size.Height;
		}
	}
}

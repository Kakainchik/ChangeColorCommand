/*
 * Создано в SharpDevelop.
 * Пользователь: misha
 * Дата: 03.08.2017
 * Время: 16:08
 */
using System;
using System.Drawing;

namespace ChangeColorCommand.DataBase
{
	/// <summary>
	/// Description of LocationChangeCommand.
	/// </summary>
	public class LocationChangeCommand : ICommand
	{
		private Rect rect;
		private Rects rects;
		private Point prevLocation;
		private Point newLocation;
		
		public LocationChangeCommand(Rects rects, Rect rect, Point location)
		{
			this.rects = rects;
			this.rect = rect;
			this.newLocation = location;
		}

		#region ICommand implementation

		public void Execute()
		{
			prevLocation = rect.Location;
			rect.Location = newLocation;
			rects.OnChanged();
		}

		public void UnExecute()
		{
			rect.Location = prevLocation;
			rects.OnChanged();
		}

		public string Name { get { return "Move.";} }

		#endregion
	}
}

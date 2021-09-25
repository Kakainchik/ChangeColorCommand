/*
 * Создано в SharpDevelop.
 * Пользователь: misha
 * Дата: 03.08.2017
 * Время: 15:48
 */
using System;

namespace ChangeColorCommand.DataBase
{
	/// <summary>
	/// Description of AddRectangleCommand.
	/// </summary>
	public class AddRectangleCommand : ICommand
	{
		private Rects rects;
		private Rect rect;
		
		public AddRectangleCommand(Rect rect, Rects rects)
		{
			this.rects = rects;
			this.rect = rect;
		}

		#region ICommand implementation

		public void Execute()
		{
			rects.Add(rect);
			rects.OnChanged();
		}

		public void UnExecute()
		{
			rects.RemoveLastRect();
			rects.OnChanged();
		}

		public string Name { get {return "Add rectangle." ;}}

		#endregion
	}
}

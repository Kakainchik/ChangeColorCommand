/*
 * Создано в SharpDevelop.
 * Пользователь: misha
 * Дата: 03.08.2017
 * Время: 16:02
 */
using System;
using System.Drawing;

namespace ChangeColorCommand.DataBase
{
	/// <summary>
	/// Description of ChangeColorCommand.
	/// </summary>
	public class ChangeColorCommand : ICommand
	{
		Rects rects;
		Color prevColor;
		Color newColor;
		
		public ChangeColorCommand(Rects rects, Color color)
		{
			this.rects = rects;
			this.newColor = color;
		}

		#region ICommand implementation

		public void Execute()
		{
			prevColor = rects.LastRect.Color;
			rects.LastRect.Color = newColor;
			rects.OnChanged();
		}

		public void UnExecute()
		{
			rects.LastRect.Color = prevColor;
			rects.OnChanged();
		}

		public string Name { get { return "Change color.";} }

		#endregion
	}
}

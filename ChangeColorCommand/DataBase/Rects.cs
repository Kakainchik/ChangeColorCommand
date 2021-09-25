/*
 * Создано в SharpDevelop.
 * Пользователь: misha
 * Дата: 02.08.2017
 * Время: 20:04
 */
using System;
using System.Collections.Generic;
using System.Collections;

namespace ChangeColorCommand.DataBase
{
	/// <summary>
	/// Description of Class1.
	/// </summary>
	public class Rects : IEnumerable<Rect>
	{
		private List<Rect> Items = new List<Rect>();
		public event EventHandler Changed = delegate{ };

		#region IEnumerable implementation

		public IEnumerator<Rect> GetEnumerator()
		{
			return Items.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		#endregion
		
		public void Add(Rect rect)
		{
			Items.Add(rect);
		}
		
		public virtual void OnChanged()
		{
			Changed(this, EventArgs.Empty);
		}
		
		internal void RemoveLastRect()
		{
			if(Items.Count == 0) throw new ArgumentException();
			Items.RemoveAt(Items.Count - 1);
		}
		
		public Rect LastRect
		{
			get { return Items.Count == 0 ? null : Items[Items.Count - 1];}
		}
	}
}

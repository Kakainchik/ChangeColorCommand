/*
 * Создано в SharpDevelop.
 * Пользователь: misha
 * Дата: 02.08.2017
 * Время: 19:46
 */
using System;
using System.Linq;
using System.Collections.Generic;

namespace ChangeColorCommand.DataBase
{
	/// <summary>
	/// Description of UndoRedoManager.
	/// </summary>
	public class UndoRedoManager
	{
		private Stack<ICommand> UndoStack {get; set;}
		private Stack<ICommand> RedoStack {get; set;}
		
		public bool CanRedo {get { return RedoStack.Count > 0;} }
		public bool CanUndo {get { return UndoStack.Count > 0;} }
		
		public event EventHandler StateChanged = delegate { };
		
		public UndoRedoManager()
		{
			UndoStack = new Stack<ICommand>();
			RedoStack = new Stack<ICommand>();
		}
		
		public void Undo()
		{
			ICommand temp = UndoStack.Pop();
			temp.UnExecute();
			RedoStack.Push(temp);
			StateChanged(this, EventArgs.Empty);
		}
		
		public void Undo(int count)
		{
			for(int i = 0; i < count; i++) Undo();
		}
		
		public void Redo()
		{
			ICommand temp = RedoStack.Pop();
			temp.Execute();
			UndoStack.Push(temp);
			StateChanged(this, EventArgs.Empty);
		}
		
		public void Redo(int count)
		{
			for(int i = 0; i < count; i++) Redo();
		}
		
		public void Execute(ICommand command)
		{
			command.Execute();
			UndoStack.Push(command);
			RedoStack.Clear();
			StateChanged(this, EventArgs.Empty);
		}
		
		public IEnumerable<string> UndoItems 
		{
			get { return UndoStack.Select(c => c.Name); }
		}
		public IEnumerable<string> RedoItems
		{
			get { return RedoStack.Select(c => c.Name); }
		}
	}
	
	public interface ICommand
	{
		string Name {get;}
		
		void Execute();
		
		void UnExecute();
	}
}

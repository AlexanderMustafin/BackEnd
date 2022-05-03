using System.Collections.Generic;
using ScrumBoard.MaximumColumns;

namespace ScrumBoard.Body
{
    public class Board : BoardI
    {
        public void ChangeTaskPriority(string taskTitle, Task_priority newPriority)
        {
            foreach (ColumnI column in _columns)
            {
                TaskID task = column.FindTaskByTitle(taskTitle);
                if (task != null)
                {
                    task.Priority = newPriority;
                    break;
                }
            }
        }
        public string Title { get; }

        public Board(string title)
        {
            Title = title;
            _columns = new();
        }

        public void AddColumn(ColumnI column)
        {

            if (_columns.Count == MAX_COLUMNS)
            {
                throw new MaxColumns();
            }

            _columns.Add(column);
        }

        public IReadOnlyCollection<ColumnI> FindColumns()
        {
            return _columns;
        }

        public ColumnI FindColumnByTitle(string title)
        {
            return _columns.Find(column => column.Title == title);
        }

        public void AddTaskToColumn(TaskID task, string columnTitle = null)
        {
            if (columnTitle == null)
            {
                _columns[0].AddTask(task);
                return;
            }
            ColumnI column = FindColumnByTitle(columnTitle);
            column.AddTask(task);
        }
        public void MoveTask(string taskTitle)
        {
            TaskID task = null;
            int nextColumnIndex = 0;

            for (int i = 0; i < _columns.Count; ++i)
            {
                task = _columns[i].FindTaskByTitle(taskTitle);
                if (task != null)
                {
                    _columns[i].DeleteTaskByTitle(taskTitle);
                    nextColumnIndex = i + 1;
                    break;
                }
            }

            if (nextColumnIndex != 0 && task != null)
            {
                _columns[nextColumnIndex].AddTask(task);
            }
        }
        public void DeleteTask(string taskTitle)
        {
            foreach (ColumnI column in _columns)
            {
                column.DeleteTaskByTitle(taskTitle);
            }
        }

        public void RenameColumn(string columnTitle, string newTitle)
        {
            ColumnI column = FindColumnByTitle(columnTitle);
            column.Title = newTitle;
        }

        public void RenameTask(string taskTitle, string newTitle)
        {
            foreach (ColumnI column in _columns)
            {
                TaskID task = column.FindTaskByTitle(taskTitle);
                if (task != null)
                {
                    task.Title = newTitle;
                    break;
                }
            }
        }

        public void ChangeTaskDescription(string taskTitle, string newDescription)
        {
            foreach (ColumnI column in _columns)
            {
                TaskID task = column.FindTaskByTitle(taskTitle);
                if (task != null)
                {
                    task.Description = newDescription;
                    break;
                }
            }
        }

        private const int MAX_COLUMNS = 10;
        private List<ColumnI> _columns;
    }
}
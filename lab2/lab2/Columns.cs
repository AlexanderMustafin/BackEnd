using System.Collections.Generic;

namespace ScrumBoard.Body
{
    public class Column : ColumnI
    {
        public string Title { get; set; }

        public Column(string title)
        {
            Title = title;
            _tasks = new();
        }
        public TaskID FindTaskByTitle(string title)
        {
            return _tasks.Find(task => task.Title == title);
        }

        public void DeleteTaskByTitle(string title)
        {
            _tasks.RemoveAll(task => task.Title == title);
        }

        public void AddTask(TaskID task)
        {
            _tasks.Add(task);
        }

        public IReadOnlyCollection<TaskID> FindTasks()
        {
            return _tasks;
        }

        private List<TaskID> _tasks;
    }
}
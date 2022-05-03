using System.Collections.Generic;

namespace ScrumBoard.Body
{
    public interface ColumnI
    {
        public string Title { get; set; }

        public void AddTask(TaskID task);
        public void DeleteTaskByTitle(string title);
        public TaskID FindTaskByTitle(string title);
        public IReadOnlyCollection<TaskID> FindTasks();
    }
}
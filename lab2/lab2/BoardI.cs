using System.Collections.Generic;

namespace ScrumBoard.Body
{
    public interface BoardI
    {
        public void DeleteTask(string taskTitle);
        public void RenameTask(string taskTitle, string newTitle);
        public void ChangeTaskDescription(string taskTitle, string newDescription);
        public void AddTaskToColumn(TaskID task, string columnTitle = null);
        public void ChangeTaskPriority(string taskTitle, Task_priority newPriority);
        public void MoveTask(string taskTitle);
        public string Title { get; }
        public ColumnI FindColumnByTitle(string title);
        public void AddColumn(ColumnI column);
        public void RenameColumn(string columnTitle, string newTitle);
        public IReadOnlyCollection<ColumnI> FindColumns();
    }
}
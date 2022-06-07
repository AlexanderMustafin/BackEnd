using Xunit;
using ScrumBoard.Creator;
using ScrumBoard.Body;

namespace ScrumTest
{
    public class ColumnsTest
    {
        private string TrialTitle = "Column title";
        private string TrialTaskTitle = "Task title";
        private string TrialDescription = "Description";
        private Task_priority TrialPriority = Task_priority.MEDIUM;

        [Fact]
        public void Create_columnToBoard()
        {
            ColumnI column = TrialColumn();
       
            Assert.Equal(TrialTitle, column.Title);
            Assert.Empty(column.FindTasks());
        }

        [Fact]
        public void RemoveTaskFromColumn()
        {

            ColumnI column = TrialColumn();
            TaskID task = TrialTask();
            column.AddTask(task);

            column.DeleteTaskByTitle(task.Title);

            Assert.Empty(column.FindTasks());
        }

        [Fact]
        public void AddTaskToColumnInBoard()
        {

            ColumnI column = TrialColumn();
            TaskID task = TrialTask();

            column.AddTask(task);

            Assert.Collection(column.FindTasks(),
            columnTask => Assert.Equal(task, columnTask));
        }

        [Fact]
        public void ChangeColumnTitleInBoard()
        {

            ColumnI column = TrialColumn();
            string newTitle = "Updated";

            column.Title = newTitle;
   
            Assert.Equal(newTitle, column.Title);
        }

        private ColumnI TrialColumn()
        {
            return Creator.Create_column(TrialTitle); ;
        }

        private TaskID TrialTask()
        {
            return Creator.Create_task(TrialTaskTitle, TrialDescription, TrialPriority);
        }
    }
}
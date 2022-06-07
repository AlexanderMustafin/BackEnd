using Xunit;
using ScrumBoard.Body;
using ScrumBoard.Creator;
using ScrumBoard.MaximumColumns;

namespace ScrumTest
{
    public class BoardTest
    {
        private string TrialTitle = "Board Title";
        private string TrialColumnTitle = "Column Title";
        private string TrialTaskTitle = "Task Title";
        private string TrialDescription = "Description";
        private Task_priority TrialPriority = Task_priority.MEDIUM;
        private BoardI TrialBoard()
        {
            return Creator.Create_board(TrialTitle);
        }

        private ColumnI TrialColumn()
        {
            return Creator.Create_column(TrialColumnTitle);
        }

        private TaskID TrialTask()
        {
            return Creator.Create_task(TrialTaskTitle, TrialDescription, TrialPriority);
        }

        [Fact]
        public void IfCountOfColumnsMoreThan10()
        {

            BoardI board = TrialBoard();
            
            for (int n = 0; n < 10; n++)
            {
                board.AddColumn(Creator.Create_column(n.ToString()));
            }
            
            Assert.Throws<MaxColumns>(() => board.AddColumn(TrialColumn()));
        }

        [Fact]
        public void Create_board()
        {
            BoardI board = TrialBoard();
            
            Assert.Equal(TrialTitle, board.Title);
        }

        [Fact]
        public void FindColumnByTitleOnBoard()
        {
            
            BoardI board = TrialBoard();
            ColumnI column = TrialColumn();
            
            board.AddColumn(column);
            
            Assert.Equal(column, board.FindColumnByTitle(column.Title));
        }

        [Fact]
        public void DeleteTaskFromColumn()
        {
            
            BoardI board = TrialBoard();
            ColumnI column = TrialColumn();
            board.AddColumn(column);
            TaskID task = TrialTask();
            column.AddTask(task);
            
            board.DeleteTask(task.Title);
            
            Assert.Empty(column.FindTasks());
        }
        [Fact]
        public void MoveTasksOnBoard()
        {
            
            BoardI board = TrialBoard();
            ColumnI column_Number1 = Creator.Create_column("Number1");
            ColumnI column_Number2 = Creator.Create_column("Number2");
            board.AddColumn(column_Number1);
            board.AddColumn(column_Number2);
            TaskID task = TrialTask();
            board.AddTaskToColumn(task);
            
            board.MoveTask(task.Title);
            
            Assert.Empty(column_Number1.FindTasks());
            Assert.Collection(column_Number2.FindTasks(),
            column_Task => Assert.Equal(task, column_Task));
        }

    }
}
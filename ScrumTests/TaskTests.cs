using Xunit;
using ScrumBoard.Creator;
using ScrumBoard.Body;

namespace ScrumTest
{
    public class TaskTests
    {
        private TaskID TrialTask()
        {
            return Creator.Create_task(TrialTitle, TrialDescription, TrialPriority);
        }
        private string TrialTitle = "Title";
        private string TrialDescription = "Description";
        private Task_priority TrialPriority = Task_priority.MEDIUM;

        [Fact]
        public void Create_taskToColumn()
        {
            
            TaskID task = TrialTask();
            

            
            Assert.Equal(TrialTitle, task.Title);
            Assert.Equal(TrialDescription, task.Description);
            Assert.Equal(TrialPriority, task.Priority);
        }

        [Fact]
        public void Rename_task_title()
        {
            
            TaskID task = TrialTask();
            string newTitle = "Updated";
            
            task.Title = newTitle;
            
            Assert.Equal(newTitle, task.Title);
        }

        [Fact]
        public void ChangeTask_priority()
        {
            
            TaskID task = TrialTask();
            Task_priority newPriority = Task_priority.HARD;
            
            task.Priority = newPriority;
            
            Assert.Equal(newPriority, task.Priority);
        }

        [Fact]
        public void RenameTaskDescription()
        {
            TaskID task = TrialTask();
            string newDescription = "Updated";
            
            task.Description = newDescription;
            
            Assert.Equal(newDescription, task.Description);
        }
    }
}
using System;
using ScrumBoard.Body;

namespace ScrumBoard
{
    class Program
    {
        private static BoardI Activate_board()
        {
            BoardI board = Creator.Create_board("First ScrumBoard");

            ColumnI Need_To_Do_Column = Creator.Create_column("Need To Do");
            ColumnI In_Progress_Column = Creator.Create_column("In Progress");
            ColumnI Completed_Column = Creator.Create_column("Completed");
            board.AddColumn(Need_To_Do_Column);
            board.AddColumn(In_Progress_Column);
            board.AddColumn(Completed_Column);

            return board;
        }
        private static void Print_board(BoardI board)
        {
            foreach (ColumnI column in board.FindColumns())
            {
                Print_column(column);
            }
        }
        private static void Print_column(ColumnI column)
        {
            Console.WriteLine($"| {column.Title} |");
            Print_tasks(column);
        }
        private static string Priority_of_tasks(Task_priority priority)
        {
            switch (priority)
            {
                case Task_priority.HARD:
                    return "HARD";
                case Task_priority.MEDIUM:
                    return "MEDIUM";
                case Task_priority.EASY:
                    return "EASY";
                case Task_priority.NONE:
                    return "NONE";
                default:
                    return "";
            }
        }
        public static void Main(string[] args)
        {
            BoardI board = Activate_board();
            Console.WriteLine("Boards\n");
            Print_board(board);

            //Добавляем первое задание 
            TaskID Writeabstract = Creator.Create_task("Write abstract", "Complete earlier", Task_priority.HARD);
            board.AddTaskToColumn(Writeabstract, "Need To Do");
            Console.WriteLine("\nTask added in progress\n");
            Print_board(board);

            board.RenameTask("Complete earlier", "Write abstract");
            board.ChangeTaskDescription("Write abstract", "complete not soon");
            board.ChangeTaskPriority("Write abstract", Task_priority.EASY);
            Console.WriteLine("\n Task are updated \n");
            Print_board(board);

            //Добавляем второе задание
            TaskID throw_out_the_trash = Creator.Create_task("throw out the trash", "today", Task_priority.EASY);
            board.AddTaskToColumn(throw_out_the_trash);
            Console.WriteLine("\nSecond task added\n");
            Print_board(board);

            board.MoveTask("throw out the trash");
            Console.WriteLine("\nTask move\n");
            Print_board(board);

            board.MoveTask("Write abstract");
            board.MoveTask("throw out the trash");
            Console.WriteLine("\nAll completed\n");
            Print_board(board);

            board.DeleteTask("Write abstract");
            board.DeleteTask("throw out the trash");
            Console.WriteLine("\nAll removed\n");
            Print_board(board);
            Console.ReadLine();
        }
        private static void Print_tasks(ColumnI column)
        {
            foreach (TaskID task in column.FindTasks())
            {
                Print_task(task);
            }
        }
        private static void Print_task(TaskID task)
        {
            Console.WriteLine($"[{Priority_of_tasks(task.Priority)}] {task.Title}: {task.Description}");
        }
    }
}
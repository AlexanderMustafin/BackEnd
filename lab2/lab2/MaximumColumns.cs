namespace ScrumBoard.MaximumColumns
{
    public class MaxColumns : System.Exception
    {
        public MaxColumns()
            : base("board column count exceeded")
        {
        }
    }
}
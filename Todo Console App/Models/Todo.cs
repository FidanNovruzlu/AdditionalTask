namespace Todo_Console_App.Models
{
    internal class Todo
    {
        private static int _id;
        public int Id { get; }
        public string Title { get; set; }
        public bool IsCheck { get; set; }
        public Todo(string title,bool isCheck)
        {
            Id = ++_id;
            Title= title;
            IsCheck= isCheck;
        }
    }
}

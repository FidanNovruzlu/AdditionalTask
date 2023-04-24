namespace Todo_Console_App.Models
{
    internal class User
    {
        private static int _id;
        public int Id { get; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<Todo> Todos { get; set; }=new List<Todo>();

        public User(string name,string surname)
        {
            Id = ++_id;
            Name = name;
            Surname = surname;        
        }

    }
}

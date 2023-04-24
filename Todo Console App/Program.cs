using Todo_Console_App.Exceptions;
using Todo_Console_App.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        List<User> users = new List<User>();

        Console.WriteLine("=================================================================================================");

        Console.WriteLine("\t\t\t\t[1] User create.");
        Console.WriteLine("\t\t\t\t[2] User remove.");
        Console.WriteLine("\t\t\t\t[3] User get all.");
        Console.WriteLine("\t\t\t\t[4] Todo create.");
        Console.WriteLine("\t\t\t\t[5] Todo remove.");
        Console.WriteLine("\t\t\t\t[6] Todo get all by User.");
        Console.WriteLine("\t\t\t\t[7] Todo remove All.");
        Console.WriteLine("\t\t\t\t[8] Todo remove (IsCheck).");
        Console.WriteLine("\t\t\t\t[9] Excit.");
        Console.WriteLine("=================================================================================================");

        while(true) 
        {
            Console.Write("\nEnter your chosen => ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            int chosen =int.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.White;

            switch (chosen)
            {
                 case 1:
                    Console.WriteLine("\n\t--- User create ----");
                    Console.Write("Enter name: ");
                    string name=Console.ReadLine().Trim();
                    Console.Write("Enter surname: ");
                    string surname=Console.ReadLine().Trim();
                    User user=new User(name, surname);
                    users.Add(user);
                    Console.WriteLine($"User id {user.Id} has been created.");
                    Console.WriteLine("----------------------------------------");
                    break;
                case 2:
                    Console.WriteLine("\n\t--- User remove ----");
                    Console.Write("Enter user id: ");
                    int id=int.Parse(Console.ReadLine());
                    User removeUser= users.Find(x => x.Id == id);
                    if(removeUser != null)
                    {
                        users.Remove(removeUser);
                        Console.WriteLine($"User id {removeUser.Id} has been removed.");
                    }
                    else
                    {
                        throw new NotFoundException("User not found!");
                    }
                    Console.WriteLine("----------------------------------------");
                    break;
                case 3:
                    Console.WriteLine("\n\t--- User get all ----");
                    users.ForEach(x => Console.WriteLine($"{x.Id} {x.Name} {x.Surname} "));
                    Console.WriteLine("----------------------------------------");
                    break;
                case 4:
                    Console.WriteLine("\n\t--- Todo create ----");
                    Console.Write("Enter user id: ");
                    int userId=int.Parse(Console.ReadLine());
                    User userFind= users.Find(x => x.Id==userId);
                    if(userFind != null)
                    {
                        Console.Write("Enter todo title: ");
                        string title=Console.ReadLine();
                        Console.Write("Todo checked?(false/true) ");
                        bool isCheck=Convert.ToBoolean(Console.ReadLine());
                        Todo todo=new Todo(title, isCheck);
                        userFind.Todos.Add(todo);
                    }
                    else
                    {
                        throw new NotFoundException("User not found!");
                    }
                    Console.WriteLine("----------------------------------------");
                    break;
                case 5:
                    Console.WriteLine("\n\t--- Todo remove ----");
                    Console.Write("Enter user id: ");
                    int userRemoveId = int.Parse(Console.ReadLine());
                    User userRemove = users.Find(x => x.Id == userRemoveId);
                    if (userRemove != null)
                    {
                        Console.Write("Enter todo id: ");
                        int todoRemoveId = int.Parse(Console.ReadLine());
                        Todo todoRemove = userRemove.Todos.Find(x => x.Id == todoRemoveId);
                        if (todoRemove != null)
                        {
                            userRemove.Todos.Remove(todoRemove);
                            Console.WriteLine("Todo removed successfully!");
                        }
                        else
                        {
                            throw new NotFoundException("Todo not found!");
                        }
                    }
                    else
                    {
                        throw new NotFoundException("User not found!");
                    }
                    Console.WriteLine("----------------------------------------");
                    break;
                case 6:
                    Console.WriteLine("\n\t--- Todo  get all by User ----");
                    Console.Write("Enter user id: ");
                    userId = int.Parse(Console.ReadLine());
                    User userTodoFind = users.Find(x => x.Id == userId);
                    if(userTodoFind != null)
                    {
                        userTodoFind.Todos.ForEach(x => Console.WriteLine($"{x.Id} {x.Title} {x.IsCheck}"));
                    }
                    else
                    {
                        throw new NotFoundException("User not found!");
                    }
                    Console.WriteLine("----------------------------------------");
                    break;
                case 7:
                    Console.WriteLine("\n\t--- Todo  remove all ----");
                    Console.Write("Enter user id: ");
                    userId = int.Parse(Console.ReadLine());
                    User TodoRemove = users.Find(x => x.Id == userId);
                    if (TodoRemove != null)
                    {
                        TodoRemove.Todos.Clear();
                        Console.WriteLine($"Todo id {TodoRemove.Id} has been removed.");
                    }
                    else
                    {
                        throw new NotFoundException("User not found!");
                    }
                    Console.WriteLine("----------------------------------------");
                    break;
                case 8:
                    Console.WriteLine("\n\t--- Todo remove(isCheck) ----");
                    Console.Write("Enter user id: ");
                    userId = int.Parse(Console.ReadLine());
                    User TodoIsCheck = users.Find(x => x.Id == userId);
                    if(TodoIsCheck != null)
                    {
                        List<Todo> todoList= TodoIsCheck.Todos.FindAll(x=> x.IsCheck == false);
                        if(todoList.Count> 0)
                        {
                            todoList.RemoveAll(x=> x.IsCheck == false);
                            Console.WriteLine($"Todo id {TodoIsCheck.Id} has been removed.");
                        }
                        else
                        {
                            Console.WriteLine("Not found isCheck=false");
                        }
                    }
                    else
                    {
                        throw new NotFoundException("User not found!");
                    }
                    Console.WriteLine("----------------------------------------");
                    break;
                case 9:
                    break;
                default:
                    Console.WriteLine("Invalid chosen!!!");
                    break;
            }
        }
    }
}
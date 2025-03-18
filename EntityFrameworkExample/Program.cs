using EntityFrameworkExample.Data;
using EntityFrameworkExample.Models;

namespace EntityFrameworkExample
{
    public class Program
    {
        public static void Main()
        {
            using var context = new ApplicationDbContext();

            User test = new User { Name = "Test", Surname = "Test" };

            SQLInstructions.InsertUser(context, test);
            SQLInstructions.SelectAllUsers(context);
            SQLInstructions.DeleteUser(context, 1);
            SQLInstructions.SelectAllUsers(context);
            SQLInstructions.DeleteAllUsers(context);
            SQLInstructions.SelectAllUsers(context);
        }
    }
}
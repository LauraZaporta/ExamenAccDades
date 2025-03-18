using EntityFrameworkExample.Data;

namespace EntityFrameworkExample.Models
{
    public class SQLInstructions
    {
        public static void InsertUser(ApplicationDbContext context, User test)
        {
            context.Users.Add(test);
            context.SaveChanges();
        }
        public static void DeleteUser(ApplicationDbContext context, int id)
        {
            var userToDelete = context.Users.Find(id); //Sempre fa el find per clau primària
            if (userToDelete != null)
            {
                context.Users.Remove(userToDelete);
                context.SaveChanges();
            }
        }
        public static void DeleteAllUsers(ApplicationDbContext context)
        {
            foreach (var user in context.Users)
            {
                context.Users.Remove(user);
            }
            context.SaveChanges();
        }
        public static void UpdateUserName(ApplicationDbContext context, int id, string newName)
        {
            var userToUpdate = context.Users.Find(id);
            if (userToUpdate != null)
            {
                userToUpdate.Name = newName;
                context.SaveChanges();
            }
        }
        public static void UpdateUserSurname(ApplicationDbContext context, int id, string newSurname)
        {
            var userToUpdate = context.Users.Find(id);
            if (userToUpdate != null)
            {
                userToUpdate.Surname = newSurname;
                context.SaveChanges();
            }
        }
        public static void SelectUser(ApplicationDbContext context, int id)
        {
            var userSelected = context.Users.Find(id);
            if (userSelected != null)
            {
                Console.WriteLine($"ID: {userSelected.Id}\nName: {userSelected.Name}\nSurname: {userSelected.Surname}");
            } 
            else
            {
                Console.WriteLine($"No user found with {id} id");
            }
        }
        public static void SelectAllUsers(ApplicationDbContext context)
        {
            List<User> users = context.Users.ToList();
            foreach(User userSelected in users)
            {
                Console.WriteLine($"ID: {userSelected.Id}\nName: {userSelected.Name}\nSurname: {userSelected.Surname}");
            }
        }
    }
}

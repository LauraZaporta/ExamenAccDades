using ORMDAOExample.Persistence.DAO;
using ORMDAOExample.Persistence.Mapping;
using ORMDAOExample.Persistence.Utils;

namespace EntityFrameworkExample
{
    public class Program
    {
        public static void Main()
        {
            // Crear una instància del DAO
            // Es fa servir qualsevol objecte que compleixi la intefície IContactDAO, així no es limita a una implementació única
            IContactDAO contactDAO = new ContactDAO(SQLServerUtils.OpenConnection());
        }
    }
}
using System.Data.SqlTypes;
using Microsoft.Data.SqlClient;
using ORMDAOExample.DTOs;
using ORMDAOExample.Persistence.DAO;

namespace ORMDAOExample.Persistence.Mapping
{
    public class ContactDAO : IContactDAO
    {
        private readonly string _connectionString;

        public ContactDAO(string connectionsString)
        {
            _connectionString = connectionsString;
        }

        public void AddContact(ContactDTO contact)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString)) // Agafa la info del json
            {
                string query = "INSERT INTO Contact (Name, Email) VALUES (@Name, @Email)"; // Determina la query amb Prepared statement
                using (SqlCommand command = new SqlCommand(query, conn)) // Estableix la relació entre la query i la connexió
                {
                    // Afegeix els paràmetres
                    command.Parameters.AddWithValue("@Name", contact.Name);
                    command.Parameters.AddWithValue("@Surname", contact.Email);
                    conn.Open(); // Obre la connexió
                    command.ExecuteNonQuery(); // Executa l'insert
                }
            }
        }

        public void AddContacts(List<ContactDTO> contacts)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        foreach (var contact in contacts)
                        {
                            string query = "INSERT INTO Contact (Name, Surname) VALUES (@Name, @Email)";
                            using (SqlCommand command = new SqlCommand(query, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@Name", contact.Name);
                                command.Parameters.AddWithValue("@Email", contact.Email);
                                command.ExecuteNonQuery();
                            }
                        }
                        transaction.Commit();
                        Console.WriteLine("Tots els contactes s'han afegit correctament.");
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine($"Error en inserir contactes: {ex.Message}");
                    }
                }
            }
        }

        public void DeleteContact(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM Contact WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<ContactDTO> SelectAllContacts()
        {
            List<ContactDTO> contacts = new List<ContactDTO>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT Id, Name, Surname FROM Contact";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ContactDTO contact = new ContactDTO
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Email = reader.GetString(2)
                            };
                            contacts.Add(contact);
                        }
                    }
                }
            }
            return contacts;
        }

        public ContactDTO SelectContactByID(int id)
        {
            ContactDTO contact = null;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT Id, Name, Surname FROM Contact WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            contact = new ContactDTO
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Email = reader.GetString(2)
                            };
                        }
                    }
                }
            }
            return contact;
        }

        public void UpdateContact(ContactDTO contact)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "UPDATE Contact SET Name = @Name, Surname = @Email WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", contact.Name);
                    command.Parameters.AddWithValue("@Email", contact.Email);
                    command.Parameters.AddWithValue("@Id", contact.Id);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}

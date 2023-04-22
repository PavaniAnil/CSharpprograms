// Create table in mysql database named Employee
// CRUD operations in C#
// Compile: csc /r:MySql.Data.dll SampleCRUDCSharp.cs
// Run with filename i.e., SampleCRUDSharp 


using System;
using MySql.Data.MySqlClient;

    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "server=138.68.140.83;user=Pavani;password=Pavani@123;database=dbPavaniBoda";
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand command = new MySqlCommand();
            connection.Open();
            while (true)
            {
                Console.WriteLine("Select an operation:");
                Console.WriteLine("1. Create");
                Console.WriteLine("2. Read");
                Console.WriteLine("3. Update");
                Console.WriteLine("4. Delete");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1: //Create 
                        Console.Write("Enter ID: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Enter name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter email: ");
                        string email = Console.ReadLine();
                        command.CommandText = "INSERT INTO Employee (id, name, email) VALUES (@id, @name, @email)";
                        command.Parameters.AddWithValue("@id", id);
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@email", email);
                        command.Connection = connection;
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine(rowsAffected + " row(s) inserted.");
                        break;
                    case 2: //Read
                        command.CommandText = "SELECT * FROM Employee";
                        command.Connection = connection;
                        MySqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Console.WriteLine("ID: {0}, Name: {1}, Email: {2}", reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
                        }
                        reader.Close();
                        break;
                    case 3: //Update
                        Console.Write("Enter ID to update: ");
                        int idToUpdate = int.Parse(Console.ReadLine());
                        Console.Write("Enter new name: ");
                        string newName = Console.ReadLine();
                        Console.Write("Enter new email: ");
                        string newEmail = Console.ReadLine();
                        command.CommandText = "UPDATE Employee SET name = @newName, email = @newEmail WHERE id = @id";
                        command.Parameters.AddWithValue("@id", idToUpdate);
                        command.Parameters.AddWithValue("@newName", newName);
                        command.Parameters.AddWithValue("@newEmail", newEmail);
                        command.Connection = connection;
                        rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine(rowsAffected + " row(s) updated.");
                        break;
                    case 4: //Delete
                        Console.Write("Enter ID to delete: ");
                        int idToDelete = int.Parse(Console.ReadLine());
                        command.CommandText = "DELETE FROM Employee WHERE id = @id";
                        command.Parameters.AddWithValue("@id", idToDelete);
                        command.Connection = connection;
                        rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine(rowsAffected + " row(s) deleted.");
                        break;
                    case 5: //Exit
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
            connection.Close();
        }
    }


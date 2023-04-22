// Create table in mysql database named BankAccount
// CRUD operations in C#.
// Compile: csc /r:MySql.Data.dll CRUDCSharp.cs
// Run with CRUDSharp

using System;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

class dbCRUD
{
    String ConnectionString = null;
    MySqlConnection Connection;
    public dbCRUD()
    {

        ConnectionString = "server = 138.68.140.83; database = dbPavaniBoda; uid = Pavani; pwd = Pavani@123";
        Connection = new MySqlConnection(ConnectionString);
        try
        {
            Connection.Open();
            Console.WriteLine("Connection Open!");
        }
        catch (Exception)
        {
            Console.WriteLine("Can not open connection !");
        }
    }

    public void CreateAccount()
    {
        Console.WriteLine("Enter AccountId: ");
        string Accountid = Console.ReadLine();
        Console.WriteLine("Enter Account holder name: ");
        string Accountholdername = Console.ReadLine();
        Console.WriteLine("Enter balance: ");
        string Balance = Console.ReadLine();
        string query = String.Format("insert into BankAccount values('{0}', '{1}',{2});", Accountid, Accountholdername, Balance);
        try
        {
            MySqlCommand cmd = new MySqlCommand(query, Connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            dataReader.Close();

        }
        catch (Exception)
        {
        }
    }

    public void ShowAccounts()
    {
        try
        {
            string query = "select * from BankAccount;";
            MySqlCommand cmd = new MySqlCommand(query, Connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                Console.Write(dataReader["AccountId"] + " ");
                Console.Write(dataReader["AccountHolderName"] + " ");
                Console.Write(dataReader["Balance"] + "\n");
            }
            dataReader.Close();
        }
        catch (Exception)
        {
        }

    }

    public void SearchAccount()
    {
        Console.WriteLine("Enter AccountId to search: ");
        string id = Console.ReadLine();
        string query = String.Format("select * from BankAccount where AccountId = '{0}'", id);
        try
        {
            MySqlCommand cmd = new MySqlCommand(query, Connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                Console.Write(dataReader["AccountId"] + " ");
                Console.Write(dataReader["AccountHolderName"] + " ");
                Console.Write(dataReader["Balance"] + "\n");
            }
            dataReader.Close();
        }
        catch (Exception)
        {
        }
    }

    public void DeleteAccount()
    {
        Console.WriteLine("Enter AccountId to delete: ");
        string id = Console.ReadLine();
        string query = String.Format("delete from BankAccount where AccountId = '{0}'", id);
        try
        {
            MySqlCommand cmd = new MySqlCommand(query, Connection);
            cmd.ExecuteNonQuery();
        }
        catch (Exception)
        {

        }

    }


    public void Exit()
    {
        try
        {
            Connection.Close();
            Environment.Exit(0);
        }
        catch (Exception)
        {
        }
    }
    public static void Main(String[] args)
    {
        dbCRUD oCRUD = new dbCRUD();
        Console.WriteLine("1. Create account\n2. Show account\n3. Search account\n4. Delete account\n5. Exit");
        Console.WriteLine("Enter your choice: ");
        int choice = Convert.ToInt32(Console.ReadLine());
        switch (choice)
        {
            case 1: 
                oCRUD.CreateAccount();
                break;
            case 2:
                oCRUD.ShowAccounts();
                break;
            case 3:
                oCRUD.SearchAccount();
                break;
            case 4:
                oCRUD.DeleteAccount();
                break;
            case 5:
                oCRUD.Exit();
                break;

        }
    }
}
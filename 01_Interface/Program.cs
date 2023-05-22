// Page 39 - Program to an Interface, not an Implementation
// For undestand of Interfaces, I'll use a common case of my actual work, PL/SQL and T-SQL variation

using System.Globalization;
using Oracle.ManagedDataAccess.Client;
using Microsoft.Data.SqlClient;

IDatabase db;

int choice = 0;
while (!Enumerable.Range(1, 2).Contains(choice))
{
    Console.Clear();

    Console.WriteLine("Choose the database:");
    Console.WriteLine("1. Oracle");
    Console.WriteLine("2. SQL Server");

    int.TryParse(Console.ReadLine(), NumberStyles.Integer, default, out choice);
}

switch (choice)
{
    case 1:
        db = new OracleDatabase();
        break;
    default:
        db = new SqlServerDatabase();
        break;
}

if (db.HasConnection()) Console.WriteLine("\nHas connection");
else Console.WriteLine("\nHasn't connection");

interface IDatabase
{
    public string ConnectionString { get; }

    bool HasConnection();
}

class OracleDatabase : IDatabase
{
    public string ConnectionString => "Data Source=interfaceTest;User Id=interfaceTest;Password=interfaceTest;";

    public bool HasConnection()
    {
        OracleConnection oc = new();

        oc.ConnectionString = ConnectionString;

        try
        {
            oc.Open();
            oc.Close();

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}

class SqlServerDatabase : IDatabase
{
    public string ConnectionString => "Server=interfaceTest;Database=interfaceTest;User Id=interfaceTest;Password=interfaceTest";

    public bool HasConnection()
    {
        SqlConnection sc = new();

        sc.ConnectionString = ConnectionString;

        try
        {
            sc.Open();
            sc.Close();

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
using System.Data.SQLite;
using SortingAlgorithms;
using System.Linq;

string filePath = "Employee.db";
string connectionString = $"Data Source={filePath};Version=3;";

using (var connection = new SQLiteConnection(connectionString))
{
    connection.Open();

    string query = "SELECT * FROM Employees;";
    List<Employee> employees = new List<Employee>();

    using (var command = new SQLiteCommand(query, connection))
    using (var reader = command.ExecuteReader())
    {
        while (reader.Read())
        {
            employees.Add(new Employee(Convert.ToInt32(reader["Id"]),
                                        reader["FirstName"].ToString(),
                                        reader["LastName"].ToString(),
                                        Convert.ToDecimal(reader["Salary"]),
                                        reader["Title"].ToString()));
        }
    }

    Console.WriteLine("2. Insertion Sort\n");
    Console.WriteLine("Enter the number corresponding to the sorting algorithm:");
    int algorithmChoice = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("Enter the field to sort by (1. Id, 2. First Name, 3. Salary):");
    int fieldChoice = Convert.ToInt32(Console.ReadLine());

    switch (fieldChoice)
    {
        case 1: // Id
            BubbleSort.Sort(employees.Select(e => e.Id).ToArray());
            break;

        case 2: // First Name
            InsertionSort.Sort(employees.Select(e => e.FirstName).ToArray());
            break;

        case 3: // Salary
            InsertionSort.Sort(employees.Select(e => e.Salary).ToArray());
            break;

        default:
            Console.WriteLine("Invalid field choice. Exiting the program.");
            return;
    }

    connection.Close();
}

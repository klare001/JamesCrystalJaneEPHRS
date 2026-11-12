using System;
using System.Collections.Generic;
using System.Linq;

public class Employee
{
    public int Id { get; set; }                  
    public string FirstName { get; set; }        
    public string LastName { get; set; }         
    public string Department { get; set; }       
    public string JobTitle { get; set; }         
    public decimal MonthlySalary { get; set; }   
    public double TaxRate { get; set; }          
    public DateTime HireDate { get; set; }       
    public bool IsActive { get; set; }           
    public string Email { get; set; }            
}

class Program
{
<<<<<<< HEAD
   
=======
>>>>>>> JamesCrystalJane
    static List<Employee> employees = new List<Employee>();
    static int nextId = 1001; 

    static void Main(string[] args)
    {
        bool running = true;
        while (running)
        {
            Console.Clear();
<<<<<<< HEAD
            Console.WriteLine("=== EMPLOYEE PAYROLL & HR MANAGEMENT  ===" );
=======
            Console.WriteLine("=== EMPLOYEE PAYROLL & HR MANAGEMENT PORTAL ===" );
>>>>>>> JamesCrystalJane
            Console.WriteLine("1. Create (Add Employee)");
            Console.WriteLine("2. Read (View All Employees)");
            Console.WriteLine("3. Search / Filter Employees");
            Console.WriteLine("4. Update Employee");
            Console.WriteLine("5. Delete Employee");
            Console.WriteLine("6. Exit");
            Console.Write("\nSelect an option: ");
            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    CreateEmployee();
                    break;
                case "2":
                    ReadEmployees();
                    break;
                case "3":
                    SearchEmployees();
                    break;
                case "4":
                    UpdateEmployee();
                    break;
                case "5":
                    DeleteEmployee();
                    break;
                case "6":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

            if (running) 
            { 
                Console.WriteLine("\nPress Enter to continue..."); 
                Console.ReadLine(); 
            }
        }
    }

    static void CreateEmployee()
    {
        Console.WriteLine("--- Add New Employee ---");
        
        Console.Write("Enter First Name: ");
        string firstName = Console.ReadLine();

        Console.Write("Enter Last Name: ");
        string lastName = Console.ReadLine();

        Console.Write("Enter Department (e.g., IT, HR, Sales): ");
        string department = Console.ReadLine();

        Console.Write("Enter Job Title: ");
        string jobTitle = Console.ReadLine();

        Console.Write("Enter Monthly Salary: ");
        decimal.TryParse(Console.ReadLine(), out decimal salary);

        Console.Write("Enter Tax Rate (e.g., 0.12 for 12%): ");
        double.TryParse(Console.ReadLine(), out double taxRate);

        Console.Write("Enter Hire Date (YYYY-MM-DD): ");
        if (!DateTime.TryParse(Console.ReadLine(), out DateTime hireDate))
        {
            hireDate = DateTime.Now;
        }

        Console.Write("Is Active? (true/false): ");
        bool.TryParse(Console.ReadLine(), out bool isActive);

        Console.Write("Enter Company Email: ");
        string email = Console.ReadLine();

        Employee newEmp = new Employee
        {
            Id = nextId++,
            FirstName = firstName,
            LastName = lastName,
            Department = department,
            JobTitle = jobTitle,
            MonthlySalary = salary,
            TaxRate = taxRate,
            HireDate = hireDate,
            IsActive = isActive,
            Email = email
        };

        employees.Add(newEmp);
        Console.WriteLine($"\nEmployee added successfully with ID: {newEmp.Id}");
    }

    static void ReadEmployees()
    {
        Console.WriteLine("--- Employee Directory ---");
        if (employees.Count == 0)
        {
            Console.WriteLine("No employees found.");
            return;
        }

        foreach (var emp in employees)
        {
            string status = emp.IsActive ? "Active" : "On Leave/Inactive";
            Console.WriteLine($"ID: {emp.Id} | Name: {emp.FirstName} {emp.LastName} | Dept: {emp.Department} | Title: {emp.JobTitle} | Salary: {emp.MonthlySalary:C} | Tax: {emp.TaxRate:P0} | Hired: {emp.HireDate.ToShortDateString()} | Status: {status} | Email: {emp.Email}");
        }
    }

    static void SearchEmployees()
    {
        Console.WriteLine("--- Search / Filter Employees ---");
        Console.Write("Enter keyword (Name, Department, or Job Title): ");
        string keyword = Console.ReadLine()?.Trim().ToLower();

        var results = employees.Where(e => 
            e.FirstName.ToLower().Contains(keyword) ||
            e.LastName.ToLower().Contains(keyword) ||
            e.Department.ToLower().Contains(keyword) ||
            e.JobTitle.ToLower().Contains(keyword)
        ).ToList();

        if (results.Count == 0)
        {
            Console.WriteLine("\nNo matching employees found.");
            return;
        }

        Console.WriteLine($"\nFound {results.Count} result(s):");
        foreach (var emp in results)
        {
            Console.WriteLine($"ID: {emp.Id} | {emp.FirstName} {emp.LastName} - {emp.JobTitle} ({emp.Department})");
        }
    }

    static void UpdateEmployee()
    {
        ReadEmployees();
        if (employees.Count == 0) return;

        Console.Write("\nEnter the ID of the employee to update: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            Employee emp = employees.FirstOrDefault(e => e.Id == id);
            if (emp != null)
            {
                Console.Write($"Enter new First Name (current: {emp.FirstName}): ");
                string val = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(val)) emp.FirstName = val;

                Console.Write($"Enter new Last Name (current: {emp.LastName}): ");
                val = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(val)) emp.LastName = val;

                Console.Write($"Enter new Department (current: {emp.Department}): ");
                val = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(val)) emp.Department = val;

                Console.Write($"Enter new Job Title (current: {emp.JobTitle}): ");
                val = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(val)) emp.JobTitle = val;

                Console.Write($"Enter new Monthly Salary (current: {emp.MonthlySalary}): ");
                string salaryInput = Console.ReadLine();
                if (decimal.TryParse(salaryInput, out decimal newSalary)) emp.MonthlySalary = newSalary;

                Console.WriteLine("\nEmployee updated successfully!");
            }
            else
            {
                Console.WriteLine("\nEmployee not found.");
            }
        }
        else
        {
            Console.WriteLine("\nInvalid ID format.");
        }
    }

    static void DeleteEmployee()
    {
        ReadEmployees();
        if (employees.Count == 0) return;

        Console.Write("\nEnter the ID of the employee to delete: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            int removedCount = employees.RemoveAll(e => e.Id == id);
            if (removedCount > 0)
            {
                Console.WriteLine("\nEmployee deleted successfully.");
            }
            else
            {
                Console.WriteLine("\nEmployee ID not found.");
            }
        }
        else
        {
            Console.WriteLine("\nInvalid ID format.");
        }
    }
}
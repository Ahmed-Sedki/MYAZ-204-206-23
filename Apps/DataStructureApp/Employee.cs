class Employee
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public decimal Salary { get; set; }
    public string Title { get; set; }

    public Employee(int id, string firstName, string lastName, decimal salary, string title)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Salary = salary;
        Title = title;
    }

    public override string ToString() => $"{Id,4} {FirstName,15} {LastName,15} {Salary,10}";
}

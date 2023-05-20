// Page 42

var company = new Company();
Console.WriteLine("-> company");
company.CreateSoftware();

var companyGameDev = new CompanyGameDev();
Console.WriteLine("-> companyGameDev");
companyGameDev.CreateSoftware();

var companyOutsourcing = new CompanyOutsourcing();
Console.WriteLine("-> companyOutsourcing");
companyOutsourcing.CreateSoftware();

class Company
{
    public void CreateSoftware()
    {
        foreach (var e in GetEmployees()) e.DoWork();
    }

    public virtual IEmployee[] GetEmployees()
    {
        return new IEmployee[] { new Designer(), new Programmer(), new Tester() };
    }
}

class CompanyGameDev : Company
{
    public override IEmployee[] GetEmployees()
    {
        return new IEmployee[] { new Designer(), new Artist() };
    }
}

class CompanyOutsourcing : Company
{
    public override IEmployee[] GetEmployees()
    {
        return new IEmployee[] { new Programmer(), new Tester() };
    }
}

interface IEmployee
{
    void DoWork();
}

class Designer : IEmployee
{
    public void DoWork()
    {
        Console.WriteLine("Designer editing stuff...");
    }
}


class Artist : IEmployee
{
    public void DoWork()
    {
        Console.WriteLine("Artist drawing stuff...");
    }
}

class Programmer : IEmployee
{
    public void DoWork()
    {
        Console.WriteLine("Programmer coding...");
    }
}

class Tester : IEmployee
{
    public void DoWork()
    {
        Console.WriteLine("Testing programmer bugs...");
    }
}
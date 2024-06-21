// See https://aka.ms/new-console-template for more information

using ConsoleApp2;
using ConsoleApp2.Entities;

Console.WriteLine("Hello, World!");
CreateCompany();
GetCompany(1);
DeleteCompany(1);
UpdateCompany(1, new Company(){Id = 3, Name = "Tri"});

static void GetCompany(int id)
{
    using (var dbContext = new DataContext())
    {
        Console.WriteLine((dbContext.Companies.FirstOrDefault(x => x.Id == id)).Name);
    }
}

static void CreateCompany()
{
    using (var dbContext = new DataContext())
    {
        var company = new Company()
        {
            Id = 1,
            Name = "Raz"
        };

        dbContext.Companies.Add(company);
        dbContext.SaveChanges();
        Console.WriteLine(company.Id);
    }
}

static void DeleteCompany(int id)
{
    using (var dbContext = new DataContext())
    {
        var company = dbContext.Companies.FirstOrDefault(x => x.Id == id);
        
        dbContext.Companies.Remove(company);
        dbContext.SaveChanges();
        Console.WriteLine("Deleted");
    }
}

static void UpdateCompany(int oldCompanyId, Company newCompany)
{
    using (var dbContext = new DataContext())
    {
        var company = dbContext.Companies.FirstOrDefault(x => x.Id == oldCompanyId);

        if (company != null)
        {
            company.Name = newCompany.Name;
        }

        dbContext.SaveChanges();
        Console.WriteLine("Updated");
    }
}


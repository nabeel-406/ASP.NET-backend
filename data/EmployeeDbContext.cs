using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoEmp.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoEmp.data;

public class EmployeeDbContext : DbContext
{
    public EmployeeDbContext(DbContextOptions options) : base(options)
    {
    }

    // public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options):base(options){}

    public DbSet<Employee> Emp {get;set;}   

 
}
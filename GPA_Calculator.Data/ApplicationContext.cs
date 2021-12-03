using System;
using System.Collections.Generic;
using System.Text;
using GPA_Calculator.Models;
using GPA_Calculator.Models.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace GPA_Calculator.Data
{
    public class ApplicationContext : DbContext
    {


        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }


        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
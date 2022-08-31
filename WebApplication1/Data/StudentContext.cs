using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Data
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(new Student[]{
                new Student(){ Id=1, Name="Taleh", Surname="Suleymanov",Age=20},
                new Student(){ Id=2, Name="Hesen", Surname="Eliyev",Age=24}
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}

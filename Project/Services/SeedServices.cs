﻿using Project.Data;
using Project.Models;
using System;

namespace Project.Services
{
    public class SeedServices
    {
        
        private readonly StudentRegistryDbContext context;
        public SeedServices(StudentRegistryDbContext context)
        {
            this.context = context;
        }
        
        public void Seed()
        {
            if (!context.Students.Any() && !context.Subjects.Any())
            {
                var math = new Subject { Name = "Mathematics" };
                var english = new Subject { Name = "English" };
                var history = new Subject { Name = "History" };

                context.Subjects.AddRange(math, english, history);
                context.SaveChanges();
                context.Students.Add(new Models.Student
                {
                    Name = "Popovici",
                    Surname = "Clara",
                    Age = 33,
                    Address = new Address
                    {
                        City = "Arad",
                        Street = "Libertatii",
                        Number = 19
                    },
                    Marks = new List<Mark>
    {
                        new Mark { Value = 9, DateGiven = DateTime.Now, Subject = math },
                        new Mark { Value = 8, DateGiven = DateTime.Now, Subject = english }
                    }
                });
                context.Students.Add(new Models.Student
                {
                    Name = "Popescu",
                    Surname = "Alin",
                    Age = 20,
                    Address = new Address
                    {
                        City = "Iasi",
                        Street = "Libertatii",
                        Number = 2
                    },
                    Marks = new List<Mark>
                    {
                        new Mark { Value = 7, DateGiven = DateTime.Now, Subject = history },
                        new Mark { Value = 6, DateGiven = DateTime.Now, Subject = english }
                    }
                });
                context.Students.Add(new Models.Student
                {
                    Name = "Ile",
                    Surname = "Lavinia",
                    Age = 19,
                    Address = new Address
                    {
                        City = "Oradea",
                        Street = "Republicii",
                        Number = 35
                    },
                    Marks = new List<Mark>
                    {
                        new Mark { Value = 10, DateGiven = DateTime.Now, Subject = math },
                        new Mark { Value = 9, DateGiven = DateTime.Now, Subject = english }
                    }
                });
                context.Students.Add(new Models.Student
                {
                    Name = "Secara",
                    Surname = "Carina",
                    Age = 21,
                    Address = new Address
                    {
                        City = "Oradea",
                        Street = "Aluminei",
                        Number = 56
                    },
                    Marks = new List<Mark>
                    {
                        new Mark { Value = 6, DateGiven = DateTime.Now, Subject = math },
                        new Mark { Value = 7, DateGiven = DateTime.Now, Subject = history }
                    }
                });
                context.Students.Add(new Models.Student
                {
                    Name = "Cuc",
                    Surname = "Patricia",
                    Age = 22,
                    Address = new Address
                    {
                        City = "Iasi",
                        Street = "Agricultori",
                        Number = 22
                    },
                    Marks = new List<Mark>
                    {
                        new Mark { Value = 8, DateGiven = DateTime.Now, Subject = english },
                        new Mark { Value = 9, DateGiven = DateTime.Now, Subject = history }
                    }
                });
                context.Students.Add(new Models.Student
                {
                    Name = "Tiutin",
                    Surname = "Natalia",
                    Age = 20,
                    Address = new Address
                    {
                        City = "Timisoara",
                        Street = "Anina",
                        Number = 19
                    },
                    Marks = new List<Mark>
                    {
                        new Mark { Value = 7, DateGiven = DateTime.Now, Subject = math },
                        new Mark { Value = 8, DateGiven = DateTime.Now, Subject = english }
                    }
                });
                
                context.SaveChanges();
            }
        }
       
    }
}
            
              
                 
                
using MenuItens.Context;
using MenuItens.Controllers;
using MenuItens.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;

namespace MenuTestProject
{
    //Create a SQLite connection to run in memory for testing. Seeding database with test data
    //According to the reference: https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/complex-data-model?view=aspnetcore-6.0
    public class InMemoryBD 
    {
        private MenuItensContext _context;
        public InMemoryBD()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder<MenuItensContext>()
                .UseSqlite(connection)
                .EnableSensitiveDataLogging()
                .Options;

            _context = new MenuItensContext(options);
            InsertFakeData();
        }
        public MenuItensContext GetContext() => _context;
        private void InsertFakeData()
        {
            if (_context.Database.EnsureCreated())
            {
                var products = new Product[]
                {
                    new Product { Id = 1, PrdName = "FRIES", PrdType = 1 },
                    new Product { Id = 2, PrdName = "COKE", PrdType = 1 },
                    new Product { Id = 3, PrdName = "BEEF", PrdType = 1 },
                    new Product { Id = 4, PrdName = "SPRITE", PrdType = 1 },
                    new Product { Id = 5, PrdName = "RICE", PrdType = 1 },
                    new Product { Id = 6, PrdName = "DRINK CHOICE", PrdType = 2 },
                    new Product { Id = 7, PrdName = "SIDE CHOICE", PrdType = 2 },
                    new Product { Id = 8, PrdName = "SPECIAL MEAL", PrdType = 3 },
                    new Product { Id = 9, PrdName = "REGULAR MEAL", PrdType = 3 },
                };
                foreach (Product p in products)
                {
                    _context.Product.Add(p);
                }
                _context.SaveChanges();

                var actives = new PrdActive[]
                {
                    new PrdActive {PrdId = products.Single(x => x.Id == 1).Id, PrdStatus = 1},
                    new PrdActive {PrdId = products.Single(x => x.Id == 2).Id, PrdStatus = 0},
                    new PrdActive {PrdId = products.Single(x => x.Id == 3).Id, PrdStatus = 1},
                    new PrdActive {PrdId = products.Single(x => x.Id == 4).Id, PrdStatus = 1},
                    new PrdActive {PrdId = products.Single(x => x.Id == 5).Id, PrdStatus = 1},
                    new PrdActive {PrdId = products.Single(x => x.Id == 6).Id, PrdStatus = 0},
                    new PrdActive {PrdId = products.Single(x => x.Id == 7).Id, PrdStatus = 0},
                    new PrdActive {PrdId = products.Single(x => x.Id == 8).Id, PrdStatus = 0},
                    new PrdActive {PrdId = products.Single(x => x.Id == 9).Id, PrdStatus = 0},

                };
                foreach (PrdActive c in actives)
                {
                    _context.PrdActive.Add(c);
                }
                _context.SaveChanges();

                var components = new PrdComponents[]
                {
                    new PrdComponents {PrdId = products.Single(x => x.Id == 6).Id, ChildPrdId = products.Single(x => x.Id == 2).Id},
                    new PrdComponents {PrdId = products.Single(x => x.Id == 6).Id, ChildPrdId = products.Single(x => x.Id == 3).Id},
                    new PrdComponents {PrdId = products.Single(x => x.Id == 7).Id, ChildPrdId = products.Single(x => x.Id == 4).Id},
                    new PrdComponents {PrdId = products.Single(x => x.Id == 7).Id, ChildPrdId = products.Single(x => x.Id == 5).Id},
                    new PrdComponents {PrdId = products.Single(x => x.Id == 8).Id, ChildPrdId = products.Single(x => x.Id == 1).Id},
                    new PrdComponents {PrdId = products.Single(x => x.Id == 8).Id, ChildPrdId = products.Single(x => x.Id == 6).Id},
                    new PrdComponents {PrdId = products.Single(x => x.Id == 8).Id, ChildPrdId = products.Single(x => x.Id == 7).Id},
                    new PrdComponents {PrdId = products.Single(x => x.Id == 9).Id, ChildPrdId = products.Single(x => x.Id == 1).Id},
                    new PrdComponents {PrdId = products.Single(x => x.Id == 9).Id, ChildPrdId = products.Single(x => x.Id == 6).Id},
                    new PrdComponents {PrdId = products.Single(x => x.Id == 9).Id, ChildPrdId = products.Single(x => x.Id == 7).Id}

                };
                _context.SaveChanges();
            }
        }

    }

}

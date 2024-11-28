using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using Sample.MongoEF.Console;

var mongoDb = new MongoClient("mongodb://localhost:27017").GetDatabase("SampleDb");
var dbContextOptions = new DbContextOptionsBuilder<StorageContext>()
    .UseMongoDB(mongoDb.Client, "TestDb");

var db = new StorageContext(dbContextOptions.Options);
await db.Products.AddRangeAsync(
    new Product { Name = "XBox", Description = "Video Game", Quantity = 10, IsStocked = true },
    new Product { Name = "Toy Story", Description = "Movie", Quantity = 4, IsStocked = true },
    new Product { Name = "Angry Bird", Description = "Movie", Quantity = 2, IsStocked = true },
    new Product { Name = "Crazy Taxi", Description = "Video Game", Quantity = 0, IsStocked = false },
    new Product { Name = "Ball Game", Description = "Video Game", Quantity = 10, IsStocked = true },
    new Product { Name = "SEGA BOLD", Description = "Video Game", Quantity = 2, IsStocked = true },
    new Product { Name = "Terminator", Description = "Movie", Quantity = 42, IsStocked = true },
    new Product { Name = "Train Simulator", Description = "Video Game", Quantity = 1, IsStocked = true },
    new Product { Name = "Bus Simulator", Description = "Video Game", Quantity = 0, IsStocked = false }
    );
await db.SaveChangesAsync();

var allProducts = db.Products.ToList();
var id = MongoDB.Bson.ObjectId.Parse("6748ad0cee67d135935454fa");
// Find the record
var product = await db.Products.FindAsync(id);
if (product != null)
{
    db.Set<Product>().Remove(product);
    await db.SaveChangesAsync();
}

var obj1 = db.Set<Product>().First(x => x.Name == "XBox");
obj1.Description = "Gaming Console";
obj1.Quantity = 5;
await db.SaveChangesAsync();
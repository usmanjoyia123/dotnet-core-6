using Chapter21.TPH;
using System.Transactions;

public class Program
{
	public static void ClearSampleData()
	{
		var context = new ApplicationDbContextFactory().CreateDbContext(null);
		var entities = new[]
		{
			typeof(Driver).FullName,
			typeof(Car).FullName,
			typeof(Make).FullName,
		};
		foreach (var entityName in entities)
		{
			var entity = context.Model.FindEntityType(entityName);
			var tableName = entity.GetTableName();
			var schemaName = entity.GetSchema();
			context.Database.ExecuteSqlRaw($"DELETE FROM {schemaName}.{tableName}");
			context.Database.ExecuteSqlRaw($"DBCC CHECKIDENT (\"{schemaName}.{tableName}\", RESEED, 0);");
		}
	}
	public static void AddIdentityRecords()
	{
		var context = new ApplicationDbContextFactory().CreateDbContext(null);
		IEntityType metaDataCar = context.Model.FindEntityType(typeof(Car).FullName);
		var schemaCar = metaDataCar.GetSchema();
		var tableNameCar = metaDataCar.GetTableName();

        IEntityType metaDataMake = context.Model.FindEntityType(typeof(Make).FullName);
        var schemaMake = metaDataMake.GetSchema();
        var tableNameMake = metaDataMake.GetTableName();

        var stratgy = context.Database.CreateExecutionStrategy();
		stratgy.Execute(() =>
		{
			using var transaction = context.Database.BeginTransaction();
			try
			{
				//Action to Execute here
				//context.Database.ExecuteSqlRaw($"SET IDENTITY_INSERT {schemaCar}.{tableNameCar} ON");
                context.Database.ExecuteSqlRaw($"SET IDENTITY_INSERT {schemaMake}.{tableNameMake} ON");
                var newMake = new Make
				{
					Id = 1,
					Name = "BMW"
				};
				var newCar = new Car() { 
					Color = "",
					MakeId = 1,
					PetName = "Honda",
					Drivers= new []
					{
						new Driver() {FirstName = "Usman"}
					}
				};
				var cars = new List<Car>
				{
					new() { Color = "Yellow", MakeId = 1, PetName = "Herbie" },
					new() { Color = "White", MakeId = 1, PetName = "Mach 5" },
					new() { Color = "Pink", MakeId = 1, PetName = "Avon" },
					new() { Color = "Blue", MakeId = 1, PetName = "Blueberry" }
				};
				var drivers = new List<Driver>
				{
					new() { person = new Person { FirstName = "Fred", LastName = "Flinstone" },
						Id = 1
					},
					new() { person = new Person { FirstName = "Wilma", LastName = "Flinstone" },
					Id = 2
					},
					new() { person = new Person { FirstName = "BamBam", LastName = "Flinstone" },
					Id = 3
					},
					new() { person = new Person { FirstName = "Barney", LastName = "Rubble" },
					Id = 4
					},
					new() { person = new Person { FirstName = "Betty", LastName = "Rubble" },
					Id = 5
					},
					new() { person = new Person { FirstName = "Pebbles", LastName = "Rubble" },
					Id = 6
					}
				};
				var carsForM2M = context.Cars.Take(2).ToList();
				((List<Car>)newMake.Cars).AddRange(cars);
				context.Cars.AddRange(carsForM2M);
				//context.Makes.Attach(newMake);
				context.Makes.Add(newMake);

				context.Attach(newCar);
				context.SaveChanges();
				transaction.Commit();
			}
			catch(Exception ex)
			{
				transaction.Rollback();   
				Console.WriteLine(ex.ToString());
			}
			finally
			{
				context.Database.ExecuteSqlRaw($"SET IDENTITY_INSERT {schemaCar}.{tableNameCar} OFF");
                context.Database.ExecuteSqlRaw($"SET IDENTITY_INSERT {schemaMake}.{tableNameMake} OFF");
                transaction.Dispose();

			}
		}
		) ;
	}
	public static void AddRecords()
	{
		var context = new ApplicationDbContextFactory().CreateDbContext(null);
		var newMake = new Make
		{
			Id = 1,
			Name = "BMW"
		};
		var cars = new List<Car>
		{
			new() { Color = "Yellow", MakeId = newMake.Id, PetName = "Herbie" },
			new() { Color = "White", MakeId = newMake.Id, PetName = "Mach 5" },
			new() { Color = "Pink", MakeId = newMake.Id, PetName = "Avon" },
			new() { Color = "Blue", MakeId = newMake.Id, PetName = "Blueberry" }
		};
		var drivers = new List<Driver>
		{
			new() { person = new Person { FirstName = "Fred", LastName = "Flinstone" }, 
				Id = 1
			},
			new() { person = new Person { FirstName = "Wilma", LastName = "Flinstone" }, 
			Id = 2
			},
			new() { person = new Person { FirstName = "BamBam", LastName = "Flinstone" },
			Id = 3
			},
			new() { person = new Person { FirstName = "Barney", LastName = "Rubble" },
			Id = 4
			},
			new() { person = new Person { FirstName = "Betty", LastName = "Rubble" }, 
			Id = 5
			},
			new() { person = new Person { FirstName = "Pebbles", LastName = "Rubble" },
			Id = 6
			}
		};
		var carsForM2M = context.Cars.Take(2).ToList();
		((List<Driver>)cars[0].Drivers).AddRange(drivers);
        ((List<Driver>)cars[1].Drivers).AddRange(drivers);
        ((List<Car>)newMake.Cars).AddRange(cars);
		context.Cars.AddRange(carsForM2M);
		//context.Makes.Attach(newMake);
		context.Makes.Add(newMake);
		context.SaveChanges();
	}
	public static void LoadMakeAndCarData()
	{
		var context = new ApplicationDbContextFactory().CreateDbContext(null);
		List<Make> makes = new()
		{
			new() { Name = "VW" },
			new() { Name = "Saab" },
			new() { Name = "Yugo" },
			new() { Name = "BMW" },
			new() { Name = "Pinto" },
			new() { Name = "Ford" },
		};
		context.Makes.AddRange(makes);
		context.SaveChanges();
		List<Car> inventory = new()
		{
			new() { MakeId = 1, Color = "Black", PetName = "Zippy" },
			new() { MakeId = 2, Color = "Rust", PetName = "Rusty" },
			new() { MakeId = 3, Color = "Black", PetName = "Mel" },
			new() { MakeId = 4, Color = "Yellow", PetName = "Clunker" },
			new() { MakeId = 5, Color = "Black", PetName = "Bimmer" },
			new() { MakeId = 5, Color = "Green", PetName = "Hank" },
			new() { MakeId = 5, Color = "Pink", PetName = "Pinky" },
			new() { MakeId = 6, Color = "Black", PetName = "Pete" },
			new() { MakeId = 4, Color = "Brown", PetName = "Brownie" },
			new() { MakeId = 1, Color = "Rust", PetName = "Lemon" },
		};
		context.Cars.AddRange(inventory);
		context.SaveChanges();
	}
	public static void QueryData()
	{
		var context = new ApplicationDbContextFactory().CreateDbContext(null);
		//Return all of the cars
		IQueryable<Car> cars = context.Cars;
		int i = 0;
		Console.WriteLine("Querying the Cars: ");
		foreach (Car c in cars)
		{
			Console.WriteLine($"{++i}: {c.PetName} is {c.Color}");
		}
		//Clean up the context
		//context.ChangeTracker.Clear();
		//List<Car> cars2 = context.Cars.ToList();
		//foreach (Car c in cars2)
		//{
		//	Console.WriteLine($"{c.PetName} is {c.Color}");
		//}
	}
    public static void FilterData()
    {
        var context = new ApplicationDbContextFactory().CreateDbContext(null);
        //Return all yellow cars
		// First(), Single(), last() for retreiving single record
        IQueryable<Car> cars = context.Cars.Where(c => c.Color == "Yellow");
        Console.WriteLine("Yellow cars");
        foreach (Car c in cars)
        {
            Console.WriteLine($"{c.PetName} is {c.Color}");
        }
        context.ChangeTracker.Clear();
        //Return all yellow cars with a petname of Clunker
        IQueryable<Car> cars2 = context.Cars.Where(c => c.Color == "Yellow" && c.PetName == "Clunker");
        Console.WriteLine("Yellow cars and Clunkers");
        foreach (Car c in cars2)
        {
            Console.WriteLine($"{c.PetName} is {c.Color}");
        }
        context.ChangeTracker.Clear();
        //Return all yellow cars with a petname of Clunker
        IQueryable<Car> cars3 = context.Cars.Where(c => c.Color == "Yellow").Where(c => c.PetName == "Clunker");
        Console.WriteLine("Yellow cars and Clunkers");
        foreach (Car c in cars3)
        {
            Console.WriteLine($"{c.PetName} is {c.Color}");
        }
        context.ChangeTracker.Clear();
        //Return all yellow cars or cars with PetName of Clunker
        IQueryable<Car> cars4 = context.Cars.Where(c => c.Color == "Yellow" || c.PetName == "Clunker");
        Console.WriteLine("Yellow cars or Clunkers");
        foreach (Car c in cars4)
        {
            Console.WriteLine($"{c.PetName} is {c.Color}");
        }
        context.ChangeTracker.Clear();
    }

	public static void UpdateData()
	{
		var context = new ApplicationDbContextFactory().CreateDbContext(null);
		Car car = context.Cars.First(); // returns first element of your context sequence 
		car.Color= "red_updated"; // car object state would changed to modified 
		context.SaveChanges();
	}

    public static void UpdateData(string name, string color)
    {
        var context = new ApplicationDbContextFactory().CreateDbContext(null);
        Car car = context.Cars.First(x=>x.PetName==name);
        car.Color = color + "_updated";

		context.ChangeTracker.Clear();

		car.Color = "Zinc_updated";
		context.Cars.Update(car);
		context.Entry(car).State = EntityState.Modified;
		context.SaveChanges();
    }

	public static void UpdateData(int id, string color)
	{
		var context = new ApplicationDbContextFactory().CreateDbContext(null);
		var updatedCar = context.Cars.AsNoTracking().First(c => c.Id == id);
		updatedCar.Color = color + "_updated";
		// add it to context and make the state as modified
		context.Cars.Update(updatedCar);
		context.Entry(updatedCar).State = EntityState.Modified;
		context.SaveChanges();
	}

	public static void DeleteRecord(int id)
	{
		var context = new ApplicationDbContextFactory().CreateDbContext(null);
		var deletedCar = context.Cars.AsNoTracking().First(c=> c.Id == id);
		context.Cars.Remove(deletedCar);
		Console.WriteLine($"the state of {deletedCar.PetName} is " +
			$"{context.Entry(deletedCar).State}");

		//cascade delete  => DeletionBehavior()
		try
		{
            context.SaveChanges();
        }
		catch (DbUpdateException ex) {
			Console.WriteLine(ex.Message );
		}
        
		Console.WriteLine($"the state of {deletedCar.PetName} is " +
            $"{context.Entry(deletedCar).State}");
    }
    public static void Main( string [] args)
	{
		//ClearSampleData();
		//AddIdentityRecords();
		ClearSampleData();
		LoadMakeAndCarData();
		//QueryData();
		DeleteRecord(4);
		QueryData();
		Console.ReadLine();

		Console.Clear();
		Console.WriteLine("I am the Filter function here");
		FilterData();
		Console.ReadLine();
	}
}

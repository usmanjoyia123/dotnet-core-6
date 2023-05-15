namespace Chapter21.TPH
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var connectionString = @"Data Source=localhost\sqlexpress; Initial Catalog=SqlTest; Integrated Security=True; Trust Server Certificate=True;";
            //Docker connection string as follow:
            //var connectionString = @"server=.,1433;Database=AdvProg;User Id=sa;Password=
            //P@ssw0rd;Encrypt=False;";
            optionsBuilder.UseSqlServer(connectionString);
            //Console.WriteLine(connectionString);
            return new ApplicationDbContext(optionsBuilder.Options);
        }

    }
}

using Ardil.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ardil.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ArdilDbContext>
    {
        public ArdilDbContext CreateDbContext(string[] args)
        {

            ConfigurationManager configurationManager = new();
            configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/Ardil.Web"));
            configurationManager.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);


            DbContextOptionsBuilder dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseNpgsql(configurationManager.GetConnectionString("ArdilDb"));
            return new(dbContextOptionsBuilder.Options);
        }
    }
}

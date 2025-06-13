using Microsoft.EntityFrameworkCore;
using ServerManagementBlazorApp.Models;

namespace ServerManagementBlazorApp.Data
{
    public class ServerManagementContext : DbContext
    {
        public DbSet<Server> Servers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Server>().HasData(
            new Server { ServerId = 1, Name = "Server1", City = "Chennai" },
            new Server { ServerId = 2, Name = "Server2", City = "Chennai" },
            new Server { ServerId = 3, Name = "Server3", City = "Chennai" },
            new Server { ServerId = 4, Name = "Server4", City = "Thanjavur" },
            new Server { ServerId = 5, Name = "Server5", City = "Thanjavur" },
            new Server { ServerId = 6, Name = "Server6", City = "Erode" },
            new Server { ServerId = 7, Name = "Server7", City = "Erode" },
            new Server { ServerId = 8, Name = "Server8", City = "Erode" },
            new Server { ServerId = 9, Name = "Server9", City = "Coimbatore" },
            new Server { ServerId = 10, Name = "Server10", City = "Coimbatore" },
            new Server { ServerId = 11, Name = "Server11", City = "Coimbatore" },
            new Server { ServerId = 12, Name = "Server12", City = "Thiruchy" },
            new Server { ServerId = 13, Name = "Server13", City = "Thiruchy" },
            new Server { ServerId = 14, Name = "Server13", City = "Thiruchy" },
            new Server { ServerId = 15, Name = "Server13", City = "Madurai" },
            new Server { ServerId = 16, Name = "Server13", City = "Madurai" },
            new Server { ServerId = 17, Name = "Server13", City = "Theni" },
            new Server { ServerId = 18, Name = "Server13", City = "Madurai" }
            );
        }

    }
}

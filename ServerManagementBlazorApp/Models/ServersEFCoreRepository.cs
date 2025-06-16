using Microsoft.EntityFrameworkCore;
using ServerManagementBlazorApp.Data;

namespace ServerManagementBlazorApp.Models
{
    public class ServersEFCoreRepository : IServersEFCoreRepository
    {
        private readonly IDbContextFactory<ServerManagementContext> contextFactory;

        public ServersEFCoreRepository(IDbContextFactory<ServerManagementContext> contextFactory)
        {
            this.contextFactory = contextFactory;
        }

        public void AddServer(Server server)
        {
            using var db = this.contextFactory.CreateDbContext();
            db.Servers.Add(server);
            db.SaveChanges();
        }

        public List<Server> GetAllServers()
        {
            using var db = this.contextFactory.CreateDbContext();
            return db.Servers.ToList();
        }

        public List<Server> GetServersByCity(string cityName)
        {
            using var db = this.contextFactory.CreateDbContext();
            return db.Servers.Where(s => s.City != null && s.City.ToLower().IndexOf(cityName.ToLower()) >= 0).ToList();
        }

        public Server? GetServersById(int Id)
        {
            using var db = this.contextFactory.CreateDbContext();
            var server = db.Servers.FirstOrDefault(x => x.ServerId == Id);

            if (server is not null) return server;

            return new Server();
        }

        public void UpdateServer(Server server, int serverId)
        {
            using var db = this.contextFactory.CreateDbContext();
            var serverToUpdate = db.Servers.FirstOrDefault(x => x.ServerId == serverId);

            if (serverToUpdate is not null)
            {
                serverToUpdate.Name = server.Name;
                serverToUpdate.City = server.City;
                serverToUpdate.IsOnline = server.IsOnline;

                db.SaveChanges();
            }
        }

        public void DeleteServer(int serverId)
        {
            using var db = this.contextFactory.CreateDbContext();
            var server = db.Servers.Find(serverId);
            if (server is null) return;

            db.Servers.Remove(server);
            db.SaveChanges();
        }

        public List<Server> SearchServer(string serverFilter)
        {
            using var db = this.contextFactory.CreateDbContext();
            return db.Servers.Where(x => x.Name!.Contains(serverFilter, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}

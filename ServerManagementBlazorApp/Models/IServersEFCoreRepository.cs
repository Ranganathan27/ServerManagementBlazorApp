
namespace ServerManagementBlazorApp.Models
{
    public interface IServersEFCoreRepository
    {
        void AddServer(Server server);
        void DeleteServer(int serverId);
        List<Server> GetAllServers();
        List<Server> GetServersByCity(string cityName);
        Server? GetServersById(int Id);
        List<Server> SearchServer(string serverFilter);
        void UpdateServer(Server server, int serverId);
    }
}
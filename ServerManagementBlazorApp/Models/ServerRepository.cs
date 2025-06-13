namespace ServerManagementBlazorApp.Models
{
    public static class ServerRepository
    {
        /// <summary>
        /// Creates a List for the availabilty of server.
        /// </summary>
        public static List<Server> servers = new List<Server>()
        {
            new Server{ServerId=1,Name="Server1",City="Chennai"},
            new Server {ServerId = 2, Name = "Server2", City = "Chennai" },
            new Server {ServerId = 3, Name = "Server3", City = "Chennai" },
            new Server {ServerId = 4, Name = "Server4", City = "Thanjavur" },
            new Server {ServerId = 5, Name = "Server5", City = "Thanjavur" },
            new Server {ServerId = 6, Name = "Server6", City = "Erode" },
            new Server {ServerId = 7, Name = "Server7", City = "Erode" },
            new Server {ServerId = 8, Name = "Server8", City = "Erode" },
            new Server {ServerId = 9, Name = "Server9", City = "Coimbatore" },
            new Server {ServerId = 10, Name = "Server10", City = "Coimbatore" },
            new Server {ServerId = 11, Name = "Server11", City = "Coimbatore" },
            new Server {ServerId = 12, Name = "Server12", City = "Thiruchy" },
            new Server {ServerId = 13, Name = "Server13", City = "Thiruchy" },
            new Server {ServerId = 14, Name = "Server13", City = "Thiruchy" },
            new Server {ServerId = 15, Name = "Server13", City = "Madurai" },
            new Server {ServerId = 16, Name = "Server13", City = "Madurai" },
            new Server {ServerId = 17, Name = "Server13", City = "Theni" },
            new Server {ServerId = 18, Name = "Server13", City = "Madurai" },

        };

        /// <summary>
        /// Create a new server to the Servers List.
        /// </summary>
        /// <param name="server"></param>
        public static void AddServer(Server server)
        {
            var maxId = servers.Max(x => x.ServerId);
            server.ServerId = maxId+1;
            servers.Add(server);
        }

        /// <summary>
        /// Get all server details.
        /// </summary>
        public static List<Server> GetServers => servers;

        /// <summary>
        /// Filters the server by city name.
        /// </summary>
        /// <param name="cityName"></param>
        /// <returns></returns>
        public static List<Server> GetServerByCity(string cityName)
        {
            return servers.Where(s => s.City!.Equals(cityName, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        /// <summary>
        /// Retreives the server id from the server.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Server? GetServerId(int id)
        {
            var server = servers.FirstOrDefault(x => x.ServerId == id);
            if(server != null)
            {
                return new Server
                {
                    ServerId = server.ServerId,
                    Name = server.Name,
                    City = server.City,
                    IsOnline = server.IsOnline,

                };
            }
            return null;
        }

        /// <summary>
        /// Updates the server details to the server.
        /// </summary>
        /// <param name="serverId"></param>
        /// <param name="serverDetail"></param>
        public static void UpdateServerDetails(int serverId, Server serverDetail)
        {
            if (serverId != serverDetail.ServerId) return;

            var serverToUpdate = servers.FirstOrDefault(x => x.ServerId == serverId);

            if (serverToUpdate != null)
            {
                serverToUpdate.Name = serverDetail.Name;
                serverToUpdate.City = serverDetail.City;
                serverToUpdate.IsOnline = serverDetail.IsOnline;
            }
        }

        /// <summary>
        /// Delete the selected server in the list.
        /// </summary>
        /// <param name="serverId"></param>
        public static void DeleteServer(int serverId)
        {
            var serverDetail = servers.FirstOrDefault(x => x.ServerId == serverId);

            if(serverDetail != null)
            {
                servers.Remove(serverDetail);
            }
        }

        /// <summary>
        /// Search the server from the server list.
        /// </summary>
        /// <param name="serverFilter"></param>
        /// <returns></returns>
        public static List<Server> SearchServer(string serverFilter)
        {
            return servers.Where(x => x.Name!.Contains(serverFilter,StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}

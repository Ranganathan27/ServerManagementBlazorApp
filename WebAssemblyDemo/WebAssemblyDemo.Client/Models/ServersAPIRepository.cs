using Newtonsoft.Json;
using System.Text;

namespace WebAssemblyDemo.Client.Models
{
    public class ServersAPIRepository : IServersRepository
    {
        private const string apiName = "ServersAPI";
        private readonly IHttpClientFactory httpClientFactory;

        public ServersAPIRepository(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<Server>? GetServerByIdAsync(int id)
        {
            var httpClient = httpClientFactory.CreateClient(apiName);

            var response = await httpClient.GetAsync($"servers/{id}.json");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Server>(content)?? new Server();
        }

        public async Task<List<Server>> GetServersAsync()
        {
            var client = httpClientFactory.CreateClient(apiName);
            var response = await client.GetAsync("servers.json");

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            if (!string.IsNullOrWhiteSpace(content) && content != null)
            {
                return JsonConvert.DeserializeObject<List<Server>>(content) ?? new List<Server>();
            }
            else
            {
                return new List<Server>();
            }
        }

        public async Task AddServerAsync(Server server)
        {
            server.ServerId = await GetNextServerIDAsync();

            var client = httpClientFactory.CreateClient(apiName);
            var content = new StringContent(JsonConvert.SerializeObject(server),Encoding.UTF8, "application/json");

            var response =  await client.PutAsync($"servers/{server.ServerId}.json",content);
            response.EnsureSuccessStatusCode();
        }


        public async Task UpdateServerAsync(int serverId, Server server)
        {
            if (serverId != server.ServerId) return;

            var httpClient = httpClientFactory.CreateClient(apiName);

            var content = new StringContent(JsonConvert.SerializeObject(server), Encoding.UTF8, "application/json");

            var response = await httpClient.PatchAsync($"servers/{serverId}.json", content);

            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteServerAsync(int serverId)
        {
            var httpClient = httpClientFactory.CreateClient(apiName);
            var response = await httpClient.DeleteAsync($"servers/{serverId}.json");
            response.EnsureSuccessStatusCode();
        }

        private async Task<int> GetNextServerIDAsync()
        {
            var servers = await GetServersAsync();
            if(servers is not null && servers.Any())
            {
                return servers.Where(x => x is not null).Max(x => x.ServerId) + 1;
            }

            return 1;
        }

    }
}

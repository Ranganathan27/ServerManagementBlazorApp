﻿using ServerManagementBlazorApp.Models;

namespace ServerManagementBlazorApp.StateStore
{
    public class ContainerStorage
    {
        private Server _server = new Server();

        public Server GetServer() {  return _server; }

        public void SetServer(Server server) { _server = server; }
    }
}

using Microsoft.AspNetCore.SignalR;

namespace ServerManagementBlazorApp.StateStore
{
    public class MaduraiOnlineServerStore : Observer
    {
        private int _numberOfServersOnline = 0;

        public int GetNumberOfServersOnline()
        { 
            return _numberOfServersOnline; 
        }

        public void SetNumberOfServersOnline(int number)
        {
            _numberOfServersOnline = number;
            base.BroadCastStateChange();
        }
    }
}

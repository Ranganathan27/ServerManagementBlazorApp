namespace ServerManagementBlazorApp.StateStore
{
    public class ChennaiOnlineServerStore : Observer
    {
        private int _numberOfServersOnline = 0;

        public int GetNumberOfServersOnline()
        {
            return _numberOfServersOnline;
        }

        public void SetNumberOfServerOnline( int number)
        {
            _numberOfServersOnline = number;
            base.BroadCastStateChange();
        }
    }
}

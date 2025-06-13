namespace ServerManagementBlazorApp.Models
{
    public static class CitiesRepository
    {
        private static List<string> Cities =new List<string>() 
        {
            "Chennai",
            "Thanjavur",
            "Erode",
            "Coimbatore",
            "Thirichy",
            "Madurai",
            "Theni"
        };

        public static List<String> GetCities() => Cities;
    }
}

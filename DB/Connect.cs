namespace loterry_console.DB
{
    internal class Connect
    {
        public static string connectDB()
        {
            return $"Server={Environment.GetEnvironmentVariable("SERVERNAME")};" +
                $"Database={Environment.GetEnvironmentVariable("DATABASE")};Trusted_Connection=True;";
        }
    }
}

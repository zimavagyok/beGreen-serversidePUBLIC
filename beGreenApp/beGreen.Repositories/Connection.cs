namespace beGreen.Repositories
{
    public static class Connection
    {
#if DEBUG 
        public static string String { get; } = @"Data Source=.\SQLEXPRESS;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False";
        //public static string String { get; } = @"Data Source = ;Initial Catalog=beGreenDB;Persist Security Info=False;User ID=;Password=;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
#else
        public static string String { get; } = @"Data Source = ;Initial Catalog=beGreenDB;Persist Security Info=False;User ID=;Password=;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
#endif
    }
}

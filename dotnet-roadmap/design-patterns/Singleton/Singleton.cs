public class Singleton
{
    private static Singleton instance = null;
    public static Singleton Instance
    {
        get
        {
            if (instance is null)
                instance = new Singleton();

            return instance;
        }
    }
    private Singleton()
    {
        Task.Delay(2000).GetAwaiter().GetResult();
    }
}
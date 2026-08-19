namespace NTM_Lesson02
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            app.MapGet("/", () => "uno, dos, tres, hala madrid!");

            app.Run();
        }
    }
}

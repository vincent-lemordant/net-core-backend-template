namespace API;

public partial class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var startup = new Startup(builder.Configuration);

        startup.ConfigureServices(builder.Services, builder.Environment);

        var app = builder.Build();
        startup.Configure(app, builder.Environment);

        app.Run();
    }
}


var builder = WebApplication.CreateBuilder(args);


string db_connection = builder.Configuration.GetConnectionString("MovieAppDb");

builder.Services
    .AddControllers(options => options.EnableEndpointRouting = false)
    .AddNewtonsoftJson();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(db_connection));
builder.Services.AddTransient<IFileFunctions, CustomFileFunctions>();


var app = builder.Build();

app.ConfigureGlobalErrorHandler();

app.ConfigureGlobalExceptionHandler();

app.UseStaticFiles();

app.UseRouting();

app.MapControllers();

app.Run();

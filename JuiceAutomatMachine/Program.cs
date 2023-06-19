using JuiceAutomatMachine.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCors(options => options.AddPolicy("AllowAll", p => p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

builder.Services.AddDbContext<JuiceDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
/*{
    SqlConnectionStringBuilder connBuilder = new(builder.Configuration.GetConnectionString("DefaultConnection"));
    connBuilder.AttachDBFilename = "AppData/MSDBData.mdf";
    options.UseSqlServer(connBuilder.ConnectionString);
} );*/
builder.Services.AddDbContext<CoinDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
/*{
    SqlConnectionStringBuilder connBuilder = new (builder.Configuration.GetConnectionString("DefaultConnection"));
    connBuilder.AttachDBFilename = "AppData/MSDBData.mdf";
    options.UseSqlServer(connBuilder.ConnectionString);
} );*/

builder.WebHost.UseUrls("https://localhost:44321");

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseCors("AllowAll");
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var juiceContext = services.GetRequiredService<JuiceDbContext>();
        var coinContext = services.GetRequiredService<CoinDbContext>();
        JuiceDbInitializer.Initialize(juiceContext);
        CoinDbInitializer.Initialize(coinContext);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred creating the DB.");
    }
}

app.Run();
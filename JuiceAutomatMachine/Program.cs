var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCors(options => options.AddPolicy("AllowAll", p => p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

//dbContexts here

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
/*builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();*/

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    /*app.UseSwagger();
    app.UseSwaggerUI();*/
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

app.UseStaticFiles();
app.UseCors("AllowAll");
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();

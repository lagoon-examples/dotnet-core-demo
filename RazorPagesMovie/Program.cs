using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddRazorPages();

var dbname = Environment.GetEnvironmentVariable("MARIADB_DATABASE");
var dbuser = Environment.GetEnvironmentVariable("MARIADB_USERNAME");
var dbpass = Environment.GetEnvironmentVariable("MARIADB_PASSWORD");
var dbhostEnv = Environment.GetEnvironmentVariable("MARIADB_HOST");
var dbhost = dbhostEnv != null ? dbhostEnv : "mariadb";
var connstring = "Server=" + dbhost + ";Database=" + dbname + ";Uid=" + dbuser + ";Pwd=" + dbpass + ";";
var serverVersion = new MariaDbServerVersion(new Version(10, 6));
//builder.Configuration.GetConnectionString("RazorPagesMovieContext") ?? throw new InvalidOperationException("Connection string 'RazorPagesMovieContext' not found."))

builder.Services.AddDbContext<RazorPagesMovieContext>(options =>
    options.UseMySql(connstring, serverVersion, providerOptions => providerOptions.EnableRetryOnFailure()));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<RazorPagesMovieContext>();    
    context.Database.Migrate();
}


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

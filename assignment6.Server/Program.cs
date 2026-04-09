using Microsoft.EntityFrameworkCore;
using assignment6.Server.Data;
using assignment6.Server.Models;


var builder = WebApplication.CreateBuilder(args);
    
builder.Services.AddDbContext<PlaylistDb>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("playlistdb")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedData.Initialize(services);
}

app.MapGet("/api/playlists", async (PlaylistDb db) =>
{
    return await db.Playlists.Include(p=>p.Tracks).ToListAsync();
});

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();

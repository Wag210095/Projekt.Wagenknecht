using Microsoft.EntityFrameworkCore;
using Project1.Context;
using Project1.Helpers;
using Project1.Interfaces;
using Project1.Models;
using Project1.Repository;
using Project1.Services;

var builder = WebApplication.CreateBuilder(args);

string? connectionString = builder.Configuration.GetConnectionString("MyConnection");


// Add services to the container
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<HttpService>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

// Add Services to IServiceCollection
builder.Services.AddTransient<IReadOnlyPlaylistService, PlaylistSerivce>();
builder.Services.AddTransient<IAddablePlaylistSerivce, PlaylistSerivce>();
builder.Services.AddTransient<IDeleteablePlaylistService, PlaylistSerivce>();

builder.Services.AddTransient<IReadOnlySongService, SongSerivce>();
builder.Services.AddTransient<IAddableSongSerivce, SongSerivce>();
builder.Services.AddTransient<IDeleteableSongService, SongSerivce>();

builder.Services.AddTransient<IReadOnlyCategoryService, CategoryService>();

builder.Services.AddTransient<IAddSongsToPlaylistService, SongsToPlaylistService>();
builder.Services.AddTransient<IRemoveSongsFromPlaylistService, SongsToPlaylistService>();

builder.Services.AddTransient<IDateTimeService, DateTimeService>();

// CRUD Services
builder.Services.AddTransient<IPlaylistRepository, PlaylistRepository>();
builder.Services.AddTransient<IReadOnlyPlaylistRepo, PlaylistRepository>();
builder.Services.AddTransient<IReadOnlyRepositoryBase<PlaylistModel>, RepositoryBase<PlaylistModel>>();


builder.Services.AddTransient<IReadOnlyCategoryRepo, CategoryRepository>();
builder.Services.AddTransient<IReadOnlyRepositoryBase<CategoryModel>, RepositoryBase<CategoryModel>>();

builder.Services.AddTransient<ISongsToPlaylistRepository, SongsToPlaylistRepository>();
builder.Services.AddTransient<IReadOnlyRepositoryBase<SongToPlaylistModel>, RepositoryBase<SongToPlaylistModel>>();


builder.Services.AddTransient<ISongRepository, SongRepository>();
builder.Services.AddTransient<IReadOnlySongRepo, SongRepository>();
builder.Services.AddTransient<IReadOnlyRepositoryBase<SongModel>, RepositoryBase<SongModel>>();


builder.Services.AddHttpContextAccessor();


DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder();
optionsBuilder.UseSqlite(connectionString);

ProjectDbContext db = new ProjectDbContext(optionsBuilder.Options);
db.Database.EnsureDeleted();
db.Database.EnsureCreated();
db.Seed();

builder.Services.AddSingleton<ProjectDbContext>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=PlaylistList}/{action=Index}/{id?}");

app.Run();

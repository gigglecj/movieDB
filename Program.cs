using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MvcWantseeContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("MvcWantseeContext") ?? throw new InvalidOperationException("Connection string 'MvcWantseeContext' not found.")));
builder.Services.AddDbContext<MvcCollectionContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("MvcCollectionContext") ?? throw new InvalidOperationException("Connection string 'MvcCollectionContext' not found.")));


builder.Services.AddDbContext<MvcUserContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("MvcUserContext") ?? throw new InvalidOperationException("Connection string 'MvcUserContext' not found.")));

builder.Services.AddDbContext<MvcMovieContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("MvcMovieContext") ?? throw new InvalidOperationException("Connection string 'MvcMovieContext' not found.")));

builder.Services.AddDbContext<MvcAttentionContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("MvcAttentionContext") ?? throw new InvalidOperationException("Connection string 'MvcAttentionContext' not found.")));
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromDays(1);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseSession();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=HomePage}/{action=Index}/{id?}");

app.Run();

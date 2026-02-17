using BlazingPizza.Data;
using BlazingPizza.Services;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// 1️⃣ Set default culture to Jamaica (JMD)
CultureInfo jamaicaCulture = new("en-JM");
CultureInfo.DefaultThreadCurrentCulture = jamaicaCulture;
CultureInfo.DefaultThreadCurrentUICulture = jamaicaCulture;

// 2️⃣ Add services
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddHttpClient();
builder.Services.AddDbContext<PizzaStoreContext>(options =>
    options.UseSqlite("Data Source=pizza.db"));
builder.Services.AddScoped<OrderState>();

var app = builder.Build();

// 3️⃣ Configure middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();
app.UseRouting();

// 4️⃣ Map Blazor and Razor endpoints
app.MapRazorPages();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// 5️⃣ Initialize the database
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<PizzaStoreContext>();
    if (db.Database.EnsureCreated())
    {
        SeedData.Initialize(db);
    }
}

// 6️⃣ Run the app
app.Run();

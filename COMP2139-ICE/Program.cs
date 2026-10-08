using COMP2139_ICE.Data;
using Microsoft.EntityFrameworkCore;

// PostgreSQL üçün DateTime xətasını həll edən konfiqurasiya
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var builder = WebApplication.CreateBuilder(args);

// DbContext və PostgreSQL bağlantısı
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// MVC Controller və View xidmətləri
builder.Services.AddControllersWithViews();

var app = builder.Build();

// HTTP request pipeline konfiqurasiyası
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
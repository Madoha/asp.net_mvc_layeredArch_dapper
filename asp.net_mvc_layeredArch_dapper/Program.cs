using asp.net_mvc_layeredArch_dapper.BL.Implementations;
using asp.net_mvc_layeredArch_dapper.BL.Interfaces;
using asp.net_mvc_layeredArch_dapper.DAL.Implementations;
using asp.net_mvc_layeredArch_dapper.DAL.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//builder.Services.AddSingleton(serviceProvider =>
//{
//    var configuration = serviceProvider.GetService<IConfiguration>();

//    var connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new ApplicationException("The connection string is null");

//    return new DbConnection(connectionString);
//});

builder.Services.AddSingleton<IUserBL, UserBL>();
builder.Services.AddSingleton<IUserDAL, UserDAL>();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

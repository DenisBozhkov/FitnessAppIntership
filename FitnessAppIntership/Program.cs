using FitnessAppIntership.Data;
using FitnessAppIntership.Data.Entities;
using FitnessAppIntership.Mappers;
using FitnessAppIntership.Models;
using FitnessAppIntership.Services;
using FitnessAppIntership.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<AccountEntity>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

//builder.Services.AddScoped<ICoachService, CoachService>();
//builder.Services.AddScoped<IEquipmentService, EquipmentService>();
builder.Services.AddScoped<IHallService, HallService>();
//builder.Services.AddScoped<IMemberListService, MemberListService>();
//builder.Services.AddScoped<IMemberService, MemberService>();
//builder.Services.AddScoped<IStatisticsService, StatisticsService>();
//builder.Services.AddScoped<ISubscriptionService, SubscriptionService>();
//builder.Services.AddScoped<ISubscriptionTypeService, SubscriptionTypeService>();
//builder.Services.AddScoped<ITrainingService, TrainingService>();
//builder.Services.AddScoped<ITrainingTypeService, TrainingTypeService>();
//builder.Services.AddScoped<IVisitService, VisitService>();

builder.Services.AddScoped<IMapper<SubscriptionViewModel, SubscriptionEntity>, SubscriptionMapper>();
builder.Services.AddScoped<IMapper<EquipmentViewModel, EquipmentEntity>, EquipmentMapper>();
builder.Services.AddScoped<IMapper<TrainingViewModel, TrainingEntity>, TrainingMapper>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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
app.MapRazorPages();

using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    if (!await roleManager.RoleExistsAsync("admin"))
        await roleManager.CreateAsync(new IdentityRole("admin"));

    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AccountEntity>>();
    if (await userManager.FindByEmailAsync("Admin@gmail.com") == null)
    {
        AccountEntity admin = new() { UserName = "Admin@gmail.com", Email = "Admin@gmail.com" };

        await userManager.CreateAsync(admin, "Admin_123");
        await userManager.AddToRoleAsync(admin, "admin");
    }
}

app.Run();

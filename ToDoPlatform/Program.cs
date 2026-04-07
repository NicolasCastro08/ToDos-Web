using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ToDoPlatform.Data;
using ToDoPlatform.Models;
using ToDoPlatform.Services;

var builder = WebApplication.CreateBuilder(args);

// Conexão com o banco
string conexao = builder.Configuration.GetConnectionString("Conexao");

builder.Services.AddDbContext<AppDbContext>(
    options => options.UseMySQL(conexao)
);

// Configuração do Identity
builder.Services.AddIdentity<AppUser, IdentityRole>(opt =>
{
    opt.User.RequireUniqueEmail = true;
    opt.SignIn.RequireConfirmedAccount = false;
})
.AddEntityFrameworkStores<AppDbContext>()
.AddDefaultTokenProviders();

// Serviço de usuário
builder.Services.AddTransient<IUserService, UserService>();

// Controllers + Views
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Garante a existência do banco
// Garante a existência do banco
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    await dbContext.Database.EnsureCreatedAsync();
}

// Pipeline HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
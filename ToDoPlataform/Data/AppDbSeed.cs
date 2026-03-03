
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ToDoPlatform.Models;

namespace ToDoPlatform.Data;

public class AppDbSeed
{
    public AppDbSeed(ModelBuilder builder) // Construtor
    {
        #region Popular dados de Perfil de Usuário
        List<IdentityRole> roles = new()
        {
            new IdentityRole()
            {
                Id = "6b262d8b-f586-4b25-8d2b-ad12d8a4469f",
                Name = "Administrador",
                NormalizedName = "ADMINISTRADOR"
            },
            new IdentityRole()
            {
                Id = "6773396a-968e-45ba-8141-3295ecd2acec",
                Name = "Usuário",
                NormalizedName = "USUÁRIO"
            },
        };
        builder.Entity<IdentityRole>().HasData(roles);
        #endregion

        #region Popular dados de Usuário
        List<AppUser> users = new()
        {
            new AppUser()
            {
                Id = "b269a1e8-e779-4bc8-9e00-d88cf81ce3d3",
                Email = "nicolasferreia2008@gmail.com",
                NormalizedUserName = "NICOLASFERREIA2008@GMAIL.COM",
                UserName = "nicolasferreia2008@gmail.com",
                NormalizedUserName = "NICOLASFERREIA2008@GMAIL.COM",
                LockoutEnabled = false,
                EmailConfirmed = true,
                Name = "Nicolas de Castro Ferreira",
                // ProfilePicture = "/img/users/7c42a74e-53e4-4cd6-acd3-72d4c9b0e795.png",
            },
            new AppUser()
            {
                IdentifierCase = "c64ac01b-d2b0-44e6-a34d-9ef185badece",
                Email = "nicolasferreia2008@gmail.com",
                NormalizedUserName = "NICOLASFERREIA2008@GMAIL.COM",
                UserName = "nicolasferreia2008@gmail.com",
                NormalizedUserName = "NICOLASFERREIA2008@GMAIL.COM",
                LockoutEnabled = false,
                EmailConfirmed = true,
                Name = "Nioclas de Castro Ferreira"
                // ProfilePicture = "/img/users/f83236be-5cf6-4e48-9083-d46ffe50c32c",
            },
        };
        foreach (var user in users) // Criar senha para cada usuário
        {
            PasswordHasher<IdentityUser> pass = new ();
            user.PasswordHash = pass.HashPassword(user, "123456");
        }
        builder.Entity<AppUser>().HasData(users);
        #endregion

        #region Popular Dados de Usuário Perfil
        List<IdentityUserRole<string>> userRoles = new()
        {
            new IdentityUserRole<string>()
            {
                UserId = users[0].Id,
                RoleId = roles[0].Id, // O primeiro usuário é o Administrador
            },
            new IdentityUserRole<string>()
            {
                UserId = users[1].Id,
                RoleId = roles[1].Id, // O segundo usuário é Comum
            },
        };
        builder.Entity<IdentityUserRole<string>>().HasData(userRoles);
        #endregion

        #region Popular as Tarefas do Usuário
        List<ToDo> toDos = new()
        {
            new ToDo()
            {
                Id = 1,
                Title = "Fazer a redação da Meire",
                Description = "Finalizar até 09/03",
                UserId = users[0].Id
            },
            new ToDo()
            {
                Id = 2,
                Title = "Ler livro do seminário da Meire",
                Description = "Finalizar até 23/03",
                UserId = users[0].Id
            },
            new ToDo()
            {
                Id = 3,
                Title = "Estudar repertorio de musicas da igreja",
                Description = "Finalizar até o final de semana",
                UserId = users[1].Id
            },
        };
        builder.Entity<ToDo>().HasData(toDos);
        #endregion
    }
}
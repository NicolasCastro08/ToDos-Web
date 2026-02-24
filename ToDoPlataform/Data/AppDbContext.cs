using Microsoft.AspnetCore.Identity;
using Microsoft.AspnetCore.Identity.EntityFrameworkCore;
using Microsoft.EnttityFrameworkCore;
using ToDoPlataform.Models;

namespace ToDoPlataform.Data

public class AppDbContext : IdentityDbContext<AppUser>
{
    
    public AppDbContext(DbContextOptions<AppDbContext> opt): base (opt)
    {
    } 

    public DbSet<AppUser> AppUsers { get; set; }
    public DbSet<ToDo> ToDo { get; set; }

    protected override void OnModelCreading(ModelBiulder biulder)
    {
        //Renomeando as tabelas do banco 
        base.OnModelCreading(biulder);

        #region Configuração das Tabelas do Identity
        biulder.Entity<AppUser>().ToTable("users");
        biulder.Entity<>




        
    }


}
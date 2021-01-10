using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
 namespace sportstore.Models
 {
     public class Context : IdentityDbContext
     {
         public Context (DbContextOptions options )
         : base (options)
         {
         }
         public DbSet<Product> Product {get;set;}
        public DbSet<Category> Category {get;set;}
        //  protected override void OnConfiguring(DbContextOptionsBuilder options)
        //  {
        //      base.OnConfiguring(options);
        //  }
     }
 }
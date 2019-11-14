using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using MAMSys.DataAccess.Abstract;
using MAMSys.Entites.Concrete;
using Microsoft.EntityFrameworkCore;

namespace MAMSys.DataAccess.Concrete.EntityFramework.Context
{
    public class MAMSysContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=K2PC1UGE55\SQLEXPRESS; Initial Catalog=MAMSys; Integrated Security=SSPI");
        }

        public DbSet<Canli> Canli { get; set; }
        public DbSet<Kullanici> Kullanici { get; set; }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<RolKullanici> RolKullanici { get; set; }


    }
}

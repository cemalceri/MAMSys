using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using MAMSys.Core.Entities.Concrete;
using MAMSys.DataAccess.Abstract;
using MAMSys.Entites.Concrete;
using Microsoft.EntityFrameworkCore;

namespace MAMSys.DataAccess.Concrete.EntityFramework.Context
{
    public class MAMSysContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source = 213.128.77.18; Initial Catalog = MAMSys; User Id = sa; password = Bil2002TAY!; ");
        }

        public DbSet<Canli> Canli { get; set; }
        public DbSet<Kullanici> Kullanici { get; set; }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<RolKullanici> RolKullanici { get; set; }


    }
}

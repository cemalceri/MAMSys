using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using MAMSys.DataAccess.Abstract;
using MAMSys.Entites.Concrete;
using Microsoft.EntityFrameworkCore;

namespace MAMSys.DataAccess.Concrete.EntityFramework.Context
{
    public class MamsysContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("");
        }

        public DbSet<Animal> Animals { get; set; }
    }
}

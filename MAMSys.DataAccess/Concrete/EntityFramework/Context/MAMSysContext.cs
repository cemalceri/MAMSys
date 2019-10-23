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
            optionsBuilder.UseSqlServer(@"Data Source=K2PC1UGE55\SQLEXPRESS; Initial Catalog=MAMSys; Integrated Security=SSPI");
        }

        public DbSet<Animal> Animals { get; set; }
    }
}

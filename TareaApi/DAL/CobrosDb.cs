using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
    

namespace TareaApi.DAL
{
    public class CobrosDb : DbContext
    {
        public CobrosDb(DbContextOptions<CobrosDb> options) : base(options)
        {
            
        }

        public DbSet<Models.Cobros> Cobros { get; set; }
    }
}

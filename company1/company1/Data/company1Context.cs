using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using company1.Models;

namespace company1.Data
{
    public class company1Context : DbContext
    {
        public company1Context (DbContextOptions<company1Context> options)
            : base(options)
        {
        }

        public DbSet<company1.Models.employee>? employee { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication_Get.Models;

namespace WebApplication_Get.Data
{
    public class WebApplication_GetContext : DbContext
    {
        public WebApplication_GetContext (DbContextOptions<WebApplication_GetContext> options)
            : base(options)
        {
        }

        public DbSet<WebApplication_Get.Models.Games> Games { get; set; }
    }
}

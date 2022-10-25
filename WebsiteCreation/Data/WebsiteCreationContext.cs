using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebsiteCreation.Models;

namespace WebsiteCreation.Data
{
    public class WebsiteCreationContext : DbContext
    {
        public WebsiteCreationContext (DbContextOptions<WebsiteCreationContext> options)
            : base(options)
        {
        }

        public DbSet<WebsiteCreation.Models.Carousel> Carousel { get; set; }
    }
}

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using DWHub.Models;

namespace DWHub.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<DWHub.Models.Watch> Watch { get; set; }

        public DbSet<DWHub.Models.Company> Company { get; set; }

        public DbSet<DWHub.Models.CompanyOwner> CompanyOwner { get; set; }

    }
}

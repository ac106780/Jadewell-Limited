﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Areas.Identity.Data;
using WebApplication1.Models;

namespace WebApplication1.Areas.Identity.Data;

public class WebApplication1ContextDB : IdentityDbContext<WebApplication1User>
{
    public WebApplication1ContextDB(DbContextOptions<WebApplication1ContextDB> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

    public DbSet<WebApplication1.Models.Workers> Workers { get; set; }

    public DbSet<WebApplication1.Models.House> House { get; set; }

    public DbSet<WebApplication1.Models.Buyers> Buyers { get; set; }

    public DbSet<WebApplication1.Models.houseAddress> houseAddress { get; set; }

    public DbSet<WebApplication1.Models.BuyerHouse> BuyerHouse { get; set; }
}

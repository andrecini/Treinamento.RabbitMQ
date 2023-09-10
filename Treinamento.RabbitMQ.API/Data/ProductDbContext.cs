﻿using Microsoft.EntityFrameworkCore;
using Treinamento.RabbitMQ.API.Models;

namespace Treinamento.RabbitMQ.API.Data
{
    public class ProductDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public ProductDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }
        public DbSet<Product> Products { get; set; }
    }
}

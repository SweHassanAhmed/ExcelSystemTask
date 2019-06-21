using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Infrastructure
{
    public class DbFactory : IDbFactory
    {
        private BaseEntity _dbContext;
        private readonly IConfiguration _config;

        public DbFactory(IConfiguration configuration)
        {
            _config = configuration;
        }

        public BaseEntity Init()
        {
            return _dbContext ?? (_dbContext = CreateDbContext());
        }

        public BaseEntity CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<BaseEntity>();
            optionsBuilder.UseSqlServer(_config.GetConnectionString("SQLServerConnection"));
            var entities = new BaseEntity(optionsBuilder.Options);
            return entities;
        }

    }
}

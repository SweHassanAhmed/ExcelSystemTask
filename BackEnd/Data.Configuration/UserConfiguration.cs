using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(u => u.UserID);

            List<User> users = new List<User>() {
                new User(){
                    UserID = 1,
                    Name = "Admin",
                    IsActive = true,
                    CreationDate = DateTime.Now,
                    ModificationDate = DateTime.Now
                }
            };

            builder.HasData(users);
        }
    }
}

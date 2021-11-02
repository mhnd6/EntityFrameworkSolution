using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.IO;
using EntityFrameworkUI.Models;

namespace EntityFrameworkUI.DataAccess
{
    public class ContactContext : DbContext //Configure EF "connect evertthing up"
    {
        //Three tables
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Email> EmailAddresses { get; set; }
        public DbSet<Phone> PhoneNumbers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //lookup and create configuration builder for talking to appsettings.json
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            var config = builder.Build();

            // package ms.extions.efcore.sqlserver 
            options.UseSqlServer(config.GetConnectionString("Default"));
        }
    }
}

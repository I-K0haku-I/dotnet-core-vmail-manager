using System;
using System.ComponentModel.DataAnnotations.Schema;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace mail_manager.Models
{
    [Table("domains")]
    public class Domains
    {
        public int Id { get; set; }
        public string Domain { get; set; }
    }

    [Table("accounts")]
    public class Accounts
    {
        public int Id {get; set;}
        public string Username {get; set;}
        public string Domain {get; set;}
        public string Password {get; set;}
        public int Quota {get; set;}
        public bool Enabled {get; set;}
        public bool Sendonly {get; set;}
    }

    [Table("aliases")]
    public class Aliases
    {
        public int Id {get; set;}
        [Column("source_username")]
        public string SourceName {get; set;}
        [Column("source_domain")]
        public string SourceDomain {get; set;}
        [Column("destination_username")]
        public string DestinationName {get; set;}
        [Column("destination_domain")]
        public string DestinationDomain {get; set;}
        public bool Enabled {get; set;}
    }

    public class MailDBContext : DbContext
    {
        public DbSet<Domains> Domains { get; set; }
        public DbSet<Accounts> Accounts { get; set; }
        public DbSet<Aliases> Aliases { get; set; }

        public MailDBContext(DbContextOptions<MailDBContext> options) : base(options)
        {

        }
    }
}
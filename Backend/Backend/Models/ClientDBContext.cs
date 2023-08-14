using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace Backend.Models
{
    public class ClientDBContext:DbContext
    {
        public ClientDBContext(DbContextOptions<ClientDBContext>options):base(options) { 

        }

        public Microsoft.EntityFrameworkCore.DbSet<Client> Clients { get; set; }
    }
}

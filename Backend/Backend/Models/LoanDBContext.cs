using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace Backend.Models
{
    public class LoanDBContext : DbContext
    {
        public LoanDBContext(DbContextOptions<LoanDBContext> options) : base(options)
        {

        }

        public Microsoft.EntityFrameworkCore.DbSet<Loan> Loans { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace Backend.Models
{
    public class LoanRequestDBContext:DbContext
    {
        public LoanRequestDBContext(DbContextOptions<LoanRequestDBContext> options) : base(options)
        {

        }

        public Microsoft.EntityFrameworkCore.DbSet<LoanRequest> LoanRequests { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace Backend.Models
{
    public class PaymentDBContext : DbContext
    {
        public PaymentDBContext(DbContextOptions<PaymentDBContext> options) : base(options)
        {

        }

        public Microsoft.EntityFrameworkCore.DbSet<Payment> Payments { get; set; }
    }
}

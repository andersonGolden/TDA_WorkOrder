using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TDADomain.DataObjects;

namespace TDADomain.Data
{
    public class TDAContext : DbContext
    {
        public TDAContext(DbContextOptions<TDAContext> options) : base(options)
        {

        }

        public DbSet<Agbada> Agbada { get; set; }
        public DbSet<ChestPocket> ChestPocket { get; set; }
        public DbSet<Cuffs> Cuffs { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Description> Description { get; set; }
        public DbSet<Embroidery> Embroidery { get; set; }
        public DbSet<Flap> Flap { get; set; }
        public DbSet<Measurement> Measurements { get; set; }
        public DbSet<Neck> Neck { get; set; }
        public DbSet<Sleeve> Sleeve { get; set; }
        public DbSet<Style> Style { get; set; }
        public DbSet<Top> Top { get; set; }
        public DbSet<Trouser> Trouser { get; set; }
        public DbSet<Trousers> Trousers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<WorkOrder> WorkOrders { get; set; }
    }
}

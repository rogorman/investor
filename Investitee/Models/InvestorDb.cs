using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Investitee.Models
{
    public class InvestorDb : DbContext
    {
        public DbSet<Investor> Investors { get; set; }
    }
}
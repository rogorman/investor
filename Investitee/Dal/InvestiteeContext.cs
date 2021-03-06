﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using Investitee.Models;

namespace Investitee.Dal
{
    public class InvestiteeContext : DbContext
    {
        public DbSet<Investor> Investors { get; set; }

        public DbSet<InvestorContact> InvestorContacts { get; set; }

        public DbSet<InvestmentConsultant> InvestmentConsultants { get; set; }

        public DbSet<InvestmentManager> InvestmentManagers { get; set; }

        public DbSet<Investment> Investments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
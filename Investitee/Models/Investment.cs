using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Investitee.Models
{
    public class Investment
    {
        public int Id { get; set; }

        public string InvestmentType { get; set; }

        public string InvestedCompany { get; set; }
    }
}
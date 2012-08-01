using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Investitee.Models
{
    public class Investor
    {
        public int id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double? FundSize { get; set; }

        public virtual ICollection<InvestorContact> Contacts { get; set; }

        public virtual ICollection<InvestmentConsultant> Consultants { get; set; }

        public virtual ICollection<InvestmentManager> InvestmentManagers { get; set; }
    }
}
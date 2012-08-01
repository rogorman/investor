using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Investitee.Models
{
    public class InvestmentManager
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Investment> Investments { get; set; }
    }
}
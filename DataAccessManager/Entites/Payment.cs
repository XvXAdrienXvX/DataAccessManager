using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessManager.Entites
{
    public class Payment : AuditableEntity
    {
        public int payment_no { get; set; }

        public int member_no { get; set; }

        public DateTime payment_dt { get; set; }

        public decimal payment_amt { get; set; }

        public int? statement_no { get; set; }

        public string payment_code { get; set; }
    }
}

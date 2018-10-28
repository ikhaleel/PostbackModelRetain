using System;
using System.Collections.Generic;

namespace PostbackModelRetain.Models
{
    public partial class SavingsDetails
    {
        public SavingsDetails()
        {
            InverseSavingsTypeNavigation = new HashSet<SavingsDetails>();
        }

        public int Id { get; set; }
        public double? Amount { get; set; }
        public int? SavingsType { get; set; }
        public DateTime? TransactionDate { get; set; }
        public DateTime? CreatedDate { get; set; }

        public SavingsDetails SavingsTypeNavigation { get; set; }
        public ICollection<SavingsDetails> InverseSavingsTypeNavigation { get; set; }
    }
}

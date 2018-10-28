using System;
using System.Collections.Generic;

namespace PostbackModelRetain.Models
{
    public partial class SavingsType
    {
        public int Id { get; set; }
        public string SavingsType1 { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}

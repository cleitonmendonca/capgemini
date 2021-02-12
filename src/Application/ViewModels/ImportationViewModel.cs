using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.ViewModels
{
    public class ImportationViewModel
    {
        public int Id { get; set; }
        public double TotalItems { get; set; }
        public double TotalValue { get ; set; }
        public DateTime LessDeliveredDate { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
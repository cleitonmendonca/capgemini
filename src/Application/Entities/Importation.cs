using System;
using System.Collections.Generic;
using System.Linq;
using Application.Core;

namespace Application.Entities
{
    public class Importation : BaseEntity
    {
        public DateTime LessDeliveredDate { get; private set; }
        public ICollection<Product> Products { get; private set; }
        public Importation(DateTime lessDeliveredDate)
        {
            LessDeliveredDate = lessDeliveredDate;
        }

        public void SetLowerDelivererDate()
        {
            var deleiveredOn = Products?.OrderByDescending(pa => pa.DeliveredOn)?.FirstOrDefault()?.DeliveredOn;
            if (deleiveredOn != null)
                this.LessDeliveredDate =
                    (DateTime) deleiveredOn;
        }
    }
}
using System;

namespace Application.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public int ImportationId { get;  set; }
        public DateTime DeliveredOn { get;  set; }
        public string Name { get;  set; }
        public double Quantity { get;  set; }
        public double Value { get;  set; }
        public double Total
        {
            get => Quantity * Value;
            set { }
        }
        //public ImportationViewModel Importation { get; set; }
    }
}
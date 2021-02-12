using System;
using System.Collections.Generic;
using System.Security.Authentication.ExtendedProtection;
using System.Xml.Serialization;
using Application.Core;

namespace Application.Entities
{
    public class Product : BaseEntity
    {
        public int ImportationId { get; private set; }
        public DateTime DeliveredOn { get; private set; }
        public string Name { get; private set; }
        public double Quantity { get; private set; }
        public double Value { get; private set; }
        public Importation Importation { get; private set; }

        public Product()
        {
        }
        public Product(DateTime deliveredOn, string name, double quantity, double value, int importationId)
        {
            DeliveredOn = deliveredOn;
            Name = name;
            Quantity = quantity;
            Value = value;
            ImportationId = importationId;
        }

    }
}
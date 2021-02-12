using System;
using System.IO;
using Application.Core.Behaviors;
using FluentValidation;
using MediatR;

namespace Application.Commands
{
    public class CreateProductCommand : IRequest<Response>
    {
        public DateTime DeliveredOn { set; get ; }
        public string Name { get;  set; }
        public double Quantity { get; set; }
        public decimal Value { get; set; }
    }
}
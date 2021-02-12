using System;
using System.Collections.Generic;
using Application.Core.Behaviors;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Commands
{
    public class CreateImportationCommand : IRequest<Response>
    {
        public IFormFile File { get; set; }
        public double TotalValue { get; set; }
        public int TotalItems { get; set; }
        public DateTime LessDeliveredDate { get; set; }
        public ICollection<CreateProductCommand> Products { get; set; }
    }
}
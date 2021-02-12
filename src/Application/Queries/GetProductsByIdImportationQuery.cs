using Application.Core.Behaviors;
using MediatR;

namespace Application.Queries
{
    public class GetProductsByIdImportationQuery : IRequest<Response>
    {
        public int ImportationId { get; set; }
    }
}
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Core.Behaviors;
using Application.Interfaces;
using Application.Queries;
using Application.ViewModels;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers
{
    public class GetProductsByIdImportationCommandHandler : IRequestHandler<GetProductsByIdImportationQuery, Response>
    {
        private readonly ICapgeminiDbContext _context;
        private readonly IMapper _mapper;

        public GetProductsByIdImportationCommandHandler(ICapgeminiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Response> Handle(GetProductsByIdImportationQuery request, CancellationToken cancellationToken)
        {
            var products = await _context.Products.Where(pr => pr.ImportationId.Equals(request.ImportationId))
                .ToListAsync(cancellationToken);

            if (products.Any())
            {
                var data = _mapper.Map<List<ProductViewModel>>(products);
                return new Response(data);
            }
            var response = new Response();
            return response.AddError("Não existe produtos para a importação requisitada!");
        }
    }
}
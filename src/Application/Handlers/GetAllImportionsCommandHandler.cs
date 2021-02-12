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
    public class GetAllImportionsCommandHandler: IRequestHandler<GetAllImportationsQuery, Response>
    {
        private readonly ICapgeminiDbContext _context;
        private readonly IMapper _mapper;

        public GetAllImportionsCommandHandler(ICapgeminiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Response> Handle(GetAllImportationsQuery request, CancellationToken cancellationToken)
        {
            var importations = await _context.Importations.Include(im => im.Products).ToListAsync();
            
            if (importations.Any())
            {
                return new Response(_mapper.Map<List<ImportationViewModel>>(importations));
            }

            var response = new Response();
            return response.AddError("Não existe data importados");
        }
    }
}
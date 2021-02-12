using System.Threading;
using System.Threading.Tasks;
using Application.Commands;
using Application.Core.Behaviors;
using Application.Entities;
using Application.Interfaces;
using Application.ViewModels;
using AutoMapper;
using AutoMapper.Configuration.Annotations;
using MediatR;

namespace Application.Handlers
{
    public class CreateImportationCommandHandler : IRequestHandler<CreateImportationCommand, Response>
    {
        private readonly ICapgeminiDbContext _context;
        private readonly IMapper _mapper;

        public CreateImportationCommandHandler(ICapgeminiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Response> Handle(CreateImportationCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Importation>(request);

            await _context.Importations.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            var response = new Response(_mapper.Map<ImportationViewModel>(entity));
            return response;
        }
    }
}
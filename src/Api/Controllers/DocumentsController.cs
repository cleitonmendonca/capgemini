using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands;
using Application.Core.Behaviors;
using Application.Queries;
using Application.Services;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DocumentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DocumentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("/api/Importar")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            var response = new Response();
            if (file == null || file.Length == 0)
            {
                return BadRequest(response.AddError("O arquivo enviando é inválido!"));
            }

            if (file.ContentType.Equals("application/vnd.ms-excel") ||
                file.ContentType.Equals("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"))
            {
                var _readExcelService = new ReadExcelService(file);
                response = await _readExcelService.OpenExcelFile();
            }
            else
            {
                response.AddError("O Formato de arquivo informado é inválido");
            }

            if (response.Errors.Any())
            {
                return BadRequest(response.Errors);
            }

            var products = (ICollection<CreateProductCommand>)response.Result;
            var createImportation = new CreateImportationCommand
            {
                Products = products,
                TotalItems = products.Count,
                LessDeliveredDate = products.OrderBy(pr => pr.DeliveredOn).FirstOrDefault().DeliveredOn
            };
            var result = await _mediator.Send(createImportation);
            return Ok(result);
        }

        [HttpGet]
        [Route("/api/GetImportacoes")]
        public async Task<IActionResult> GetImportacoes()
        {
            var result = await _mediator.Send(new GetAllImportationsQuery());
            if (result.Errors.Any())
            {
                return BadRequest(result.Errors);
            }

            return Ok(result.Result);
        }

        [HttpGet]
        [Route("/api/GetImportacao/{importacaoId}")]
        public async Task<IActionResult> GetImportacao(int importacaoId)
        {
            var response = new Response();
            if (importacaoId == 0)
            {
                response.AddError("Identificador de Importação inválido!");
                return BadRequest(response);
            }

            var result = await _mediator.Send(new GetProductsByIdImportationQuery {ImportationId = importacaoId});
            if (result.Errors.Any())
            {
                return BadRequest(result.Errors);
            }

            return Ok(result.Result);
        }
    }
}

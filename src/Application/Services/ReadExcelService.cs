using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands;
using Application.Core.Behaviors;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;

namespace Application.Services
{
    public class ReadExcelService : IReadExcelService
    {
        private readonly IFormFile _file;

        public ReadExcelService(IFormFile file)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            _file = file;
        }

        public async Task<Response> OpenExcelFile()
        {
            var stream = new MemoryStream();
            await _file.CopyToAsync(stream).ConfigureAwait(false);

            var package = new ExcelPackage(stream);

            var worksheet = package.Workbook.Worksheets[0];
            return await ReadExcelPackage(worksheet);
        }

        private async Task<Response> ReadExcelPackage(ExcelWorksheet sheet)
        {
            var response = new Response();
            var rows = sheet.Dimension?.Rows;
            var cols = sheet.Dimension?.Columns;

            if (Equals(!rows.HasValue) || Equals(!cols.HasValue))
            {
                response.AddError("O Arquivo enviado não possui dados para serem lidos!");
                return response;
            }
            
            if (cols > 4)
            {
                response.AddError("O Layout do Arquivo informado é inválido, o sistema só permite leitura de arquivo com 04 (quatro) colunas.");
                return response;
            }

            IList<CreateProductCommand> documentCommandsList = new List<CreateProductCommand>();
            for (int row = 2; row <= rows; row++)
            {
                var createDocument = new CreateProductCommand();
                for (int col = 1; col <= cols; col++)
                {
                    var cell = sheet.Cells[row, col].Value;
                    var position = sheet.Cells[row, col].Address;

                    switch (col)
                    {
                        case 1:
                            ValidatorDataExcel.ValidateDeliveryDate(col, cell, createDocument, response, position);
                            break;
                        case 2:
                            ValidatorDataExcel.ValidateDescription(col, cell, createDocument, response, position);
                            break;
                        case 3:
                            ValidatorDataExcel.ValidateQuantity(col, cell, createDocument, response, position);
                            break;
                        case 4:
                            ValidatorDataExcel.ValidateValue(col, cell, createDocument, response, position);
                            break;
                    }
                }
                documentCommandsList.Add(createDocument);
            }

            if (!response.Errors.Any())
            {
                response = new Response(documentCommandsList);
            }
            return response;
        }

    }
}
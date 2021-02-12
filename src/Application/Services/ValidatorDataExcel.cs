using System;
using Application.Commands;
using Application.Core.Behaviors;

namespace Application.Services
{
    public static class ValidatorDataExcel
    {
        public static void ValidateValue(int col, object cell, CreateProductCommand createProduct, Response response,
            object position)
        {
            if (cell != null && (double) cell > 0.00)
            {
                createProduct.Value = Decimal.Parse(cell.ToString());
            }
            else
            {
                response.AddError(
                    $"O Valor do produto informado na celula {position} é inválido! O valor do produto deve ser superior a 0.");
            }
        }

        public static void ValidateQuantity(int col, object cell, CreateProductCommand createProduct,
            Response response,
            object position)
        {
            if (cell != null && (double) cell > 0)
            {
                createProduct.Quantity = (double) cell;
            }
            else
            {
                response.AddError(
                    $"O Valor quantidade informada na celula {position} é inválida! A quantidade do produto deve ser superior a 0.");
            }
        }

        public static void ValidateDescription(int col, object cell, CreateProductCommand createProduct,
            Response response,
            object position)
        {
            if (cell!= null && !string.IsNullOrEmpty(cell.ToString()) && !string.IsNullOrWhiteSpace(cell.ToString()) && cell.ToString().Length < 51)
            {
                createProduct.Name = cell.ToString();
            }
            else
            {
                response.AddError(
                    $"O Valor da descrição informada na celula {position} é inválida! A quantiade máxima de caracter permitido é 50");
            }
        }

        public static void ValidateDeliveryDate(int col, object cell, CreateProductCommand createProduct,
            Response response,
            object position)
        {
            if (cell != null && !string.IsNullOrEmpty(cell.ToString()) && !string.IsNullOrWhiteSpace(cell.ToString()))
            {
                createProduct.DeliveredOn = DateTime.Parse(cell.ToString());
            }
            else
            {
                response.AddError(
                    $"O Valor da data de entrega informada na celula {position} é inválida! A data de entrega tem que ser superior a data atual");
            }
        }

        public static void ValidateContentType(string contentType, Response response)
        {
            if (!contentType.Equals("application/vnd.ms-excel") &&
                !contentType.Equals("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"))
            {
                response.AddError("O Formato de arquivo informado é inválido");
            }
        }
    }
}
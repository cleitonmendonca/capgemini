using System.Threading.Tasks;
using Application.Core.Behaviors;

namespace Application.Interfaces
{
    public interface IReadExcelService
    {
        Task<Response> OpenExcelFile();
    }
}
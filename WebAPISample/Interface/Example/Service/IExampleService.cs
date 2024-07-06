
using WebAPISample.DTOs.Example;
using WebAPISample.Entities;

namespace WebAPISample.Interface.Example.Service
{
    public interface IExampleService
    {
        Task<IEnumerable<AppExample>> GetAllExampleAsync();
        Task<AppExample> GetExampleIdAsync(int id);
        Task CreateExampleAsync(CreateExampleRequest request);
        Task UpdateExampleAsync(int id, UpdateExampleRequest request);
        Task DeleteExampleAsync(int id);
    }
}

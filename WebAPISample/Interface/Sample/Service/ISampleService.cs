
using WebAPISample.DTOs.Sample;
using WebAPISample.Entities;

namespace WebAPISample.Interface.Sample.Service
{
    public interface ISampleService
    {
        Task<IEnumerable<AppSample>> GetAllAsync();
        Task<AppSample> GetSampleIdAsync(int id);
        Task CreateSampleAsync(CreateSampleRequest request);
        Task UpdateSample(int id, UpdateSampleRequest request);
        Task DeleteSampleAsync(int id);
    }
}



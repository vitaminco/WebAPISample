using AutoMapper;
using WebAPISample.DTOs.Sample;
using WebAPISample.Entities;
using WebAPISample.Interface.Sample.Repository;
using WebAPISample.Interface.Sample.Service;

namespace WebAPISample.Respon.Sample.Service
{
    public class SampleService : ISampleService
    {
        private ISampleRepository sampleRepository;
        private IMapper mapper;
        private readonly ILogger<SampleService> logger;
        public SampleService(ISampleRepository sampleRepository, IMapper mapper, ILogger<SampleService> logger)
        {
            this.sampleRepository = sampleRepository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<IEnumerable<AppSample>> GetAllAsync()
        {
            var res = await sampleRepository.GetAllAsync();
            if (res == null)
            {
                logger.LogInformation($" No Sample items found");
            }
            return res;
        }

        public async Task<AppSample> GetSampleIdAsync(int id)
        {
            var res = await sampleRepository.GetByIDAsync(id);
            if (res == null)
            {
                logger.LogInformation($"No Sample item with Id {id} found.");
            }
            return res;
        }

        public async Task CreateSampleAsync(CreateSampleRequest request)
        {
            try
            {
                // DATA
                var dataAdd = mapper.Map<AppSample>(request);
                dataAdd.CreatedAt = DateTime.Now;
                // CREATE & SAVE
                await sampleRepository.CreateAsync(dataAdd);
                await sampleRepository.SaveChangeAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while creating the todo item.");
            }
        }
 
        public async Task UpdateSample(int id, UpdateSampleRequest request)
        {
            try
            {
                // FINDED
                var dataTable = await sampleRepository.GetByIDAsync(id);
                if (dataTable != null)
                {
                    var dataUpdate = mapper.Map(request, dataTable);
                    dataUpdate.UpdatedAt = DateTime.Now;
                    // UPDATE & SAVE
                    sampleRepository.Update(dataUpdate);
                    await sampleRepository.SaveChangeAsync();
                }
                else
                {
                    logger.LogInformation($" No Sample items found");
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while updating the todo item.");
            }
        }

        public async Task DeleteSampleAsync(int id)
        {
            try
            {
                // FINDED
                var data = await sampleRepository.GetByIDAsync(id);
                if (data != null)
                {
                    // DELETE & SAVE
                    sampleRepository.Delete(data);
                    await sampleRepository.SaveChangeAsync();
                }
                else
                {
                    logger.LogInformation($"No item found with the id {id}");
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while remove the todo item.");
            }
        }

        
    }
}

using AutoMapper;
using WebAPISample.Data;
using WebAPISample.DTOs.Example;
using WebAPISample.Entities;
using WebAPISample.Interface.Example.Repository;
using WebAPISample.Interface.Example.Service;
using WebAPISample.Interface.Sample.Repository;

namespace WebAPISample.Respon.Example.Service
{
    public class ExampleService : IExampleService
    {
        private readonly IExampleRepository exampleRepository;
        private readonly ISampleRepository sampleRepository1;
        private readonly IMapper mapper;
        private readonly ILogger<ExampleService> logger;

        public ExampleService(IExampleRepository exampleRepository, ISampleRepository sampleRepository1, IMapper mapper, ILogger<ExampleService> logger)
        {
            this.exampleRepository = exampleRepository;
            this.sampleRepository1 = sampleRepository1;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<IEnumerable<AppExample>> GetAllExampleAsync()
        {
            var res = await exampleRepository.GetAllAsync();
            if (res == null)
            {
                logger.LogInformation($" ko tìm thấy");
            }
            return res;
        }

        public async Task<AppExample> GetExampleIdAsync(int id)
        {
            var res = await exampleRepository.GetByIDAsync(id);
            if (res == null)
            {
                logger.LogInformation($"ko tìm thấy Id: {id}.");
            }
            return res;
        }

        public async Task CreateExampleAsync(CreateExampleRequest request)
        {
            try
            {
                // DATA
                var dataAdd = mapper.Map<AppExample>(request);

                var appSample = await sampleRepository1.GetByIDAsync(request.SampleId);


                /*check*/
                if (appSample == null)
                {
                    throw new Exception("Chưa nhập SampleId");
                }

                // Thêm data cho khóa ngoại
                dataAdd.SampleId = appSample.Id;

                dataAdd.CreatedAt = DateTime.Now;
                // CREATE & SAVE
                await exampleRepository.CreateAsync(dataAdd);
                await exampleRepository.SaveChangeAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while creating the todo item.");
            }
        }

        public async Task UpdateExampleAsync(int id, UpdateExampleRequest request)
        {
            try
            {
                // FINDED
                var dataTable = await exampleRepository.GetByIDAsync(id);
                if (dataTable != null)
                {
                    var dataUpdate = mapper.Map(request, dataTable);
                    //lấy id của sample để check khớp nhau
                    var appSample = await sampleRepository1.GetByIDAsync(request.SampleId.Value);

                    /*check*/
                    if (appSample == null)
                    {
                        throw new Exception("Chưa nhập SampleId");
                    }
                    dataUpdate.SampleId = appSample.Id;

                    dataUpdate.UpdatedAt = DateTime.Now;
                    // UPDATE & SAVE
                    exampleRepository.Update(dataUpdate);
                    await exampleRepository.SaveChangeAsync();
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

        public async Task DeleteExampleAsync(int id)
        {
            try
            {
                // FINDED
                var data = await exampleRepository.GetByIDAsync(id);
                if (data != null)
                {
                    // DELETE & SAVE
                    exampleRepository.Delete(data);
                    await exampleRepository.SaveChangeAsync();
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

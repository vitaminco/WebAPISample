using WebAPISample.Data;
using WebAPISample.Entities;
using WebAPISample.Infrastructure;
using WebAPISample.Interface.Sample.Repository;

namespace WebAPISample.Respon.Sample.Reponsitory
{
    public class SampleRepository : Repository<AppSample>, ISampleRepository
    {
        public SampleRepository(SampleDbContext context) : base(context)
        {
        }
    }
}

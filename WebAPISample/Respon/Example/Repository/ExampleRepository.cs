using Microsoft.EntityFrameworkCore;
using WebAPISample.Data;
using WebAPISample.Entities;
using WebAPISample.Infrastructure;
using WebAPISample.Interface.Example.Repository;

namespace WebAPISample.Respon.Example.Repository
{
    public class ExampleRepository : Repository<AppExample>, IExampleRepository
    {
        public ExampleRepository(SampleDbContext context) : base(context)
        {
        }
    }
}

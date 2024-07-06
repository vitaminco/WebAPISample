using Microsoft.EntityFrameworkCore;
using WebAPISample.Entities;

namespace WebAPISample.Data
{
    public class SampleDbContext:DbContext
    {
        public SampleDbContext(DbContextOptions<SampleDbContext> options) : base(options) { }

        public DbSet<AppSample> AppSamples { get; set; }
        public DbSet<AppExample> Examples { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //bảng Sample
            modelBuilder.Entity<AppSample>()
                 .Property(x => x.Title)
                 .HasMaxLength(100);
            modelBuilder.Entity<AppSample>()
                 .Property(x => x.Description)
                 .HasMaxLength(500);

            //bảng Example
            modelBuilder.Entity<AppExample>()
                 .Property(x => x.Title)
                 .HasMaxLength(100);
            modelBuilder.Entity<AppExample>()
                 .Property(x => x.Description)
                 .HasMaxLength(500);

            //Cấu hình khóa ngoại
            modelBuilder.Entity<AppExample>()
                        .HasOne(i => i.AppSample) //bảng AppExample
                        .WithMany(i => i.appExamples) //bảng AppSample
                        .HasForeignKey(i => i.SampleId); //khóa ngoại
        }
    }
}

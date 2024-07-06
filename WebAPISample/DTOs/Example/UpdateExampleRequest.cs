using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebAPISample.DTOs.Example
{
    public class UpdateExampleRequest
    {
        [StringLength(100)]
        public string Title { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        public int? SampleId { get; set; }
        public DateTime DueDate { get; set; }
    }
}

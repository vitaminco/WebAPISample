﻿namespace WebAPISample.Entities
{
    public class AppExample
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? SampleId { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        //
        public AppSample AppSample { get; set; }
    }
}

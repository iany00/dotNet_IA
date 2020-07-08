using System;

namespace CarStore.Domain.Models
{
    public class CarPhotos
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public string Name { get; set; }
        public DateTimeOffset UploadDate { get; set; } = DateTimeOffset.Now;
        public long FileSize { get; set; }

        public int CarId { get; set; }
    }
}

namespace apisistec.Dtos.File
{
    public class FileUploadedDto
    {
        public Guid cacheKey { get; set; }
        public string size { get; set; }
        public string tempPath { get; set; }
        public string name { get; set; }
    }
}

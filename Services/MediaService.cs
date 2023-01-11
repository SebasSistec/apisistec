using apisistec.Constants;
using apisistec.Entities;
using apisistec.Interfaces;
using Cuaier.Extensions;

namespace apisistec.Services
{
    public class MediaService : IMediaService
    {
        private readonly IWebHostEnvironment _env;

        public MediaService(IWebHostEnvironment env)
        {
            _env = env;
        }

        public void RemoveFile(string path) => File.Delete(Path.Combine(_env.WebRootPath, path));

        public IssueFiles SaveFileFromTmp(string root, string subRoot, string tempPath)
        {
            IssueFiles file = new();
            file.id = Guid.NewGuid();
            string name = Path.GetFileName(tempPath);
            string extension = Path.GetExtension(name);
             
            string rootPath = Path.Combine(_env.WebRootPath, root, subRoot);

            if (!Directory.Exists(rootPath))
                Directory.CreateDirectory(rootPath);

            string path = Path.Combine(rootPath, name);

            File.Move(tempPath, path);

            file.name = name;
            file.path = $"{root}/{subRoot}/{name}";
            file.extension = extension;
            file.createdAt = DateTime.Now;

            return file;
        }

        public string SaveToTmp(IFormFile file, string? name)
        {
            string ext = Path.GetExtension(file.FileName);
            name = name ?? Guid.NewGuid().ToString() + ext;
            //string TEMP_FOLDER = "C:/WINDOWS/TEMP";
            string tempPath = Path.Combine(Path.GetTempPath(), name);
            file.SaveAs(tempPath);
            return tempPath;
        }

        public string SizeConverter(long bytes)
        {
            decimal fileSize = new decimal(bytes);
            decimal kilobyte = new decimal(1024);
            decimal megabyte = new decimal(1024 * 1024);
            decimal gigabyte = new decimal(1024 * 1024 * 1024);

            switch (fileSize)
            {
                case var _ when fileSize < kilobyte:
                    return $"Less then 1KB";
                case var _ when fileSize < megabyte:
                    return $"{Math.Round(fileSize / kilobyte, 0, MidpointRounding.AwayFromZero):###.##}KB";
                case var _ when fileSize < gigabyte:
                    return $"{Math.Round(fileSize / megabyte, 2, MidpointRounding.AwayFromZero):###.##}MB";
                case var _ when fileSize >= gigabyte:
                    return $"{Math.Round(fileSize / gigabyte, 2, MidpointRounding.AwayFromZero):###.##}GB";
                default:
                    return "n/a";
            }
        }
    }
}

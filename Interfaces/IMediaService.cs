using apisistec.Entities;

namespace apisistec.Interfaces
{
    public interface IMediaService
    {
        string SaveToTmp(IFormFile file, string? name = null);
        IssueFiles SaveFileFromTmp(string root, string subRoot, string tempPath);
        void RemoveFile(string path);
        string SizeConverter(long bytes);
    }
}

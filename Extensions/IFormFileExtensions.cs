namespace Cuaier.Extensions
{
    public static class IFormFileExtensions
    {
        public static async Task SaveAsAsync(this IFormFile formFile, string filePath)
        {
            using (FileStream stream = new FileStream(filePath, FileMode.Create))
            {
                await formFile.CopyToAsync(stream);
            }
        }

        public static void SaveAs(this IFormFile formFile, string filePath)
        {
            using (FileStream stream = new FileStream(filePath, FileMode.Create))
            {
                formFile.CopyTo(stream);
            }
        }

        public static void Eliminar(string filePath)
        {
            File.Delete(filePath);
        }

    }
}

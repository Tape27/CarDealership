namespace CarDealership.Infrastructure.Repository
{
    public static class YandexCloudHelper
    {
        public static string GetFilenameFromUrl(string url)
        {
            if (!url.Contains("https://storage.yandexcloud.net/"))
            {
                throw new ArgumentException("This is not yandex cloud url");
            }

            int lastSlashIndex = url.LastIndexOf('/');
            string filePathWithSlash = url.Substring(lastSlashIndex);
            string filePathWithoutSlash = filePathWithSlash.Substring(1);
            return filePathWithoutSlash;
        }
    }
}

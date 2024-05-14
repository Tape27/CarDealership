using Amazon.S3;

namespace CarDealership.Infrastructure
{
    public class YandexCloudS3Context
    {
        private string _AccessKey;
        private string _SecretKey;
        public string ServiceUrl { get; }
        public string Bucket { get; }
        public string AdminKey { get; }
        public string CarKey { get; }
        public AmazonS3Client S3Client { get; }
        public YandexCloudS3Context(string accessKey, string secretKey, string serviceUrl,
            string bucket, string adminKey, string carKey)
        {
            _AccessKey = accessKey;
            _SecretKey = secretKey;
            ServiceUrl = serviceUrl;
            Bucket = bucket;
            AdminKey = adminKey;
            CarKey = carKey;

            S3Client = new AmazonS3Client(_AccessKey, _SecretKey,
                new AmazonS3Config
                {
                    ServiceURL = ServiceUrl,
                    ForcePathStyle = true
                });
        }
        
    }
}

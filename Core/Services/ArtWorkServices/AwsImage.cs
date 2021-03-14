using System.IO;
using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.Extensions.Configuration;

namespace Core.Services.ArtWorkServices
{
    public interface IAwsImage
    {
        string UploadFile();
    }

    public class AwsImage : IAwsImage
    {
        private readonly string _bucketName;
        private readonly string _secretKey;
        private readonly string _accessKey;

        public AwsImage(IConfiguration configuration)
        {
            _bucketName = configuration["Aws:Bucket"];
            _accessKey = configuration["Aws:AccessKey"];
            _secretKey = configuration["Aws:SecretKey"];
        }

        public string UploadFile()
        {
            var client = new AmazonS3Client(_accessKey, _secretKey, RegionEndpoint.USEast1);

            var file = new FileInfo(@"/home/stanzu10/README.md");
            var folderPath = "Images/";

            var request = new PutObjectRequest()
            {
                InputStream = file.OpenRead(),
                BucketName = _bucketName,
                Key = folderPath
            };
            var response = client.PutObjectAsync(request);
            return "";
        }
    }
}
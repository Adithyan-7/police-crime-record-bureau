using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Amazon;
using Amazon.S3;
using Amazon.S3.Transfer;
using Amazon.Runtime;
using Amazon.S3.Model;

namespace PoliceCrimeRecordBureau
{

    /// <summary>
    /// Summary description for AmazoneCloud
    /// </summary>
    public class AmazoneCloud
    {
        public bool UploadToCloud(string fileNameInS3, string ReportPath)
        {
            string bucketName = "mahima-project-trinity"; ///bucketName here...............
            string subDirectoryInBucket = ""; //... if any directory...........

            IAmazonS3 client = new AmazonS3Client(RegionEndpoint.USEast1);
            TransferUtility utility = new TransferUtility(client);
            TransferUtilityUploadRequest request = new TransferUtilityUploadRequest();

            if (subDirectoryInBucket == "" || subDirectoryInBucket == null)
            {
                request.BucketName = bucketName; //no subdirectory just bucket name  
            }
            else
            {   // subdirectory and bucket name  
                request.BucketName = bucketName + @"/" + subDirectoryInBucket;
            }
            request.Key = fileNameInS3; //file name up in S3  
                                        //request.InputStream = localFilePath;
            request.FilePath = ReportPath;
            utility.Upload(request); //commensing the transfer  

            return true; //indicate that the file was sent  
        }

        public void DownloadFromCloud(string downloadpath, string DonwloadReportname)
        {

            string path = downloadpath;

            RegionEndpoint bucketRegion = RegionEndpoint.USEast1;
            IAmazonS3 client = new AmazonS3Client(bucketRegion);

            string accessKey = System.Configuration.ConfigurationManager.AppSettings["AWSAccessKey"];
            string secretKey = System.Configuration.ConfigurationManager.AppSettings["AWSSecretKey"];
            AmazonS3Client s3Client = new AmazonS3Client(new BasicAWSCredentials(accessKey, secretKey), Amazon.RegionEndpoint.USEast1);
            string objectKey = DonwloadReportname;//..................... download file name.................
                                                  //EMR is folder name of the image inside the bucket 
            GetObjectRequest request = new GetObjectRequest();
            request.BucketName = "mahima-project-trinity";//.................Bucket Name Here.......................
            request.Key = objectKey;
            GetObjectResponse response = s3Client.GetObject(request);
            response.WriteResponseStreamToFile(path);

        }




    }
}
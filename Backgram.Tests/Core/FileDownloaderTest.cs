using Backgram.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Backgram.Tests.Core
{
    [TestClass]
    public class FileDownloaderTest: BaseTestClass
    {
        private string testDir;

        [TestInitialize]
        public void Setup()
        {
            testDir = Path.Combine(TestContext.TestRunDirectory, "testDownloadedFiles");
            Directory.CreateDirectory(testDir);
        }

        [TestMethod]
        public void ConstructorTestNotNull()
        {
            FileDownloader downloader = new FileDownloader();
            Assert.IsNotNull(downloader);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task DownloadFileAsyncTestUriArgumentNullException()
        {
            FileDownloader downloader = new FileDownloader();
            var file = await downloader.DownloadFileAsync(null, Path.Combine(testDir, "anotherTest.txt"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task DownloadFileAsyncTestFileArgumentNullException()
        {
            FileDownloader downloader = new FileDownloader();
            var file = await downloader.DownloadFileAsync(new Uri("http://www.google.com/file.gif"), "");
        }

        [TestMethod]
        public async Task DownloadFileAsyncShouldDownloadFile()
        {
            FileDownloader downloader = new FileDownloader();
            var file = await downloader.DownloadFileAsync(new Uri("http://humanstxt.org/humans.txt"), Path.Combine(testDir, "humans.txt")); //TODO: change to  file://

            Assert.IsTrue(file != null && file.Exists);
        }

        [TestMethod]
        public void DownloadFilesShouldDownloadAllFilesAsync()
        {
            FileDownloader downloader = new FileDownloader();
            var localDir = Directory.CreateDirectory(Path.Combine(testDir, "testDownloadFilesToDir"));

            List<Uri> uriList = new List<Uri> //TODO: change URI to file://
            {
                new Uri("http://humanstxt.org/humans.txt"),
                new Uri("http://www.google.com/humans.txt"),
                new Uri("https://github.com/humans.txt")
            };

            List<FileInfo> resultList = null;
            //fires the download of the files.
            resultList = Task.Run(() => downloader.DownloadFiles(uriList, localDir.FullName)).Result;
            //sleep for 1s making sure all files are downloaded.
            Thread.Sleep(1000);

            Assert.IsNotNull(resultList);
            Assert.IsTrue(resultList.Count == 3);
        }
    }
}

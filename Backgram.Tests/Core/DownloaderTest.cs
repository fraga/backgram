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
    public class DownloaderTest
    {
        private TestContext testContextInstance;
        private string testDir;
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [TestInitialize]
        public void Setup()
        {
            testDir = Path.Combine(TestContext.TestRunDirectory, "testDownloadedFiles");
            Directory.CreateDirectory(testDir);
        }

        [TestMethod]
        public void ConstructorTestNotNull()
        {
            Downloader downloader = new Downloader();
            Assert.IsNotNull(downloader);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task DownloadFileAsyncTestUriArgumentNullException()
        {
            Downloader downloader = new Downloader();
            var file = await downloader.DownloadFileAsync(null, Path.Combine(testDir, "anotherTest.txt"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task DownloadFileAsyncTestFileArgumentNullException()
        {
            Downloader downloader = new Downloader();
            var file = await downloader.DownloadFileAsync(new Uri("http://www.google.com/file.gif"), "");
        }

        [TestMethod]
        public async Task DownloadFileAsyncShouldDownloadFile()
        {
            Downloader downloader = new Downloader();
            var file = await downloader.DownloadFileAsync(new Uri("http://humanstxt.org/humans.txt"), Path.Combine(testDir, "humans.txt")); //TODO: change to  file://

            Assert.IsTrue(file != null && file.Exists);
        }

        [TestMethod]
        public void DownloadFilesShouldDownloadAllFilesAsync()
        {
            Downloader downloader = new Downloader();
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
            Thread.Sleep(new TimeSpan(0, 0, 1));

            Assert.IsNotNull(resultList);
            Assert.IsTrue(resultList.Count == 3);
        }
    }
}

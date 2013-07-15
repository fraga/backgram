using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Backgram.Compress;
using System.IO;
using System.Text;

namespace Backgram.Tests.Compress
{
    [TestClass]
    public class ZiplibTest
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
            testDir = Path.Combine(TestContext.TestRunDirectory, "testFiles");
            CreateTestFiles();
        }

        public void CreateTestFiles()
        {
            if (TestContext != null)
            {
                var dirInfo = Directory.CreateDirectory(testDir);

                for (int i = 0; i <= 4; i++)
                {
                    using(StreamWriter writer = new StreamWriter(Path.Combine(dirInfo.FullName, Guid.NewGuid().ToString())))
                    {
                        writer.Write(Guid.NewGuid().ToString());
                        writer.Flush();
                        writer.Close();
                    }
                }
            }
        }

        [TestMethod]
        public void TestConstructorNotNull()
        {
            Ziplib ziplib = new Ziplib();
            Assert.IsNotNull(ziplib);
        }

        [TestMethod]
        public void TestCompress()
        {
            var compressedFileName = Path.Combine(TestContext.TestRunDirectory, "testFiles.zip");
            Ziplib ziplib = new Ziplib(Path.Combine(testDir));
            ziplib.Compress(compressedFileName);
            Assert.IsTrue(File.Exists(compressedFileName));
        }
    }
}

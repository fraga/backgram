using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Checksums;



namespace Backgram.Compress
{
    public class Ziplib
    {
        public string DirToCompress { get; set; }

        public Ziplib()
        {
        }

        public Ziplib(string dirToCompress)
        {
            DirToCompress = dirToCompress;
        }

        /// <summary>
        /// Calculates a file checksum
        /// </summary>
        /// <param name="pathToFile">Full path to the file</param>
        /// <returns></returns>
        public string CalculateCheckSum(string pathToFile)
        {
            Crc32 crc32 = new Crc32();
            string checksum = string.Empty;

            try
            {
                FileStream fileStream = new FileStream(pathToFile, FileMode.Open);
                byte[] fileBuffer = new byte[fileStream.Length];
                fileStream.Read(fileBuffer, 0, fileBuffer.Length);
                crc32.Update(fileBuffer, 0, fileBuffer.Length);
                checksum = crc32.Value.ToString();
            }
            catch (Exception)
            {
            }

            return checksum;
        }

        /// <summary>
        /// Compress the folder set in the DirToCompress property
        /// </summary>
        /// <param name="fileOutputPath">The zipped file</param>
        public void Compress(string fileOutputPath)
        {
            try
            {
                FileStream outputFile = new FileStream(fileOutputPath, FileMode.Create);
                ZipOutputStream outputCompressed = new ZipOutputStream(outputFile);

                if (!string.IsNullOrEmpty(DirToCompress) && Directory.Exists(DirToCompress))
                {
                    var files = new DirectoryInfo(DirToCompress).GetFiles();

                    foreach (var file in files)
                    {
                        FileStream fileStream = new FileStream(file.FullName, FileMode.Open);
                        outputCompressed.PutNextEntry(new ZipEntry(file.Name));
                        fileStream.CopyTo(outputCompressed);
                    }
                }

                outputCompressed.IsStreamOwner = true;
                outputCompressed.Close();
            }
            catch (OutOfMemoryException exception)
            {
                throw exception;
            }
            catch (ZipException exception)
            {
                throw exception;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}

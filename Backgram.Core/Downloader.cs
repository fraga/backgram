using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Backgram.Core
{
    /// <summary>
    /// Downloads files or a set of files from URI paths asynchronously
    /// </summary>
    public class Downloader
    {
        /// <summary>
        /// Download a set of URI locations as fast as possible, as async as possible
        /// </summary>
        /// <param name="uriToDownload">The list of Uri to download</param>
        /// <param name="destinationDirPath">The directory in which the files will be downloaded to</param>
        /// <returns></returns>
        public List<FileInfo> DownloadFiles(List<Uri> uriToDownload, string destinationDirPath)
        {
            List<FileInfo> downloadedFiles = new List<FileInfo>();

            if (uriToDownload == null || string.IsNullOrEmpty(destinationDirPath))
                return downloadedFiles;

            Parallel.ForEach(uriToDownload, async u =>
                {
                    await DownloadFileAsync(
                        u, Path.Combine(destinationDirPath, Guid.NewGuid().ToString())).ContinueWith(
                            async f =>
                            {
                                downloadedFiles.Add(await f);
                            });

                }
                );

            return downloadedFiles;
        }

        /// <summary>
        /// Downloads a single URI path async
        /// </summary>
        /// <param name="uri">The file URI</param>
        /// <param name="fullFilePath">Full file path to be created as download</param>
        /// <returns></returns>
        public async Task<FileInfo> DownloadFileAsync(Uri uri, string fullFilePath)
        {
            if (uri == null || string.IsNullOrEmpty(fullFilePath))
                throw new ArgumentNullException("URI and Destination Path should not be null");

            using (FileStream newFile = new FileStream(fullFilePath, FileMode.CreateNew))
            {
                using (HttpClient client = new HttpClient())
                {
                    var httpStream = await client.GetStreamAsync(uri);

                    await httpStream.CopyToAsync(newFile);
                }

                newFile.Flush();
            }

            return new FileInfo(fullFilePath);
        }
    }
}

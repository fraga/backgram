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
    public class Downloader
    {
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

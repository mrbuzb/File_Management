using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_Management_Service.Services;

public interface IStorageService
{
    Task CreateFolderAsync(string folderPath);
    Task DeleteFolderAsync(string folderPath);
    Task UploadFileAsync(string filePath, Stream strem);
    Task DeleteFileAsync(string filePath);
    Task<List<string>> GetFoldersAndFilesAsync(string path);
    Task<Stream> DownloadFileAsync(string filePath);
    Task<Stream> DownloadFolderAsZipAsync(string folderPath);
}

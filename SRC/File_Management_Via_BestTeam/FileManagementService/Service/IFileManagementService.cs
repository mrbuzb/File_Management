using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagementService.Service;

public interface IFileManagementService
{
    Task CreateFolderAsync(string folderPath);
    Task DeleteFolderAsync(string folderPath);
    Task UploadFileAsync(string filePath, Stream strem);
    Task DeleteFileAsync(string filePath);
    Task<List<string>> GetFoldersAndFilesAsync(string path);
    Task<Stream> DownloadFileAsync(string filePath);
    Task<Stream> DownloadFolderAsZipAsync(string folderPath);
}

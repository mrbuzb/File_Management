using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagementService.Service;

public class FileManagementService : IFileManagementService
{
    public Task CreateFolderAsync(string folderPath)
    {
        throw new NotImplementedException();
    }

    public Task DeleteFileAsync(string filePath)
    {
        throw new NotImplementedException();
    }

    public Task DeleteFolderAsync(string folderPath)
    {
        throw new NotImplementedException();
    }

    public Task<Stream> DownloadFileAsync(string filePath)
    {
        throw new NotImplementedException();
    }

    public Task<Stream> DownloadFolderAsZipAsync(string folderPath)
    {
        throw new NotImplementedException();
    }

    public Task<List<string>> GetFoldersAndFilesAsync(string path)
    {
        throw new NotImplementedException();
    }

    public Task UploadFileAsync(string filePath, Stream strem)
    {
        throw new NotImplementedException();
    }
}

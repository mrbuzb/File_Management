using File_Management_Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagementService.Service;

public class FileManagementServicee : IFileManagementService
{
    private IStorageService _storageService;
    public FileManagementServicee(IStorageService storageService)
    {
        _storageService = storageService;
    }
    public async Task CreateFolderAsync(string folderPath)
    {
        await _storageService.CreateFolderAsync(folderPath);
    }

    public async Task DeleteFileAsync(string filePath)
    {
       await _storageService.DeleteFileAsync(filePath);
    }

    public async Task DeleteFolderAsync(string folderPath)
    {
        await _storageService.DeleteFolderAsync(folderPath);
    }

    public async Task<Stream> DownloadFileAsync(string filePath)
    {
      return await _storageService.DownloadFileAsync(filePath);
    
    }

    public async Task<Stream> DownloadFolderAsZipAsync(string folderPath)
    {
       return await _storageService.DownloadFolderAsZipAsync(folderPath);
    }

    public Task<List<string>> GetFoldersAndFilesAsync(string path)
    {
        return _storageService.GetFoldersAndFilesAsync(path);
    }

    public async Task UploadFileAsync(string filePath, Stream strem)
    {
      await  _storageService.UploadFileAsync(filePath, strem);
    }
}

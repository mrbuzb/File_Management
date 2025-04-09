using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_Management_Service.Services;

public class LocalStorageService : IStorageService
{
    private string _dataPath;
    public LocalStorageService()
    {
        _dataPath = Path.Combine(Directory.GetCurrentDirectory(), "data");

        if (!Directory.Exists(_dataPath))
        {
            Directory.CreateDirectory(_dataPath);
        }
    }


    public async Task CreateFolderAsync(string folderPath)
    {
        var mainPath = Path.Combine(_dataPath, folderPath);
        ValidationDirectoryPath(mainPath);
        Directory.CreateDirectory(mainPath);
    }

    public async Task DeleteFileAsync(string filePath)
    {
        var _filePath = Path.Combine(_dataPath, filePath);

        if (!File.Exists(_filePath))
        {
            throw new Exception("This kind of file is not exsists to delete");
        }

        File.Delete(_filePath);
    }

    public async Task DeleteFolderAsync(string folderPath)
    {
        var _directoryPath = Path.Combine(_dataPath, folderPath);

        if (!Directory.Exists(_directoryPath))
        {
            throw new Exception("There is no any folder to delete");
        }

        Directory.Delete(_directoryPath);
    }

    public async Task<Stream> DownloadFileAsync(string filePath)
    {
        var _filePath = Path.Combine(_dataPath, filePath);

        if (!File.Exists(_filePath))
        {
            throw new Exception("File not found to download");
        }

        var stream = new FileStream(_filePath, FileMode.Open, FileAccess.Read);
        return stream;
    }

    public async Task<Stream> DownloadFolderAsZipAsync(string folderPath)
    {
        var _folderPath = Path.Combine(_dataPath, folderPath);

        if (!Directory.Exists(_folderPath))
        {
            throw new Exception("There is no folder to download");
        }

        var zipPath = _folderPath + ".zip";

        ZipFile.CreateFromDirectory(_folderPath, zipPath);

        var stream = new FileStream(zipPath, FileMode.Open, FileAccess.Read);
        return stream;
    }




    public async Task<List<string>> GetFoldersAndFilesAsync(string path)
    {
        var directoryPath = Path.Combine(_dataPath, path);

        var parentPath = Directory.GetParent(directoryPath);

        if (!Directory.Exists(parentPath.FullName))
        {
            throw new Exception($"This {parentPath.FullName} is not exsists");
        }

        var collectItems = Directory.GetFileSystemEntries(directoryPath).ToList();

        collectItems = collectItems.Select(p => p.Remove(0, directoryPath.Length + 1)).ToList();

        return collectItems;
    }



    public async Task UploadFileAsync(string filePath, Stream strem)
    {
        var _filePath = Path.Combine(_dataPath, filePath);

        var parentPath = Directory.GetParent(_filePath);

        if (!Directory.Exists(parentPath.FullName))
        {
            throw new Exception("Parent pasth not found in UploadFileAsync");
        }

        using (FileStream fileStream = new FileStream(_filePath, FileMode.Create, FileAccess.Write))
        {
            strem.CopyTo(fileStream);
        }
    }


    private void ValidationDirectoryPath(string directoryPath)
    {
        if (Directory.Exists(directoryPath))
        {
            throw new Exception("This kind of directory already has been created");
        }

        var parentPath = Directory.GetParent(directoryPath);

        if (!Directory.Exists(parentPath.FullName))
        {
            throw new Exception("There is no any kind of parent path for this folder");
        }
    }

}

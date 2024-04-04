using System.IO;

public class FileService : IFileService
{    
    public bool HasDatExtension(string path)
    {
        var extension = Path.GetExtension(path).ToLower();
        return extension == ".dat";
    }

    public string ReadFile(string path)
    {
        IFileStrategy strategy = GetFileStrategy(path);
        return ReadFile(strategy, path);
    }

    public void WriteFile(string path, string content)
    {
        IFileStrategy strategy = GetFileStrategy(path);
         WriteFile(strategy, path,content);     
    }

    private string ReadFile(IFileStrategy fileStrategy, string path)
    {
        return fileStrategy.ReadFile(path);
    }

    private void WriteFile(IFileStrategy fileStrategy, string path, string content)
    {
        fileStrategy.WriteFile(path, content);     
    }

    private IFileStrategy GetFileStrategy(string keyFile)
    {
        IFileStrategy fileStrategy = new TextFileStrategy();
        if(HasDatExtension(keyFile) )
        {
             fileStrategy = new ByteFileStrategy();    
        }
        return fileStrategy;
    }
}
    
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming.Cryptography.Cli.Test;

// Definer en test fixture-samling
[CollectionDefinition("FileFixture")]
public class FileFixtureCollection : ICollectionFixture<FileFixture>
{}

public  class FileFixture : IDisposable
{
    private Dictionary<string, string> FilesCollection { get; } = new Dictionary<string, string>();

    public string GetKatalog(string key)
    {
        return FilesCollection[key];
    }

    public FileFixture()
    {
        if (!Directory.Exists("./Testkataloger"))
        {
            // Opprett katalogen
            Directory.CreateDirectory("./Testkataloger");
        }

        FilesCollection.Add("TestDecryptCommand", "./Testkataloger/TestDecryptCommand");
        FilesCollection.Add("TestEncryptCommand", "./Testkataloger/TestEncryptCommand");
        FilesCollection.Add("TestGenerateKeyCommand", "./Testkataloger/TestGenerateKeyCommand");
        FilesCollection.Add("TestProtectCommand", "./Testkataloger/TestProtectCommand");
        FilesCollection.Add("TestUnprotectCommand", "./Testkataloger/TestUnprotectCommand");       

        foreach (var directory in FilesCollection.Values)
        {
            if (!Directory.Exists(directory))
            {             
                Directory.CreateDirectory(directory);
            }
            else
            {
                FjernFilerIKatalog(directory);
            }

            File.Copy("./testfiles/Key.unprotected", $"{directory}/Key.unprotected");
            File.Copy("./testfiles/Vector.unprotected", $"{directory}/Vector.unprotected"); 
        }

       
       
    }

    private static void FjernFilerIKatalog(string directoryPath)
    {
        // Hent alle filene i katalogen
        var files = Directory.GetFiles(directoryPath);

        // Loop gjennom alle filene og slett dem
        foreach (var file in files)
        {
            File.Delete(file);
        }
    }

    public void Dispose()
    {        
    }
}

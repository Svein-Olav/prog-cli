using Cocona;
using Cocona.Command;
using Cocona.Help.DocumentModel;
using System;


public class EncryptCommand
{
    private readonly ICryptographiService _cryptographiService;
    private readonly IFileService _fileService;

    public EncryptCommand(ICryptographiService service, IFileService fileService)
    {
        _cryptographiService = service;
        _fileService = fileService;
    }

    [Command("Encrypt", Description = "Krypterer tekst ved å bruke Key and an IV. Eksempel: dotnet run encrypt --key-file .\\testfiles\\key.unprotected .\\testfiles\\vector.unprotected \"teststreng\"")]
    public string Encrypt(
         [Option(Description = "File som inneholder Key på base64format")] string keyFile, 
         [Option(Description = "FFile som inneholder IV på base64format")] string ivFile, 
         [Argument(Description = "Tekst som skal krypteres")] string tekst)
    {
                        
        var key = _fileService.ReadFile(keyFile);
        var iv = _fileService.ReadFile(ivFile);
        
        var encryptText = _cryptographiService.Encrypt(key, iv, tekst);

        Console.WriteLine(encryptText);
        return encryptText;

    }

    


}

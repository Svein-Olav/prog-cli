using Microsoft.Extensions.Hosting;

public class UnprotectKeyCommand
{
    private readonly ICryptographiService _cryptographiService;
    private readonly IFileService _fileService;    

    public UnprotectKeyCommand(ICryptographiService cryptoService, IFileService fileService)
    {
        _cryptographiService = cryptoService;
        _fileService = fileService;

    }

    
    [Command("Unprotectkey", 
            Description = @"Denne kommandoen gjør det mulig å om gjøre en proteced fil dvs .dat til en vanlig lesbar fil.")]
    public void UnprotectKey(
        [Option(Description = "File som inneholder kryptert key (Key.dat)")] string keyFile, 
        [Option(Description = "File som inneholder kryptert vector (Vector.dat) ")] string ivFile)
    {
        if (!_fileService.HasDatExtension(keyFile) || !_fileService.HasDatExtension(ivFile))
        {
            Console.WriteLine("The key and IV files must have the .dat extension");
            return;
        }
        
        _cryptographiService.unprotectkey(keyFile, ivFile);

        var currentUser = Environment.UserName;
        Console.WriteLine($"Key og IV ble dekryptert med bruker {currentUser}");

    }    
}

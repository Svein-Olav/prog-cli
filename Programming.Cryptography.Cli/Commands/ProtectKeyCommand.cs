public class ProtectKeyCommand
{
    private readonly ICryptographiService _cryptographiService;
    private readonly IFileService _fileService;    

    public ProtectKeyCommand(ICryptographiService cryptoService, IFileService fileService)
    {
        _cryptographiService = cryptoService;
        _fileService = fileService;

    }

    
    [Command("Protectkey", Description = @"Bruker DPAPI for å beskytte filene med Key.unprotected og Vector.unprotected. Key.unprotected and Vector.unprotected blir skrevet til filene Key.dat og Vector.dat. Det er kun brukeren som har tilgang til filene og filene kan ikke flyttes til en annen maskin.")]
    public void  ProtectKey(
        [Option(Description = "Key.unprotected fil ")] string keyFile, 
        [Option(Description = "Vector.unprotected fil")] string ivFile)
    {        
        
        _cryptographiService.protectkey(keyFile, ivFile);

        var currentUser = Environment.UserName;
        Console.WriteLine($"Key og IV ble kryptert med bruker {currentUser}");
        

    }
    
}

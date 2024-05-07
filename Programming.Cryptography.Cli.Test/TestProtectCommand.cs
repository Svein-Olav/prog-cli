using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming.Cryptography.Cli.Test;
[Collection("FileFixture")]
public class TestProtectCommand
{
    private readonly string _testKatalog;

    public TestProtectCommand(FileFixture fileFixture)
    {
        _testKatalog = fileFixture.GetKatalog("TestProtectCommand");
    }

    [Fact]
        public void SimpleTest()
        {
        // Arrange       
      
        var CryptographiService = new CryptographiService();
        var FileService = new FileService();

        var mut = new ProtectKeyCommand(CryptographiService, FileService);

        // Act
        var user = mut.ProtectKey($"{_testKatalog}/Key.unprotected", $"{_testKatalog}/Vector.unprotected");


        // Assert
        Assert.True(File.Exists($"{_testKatalog}/Key.dat"));
        Assert.True(File.Exists($"{_testKatalog}/Vector.dat"));
        Assert.Equal(user, Environment.UserName);

    }
}

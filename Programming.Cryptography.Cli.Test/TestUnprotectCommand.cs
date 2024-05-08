using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming.Cryptography.Cli.Test;
[Collection("FileFixture")]
public class TestUnprotectCommand
{
    private readonly string _testKatalog;

    public TestUnprotectCommand(FileFixture fileFixture)
    {
        _testKatalog = fileFixture.GetKatalog("TestEncryptCommand");
    }

    [Fact]
        public void SimpleTest()
        {
        // Arrange       

      

        var CryptographiService = new CryptographiService();
        var FileService = new FileService();

        var protectKeyCommand = new ProtectKeyCommand(CryptographiService, FileService);
        protectKeyCommand.ProtectKey($"{_testKatalog}/Key.unprotected", $"{_testKatalog}/Vector.unprotected");
         
        File.Delete($"{_testKatalog}/Key.unprotected");
        File.Delete($"{_testKatalog}/Vector.unprotected");    

        var sut = new UnprotectKeyCommand(CryptographiService, FileService);
             

        // Act
            sut.UnprotectKey($"{_testKatalog}/Key.dat", $"{_testKatalog}/Vector.dat");



        // Assert
        string orginalKey = File.ReadAllText("./testfiles/Key.unprotected");
        string orginalVector = File.ReadAllText("./testfiles/Vector.unprotected");

        string unprotectedKey = File.ReadAllText($"{_testKatalog}/Key.unprotected");
        string unprotectedVector = File.ReadAllText($"{_testKatalog}/Vector.unprotected");

        Assert.True(File.Exists($"{_testKatalog}/Key.unprotected"));
        Assert.True(File.Exists($"{_testKatalog}/Vector.unprotected"));
        Assert.Equal(orginalKey, unprotectedKey);
        Assert.Equal(orginalVector, unprotectedVector);

    }
    }

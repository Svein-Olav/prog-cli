using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming.Cryptography.Cli.Test;
[Collection("FileFixture")]
public class TestGenerateKeyCommand
{
    private readonly string _testKatalog;

    public TestGenerateKeyCommand(FileFixture fileFixture)
    {
        _testKatalog = fileFixture.GetKatalog("TestGenerateKeyCommand");
    }
    [Fact]
        public void SimpleTest()
        {
        // Arrange
        

        File.Delete($"{_testKatalog}/Key.unprotected");
        File.Delete($"{_testKatalog}/Vector.unprotected");

        var CryptographiService = new CryptographiService();
            var FileService = new FileService();

            var sut = new GenerateKeyCommand(CryptographiService, FileService);
          


            // Act
                sut.GenerateKey($"{_testKatalog}");


        // Assert
        Assert.True(File.Exists($"{_testKatalog}/Key.unprotected"));
        Assert.True(File.Exists($"{_testKatalog}/Vector.unprotected"));

    }
    }

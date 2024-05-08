using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming.Cryptography.Cli.Test;
[Collection("FileFixture")]
public class TestEncrypt
   {
    private readonly string _testKatalog;

    public TestEncrypt(FileFixture fileFixture)
    {
        _testKatalog = fileFixture.GetKatalog("TestEncryptCommand");
    }

    [Fact]
        public void SimpleTest()
        {
            // Arrange
            var CryptographiService = new CryptographiService();
            var FileService = new FileService();

            var sut = new EncryptCommand(CryptographiService, FileService);
        

        // Act
        var stringHexDec = sut.Encrypt($"{_testKatalog}/Key.unprotected", $"{_testKatalog}/Vector.unprotected", "TestString");

            // Assert
            Assert.Equal("82A5193FCF471B6D78C20E0304C79C88", stringHexDec);
        }
    }

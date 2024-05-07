using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming.Cryptography.Cli.Test;
[Collection("FileFixture")]
public class TestDecrypt
   {

    private readonly string _testKatalog;

    public TestDecrypt(FileFixture fileFixture)
    {
        _testKatalog = fileFixture.GetKatalog("TestDecryptCommand");
    }
    [Fact]
        public void SimpleTest()
        {
            // Arrange
            var CryptographiService = new CryptographiService();
            var FileService = new FileService();

            var mut = new DecryptCommand(CryptographiService, FileService);             

            // Act
            var dekryptertTekst = mut.Decrypt($"{_testKatalog}/Key.unprotected", $"{_testKatalog}/Vector.unprotected", "82A5193FCF471B6D78C20E0304C79C88");


            // Assert
            Assert.Equal("TestString", dekryptertTekst);


        }
    }

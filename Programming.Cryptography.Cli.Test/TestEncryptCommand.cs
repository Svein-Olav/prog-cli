using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming.Cryptography.Cli.Test;
public class TestEncrypt
   {
        [Fact]
        public void SimpleTest()
        {
            // Arrange
            var CryptographiService = new CryptographiService();
            var FileService = new FileService();

            var mut = new EncryptCommand(CryptographiService, FileService);


            // Act
               var stringHexDec = mut.Encrypt("./testfiles/Key.unprotected", "./testfiles/Vector.unprotected", "TestString");


            // Assert
            Assert.Equal("82A5193FCF471B6D78C20E0304C79C88", stringHexDec);


        }
    }

namespace Programming.Datastructure.List.Test;

public class UnitTestCryptographiyService
{
    [Fact]
    public void Decrypt()
    {
        // Arrange
        ICryptographiService sut = new CryptographiService(); 
        var key = sut.GenerateKey();

        // Act

        var returValue = sut.Encrypt(key.Key, key.IV, "Hello World");

        // Assert
        Assert.Equal("Hello World", sut.Decrypt(key.Key, key.IV, returValue));


    }

    

    

}
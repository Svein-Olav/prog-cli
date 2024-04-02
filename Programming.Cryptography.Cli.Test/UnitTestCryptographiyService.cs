namespace Programming.Datastructure.List.Test;

public class UnitTestCryptographiyService
{
    [Fact]
    public void Decrypt()
    {
        // Arrange
        ICryptographiService mut = new CryptographiService(); 
        var key = mut.GenerateKey();

        // Act

        var returValue = mut.Encrypt(key.Key, key.IV, "Hello World");

        // Assert
        Assert.Equal("Hello World", mut.Decrypt(key.Key, key.IV, returValue));


    }

    [Fact]
    public void Encrypt()
    {

    }

    

}
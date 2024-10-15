namespace Kek.Net.ErrorHandling.Tests;

public class ErrorTests
{
    [Fact]
    public void Error_Should_SaveMessage()
    {
        // Arrange
        var message = "Test error";
        
        // Act
        var sut = new Error(message);
        
        // Assert
        Assert.Equal(message, sut.Message);
    }

    [Fact]
    public void Error_Should_SaveMetadata()
    {
        // Arrange
        var metadata = new { TestData = 1 };
        var metadataKey = "test";
        
        // Act
        var sut = new Error("test").WithMetadata(metadataKey, metadata);
        
        // Assert
        Assert.Contains(metadataKey, sut.Metadata.Keys);
        Assert.Equal(metadata, sut.Metadata[metadataKey]);
    }
}
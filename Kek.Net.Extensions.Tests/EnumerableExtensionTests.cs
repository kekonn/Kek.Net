namespace Kek.Net.Extensions.Tests;

public class EnumerableExtensionTests
{
    class RecursiveItem
    {
        public ICollection<RecursiveItem> Text { get; set; } = Array.Empty<RecursiveItem>();
    }
    
    [Fact]
    public void Flatten_Should_ReturnEmptyForEmptyCollection()
    {
        // Arrange
        var sut = Array.Empty<object>();
        
        // Act
        var result = sut.Flatten(e => Array.Empty<object>());
        
        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void Flatten_Should_FlattenCollections()
    {
        // Arrange
        var collection = new RecursiveItem[] {
            new RecursiveItem()
            {
                Text = [
                    new RecursiveItem()
                ]
            },
            new RecursiveItem()
            {
                Text = [
                    new RecursiveItem()
                    {
                        Text = new List<RecursiveItem>()
                    }
                ]
            }
        };
        
        // Act
        var result = collection.Flatten(e => e.Text);
        
        // Arrange
        Assert.Equal(4, result.Count());
    }
}
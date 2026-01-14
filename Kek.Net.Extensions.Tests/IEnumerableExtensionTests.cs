namespace Kek.Net.Extensions.Tests;

public class IEnumerableExtensionTests
{
    [Fact]
    public void Flatten_ShouldThrow_IfNull()
    {
        Assert.Throws<ArgumentNullException>(() => IEnumerableExtensions.Flatten<string>(null, null));
        Assert.Throws<ArgumentNullException>(() => Array.Empty<string>().Flatten(null));
        Assert.Throws<ArgumentNullException>(() => IEnumerableExtensions.Flatten<object>(null, s => []));
    }

    [Fact]
    public void Flatten_ShouldReturn_EmptyCollectionOnEmptyCollection()
    {
        // Arrange
        var empty = Array.Empty<object>();

        // Act
        var result = empty.Flatten(o => []);

        // Assert
        Assert.IsAssignableFrom<object[]>(result);
        Assert.Empty(result);
    }
}
using Microsoft.IO;
using System.Buffers.Text;
using System.IO.Compression;

namespace Kroki.Tests;

public class Base64UrlExTests
{
    static RecyclableMemoryStreamManager MemoryStreamManager { get; } = new();
    static RecyclableMemoryStreamManager FragmentedMemoryStreamManager { get; } = new(new()
    {
        BlockSize = 1,
    });
    [Theory]
    [InlineData(0)]
    [InlineData(1024)]
    [InlineData(1024 * 1024)]
    public void Base64UrlExGeneratesSameResult(int size)
    {
        var random = new Random(size);
        var sourceArray = GC.AllocateUninitializedArray<byte>(size);
        random.NextBytes(sourceArray);


        using var memoryStream = MemoryStreamManager.GetStream(sourceArray);
        var sourceSequence = memoryStream.GetReadOnlySequence();

        Assert.Equal(Base64Url.EncodeToString(sourceArray), Base64UrlEx.EncodeToString(sourceSequence));

    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    public void Base64UrlExGeneratesSameResultWithFragmentedSequence(int size)
    {
        var random = new Random(size);
        var sourceArray = GC.AllocateUninitializedArray<byte>(size);
        random.NextBytes(sourceArray);


        using var memoryStream = FragmentedMemoryStreamManager.GetStream(sourceArray);
        var sourceSequence = memoryStream.GetReadOnlySequence();

        Assert.Equal(Base64Url.EncodeToString(sourceArray), Base64UrlEx.EncodeToString(sourceSequence));

    }
}
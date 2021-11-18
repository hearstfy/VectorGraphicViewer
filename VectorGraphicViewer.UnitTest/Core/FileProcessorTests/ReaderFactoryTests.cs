using System;
using VectorGraphicViewer.Core.FileProcessor;
using VectorGraphicViewer.Core.FileProcessor.Readers;
using Xunit;

namespace VectorGraphicViewer.UnitTest
{
    public class ReaderFactoryTests
    {
        [Theory]
        [InlineData(@"testpath\shapes.json")]
        public void FileExtensionWithImplementedReaderReturnsReader(string filePath)
        {
            var reader = ReaderFactory.GetReader(filePath);

            Assert.NotNull(reader);
            Assert.IsAssignableFrom<IReader>(reader);
        }

        [Theory]
        [InlineData(@"testpath\shapes.pdf")]
        [InlineData(@"testpath\shapes.data")]
        public void FileExtensionWithNotImplementedReaderThrowsNotImplementedException(string filePath)
        {
            Assert.Throws<NotImplementedException>(() => ReaderFactory.GetReader(filePath));
        }
    }
}
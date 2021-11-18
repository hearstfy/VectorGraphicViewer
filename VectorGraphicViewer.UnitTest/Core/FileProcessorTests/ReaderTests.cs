using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using VectorGraphicViewer.Core.FileProcessor;
using VectorGraphicViewer.Core.Models;
using Xunit;

namespace VectorGraphicViewer.UnitTest.Core.FileProcessorTests
{
    public class ReaderTests
    {
        [Fact]
        public void ReaderWithInvalidJsonThrowsJsonReaderException()
        {
            
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Core\Assets\invalid.json");
            var reader = ReaderFactory.GetReader(filePath);

            Assert.Throws<JsonReaderException>(() => reader.Read(filePath));
        }
        [Fact]
        public void ReaderWithValidJsonWithInvalidShapeThrowsNotImplementedException()
        {

            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Core\Assets\valid_with_invalid_shape.json");
            var reader = ReaderFactory.GetReader(filePath);

            Assert.Throws<NotImplementedException>(() => reader.Read(filePath));
        }

        [Fact]
        public void ReaderWithValidJsonReturnsShapeList()
        {

            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Core\Assets\valid.json");
            var reader = ReaderFactory.GetReader(filePath);

            var shapeList = reader.Read(filePath);

            Assert.NotNull(shapeList);
            Assert.NotEmpty(shapeList);
            Assert.IsAssignableFrom<IEnumerable<Shape>>(shapeList);
        }

    }
}

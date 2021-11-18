using System.Collections.Generic;
using VectorGraphicViewer.Core.Models;

namespace VectorGraphicViewer.Core.FileProcessor.Readers
{
    public interface IReader
    {
        public IEnumerable<Shape> Read(string FilePath);
    }
}

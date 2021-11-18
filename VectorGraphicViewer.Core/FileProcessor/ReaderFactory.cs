using System;
using System.IO;
using System.Linq;
using System.Reflection;
using VectorGraphicViewer.Core.FileProcessor.Readers;

namespace VectorGraphicViewer.Core.FileProcessor
{
    public class ReaderFactory
    {
        public static IReader GetReader(string filePath)
        {
            string fileExtension = Path.GetExtension(filePath).TrimStart('.');
            var readerClass = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.IsClass && t.Namespace == "VectorGraphicViewer.Core.FileProcessor.Readers" && t.Name.ToLower().Equals(fileExtension + "reader"));
            if (readerClass == null) throw new NotImplementedException("No reader is implemented for this extension");
            
            return (IReader)Activator.CreateInstance(readerClass);
        }
    }
}

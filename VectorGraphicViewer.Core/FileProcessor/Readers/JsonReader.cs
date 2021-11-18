using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using VectorGraphicViewer.Core.Models;
using VectorGraphicViewer.FileProcessor.Converters;

namespace VectorGraphicViewer.Core.FileProcessor.Readers
{
    internal class JsonReader : IReader
    {
        public IEnumerable<Shape> Read(string FilePath)
        {
            using (StreamReader r = new StreamReader(FilePath))
            {
                string json = r.ReadToEnd();

                try
                {
                    List<Shape> shapes = JsonConvert.DeserializeObject<List<Shape>>(json, new JsonShapeConverter());
                    return shapes;
                }
                catch (JsonReaderException ex)
                {
                    throw new JsonReaderException("Invalid file");
                }
                catch(NotImplementedException ex)
                {
                    throw new NotImplementedException(ex.Message);
                }

            }
        }
    }
}

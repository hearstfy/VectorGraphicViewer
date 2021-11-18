using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Reflection;
using VectorGraphicViewer.Core.Models;

namespace VectorGraphicViewer.FileProcessor.Converters
{
    internal class JsonShapeConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(Shape));
        }

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);
            var shapeClass = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.IsClass && t.Namespace == "VectorGraphicViewer.Core.Models" && t.Name.ToLower() == jo["type"].ToString());
            if (shapeClass == null) throw new NotImplementedException("No implementation for this shape: " + jo["type"].ToString());

            var shapeInstance = ((Shape)Activator.CreateInstance(shapeClass)).FromJSON(jo);
            return shapeInstance;

        }

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}

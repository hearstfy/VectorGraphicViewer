using Newtonsoft.Json.Linq;
using System.Windows.Media;

namespace VectorGraphicViewer.Core.Models
{
    public class Triangle : Shape
    {
        public PointCollection Coordinates { get; set; }
        public bool Filled { get; set; }

        public override Shape FromJSON(JObject jo)
        {
            Type = jo["type"].ToString();

            Coordinates = new PointCollection()
            {
                GetCoordinate(jo["a"].ToString()),
                GetCoordinate(jo["b"].ToString()),
                GetCoordinate(jo["c"].ToString())
            };
            Filled = bool.Parse(jo["filled"].ToString());
            Color = GetColor(jo["color"].ToString());

            return this;
        }
    }
}

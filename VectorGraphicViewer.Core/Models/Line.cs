using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace VectorGraphicViewer.Core.Models
{
    public class Line: Shape
    {
        public PointCollection Coordinates { get; set; }

        public override Shape FromJSON(JObject jo)
        {
            Type = jo["type"].ToString();
            Coordinates = new PointCollection()
            {
                GetCoordinate(jo["a"].ToString()),
                GetCoordinate(jo["b"].ToString())
            };
            Color = GetColor(jo["color"].ToString());

            return this;
        }
    }
}

using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace VectorGraphicViewer.Core.Models
{
    public class Circle: Shape
    {
        public Point Center { get; set; }
        public float Radius { get; set; }
        public bool Filled { get; set; }
        public override Shape FromJSON(JObject jo)
        {
            Type = jo["type"].ToString();
            Center = GetCoordinate(jo["center"].ToString());
            Radius = float.Parse(jo["radius"].ToString());
            Color = GetColor(jo["color"].ToString());
            Filled = bool.Parse(jo["filled"].ToString());

            return this;
        }
    }
}

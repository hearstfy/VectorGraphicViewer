using System;
using System.Linq;
using System.Reflection;
using System.Windows.Controls;
using VectorGraphicViewer.Core.Models;

namespace VectorGraphicViewer.UI.Drawers
{
    public class DrawerFactory
    {
        public static IDrawer GetDrawer(string shapeType)
        {
            var drawerClass = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.IsClass && t.Namespace == "VectorGraphicViewer.UI.Drawers" && t.Name.ToLower().Equals(shapeType + "drawer"));
            if (drawerClass == null) throw new NotImplementedException("No drawer for this shape type is implemented");
            return (IDrawer)Activator.CreateInstance(drawerClass);
        }
    }
}

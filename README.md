# How to run
Run following commands on root folder of the project
```
dotnet build
dotnet test
dotnet run --project .\VectorGraphicViewer.UI\VectorGraphicViewer.UI.csproj
```

# About  
Shapes, file readers and shape drawers are dynamically instantiated by using reflection. Thats why you need to follow naming convention when adding new shape, file reader or shape drawer.

 **VectorGraphicViewer.Core :**   
 File processing logic and shape models reside in this project. 
 <br/><br/>
**VectorGraphicViewer.UI :**  
WPF UI, custom controls and drawers reside in this project.
<br/><br/>
**VectorGraphicViewer.UnitTest :**  
Unit tests are in this project

# How to add a new data source reading
- Add a new class that follows naming convention **[FileExtension]Reader** and implements **IReader** interface to **VectorGraphicViewer.Core\FileProcessor\Readers** folder and implement its logic. 
- If a converter needed,  add converter class to **VectorGraphicViewer.Core\FileProcessor\Converters**
- Add **From[FileExtension]** function to  **VectorGraphicViewer.Core\Models\Shape.cs** and add overridden function to each shape class.

# How to add a new shape
- Add a new class that follows naming convention **[ShapeName]** and extends **Shape** abstract class to **VectorGraphicViewer.Core\Models** folder and implement its logic. 
- Add a new class that follows naming convention **[ShapeName]Drawer** and implements **IDrawer** interface to **VectorGraphicViewer.UI\Drawers** folder and implement its logic. 

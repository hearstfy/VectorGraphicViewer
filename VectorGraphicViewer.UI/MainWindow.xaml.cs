using System.Collections.Generic;
using System.Reactive.Subjects;
using System;
using System.Windows;
using VectorGraphicViewer.Core.Models;
using VectorGraphicViewer.UI.Drawers;
using VectorGraphicViewer.Core.FileProcessor.Readers;
using VectorGraphicViewer.Core.FileProcessor;

namespace VectorGraphicViewer.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Subject<IEnumerable<Shape>> onFileRead = new();
        private IDrawer _drawer;
        private IReader _reader;
        public MainWindow()
        {
            InitializeComponent();

            onFileRead.Subscribe(shapes =>
            {
                canvas.Children.Clear();

                foreach (Shape shape in shapes)
                {
                    this.DrawShape(shape);
                }
            });
        }

        private void fileDialogButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog fileDialog = new Microsoft.Win32.OpenFileDialog();

            if (fileDialog.ShowDialog() == true)
            {
                string fileName = fileDialog.FileName;
                fileNameTextBox.Text = fileName;

                try
                {
                    _reader = ReaderFactory.GetReader(fileName);
                    onFileRead.OnNext(_reader.Read(fileName));
                }
                catch (Exception ex)
                {
                    ShowMessageBox("Error", ex.Message);
                }
            }
        }

        private void DrawShape(Shape shape)
        {
            try
            {
                _drawer = DrawerFactory.GetDrawer(shape.Type);
                _drawer.Draw(canvas, shape);
            } catch (Exception ex)
            {
                ShowMessageBox("Error", ex.Message);
            }
        }

        private void ShowMessageBox(string title, string messageText)
        {
            MessageBox.Show(messageText, title);
        }

        private void mainWindow_Closed(object sender, EventArgs e)
        {
            onFileRead.Dispose();
        }
    }
}

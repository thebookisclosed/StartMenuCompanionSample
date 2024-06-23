using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Albacore.StartMenuCompanion.Sample
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        private string JSONDirectory = Path.Combine(ApplicationData.Current.LocalFolder.Path, "StartMenu");
        private string JSONPath;

        public MainWindow()
        {
            this.InitializeComponent();
            JSONPath = Path.Combine(JSONDirectory, "StartMenuCompanion.json");
            if (!Directory.Exists(JSONDirectory))
                DropSampleJSON();
            else
                ReadJSONFile();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            WriteJSONFile();
        }

        private void ReloadButton_Click(object sender, RoutedEventArgs e)
        {
            ReadJSONFile();
        }

        private void ReadJSONFile()
        {
            if (!File.Exists(JSONPath))
                return;
            var jsonData = File.ReadAllText(JSONPath);
            CompanionJSONContent.Text = jsonData;
        }

        private void WriteJSONFile()
        {
            File.WriteAllText(JSONPath, CompanionJSONContent.Text);
        }

        private async void OpenFolderButton_Click(object sender, RoutedEventArgs e)
        {
            await Windows.System.Launcher.LaunchFolderPathAsync(JSONDirectory);
        }

        private async void DropSampleJSON()
        {
            var storageFile = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/SampleAdaptiveCard.json"));
            var storageDir = await ApplicationData.Current.LocalFolder.CreateFolderAsync("StartMenu");

            var dirInfo = new DirectoryInfo(JSONDirectory);
            var dirSec = dirInfo.GetAccessControl();
            // Add Shell Experience Capability SID
            dirSec.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier("S-1-15-3-1024-3167453650-624722384-889205278-321484983-714554697-3592933102-807660695-1632717421"), FileSystemRights.ReadAndExecute, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow));
            dirInfo.SetAccessControl(dirSec);

            await storageFile.CopyAsync(storageDir, "StartMenuCompanion.json");
            ReadJSONFile();
        }
    }
}

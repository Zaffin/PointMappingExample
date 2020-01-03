using System.Windows;

using PointMappingExample.ViewModel;
using PointMappingExample.Services;

namespace PointMappingExample.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
            DataContext = new MainViewViewModel(new MastercamService());
        }
    }
}

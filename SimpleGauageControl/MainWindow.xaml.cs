using SimpleGauageControl.UC;
using System.Windows;


namespace SimpleGauageControl
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            GaugeControl.ProgressValue(70.0);
        }
    }
}

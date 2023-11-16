using System.Windows;
using System.Windows.Input;


namespace BankProject {
    /// <summary>
    /// Interaction logic for WindowRegister.xaml
    /// </summary>
    public partial class WindowRegister : Window {

        public string ConnectionString {  get; set; }


        public WindowRegister(string connectionString) {
            InitializeComponent();
            ConnectionString = connectionString;
        }


        private void Border_MouseDown(object sender, MouseButtonEventArgs e) {
            if(e.ChangedButton==MouseButton.Left) {
                this.DragMove();
            }
        }


        private void ButtonBack_Click(object sender, RoutedEventArgs e) {
            this.Hide();
            this.Owner.Show();
        }


        private void ImageClose_MouseUp(object sender, MouseButtonEventArgs e) {
            Application.Current.Shutdown();
        }


        private void ImageMinimize_MouseUp(object sender, MouseButtonEventArgs e) {
            this.WindowState = WindowState.Minimized;
        }
    }
}

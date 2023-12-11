using BankProject.Classes;
using BankProject.UserControls;
using BankProject.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BankProject
{
    /// <summary>
    /// Interaction logic for WindowFrame.xaml
    /// </summary>
    public partial class WindowFrame : Window
    {

        private ClassController MyController { get; set; }
        private ClassUserLogged MyUserLogged { get; set; }


        public WindowFrame(ClassController myController)
        {
            InitializeComponent();
            MyController = myController;
            MyUserLogged = MyController.MyUserLogged;

            nameMenu.Text = $"{MyUserLogged.FirstName} {MyUserLogged.LastName}";
            initialsMenu.Text = $"{MyUserLogged.FirstName[0].ToString().ToUpper()}{MyUserLogged.LastName[0].ToString().ToUpper()}";
            UcDashboard newDashboard = new UcDashboard(MyController);
            TabItem newTabItem = new TabItem();
            newTabItem.Content = newDashboard;
            newTabItem.Visibility = Visibility.Collapsed; //Hide Item Tab in TabControl
            tabControl_Frame.Items.Add(newTabItem);
            tabControl_Frame.SelectedItem = newTabItem;
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }


        private void ImageMinimize_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }


        private void ImageClose_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }


        private void ButtonLogout_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            this.Owner.Show();
        }

        private void ButtonDashboard_Click(object sender, RoutedEventArgs e)
        {
            Button buttonPressed = (Button)sender;
            UcDashboard newDashboard = new UcDashboard(MyController);
            SwitchTabs(newDashboard, buttonPressed);
        }


        private void ButtonWallet_Click(object sender, RoutedEventArgs e)
        {
            UcWallet newWallet = new UcWallet(MyController);
            Button buttonPressed = (Button)sender;
            TabItem newTabItem = new TabItem();
            SwitchTabs(newWallet, buttonPressed);
        }

        private void ButtonCustomerBase_Click(object sender, RoutedEventArgs e)
        {



            //Switch windows
            var MyWindowCustomer = new WindowCustomerBase(MyController.ConnectionString);
            MyWindowCustomer.Owner = this;
            this.Hide();
            MyWindowCustomer.Show();
        }

        private void SwitchTabs(object newUserControl, Button buttonPressed)
        {
            //Add newUserControl into new Item of tabControl_Frame
            TabItem newTabItem = new TabItem();
            newTabItem.Content = newUserControl;
            newTabItem.Visibility = Visibility.Collapsed; //Hide Item Tab in TabControl
            tabControl_Frame.Items.Add(newTabItem);
            tabControl_Frame.SelectedItem = newTabItem;

            //Reset all Menu Button styles
            foreach (Object obj in buttonsList.Children)
            {
                if (obj.GetType() == typeof(Button))
                {
                    ((Button)obj).Style = (Style)Application.Current.Resources["menuButton_Frame"];
                }
            }
            //Set current button style to active
            buttonPressed.Style = (Style)Application.Current.Resources["menuButtonActive_Frame"];
        }

    }
}

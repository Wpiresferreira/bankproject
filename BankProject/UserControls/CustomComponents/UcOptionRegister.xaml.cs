using System;
using System.Windows;
using System.Windows.Controls;


namespace BankProject.UserControls {
    /// <summary>
    /// Interaction logic for UcOptionRegister.xaml
    /// </summary>
    public partial class UcOptionRegister : UserControl {

        public UcOptionRegister() {
            InitializeComponent();
        }


        public string Text {
            get {  return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(UcOptionRegister));

        public FontAwesome.WPF.FontAwesomeIcon Icon {
            get {  return (FontAwesome.WPF.FontAwesomeIcon)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }
        public static readonly DependencyProperty IconProperty = DependencyProperty.Register("Icon", typeof(FontAwesome.WPF.FontAwesomeIcon), typeof(UcOptionRegister));

    }
}

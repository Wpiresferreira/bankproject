using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;


namespace BankProject.UserControls {
    /// <summary>
    /// Interaction logic for UcTextBoxRegister.xaml
    /// </summary>
    public partial class UcTextBoxRegister : UserControl {
        
        public UcTextBoxRegister() {
            InitializeComponent();
        }

        public string Hint {
            get { return (string)GetValue(HintProperty); }
            set { SetValue(HintProperty, value); }
        }

        public static readonly DependencyProperty HintProperty = DependencyProperty.Register("Hint", typeof(string), typeof(UcTextBoxRegister));
    }
}

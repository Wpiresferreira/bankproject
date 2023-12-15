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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BankProject.UserControls {
    /// <summary>
    /// Interaction logic for UcTextBoxRegisterReadOnly.xaml
    /// </summary>
    public partial class UcTextBoxRegisterReadOnly : UserControl {
        
        public UcTextBoxRegisterReadOnly() {
            InitializeComponent();
        }

        public string Hint {
            get { return (string)GetValue(HintProperty); }
            set { SetValue(HintProperty, value); }
        }

        public static readonly DependencyProperty HintProperty = DependencyProperty.Register("Hint", typeof(string), typeof(UcTextBoxRegisterReadOnly));
    }
}

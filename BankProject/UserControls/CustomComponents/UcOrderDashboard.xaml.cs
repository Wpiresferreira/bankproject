using System;
using System.Windows;
using System.Windows.Controls;


namespace BankProject.UserControls
{
    /// <summary>
    /// Interaction logic for UcOrderAdmin.xaml
    /// </summary>
    public partial class UcOrderDashboard : UserControl
    {
        public UcOrderDashboard()
        {
            InitializeComponent();
        }

        public string Title {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }
        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(UcOrderDashboard));
        
        public string Desc {
            get { return (string)GetValue(DescProperty); }
            set { SetValue(DescProperty, value); }
        }
        public static readonly DependencyProperty DescProperty = DependencyProperty.Register("Desc", typeof(string), typeof(UcOrderDashboard));

        public FontAwesome.WPF.FontAwesomeIcon Icon {
            get { return (FontAwesome.WPF.FontAwesomeIcon)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }
        public static readonly DependencyProperty IconProperty = DependencyProperty.Register("Icon", typeof(FontAwesome.WPF.FontAwesomeIcon), typeof(UcOrderDashboard));
    }
}

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
using PolvakWPF.Logic;

namespace PolvakWPF.Forms
{
    /// <summary>
    /// Interaction logic for autoklavVisual.xaml
    /// </summary>
    public partial class AutoklavVisual : UserControl
    {
        private AutoklavData Data = new AutoklavData();
        public AutoklavVisual()
        {
            InitializeComponent();
            DataContext = Data;
            Data.Apparat = 10;
            Data.PApparat = 11;
            Data.PodPara = 12;
            Data.RubNiz = 13;
            Data.RubVerh = 14;
            Data.Uroven = 15;
        }
    }
}

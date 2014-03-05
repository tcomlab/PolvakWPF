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

namespace PolvakWPF.Forms
{
 
    /// <summary>
    /// Interaction logic for ButtonPanel.xaml
    /// </summary>
    public partial class ButtonPanel : UserControl
    {
        public class ViewArg:EventArgs
        {
            public ViewState State;

            public ViewArg(ViewState state)
            {
                State = state;
            }
        }

        public enum ViewState
        {
            BE16000,
            BE16001,
            CE3,
            CE4,
            CE25,
            GMV40,
            GMV60,
            KAUSTIC,
            PRGNEW,
            PRGOLD,
            REPULPATOR
        }

        public event EventHandler ChangeView;

        public ButtonPanel()
        {
            InitializeComponent();
        }

        private void SelectClick(object sender, RoutedEventArgs e)
        {
            var a = (string)(((Button)sender).Tag);
            var ab = (ViewState) Convert.ToByte(a);
            if (ChangeView != null)
            {
                ChangeView(this, new ViewArg(ab));
            }
        }
    }
}

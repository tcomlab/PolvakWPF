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
using PolvakWPF.Forms;
using PolvakWPF.Logic;

namespace PolvakWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ButtonPanel.ViewState View;

        public MainWindow()
        {
            InitializeComponent();
            Controller.Start();
            ButtonPanel1.ChangeView += ChangeView;
            ButtonPanel1.ChangeView += ChartPanel1.ChangeView;

            WindowState = WindowState.Normal;
            WindowStyle = WindowStyle.None;
            WindowState = WindowState.Maximized;
            ResizeMode = ResizeMode.NoResize;
        }

        private void ChangeView(object sender, EventArgs e)
        {
            var st = (ButtonPanel.ViewArg) e;
            Panel1.Children.Clear();
            switch (st.State)
            {
                case ButtonPanel.ViewState.BE16000:
                    Panel1.Children.Add(new AutoklavVisual(Controller.Be16000Data));
                    break;
                case ButtonPanel.ViewState.BE16001:
                    Panel1.Children.Add(new AutoklavVisual(Controller.Be16001Data));
                    break;
                case ButtonPanel.ViewState.CE3:
                    Panel1.Children.Add(new AutoklavVisual(Controller.Ce3Data));
                    break;
                case ButtonPanel.ViewState.CE4:
                    Panel1.Children.Add(new AutoklavVisual(Controller.Ce4Data));
                    break;
                case ButtonPanel.ViewState.CE25:
                    Panel1.Children.Add(new AutoklavVisual(Controller.Ce25Data));
                    break;
                case ButtonPanel.ViewState.GMV40:
                    Panel1.Children.Add(new gmv40vis(Controller.Gmv40));
                    break;
                case ButtonPanel.ViewState.GMV60:
                    Panel1.Children.Add(new gmv60vis(Controller.Gmv60));
                    break;
                case ButtonPanel.ViewState.KAUSTIC:
                    Panel1.Children.Add(new kausticvis(Controller.Kaustic));
                    break;
                case ButtonPanel.ViewState.PRGNEW:
                    Panel1.Children.Add(new prgvis(Controller.PrgNew));
                    break;
                case ButtonPanel.ViewState.PRGOLD:
                    Panel1.Children.Add(new prgvis(Controller.PrgOld));
                    break;
                case ButtonPanel.ViewState.REPULPATOR:
                    Panel1.Children.Add(new RepulpatorVisual(Controller.Repulpat));
                    break;

            }
        }
    }
}

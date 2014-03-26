using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Threading;
using System.Windows.Documents;
using System.Windows.Threading;
using DevExpress.Xpf.Charts;
using LinqToDB;
using LinqToDB.SqlQuery;
using PolvakWPF.Logic.DataBasePrototype;


namespace PolvakWPF.Forms
{
    /// <summary>
    /// Interaction logic for ChartPanel.xaml
    /// </summary>
    public partial class ChartPanel : UserControl
    {
        private ButtonPanel.ViewState _state { set; get; }

        public ChartPanel()
        {
            InitializeComponent();
           // new Thread(ChartBulder){IsBackground = true}.Start();
        }

        private void ChartBulder()
        {
            while (true)
            {
                RefreshData();
                Thread.Sleep(120000);
            }
        }

        private void RefreshData()
        {
            //new Thread(create_series) { IsBackground = true }.Start();
        }


        private object get_data( )
        {
            using (var db = new polvak_db2())
            {
                var tstamp = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
                switch (_state)
                {
                    case ButtonPanel.ViewState.BE16000:
                        return (from c in db.BE16000
                                where c.DT > tstamp
                            select c).ToList();
                    case ButtonPanel.ViewState.BE16001:
                        return (from c in db.BE16001
                                where c.DT > tstamp
                            select c).ToList();
                    case ButtonPanel.ViewState.CE3:
                        return (from c in db.CE3
                                where c.DT > tstamp
                            select c).ToList();
                    case ButtonPanel.ViewState.CE4:
                        return (from c in db.CE4
                                where c.DT > tstamp
                            select c).ToList();
                    case ButtonPanel.ViewState.CE25:
                        return (from c in db.CE25
                                where c.DT > tstamp
                            select c).ToList();
                    case ButtonPanel.ViewState.GMV40:
                        return (from c in db.GMV20
                                where c.DT > tstamp
                            select c).ToList();
                    case ButtonPanel.ViewState.GMV60:
                        return (from c in db.GMV60
                                where c.DT > tstamp
                            select c).ToList();
                    case ButtonPanel.ViewState.KAUSTIC:
                        return (from c in db.Kaustik
                                where c.DT > tstamp
                            select c).ToList();
                    case ButtonPanel.ViewState.PRGNEW:
                        return (from c in db.PrgNew
                                where c.DT > tstamp
                            select c).ToList();
                    case ButtonPanel.ViewState.PRGOLD:
                        return (from c in db.PrgOld
                                where c.DT > tstamp
                            select c).ToList();
                    case ButtonPanel.ViewState.REPULPATOR:
                        return null;
                }
            }
            return null;
        }

        private void create_series()
        {
            if (_state == null) return;

            var result = get_data();
            if (result == null) return;
            this.Dispatcher.Invoke(() =>{ ChartControl1.Visibility = Visibility.Hidden; });
            this.Dispatcher.Invoke(()=> { ChartControl1.DataSource = result; });

            var hTable = new Dictionary<string, string>();

            switch (_state)
            {
                case ButtonPanel.ViewState.BE16000:
                case ButtonPanel.ViewState.BE16001:
                case ButtonPanel.ViewState.CE3:
                case ButtonPanel.ViewState.CE4:
                case ButtonPanel.ViewState.CE25:
                    hTable.Add("t_aparat", "В аппарате");
                    hTable.Add("t_rub_niz", "Рубашка низ");
                    hTable.Add("t_rub_verh", "Рубашка верх");
                    hTable.Add("t_pod_para", "Подача пара");
                    hTable.Add("dav_aparat", "Давление");
                    break;
                case ButtonPanel.ViewState.GMV40:
                    break;
                case ButtonPanel.ViewState.GMV60:
                    break;
                case ButtonPanel.ViewState.KAUSTIC:
                    break;
                case ButtonPanel.ViewState.PRGNEW:
                    break;
                case ButtonPanel.ViewState.PRGOLD:
                    break;
                case ButtonPanel.ViewState.REPULPATOR:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

           

            foreach (var pair in hTable)
            {
                this.Dispatcher.Invoke(() => { 
                Diagram2D1.Series.Add(new LineSeries2D
                {
                    ArgumentScaleType = ScaleType.DateTime,
                    ValueScaleType = ScaleType.Numerical,
                    ArgumentDataMember = "DT",
                    ValueDataMember = pair.Key,
                    DisplayName = pair.Value
                });
                });
            }

            this.Dispatcher.Invoke(() => { ChartControl1.Visibility = Visibility.Visible; });
        }


        public void ChangeView(object sender, EventArgs e)
        {
            var st = (ButtonPanel.ViewArg)e;
            _state = st.State;
            //RefreshData();
        }
    }
}

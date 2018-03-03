using One_Sgp4;
using OxyPlot;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MARRSS.Forms
{
    public partial class SatelliteStorageForm : Form
    {
        public SatelliteStorageForm(Satellite.Satellite sat)
        {
            this.InitializeComponent();
            var myModel = new PlotModel { Title = sat.getName() +" Storage Capacity" };

            var down = sat.getDataStorage().GetDownloadedDataPackets();
            var stor = sat.getDataStorage().GetCreatedDataPackets();

            LineSeries ls = new LineSeries();;
            LineSeries dw = new LineSeries();
            long tm = 0;
            for (int i = 0; i < down.Count; i += 1000)
            {
                ls.Points.Add(new DataPoint(tm, down[i].getStoredData()));
                tm += down[i].getDurationInSec();
            }

            myModel.Series.Add(ls);
            this.plot1.Model = myModel;
        }

        private void SatelliteStorageForm_Load(object sender, EventArgs e)
        {

        }
    }
}

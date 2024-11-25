using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi301.EFProject
{
    public partial class FrmStatistics : Form
    {
        public FrmStatistics()
        {
            InitializeComponent();
        }
        EgitimKampiEFTravelDbEntities db = new EgitimKampiEFTravelDbEntities();
        private void FrmStatistics_Load(object sender, EventArgs e)
        {

            lblLocationCount.Text = db.Locations.Count().ToString();
            lblSumCapacity.Text = db.Locations.Sum(x => x.Capacity).ToString();
            lblGuideCount.Text = db.Guides.Count().ToString();
            decimal avg = decimal.Parse(db.Locations.Average(x => x.Capacity).ToString());
            lblAvgCapatiy.Text = Math.Round(avg,2).ToString();

            decimal average = decimal.Parse(db.Locations.Average(x => x.Price).ToString());
            lblAvgLocationPrice.Text = Math.Round(average,2).ToString();

            int id = db.Locations.Max(x=>x.LocationId);
            lblLastCountryName.Text = db.Locations.Where(x=>x.LocationId==id).Select(y=>y.Country).FirstOrDefault();

            lblCapadokiaLocationCapacity.Text = db.Locations.Where(x => x.City == "Kapadokya").Select(y => y.Capacity).FirstOrDefault().ToString();

            lblTurkiyeCapacityAvg.Text = db.Locations.Where(x=>x.Country=="Türkiye").Average(y=>y.Capacity).ToString();

            var RomeGuideId = db.Locations.Where(x => x.City == "Roma").Select(y => y.GuideId).FirstOrDefault();
            lblRomeGuideName.Text = db.Guides.Where(x=>x.GuideId==RomeGuideId).Select(y=>y.GuideName+" "+y.GuideSurname).FirstOrDefault().ToString();

           var maxCapacity=db.Locations.Max(x=>x.Capacity);
            lblMaxCapacityLocation.Text = db.Locations.Where(x => x.Capacity == maxCapacity).Select(y => y.City).FirstOrDefault().ToString().ToString();

            var maxPrice = db.Locations.Max(x => x.Price);
            lblMaxPriceLocation.Text = db.Locations.Where(x => x.Price == maxPrice).Select(y => y.City).FirstOrDefault().ToString();

            var AyseGulId = db.Guides.Where(x=>x.GuideName=="AyşeGül" && x.GuideSurname=="Çınar").Select(y=>y.GuideId).FirstOrDefault();
            lblAyseGulCinarLocationCount.Text=db.Locations.Where(x=>x.GuideId==AyseGulId).Count().ToString();

        }
    }
}

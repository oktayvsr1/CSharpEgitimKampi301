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
    public partial class FrmLocation : Form
    {
        public FrmLocation()
        {
            InitializeComponent();
        }
        EgitimKampiEFTravelDbEntities db = new EgitimKampiEFTravelDbEntities();
        private void btnList_Click(object sender, EventArgs e)
        {
            var values=db.Locations.ToList();
            dataGridView1.DataSource = values;
        }

        private void FrmLocation_Load(object sender, EventArgs e)
        {
            var values = db.Guides.Select(x => new
            {
                FullName = x.GuideName + " " + x.GuideSurname,
                x.GuideId
            }).ToList();
            cmbGuide.DisplayMember = "FullName";
            cmbGuide.ValueMember = "GuideId";
            cmbGuide.DataSource = values;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Locations location = new Locations();
            location.Capacity = byte.Parse(numericUpDown1.Value.ToString());
            location.City=txtCity.Text;
            location.Country=txtCountry.Text;
            location.Price = decimal.Parse(txtPrice.Text);
            location.DayNight=txtNightAndDay.Text;
            location.GuideId=int.Parse(cmbGuide.SelectedValue.ToString());
            db.Locations.Add(location);
            db.SaveChanges();
            MessageBox.Show("Ekleme işlemi başarılı");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var values = db.Locations.Find(id);
            db.Locations.Remove(values);
            db.SaveChanges();
            MessageBox.Show("Silme işlemi başarılı");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var values = db.Locations.Find(id);
            values.DayNight = txtNightAndDay.Text;
            values.Price = decimal.Parse(txtPrice.Text);
            values.Capacity=byte.Parse(numericUpDown1.Value.ToString());
            values.City=txtCity.Text;
            values.Country=txtCountry.Text;
            values.GuideId = int.Parse(cmbGuide.SelectedValue.ToString());
            db.SaveChanges();
            MessageBox.Show("Güncelleme işlemi başarılı");
        }
    }
}

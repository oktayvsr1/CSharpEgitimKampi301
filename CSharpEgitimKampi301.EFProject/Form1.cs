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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        EgitimKampiEFTravelDbEntities db = new EgitimKampiEFTravelDbEntities();
        private void btnList_Click(object sender, EventArgs e)
        {

            var values = db.Guides.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Guides guides = new Guides();
            guides.GuideName = txtName.Text;
            guides.GuideSurname = txtSurname.Text;
            db.Guides.Add(guides);
            db.SaveChanges();
            MessageBox.Show("Rehber Ekleme İşlemi başarılı bir şekilde gerçekleştirildi");

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id=int.Parse(txtId.Text);
            var values = db.Guides.Find(id);
            db.Guides.Remove(values);
            db.SaveChanges() ;
            MessageBox.Show("Rehber Başarıyla Silindi");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id=int.Parse(txtId.Text);
            var values = db.Guides.Find(id);
            values.GuideName = txtName.Text;
            values.GuideSurname= txtSurname.Text;
            db.SaveChanges();
            MessageBox.Show("Rehber Başarıyla Güncellendi");
        }

        private void btnGetByID_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var values = db.Guides.Where(x=>x.GuideId==id).ToList();
            dataGridView1.DataSource = values;

        }
    }
}

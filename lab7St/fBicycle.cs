using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.MonthCalendar;

namespace lab7St
{
    public partial class fBicycle : Form
    {
        private Bicycle _bicycle;
        public fBicycle(ref Bicycle bicycle)
        {
            InitializeComponent();
            _bicycle = bicycle;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnOk_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBrand.Text) ||
           string.IsNullOrWhiteSpace(txtModel.Text) ||
           !int.TryParse(txtFrameSize.Text, out int frameSize) ||
           !int.TryParse(txtWheelSize.Text, out int wheelSize) ||
           string.IsNullOrWhiteSpace(txtColor.Text) ||
           !decimal.TryParse(txtPrice.Text, out decimal price))
            {
                MessageBox.Show("Заповніть всі поля у правильному форматі.", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _bicycle.Brand = txtBrand.Text;
            _bicycle.Model = txtModel.Text;
            _bicycle.FrameSize = frameSize;
            _bicycle.WheelSize = wheelSize;
            _bicycle.Color = txtColor.Text;
            _bicycle.IsElectric = chkIsElectric.Checked;
            _bicycle.Price = price;

            this.DialogResult = DialogResult.OK;
        }
    }
}


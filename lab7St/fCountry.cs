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
    public partial class fCountry : Form
    {
        private Country _country;
        private double populationDensityResult;
        private bool isAboveAverageResult;
        public fCountry(ref Country country)
        {
            InitializeComponent();
            _country = country;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnOk_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
            string.IsNullOrWhiteSpace(txtContinent.Text) ||
            string.IsNullOrWhiteSpace(txtCapitalCity.Text) ||
            !int.TryParse(txtPopulation.Text, out int population) ||
            !double.TryParse(txtArea.Text, out double area) ||
            !double.TryParse(txtLifeExpectancy.Text, out double lifeExpectancy))
            {
                MessageBox.Show("Заповніть всі поля у правильному форматі.", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _country.CountryName = txtName.Text;
            _country.Continent = txtContinent.Text;
            _country.CapitalCity = txtCapitalCity.Text;
            _country.Population = population;
            _country.Area = area;
            _country.LifeExpectancy = lifeExpectancy;
            _country.IsInEU = chkIsInEU.Checked;
            _country.IsInNATO = chkIsInNATO.Checked;

            populationDensityResult = _country.CalculatePopulationDensity();
            isAboveAverageResult = _country.IsPopulationDensityAboveAverage();

            this.DialogResult = DialogResult.OK;
        }
    }
}


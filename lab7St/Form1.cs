using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab7St
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            gvCity.CellFormatting += gvCity_CellFormatting;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gvCity.AutoGenerateColumns = false;

            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "CountryName";
            column.Name = "Назва";
            gvCity.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Continent";
            column.Name = "Континент";
            gvCity.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "CapitalCity";
            column.Name = "Столиця";
            gvCity.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Population";
            column.Name = "Населення";
            gvCity.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Area";
            column.Name = "Площа";
            gvCity.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "LifeExpectancy";
            column.Name = "Очікувана тривалість життя";
            gvCity.Columns.Add(column);

            column = new DataGridViewCheckBoxColumn();
            column.DataPropertyName = "IsInEU";
            column.Name = "В ЄС";
            column.Width = 60;
            gvCity.Columns.Add(column);

            column = new DataGridViewCheckBoxColumn();
            column.DataPropertyName = "IsInNATO";
            column.Name = "В НАТО";
            column.Width = 60;
            gvCity.Columns.Add(column);
            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "PopulationDensity";
            column.Name = "Густина населення";
            gvCity.Columns.Add(column);

            column = new DataGridViewCheckBoxColumn();
            column.DataPropertyName = "IsAboveAverage";
            column.Name = "Вище середньої";
            column.Width = 60;
            gvCity.Columns.Add(column);

            Country kiev = new Country("Україна", "Європа", "Київ", 42000000, 603628, 71.5, false, false);

            kiev.PopulationDensity = kiev.CalculatePopulationDensity();
            kiev.IsAboveAverage = kiev.IsPopulationDensityAboveAverage();

            bindSrcCountry.Add(kiev);

            gvCity.DataSource = bindSrcCountry;

            EventArgs args = new EventArgs();
            OnResize(args);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            int buttonsSize = 5 * btnAdd.Width + 2 * tsSeparator1.Width + 30; btnExit.Margin = new Padding(Width - buttonsSize, 0, 0, 0);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Country country = new Country();
            fCountry fc = new fCountry(ref country);
            if (fc.ShowDialog() == DialogResult.OK)
            {
                bindSrcCountry.Add(country);

                // Розрахунки для нової країни
                country.PopulationDensity = country.CalculatePopulationDensity();
                country.IsAboveAverage = country.IsPopulationDensityAboveAverage();

                // Знаходження текстових полів у формі fCountry і встановлення їх значень
                fCountry fCountryForm = fc as fCountry;
                if (fCountryForm != null)
                {
                    country.PopulationDensity.ToString("F2");
                    country.IsAboveAverage.ToString();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Country country = (Country)bindSrcCountry.List[bindSrcCountry.Position];

            fCountry fc = new fCountry(ref country);
            if (fc.ShowDialog() == DialogResult.OK)
            {
                bindSrcCountry.List[bindSrcCountry.Position] = country;
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            {
                if (MessageBox.Show("Видалити поточний запис?", "Видалення запису", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    bindSrcCountry.RemoveCurrent();
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Очистити таблицю?\n\nВсі дані будуть втрачені", "Очищення даних", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                bindSrcCountry.Clear();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Закрити застосунок?", "Вихід з програми", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void gvCity_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
                double value;
                if (double.TryParse(e.Value.ToString(), out value))
                {
                    e.Value = value.ToString("F2");
                    e.FormattingApplied = true;
                }
        }

    }

}

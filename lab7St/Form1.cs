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
            gvBicycles.CellFormatting += gvBicycles_CellFormatting;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gvBicycles.AutoGenerateColumns = false;

            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Brand";
            column.Name = "Бренд";
            gvBicycles.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Model";
            column.Name = "Модель";
            gvBicycles.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "FrameSize";
            column.Name = "Розмір рами";
            gvBicycles.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "WheelSize";
            column.Name = "Розмір колеса";
            gvBicycles.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Color";
            column.Name = "Колір";
            gvBicycles.Columns.Add(column);

            column = new DataGridViewCheckBoxColumn();
            column.DataPropertyName = "IsElectric";
            column.Name = "Електричний";
            column.Width = 80;
            gvBicycles.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Price";
            column.Name = "Ціна";
            gvBicycles.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "DiscountedPrice";
            column.Name = "Ціна зі знижкою 10%";
            gvBicycles.Columns.Add(column);

            bindSrcBicycles.Add(new Bicycle("Trek", "FX 1", 52, 28, "Чорний", false, 1000.00m));
            gvBicycles.DataSource = bindSrcBicycles;

            EventArgs args = new EventArgs();
            OnResize(args);
        }

            private void Form1_Resize(object sender, EventArgs e)
        {
            int buttonsSize = 5 * btnAdd.Width + 2 * tsSeparator1.Width + 30; btnExit.Margin = new Padding(Width - buttonsSize, 0, 0, 0);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Bicycle bicycle = new Bicycle();
            fBicycle fb = new fBicycle(ref bicycle);
            if (fb.ShowDialog() == DialogResult.OK)
            {
                bindSrcBicycles.Add(bicycle);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Bicycle bicycle = (Bicycle)bindSrcBicycles.List[bindSrcBicycles.Position];
            fBicycle fb = new fBicycle(ref bicycle);
            if (fb.ShowDialog() == DialogResult.OK)
            {
                bindSrcBicycles.List[bindSrcBicycles.Position] = bicycle;
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            {
                if (MessageBox.Show("Видалити поточний запис?", "Видалення запису", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    bindSrcBicycles.RemoveCurrent();
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Очистити таблицю?\n\nВсі дані будуть втрачені", "Очищення даних", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                bindSrcBicycles.Clear();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Закрити застосунок?", "Вихід з програми", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void gvBicycles_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == gvBicycles.Columns["Ціна зі знижкою 10%"].Index && e.Value != null)
            {
                Bicycle bicycle = (Bicycle)gvBicycles.Rows[e.RowIndex].DataBoundItem;
                e.Value = bicycle.CalculateDiscountedPrice().ToString("F2");
                e.FormattingApplied = true;
            }
        }

    }

}

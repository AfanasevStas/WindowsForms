using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clock
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            int screenWidth_start = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight_start = Screen.PrimaryScreen.Bounds.Height;
            int screenWidth_finish = (screenWidth_start / 100) * 80;
            int screenHeight_finish = (screenHeight_start / 100) * 5;
            this.Location = new Point(screenWidth_finish, screenHeight_finish);
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            labelTime.Text = DateTime.Now.ToString
                (
                "hh:mm:ss tt",
                System.Globalization.CultureInfo.InvariantCulture
                );
            if (checkBoxShowDate.Checked)
                labelTime.Text += $"\n{DateTime.Now.ToString("yyyy.mm.dd")}";
            if (checkBoxShowWeekday.Checked)
            {
                DateTime date = DateTime.Now;
                int Number_day = (int)date.DayOfWeek;
                if (Number_day == 0)
                {
                    labelTime.Text += $"\n{("Воскресенье")}";
                }
                if (Number_day == 1)
                {
                    labelTime.Text += $"\n{("Понедельник")}";
                }
                if (Number_day == 2)
                {
                    labelTime.Text += $"\n{("Вторник")}";
                }
                if (Number_day == 3)
                {
                    labelTime.Text += $"\n{("Среда")}";
                }
                if (Number_day == 4)
                {
                    labelTime.Text += $"\n{("Четверг")}";
                }
                if (Number_day == 5)
                {
                    labelTime.Text += $"\n{("Пятница")}";
                }
                if (Number_day == 6)
                {
                    labelTime.Text += $"\n{("Суббота")}";
                }
            }

        }
        void SetVisibility(bool visible)
        {
            this.FormBorderStyle = visible ? FormBorderStyle.FixedToolWindow : FormBorderStyle.None;
            checkBoxShowDate.Visible = visible;
            checkBoxShowWeekday.Visible = visible;
            buttonHideControls.Visible = visible;
            this.ShowInTaskbar = visible;
            this.TransparencyKey = visible ? Color.Empty : this.BackColor;
        }
        private void buttonHideControls_Click(object sender, EventArgs e)
        {
            SetVisibility(false);
        }

        private void labelTime_DoubleClick(object sender, EventArgs e)
        {
            SetVisibility(true);
        }
    }
}
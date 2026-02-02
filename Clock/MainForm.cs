using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Clock
{
    public partial class MainForm : Form
    {
        ColorDialog backgroundDialog;
        ColorDialog foregroundDialog;
        public MainForm()
        {
            InitializeComponent();
            int screenWidth_start = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight_start = Screen.PrimaryScreen.Bounds.Height;
            int screenWidth_finish = (screenWidth_start / 100) * 80;
            int screenHeight_finish = (screenHeight_start / 100) * 5;
            this.Location = new Point(screenWidth_finish, screenHeight_finish);
            tsmiShowControls.Checked = true;
            backgroundDialog = new ColorDialog();
            foregroundDialog = new ColorDialog();
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
            notifyIcon.Text = labelTime.Text;
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
            tsmiShowControls.Checked = false;
        }

        private void labelTime_DoubleClick(object sender, EventArgs e)
        {
            tsmiShowControls.Checked = true;
        }

        private void tsmiTopmost_CheckedChanged(object sender, EventArgs e) =>        
            //this.TopMost = tsmiTopmost.Checked;
            this.TopMost = (sender as ToolStripMenuItem).Checked;

        private void tsmiShowControls_CheckedChanged(object sender, EventArgs e) =>
            SetVisibility(tsmiShowControls.Checked);

        private void tsmiExit_Click(object sender, EventArgs e) => Close();

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(!this.TopMost)
            {
                this.TopMost = true;
                this.TopMost = false;
            }
        }

        private void tsmiShowDate_CheckedChanged(object sender, EventArgs e) =>
            checkBoxShowDate.Checked = (sender as ToolStripMenuItem).Checked;

        private void tsmiShowWeekday_CheckedChanged(object sender, EventArgs e) =>
            checkBoxShowWeekday.Checked = (sender as ToolStripMenuItem).Checked;

        private void checkBoxShowDate_CheckedChanged(object sender, EventArgs e) =>
            tsmiShowDate.Checked = (sender as CheckBox).Checked;

        private void checkBoxShowWeekday_CheckedChanged(object sender, EventArgs e) =>
            tsmiShowWeekday.Checked = (sender as CheckBox).Checked;

        private void tsmiBackgroundColor_Click(object sender, EventArgs e)
        {
            DialogResult result = backgroundDialog.ShowDialog();
            if(result == DialogResult.OK)
            {
                labelTime.BackColor = backgroundDialog.Color; 
            }
        }

        private void tsmiForegroundColor_Click(object sender, EventArgs e)
        {
            if(foregroundDialog.ShowDialog() == DialogResult.OK)
                labelTime.ForeColor = foregroundDialog.Color;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            PrivateFontCollection pfs = new PrivateFontCollection();
            pfs.AddFontFile("C:\\Users\\Admin\\source\\repos\\WindowsForms\\Clock\\Fonts\\digital-7 (mono).ttf");
            labelTime.Font = new Font(pfs.Families[0], 32, FontStyle.Regular);
        }

        private void tsmiAutorn_Click(object sender, EventArgs e)
        {
            
        }
        private void labelTime_MouseUp(object sender, MouseEventArgs e)
        {
            if (tsmiShowControls.Checked == false)
            {
                if (e.Button == MouseButtons.Left)
                    this.Location = new Point(Cursor.Position.X - 130, Cursor.Position.Y - 35);
            }
        }
    }
}
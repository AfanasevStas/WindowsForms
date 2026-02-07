using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using Microsoft.Win32;

namespace Clock
{
    public partial class MainForm : Form
    {
        ColorDialog backgroundDialog;
        ColorDialog foregroundDialog;
        FontDialog fontDialog;
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
            //fontDialog = new FontDialog(this);
            LoadSettings();
        }
        void SaveSettings()
        {
            Directory.SetCurrentDirectory($"{Application.ExecutablePath}\\..\\..\\..");
            string filename = "Settings.ini";
            StreamWriter writer = new StreamWriter("Settings.ini");
            writer.WriteLine(tsmiTopmost.Checked);
            writer.WriteLine(tsmiShowControls.Checked);
            writer.WriteLine(tsmiShowDate.Checked);
            writer.WriteLine(tsmiShowWeekday.Checked);
            writer.WriteLine(tsmiAutorn.Checked);
            writer.WriteLine(labelTime.BackColor.ToArgb());
            writer.WriteLine(labelTime.ForeColor.ToArgb());
            writer.WriteLine(fontDialog.FontFile);
            writer.WriteLine(fontDialog.FontSize);
            writer.Close();
            Process.Start("notepad",filename);
        }
        void LoadSettings()
        {
            Directory.SetCurrentDirectory($"{Application.ExecutablePath}\\..\\..\\..");
            StreamReader reader = null;

            try
            {
                reader = new StreamReader("Settings.ini");
                tsmiTopmost.Checked = bool.Parse(reader.ReadLine());
                tsmiShowControls.Checked = bool.Parse(reader.ReadLine());
                tsmiShowDate.Checked = bool.Parse(reader.ReadLine());
                tsmiShowWeekday.Checked = bool.Parse(reader.ReadLine());
                tsmiAutorn.Checked = bool.Parse(reader.ReadLine());
                labelTime.BackColor = backgroundDialog.Color = Color.FromArgb(Convert.ToInt32(reader.ReadLine()));
                labelTime.ForeColor = foregroundDialog.Color = Color.FromArgb(Convert.ToInt32(reader.ReadLine()));
                //fontDialog = new FontDialog(this);
                //fontDialog.FontFile = reader.ReadLine();
                fontDialog = new FontDialog(this, reader.ReadLine());
                fontDialog.FontSize = (float)Convert.ToDouble(reader.ReadLine());
                labelTime.Font = fontDialog.ApplyFontExample(fontDialog.FontFile);


                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
            if(reader!=null) reader.Close();
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

        private void tsmiFont_Click(object sender, EventArgs e)
        {
            if (fontDialog.ShowDialog() == DialogResult.OK)
                labelTime.Font = fontDialog.Font;
        }

        private void tsmiAutorn_CheckedChanged(object sender, EventArgs e)
        {
            string key_name = "Clock_PV_522";
            RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (tsmiAutorn.Checked) rk.SetValue(key_name, Application.ExecutablePath);
            else rk.DeleteValue(key_name, false);
            rk.Dispose();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
        }
    }
}
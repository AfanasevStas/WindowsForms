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
using System.Runtime.InteropServices;
using System.Drawing.Text;

namespace Clock
{
    public partial class FontDialog : Form
    {
        public decimal value_1 = 0;
        public bool check = true;
        PrivateFontCollection pfc;
        MainForm parent;
        Dictionary<string,string> fonts = new Dictionary<string,string>();
        public Font Font { get; private set; }
        public string FontFile { get; set; }
        public FontDialog(MainForm parent)
        {
            pfc = null;
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.parent = parent;
            LoadFonts();
            LoadSettings_2();
        }
        public void LoadSettings_2()
        {

            Directory.SetCurrentDirectory($"{Application.ExecutablePath}\\..\\..\\..");
            try
            {
                StreamReader reader = new StreamReader("Settings.ini");
                reader.ReadLine();
                reader.ReadLine();
                reader.ReadLine();
                reader.ReadLine();
                reader.ReadLine();
                reader.ReadLine();
                reader.ReadLine();
                this.FontFile = reader.ReadLine();
                comboBoxFonts.Font = ApplyFontExample(FontFile);
                //comboBoxFonts.Font.Size = 8.25;
                ApplyFontExample(FontFile);
                value_1 = decimal.Parse(reader.ReadLine());
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
            this.numericUpDownFontSize.Value = value_1;
        }
        void LoadFonts()
        {
            //AllocConsole();
            Console.WriteLine(Application.ExecutablePath);
            //Directory.SetCurrentDirectory($"{Application.ExecutablePath}");
            Directory.SetCurrentDirectory($"{Application.ExecutablePath}\\..\\..\\..\\Fonts");
            Console.WriteLine(Directory.GetCurrentDirectory());
            LoadFonts(Directory.GetCurrentDirectory(),"*.ttf");
            LoadFonts(Directory.GetCurrentDirectory(),"*.otf");
            Traverse(Directory.GetCurrentDirectory());
            comboBoxFonts.Items.AddRange(fonts.Keys.ToArray());
        }
        void LoadFonts(string path, string extension)
        {
            string[] files = Directory.GetFiles(path, extension);
            for (int i = 0; i < files.Length; i++)
            {
                //files[i] = Path.GetFileName(files[i]);
                //files[i] = files[i].Split('\\').Last();
                if (fonts.ContainsKey(files[i].Split('\\').Last())) continue;
                fonts.Add(files[i].Split('\\').Last()/*.Split('.').First()*/, files[i]);
            }
           // comboBoxFonts.Items.AddRange(files);
        }
        void Traverse(string path)
        {
            LoadFonts(path, "*.ttf");
            LoadFonts(path, "*.otf");
            string[] directories = Directory.GetDirectories(path);
            if (directories.Length == 0) return;
            for(int i = 0;i < directories.Length;i++)
            {
                Traverse(directories[i]);
            }
        }
        [DllImport("kernel32.dll")]
        public static extern void AllocConsole();
        [DllImport("kernel32.dll")]
        public static extern void FreeConsole();
        private void FontDialog_Load(object sender, EventArgs e)
        {
            this.Location = new Point
                (
                   this.parent.Location.X - this.Width/4,
                   this.parent.Location.Y + 100
                );
            //LoadFonts();
            //ApplyFontExample(FontFile);
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.Font = labelExemple.Font;
            this.FontFile = fonts[comboBoxFonts.SelectedItem.ToString()];
        }
        public Font ApplyFontExample(string filename)
        {
            if(pfc != null) pfc.Dispose();
            pfc = new PrivateFontCollection();
            pfc.AddFontFile(filename);
            return labelExemple.Font = new Font(pfc.Families[0], (float)numericUpDownFontSize.Value);
        }
        private void comboBoxFonts_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFontExample(fonts[comboBoxFonts.SelectedItem.ToString()]);
        }

        private void numericUpDownFontSize_ValueChanged(object sender, EventArgs e)
        {
            //LoadFonts(Directory.GetCurrentDirectory(), "*.ttf");
            //LoadFonts(Directory.GetCurrentDirectory(), "*.otf");
            //Traverse(Directory.GetCurrentDirectory());
            if(check == false)
            {
                ApplyFontExample(fonts[comboBoxFonts.SelectedItem.ToString()]);
            }
            value_1 = numericUpDownFontSize.Value;
            check = false;
        }
    }
}

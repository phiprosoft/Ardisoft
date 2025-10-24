using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arduino_Display2
{
    public partial class Form1 : Form
    {
        SerialPort serialPort;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            serialPort = new SerialPort("COM3", 9600);
            serialPort.Open();

            // Page1 bekommt den Port übergeben
            var page1 = new Page1(serialPort);
            LoadPage(page1);
        }

        private void LoadPage(UserControl page)
        {
            panelContainer.Controls.Clear();   // Alte Seite entfernen
            page.Dock = DockStyle.Fill;        // Seite füllt den Container
            panelContainer.Controls.Add(page); // Neue Seite einfügen
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            LoadPage(new Page1(serialPort));
        }

        private void toolStripTextBox2_Click(object sender, EventArgs e)
        {
            LoadPage(new Page2(serialPort));
        }

    }
}

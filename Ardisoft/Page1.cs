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
    public partial class Page1 : UserControl
    {
        private SerialPort serialPort;

        public Page1() // leerer Konstruktor
        {
            InitializeComponent();
        }

        public Page1(SerialPort port) // Konstruktor mit Port
        {
            InitializeComponent();
            this.serialPort = port;
        }


        public void send_Click(object sender, EventArgs e)
        {
            if (serialPort != null && serialPort.IsOpen)
            {
                serialPort.WriteLine(txtInput.Text);
                txtInput.Text = null;
            }
        }
    }
}

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
    public partial class Page2 : UserControl
    {
        private SerialPort serialPort;

        public Page2() // leerer Konstruktor (falls du ihn brauchst)
        {
            InitializeComponent();
        }

        public Page2(SerialPort port) // Konstruktor mit Port
        {
            InitializeComponent();
            this.serialPort = port;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SouboryBin08
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(@"..\..\VyskyVeTride.dat", FileMode.Create);
            fs.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string jmeno = textBox1.Text;
            int vyska = int.Parse(textBox2.Text);
            FileStream fs = new FileStream(@"..\..\VyskyVeTride.dat", FileMode.Open, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(jmeno);
            bw.Write(vyska);
            fs.Close();
        }

        public double prumer;
        public string nejvyssiJmeno;
        public string nejmensiJmeno = "";

        private void button3_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(@"..\..\VyskyVeTride.dat",FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            int pc = 0;
            int sc = 0;
            int nejvyssi = 0;
            int nejmensi = 300;
            while (br.BaseStream.Position<br.BaseStream.Length)
            {
                string jmeno = br.ReadString();
                int vyska = br.ReadInt32();
                sc += vyska;
                pc++;
                if(vyska>nejvyssi)
                {
                    nejvyssi = vyska;
                    nejvyssiJmeno = jmeno;
                }
                if(vyska<nejmensi)
                {
                    nejmensi=vyska; 
                    nejmensiJmeno = jmeno;
                }
                string radek = jmeno + " " + vyska + " cm";
                listBox1.Items.Add(jmeno);
            }
            prumer = (double)sc / pc;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label1.Text = "Pruměr ve třidě: " + prumer;
            label2.Text = "Nejvyšší: " + nejvyssiJmeno;
            label3.Text = "Nejmenší: " + nejmensiJmeno;
        }
    }
}

using CaveGen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CavePreview
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        CellularAutomata<bool> automata;
        Bitmap image;

        const int width = 50, height = 50, initialFillPercentage = 40;
        private void btnGen_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            automata = new CellularAutomata<bool>(width, height, () => r.Next(100) < initialFillPercentage);
            automata.BoundaryState = true;
            automata.LoopHorizontal = true;
            automata.LoopVertical = false;
            
            image = new Bitmap(width, height);
            UpdateImage();
        }

        private void btnGrow_Click(object sender, EventArgs e)
        {
            automata.Iterate(CaveGenerator.GrowAndContract, 1);
            UpdateImage();
        }

        private void btnContract_Click(object sender, EventArgs e)
        {
            automata.Iterate(CaveGenerator.Contract, 1);
            UpdateImage();
        }

        private void UpdateImage()
        {
            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                    image.SetPixel(x, y, automata.Data[x, y] ? Color.Black : Color.White);

            if (chkAutoEnhance.Checked)
                btnEnhance_Click(null, EventArgs.Empty);
            else
                preview.Image = image;
        }

        private void btnEnhance_Click(object sender, EventArgs e)
        {
            preview.Image = CaveGenerator.EnhanceImage(automata);
        }

        private void chkAutoEnhance_CheckedChanged(object sender, EventArgs e)
        {
            btnEnhance.Enabled = !chkAutoEnhance.Checked;
        }

        private void btnOffset_Click(object sender, EventArgs e)
        {
            CaveGenerator.Offset(automata);
            UpdateImage();
        }
    }
}

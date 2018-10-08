using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Griye_Çevirme_Yöntemleri
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            
        }

        Bitmap Resim, cevir, kayit;
        int max;
        int min;
       


        private void ekleToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DialogResult sonuc = openFileDialog1.ShowDialog();
            

            if (sonuc == DialogResult.OK)
            {

                Resim = new Bitmap(openFileDialog1.FileName);

                pictureBox1.Image = Resim;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            int a = Resim.Width;
            int b = Resim.Height;

             cevir = new Bitmap(a, b);

            for (int x = 0; x < a; x++)
            {
                for (int y = 0; y < b; y++)
                {
                    Color renkli = Resim.GetPixel(x, y);
                    int gri = (int)((renkli.R* .3) + (renkli.G*.59) + (renkli.B*.11));
                    Color grili = Color.FromArgb(gri, gri, gri);
                    cevir.SetPixel(x, y, grili);

                }
            }

            pictureBox2.Image = cevir;
        }

        private void temizleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int a = Resim.Width;
            int b = Resim.Height;

            cevir = new Bitmap(a, b);

            for (int x = 0; x < a; x++)
            {
                for (int y = 0; y < b; y++)
                {
                    Color renkli = Resim.GetPixel(x, y);
                    int gri = (int)((renkli.R * 0.2125) + (renkli.G * 0.7154) + (renkli.B * 0.072));
                    Color grili = Color.FromArgb(gri, gri, gri);
                    cevir.SetPixel(x, y, grili);

                }
            }

            pictureBox2.Image = cevir;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int a = Resim.Width;
            int b = Resim.Height;
            

            cevir = new Bitmap(a, b);

            for (int x = 0; x < a; x++)
            {
                for (int y = 0; y < b; y++)
                {
                    Color renkli = Resim.GetPixel(x, y);

                    if (renkli.R > renkli.G && renkli.R > renkli.B) { max = renkli.R; }
                    if (renkli.G > renkli.R && renkli.G > renkli.B) { max = renkli.G; }
                    if (renkli.B > renkli.G && renkli.B > renkli.R) { max = renkli.B; }

                    if (renkli.R < renkli.G && renkli.R < renkli.B) { min = renkli.R; }
                    if (renkli.G < renkli.R && renkli.G < renkli.B) { min = renkli.G; }
                    if (renkli.B < renkli.G && renkli.B < renkli.R) { min = renkli.B; }





                    int gri =(int) (max+min) / 2;
                    Color grili = Color.FromArgb(gri, gri, gri);
                    cevir.SetPixel(x, y, grili);

                }
            }

            pictureBox2.Image = cevir;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int a = Resim.Width;
            int b = Resim.Height;

            cevir = new Bitmap(a, b);

            for (int x = 0; x < a; x++)
            {
                for (int y = 0; y < b; y++)
                {
                    
                    Color renkli = Resim.GetPixel(x, y);
                    int c = renkli.A;
                    int r = renkli.R;
                    int g = renkli.G;
                    int d = renkli.B;
                    
                    
                     cevir.SetPixel(x, y, Color.FromArgb(Resim.GetPixel(x,y).A,Resim.GetPixel(x,y).R,0,0)); 
                    

                }
            }

            pictureBox2.Image = cevir;
        }

        private void kaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "PNG|*.png";
            DialogResult sonuc = saveFileDialog1.ShowDialog();
            ImageFormat format = ImageFormat.Png;
            if (sonuc == DialogResult.OK)
            {
                cevir.Save(saveFileDialog1.FileName, format);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a = Resim.Width;
            int b = Resim.Height;

            cevir = new Bitmap(a, b);
            
            for( int x=0; x < a; x++)
            {
                for(int y=0;y<b;y++)
                {
                    Color renkli = Resim.GetPixel(x, y);
                    int gri = (renkli.R + renkli.G + renkli.B) / 3;
                    Color grili = Color.FromArgb(gri, gri, gri);
                    cevir.SetPixel(x, y, grili);

                }
            }

            pictureBox2.Image = cevir;

        }
    }
}

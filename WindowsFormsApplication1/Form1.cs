using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication1
{
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }

            public static int usercount = 1;
            public static bool [] pr = new bool [9];
            public static int[,] im = new int[3, 3];
            public static bool igra = false;

            private void button1_Click_1(object sender, EventArgs e)
            {
                for (int i = 0; i < 9; i++)
                    pr[i] = false;
                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < 3; j++)
                        im[i,j] = 0;
                
                pictureBox1.Image = null;
                pictureBox2.Image = null;
                pictureBox3.Image = null;
                pictureBox4.Image = null;
                pictureBox5.Image = null;
                pictureBox6.Image = null;
                pictureBox7.Image = null;
                pictureBox8.Image = null;
                pictureBox9.Image = null;
                usercount = 1;
                loadlabel();
                igra = true;
            }

            private void loadlabel()
            {
                label1.Text = "Игрок " + Convert.ToString(usercount);
            }

            private void zap(object sender, System.Windows.Forms.MouseEventArgs e)
            
            {
                if (igra)
                {
                int k = 0;
                int j=0;
                PictureBox img = sender as PictureBox;

                int number = Convert.ToInt32(img.Name[img.Name.Length-1]);
                if ((number - 49) <= 2)
                {
                    k = 0;
                    j = 0;
                }
                if (((number - 49) >= 3) && ((number - 49) <= 5)) { j = 1; k = 3; };
                if (((number - 49) >= 6)) { j = 2; k = 6; };

                if (im[number - 49 - k, j] == 0)
                {
                    if ((e.Button == MouseButtons.Left) && (usercount == 1))
                    {
                        img.Image = imageList1.Images[0];
                        usercount = 2;
                        im[number - 49 - k, j] = 1;
                    }
                    if ((e.Button == MouseButtons.Right) && (usercount == 2))
                    {
                        img.Image = imageList1.Images[1];
                        usercount = 1;
                        im[number - 49 - k, j] = -2;
                    }
                    loadlabel();
                    if (proverka() == true) MessageBox.Show("Победа игрока " + usercount);
                }
               }

            }

            private bool proverka()
            {
                int i, j, sum_raw = 0, sum_col = 0, sum_gl = 0, sum_pob = 0 ;
                bool prover = false;


                 for ( i = 0; i < 3; i++)
                 {
                     sum_raw =0;
                     sum_col = 0;
                     for (j = 0; j < 3; j++)
                     {
                         sum_raw += im[i, j];
                         sum_col += im[j, i];
                     }
                     sum_gl += im[i, i];
                     sum_pob += im[i, 2 - i];

                     if ((sum_raw == 3) || (sum_col == 3) || (sum_gl == 3) || (sum_pob == 3)) 
                     {
                         prover = true;
                         usercount = 1;
                         igra = !prover;
                         return prover;
                     }
                     if ((sum_raw == -6) || (sum_col == -6) || (sum_gl == -6) || (sum_pob == -6))
                     {
                         prover = true;
                         usercount = 2;
                         igra = !prover;
                         return prover;
                     
                     }
                 }
                 return prover;

            }

            private void Form1_Load(object sender, EventArgs e)
            {
                
            }

           
    }
}

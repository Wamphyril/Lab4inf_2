using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Lab4._2iikt
{
    public partial class Form1 : Form
    {
        float xPos = 10;
        float yPos = 10;
        Bitmap b;
        Bitmap c;
        Bitmap g = new Bitmap(@"C:\Users\Admin\Desktop\444\Новая папка\Lab4\Lab4.2iikt\t.PNG");
        Bitmap khearts = new Bitmap(@"C:\Users\Admin\Desktop\444\Новая папка\Lab4\Lab4.2iikt\p.PNG");
        int k = 2;
        int max = 36;
        public Form1()
        {
            InitializeComponent();
        }

        public void DrawElements()
        {
           
            Graphics dc = CreateGraphics();
            Graphics bufDC = Graphics.FromImage(c);           
            bufDC.DrawImage(khearts, xPos, yPos, 100, 140);
            bufDC.Dispose();
            dc.DrawImage(c, 0, 0);

        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            b = new Bitmap(ClientRectangle.Width, ClientRectangle.Height);
            back();
            this.BackgroundImage = b;
           
        }
        public void back()
        {
          
            Graphics bufDC = Graphics.FromImage(b);
            bufDC.FillRectangle(new LinearGradientBrush(new Point(0, 0), new Point(ClientRectangle.Width, ClientRectangle.Height), Color.Purple, Color.DarkGreen), ClientRectangle);

            k = 2;
            max = 36;
            for (int i = 0; i < max; i++)
            {
                if (i > 30)
                {
                    bufDC.DrawImage(khearts, 10 + k, 10 + k, 100, 140);
                    k += 2;
                }
                else
                    bufDC.DrawImage(khearts, 10, 10, 100, 140);
            }
            bufDC.Dispose();
            Rectangle rec = new Rectangle(0, 0, ClientRectangle.Width, ClientRectangle.Height);
            c = b.Clone(rec, b.PixelFormat);
        }

        bool da = true;
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
           
            if (e.Button == System.Windows.Forms.MouseButtons.Left && flag && max>0)
            {
                Cursor.Clip = new Rectangle(this.RectangleToScreen(this.ClientRectangle).Location, this.RectangleToScreen(this.ClientRectangle).Size);

                xPos = e.X;
                yPos = e.Y;
                Rectangle rec = new Rectangle(0, 0, ClientRectangle.Width, ClientRectangle.Height);
                c = b.Clone(rec, b.PixelFormat);
                DrawElements();
                da = true;
            }
          
        }

        private void Form1_Resize(object sender, EventArgs e)
        {

        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            
        }
        int[,] matrix = new int[4, 9];
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (da)
            {
                Random rnd = new Random();
                
                int[] arrayX = new int[9];
                for(int i=0, j = 345;i<arrayX.Length;i++)
                {
                    arrayX[i] = j;
                    j += 87;

                }
                int[] arrayY = new int[4];
                for (int i = 0, j = 0; i < arrayY.Length; i++)
                {
                    arrayY[i] = j;
                    j += 122;

                }
                
                int x = rnd.Next(0, 9);
                int y = rnd.Next(0, 4);
                while(matrix[y,x]==1)
                {
                    x = rnd.Next(0, 9);
                    y = rnd.Next(0, 4);
                }
                matrix[y, x] = 1;
                Rectangle recb = new Rectangle(arrayX[x], arrayY[y], 76, 112) ;
                Bitmap bmp = g.Clone(recb, g.PixelFormat);
            
                Rectangle rec = new Rectangle(0, 0, ClientRectangle.Width, ClientRectangle.Height);
                c = b.Clone(rec, b.PixelFormat);
               
                float alfa = rnd.Next(-90, 90);
                
                Graphics dc = CreateGraphics();
                Graphics bufDC = Graphics.FromImage(c);
                bufDC.TranslateTransform(e.X, e.Y);
                bufDC.RotateTransform(alfa);
                bufDC.TranslateTransform(-e.X, -e.Y);
                bufDC.DrawImage(bmp, xPos, yPos, 100, 140);

                bufDC.Dispose();
                dc.DrawImage(c, 0, 0);
                Rectangle recc = new Rectangle(0, 0, ClientRectangle.Width, ClientRectangle.Height);
                b = c.Clone(recc, c.PixelFormat);
                da = false;
                max--;
                Cursor.Clip = Rectangle.Empty;
            }
          
        }
        bool flag = false;
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.X > 10 && e.Y > 10 && e.X < 120 && e.Y < 160)
                flag = true;
            else
                flag = false;
            

        }

        private void Form1_MouseLeave(object sender, EventArgs e)
        {
            flag = false;
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.F2)
            {
                b = new Bitmap(ClientRectangle.Width, ClientRectangle.Height);
                back();
                this.BackgroundImage = b;
            }

        }
    }
}

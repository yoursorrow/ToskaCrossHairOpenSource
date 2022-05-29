using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Windows.Controls.Ribbon;

namespace ToskaCrossHairOpenSource
{
    public partial class ToskaCross : Form
    {
        Overlay crosshairOverlay = new Overlay();

        public ToskaCross()
        {
            InitializeComponent();
        }

        // Brush colors, these were temporary but left in for static changing and an example of using the auto-update for the preview.
        public SolidBrush red = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
        public SolidBrush blue = new System.Drawing.SolidBrush(System.Drawing.Color.Blue);
        public SolidBrush currentcolor = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
        public SolidBrush realColor;


        // SUBJECT END


        // NEEDED!!! Used inside auto-update
        private void clearPreview(PaintEventArgs e)
        {
            e.Graphics.Clear(Color.Red);
        }
        // SUBJECT END

        // Draws the 'crosshair' on the form in a preview form.
        private void previewCrosshair(SolidBrush color, int x, int y)
        {
            int xV = x;
            int yV = y;
            System.Drawing.SolidBrush myBrush = currentcolor;
            System.Drawing.Graphics formGraphics;
            formGraphics = this.CreateGraphics();
            formGraphics.FillEllipse(myBrush, new Rectangle(100, 100, xV, yV));
            currentcolor = null;


        }
        // SUBJECT END
        private void ToskaCross_Load(object sender, EventArgs e)
        {
            Location = new Point(Bottom + 1050, Right);
            previewCrosshair(red, 16, 16);

        }

        // 'isp' C# wait function for WinForms using timers
        public void wait(int milliseconds)
        {
            var timer1 = new System.Windows.Forms.Timer();
            if (milliseconds == 0 || milliseconds < 0) return;

            // Console.WriteLine("start wait timer");
            timer1.Interval = milliseconds;
            timer1.Enabled = true;
            timer1.Start();

            timer1.Tick += (s, e) =>
            {
                timer1.Enabled = false;
                timer1.Stop();
                // Console.WriteLine("stop wait timer");
            };

            while (timer1.Enabled)
            {
                Application.DoEvents();
            }
        }
        // SUBJECT END

        


        private void onOrOff_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        // TOO LAZY TO TAKE THESE OUT OF REX DONT MIND
        private void crosshairText_Click(object sender, EventArgs e)
        {

        }

        private void ToskaLabel_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        // SUBEJCT END

        // Draggable top panel, really neat feature for creating "modern" designs ;)
        private bool mouseDown;
        private Point lastLocation;

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1mouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void panel1MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void panel1MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
        // end subject

        //show color dialog

        private void label2_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                SolidBrush color = new SolidBrush(colorDialog1.Color);
                this.currentcolor = color;
                previewCrosshair(currentcolor, 8, 8);
            }
        }

        //end subject


        // Opens overlay and sends over color info
        private void flatToggle1_CheckedChanged(object sender)
        {

            if(flatToggle1.Checked == true)
            {
                SolidBrush color = new SolidBrush(colorDialog1.Color);
                this.realColor = color;
                crosshairOverlay.Show();
                crosshairOverlay.previewCrosshair(color, 16, 16);
            }
            else
            {
                crosshairOverlay.Hide();
            }
        }
        // end subject



        // SUBJECT END
    }
}

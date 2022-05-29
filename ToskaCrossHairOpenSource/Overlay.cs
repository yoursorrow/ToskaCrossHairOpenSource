using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToskaCrossHairOpenSource
{
    public partial class Overlay : Form
    {

        public Overlay()
        {
            InitializeComponent();
        }

        // 'isp' C# wait function for WinForms using timers
        public void wait(int milliseconds)
        {
            var timer1 = new System.Windows.Forms.Timer();
            if (milliseconds == 0 || milliseconds < 0) return;

            timer1.Interval = milliseconds;
            timer1.Enabled = true;
            timer1.Start();

            timer1.Tick += (s, e) =>
            {
                timer1.Enabled = false;
                timer1.Stop();
            };

            while (timer1.Enabled)
            {
                Application.DoEvents();
            }
        }
        // end subject




        // on load do a bunch of transparency and wait stuff


        private void Overlay_Load(object sender, EventArgs e)
        {
            ToskaCross mainForm = new ToskaCross();
            this.BackColor = Color.Wheat;
            this.TransparencyKey = Color.Wheat;
            this.TopMost = true;
            wait(5000);
            label1.Visible = false;
            DisableMouse();
                    
            
        }
        // end subject

        //stores
        Rectangle BoundRect;
        Rectangle OldRect = Rectangle.Empty;
        //end subject

        // disables mouse capture & movement within rect
        private void DisableMouse()
        {
            OldRect = Cursor.Clip;
            // Arbitrary location.
            BoundRect = new Rectangle(50, 50, 1, 1);
            Cursor.Clip = BoundRect;
            Cursor.Hide();
        }

        //emd sibkect
        // same function as in TonkaCross.cs but like, idk it works the way its supposed to
        public void previewCrosshair(SolidBrush color, int x, int y)
        {
            ToskaCross mainForm = new ToskaCross();
            int xV = x;
            int yV = y;
            System.Drawing.Graphics formGraphics;
            formGraphics = this.CreateGraphics();
            formGraphics.FillEllipse(color, new Rectangle(324, 204, xV, yV));
            color = null;


        }

        //end subject
    }
}

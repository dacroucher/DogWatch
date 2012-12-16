using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DogWatch.Imaging;

namespace DogWatch
{
    public partial class MotionDebugPanel : Form
    {
        MotionDetector md;
        CamInterface cam;

        bool wait = true;
        public MotionDebugPanel(CamInterface source, MotionDetector motionDetect)
        {
            cam = source;
            md = motionDetect;
            InitializeComponent();

            cam.NewFrame += new NewFrameEventHandler(cam_NewFrame);
        }

        void cam_NewFrame(object sender, EventArgs e)
        {
            if (wait)
            {
                wait = false;
            }
            else
            {
                Action action = () =>


                currentViewBox.Image = new Bitmap(md.frame_c, currentViewBox.Size);
                pictureBox1.Image = new Bitmap(md.frame_gs, currentViewBox.Size);
                pictureBox2.Image = new Bitmap(md.frame_processed, currentViewBox.Size);
                pictureBox3.Image = new Bitmap(md.back, currentViewBox.Size);

                this.Invoke(action);
            }
        }




    }
}

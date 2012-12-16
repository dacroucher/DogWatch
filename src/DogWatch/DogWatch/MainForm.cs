using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DogWatch.Networking;
using DogWatch.Imaging;


namespace DogWatch
{
    public partial class MainForm : Form
    {
        private CamInterface cam;
        private MotionDetector motionDetect;
        private System.Timers.Timer motionTimeout;

        public MainForm()
        {
            motionTimeout = new System.Timers.Timer(2000);
            motionTimeout.Elapsed += new System.Timers.ElapsedEventHandler(motionTimeout_Elapsed);
            cam = new CamInterface();
            //cam.NewFrame += new NewFrameEventHandler(cam_NewFrame);            
            //new VideoForm(cam).Show();
            //new TestPanel().Show();
            motionDetect = new MotionDetector(cam, 1024,576);
            motionDetect.MotionDetected += new MotionDetectedEventHandler(motionDetect_MotionDetected);
            Network.Init(9762);
            InitializeComponent();
            new MotionDebugPanel(cam,motionDetect).Show();
        }


        private void motionDetect_MotionDetected(object sender, EventArgs e)
        {
            if(motionTimeout.Enabled)
                motionTimeout.Stop();
            Action action = () =>
                notificationBox.Text = "MOTION DETECTED!";
            this.Invoke(action);
            motionTimeout.Start();
        }


        private void cam_NewFrame(object sender, EventArgs e)
        {
            Bitmap frame = new Bitmap((Bitmap)cam.Frame().Clone(),currentViewBox.Size);
            Action action = () =>        
                        currentViewBox.Image = frame;
                this.Invoke(action);            
        }

        private void listenButton_Click(object sender, EventArgs e)
        {
            Network.listener.Listen();            
        }


        void motionTimeout_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Action action = () =>
                notificationBox.Text = "";
            this.Invoke(action);     
        }



    }
}

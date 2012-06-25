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
        CamInterface cam;

        public MainForm()
        {
            cam = new CamInterface();
            //cam.NewFrame += new NewFrameEventHandler(cam_NewFrame);
            new VideoForm(cam).Show();
            Network.Init(9762);
            InitializeComponent();            
        }



        private void cam_NewFrame(object sender, EventArgs e)
        {
            Bitmap temp = (Bitmap)cam.Frame().Clone();
            Bitmap t2 = new Bitmap(temp, currentViewBox.Size);
            Action action = () =>        
                        currentViewBox.Image = t2;                                
                this.Invoke(action);
            
        }

        private void listenButton_Click(object sender, EventArgs e)
        {
            Network.listener.Listen();            
        }


        


    }
}

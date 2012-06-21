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
            cam.NewFrame += new NewFrameEventHandler(cam_NewFrame);
            Network.Init(9762);
            InitializeComponent();
        }

        private void cam_NewFrame(object sender, EventArgs e)
        {
            currentViewBox.Image = cam.Frame();
        }

        private void listenButton_Click(object sender, EventArgs e)
        {
            Network.listener.Listen();            
        }

        


    }
}

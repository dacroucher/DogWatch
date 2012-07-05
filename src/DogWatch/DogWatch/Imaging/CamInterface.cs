using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AForge;
using AForge.Video.DirectShow;
using System.Drawing;

namespace DogWatch.Imaging
{    
    public delegate void NewFrameEventHandler(object sender, EventArgs e);

    public class CamInterface
    {
        VideoCaptureDevice source;        
        private Bitmap currFrame;
        public event NewFrameEventHandler NewFrame;
        
        public CamInterface()
        {
            InitCam();
            source.Start();
        }

        private void InitCam()
        {
            FilterInfoCollection videoDevice = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            source = new VideoCaptureDevice(videoDevice[0].MonikerString);
            source.DesiredSnapshotSize = new Size(1024,576);
            source.DesiredFrameSize = new Size(1024, 576);
            source.DesiredFrameRate = 15;
            source.NewFrame += new AForge.Video.NewFrameEventHandler(source_NewFrame);
        }

        private void source_NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        {
            currFrame = eventArgs.Frame;
            if(NewFrame != null)
                NewFrame(this, EventArgs.Empty);
        }

        public void Dispose()
        {
            source.SignalToStop();
            source.WaitForStop();
            source = null;            
        }

        public Bitmap Frame()
        {
            return currFrame;
        }

    }
}

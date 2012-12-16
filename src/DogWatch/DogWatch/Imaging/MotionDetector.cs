using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Imaging;
using System.Drawing;
using AForge;
using DogWatch.Imaging;
using AForge.Imaging.Filters;
using AForge.Imaging;



namespace DogWatch.Imaging
{
    public delegate void MotionDetectedEventHandler(object sender, EventArgs e);

    public class MotionDetector
    {
        public event MotionDetectedEventHandler MotionDetected;

        private CamInterface source;

        //Frame Properties
        private short m_width;
        public short width
        {
            get { return m_width; }
            set
            {
                m_width = value;
                size = new Size(m_width, m_height);
            }
        }
        private short m_height;
        public short height
        {
            get { return m_height; }
            set
            {
                m_height = value;
                size = new Size(m_width, m_height);
            }
        }               
        private Size size;

        //Filter Properties
        private const double MORPH_PERCENT = 0.7;
        private const short MIN_BLOB = 30;
        private const short MAX_BLOB = 2000;
        private const short THRESHOLD = 40;

        //Frames
        public Bitmap frame_c;
        public Bitmap frame_pre;
        public Bitmap frame_gs;
        public Bitmap back;
        public Bitmap frame_processed;

        //Filters
        private FiltersSequence motionFilter;
        private Grayscale gsFilter;
        private IFilter preFilter;
        private Morph morphFilter;
        private Difference diffFilter;

        //MotionCheck
        private BlobCounter blobCount;
        

        public MotionDetector(CamInterface cam, short frameWidth, short frameHeight)
        {
            source = cam;
            m_width = frameWidth;
            m_height = frameHeight;
            size = new Size(m_width, m_height);
            InitFilters();
            cam.NewFrame += new NewFrameEventHandler(cam_NewFrame);
        }

        private void InitFilters()
        {
            gsFilter = new Grayscale(0.33, 0.33, 0.33);
            diffFilter = new Difference();
            motionFilter = new FiltersSequence();            
            motionFilter.Add(new Threshold(THRESHOLD));
            motionFilter.Add(new BlobsFiltering(MIN_BLOB, MIN_BLOB, MAX_BLOB, MAX_BLOB, true));
            morphFilter = new Morph();
            morphFilter.SourcePercent = MORPH_PERCENT;
            blobCount = new BlobCounter();
            blobCount.MinHeight = MIN_BLOB;
            blobCount.MaxHeight = MAX_BLOB;
        }

        private void cam_NewFrame(object sender, EventArgs e)
        {
            frame_c = new Bitmap((Bitmap)source.Frame().Clone());
            ProcessFrame();            
        }

        private void ProcessFrame()
        {
            //Check for preprocess filter & filter to grey
            if (preFilter != null)
            {
                frame_pre = preFilter.Apply(frame_c);
                frame_gs = gsFilter.Apply(frame_pre);
            }
            else
            {
                frame_gs = gsFilter.Apply(frame_c);
            }

            //Initialise Background
            if (back == null)
            {
                back = (Bitmap)frame_gs.Clone();
            }

            //Process frame for motion
            diffFilter.OverlayImage = back;
            frame_processed = diffFilter.Apply(frame_gs);
            frame_processed = motionFilter.Apply(frame_processed);

            CheckMotion();

            //Update Background
            morphFilter.OverlayImage = frame_gs;
            back = morphFilter.Apply(back);
        }

        public void IncludePreProcess(IFilter filter)
        {
            preFilter = filter;
        }

        private void SignalMotion()
        {
            if (MotionDetected != null)
                MotionDetected(this, EventArgs.Empty);
        }

        public void Dispose()
        {
            if (source != null)
                source.NewFrame -= cam_NewFrame;
            if (frame_c != null)
                frame_c.Dispose();
            if (frame_gs != null)
                frame_gs.Dispose();
            if(frame_pre !=null)
                frame_pre.Dispose();
            if (frame_processed != null)
                frame_processed.Dispose();
        }

        private void CheckMotion()
        {
            blobCount.ProcessImage(frame_processed);
            
            /* Tryout drawing*/
            Rectangle[] rects = blobCount.GetObjectsRectangles();
            // create graphics object from initial image
            Graphics g = Graphics.FromImage(frame_c);
            // draw each rectangle
            using (Pen pen = new Pen(Color.Red, 1))
            {
                foreach (Rectangle rc in rects)
                {
                    g.DrawRectangle(pen, rc);

                    if ((rc.Width > 15) && (rc.Height > 15))
                    {
                        // here we can higligh large objects with something else
                    }
                }
            }
            g.Dispose();

            
            if (blobCount.GetObjectsRectangles().Length > 1)
                SignalMotion();
        }
    }
}

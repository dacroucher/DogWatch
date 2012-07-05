using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using AForge;
using DogWatch.Imaging;
using AForge.Imaging.Filters;
using AForge.Imaging;
using AForge.Vision.Motion;

namespace DogWatch
{
    public partial class VideoForm : Form
    {
        private CamInterface source;
        private Bitmap curr_c;
        private Bitmap curr_gs;
        private Bitmap back;
        private Bitmap processed;

        private bool first = true;

        private Difference diffFilter;
        private IFilter thresholdFilter;
        private IFilter erosionFilter;
        private MoveTowards towardsFilter;
        private Edges edgeFilter;
        private Opening openFilter;
        private Pixellate pixelFilter;
        private Morph morphFilter;
        private ExtractBiggestBlob blobGrabber;
        private BlobCounter blobCounter;
        Grayscale gs = new Grayscale(0.33, 0.33, 0.33);


        public VideoForm(CamInterface c)
        {
            InitFilters();
            InitializeComponent();
            source = c;
            c.NewFrame += new NewFrameEventHandler(cam_NewFrame);
        }

        private void cam_NewFrame(object sender, EventArgs e)
        {
            curr_c = new Bitmap((Bitmap)source.Frame().Clone(), preBox.Size);
            curr_gs = gs.Apply(curr_c);

            Action action = () =>
                {
                    processed = ProcessCurrentFrame();
                    postBox.Image = processed;
                    preBox.Image = curr_c;
                    backBox.Image = back;                    
                };
            if (!this.IsDisposed && !this.Disposing)
                this.Invoke(action);
        }

        private void InitFilters()
        {

            diffFilter = new Difference();
            diffFilter.OverlayImage = back;

            thresholdFilter = new Threshold(20);

            erosionFilter = new Erosion();

            edgeFilter = new Edges();

            openFilter = new Opening();

            pixelFilter = new Pixellate();

            morphFilter = new Morph();
            morphFilter.SourcePercent = 0.9;

            towardsFilter = new MoveTowards();
            towardsFilter.StepSize = 10;

            blobCounter = new BlobCounter();
            blobGrabber = new ExtractBiggestBlob();

        }

        private Bitmap PreProcess(Bitmap bmp)
        {
            
            return bmp;
        }

        private Bitmap ProcessCurrentFrame()
        {
            Bitmap bmp;

            //curr_gs = pixelFilter.Apply(curr_gs);

            if (first)
            {
                back = (Bitmap)curr_gs.Clone();
                first = false;
            }

            /* Detection */

            diffFilter.OverlayImage = back;
            bmp = diffFilter.Apply(curr_gs);
            bmp = thresholdFilter.Apply(bmp);
            bmp = erosionFilter.Apply(bmp);
            bmp = openFilter.Apply(bmp);
            bmp = edgeFilter.Apply(bmp);

            try
            {
                //blobCount.Text = blobGrabber.Apply(bmp).Size.ToString();
            }
            catch (Exception)
            {
            }
            

            /* Transcribe to original image */

            // extract red channel from the original image
            IFilter extrachChannel = new ExtractChannel(RGB.R);
            Bitmap redChannel = extrachChannel.Apply(curr_c);
            //  merge red channel with motion regions
            Merge mergeFilter = new Merge();
            mergeFilter.OverlayImage = bmp;
            Bitmap tmp4 = mergeFilter.Apply(redChannel);
            // replace red channel in the original image
            ReplaceChannel replaceChannel = new ReplaceChannel(RGB.R,tmp4);            
            curr_c = replaceChannel.Apply(curr_c);

            /* Background Update */
            //towardsFilter.OverlayImage = curr_gs;            
            //back = towardsFilter.Apply(back);
            morphFilter.OverlayImage = curr_gs;
            back = morphFilter.Apply(back);


            return bmp;
        }

        private int CheckMotion()
        {
             int count = 0;
            // lock difference image
            BitmapData data = processed.LockBits( new Rectangle( 0, 0, processed.Width, processed.Height ),
                ImageLockMode.ReadOnly, PixelFormat.Format8bppIndexed );
            int offset = data.Stride - processed.Width;
            unsafe
            {
                byte * ptr = (byte *) data.Scan0.ToPointer( );
                for ( int y = 0; y < processed.Height; y++ )
                {
                    for ( int x = 0; x < processed.Width; x++, ptr++ )
                    {
                        count += ( (*ptr) >> 7 );
                    }
                    ptr += offset;
                }
            }
            // unlock image
            processed.UnlockBits( data );
            return count;

        }
    }
}

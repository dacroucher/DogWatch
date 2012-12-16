using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AForge;
using DogWatch.Imaging;
using AForge.Imaging.Filters;
using AForge.Imaging;
using AForge.Vision.Motion;

namespace DogWatch
{
    public partial class TestPanel : Form
    {

        ExtractChannel redFilter = new ExtractChannel(RGB.R);
        ExtractChannel greenFilter = new ExtractChannel(RGB.G);
        ExtractChannel blueFilter = new ExtractChannel(RGB.B);        
        ExtractChannel selected;

        ColorFiltering brownFilter = new ColorFiltering();
               
        Threshold thresholdFilter = new Threshold( 100 );

        public TestPanel()
        {
            InitializeComponent();
            selected = redFilter;

            for (int x = 0; x < 187; x++)
            {
                comboBox1.Items.Add(x);
            }

            brownFilter.Red = new IntRange(55,85);
            brownFilter.Green = new IntRange(45,75);
            brownFilter.Blue = new IntRange(45,75);

            comboBox2.Items.Add("Re");
            comboBox2.Items.Add("Gr");
            comboBox2.Items.Add("Bl");            

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = new Bitmap(Bitmap.FromFile("C:\\testimg\\" +comboBox1.SelectedIndex + ".png"), pictureBox1.Size);
            Bitmap channel = selected.Apply((Bitmap)pictureBox1.Image);
            thresholdFilter = new Threshold(Int32.Parse(textBox1.Text));
            thresholdFilter.ApplyInPlace(channel);
            pictureBox2.Image = channel;
            pictureBox3.Image = brownFilter.Apply((Bitmap)pictureBox1.Image);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox2.SelectedIndex)
            {
                case 0:
                    selected = redFilter;
                    break;
                case 1:
                    selected = greenFilter;
                    break;
                case 2:
                    selected = blueFilter;
                    break;                
                default:
                    break;

            }
            Bitmap channel = selected.Apply((Bitmap)pictureBox1.Image);
            thresholdFilter = new Threshold(Int32.Parse(textBox1.Text));
            thresholdFilter.ApplyInPlace(channel);
            pictureBox2.Image = channel;
        }



    }
}

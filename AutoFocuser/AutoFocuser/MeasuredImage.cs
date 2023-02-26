using AForge.Imaging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFocuser
{
    public class MeasuredImage
    {
        public Bitmap Image { get; set; }
        public float HFDValue { get; set; }
        public List<Blob> Blobs { get; set; }
        public bool Processed { get; set; }
        public MeasuredImage()
        {
            Image = null;
            HFDValue = 0;
            Blobs = new List<Blob>();
            Processed = false;
        }
    }
}

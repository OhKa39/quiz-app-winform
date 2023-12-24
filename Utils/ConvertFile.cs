using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Utils
{
    public class ConvertFile
    {
        public static Image convertByteToImage(byte[] byteArrayIn)
        {
            Image abc;
            using (var ms = new MemoryStream(byteArrayIn))
            {
                return Image.FromStream(ms);
            }
        }
    }
}

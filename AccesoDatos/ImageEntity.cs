using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    /// <summary>
    /// 
    /// </summary>
    public class ImageEntity
    {
        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }

        public byte[] imageToByteArray(string url)
        {
            System.Drawing.Image imageIn=Image.FromFile(url);
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;



        }
    }
}




//Convert the image to a byte[] and store that in the database.

//Add this column to your model:

//public byte[] Content { get; set; }

//Then convert your image to a byte array and store that like you would any other data:

//public byte[] imageToByteArray(System.Drawing.Image imageIn)
//{
//    MemoryStream ms = new MemoryStream();
//    imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
//    return ms.ToArray();
//}

//public Image byteArrayToImage(byte[] byteArrayIn)
//{
//    MemoryStream ms = new MemoryStream(byteArrayIn);
//    Image returnImage = Image.FromStream(ms);
//    return returnImage;
//}

//Source: Fastest way to convert Image to Byte array

//var image = new ImageEntity()
//{
//    Content = imageToByteArray(image)
//}
//_Context.Images.Add(image);
//_Context.SaveChanges();

//When you want to get the image back, get the byte array from the database and use the byteArrayToImage and do what you wish with the Image

//As per my comment I did not use EF for my solution as it stops working when the byte[] gets to big.It should however work for files under 100Mb

//(Solution when using big files: http://www.syntaxwarriors.com/2013/stream-varbinary-data-to-and-from-mssql-using-csharp/)


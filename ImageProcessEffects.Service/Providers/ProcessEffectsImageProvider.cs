using ImageProcessEffects.Core.Providers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Net.Mime;
using System.Text;

namespace ImageProcessEffects.Service.Providers
{
    public class ProcessEffectsImageProvider : IProcessEffectsImageProvider
    {
        public string ImagenToBase64(Image img, ImageFormat format)
        {
            byte[] imagebyte = ImageToByte(img, format);
            string encodedImage = Convert.ToBase64String(imagebyte);
            return encodedImage;
        }

        public byte[] ImageToByte(Image img, ImageFormat format)
        {
            using (var stream = new MemoryStream())
            {
                img.Save(stream, format);
                return stream.ToArray();
            }
        }

        public Image ProcesarNegativa(Image img)
        {
            Bitmap bmpInverted = new Bitmap(img.Width, img.Height);
            ImageAttributes imageAttributes = new ImageAttributes();
            ColorMatrix colorMatrix = new ColorMatrix(new float[][]
                        {
                            new float[]{-1, 0, 0, 0, 0},
                            new float[]{0, -1, 0, 0, 0},
                            new float[]{0, 0, -1, 0, 0},
                            new float[]{0, 0, 0, 1, 0},
                            new float[]{1, 1, 1, 1, 1}
                        });

            Graphics g = Graphics.FromImage(bmpInverted);
            g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, imageAttributes);
            g.Dispose();
            img = bmpInverted;

            return img;
        }

        public  Image ProcesarEscalaGrises(Image img)
        {
            Bitmap bmpInverted = new Bitmap(img.Width, img.Height);
            ImageAttributes imageAttributes = new ImageAttributes();
            ColorMatrix colorMatrix = new ColorMatrix(new float[][]
                       {
                            new float[]{.3f, .3f, .3f, 0, 0},
                            new float[]{.59f, .59f, .59f, 0, 0},
                            new float[]{.11f, .11f, .11f, 0, 0},
                            new float[]{0, 0, 0, 1, 0},
                            new float[]{0, 0, 0, 0, 1}
                       });

            Graphics g = Graphics.FromImage(bmpInverted);
            g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, imageAttributes);
            g.Dispose();
            img = bmpInverted;

            return img;
        }

        public Image ProcesarTransparecia(Image img)
        {
            Bitmap bmpInverted = new Bitmap(img.Width, img.Height);
            ImageAttributes imageAttributes = new ImageAttributes();
            ColorMatrix colorMatrix = new ColorMatrix(new float[][]
                        {
                            new float[]{1, 0, 0, 0, 0},
                            new float[]{0, 1, 0, 0, 0},
                            new float[]{0, 0, 1, 0, 0},
                            new float[]{0, 0, 0, 0.3f, 0},
                            new float[]{0, 0, 0, 0, 1}
                        });

            imageAttributes.SetColorMatrix(colorMatrix);

            Graphics g = Graphics.FromImage(bmpInverted);
            g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, imageAttributes);
            g.Dispose();
            img = bmpInverted;

            return img;
        }
        
        public Image ProcesarTonoSepia(Image img)
        {
            Bitmap bmpInverted = new Bitmap(img.Width, img.Height);
            ImageAttributes imageAttributes = new ImageAttributes();

            ColorMatrix colorMatrix = new ColorMatrix(new float[][]
                     {
                        new float[]{.393f, .349f, .272f, 0, 0},
                        new float[]{.769f, .686f, .534f, 0, 0},
                        new float[]{.189f, .168f, .131f, 0, 0},
                        new float[]{0, 0, 0, 1, 0},
                        new float[]{0, 0, 0, 0, 1}
                     });

            imageAttributes.SetColorMatrix(colorMatrix);

            Graphics g = Graphics.FromImage(bmpInverted);
            g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, imageAttributes);
            g.Dispose();
            img = bmpInverted;

            return img;
        }

        public Image RedimencionarImagen(Image img,int alto, int ancho)
        {
            var destRect = new Rectangle(0, 0, ancho, alto);
            var destImage = new Bitmap(ancho, alto);

            destImage.SetResolution(img.HorizontalResolution, img.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(img, destRect, 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }
    }
}

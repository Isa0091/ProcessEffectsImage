using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessEffects.Core
{
    /// <summary>
    /// en esta clase se alojaran los diferentes enum que utilizaremos
    /// </summary>
    public class Enums
    {

        /// <summary>
        /// enum que define el ipo de efecto que se le dara a  la imagen
        /// </summary>
        public enum TipoEffecto
        {
            Sepia = 0,
            EscalaGris= 1,
            Trasnparencia=2,
            Negativo=3
        };
        /// <summary>
        /// enum que define los tipos de formatos
        /// </summary>
        public enum FormatoImagen
        {
            Bmp = 0,
            Emf = 1,
            Exif = 2,
            Gif = 3,
            Icon = 4,
            Jpeg = 5,
            MemoryBmp = 6,
            Png = 7,
            Tiff = 8,
            Wmf = 9,
        }
    }
}

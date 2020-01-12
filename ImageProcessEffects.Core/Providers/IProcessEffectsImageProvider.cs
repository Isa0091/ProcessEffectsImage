using ImageProcessEffects.Core.DTO.ProcessImageDTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;

namespace ImageProcessEffects.Core.Providers
{
    /// <summary>
    /// provider que se encarga de hacer el procesamiento de las diferentes
    /// efectos de las imagenes
    /// </summary>
    public interface IProcessEffectsImageProvider
    {
        /// <summary>
        /// convierte un tipo image a bytes
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        byte[] ImageToByte(Image img , ImageFormat format);
        /// <summary>
        /// procesa el tono sepia de una imagen
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        Image ProcesarTonoSepia(Image img);
        /// <summary>
        /// convierte un tipo image a base 64
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        string ImagenToBase64(Image img, ImageFormat format);
        /// <summary>
        /// redimenciona una iumagen con datos especificos
        /// </summary>
        /// <param name="alto"></param>
        /// <param name="Ancho"></param>
        /// <returns></returns>
        Image RedimencionarImagen(Image img,int alto, int Ancho);
    }
}

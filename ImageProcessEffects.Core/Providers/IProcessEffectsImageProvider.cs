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
        /// redimenciona una imagen con datos especificos
        /// </summary>
        /// <param name="alto"></param>
        /// <param name="Ancho"></param>
        /// <returns></returns>
        Image RedimencionarImagen(Image img,int alto, int Ancho);
        /// <summary>
        /// procesa una imagen con transparecia
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        Image ProcesarTransparecia(Image img);
        /// <summary>
        /// procesa una imagen para hacerla tono negativa
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        Image ProcesarNegativa(Image img);
        /// <summary>
        /// procesa una imagen a tono de escala de grises
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        Image ProcesarEscalaGrises(Image img);
    }
}

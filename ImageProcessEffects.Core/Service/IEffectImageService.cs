using ImageProcessEffects.Core.DTO.ProcessImageDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessEffects.Core.Service
{
    /// <summary>
    /// servicio proporcionado para el procesamiento de
    /// los tipos de efectos
    /// </summary>
    public interface IEffectImageService
    {
        /// <summary>
        /// procesa la operacion de añadir effecto
        /// a la imagen
        /// </summary>
        /// <param name="proccessDataImage"></param>
        /// <returns></returns>
        ResultProcessImageDTO AddEffectoImagen(ProcessDataImageDTO proccessDataImage);
    }
}

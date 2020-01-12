using System;
using System.Collections.Generic;
using System.Text;
using static ImageProcessEffects.Core.Enums;

namespace ImageProcessEffects.Core.DTO.ProcessImageDTO
{
    /// <summary>
    /// DTo de resultado del procesamiento de la imagen
    /// </summary>
    public class ResultProcessImageDTO
    {
        /// <summary>
        /// indica la imagen procesada en base 64
        /// </summary>
        public string ImagenProcesadaBase64{ get; set; }

        /// <summary>
        /// indica el tipo de efecto que se le dara a la imagen
        /// </summary>
        public TipoEffecto TipoEffecto { get; set; }
    }
}

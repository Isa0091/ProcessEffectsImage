using System;
using System.Collections.Generic;
using System.Text;
using static ImageProcessEffects.Core.Enums;

namespace ImageProcessEffects.Core.DTO.ProcessImageDTO
{
    /// <summary>
    ///Esta clase envia lo necesario para el procesamiento de 
    ///la imagen
    /// </summary>
    public class ProcessDataImageDTO
    {
        /// <summary>
        /// la iamgen en base 64 la cual se procesara
        /// </summary>
        public string ImagenBase64 { get; set; }
        /// <summary>
        /// el alto de la imagen a procesar
        /// </summary>
        public int? Alto { get; set; }
        /// <summary>
        /// el ancho de la imagen a procesar
        /// </summary>
        public int? Ancho { get; set; }
        /// <summary>
        /// indica el tipo de efecto que se le dara a la imagen
        /// </summary>
        public TipoEffecto TipoEffecto { get; set; }
        /// <summary>
        /// enum que identifica el tipo de formato de la imagen
        /// </summary>
        public FormatoImagen formatoImagen { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ImageProcessEffects.Core.Enums;

namespace ImageProcessEffects.DTO.Input
{
    /// <summary>
    /// procesa una imagen a varios efectos
    /// </summary>
    public class ProcessImagesInputDTO
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
        public List<TipoEffecto> TiposEffectos { get; set; }
        /// <summary>
        /// enum que identifica el tipo de formato de la imagen
        /// </summary>
        public FormatoImagen formatoImagen { get; set; }
        /// <summary>
        /// se redimenciona la calidad de la imagen
        /// </summary>
        public int Calidad { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Drawing;
using System.IO;
using ImageProcessEffects.Core.Service;
using ImageProcessEffects.Core.DTO.ProcessImageDTO;
using ImageProcessEffects.DTO.Input;

namespace ImageProcessEffects.Controllers
{
    [Route("api/ImagesProcess")]
    [ApiController]
    public class ProcessImagesController : ControllerBase
    {
        private IHostingEnvironment _env;
        private readonly IEffectImageService _effectImageService;

        public ProcessImagesController(IHostingEnvironment env, IEffectImageService effectImageService)
        {
            _env = env;
            _effectImageService = effectImageService;
        }

        /// <summary>
        /// agrega un efecto especifico a una imagen
        /// </summary>
        /// <param name="processDataImage"></param>
        /// <returns></returns>
        [HttpPost("TonoImagen")]
        [ProducesResponseType(200)]
        public IActionResult AgregarEfectoTono([FromBody] ProcessDataImageDTO processDataImage)
        {
            ResultProcessImageDTO resultProcessImage = _effectImageService.AddEffectoImagen(processDataImage);
            return Ok(resultProcessImage);
        }

        /// <summary>
        /// agrega un efecto especifico a una lista de imagenes 
        /// </summary>
        /// <param name="processDataImage"></param>
        /// <returns></returns>
        [HttpPost("TonosImagenes")]
        [ProducesResponseType(200)]
        public IActionResult AgregarTonalidadesAImagenes([FromBody] ProcessImagesInputDTO processImagesInput)
        {
            List<ResultProcessImageDTO> resultProcessImages = new List<ResultProcessImageDTO>();

            processImagesInput.TiposEffectos.ForEach(z =>
            {
                ProcessDataImageDTO processDataImage = new ProcessDataImageDTO()
                {
                     Alto= processImagesInput.Alto,
                     Ancho= processImagesInput.Ancho,
                     Calidad= processImagesInput.Calidad,
                     formatoImagen= processImagesInput.formatoImagen,
                     ImagenBase64= processImagesInput.ImagenBase64,
                     TipoEffecto= z
                };
                ResultProcessImageDTO resultProcessImage = _effectImageService.AddEffectoImagen(processDataImage);
                resultProcessImages.Add(resultProcessImage);
            });
           
            return Ok(resultProcessImages);
        }

    }
}
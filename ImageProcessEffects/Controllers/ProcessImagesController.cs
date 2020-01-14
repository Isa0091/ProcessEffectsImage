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
using Microsoft.Extensions.Hosting;
using AutoMapper;

namespace ImageProcessEffects.Controllers
{
    [Route("api/ImagesProcess")]
    [ApiController]
    public class ProcessImagesController : ControllerBase
    {
        private readonly IEffectImageService _effectImageService;
        private readonly IMapper _mapper;

        public ProcessImagesController(IMapper mapper,IEffectImageService effectImageService)
        {
            _effectImageService = effectImageService;
            _mapper = mapper;
        }

        /// <summary>
        /// agrega un efecto especifico a una imagen
        /// </summary>
        /// <param name="processDataImage"></param>
        /// <returns></returns>
        [HttpPost("TonoImagen")]
        [ProducesResponseType(200,Type= typeof(ResultProcessImageDTO))]
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
        [ProducesResponseType(200, Type = typeof(List<ResultProcessImageDTO>))]
        public IActionResult AgregarTonalidadesAImagenes([FromBody] ProcessImagesInputDTO processImagesInput)
        {
            List<ResultProcessImageDTO> resultProcessImages = new List<ResultProcessImageDTO>();
            //mapeo mi dto de entrada del api a uno que necesaita el servicio
            ProcessDataImageDTO processDataImage = _mapper.Map<ProcessDataImageDTO>(processImagesInput);

            //recorro los efectos ya que la demas data< es igul para todo
            processImagesInput.TiposEffectos.ForEach(z =>
            {
                 processDataImage.TipoEffecto = z;
                 ResultProcessImageDTO resultProcessImage = _effectImageService.AddEffectoImagen(processDataImage);
                resultProcessImages.Add(resultProcessImage);
            });
           
            return Ok(resultProcessImages);
        }

    }
}
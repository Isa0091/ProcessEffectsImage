using ImageProcessEffects.Core.DTO.ProcessImageDTO;
using ImageProcessEffects.Core.Providers;
using ImageProcessEffects.Core.Service;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;

namespace ImageProcessEffects.Service
{
    public class EffectImageService : IEffectImageService
    {
        private readonly IProcessEffectsImageProvider _processEffectsImageProvider;

        public EffectImageService(IProcessEffectsImageProvider processEffectsImageProvider)
        {

            _processEffectsImageProvider = processEffectsImageProvider;
        }
        public ResultProcessImageDTO AddEffectoImagen(ProcessDataImageDTO processDataImage)
        {
            ResultProcessImageDTO resultProcessImage = new ResultProcessImageDTO();
            resultProcessImage.TipoEffecto = processDataImage.TipoEffecto;

            string Base64String = processDataImage.ImagenBase64.Replace("data:image/png;base64,","");
            byte[] bytes = Convert.FromBase64String(Base64String);
            Image image;

            using (MemoryStream ms = new MemoryStream(bytes))
            {
                image = Image.FromStream(ms);
                image = _processEffectsImageProvider.RedimencionarImagen(image, processDataImage.Alto, processDataImage.Ancho);
            }


            switch (processDataImage.TipoEffecto)
            {
                case Core.Enums.TipoEffecto.Sepia:

                    image = _processEffectsImageProvider.ProcesarTonoSepia(image);
                    break;
            }

            //TODO aun no se esta usando el enum de nuestro sistema del formato
            string imagenbase64 =_processEffectsImageProvider.ImagenToBase64(image, ImageFormat.Png);
            resultProcessImage.ImagenProcesadaBase64 = imagenbase64;

            return resultProcessImage;
        }
    }
}

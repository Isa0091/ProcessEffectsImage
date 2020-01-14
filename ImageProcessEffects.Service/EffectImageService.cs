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

                if(processDataImage.Alto.HasValue && processDataImage.Ancho.HasValue)
                image = _processEffectsImageProvider.RedimencionarImagen(image,(int) processDataImage.Alto,(int)processDataImage.Ancho);
            }


            switch (processDataImage.TipoEffecto)
            {
                case Core.Enums.TipoEffecto.Sepia:
                    image = _processEffectsImageProvider.ProcesarTonoSepia(image);
                    break;
                case Core.Enums.TipoEffecto.Trasnparencia:
                    image = _processEffectsImageProvider.ProcesarTransparecia(image);
                    break;
                case Core.Enums.TipoEffecto.Negativo:
                    image = _processEffectsImageProvider.ProcesarNegativa(image);
                    break;
                case Core.Enums.TipoEffecto.EscalaGris:
                    image = _processEffectsImageProvider.ProcesarEscalaGrises(image);
                    break;
            }

            //TODO aun no se esta usando el enum de nuestro sistema del formato
            string imagenbase64 =_processEffectsImageProvider.ImagenToBase64(image, ImageFormat.Png);
            resultProcessImage.ImagenProcesadaBase64 = imagenbase64;

            return resultProcessImage;
        }
    }
}

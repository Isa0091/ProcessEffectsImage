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
        [HttpPost()]
        [ProducesResponseType(200)]
        public async Task<IActionResult> AgregarEfecto([FromBody] ProcessDataImageDTO processDataImage )
        {
            ResultProcessImageDTO resultProcessImage = _effectImageService.AddEffectoImagen(processDataImage);
            return Ok(resultProcessImage);
        }



        private void GuardarImagen(string imagenBase64)
        {

            var webRoot = _env.WebRootPath;
            var PathWithFolderName = "~/Temp";

            if (!Directory.Exists(PathWithFolderName))
            {
                // Try to create the directory.
                DirectoryInfo di = Directory.CreateDirectory(PathWithFolderName);


                string Base64String = imagenBase64.Replace("data:image/png;base64,", "");

                byte[] bytes = Convert.FromBase64String(Base64String);

                Image image;
                using (MemoryStream ms = new MemoryStream(bytes))
                {

                    image = Image.FromStream(ms);
                    Bitmap bmpInverted = new Bitmap(image.Width, image.Height);

                    ImageAttributes imageAttributes = new ImageAttributes();
                    imageAttributes.SetColorMatrix(DrawAsSepiaTone());
                    Graphics g = Graphics.FromImage(bmpInverted);
                    g.DrawImage(image, new Rectangle(0, 0, image.Width, image.Height), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, imageAttributes);
                    g.Dispose();

                    image = bmpInverted;
                }

                image.Save(PathWithFolderName + "/ImageName.png");
            }

        }

        private ColorMatrix DrawAsSepiaTone()
        {
            ColorMatrix colorMatrix = new ColorMatrix(new float[][]
                       {
                        new float[]{.393f, .349f, .272f, 0, 0},
                        new float[]{.769f, .686f, .534f, 0, 0},
                        new float[]{.189f, .168f, .131f, 0, 0},
                        new float[]{0, 0, 0, 1, 0},
                        new float[]{0, 0, 0, 0, 1}
                       });

            return colorMatrix;
        }


        private byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }
    }
}
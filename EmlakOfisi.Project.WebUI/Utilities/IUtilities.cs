using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmlakOfisi.Project.WebUI.Utilities
{
   public  interface IUtilities
   {
       SelectList SelectCity(string selectedCity = null, string userId = null);
        
       SelectList SelectRoom(string selectedRoom=null, string userId = null);

       string UploadImages(string webRootPath, string imageClassPath, IFormFile formfile);

   }
}

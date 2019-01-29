using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KymiraAdmin.Pages
{
    public class UploadModel : PageModel
    {
        public void OnGet()
        {

        }

        private IHostingEnvironment _hostingEnvironment;

        public UploadModel(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public ActionResult OnPostUpload()
        {

        }
    }
}
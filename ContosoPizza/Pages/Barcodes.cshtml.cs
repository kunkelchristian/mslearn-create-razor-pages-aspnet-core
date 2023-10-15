using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Hosting.Internal;
using Net.Codecrete.QrCodeGenerator;
using Net.ConnectCode.Barcode;


namespace ContosoPizza.Pages
{
    public class BarcodesModel : PageModel
    {

        private readonly IWebHostEnvironment hostingEnvironment;

        public BarcodesModel (IWebHostEnvironment environment){
            this.hostingEnvironment = environment;
        }
        public void OnGet()
        {
            
        }

        public ActionResult OnPostQR (string qrText){
            var qr = QrCode.EncodeText(qrText, QrCode.Ecc.Medium);
            string svg = qr.ToSvgString(4);
            string fileName = Guid.NewGuid().ToString() + "_" + "qr.svg";
            var dataFile = Path.Combine(hostingEnvironment.WebRootPath, fileName); 
            System.IO.File.WriteAllText(dataFile, svg, System.Text.Encoding.UTF8);
            ViewData["DataFile"] = fileName;
            return Page();
        }

    }
}

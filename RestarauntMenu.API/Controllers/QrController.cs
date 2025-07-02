using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestarauntMenu.Application.UseCases.QrCodeServices;

namespace RestarauntMenu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QrController : ControllerBase
    {
        private readonly IQrCodeService _qrCodeService;

        public QrController(IQrCodeService qrCodeService)
        {
            _qrCodeService = qrCodeService;
        }

        [HttpGet]
        public IActionResult GetQrCode([FromQuery] string text)
        {
            var qrBytes = _qrCodeService.GenerateQrCode(text);
            return File(qrBytes, "image/png");
        }
    }
}

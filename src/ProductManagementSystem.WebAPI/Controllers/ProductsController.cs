using Microsoft.AspNetCore.Mvc;
using ProductManagementSystem.Core.Interfaces;
using ProductManagementSystem.WebAPI.Services;

namespace ProductManagementSystem.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : ApiControllerBase
    {
        private readonly IProductAddService productAddService;
        private readonly IFileUploadService fileUploadService;

        public ProductsController(
            IProductAddService productAddService,
            IFileUploadService fileUploadService)
        {
            this.productAddService = productAddService;
            this.fileUploadService = fileUploadService;
        }

        [HttpPost]
        public async Task<IActionResult> AddProducts()
        {
            string fileName = await fileUploadService.UploadFileAsync(HttpContext.Request);
            await productAddService.AddProductsAsync(fileName);

            return Ok();
        }
    }
}

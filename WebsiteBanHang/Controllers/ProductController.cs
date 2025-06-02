using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebsiteBanHang.Models; // Thay thế bằng namespace thực tế của bạn
using WebsiteBanHang.Repositories;
namespace WebsiteBanHang.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductController(IProductRepository productRepository,
       ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        // GET: Product/Add
        public IActionResult Add()
        {
            ViewBag.Categories = new SelectList(_categoryRepository.GetAllCategories(), "Id", "Name");
            return View();
        }

        // POST: Product/Add
        [HttpPost]
        public async Task<IActionResult> Add(Product product, IFormFile imageUrl, List<IFormFile> imageUrls)
        {
            if (ModelState.IsValid)
            {
                if (imageUrl != null)
                {
                    product.ImageUrl = await SaveImage(imageUrl);
                }
                if (imageUrls != null && imageUrls.Count > 0)
                {
                    product.ImageUrls = new List<string>();
                    foreach (var file in imageUrls)
                    {
                        product.ImageUrls.Add(await SaveImage(file));
                    }
                }
                _productRepository.Add(product);
                return RedirectToAction("Index");
            }
            ViewBag.Categories = new SelectList(_categoryRepository.GetAllCategories(), "Id", "Name");
            return View(product);
        }

        // Display a list of products
        public IActionResult Index()
        {
            var products = _productRepository.GetAll();
            return View(products);
        }

        public IActionResult Display(int id)
        {
            var product = _productRepository.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // Show the product update form
        public IActionResult Update(int id)
        {
            var product = _productRepository.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewBag.Categories = new SelectList(_categoryRepository.GetAllCategories(), "Id", "Name");
            return View(product);
        }

        // Process the product update
        [HttpPost]
        public IActionResult Update(Product product)
        {
            if (ModelState.IsValid)
            {
                _productRepository.Update(product);
                return RedirectToAction("Index");
            }
            ViewBag.Categories = new SelectList(_categoryRepository.GetAllCategories(), "Id", "Name");
            return View(product);
        }

        // Show the product delete confirmation
        public IActionResult Delete(int id)
        {
            var product = _productRepository.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        private async Task<string> SaveImage(IFormFile image)
        {
            // Thay đổi đường dẫn theo cấu hình của bạn
            var savePath = Path.Combine("wwwroot/images", image.FileName);
            using (var fileStream = new FileStream(savePath, FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
            }
            return "/images/" + image.FileName; // Trả về đường dẫn tương đối
        }

        // Process the product deletion
        [HttpPost, ActionName("DeleteConfirmed")]
        public IActionResult DeleteConfirmed(int id)
        {
            _productRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}

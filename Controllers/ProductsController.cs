using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DavShop.Data;
using DavShop.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DutchTreat.Controllers
{
  [Route("api/[Controller]")]
  [ApiController]
  [Produces("application/json")]
  public class ProductsController : ControllerBase
  {
    private readonly IDavRepository _repository;
    private readonly ILogger<ProductsController> _logger;

    public ProductsController(IDavRepository repository, ILogger<ProductsController> logger)
    {
      _repository = repository;
      _logger = logger;
    }

    [HttpGet]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public ActionResult<IEnumerable<Product>> Get()
    {
      try
      {
        return Ok(_repository.GetAllProducts()); 
      }
      catch (Exception ex)
      {
        _logger.LogError($"Failed to get products: {ex}");
        return BadRequest("failed to get products");
      }
    }
  }
}

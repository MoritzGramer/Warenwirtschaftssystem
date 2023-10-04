using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Warenwirtschaftssystem;

namespace WebApiProjekt.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ArtikelController : ControllerBase
{
    private readonly ArtikelRepository _repository;


    public ArtikelController(ArtikelRepository repository)
    {
        _repository = repository;
    }



    [HttpGet("{id}")]
    public IActionResult GetArtikel(string id)
    {
        var artikel = _repository.GetArtikelById(id);

        if (artikel == null)
        {
            return NotFound();
        }
        return Ok(artikel);
    }
}


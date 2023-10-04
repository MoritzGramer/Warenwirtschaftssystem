using System;
using System.Linq;

namespace Warenwirtschaftssystem;

public class ArtikelRepository
{
    private readonly ApplicationDbContext _context;

    public ArtikelRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Artikel GetArtikelById(string id)
    {
        return _context.Artikel.FirstOrDefault(a => a.Artikelnummer == id);
    }
}
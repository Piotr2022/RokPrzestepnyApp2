using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RokPrzestepnyZBaza.Data;
using RokPrzestepnyZBaza.Model;

namespace RokPrzestepnyZBaza.Pages
{
    public class HistoriaModel : PageModel
    {
        private readonly ILogger<HistoriaModel> _logger;
        private readonly RokPrzestepnyDbContext _context;

        public HistoriaModel(ILogger<HistoriaModel> logger, RokPrzestepnyDbContext context)
        {
            _logger = logger;
            _context = context;
        }



        [BindProperty]
        public List<WpisPrzestepnosci> lista { get; set; }


        public void OnGet()
        {
            lista = _context.WpisyPrzestepnosci.ToList();
            lista = lista.OrderBy(x => x.Data).ToList();
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var wpis = this._context.WpisyPrzestepnosci.Find(id);

            if (wpis == null)
            {
                return NotFound();
            }

            this._context.WpisyPrzestepnosci.Remove(wpis);
            this._context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

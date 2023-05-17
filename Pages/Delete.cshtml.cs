using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RokPrzestepnyZBaza.Data;

namespace RokPrzestepnyZBaza.Pages
{
    public class DeleteModel : PageModel
    {

        private readonly ILogger<HistoriaModel> _logger;
        private readonly RokPrzestepnyDbContext _context;


        public DeleteModel(ILogger<HistoriaModel> logger, RokPrzestepnyDbContext context, IConfiguration configuration)
        {
            _logger = logger;
            _context = context;
        }

        [BindProperty]
        public int? ID { get; set; } 


        public void onGet(int? id)
        {
            if(id != null)
            {
                ID = id;
            }
        }

        public IActionResult OnPost()
        {

            var wpis = this._context.WpisyPrzestepnosci.Find(ID);

            if (wpis != null)
            {
                this._context.WpisyPrzestepnosci.Remove(wpis);
                this._context.SaveChanges();
            }


            return RedirectToPage("./Historia");
        }
    }
}

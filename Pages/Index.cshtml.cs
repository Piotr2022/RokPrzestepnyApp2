using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RokPrzestepnyZBaza.Data;
using RokPrzestepnyZBaza.Model;
using System.Security.Claims;

namespace RokPrzestepnyZBaza.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        //[BindProperty]
        //public WpisPrzestepnosci wpisPrzestepnosci { get; set; }



        [BindProperty]
        public int Rok { get; set; }

        [BindProperty]
        public string? Imie { get; set; }

        public string? Message { get; set; }


        private readonly RokPrzestepnyDbContext _context;

        public IndexModel(ILogger<IndexModel> logger, RokPrzestepnyDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {


            if (ModelState.IsValid)
            {
                WpisPrzestepnosci wpisPrzestepnosci = new WpisPrzestepnosci();

                wpisPrzestepnosci.Rok = Rok;
                wpisPrzestepnosci.Imie = Imie;

                Message = wpisPrzestepnosci.get_Message();

                string newData = wpisPrzestepnosci.Imie + ", " + wpisPrzestepnosci.Rok + " - ";

                if (wpisPrzestepnosci.czy_Przestepny() == true)
                {
                    newData += "rok przestępny";
                }
                else
                {
                    newData += "rok nieprzestępny";
                }

                wpisPrzestepnosci.Data = DateTime.Now;
                wpisPrzestepnosci.Login = HttpContext.User.Identity.Name ?? "";
                wpisPrzestepnosci.loginID = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "";
                wpisPrzestepnosci.Result = wpisPrzestepnosci.get_Message();

                _context.WpisyPrzestepnosci.Add(wpisPrzestepnosci);
                _context.SaveChanges();
            }
            return Page();
        }
    }
}
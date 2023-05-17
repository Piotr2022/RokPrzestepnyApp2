using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RokPrzestepnyZBaza.Data;
using RokPrzestepnyZBaza.Model;
using Microsoft.Extensions.Configuration;
namespace RokPrzestepnyZBaza.Pages
{
    public class HistoriaModel : PageModel
    {
        private readonly ILogger<HistoriaModel> _logger;
        private readonly RokPrzestepnyDbContext _context;
        private readonly IConfiguration Configuration;


        public HistoriaModel(ILogger<HistoriaModel> logger, RokPrzestepnyDbContext context, IConfiguration configuration)
        {
            _logger = logger;
            _context = context;
            Configuration = configuration;
            pageIndexValue = 1;
        }



        public PaginatedList<WpisPrzestepnosci> lista { get; set; }


        [BindProperty]
        public int? pageIndexValue { get; set; }

        public async Task OnGetAsync(int? pageIndex)
        {
            
            IQueryable<WpisPrzestepnosci> wpisyIQ = from w in _context.WpisyPrzestepnosci select w;
            wpisyIQ = wpisyIQ.OrderByDescending(w => w.Data);



            pageIndexValue = pageIndex;

            var pageSize = Configuration.GetValue("PageSize", 20);
            lista = await PaginatedList<WpisPrzestepnosci>.CreateAsync(wpisyIQ.AsNoTracking(),pageIndex ?? 1, pageSize);
        }
    }
}

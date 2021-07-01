using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Common.Data;
using Common.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using WebApp.Helper;

namespace WebApp.Pages.Colors
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        public IndexModel(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        //public IList<Color> Color { get;set; }
        public PaginatedList<Color> Colors { get; set; }
        public string CurrentSearch { get; set; }

        public async Task OnGetAsync(string search,int? pageIndex)
        {
            //System.Diagnostics.Debug.WriteLine(_configuration.GetValue("PageSize", 3));
            CurrentSearch = search;
            var pageSize = _configuration.GetValue("PageSize", 4);
            IQueryable<Color> colorsIQ = from s in _context.Color select s;
            if (!String.IsNullOrEmpty(search))
            {
                colorsIQ = colorsIQ.Where(s => s.Name.Contains(search));
            }
            Colors = await PaginatedList<Color>.CreateAsync(
                colorsIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
            //Color = await _context.Color.ToListAsync();
        }
    }
}

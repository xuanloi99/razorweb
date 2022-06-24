using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Pages.Blog
{
    public class IndexModel : PageModel
    {
        private readonly WebApplication1.Models.MyBlogContext _context;

        public IndexModel(WebApplication1.Models.MyBlogContext context)
        {
            _context = context;
        }

        public IList<Article> Article { get;set; }
        public const int Items_Per_Page = 10;
        [BindProperty(SupportsGet = true, Name = "p")]
        public int CurrentPage { get; set; }
        public int CountPages { get; set; }
        public async Task OnGetAsync(string searchString)
        {
            int totalAticles = await _context.articles.CountAsync();
            CountPages = (int) Math.Ceiling(totalAticles *1.0 / Items_Per_Page);
            if (CurrentPage <1)
            {
                CurrentPage = 1;
            }
            else if (CurrentPage > CountPages)
            {
                CurrentPage = CountPages;
            }
            //Article = await _context.articles.ToListAsync();
            var qr = (from a in _context.articles
                     orderby a.Created descending
                     select a)
                     .Skip((CurrentPage-1) * Items_Per_Page)
                     .Take(Items_Per_Page);
            if (!string.IsNullOrEmpty(searchString))
            {
                Article = await qr.Where(a => a.Title.Contains(searchString)).ToListAsync();
            }
            else
            {
                Article = await qr.ToListAsync();
            }
            
        }
    }
}

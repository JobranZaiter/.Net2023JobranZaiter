using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Project.Infrastructure.NewFolder
{
    public class CategoryViewComponent : ViewComponent
    {
        private readonly DataContext _context;

        public CategoryViewComponent(DataContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync() => View(await _context.Categories.ToListAsync());
    }
}

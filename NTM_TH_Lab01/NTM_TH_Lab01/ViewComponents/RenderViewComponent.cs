using Microsoft.AspNetCore.Mvc;
using NTM_TH_Lab01.Models;

namespace NTM_TH_Lab01.ViewComponents
{
    public class RenderViewComponent : ViewComponent
    {
        private List<MenuItem> MenuItems = new List<MenuItem>();

        public RenderViewComponent()
        {
            // Khởi tạo danh sách các mục Menu động
            MenuItems = new List<MenuItem>()
            {
                new MenuItem()
                {
                    Id = 1,
                    Name = "Branches",
                    Link = "Admin/Branch/List"
                },
                new MenuItem()
                {
                    Id = 2,
                    Name = "Students",
                    Link = "Admin/Student/List"
                },
                new MenuItem()
                {
                    Id = 3,
                    Name = "Subjects",
                    Link = "Admin/Subject/List"
                },
                new MenuItem()
                {
                    Id = 4,
                    Name = "Courses",
                    Link = "Admin/Course/List"
                }
            };
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            // Trả về View có tên "RenderLeftMenu" kèm theo danh sách MenuItems
            return View("RenderLeftMenu", MenuItems);
        }
    }
}
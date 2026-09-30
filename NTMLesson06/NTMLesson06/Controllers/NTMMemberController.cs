using Microsoft.AspNetCore.Mvc;
using NTMLesson06.Models;

namespace NTMLesson06.Controllers
{
    public class NTMMemberController : Controller
    {
        // mock data
        private static readonly List<NTMMember> members = new List<NTMMember>()
        {
            new NTMMember()
            {
                ID = Guid.NewGuid().ToString(),
                username = "hehe",
                password = "123",
                email = "123@hehe.com",
                fullname = "ronaldo"
            },

            new NTMMember()
            {
                ID = Guid.NewGuid().ToString(),
                username = "hehe",
                password = "123",
                email = "123@hehe.com",
                fullname = "ronaldo"
            },

            new NTMMember()
            {
                ID = Guid.NewGuid().ToString(),
                username = "hehe",
                password = "123",
                email = "123@hehe.com",
                fullname = "ronaldo"
            },

            new NTMMember()
            {
                ID = Guid.NewGuid().ToString(),
                username = "hehe",
                password = "123",
                email = "123@hehe.com",
                fullname = "ronaldo"
            },

            new NTMMember()
            {
                ID = Guid.NewGuid().ToString(),
                username = "hehe",
                password = "123",
                email = "123@hehe.com",
                fullname = "ronaldo"
            }
        };
        public IActionResult Index()
        {
            return View(members);
        }

        public IActionResult NTMGetDetails()
        {
            var member = new NTMMember()
            {
                ID = Guid.NewGuid().ToString(),
                username = "tm",
                password = "password",
                fullname = "Nguyễn Tuấn Minh",
                email = "tmiikka.8406@gmail.com"
            };

            return View(member);
        }

        // 3. Form Thêm mới (Create - GET)
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        // Xử lý Thêm mới (Create - POST)
        [HttpPost]
        public IActionResult Create(NTMMember member)
        {
            member.ID = Guid.NewGuid().ToString();

            // Sinh mã GUID ngẫu nhiên
            members.Add(member);

            // Chuyển hướng về trang danh sách
            return RedirectToAction("Index");
        }


        // 4. Form Chỉnh sửa (Edit - GET)
        [HttpGet]
        public IActionResult Edit(string id)
        {
            var member = members.FirstOrDefault(
                x => x.ID.Equals(id)
            );

            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }


        // Xử lý Cập nhật (Edit - POST)
        [HttpPost]
        public IActionResult Edit(NTMMember member)
        {
            var item = members.FirstOrDefault(
                x => x.ID.Equals(member.ID)
            );

            if (item != null)
            {
                item.username = member.username;
                item.fullname = member.fullname;
                item.email = member.email;
            }

            return RedirectToAction("Index");
        }
    }
}





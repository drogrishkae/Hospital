using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using WebApp.DAL;
using WebApp.Models;

namespace WebApp.Areas.Member.Controllers
{
    [Authorize(Roles = "Member")]
    [Area("Member")]
    public class MemberController : Controller
    {
        UserManager<WebApp.Models.Member> _userManager;
        private readonly HospitalDB _db;
        public MemberController(UserManager<WebApp.Models.Member> userManager, HospitalDB db)
        {
            _userManager = userManager;
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

      

        



        private int GetUserID()
        {
            return int.Parse(_userManager.GetUserId(User));
        }

    }
}
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Security.Claims;
using Bookshopemployee.Models;

namespace Bookshopemployee.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User model)
        {
            
            string connString = "server=localhost; database=EmployeeManagement; TrustServerCertificate=true;";
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Open();
                string stmt = $"select count(*) total from users where username='{model.username}' and password='{model.password}'";
                SqlCommand cmd = new SqlCommand(stmt, con);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count > 0)
                {
                   
                    HttpContext.Session.SetString("username", model.username);

                 
                    var claims = new List<Claim>(){
                    new Claim(ClaimTypes.NameIdentifier,model.username),
                    new Claim(ClaimTypes.Role,"Admin")

                    }.ToArray();

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var princible = new ClaimsPrincipal(identity);
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, princible);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewData["error"] = "Invalid Credentials";
                    //user is invalid
                    return View(model);
                }

            }


        }

        public IActionResult logout()
        {
            HttpContext.Session.Remove("username");
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("login");
        }
    }
}

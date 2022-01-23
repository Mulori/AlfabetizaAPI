using AlfabetizaAPI.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace AlfabetizaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TypeAccountController : Controller
    {
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get()
        {
            var listTypeAccount = new List<TypeAccount>();
            listTypeAccount.Add(new TypeAccount { id = 1, name = "Student" });
            listTypeAccount.Add(new TypeAccount { id = 2, name = "Teacher" });

            return Ok(listTypeAccount);
        }
    }
}

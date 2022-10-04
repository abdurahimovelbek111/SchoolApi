using Microsoft.AspNetCore.Mvc;
using SchoolApi.Domain.ModelView;

namespace SchoolApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        /// <summary>
        /// Claims dan userni olish kerak edi.
        /// bizda indentity middelware bo'lmaganligi uchun userni mavjud bo'lmaganligi uchun
        /// Static User yoizldi. Singilton patterni asosida;
        /// </summary>
        protected UserProfile CurrentUser = UserProfile.User;
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P01_2022VF650_2022MV652.Models;
using Microsoft.EntityFrameworkCore;


namespace P01_2022VF650_2022MV652.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class parqueosDBController : ControllerBase
    {
        private readonly parqueosDBContext _parqueosDBContexto;
        public parqueosDBController(parqueosDBContext parqueosDBContexto)
        {
            _parqueosDBContexto = parqueosDBContexto;
        }


    }
}

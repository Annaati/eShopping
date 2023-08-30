﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Basket.API.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:ApiVersion}/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
    }
}

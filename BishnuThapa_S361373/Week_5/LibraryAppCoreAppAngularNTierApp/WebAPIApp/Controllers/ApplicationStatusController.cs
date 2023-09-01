using LOGIC.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_API.Models.ApplicationStatus;

namespace WEB_API.Controllers
{
    [EnableCors("angular")]
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationStatusController : ControllerBase
    {
        private IApplicationStatus_Service _applicationStatus_Service;

        public ApplicationStatusController(IApplicationStatus_Service applicationStatus_Service)
        {
            _applicationStatus_Service = applicationStatus_Service;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> AddAppStatus(string name)
        {
            var result = await _applicationStatus_Service.AddApplicationStatus(name);
            switch (result.success)
            {
                case true:
                    return Ok(result);

                case false:
                    return StatusCode(500, result);
            }
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllAppStatuses()
        {
            var result = await _applicationStatus_Service.GetAllApplicationStatuses();
            switch (result.success)
            {
                case true:
                    return Ok(result);

                case false:
                    return StatusCode(500, result);
            }
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> UpdateAppStatus(ApplicationStatusUpdate_Pass_Object status)
        {
            var result = await _applicationStatus_Service.UpdateApplicationStatus(status.id, status.name);
            switch (result.success)
            {
                case true:
                    return Ok(result);

                case false:
                    return StatusCode(500, result);
            }
        }
    }
}

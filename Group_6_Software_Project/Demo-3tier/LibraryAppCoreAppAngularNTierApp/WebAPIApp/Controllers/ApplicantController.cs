using LOGIC.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_API.Models.Applicant;

namespace WEB_API.Controllers
{
    [EnableCors("angular")]
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantController : ControllerBase
    {
        private IApplicant_Service _applicant_Service;

        public ApplicantController (IApplicant_Service applicant_Service)
        {
            _applicant_Service = applicant_Service;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddApplicant(Applicant_Pass_Object applicant)
        {
            var result = await _applicant_Service.AddSingleApplicant(applicant.name, applicant.surname, applicant.birthday, applicant.email, applicant.phone_number);
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
        public async Task<IActionResult> GetApplicantById(int id)
        {
            var result = await _applicant_Service.GetApplicantById(id);
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
        public async Task<IActionResult> UpdateApplicant(ApplicantUpdate_Pass_Object applicant)
        {
            var result = await _applicant_Service.UpdateApplicant(applicant.id, applicant.name, applicant.surname, 
                applicant.birthday, applicant.email, applicant.phone_number);
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

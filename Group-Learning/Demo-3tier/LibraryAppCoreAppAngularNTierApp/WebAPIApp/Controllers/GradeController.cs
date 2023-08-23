using LOGIC.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_API.Models.Grade;

namespace WEB_API.Controllers
{
    [EnableCors("angular")]
    [Route("api/[controller]")]
    [ApiController]
    public class GradeController : ControllerBase
    {
        private IGrade_Service _gradeService;

        public GradeController(IGrade_Service grade_Service)
        {
            _gradeService = grade_Service;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddGrade(Grade_Pass_Object grade_object)
        {
            var result = await _gradeService.AddSingleGrade(grade_object.name, grade_object.grade_number, grade_object.capacity);
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
        public async Task<IActionResult> GetAllGrades()
        {
            var result = await _gradeService.GetAllGrades();
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
        public async Task<IActionResult> UpdateGrade(GradeUpdate_Pass_Object grade_object)
        {
            var result = await _gradeService.UpdateGrade(grade_object.id, grade_object.name, grade_object.grade_number, grade_object.capacity);
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

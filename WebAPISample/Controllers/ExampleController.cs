using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPISample.DTOs.Example;
using WebAPISample.DTOs.Sample;
using WebAPISample.Interface.Example.Service;
using WebAPISample.Respon.Sample.Service;

namespace WebAPISample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExampleController : ControllerBase
    {
        private readonly IExampleService exampleService;

        public ExampleController(IExampleService exampleService)
        {
            this.exampleService = exampleService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllExampleAsync()
        {
            try
            {
                var Example = await exampleService.GetAllExampleAsync();
                if (Example == null || !Example.Any())
                {
                    return Ok(new { message = "No example Items found" });
                }
                return Ok(new { message = "Successfully retrieved all example ", data = Example });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while retrieving all Example it", error = ex.Message });
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetExampleIdAsync(int id)
        {
            try
            {
                var Example = await exampleService.GetExampleIdAsync(id);
                if (Example == null)
                {
                    return NotFound(new { message = $"Example Item  with id {id} not found" });
                }
                return Ok(new { message = "Successfully retrieved all Example ", data = Example });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while retrieving all Example it", error = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateExampleAsync(CreateExampleRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                await exampleService.CreateExampleAsync(request);
                return Ok(new { message = "Example successfully created" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while creating the crating Sample Item", error = ex.Message });
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateExampleAsync(int id, UpdateExampleRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var Example = await exampleService.GetExampleIdAsync(id);
                if (Example == null)
                {
                    return NotFound(new { message = $"Example Item  with id {id} not found" });
                }
                await exampleService.UpdateExampleAsync(id, request);
                return Ok(new { message = $" Example Item  with id {id} successfully updated" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"An error occurred while updating Example with id {id}", error = ex.Message });
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteExampleAsync(int id)
        {
            try
            {
                var Example = await exampleService.GetExampleIdAsync(id);
                if (Example == null)
                {
                    return NotFound(new { message = $"Example Item  with id {id} not found" });
                }
                await exampleService.DeleteExampleAsync(id);
                return Ok(new { message = $"Example  with id {id} successfully deleted" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"An error occurred while deleting Example Item  with id {id}", error = ex.Message });
            }
        }
    }
}

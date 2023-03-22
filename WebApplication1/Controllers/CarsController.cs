using ConsoleAppConnectDb.Models;
using ConsoleAppConnectDb.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Reflection;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : ControllerBase
    {
        private readonly ICarRepository _carRepository;

        public CarsController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }
        
        [HttpGet(Name = "GetCars")]
        public ActionResult<IEnumerable<Car>> GetAllCars()
        {
            try
            {
                return _carRepository.GetCars();
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            
        }
    }
}

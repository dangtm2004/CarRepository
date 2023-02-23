using ConsoleAppConnectDb.Models;
using ConsoleAppConnectDb.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Reflection;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarsController : ControllerBase
    {
        private readonly CarRepository _carRepository;

        public CarsController(CarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        [HttpGet(Name = "GetCars")]
        public ActionResult<IEnumerable<Car>> GetAllCars()
        {
            return _carRepository.GetCars();
        }
    }
}

using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using flightManagement.BLL;
using flightManagement.Data;

namespace flightAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private flightService _flightService;

        public FlightController(flightService flightService)
        {
            _flightService = flightService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Flight> flights = _flightService.GetAllFlights();
            return Ok(flights);
        }

        [HttpGet("search")]
        public IActionResult Search(string destination)
        {
            List<Flight> flights = _flightService.SearchFlights(destination);

            if (flights.Count == 0)
            {
                return NotFound("No flights found for that destination.");
            }

            return Ok(flights);
        }

        [HttpPost]
        public IActionResult AddFlight([FromBody] Flight flight)
        {
            _flightService.AddFlight(flight.flightdestination, flight.time, flight.price);
            return Ok("Flight added successfully.");
        }

        [HttpPut]
        public IActionResult UpdateFlight([FromBody] Flight flight)
        {
            _flightService.UpdateFlight(flight.flightdestination, flight.time, flight.price);
            return Ok("Flight updated successfully.");
        }

        [HttpDelete("{destination}")]
        public IActionResult DeleteFlight(string destination)
        {
            _flightService.DeleteFlight(destination);
            return Ok("Flight deleted successfully.");
        }
    }
}
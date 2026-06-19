using System;
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
            try
            {
                List<Flight> flights = _flightService.SearchFlights(destination);

                if (flights.Count == 0)
                {
                    return NotFound("No flights found for that destination.");
                }

                return Ok(flights);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult AddFlight([FromBody] Flight flight)
        {
            try
            {
                _flightService.AddFlight(flight.flightdestination, flight.DestinationCode, flight.time, flight.price);
                return Ok("Flight added successfully.");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateFlight(int id, [FromBody] Flight flight)
        {
            try
            {
                _flightService.UpdateFlight(id, flight.flightdestination, flight.DestinationCode, flight.time, flight.price);
                return Ok("Flight updated successfully.");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFlight(int id)
        {
            try
            {
                _flightService.DeleteFlight(id);
                return Ok("Flight deleted successfully.");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
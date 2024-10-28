using Dapper;
using Carss.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Calendars.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalendarController : ControllerBase
    {
        private readonly string _connectString = DBUtil.ConnectionString(); [HttpGet]
        public async Task<IEnumerable<Calendar>> GetCalendars(){
            string sqlQuery = "SELECT * FROM VehicleRentals"; 
            using (var connection = new SqlConnection(_connectString))

            { 
                var Calendars = await connection.QueryAsync<Calendar>(sqlQuery); 
                return Calendars.ToList(); 
            }
        }

        [HttpGet("{id}")] 
        public async Task<Calendar> GetCalendar(Guid id) 
        { 
            string sqlQuery = "SELECT * FROM VehicleRentals WHERE RentalId = @Id"; 
            using (var connection = new SqlConnection(_connectString)) 
            { 
                var Calendar = await connection.QueryFirstOrDefaultAsync<Calendar>(sqlQuery, new { Id = id }); 
                if (Calendar == null) 
                { 
                    return new Calendar(); 
                } 
                return Calendar; 
            } 
        }

        [HttpPost] 
        public async Task<IActionResult> AddCalendar(Calendar Calendar) 
        { 
            string sqlQuery = "INSERT  INTO  VehicleRentals  (VehicleName,  CustomerName,  RentalDate, ReturnDate, IsReturned)  VALUES (@VehicleName,  @CustomerName,  @RentalDate, @ReturnDate, @IsReturned)"; 
            using (var connection = new SqlConnection(_connectString)) 
            { 
                await connection.ExecuteAsync(sqlQuery, Calendar); 
                return Ok(); 
            } 
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCalendar(Calendar Calendar)
        {
            string sqlQuery = "UPDATE VehicleRentals SET VehicleName = @VehicleName, CustomerName = @CustomerName, RentalDate = @RentalDate, ReturnDate=@ReturnDate, IsReturned = @IsReturned, CreatedDate = @CreatedDate WHERE RentalId = @RentalId";
            using (var connection = new SqlConnection(_connectString))
            {
                await connection.ExecuteAsync(sqlQuery, Calendar);
                return Ok();

            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCalendar(Guid id)
        {
            string sqlQuery = "DELETE FROM VehicleRentals WHERE RentalId = @Id";
            using (var connection = new SqlConnection(_connectString))
            {
                await connection.ExecuteAsync(sqlQuery, new { Id = id });
                return Ok();
            }
        }


    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Agence_de_Voyages.Controllers
{
	public class User_validation : Controller
	{
		public IActionResult Index()
		{
			return RedirectToAction(nameof(Index));
		}

		[HttpPost]
		public JsonResult ValidateUser(string Email, string password)
		{
			// Your SQL Server connection string
			string connectionString = "Server=DESKTOP-9BF9GB8;Database=Agence_de_voyages;Integrated Security=true;Trust Server Certificate=yes; ";

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.Open();

				// Query to validate user
				string query = "SELECT COUNT(*) FROM Users WHERE Email = @Email AND Password = @Password";

				using (SqlCommand command = new SqlCommand(query, connection))
				{
					command.Parameters.AddWithValue("@Email", Email);
					command.Parameters.AddWithValue("@Password", password);

					int count = (int)command.ExecuteScalar();

					// If a matching user is found in the database, return true; otherwise, return false
					return Json(count > 0);
				}
			}
		}
	}
}

using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System;

namespace Agence_de_Voyages.Models
{
	public class UsersModel
	{
		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Name field is Required")]
		[MinLength(3, ErrorMessage = "Name contains at least 3 letters")]
		[MaxLength(20, ErrorMessage="Name is too long")]
		[RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Name should not contain special characters")]
		public String? Name { get; set; }

		[Required(ErrorMessage = "Age field is Required")]
		[Range(18, 80, ErrorMessage = "Age must be between 18 and 80")]

		public int Age { get; set; }
		[Required(ErrorMessage = "Gender field is Required")]
		public String Gender { get; set; }

		[Required(ErrorMessage = "Email field is Required")]
		[EmailAddress(ErrorMessage = "Invalid Email Address")]
		public String Email { get; set; }

		[Required(ErrorMessage = "Phone field is Required")]
		public String Phone { get; set; }

		[Required(ErrorMessage = "Type field is Required")]
		public String Type { get; set; }

		[Required(ErrorMessage = "Password field is Required")]
		[MinLength(8, ErrorMessage = "Password must be at least 8 characters long")]
		public String Password { get; set; }
	}

}	

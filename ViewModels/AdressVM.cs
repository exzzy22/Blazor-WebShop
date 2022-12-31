﻿using System.ComponentModel.DataAnnotations;
using ViewModels.ValidationAttributes;

namespace ViewModels;

public class AdressVM
{
	[Required]
	public string FirstName { get; set; } = null!;
	[Required]
	public string LastName { get; set; } = null!;
	[Required]
	[EmailAddress]
	public string Email { get; set; } = null!;
	[Required]
	public string Address { get; set; } = null!;
	[Required]
	public string City { get; set; } = null!;
	[Required]
	public string Country { get; set; } = null!;
	[Required]
	public string ZipCode { get; set; } = null!;
	[Phone]
	[Required]
	public string Tel { get; set; } = null!;
}

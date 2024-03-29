﻿namespace Domain.Models;

public class Order
{
	public int Id { get; set; }
	public int CartId { get; set; }
	public int? UserId { get; set; }
	public string StripeId { get; set; } = null!;
	public string Email { get; set; } = null!;
	public string CurrencyISO4217 { get; set; } = null!;
	public double Amount { get; set; }
	public string? Note { get; set; }
	public string? Invoice { get; set; }
	public Guid SessionId { get; set; }
	public OrderStatus Status { get; set; } = OrderStatus.Created;
	public DateTime CratedDate { get; set; }


	public virtual Address BillingAddress { get; set; } = null!;
	public virtual Address ShippingAddress { get; set; } = null!;
	public virtual ICollection<ProductOrder> Prodcuts { get; set; } = null!;

}

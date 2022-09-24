﻿namespace Domain.Exceptions.ModelSpecific;

public class ProductNotFound : NotFoundException
{
    public ProductNotFound(int id) : base($"Product with {id} not found")
    {
    }
}

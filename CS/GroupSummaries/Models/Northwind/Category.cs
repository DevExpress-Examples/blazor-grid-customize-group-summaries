﻿namespace GroupSummaries.Models.Northwind;

public partial class Category {
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
    public string Description { get; set; }
    public byte[] Picture { get; set; }
}
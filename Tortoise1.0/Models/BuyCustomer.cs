using System;
using System.Collections.Generic;

namespace Tortoise1._0.Models;

public partial class BuyCustomer
{
    public int Id { get; set; }

    public string CName { get; set; } = null!;

    public string? CAddress { get; set; }

    public int? CPhone { get; set; }

    public string? CGstNo { get; set; }
}

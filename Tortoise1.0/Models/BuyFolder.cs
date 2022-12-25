using System;
using System.Collections.Generic;

namespace Tortoise1._0.Models;

public partial class BuyFolder
{
    public int Id { get; set; }

    public int CId { get; set; }

    public DateTime Date { get; set; }

    public string BillNo { get; set; } = null!;

    public double Amount { get; set; }

    public string? CheckNo { get; set; }
}

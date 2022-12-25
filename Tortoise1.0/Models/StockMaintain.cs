using System;
using System.Collections.Generic;

namespace Tortoise1._0.Models;

public partial class StockMaintain
{
    public int Id { get; set; }

    public int? TypeId { get; set; }

    public string? Name { get; set; }

    public int? Count { get; set; }
}

using System;
using System.Collections.Generic;

namespace EFDbFirst.UI.Model;

public partial class LowInStock
{
    public string ProductName { get; set; } = null!;

    public short? UnitsInStock { get; set; }
}

using System;
using System.Collections.Generic;

namespace EmpMgmtMVCAppCS.Models;

public partial class Employee
{
    public decimal EmpId { get; set; }

    public string Name { get; set; } = null!;

    public decimal Age { get; set; }
}

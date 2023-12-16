using System;
using System.Collections.Generic;

namespace FullWebApp.Models;

public partial class Department
{
    public int Id { get; set; }

    public string? DeptName { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}

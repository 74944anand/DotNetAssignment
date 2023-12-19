using System;
using System.Collections.Generic;

namespace EmployeeApi.Models;

public partial class Table
{
    public int EmployeeId { get; set; }

    public string? EmployeeName { get; set; }

    public string? EmployeeCity { get; set; }

    public DateTime? EmployeeDob { get; set; }

    public string? EmployeeGender { get; set; }

    public decimal? EmployeeSalary { get; set; }
}

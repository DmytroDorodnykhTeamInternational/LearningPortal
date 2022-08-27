// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortalPerfomanceEmployees.Models;

public class Team
{
    [Key]
    public int TeamId { get; set; }
    public DateTime DateCreated { get; set; }
    public string TeamName { get; set; }
    [ForeignKey("Id")]
    public Employee TeamLeader { get; set; }
    [ForeignKey("Id")]
    public List<Employee> Employees { get; set; }

}

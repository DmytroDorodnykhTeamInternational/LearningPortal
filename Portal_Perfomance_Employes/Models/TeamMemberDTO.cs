// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

namespace PortalPerfomanceEmployees.Models;

public class TeamMemberDTO
{
    public int EmployeeId { get; set; }
    public int TeamId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public bool IsActive { get; set; }
    public DateTime? FromDate { get; set; }
}

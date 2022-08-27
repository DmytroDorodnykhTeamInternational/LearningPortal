// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using System.ComponentModel.DataAnnotations;

namespace PortalPerfomanceEmployees.Models;

public class TeamDTO
{
    [Required(ErrorMessage = "Please enter a team name")]
    public string TeamName { get; set; }
}

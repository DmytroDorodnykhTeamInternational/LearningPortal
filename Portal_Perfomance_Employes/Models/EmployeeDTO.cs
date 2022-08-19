// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.
using System.ComponentModel.DataAnnotations;

namespace PortalPerfomanceEmployees.Models
{
    public class EmployeeDTO
    {
        [Required(ErrorMessage = "Please enter a first name")]
        public string FirstName { get; set; } = "";
        [Required(ErrorMessage = "Please enter a last name")]
        public string LastName { get; set; } = "";
        [Required(ErrorMessage = "Please enter a date of birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateOfBirth { get; set; }
        [Required(ErrorMessage = "Please choose a seniority level")]
        [Range(0, 2, ErrorMessage = "Please choose a correct seniority level")]
        public Seniority? Level { get; set; }
        [Required(ErrorMessage = "Please choose a role tier")]
        [Range(0, 2, ErrorMessage = "Please choose a correct role tier")]
        public Role? Tier { get; set; }
        // These fields are nullable because otherwise the [Required] attribute will not work
    }
}
// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using System.ComponentModel.DataAnnotations;

namespace PortalPerfomanceEmployees.Models
{
    public class SkillLevelType
    {
        [Key]
        public int SkillLevelTypeId { get; set; }
        public string SkillLevelTypeName { get; set; }
        public ICollection<Skill> Skills { get; set; } = new List<Skill>();
        public ICollection<SkillLevel> SkillLevels { get; set; } = new List<SkillLevel>();
    }
}

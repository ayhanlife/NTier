using System.ComponentModel.DataAnnotations;
using TodoAppNTier.Dtos.Interfaces;

namespace TodoAppNTier.Dtos.WorkDtos
{
    public class WorkCreateDto : IDto
    {

        [Required]
        public string Definition { get; set; }
        public bool IsCompleted { get; set; }
    }
}

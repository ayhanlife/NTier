﻿using TodoAppNTier.Dtos.Interfaces;

namespace TodoAppNTier.Dtos.WorkDtos
{
    public class WorkListDto: IDto
    {
        public int Id { get; set; }
        public string Definition { get; set; }
        public bool IsCompleted { get; set; }
    }
}

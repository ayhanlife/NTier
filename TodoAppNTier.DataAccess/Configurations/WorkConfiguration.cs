﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoAppNTier.Entities.Concrete;

namespace TodoAppNTier.DataAccess.Configurations
{
    public class WorkConfiguration : IEntityTypeConfiguration<Work>
    {
        public void Configure(EntityTypeBuilder<Work> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Definition).HasMaxLength(200);
            builder.Property(x => x.Definition).IsRequired(true);

            builder.Property(x => x.IsCompleted).IsRequired(true);
            
        }

    }
}

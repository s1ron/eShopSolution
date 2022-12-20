﻿using eShopData.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopData.Configurations
{
    public class CategoryTranslationConfiguration : IEntityTypeConfiguration<CategoryTranslation>
    {
        public void Configure(EntityTypeBuilder<CategoryTranslation> builder)
        {
            builder.ToTable("CategoryTranslations");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
            builder.Property(x => x.SeoAlias).IsRequired().HasMaxLength(200);
            builder.Property(x => x.SeoDescription).HasMaxLength(500);
            builder.Property(x => x.SeoTitle).HasMaxLength(200);
            builder.Property(x => x.LanguageID).IsUnicode(false).IsRequired().HasMaxLength(5);
            builder.HasOne(x => x.Language).WithMany(x => x.CategoryTranslations).HasForeignKey(x => x.LanguageID);
            builder.HasOne(x => x.Category).WithMany(x => x.CategoryTranslations).HasForeignKey(x => x.CategoryID);
        }
    }
}
using System;
using System.Linq.Expressions;
using MeSoftware.Core;
using MeSoftware.EntityComponentModel;
using MeSoftware.EntityComponentModel.ConfigurationServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeSoftware.OrderManagement.ModelConfiguration
{
    public abstract class ConfiguratorBase<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : class, IPropertyContract
    {
        private readonly IConfigurationServiceManager<TEntity> configurationServiceManager;
        private readonly string tableName;
        private readonly ModelBuilder modelBuilder;
        private string propertyNo;
        private int initialValue;
        private bool hasIndex;

        public ConfiguratorBase(ModelBuilder modelBuilder, string tableName)
        {
            configurationServiceManager = new ConfigurationServiceManager<TEntity>();
            this.tableName = tableName;
            this.modelBuilder = modelBuilder;
        }

        public ConfiguratorBase<TEntity> SetSequencedPropertyNo<TProperty>(Expression<Func<TEntity, TProperty>> property, int initialValue = int.MinValue, bool createIndex = true)
        {
            propertyNo = (property.Body as MemberExpression).Member.Name;
            hasIndex = createIndex;
            this.initialValue = initialValue;
            return this;
        }

        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            if (tableName.HasValue())
            {
                builder.ToTable(tableName);
            }
            SequenceBuilder sequence = null;
            string sequenceName = null;
            if (propertyNo.HasValue())
            {
                sequenceName = $"{propertyNo}Sequence";
                sequence = modelBuilder.HasSequence<int>(sequenceName);
                if (initialValue.IsNot(int.MinValue))
                    sequence.StartsAt(initialValue);
            }
            if (sequence.IsNotNull())
            {
                builder.Property(propertyNo)
                    .HasDefaultValueSql($"NEXT VALUE FOR {propertyNo}Sequence");
                if (hasIndex)
                    builder.HasIndex(propertyNo)
                        .IsUnique(true);
            }
            configurationServiceManager.Configure(builder);
        }
    }
}

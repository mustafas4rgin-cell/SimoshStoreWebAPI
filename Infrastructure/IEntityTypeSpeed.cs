using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SimoshStore;

public interface IEntityTypeSeed<T> where T : class
    {
        void SeedData(EntityTypeBuilder<T> builder);
    }

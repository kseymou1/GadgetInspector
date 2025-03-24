using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GadgetInspector.Data.Converters;

//https://stackoverflow.com/questions/4648540/entity-framework-datetime-and-utc/73154546#73154546
class UtcValueConverter : ValueConverter<DateTime, DateTime>
{
    public UtcValueConverter()
        : base(v => v, v => DateTime.SpecifyKind(v, DateTimeKind.Utc))
    {
    }
}

using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace Elastic.Core.Tests.Model
{
    /// <summary>
    /// </summary>
    public class SimpleEntityMap : ClassMapping<SimpleEntity>
    {
        public SimpleEntityMap()
        {
            Id(p => p.Id, map => map.Generator(Generators.Assigned));
            Property(p => p.FirstName);
            Property(p => p.LastName);
        }
    }
}
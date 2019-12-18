using FluentNHibernate.Mapping;

namespace RithV.FX.Entity
{
    public abstract class VersionedClassMap<T> : ClassMap<T> where T : IVersionedObjectModel
    {
        protected VersionedClassMap()
        {
            Version(z => z.Version)
                .Column("fldLastUpdated")
                .CustomSqlType("Rowversion")
                .Generated.Always()
                .UnsavedValue("null");
        }
    }


}
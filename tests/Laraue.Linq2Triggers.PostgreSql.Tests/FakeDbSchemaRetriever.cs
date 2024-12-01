using System.Reflection;
using Laraue.Linq2Triggers.SqlGeneration;

namespace Laraue.Linq2Triggers.PostgreSql.Tests;

public class FakeDbSchemaRetriever : IDbSchemaRetriever
{
    public string GetColumnName(Type type, MemberInfo memberInfo)
    {
        return memberInfo.Name;
    }

    public string GetTableName(Type entity)
    {
        return entity.Name;
    }

    public string? GetTableSchemaName(Type entity)
    {
        return null;
    }

    public PropertyInfo[] GetPrimaryKeyMembers(Type type)
    {
        throw new NotImplementedException();
    }

    public KeyInfo[] GetForeignKeyMembers(Type type, Type type2)
    {
        throw new NotImplementedException();
    }

    public Type GetActualClrType(Type type, MemberInfo memberInfo)
    {
        return type;
    }
}
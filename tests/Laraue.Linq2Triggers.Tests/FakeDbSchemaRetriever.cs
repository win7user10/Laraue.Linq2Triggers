using System.Reflection;
using Laraue.Linq2Triggers.SqlGeneration;

namespace Laraue.Linq2Triggers.Tests;

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
        return type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
            .Where(p => p.Name == "Id")
            .ToArray();
    }

    public KeyInfo[] GetForeignKeyMembers(Type type, Type type2)
    {
        var principalProperty = type2
            .GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
            .FirstOrDefault(p => p.Name == "Id");
        
        var foreignKeyProperty = type
            .GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
            .FirstOrDefault(p => p.Name == $"{type2.Name}Id");

        return principalProperty == null || foreignKeyProperty == null
            ? Array.Empty<KeyInfo>()
            : new[] { new KeyInfo(principalProperty, foreignKeyProperty) };
    }

    public Type GetActualClrType(Type type, MemberInfo memberInfo)
    {
        return type;
    }
}
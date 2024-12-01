using System.Reflection;

namespace Laraue.Linq2Triggers.SqlGeneration
{
    public sealed record KeyInfo(MemberInfo PrincipalKey, MemberInfo ForeignKey);
}
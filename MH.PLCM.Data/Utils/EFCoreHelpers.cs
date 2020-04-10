using MH.PLCM.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;

namespace MH.PLCM.Utils
{
    public static class EFCoreHelpers
    {
        public static List<T> RawSqlQuery<T>(this DbContext ctx, string query, Func<DbDataReader, T> map)
        {

            using (var command = ctx.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = query;
                command.CommandType = CommandType.Text;

                ctx.Database.OpenConnection();

                using (var result = command.ExecuteReader())
                {
                    var entities = new List<T>();

                    while (result.Read())
                    {
                        entities.Add(map(result));
                    }

                    return entities;
                }
            }
        }


        public static IQueryable Query(this NorthwindContext context, string entityName) => context.Query(context.Model.FindEntityType(entityName).ClrType);

        static readonly MethodInfo SetMethod = typeof(NorthwindContext).GetMethod(nameof(DbContext.Set));

        public static IQueryable Query(this NorthwindContext context, Type entityType) => (IQueryable)SetMethod.MakeGenericMethod(entityType).Invoke(context, null);

    }
}

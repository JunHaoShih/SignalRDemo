using Dapper;
using DataAccessLib.Models.DataTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DataAccessLib.DAOs.TypeHandlers
{
    /// <summary>
    /// 給Dapper知道如何轉換Topic的TypeHandler
    /// </summary>
    public class TopicTypeHandler : SqlMapper.TypeHandler<Topic>
    {
        public override Topic Parse(object value)
        {
            return new Topic((string)value);
        }

        public override void SetValue(IDbDataParameter parameter, Topic value)
        {
            parameter.Value = value.ToString();
        }
    }
}

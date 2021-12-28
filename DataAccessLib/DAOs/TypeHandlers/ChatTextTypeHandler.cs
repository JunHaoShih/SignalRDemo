using Dapper;
using DataAccessLib.Models.DataTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DataAccessLib.DAOs.TypeHandlers
{
    /// <summary>
    /// 給Dapper知道如何轉換ChatText的TypeHandler
    /// </summary>
    public class ChatTextTypeHandler : SqlMapper.TypeHandler<ChatText>
    {
        public override ChatText Parse(object value)
        {
            return new ChatText((string)value);
        }

        public override void SetValue(IDbDataParameter parameter, ChatText value)
        {
            parameter.Value = value.ToString();
        }
    }
}

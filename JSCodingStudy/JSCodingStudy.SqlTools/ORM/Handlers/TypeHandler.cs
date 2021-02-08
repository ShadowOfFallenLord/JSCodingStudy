using JSCodingStudy.SqlTools.ORM.Interfaces;
using JSCodingStudy.SqlTools.ORM.Rules;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSCodingStudy.SqlTools.ORM.Handlers
{
    public class TypeHandler : IORMHandler
    {
        public TypeRule Rule { get; private set; }

        public TypeHandler(TypeRule rule)
        {
            Rule = rule;
        }

        private object CreateTypeInstance()
        {
            return Activator.CreateInstance(Rule.Type);
        }

        public object Handle(SqlDataReader reader)
        {
            object t = CreateTypeInstance();

            foreach(var p in Rule.Properties)
            {
                p.Handle(reader, t);
            }

            return t;
        }
    }
}

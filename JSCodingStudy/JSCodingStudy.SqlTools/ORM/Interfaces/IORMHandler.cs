﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSCodingStudy.SqlTools.ORM.Interfaces
{
    public interface IORMHandler
    {
        object Handle(SqlDataReader reader);
    }
}

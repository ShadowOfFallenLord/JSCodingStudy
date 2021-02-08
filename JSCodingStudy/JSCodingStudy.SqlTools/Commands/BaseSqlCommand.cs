﻿using JSCodingStudy.SqlTools.ORM.Interfaces;
using JSCodingStudy.SqlTools.Commands.Common;
using JSCodingStudy.SqlTools.Commands.Common.Parameter;
using JSCodingStudy.SqlTools.Commands.HandleStrategy;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSCodingStudy.SqlTools.Commands
{
    public class BaseSqlCommand
    {
        public static BaseSqlCommand CreateRequestCommand(string connection_string, string request)
        {
            RequestInfo info = RequestInfo.CreateRequest(request);
            return new BaseSqlCommand(connection_string, info);
        }

        public static BaseSqlCommand CreateProcedureCommand(string connection_string, string procedure)
        {
            RequestInfo info = RequestInfo.CreateProcedure(procedure);
            return new BaseSqlCommand(connection_string, info);
        }

        public string ConnectionString { get; set; }
        public RequestInfo Request { get; set; }
        public ParametersList Parameters { get; set; }

        public BaseSqlCommand(string connection_string, RequestInfo request)
        {
            ConnectionString = connection_string;
            Request = request;
            Parameters = new ParametersList();
        }

        private SqlConnection CreateConnection() => new SqlConnection(ConnectionString);

        private SqlCommand CreateCommand(SqlConnection connection)
        {
            SqlCommand command = connection.CreateCommand();

            command.CommandText = Request.CommandText;
            command.CommandType = Request.CommandType;

            return command;
        }

        private void AddParametersToCommand(SqlCommand command, Dictionary<string, SqlParameter> p)
        {
            foreach(string key in p.Keys)
            {
                command.Parameters.Add(p[key]);
            }
        }

        private void Execute(IHandleStrategy strategy)
        {
            using (SqlConnection connection = CreateConnection())
            {
                SqlCommand command = CreateCommand(connection);

                Dictionary<string, SqlParameter> p = Parameters.ToSqlParameters();

                AddParametersToCommand(command, p);

                connection.Open();

                strategy.Execute(command);

                Parameters.UpdateValues(p);
            }
        }

        public object ExecuteQuery(IORMHandler handler)
        {
            QueryHandleStrategy strategy = new QueryHandleStrategy
            {
                Handler = handler
            };

            Execute(strategy);

            return strategy.Result;
        }

        public int ExecuteNonQuery()
        {
            NonQueryHandleStrategy strategy = new NonQueryHandleStrategy();
            Execute(strategy);
            return strategy.Result;
        }
    }
}

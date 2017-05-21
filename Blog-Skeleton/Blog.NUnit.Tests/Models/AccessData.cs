﻿using Blog.NUnit.Tests.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.NUnit.Tests.Models
{
    public class AccessExcelData
    {
        public static string TestDataFileConnection()
        {
            var path = ConfigurationManager.AppSettings["TestDataSheetPath"];
            var filename = "UserData.xlsx";
            var con = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;
		                              Data Source = {0}; 
		                              Extended Properties=Excel 12.0;", path + filename);
            return con;
        }

        public static LoginUser GetTestData(string keyName)
        {
            using (var connection = new OleDbConnection(TestDataFileConnection()))
            {
                connection.Open();
                var query = string.Format("select * from [LoginUser$] where key = '{0}'", keyName);
                var value = connection.Query<LoginUser>(query).FirstOrDefault();
                connection.Close();
                return value;
            }
        }
    }
}
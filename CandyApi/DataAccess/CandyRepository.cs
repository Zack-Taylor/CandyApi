﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using CandyApi.Models;
using Dapper;


namespace CandyApi.DataAccess
{
    public class CandyRepository
    {
        string ConnectionString;

        public CandyRepository(IConfiguration config)
        {
            ConnectionString = config.GetConnectionString("CandyMarket");
        }

        public IEnumerable<Candy> GetAll()
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                return db.Query<Candy>("select * from candy");
            }
        }
    }
}

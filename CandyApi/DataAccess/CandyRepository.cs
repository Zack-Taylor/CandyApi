using System;
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

        public IEnumerable<Candy> GetCandyByOwner(string name)
        {
            var sql = @"
                     select 
	             u.name,
                     c.Name,
	             c.Manufacturer,
	             c.DateCollected
                     from stash s
	                join candy c
		           on c.CandyId = s.CandyId
	                join [user] u
		          on u.Uid = s.UserId
	             where u.Name = @name
                     order by u.Name
                      ";

            using (var db = new SqlConnection(ConnectionString))
            {
                var parameters = new { Name = name };
                var result = db.Query<Candy>(sql, parameters);
                return result;
            }
        }
    }
}

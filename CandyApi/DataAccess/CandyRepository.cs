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

        public IEnumerable<Candy> GetCandyByOwner(int uid)
        {
            var sql = @"
                     select 
	                    c.CandyId,
	                    c.[Name],
                        c.Manufacturer,
	                    c.FlavorId,
	                    c.DateCollected,
	                    c.Ate,
	                    c.StashId
                     from stash s
	                join candy c
		           on c.CandyId = s.CandyId
	                join [user] u
		          on u.Uid = s.UserId
	             where u.uid = @uid
                     order by u.Name
                      ";

            using (var db = new SqlConnection(ConnectionString))
            {
                var parameters = new { Uid = uid };
                var result = db.Query<Candy>(sql, parameters);
                return result;
            }
        }

        public IEnumerable<Candy> GetEatenCandy(int uid)
        {
            var sql = @"SELECT
	                    Candy.CandyId,
	                    Candy.[Name],
                        Candy.Manufacturer,
	                    Candy.FlavorId,
	                    Candy.DateCollected,
	                    Candy.Ate,
	                    Candy.StashId
                    FROM Candy
                    JOIN Stash ON Stash.StashId = Candy.StashId
                    JOIN [User] ON [User].Uid = Stash.UserId
                    WHERE Candy.Ate = 1 AND [User].Uid = @uid
                    ORDER BY Candy.DateCollected, Candy.StashId";

            using (var db = new SqlConnection(ConnectionString))
            {
                var parameters = new { Uid = uid };
                var results = db.Query<Candy>(sql, parameters);
                return results;
            }
        }
    }
}

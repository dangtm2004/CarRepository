using ConsoleAppConnectDb.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleAppConnectDb.Repositories
{
    public interface ICarRepository
    {
        List<Car> GetCars();
    }
    public class CarRepository : ICarRepository
    {
        private string _connectionString;
        public CarRepository()
        {
            // Google for SQL Server connectionString for c#
            // "yourservername" - is the computer name where the database is installed.  in your case, it's your laptop.
            //                    so, lookup to see what your computer name is
            //                    or, you can google for how to set Data Source for a local db
            //  Leave everything else as is.
            _connectionString = "Data Source=carrepositorydbserver.database.windows.net,1433;User Id=user;Password=@$TTckol2008;Initial Catalog=AutoCare;Integrated Security=True;Trusted_Connection=false;MultipleActiveResultSets=true";
        }
        public List<Car> GetCars()
        {
            var sql = $"select  Year, Make, Model, SubModel, Engine from Car ";
            try
            {
                IEnumerable<Car> data;
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    data = (connection.QueryAsync<Car>(sql).Result);
                }
                // .ToList() is a LinQ function.  LinQ is a query language that Microsoft introduced with Entity Framework (which is another database driver)
                // Don't worry about Entity Framework for now.  I'll point you to learning it later along with LinQ.
                // There's also another MS database driver called ADO.NET which came out before Entity Framework.  
                // Microsoft.Data.SqlClient is a part of ADO.NET.
                // I'll point you to material to learn this stuff in more detail later.
                return data.ToList();

                // For now, I am having you use Microsoft.Data.SqlClient and Dapper to query data

                // Note:  Entity Framework is an Object Relation Mapper technology (underneath it is ADO.NET)
                // Dapper is an open source Object Relation Mapper for .NET/.NetCore to be used along with ADO.NET
      
            }
            
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Casscading.Models
{
    public class DbContext
    {
        string cs = ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString;

        public List<Country> getCountries()
        {
            List<Country> countries= new List<Country>();

            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("GetCountries", con);
            cmd.CommandType=CommandType.StoredProcedure;
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();

            while(sdr.Read())
            {
                Country country = new Country();
                country.CountryID = Convert.ToInt32(sdr["CountryID"]);
                country.CountryName = Convert.ToString(sdr["CountryName"].ToString());  
                countries.Add(country);
            }

            return countries;   
        }

    }
}
using cadl.Models;
using Microsoft.Data.SqlClient;
using RepoDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cadl.Repository
{
    public class CountryRepository
    {

        public GenericResponse GetAllCountries()
        {
            try
            {
                using (var ctx = new SqlConnection(Properties.Settings.Default.nConString))
                {
                    return new GenericResponse 
                    { 
                        Data = ctx.QueryAll<Country>().ToList(), 
                        ResponseCode = 00, 
                        ResponseMessage = "Command Completed Successfully" 
                    };
                }
            }
            catch (Exception ex)
            {
                return new GenericResponse { ResponseMessage = ex.Message, ResponseCode = 99, DateTime = DateTime.Now };
            }
        }


        public GenericResponse GetCountryById(int id)
        {
            try
            {
                using (var ctx = new SqlConnection(Properties.Settings.Default.nConString))
                {
                    return new GenericResponse
                    {
                        Data = ctx.Query<Country>(w => w.Id == id).FirstOrDefault(),
                        ResponseCode = 00,
                        ResponseMessage = "Command Completed Successfully"
                    };
                }
            }
            catch (Exception ex)
            {
                return new GenericResponse { ResponseMessage = ex.Message, ResponseCode = 99, DateTime = DateTime.Now };
            }
        }



    }
}

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

        public List<CountryResponse> GetAllCountries()
        {
            try
            {
                using (var ctx = new SqlConnection(Properties.Settings.Default.nConString))
                {
                    var countryDetailList = ctx.QueryAll<Country>(fields: Field.Parse<Country>(t => new
                    {
                        t.Id,
                        t.Name
                    })).ToList();

                    var listItem = new List<CountryResponse>();

                    foreach (var item in countryDetailList)
                    {
                        listItem.Add(new CountryResponse
                        {
                            Id = item.Id,
                            CountryName = item.Name,
                        });
                    }
                    return listItem;
                    //return new CountryResponse
                    //{
                    //    Id = countryDetailList[0].Id,
                    //    CountryName = countryDetailList[0].Name,
                    //    DateTime = DateTime.Now,
                    //    ResponseCode = 00,
                    //    ResponseMessage = "Command Completed Successfully",
                    //};

                }
            }
            catch (Exception ex)
            {
                throw;
                //return new CountryResponse { ResponseMessage = ex.Message, ResponseCode = 99, DateTime = DateTime.Now };
            }
        }

        public List<StateResponse> GetCountryById(string id)
        {
            try
            {
                using (var ctx = new SqlConnection(Properties.Settings.Default.nConString))
                {

                    var stateDetails = ctx.Query<State>(w => w.CountryId == int.Parse(id), fields: Field.Parse<State>(q => new
                    {
                        q.Id,
                        q.Name
                    }));

                    var stateRes = new List<StateResponse>();
                    foreach (var item in stateDetails)
                    {
                        stateRes.Add(new StateResponse
                        {
                            Id = item.Id,
                            StateName = item.Name,
                        });
                    }
                    return stateRes;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<LGAResponse>GetLGAById(string id)
        {
            try
            {
                using (var ctx = new SqlConnection(Properties.Settings.Default.nConString))
                {

                    var stateDetails = ctx.Query<LGA>(w => w.StateId == int.Parse(id), fields: Field.Parse<LGA>(q => new
                    {
                        q.LGAId,
                        q.LGAName
                    }));

                    var lgaRes = new List<LGAResponse>();
                    foreach (var item in stateDetails)
                    {
                        lgaRes.Add(new LGAResponse
                        {
                            LGAId = item.LGAId,
                            LGAName = item.LGAName,
                        });
                    }
                    return lgaRes;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }



    }
}

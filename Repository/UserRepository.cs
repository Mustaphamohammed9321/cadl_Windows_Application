using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cadl.Helpers;
using cadl.Models;
using cadl.Models.DTO.RequestDTO;
using cadl.Models.DTO.ResponseDTO;
using Microsoft.Data.SqlClient;
using RepoDb;

namespace cadl.Repository
{
    public sealed class UserRepository
    {
        public UserRepository()
        {

        }


        public async Task<LoginResponse> LoginAsync(LoginRequest request)
        {
            using (var ctx = new SqlConnection(Properties.Settings.Default.ConnectionString.ToString()))
            {
                Configuration.Crypt _crypt = new Configuration.Crypt();
                if (request.Username == String.Empty || request.Password == String.Empty)
                {
                    return new LoginResponse
                    {
                        ResponseCode = 90,
                        ResponseMessage = "Username and Password is required" 
                    };
                }
                else
                {
                    try
                    {
                        var response = ctx.Query<Users>(w => w.Username == request.Username && w.PasswordHash == _crypt.Encrypt(request.Password)).FirstOrDefault();
                        if (response != null)
                        {
                            return new LoginResponse
                            {
                                ResponseCode = 00,
                                ResponseMessage = "Login Successful",
                            };
                        }
                        else
                        {
                            return new LoginResponse
                            {
                                ResponseMessage = "Invalid Login Details",
                                ResponseCode = 90
                            };
                        }
                    }
                    catch (Exception ex)
                    {
                        return new LoginResponse 
                        { 
                            ResponseMessage = $"An error occured, reason: {ex.Message}", 
                            ResponseCode = 99 
                        };
                    }
                }
            }
        }


    



    }
}

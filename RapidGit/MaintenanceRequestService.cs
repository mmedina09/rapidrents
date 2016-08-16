using Sabio.Data;
using Sabio.Web.Domain;
using Sabio.Web.Models.Requests;
using Sabio.Web.Models.Requests.MaintenanceRequest;
using Sabio.Web.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Sabio.Web.Models
{
    public class MaintenanceRequestServices : BaseService, IMaintenanceRequestServices
    {
        public int Insert(MaintenanceAddRequest model, string userId)
        {
            int Id = 0;

            DataProvider.ExecuteNonQuery(GetConnection, "dbo.MaintenanceRequest_Insert"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   paramCollection.AddWithValue("@Name", model.Name);
                   paramCollection.AddWithValue("@UserId", userId);
                   paramCollection.AddWithValue("@Unit_No", model.UnitNumber);
                   paramCollection.AddWithValue("@Subject", model.Subject);
                   paramCollection.AddWithValue("@Description", model.Description);
                   paramCollection.AddWithValue("@Urgency_ID", model.UrgencyId);

                   SqlParameter p = new SqlParameter("@Id", System.Data.SqlDbType.Int);
                   p.Direction = System.Data.ParameterDirection.Output;

                   paramCollection.Add(p);
               }, returnParameters: delegate (SqlParameterCollection param)
               {
                   int.TryParse(param["@Id"].Value.ToString(), out Id);
               }
               );

            return Id;
        }

        public int Insert2(MaintenanceAddRequest2 model, string userId)
        {
            int Id = 0;

            DataProvider.ExecuteNonQuery(GetConnection, "dbo.MaintenanceRequest_Insert_Address_ID"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   paramCollection.AddWithValue("@Name", model.Name);
                   paramCollection.AddWithValue("@UserId", userId);
                   paramCollection.AddWithValue("@Unit_No", model.UnitNumber);
                   paramCollection.AddWithValue("@Subject", model.Subject);
                   paramCollection.AddWithValue("@Description", model.Description);
                   paramCollection.AddWithValue("@Urgency_ID", model.UrgencyId);
                   paramCollection.AddWithValue("@Address_ID", model.Id);
                   paramCollection.AddWithValue("@Status", model.Status);

                   SqlParameter p = new SqlParameter("@Id", System.Data.SqlDbType.Int);
                   p.Direction = System.Data.ParameterDirection.Output;

                   paramCollection.Add(p);
               }, returnParameters: delegate (SqlParameterCollection param)
               {
                   int.TryParse(param["@Id"].Value.ToString(), out Id);
               }
               );

            return Id;
        }

        public void Update(MaintenanceUpdateRequest model)
        {
            DataProvider.ExecuteNonQuery(GetConnection, "dbo.MaintenanceRequest_Update"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   paramCollection.AddWithValue("@Name", model.Name);
                   paramCollection.AddWithValue("@Id", model.Id);
                   paramCollection.AddWithValue("@Unit_No", model.UnitNumber);
                   paramCollection.AddWithValue("@Subject", model.Subject);
                   paramCollection.AddWithValue("@Description", model.Description);
                   paramCollection.AddWithValue("@Urgency_ID", model.UrgencyId);
                   paramCollection.AddWithValue("@Status", model.Status);

               });
        }

        public List<MaintenanceRequest> GetAll()
        {
            List<MaintenanceRequest> list = null;

            DataProvider.ExecuteCmd(GetConnection, "dbo.MaintenanceRequest_Select"
               , inputParamMapper: null
               , map: delegate (IDataReader reader, short set)
               {
                   MaintenanceRequest p = MapMaintenanceRequest(reader);

                   if (list == null)
                   {
                       list = new List<MaintenanceRequest>();
                   }

                   list.Add(p);
               });

            return list;
        }

        public MaintenanceRequest GetId(int Id)
        {
            MaintenanceRequest singleMaintRequest = null;

            DataProvider.ExecuteCmd(GetConnection, "dbo.MaintenanceRequests_Select_By_Id"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   paramCollection.AddWithValue("@Id", Id);
               }
               , map: delegate (IDataReader reader, short set)
               {
                   singleMaintRequest = MapMaintenanceRequest(reader);
               });

            return singleMaintRequest;
        }

        private static MaintenanceRequest MapMaintenanceRequest(IDataReader reader)
        {
            MaintenanceRequest singleMaintRequest = new MaintenanceRequest();
            int startingIndex = 0;

            singleMaintRequest.Id = reader.GetSafeInt32(startingIndex++);
            singleMaintRequest.Name = reader.GetSafeString(startingIndex++);
            singleMaintRequest.Unit_No = reader.GetSafeString(startingIndex++);
            singleMaintRequest.Subject = reader.GetSafeString(startingIndex++);
            singleMaintRequest.Description = reader.GetSafeString(startingIndex++);
            singleMaintRequest.UrgencyId = reader.GetSafeInt32(startingIndex++);
            singleMaintRequest.UserId = reader.GetSafeString(startingIndex++);
            singleMaintRequest.DateAdded = reader.GetSafeDateTime(startingIndex++);
            singleMaintRequest.DateModified = reader.GetSafeDateTime(startingIndex++);
            singleMaintRequest.Status = reader.GetSafeInt32(startingIndex++);
            return singleMaintRequest;
        }



        public List<MaintenanceRequest> GetByAddressId(int addressId)
        {
            List<MaintenanceRequest> list = null;

            DataProvider.ExecuteCmd(GetConnection, "dbo.MaintenanceRequests_Select_By_Address_Id"
                 , inputParamMapper: delegate (SqlParameterCollection paramCollection)
                 {
                     paramCollection.AddWithValue("@Address_ID", addressId);
                 }
               , map: delegate (IDataReader reader, short set)
               {
                   MaintenanceRequest p = MapMaintenanceRequestByAddress(reader);

                   if (list == null)
                   {
                       list = new List<MaintenanceRequest>();
                   }

                   list.Add(p);
               });

            return list;
        }



        public MaintenanceRequest GetFirstByAddressId(int addressId)
        {
            MaintenanceRequest maintReqByAddressId = null;

            DataProvider.ExecuteCmd(GetConnection, "dbo.MaintenanceRequests_Select_By_Address_Id"
                , inputParamMapper: delegate (SqlParameterCollection paramCollection)
                {
                    paramCollection.AddWithValue("@Address_ID", addressId);
                }
                , map: delegate (IDataReader reader, short set)
                {
                    maintReqByAddressId = MapMaintenanceRequestByAddress(reader);
                });

            return maintReqByAddressId;
        }

        private static MaintenanceRequest MapMaintenanceRequestByAddress(IDataReader reader)
        {
            MaintenanceRequest maintReqByAddressId = new MaintenanceRequest();
            int startingIndex = 0;

            maintReqByAddressId.Id = reader.GetSafeInt32(startingIndex++);
            maintReqByAddressId.Name = reader.GetSafeString(startingIndex++);
            maintReqByAddressId.Unit_No = reader.GetSafeString(startingIndex++);
            maintReqByAddressId.Subject = reader.GetSafeString(startingIndex++);
            maintReqByAddressId.Description = reader.GetSafeString(startingIndex++);
            maintReqByAddressId.UrgencyId = reader.GetSafeInt32(startingIndex++);
            maintReqByAddressId.UserId = reader.GetSafeString(startingIndex++);
            maintReqByAddressId.DateAdded = reader.GetSafeDateTime(startingIndex++);
            maintReqByAddressId.DateModified = reader.GetSafeDateTime(startingIndex++);
            maintReqByAddressId.Status = reader.GetSafeInt32(startingIndex++);
          //  maintReqByAddressId.AddressId = reader.GetSafeInt32(startingIndex++);
            return maintReqByAddressId;
        }



        public void Delete(int Id)
        {
            DataProvider.ExecuteNonQuery(GetConnection, "dbo.MaintenanceRequests_DeleteById"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   paramCollection.AddWithValue("@Id", Id);
               });
        }

        public List<MaintenanceRequest> GetMaintenanceRqstByAddId(int AddressId)
        {
            List<MaintenanceRequest> multiMaintRequest = null;

            DataProvider.ExecuteCmd(GetConnection, "dbo.MaintenanceRequests_Select_By_Address_Id"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   paramCollection.AddWithValue("@Address_Id", AddressId);
               }
               , map: delegate (IDataReader reader, short set)
               {
                   MaintenanceRequest singleMaintRequest = MapMaintenanceRequest(reader);

                   if (multiMaintRequest == null)
                   {
                       multiMaintRequest = new List<MaintenanceRequest>();
                   }
                   multiMaintRequest.Add(singleMaintRequest);
               });

            return multiMaintRequest;
        }
    }
}
using Sabio.Web.Models.Requests.Properties;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


using Sabio.Web.Domain;
using Sabio.Data;
using Sabio.Web.Models.Requests.ImportedRents;
using System;

namespace Sabio.Web.Services
{
    public class ImportService : BaseService, I_ImportedProperties
    {
        public int ImprotedPropertiesInsert(AddImportedProperties model)
        {
            int uid = 0;

            DataProvider.ExecuteNonQuery(GetConnection, "dbo.ImportedProperties_Insert"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   paramCollection.AddWithValue("@Apn", model.Apn);
                   paramCollection.AddWithValue("@RegisteredDate", model.RegisteredDate);
                   paramCollection.AddWithValue("@PropertyType", model.PropertyType);
                   paramCollection.AddWithValue("@PropertyAddress", model.PropertyAddress);
                   paramCollection.AddWithValue("@PropertyCity", model.PropertyCity);
                   paramCollection.AddWithValue("@PropertyState", model.PropertyState);
                   paramCollection.AddWithValue("@PropertyZip", model.PropertyZip);
                   paramCollection.AddWithValue("@CouncilDistrict", model.CouncilDistrict);
                   paramCollection.AddWithValue("@Lender", model.Lender);
                   paramCollection.AddWithValue("@LenderContact", model.LenderContact);
                   paramCollection.AddWithValue("@LenderContactPhone", model.LenderContactPhone);
                   paramCollection.AddWithValue("@PropertyManagement", model.PropertyManagement);
                   paramCollection.AddWithValue("@PropertyManagementContact", model.PropertyManagementContact);
                   paramCollection.AddWithValue("@PropertyManagementAddress", model.PropertyManagementAddress);
                   paramCollection.AddWithValue("@PropertyMgmtContactPhone", model.PropertyMgmtContactPhone);


                   SqlParameter p = new SqlParameter("@Id", System.Data.SqlDbType.Int);
                   p.Direction = System.Data.ParameterDirection.Output;

                   paramCollection.Add(p);

               }, returnParameters: delegate (SqlParameterCollection param)
               {
                   int.TryParse(param["@Id"].Value.ToString(), out uid);
               }
               );


            return uid;
        }


        public List<Sabio.Web.Domain.ImportedProperties> GetAll_ImportedProperties()
        {
            List<ImportedProperties> list = null;

            DataProvider.ExecuteCmd(GetConnection, "dbo.ImportedProperties_Select"
            , inputParamMapper: null
            , map: delegate (IDataReader reader, short set)
            {

                ImportedProperties p = new ImportedProperties();
                int startingIndex = 0;

                if (list == null)
                {
                    list = new List<ImportedProperties>();
                }
                p.Id = reader.GetSafeInt32(startingIndex++);
                p.Apn = reader.GetSafeString(startingIndex++);
                p.RegisteredDate = reader.GetSafeDateTime(startingIndex++);

                p.PropertyType = reader.GetSafeString(startingIndex++);
                p.PropertyAddress = reader.GetSafeString(startingIndex++);
                p.PropertyCity = reader.GetSafeString(startingIndex++);
                p.PropertyState = reader.GetSafeString(startingIndex++);
                p.PropertyZip = reader.GetSafeInt32(startingIndex++);
                p.CouncilDistrict = reader.GetSafeInt32(startingIndex++);
                p.Lender = reader.GetSafeString(startingIndex++);
                p.LenderContact = reader.GetSafeString(startingIndex++);
                p.LenderContactPhone = reader.GetSafeString(startingIndex++);
                p.PropertyManagement = reader.GetSafeString(startingIndex++);
                p.PropertyManagementContact = reader.GetSafeString(startingIndex++);
                p.PropertyManagementAddress = reader.GetSafeString(startingIndex++);
                p.PropertyMgmtContactPhone = reader.GetSafeString(startingIndex++);

                if (list == null)
                {
                    list = new List<ImportedProperties>();
                }

                list.Add(p);

            });

            return list;

        }

        public void ImprotedPropertiesBulkInsert(AddImportedProperties[] model)
        {

            DataProvider.ExecuteNonQuery(GetConnection, "ImportedPropertiesInsert_Structured"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {

                   SqlParameter p = new SqlParameter("@ImportedPropertiesTable", System.Data.SqlDbType.Structured);

                   p.Value = new ImportedPropertiesTableType(model);

                   paramCollection.Add(p);

               }, returnParameters: delegate (SqlParameterCollection param)
               {
               });

        }


        public int ImportedRentsInsert(AddImportedRents model)
        {
            int uid = 0;

            DataProvider.ExecuteNonQuery(GetConnection, "dbo.ImportedRents_Insert"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   paramCollection.AddWithValue("@ExternalId", model.ExternalId);
                   paramCollection.AddWithValue("@StreetNumber", model.StreetNumber);
                   paramCollection.AddWithValue("@StreetName", model.StreetName);
                   paramCollection.AddWithValue("@Unit", model.Unit);
                   paramCollection.AddWithValue("@Zipcode", model.Zipcode);
                   paramCollection.AddWithValue("@MaximumAllowableRent", model.MaximumAllowableRent);
                   paramCollection.AddWithValue("@City", model.City);
                   paramCollection.AddWithValue("@State", model.State);


                   SqlParameter p = new SqlParameter("@Id", System.Data.SqlDbType.Int);
                   p.Direction = System.Data.ParameterDirection.Output;

                   paramCollection.Add(p);

               }, returnParameters: delegate (SqlParameterCollection param)
               {
                   int.TryParse(param["@Id"].Value.ToString(), out uid);
               }
               );


            return uid;
        }


        public List<ImportedRents> GetAll_ImportedRents()
        {
            List<ImportedRents> list = null;

            DataProvider.ExecuteCmd(GetConnection, "dbo.ImportedRents_Select"
            , inputParamMapper: null
            , map: delegate (IDataReader reader, short set)
            {

                ImportedRents p = new ImportedRents();
                int startingIndex = 0;

                if (list == null)
                {
                    list = new List<ImportedRents>();
                }
                p.Id = reader.GetSafeInt32(startingIndex++);
                p.ExternalId = reader.GetSafeString(startingIndex++);
                p.StreetNumber = reader.GetSafeString(startingIndex++);
                p.StreetName = reader.GetSafeString(startingIndex++);
                p.Unit = reader.GetSafeString(startingIndex++);
                p.Zipcode = reader.GetSafeInt32(startingIndex++);
                p.MaximumAllowableRent = reader.GetSafeInt32(startingIndex++);
                p.City = reader.GetSafeString(startingIndex++);
                p.State = reader.GetSafeString(startingIndex++);

                if (list == null)
                {
                    list = new List<ImportedRents>();
                }

                list.Add(p);

            });

            return list;

        }


        public void ImportedRentsBulkInsert(AddImportedRents[] model)
        {

            DataProvider.ExecuteNonQuery(GetConnection, "ImportedRentsInsert_Structured"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {

                   SqlParameter p = new SqlParameter("@ImportedRents", System.Data.SqlDbType.Structured);

                   p.Value = new ImportedRentsTableTypeV2(model);

                   paramCollection.Add(p);

               }, returnParameters: delegate (SqlParameterCollection param)
               {
               });

        }

        //update addresses

        public void UpdateAllAddresses()
        {

           // DataProvider.ExecuteNonQuery(GetConnection, "ImportedRentsAddress_ExecuteMultipleProc");
            DataProvider.ExecuteNonQuery(GetConnection, "ImportedRentsAddress_ExecuteMultipleProc"
           , inputParamMapper: null, returnParameters:null);


        }


    }

}



















































using System.Collections.Generic;
using System.Data.SqlClient;
using Sabio.Data;
using Sabio.Web.Models.Requests.Properties;
using System.Data;
using Sabio.Web.Domain;

namespace Sabio.Web.Services
{

    public class PropertiesServices : BaseService, IPropertiesServices
    {
        private readonly IUserService _userService;
        public PropertiesServices(IUserService svc)
        {
            _userService = svc;
        }

        public int Insert(PropertyAddRequest model)
        {
            int uid = 0;

            DataProvider.ExecuteNonQuery(GetConnection, "dbo.Properties_Insert"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   paramCollection.AddWithValue("@PropertyType", model.TypeId);
                   paramCollection.AddWithValue("@NumberOfUnits", model.NumberOfUnits);
                   paramCollection.AddWithValue("@YearBuilt", model.YearBuilt);
                   paramCollection.AddWithValue("@RentControl", model.HasRentControl);
                   paramCollection.AddWithValue("@AssessorParcelNumber", model.AssessorParcelNumber);
                   paramCollection.AddWithValue("@HasDetached", model.HasDetached);

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

        public void Update(PropertyUpdateRequest model)
        {


            DataProvider.ExecuteNonQuery(GetConnection, "dbo.Properties_Update"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   paramCollection.AddWithValue("@PropertyType", model.TypeId);
                   paramCollection.AddWithValue("@NumberOfUnits", model.NumberOfUnits);
                   paramCollection.AddWithValue("@YearBuilt", model.YearBuilt);
                   paramCollection.AddWithValue("@RentControl", model.HasRentControl);
                   paramCollection.AddWithValue("@AssessorParcelNumber", model.AssessorParcelNumber);
                   paramCollection.AddWithValue("@HasDetached", model.HasDetached);
                   paramCollection.AddWithValue("@ID", model.Id);

               });

        }

        public List<Property> GetAll()
        {
            List<Property> list = null;

            DataProvider.ExecuteCmd(GetConnection, "dbo.Properties_Select"
            , inputParamMapper: null
            , map: delegate (IDataReader reader, short set)
            {

                Property p = MapProperty(reader);

                if (list == null)
                {
                    list = new List<Property>();
                }

                list.Add(p);
            });

            return list;
        }

        public Property Get(int id)
        {
            Property prop = null;

            DataProvider.ExecuteCmd(GetConnection, "dbo.Properties_Select_ById"
            , inputParamMapper: delegate (SqlParameterCollection paramCollection)
            {
                paramCollection.AddWithValue("@Id", id);
            }
            , map: delegate (IDataReader reader, short set)
            {
                prop = MapProperty(reader);

            });

            return prop;
        }

        private static Property MapProperty(IDataReader reader)
        {
            Property prop = new Property();
            int startingIndex = 0; //startingOrdinal


            prop.Id = reader.GetSafeInt32(startingIndex++);
            prop.TypeId = reader.GetSafeInt32(startingIndex++);
            prop.NumberOfUnits = reader.GetSafeInt32(startingIndex++);
            prop.YearBuilt = reader.GetSafeInt32(startingIndex++);
            prop.HasRentControl = reader.GetSafeBool(startingIndex++);
            prop.AssessorParcelNumber = reader.GetSafeString(startingIndex++);
            prop.HasDetached = reader.GetSafeBool(startingIndex++);
            return prop;
        }

        public void DeleteById(int id)
        {
            DataProvider.ExecuteNonQuery(GetConnection, "dbo.Properties_Delete"
                , inputParamMapper: delegate (SqlParameterCollection paramCollection)
                {
                    paramCollection.AddWithValue("@Id", id);
                });
        }
        public List<Property> GetByOwnerId(string userId)
        {
            List<Property> list = null;

            DataProvider.ExecuteCmd(GetConnection, "dbo.Properties_SelectByOwnerId"
            , inputParamMapper: delegate (SqlParameterCollection paramCollection)
            {
                paramCollection.AddWithValue("@OwnerId", userId);
            }
            , map: delegate (IDataReader reader, short set)
            {
                Property p = new Property();
                int startingIndex = 0;

                p.Id = reader.GetSafeInt32(startingIndex++);
                p.TypeId = reader.GetSafeInt32(startingIndex++);
                p.NumberOfUnits = reader.GetSafeInt32Nullable(startingIndex++);
                p.YearBuilt = reader.GetSafeInt32Nullable(startingIndex++);
                p.HasRentControl = reader.GetSafeBoolNullable(startingIndex++);
                p.AssessorParcelNumber = reader.GetSafeString(startingIndex++);
                p.HasDetached = reader.GetSafeBoolNullable(startingIndex++);

                if (list == null)
                {
                    list = new List<Property>();
                }

                list.Add(p);
            });

            return list;
        }
        public List<Property> APN_Search(string search_item)
        {
            List<Property> list = null;

            DataProvider.ExecuteCmd(GetConnection, "dbo.APN_Search_For_Property"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   paramCollection.AddWithValue("@search_item", search_item);
               }
               , map: delegate (IDataReader reader, short set)
               {
                   Property p = new Property();
                   int startingIndex = 0;

                   p.Id = reader.GetSafeInt32(startingIndex++);
                   p.TypeId = reader.GetSafeInt32(startingIndex++);
                   p.NumberOfUnits = reader.GetSafeInt32(startingIndex++);
                   p.YearBuilt = reader.GetSafeInt32(startingIndex++);
                   p.HasRentControl = reader.GetSafeBool(startingIndex++);
                   p.AssessorParcelNumber = reader.GetSafeString(startingIndex++);
                   p.HasDetached = reader.GetSafeBool(startingIndex++);

                   if (list == null)
                   {
                       list = new List<Property>();
                   }

                   list.Add(p);
               });
            return list;
        }


        public void PropertyRequestInsert(PropertyVerificationRequest model, string userId)
        {

            DataProvider.ExecuteNonQuery(GetConnection, "dbo.PropertyOwnerRequestTable_Insert"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   paramCollection.AddWithValue("@PropertyId", model.PropertyId);
                   paramCollection.AddWithValue("@AspNetUserId", userId);

               });
        }
    }

}
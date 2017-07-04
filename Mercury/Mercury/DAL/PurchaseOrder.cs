using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Mercury.DAL
{
    /// <summary>
    /// 数据访问类:PurchaseOrder
    /// </summary>
    public partial class PurchaseOrder
    {
        public PurchaseOrder()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("Id", "PurchaseOrder");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from PurchaseOrder");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
            parameters[0].Value = Id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.PurchaseOrder model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into PurchaseOrder(");
            strSql.Append("OrderNo,Title,PublishTime,ExpireTime,RecvDistrictId,RecvCityId,RecvProvinceId,Address,ExpectVendorDistrictId,ExpectVendorCityId,ExpectVendorProvinceId,Quantity,ProductScale,ProductCategoryId,ProductTypeId,NeedInvoice,NeedSample,NeedCustom,CustomInfo,Description,Image1,Image2,Image3,Status,Deleted,VendeeId,ContacterName,TelePhone,MobilePhone,Gender,Email,CompanyName,Position,CreateTime,FamousCompanyPurchase,PurchaseType,UnitTypeId,BrowseCount,IsEmergency,IsContactInfoPublic,IsNeedIdentity,IsNeedMobilePhone,IsNeedComplete,IsNeedVipVendor,Budget,IsSetTop,SetTopDays,PurchaseProductType,SysUserId)");
            strSql.Append(" values (");
            strSql.Append("@OrderNo,@Title,@PublishTime,@ExpireTime,@RecvDistrictId,@RecvCityId,@RecvProvinceId,@Address,@ExpectVendorDistrictId,@ExpectVendorCityId,@ExpectVendorProvinceId,@Quantity,@ProductScale,@ProductCategoryId,@ProductTypeId,@NeedInvoice,@NeedSample,@NeedCustom,@CustomInfo,@Description,@Image1,@Image2,@Image3,@Status,@Deleted,@VendeeId,@ContacterName,@TelePhone,@MobilePhone,@Gender,@Email,@CompanyName,@Position,@CreateTime,@FamousCompanyPurchase,@PurchaseType,@UnitTypeId,@BrowseCount,@IsEmergency,@IsContactInfoPublic,@IsNeedIdentity,@IsNeedMobilePhone,@IsNeedComplete,@IsNeedVipVendor,@Budget,@IsSetTop,@SetTopDays,@PurchaseProductType,@SysUserId)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderNo", SqlDbType.VarChar,50),
					new SqlParameter("@Title", SqlDbType.VarChar,500),
					new SqlParameter("@PublishTime", SqlDbType.DateTime),
					new SqlParameter("@ExpireTime", SqlDbType.DateTime),
					new SqlParameter("@RecvDistrictId", SqlDbType.Int,4),
					new SqlParameter("@RecvCityId", SqlDbType.Int,4),
					new SqlParameter("@RecvProvinceId", SqlDbType.Int,4),
					new SqlParameter("@Address", SqlDbType.VarChar,250),
					new SqlParameter("@ExpectVendorDistrictId", SqlDbType.Int,4),
					new SqlParameter("@ExpectVendorCityId", SqlDbType.Int,4),
					new SqlParameter("@ExpectVendorProvinceId", SqlDbType.Int,4),
					new SqlParameter("@Quantity", SqlDbType.Int,4),
					new SqlParameter("@ProductScale", SqlDbType.VarChar,100),
					new SqlParameter("@ProductCategoryId", SqlDbType.Int,4),
					new SqlParameter("@ProductTypeId", SqlDbType.Int,4),
					new SqlParameter("@NeedInvoice", SqlDbType.Int,4),
					new SqlParameter("@NeedSample", SqlDbType.Int,4),
					new SqlParameter("@NeedCustom", SqlDbType.Int,4),
					new SqlParameter("@CustomInfo", SqlDbType.VarChar,500),
					new SqlParameter("@Description", SqlDbType.VarChar,-1),
					new SqlParameter("@Image1", SqlDbType.VarChar,200),
					new SqlParameter("@Image2", SqlDbType.VarChar,200),
					new SqlParameter("@Image3", SqlDbType.VarChar,200),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@Deleted", SqlDbType.Int,4),
					new SqlParameter("@VendeeId", SqlDbType.Int,4),
					new SqlParameter("@ContacterName", SqlDbType.VarChar,50),
					new SqlParameter("@TelePhone", SqlDbType.VarChar,50),
					new SqlParameter("@MobilePhone", SqlDbType.VarChar,50),
					new SqlParameter("@Gender", SqlDbType.Int,4),
					new SqlParameter("@Email", SqlDbType.VarChar,100),
					new SqlParameter("@CompanyName", SqlDbType.VarChar,500),
					new SqlParameter("@Position", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@FamousCompanyPurchase", SqlDbType.Int,4),
					new SqlParameter("@PurchaseType", SqlDbType.Int,4),
					new SqlParameter("@UnitTypeId", SqlDbType.Int,4),
					new SqlParameter("@BrowseCount", SqlDbType.Int,4),
					new SqlParameter("@IsEmergency", SqlDbType.Int,4),
					new SqlParameter("@IsContactInfoPublic", SqlDbType.Int,4),
					new SqlParameter("@IsNeedIdentity", SqlDbType.Bit,1),
					new SqlParameter("@IsNeedMobilePhone", SqlDbType.Bit,1),
					new SqlParameter("@IsNeedComplete", SqlDbType.Bit,1),
					new SqlParameter("@IsNeedVipVendor", SqlDbType.Bit,1),
					new SqlParameter("@Budget", SqlDbType.Decimal,9),
					new SqlParameter("@IsSetTop", SqlDbType.Bit,1),
					new SqlParameter("@SetTopDays", SqlDbType.Int,4),
					new SqlParameter("@PurchaseProductType", SqlDbType.Int,4),
					new SqlParameter("@SysUserId", SqlDbType.Int,4)};
            parameters[0].Value = model.OrderNo;
            parameters[1].Value = model.Title;
            parameters[2].Value = model.PublishTime;
            parameters[3].Value = model.ExpireTime;
            parameters[4].Value = model.RecvDistrictId;
            parameters[5].Value = model.RecvCityId;
            parameters[6].Value = model.RecvProvinceId;
            parameters[7].Value = model.Address;
            parameters[8].Value = model.ExpectVendorDistrictId;
            parameters[9].Value = model.ExpectVendorCityId;
            parameters[10].Value = model.ExpectVendorProvinceId;
            parameters[11].Value = model.Quantity;
            parameters[12].Value = model.ProductScale;
            parameters[13].Value = model.ProductCategoryId;
            parameters[14].Value = model.ProductTypeId;
            parameters[15].Value = model.NeedInvoice;
            parameters[16].Value = model.NeedSample;
            parameters[17].Value = model.NeedCustom;
            parameters[18].Value = model.CustomInfo;
            parameters[19].Value = model.Description;
            parameters[20].Value = model.Image1;
            parameters[21].Value = model.Image2;
            parameters[22].Value = model.Image3;
            parameters[23].Value = model.Status;
            parameters[24].Value = model.Deleted;
            parameters[25].Value = model.VendeeId;
            parameters[26].Value = model.ContacterName;
            parameters[27].Value = model.TelePhone;
            parameters[28].Value = model.MobilePhone;
            parameters[29].Value = model.Gender;
            parameters[30].Value = model.Email;
            parameters[31].Value = model.CompanyName;
            parameters[32].Value = model.Position;
            parameters[33].Value = model.CreateTime;
            parameters[34].Value = model.FamousCompanyPurchase;
            parameters[35].Value = model.PurchaseType;
            parameters[36].Value = model.UnitTypeId;
            parameters[37].Value = model.BrowseCount;
            parameters[38].Value = model.IsEmergency;
            parameters[39].Value = model.IsContactInfoPublic;
            parameters[40].Value = model.IsNeedIdentity;
            parameters[41].Value = model.IsNeedMobilePhone;
            parameters[42].Value = model.IsNeedComplete;
            parameters[43].Value = model.IsNeedVipVendor;
            parameters[44].Value = model.Budget;
            parameters[45].Value = model.IsSetTop;
            parameters[46].Value = model.SetTopDays;
            parameters[47].Value = model.PurchaseProductType;
            parameters[48].Value = model.SysUserId;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.PurchaseOrder model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update PurchaseOrder set ");
            strSql.Append("OrderNo=@OrderNo,");
            strSql.Append("Title=@Title,");
            strSql.Append("PublishTime=@PublishTime,");
            strSql.Append("ExpireTime=@ExpireTime,");
            strSql.Append("RecvDistrictId=@RecvDistrictId,");
            strSql.Append("RecvCityId=@RecvCityId,");
            strSql.Append("RecvProvinceId=@RecvProvinceId,");
            strSql.Append("Address=@Address,");
            strSql.Append("ExpectVendorDistrictId=@ExpectVendorDistrictId,");
            strSql.Append("ExpectVendorCityId=@ExpectVendorCityId,");
            strSql.Append("ExpectVendorProvinceId=@ExpectVendorProvinceId,");
            strSql.Append("Quantity=@Quantity,");
            strSql.Append("ProductScale=@ProductScale,");
            strSql.Append("ProductCategoryId=@ProductCategoryId,");
            strSql.Append("ProductTypeId=@ProductTypeId,");
            strSql.Append("NeedInvoice=@NeedInvoice,");
            strSql.Append("NeedSample=@NeedSample,");
            strSql.Append("NeedCustom=@NeedCustom,");
            strSql.Append("CustomInfo=@CustomInfo,");
            strSql.Append("Description=@Description,");
            strSql.Append("Image1=@Image1,");
            strSql.Append("Image2=@Image2,");
            strSql.Append("Image3=@Image3,");
            strSql.Append("Status=@Status,");
            strSql.Append("Deleted=@Deleted,");
            strSql.Append("VendeeId=@VendeeId,");
            strSql.Append("ContacterName=@ContacterName,");
            strSql.Append("TelePhone=@TelePhone,");
            strSql.Append("MobilePhone=@MobilePhone,");
            strSql.Append("Gender=@Gender,");
            strSql.Append("Email=@Email,");
            strSql.Append("CompanyName=@CompanyName,");
            strSql.Append("Position=@Position,");
            strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("FamousCompanyPurchase=@FamousCompanyPurchase,");
            strSql.Append("PurchaseType=@PurchaseType,");
            strSql.Append("UnitTypeId=@UnitTypeId,");
            strSql.Append("BrowseCount=@BrowseCount,");
            strSql.Append("IsEmergency=@IsEmergency,");
            strSql.Append("IsContactInfoPublic=@IsContactInfoPublic,");
            strSql.Append("IsNeedIdentity=@IsNeedIdentity,");
            strSql.Append("IsNeedMobilePhone=@IsNeedMobilePhone,");
            strSql.Append("IsNeedComplete=@IsNeedComplete,");
            strSql.Append("IsNeedVipVendor=@IsNeedVipVendor,");
            strSql.Append("Budget=@Budget,");
            strSql.Append("IsSetTop=@IsSetTop,");
            strSql.Append("SetTopDays=@SetTopDays,");
            strSql.Append("PurchaseProductType=@PurchaseProductType,");
            strSql.Append("SysUserId=@SysUserId");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderNo", SqlDbType.VarChar,50),
					new SqlParameter("@Title", SqlDbType.VarChar,500),
					new SqlParameter("@PublishTime", SqlDbType.DateTime),
					new SqlParameter("@ExpireTime", SqlDbType.DateTime),
					new SqlParameter("@RecvDistrictId", SqlDbType.Int,4),
					new SqlParameter("@RecvCityId", SqlDbType.Int,4),
					new SqlParameter("@RecvProvinceId", SqlDbType.Int,4),
					new SqlParameter("@Address", SqlDbType.VarChar,250),
					new SqlParameter("@ExpectVendorDistrictId", SqlDbType.Int,4),
					new SqlParameter("@ExpectVendorCityId", SqlDbType.Int,4),
					new SqlParameter("@ExpectVendorProvinceId", SqlDbType.Int,4),
					new SqlParameter("@Quantity", SqlDbType.Int,4),
					new SqlParameter("@ProductScale", SqlDbType.VarChar,100),
					new SqlParameter("@ProductCategoryId", SqlDbType.Int,4),
					new SqlParameter("@ProductTypeId", SqlDbType.Int,4),
					new SqlParameter("@NeedInvoice", SqlDbType.Int,4),
					new SqlParameter("@NeedSample", SqlDbType.Int,4),
					new SqlParameter("@NeedCustom", SqlDbType.Int,4),
					new SqlParameter("@CustomInfo", SqlDbType.VarChar,500),
					new SqlParameter("@Description", SqlDbType.VarChar,-1),
					new SqlParameter("@Image1", SqlDbType.VarChar,200),
					new SqlParameter("@Image2", SqlDbType.VarChar,200),
					new SqlParameter("@Image3", SqlDbType.VarChar,200),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@Deleted", SqlDbType.Int,4),
					new SqlParameter("@VendeeId", SqlDbType.Int,4),
					new SqlParameter("@ContacterName", SqlDbType.VarChar,50),
					new SqlParameter("@TelePhone", SqlDbType.VarChar,50),
					new SqlParameter("@MobilePhone", SqlDbType.VarChar,50),
					new SqlParameter("@Gender", SqlDbType.Int,4),
					new SqlParameter("@Email", SqlDbType.VarChar,100),
					new SqlParameter("@CompanyName", SqlDbType.VarChar,500),
					new SqlParameter("@Position", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@FamousCompanyPurchase", SqlDbType.Int,4),
					new SqlParameter("@PurchaseType", SqlDbType.Int,4),
					new SqlParameter("@UnitTypeId", SqlDbType.Int,4),
					new SqlParameter("@BrowseCount", SqlDbType.Int,4),
					new SqlParameter("@IsEmergency", SqlDbType.Int,4),
					new SqlParameter("@IsContactInfoPublic", SqlDbType.Int,4),
					new SqlParameter("@IsNeedIdentity", SqlDbType.Bit,1),
					new SqlParameter("@IsNeedMobilePhone", SqlDbType.Bit,1),
					new SqlParameter("@IsNeedComplete", SqlDbType.Bit,1),
					new SqlParameter("@IsNeedVipVendor", SqlDbType.Bit,1),
					new SqlParameter("@Budget", SqlDbType.Decimal,9),
					new SqlParameter("@IsSetTop", SqlDbType.Bit,1),
					new SqlParameter("@SetTopDays", SqlDbType.Int,4),
					new SqlParameter("@PurchaseProductType", SqlDbType.Int,4),
					new SqlParameter("@SysUserId", SqlDbType.Int,4),
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = model.OrderNo;
            parameters[1].Value = model.Title;
            parameters[2].Value = model.PublishTime;
            parameters[3].Value = model.ExpireTime;
            parameters[4].Value = model.RecvDistrictId;
            parameters[5].Value = model.RecvCityId;
            parameters[6].Value = model.RecvProvinceId;
            parameters[7].Value = model.Address;
            parameters[8].Value = model.ExpectVendorDistrictId;
            parameters[9].Value = model.ExpectVendorCityId;
            parameters[10].Value = model.ExpectVendorProvinceId;
            parameters[11].Value = model.Quantity;
            parameters[12].Value = model.ProductScale;
            parameters[13].Value = model.ProductCategoryId;
            parameters[14].Value = model.ProductTypeId;
            parameters[15].Value = model.NeedInvoice;
            parameters[16].Value = model.NeedSample;
            parameters[17].Value = model.NeedCustom;
            parameters[18].Value = model.CustomInfo;
            parameters[19].Value = model.Description;
            parameters[20].Value = model.Image1;
            parameters[21].Value = model.Image2;
            parameters[22].Value = model.Image3;
            parameters[23].Value = model.Status;
            parameters[24].Value = model.Deleted;
            parameters[25].Value = model.VendeeId;
            parameters[26].Value = model.ContacterName;
            parameters[27].Value = model.TelePhone;
            parameters[28].Value = model.MobilePhone;
            parameters[29].Value = model.Gender;
            parameters[30].Value = model.Email;
            parameters[31].Value = model.CompanyName;
            parameters[32].Value = model.Position;
            parameters[33].Value = model.CreateTime;
            parameters[34].Value = model.FamousCompanyPurchase;
            parameters[35].Value = model.PurchaseType;
            parameters[36].Value = model.UnitTypeId;
            parameters[37].Value = model.BrowseCount;
            parameters[38].Value = model.IsEmergency;
            parameters[39].Value = model.IsContactInfoPublic;
            parameters[40].Value = model.IsNeedIdentity;
            parameters[41].Value = model.IsNeedMobilePhone;
            parameters[42].Value = model.IsNeedComplete;
            parameters[43].Value = model.IsNeedVipVendor;
            parameters[44].Value = model.Budget;
            parameters[45].Value = model.IsSetTop;
            parameters[46].Value = model.SetTopDays;
            parameters[47].Value = model.PurchaseProductType;
            parameters[48].Value = model.SysUserId;
            parameters[49].Value = model.Id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PurchaseOrder ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
            parameters[0].Value = Id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string Idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PurchaseOrder ");
            strSql.Append(" where Id in (" + Idlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.PurchaseOrder GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,OrderNo,Title,PublishTime,ExpireTime,RecvDistrictId,RecvCityId,RecvProvinceId,Address,ExpectVendorDistrictId,ExpectVendorCityId,ExpectVendorProvinceId,Quantity,ProductScale,ProductCategoryId,ProductTypeId,NeedInvoice,NeedSample,NeedCustom,CustomInfo,Description,Image1,Image2,Image3,Status,Deleted,VendeeId,ContacterName,TelePhone,MobilePhone,Gender,Email,CompanyName,Position,CreateTime,FamousCompanyPurchase,PurchaseType,UnitTypeId,BrowseCount,IsEmergency,IsContactInfoPublic,IsNeedIdentity,IsNeedMobilePhone,IsNeedComplete,IsNeedVipVendor,Budget,IsSetTop,SetTopDays,PurchaseProductType,SysUserId from PurchaseOrder ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
            parameters[0].Value = Id;

            Model.PurchaseOrder model = new Model.PurchaseOrder();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.PurchaseOrder DataRowToModel(DataRow row)
        {
            Model.PurchaseOrder model = new Model.PurchaseOrder();
            if (row != null)
            {
                if (row["Id"] != null && row["Id"].ToString() != "")
                {
                    model.Id = int.Parse(row["Id"].ToString());
                }
                if (row["OrderNo"] != null)
                {
                    model.OrderNo = row["OrderNo"].ToString();
                }
                if (row["Title"] != null)
                {
                    model.Title = row["Title"].ToString();
                }
                if (row["PublishTime"] != null && row["PublishTime"].ToString() != "")
                {
                    model.PublishTime = DateTime.Parse(row["PublishTime"].ToString());
                }
                if (row["ExpireTime"] != null && row["ExpireTime"].ToString() != "")
                {
                    model.ExpireTime = DateTime.Parse(row["ExpireTime"].ToString());
                }
                if (row["RecvDistrictId"] != null && row["RecvDistrictId"].ToString() != "")
                {
                    model.RecvDistrictId = int.Parse(row["RecvDistrictId"].ToString());
                }
                if (row["RecvCityId"] != null && row["RecvCityId"].ToString() != "")
                {
                    model.RecvCityId = int.Parse(row["RecvCityId"].ToString());
                }
                if (row["RecvProvinceId"] != null && row["RecvProvinceId"].ToString() != "")
                {
                    model.RecvProvinceId = int.Parse(row["RecvProvinceId"].ToString());
                }
                if (row["Address"] != null)
                {
                    model.Address = row["Address"].ToString();
                }
                if (row["ExpectVendorDistrictId"] != null && row["ExpectVendorDistrictId"].ToString() != "")
                {
                    model.ExpectVendorDistrictId = int.Parse(row["ExpectVendorDistrictId"].ToString());
                }
                if (row["ExpectVendorCityId"] != null && row["ExpectVendorCityId"].ToString() != "")
                {
                    model.ExpectVendorCityId = int.Parse(row["ExpectVendorCityId"].ToString());
                }
                if (row["ExpectVendorProvinceId"] != null && row["ExpectVendorProvinceId"].ToString() != "")
                {
                    model.ExpectVendorProvinceId = int.Parse(row["ExpectVendorProvinceId"].ToString());
                }
                if (row["Quantity"] != null && row["Quantity"].ToString() != "")
                {
                    model.Quantity = int.Parse(row["Quantity"].ToString());
                }
                if (row["ProductScale"] != null)
                {
                    model.ProductScale = row["ProductScale"].ToString();
                }
                if (row["ProductCategoryId"] != null && row["ProductCategoryId"].ToString() != "")
                {
                    model.ProductCategoryId = int.Parse(row["ProductCategoryId"].ToString());
                }
                if (row["ProductTypeId"] != null && row["ProductTypeId"].ToString() != "")
                {
                    model.ProductTypeId = int.Parse(row["ProductTypeId"].ToString());
                }
                if (row["NeedInvoice"] != null && row["NeedInvoice"].ToString() != "")
                {
                    model.NeedInvoice = int.Parse(row["NeedInvoice"].ToString());
                }
                if (row["NeedSample"] != null && row["NeedSample"].ToString() != "")
                {
                    model.NeedSample = int.Parse(row["NeedSample"].ToString());
                }
                if (row["NeedCustom"] != null && row["NeedCustom"].ToString() != "")
                {
                    model.NeedCustom = int.Parse(row["NeedCustom"].ToString());
                }
                if (row["CustomInfo"] != null)
                {
                    model.CustomInfo = row["CustomInfo"].ToString();
                }
                if (row["Description"] != null)
                {
                    model.Description = row["Description"].ToString();
                }
                if (row["Image1"] != null)
                {
                    model.Image1 = row["Image1"].ToString();
                }
                if (row["Image2"] != null)
                {
                    model.Image2 = row["Image2"].ToString();
                }
                if (row["Image3"] != null)
                {
                    model.Image3 = row["Image3"].ToString();
                }
                if (row["Status"] != null && row["Status"].ToString() != "")
                {
                    model.Status = int.Parse(row["Status"].ToString());
                }
                if (row["Deleted"] != null && row["Deleted"].ToString() != "")
                {
                    model.Deleted = int.Parse(row["Deleted"].ToString());
                }
                if (row["VendeeId"] != null && row["VendeeId"].ToString() != "")
                {
                    model.VendeeId = int.Parse(row["VendeeId"].ToString());
                }
                if (row["ContacterName"] != null)
                {
                    model.ContacterName = row["ContacterName"].ToString();
                }
                if (row["TelePhone"] != null)
                {
                    model.TelePhone = row["TelePhone"].ToString();
                }
                if (row["MobilePhone"] != null)
                {
                    model.MobilePhone = row["MobilePhone"].ToString();
                }
                if (row["Gender"] != null && row["Gender"].ToString() != "")
                {
                    model.Gender = int.Parse(row["Gender"].ToString());
                }
                if (row["Email"] != null)
                {
                    model.Email = row["Email"].ToString();
                }
                if (row["CompanyName"] != null)
                {
                    model.CompanyName = row["CompanyName"].ToString();
                }
                if (row["Position"] != null && row["Position"].ToString() != "")
                {
                    model.Position = int.Parse(row["Position"].ToString());
                }
                if (row["CreateTime"] != null && row["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(row["CreateTime"].ToString());
                }
                if (row["FamousCompanyPurchase"] != null && row["FamousCompanyPurchase"].ToString() != "")
                {
                    model.FamousCompanyPurchase = int.Parse(row["FamousCompanyPurchase"].ToString());
                }
                if (row["PurchaseType"] != null && row["PurchaseType"].ToString() != "")
                {
                    model.PurchaseType = int.Parse(row["PurchaseType"].ToString());
                }
                if (row["UnitTypeId"] != null && row["UnitTypeId"].ToString() != "")
                {
                    model.UnitTypeId = int.Parse(row["UnitTypeId"].ToString());
                }
                if (row["BrowseCount"] != null && row["BrowseCount"].ToString() != "")
                {
                    model.BrowseCount = int.Parse(row["BrowseCount"].ToString());
                }
                if (row["IsEmergency"] != null && row["IsEmergency"].ToString() != "")
                {
                    model.IsEmergency = int.Parse(row["IsEmergency"].ToString());
                }
                if (row["IsContactInfoPublic"] != null && row["IsContactInfoPublic"].ToString() != "")
                {
                    model.IsContactInfoPublic = int.Parse(row["IsContactInfoPublic"].ToString());
                }
                if (row["IsNeedIdentity"] != null && row["IsNeedIdentity"].ToString() != "")
                {
                    if ((row["IsNeedIdentity"].ToString() == "1") || (row["IsNeedIdentity"].ToString().ToLower() == "true"))
                    {
                        model.IsNeedIdentity = true;
                    }
                    else
                    {
                        model.IsNeedIdentity = false;
                    }
                }
                if (row["IsNeedMobilePhone"] != null && row["IsNeedMobilePhone"].ToString() != "")
                {
                    if ((row["IsNeedMobilePhone"].ToString() == "1") || (row["IsNeedMobilePhone"].ToString().ToLower() == "true"))
                    {
                        model.IsNeedMobilePhone = true;
                    }
                    else
                    {
                        model.IsNeedMobilePhone = false;
                    }
                }
                if (row["IsNeedComplete"] != null && row["IsNeedComplete"].ToString() != "")
                {
                    if ((row["IsNeedComplete"].ToString() == "1") || (row["IsNeedComplete"].ToString().ToLower() == "true"))
                    {
                        model.IsNeedComplete = true;
                    }
                    else
                    {
                        model.IsNeedComplete = false;
                    }
                }
                if (row["IsNeedVipVendor"] != null && row["IsNeedVipVendor"].ToString() != "")
                {
                    if ((row["IsNeedVipVendor"].ToString() == "1") || (row["IsNeedVipVendor"].ToString().ToLower() == "true"))
                    {
                        model.IsNeedVipVendor = true;
                    }
                    else
                    {
                        model.IsNeedVipVendor = false;
                    }
                }
                if (row["Budget"] != null && row["Budget"].ToString() != "")
                {
                    model.Budget = decimal.Parse(row["Budget"].ToString());
                }
                if (row["IsSetTop"] != null && row["IsSetTop"].ToString() != "")
                {
                    if ((row["IsSetTop"].ToString() == "1") || (row["IsSetTop"].ToString().ToLower() == "true"))
                    {
                        model.IsSetTop = true;
                    }
                    else
                    {
                        model.IsSetTop = false;
                    }
                }
                if (row["SetTopDays"] != null && row["SetTopDays"].ToString() != "")
                {
                    model.SetTopDays = int.Parse(row["SetTopDays"].ToString());
                }
                if (row["PurchaseProductType"] != null && row["PurchaseProductType"].ToString() != "")
                {
                    model.PurchaseProductType = int.Parse(row["PurchaseProductType"].ToString());
                }
                if (row["SysUserId"] != null && row["SysUserId"].ToString() != "")
                {
                    model.SysUserId = int.Parse(row["SysUserId"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,OrderNo,Title,PublishTime,ExpireTime,RecvDistrictId,RecvCityId,RecvProvinceId,Address,ExpectVendorDistrictId,ExpectVendorCityId,ExpectVendorProvinceId,Quantity,ProductScale,ProductCategoryId,ProductTypeId,NeedInvoice,NeedSample,NeedCustom,CustomInfo,Description,Image1,Image2,Image3,Status,Deleted,VendeeId,ContacterName,TelePhone,MobilePhone,Gender,Email,CompanyName,Position,CreateTime,FamousCompanyPurchase,PurchaseType,UnitTypeId,BrowseCount,IsEmergency,IsContactInfoPublic,IsNeedIdentity,IsNeedMobilePhone,IsNeedComplete,IsNeedVipVendor,Budget,IsSetTop,SetTopDays,PurchaseProductType,SysUserId ");
            strSql.Append(" FROM PurchaseOrder ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" Id,OrderNo,Title,PublishTime,ExpireTime,RecvDistrictId,RecvCityId,RecvProvinceId,Address,ExpectVendorDistrictId,ExpectVendorCityId,ExpectVendorProvinceId,Quantity,ProductScale,ProductCategoryId,ProductTypeId,NeedInvoice,NeedSample,NeedCustom,CustomInfo,Description,Image1,Image2,Image3,Status,Deleted,VendeeId,ContacterName,TelePhone,MobilePhone,Gender,Email,CompanyName,Position,CreateTime,FamousCompanyPurchase,PurchaseType,UnitTypeId,BrowseCount,IsEmergency,IsContactInfoPublic,IsNeedIdentity,IsNeedMobilePhone,IsNeedComplete,IsNeedVipVendor,Budget,IsSetTop,SetTopDays,PurchaseProductType,SysUserId ");
            strSql.Append(" FROM PurchaseOrder ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM PurchaseOrder ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.Id desc");
            }
            strSql.Append(")AS Row, T.*  from PurchaseOrder T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "PurchaseOrder";
            parameters[1].Value = "Id";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}


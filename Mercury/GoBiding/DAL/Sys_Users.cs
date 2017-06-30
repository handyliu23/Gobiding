using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace GoBiding.DAL
{
	/// <summary>
	/// 数据访问类:Sys_Users
	/// </summary>
	public partial class Sys_Users
	{
		public Sys_Users()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("CompanyId", "Sys_Users"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int CompanyId,int Sys_UserId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Sys_Users");
			strSql.Append(" where CompanyId=@CompanyId and Sys_UserId=@Sys_UserId ");
			SqlParameter[] parameters = {
					new SqlParameter("@CompanyId", SqlDbType.Int,4),
					new SqlParameter("@Sys_UserId", SqlDbType.Int,4)			};
			parameters[0].Value = CompanyId;
			parameters[1].Value = Sys_UserId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(GoBiding.Model.Sys_Users model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Sys_Users(");
			strSql.Append("UserNickName,UserGUID,Password,UserName,Description,UserProfile,Gender,Address,ContacterName,TelephonePhone,TelephonePhone2,MobilePhone,MobilePhone2,Email,QQ,Fax,DistrictId,OnCreate,Deleted,ManufacturerGUID,PostCode,WebSite,Notes,DisplayOrder,Scores,LoginIp,LastLoginTime,LevelId,LastLoginIp,DefaultAddressId,RecommenderId,UserLoginType,OpenId,AccessToken,RecommendUserId,CompanyId,CompanyName,IsSmsNotice,IsEmailNotice,IsWeiXinNotice,LevelServiceTime,YYZZ,ZZDJZ,SWDJZ,SFZ1,SFZ2,CompanyAuditStatus,CompanyAuditApplyTime,CompanyAuditTime,LoginTimes,CreateByPlatform,LastLoginPlatform,ThirdLoginPartyName)");
			strSql.Append(" values (");
			strSql.Append("@UserNickName,@UserGUID,@Password,@UserName,@Description,@UserProfile,@Gender,@Address,@ContacterName,@TelephonePhone,@TelephonePhone2,@MobilePhone,@MobilePhone2,@Email,@QQ,@Fax,@DistrictId,@OnCreate,@Deleted,@ManufacturerGUID,@PostCode,@WebSite,@Notes,@DisplayOrder,@Scores,@LoginIp,@LastLoginTime,@LevelId,@LastLoginIp,@DefaultAddressId,@RecommenderId,@UserLoginType,@OpenId,@AccessToken,@RecommendUserId,@CompanyId,@CompanyName,@IsSmsNotice,@IsEmailNotice,@IsWeiXinNotice,@LevelServiceTime,@YYZZ,@ZZDJZ,@SWDJZ,@SFZ1,@SFZ2,@CompanyAuditStatus,@CompanyAuditApplyTime,@CompanyAuditTime,@LoginTimes,@CreateByPlatform,@LastLoginPlatform,@ThirdLoginPartyName)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@UserNickName", SqlDbType.VarChar,50),
					new SqlParameter("@UserGUID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@Password", SqlDbType.VarChar,50),
					new SqlParameter("@UserName", SqlDbType.NVarChar,500),
					new SqlParameter("@Description", SqlDbType.Text),
					new SqlParameter("@UserProfile", SqlDbType.VarChar,200),
					new SqlParameter("@Gender", SqlDbType.Int,4),
					new SqlParameter("@Address", SqlDbType.VarChar,500),
					new SqlParameter("@ContacterName", SqlDbType.NVarChar,100),
					new SqlParameter("@TelephonePhone", SqlDbType.VarChar,20),
					new SqlParameter("@TelephonePhone2", SqlDbType.VarChar,20),
					new SqlParameter("@MobilePhone", SqlDbType.VarChar,50),
					new SqlParameter("@MobilePhone2", SqlDbType.VarChar,50),
					new SqlParameter("@Email", SqlDbType.VarChar,50),
					new SqlParameter("@QQ", SqlDbType.VarChar,20),
					new SqlParameter("@Fax", SqlDbType.VarChar,50),
					new SqlParameter("@DistrictId", SqlDbType.Int,4),
					new SqlParameter("@OnCreate", SqlDbType.DateTime),
					new SqlParameter("@Deleted", SqlDbType.Bit,1),
					new SqlParameter("@ManufacturerGUID", SqlDbType.VarChar,50),
					new SqlParameter("@PostCode", SqlDbType.VarChar,10),
					new SqlParameter("@WebSite", SqlDbType.VarChar,50),
					new SqlParameter("@Notes", SqlDbType.Text),
					new SqlParameter("@DisplayOrder", SqlDbType.Int,4),
					new SqlParameter("@Scores", SqlDbType.Int,4),
					new SqlParameter("@LoginIp", SqlDbType.VarChar,50),
					new SqlParameter("@LastLoginTime", SqlDbType.DateTime),
					new SqlParameter("@LevelId", SqlDbType.Int,4),
					new SqlParameter("@LastLoginIp", SqlDbType.VarChar,20),
					new SqlParameter("@DefaultAddressId", SqlDbType.Int,4),
					new SqlParameter("@RecommenderId", SqlDbType.Int,4),
					new SqlParameter("@UserLoginType", SqlDbType.Int,4),
					new SqlParameter("@OpenId", SqlDbType.VarChar,50),
					new SqlParameter("@AccessToken", SqlDbType.VarChar,50),
					new SqlParameter("@RecommendUserId", SqlDbType.Int,4),
					new SqlParameter("@CompanyId", SqlDbType.Int,4),
					new SqlParameter("@CompanyName", SqlDbType.VarChar,100),
					new SqlParameter("@IsSmsNotice", SqlDbType.Int,4),
					new SqlParameter("@IsEmailNotice", SqlDbType.Int,4),
					new SqlParameter("@IsWeiXinNotice", SqlDbType.Int,4),
					new SqlParameter("@LevelServiceTime", SqlDbType.DateTime),
					new SqlParameter("@YYZZ", SqlDbType.VarChar,100),
					new SqlParameter("@ZZDJZ", SqlDbType.VarChar,100),
					new SqlParameter("@SWDJZ", SqlDbType.VarChar,100),
					new SqlParameter("@SFZ1", SqlDbType.VarChar,100),
					new SqlParameter("@SFZ2", SqlDbType.VarChar,100),
					new SqlParameter("@CompanyAuditStatus", SqlDbType.Int,4),
					new SqlParameter("@CompanyAuditApplyTime", SqlDbType.DateTime),
					new SqlParameter("@CompanyAuditTime", SqlDbType.DateTime),
					new SqlParameter("@LoginTimes", SqlDbType.Int,4),
					new SqlParameter("@CreateByPlatform", SqlDbType.VarChar,50),
					new SqlParameter("@LastLoginPlatform", SqlDbType.VarChar,50),
					new SqlParameter("@ThirdLoginPartyName", SqlDbType.VarChar,50)};
			parameters[0].Value = model.UserNickName;
			parameters[1].Value = Guid.NewGuid();
			parameters[2].Value = model.Password;
			parameters[3].Value = model.UserName;
			parameters[4].Value = model.Description;
			parameters[5].Value = model.UserProfile;
			parameters[6].Value = model.Gender;
			parameters[7].Value = model.Address;
			parameters[8].Value = model.ContacterName;
			parameters[9].Value = model.TelephonePhone;
			parameters[10].Value = model.TelephonePhone2;
			parameters[11].Value = model.MobilePhone;
			parameters[12].Value = model.MobilePhone2;
			parameters[13].Value = model.Email;
			parameters[14].Value = model.QQ;
			parameters[15].Value = model.Fax;
			parameters[16].Value = model.DistrictId;
			parameters[17].Value = model.OnCreate;
			parameters[18].Value = model.Deleted;
			parameters[19].Value = model.ManufacturerGUID;
			parameters[20].Value = model.PostCode;
			parameters[21].Value = model.WebSite;
			parameters[22].Value = model.Notes;
			parameters[23].Value = model.DisplayOrder;
			parameters[24].Value = model.Scores;
			parameters[25].Value = model.LoginIp;
			parameters[26].Value = model.LastLoginTime;
			parameters[27].Value = model.LevelId;
			parameters[28].Value = model.LastLoginIp;
			parameters[29].Value = model.DefaultAddressId;
			parameters[30].Value = model.RecommenderId;
			parameters[31].Value = model.UserLoginType;
			parameters[32].Value = model.OpenId;
			parameters[33].Value = model.AccessToken;
			parameters[34].Value = model.RecommendUserId;
			parameters[35].Value = model.CompanyId;
			parameters[36].Value = model.CompanyName;
			parameters[37].Value = model.IsSmsNotice;
			parameters[38].Value = model.IsEmailNotice;
			parameters[39].Value = model.IsWeiXinNotice;
			parameters[40].Value = model.LevelServiceTime;
			parameters[41].Value = model.YYZZ;
			parameters[42].Value = model.ZZDJZ;
			parameters[43].Value = model.SWDJZ;
			parameters[44].Value = model.SFZ1;
			parameters[45].Value = model.SFZ2;
			parameters[46].Value = model.CompanyAuditStatus;
			parameters[47].Value = model.CompanyAuditApplyTime;
			parameters[48].Value = model.CompanyAuditTime;
			parameters[49].Value = model.LoginTimes;
			parameters[50].Value = model.CreateByPlatform;
			parameters[51].Value = model.LastLoginPlatform;
			parameters[52].Value = model.ThirdLoginPartyName;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
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
		public bool Update(GoBiding.Model.Sys_Users model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Sys_Users set ");
			strSql.Append("UserNickName=@UserNickName,");
			strSql.Append("UserGUID=@UserGUID,");
			strSql.Append("Password=@Password,");
			strSql.Append("UserName=@UserName,");
			strSql.Append("Description=@Description,");
			strSql.Append("UserProfile=@UserProfile,");
			strSql.Append("Gender=@Gender,");
			strSql.Append("Address=@Address,");
			strSql.Append("ContacterName=@ContacterName,");
			strSql.Append("TelephonePhone=@TelephonePhone,");
			strSql.Append("TelephonePhone2=@TelephonePhone2,");
			strSql.Append("MobilePhone=@MobilePhone,");
			strSql.Append("MobilePhone2=@MobilePhone2,");
			strSql.Append("Email=@Email,");
			strSql.Append("QQ=@QQ,");
			strSql.Append("Fax=@Fax,");
			strSql.Append("DistrictId=@DistrictId,");
			strSql.Append("OnCreate=@OnCreate,");
			strSql.Append("Deleted=@Deleted,");
			strSql.Append("ManufacturerGUID=@ManufacturerGUID,");
			strSql.Append("PostCode=@PostCode,");
			strSql.Append("WebSite=@WebSite,");
			strSql.Append("Notes=@Notes,");
			strSql.Append("DisplayOrder=@DisplayOrder,");
			strSql.Append("Scores=@Scores,");
			strSql.Append("LoginIp=@LoginIp,");
			strSql.Append("LastLoginTime=@LastLoginTime,");
			strSql.Append("LevelId=@LevelId,");
			strSql.Append("LastLoginIp=@LastLoginIp,");
			strSql.Append("DefaultAddressId=@DefaultAddressId,");
			strSql.Append("RecommenderId=@RecommenderId,");
			strSql.Append("UserLoginType=@UserLoginType,");
			strSql.Append("OpenId=@OpenId,");
			strSql.Append("AccessToken=@AccessToken,");
			strSql.Append("RecommendUserId=@RecommendUserId,");
			strSql.Append("CompanyName=@CompanyName,");
			strSql.Append("IsSmsNotice=@IsSmsNotice,");
			strSql.Append("IsEmailNotice=@IsEmailNotice,");
			strSql.Append("IsWeiXinNotice=@IsWeiXinNotice,");
			strSql.Append("LevelServiceTime=@LevelServiceTime,");
			strSql.Append("YYZZ=@YYZZ,");
			strSql.Append("ZZDJZ=@ZZDJZ,");
			strSql.Append("SWDJZ=@SWDJZ,");
			strSql.Append("SFZ1=@SFZ1,");
			strSql.Append("SFZ2=@SFZ2,");
			strSql.Append("CompanyAuditStatus=@CompanyAuditStatus,");
			strSql.Append("CompanyAuditApplyTime=@CompanyAuditApplyTime,");
			strSql.Append("CompanyAuditTime=@CompanyAuditTime,");
			strSql.Append("LoginTimes=@LoginTimes,");
			strSql.Append("CreateByPlatform=@CreateByPlatform,");
			strSql.Append("LastLoginPlatform=@LastLoginPlatform,");
			strSql.Append("ThirdLoginPartyName=@ThirdLoginPartyName");
			strSql.Append(" where Sys_UserId=@Sys_UserId");
			SqlParameter[] parameters = {
					new SqlParameter("@UserNickName", SqlDbType.VarChar,50),
					new SqlParameter("@UserGUID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@Password", SqlDbType.VarChar,50),
					new SqlParameter("@UserName", SqlDbType.NVarChar,500),
					new SqlParameter("@Description", SqlDbType.Text),
					new SqlParameter("@UserProfile", SqlDbType.VarChar,200),
					new SqlParameter("@Gender", SqlDbType.Int,4),
					new SqlParameter("@Address", SqlDbType.VarChar,500),
					new SqlParameter("@ContacterName", SqlDbType.NVarChar,100),
					new SqlParameter("@TelephonePhone", SqlDbType.VarChar,20),
					new SqlParameter("@TelephonePhone2", SqlDbType.VarChar,20),
					new SqlParameter("@MobilePhone", SqlDbType.VarChar,50),
					new SqlParameter("@MobilePhone2", SqlDbType.VarChar,50),
					new SqlParameter("@Email", SqlDbType.VarChar,50),
					new SqlParameter("@QQ", SqlDbType.VarChar,20),
					new SqlParameter("@Fax", SqlDbType.VarChar,50),
					new SqlParameter("@DistrictId", SqlDbType.Int,4),
					new SqlParameter("@OnCreate", SqlDbType.DateTime),
					new SqlParameter("@Deleted", SqlDbType.Bit,1),
					new SqlParameter("@ManufacturerGUID", SqlDbType.VarChar,50),
					new SqlParameter("@PostCode", SqlDbType.VarChar,10),
					new SqlParameter("@WebSite", SqlDbType.VarChar,50),
					new SqlParameter("@Notes", SqlDbType.Text),
					new SqlParameter("@DisplayOrder", SqlDbType.Int,4),
					new SqlParameter("@Scores", SqlDbType.Int,4),
					new SqlParameter("@LoginIp", SqlDbType.VarChar,50),
					new SqlParameter("@LastLoginTime", SqlDbType.DateTime),
					new SqlParameter("@LevelId", SqlDbType.Int,4),
					new SqlParameter("@LastLoginIp", SqlDbType.VarChar,20),
					new SqlParameter("@DefaultAddressId", SqlDbType.Int,4),
					new SqlParameter("@RecommenderId", SqlDbType.Int,4),
					new SqlParameter("@UserLoginType", SqlDbType.Int,4),
					new SqlParameter("@OpenId", SqlDbType.VarChar,50),
					new SqlParameter("@AccessToken", SqlDbType.VarChar,50),
					new SqlParameter("@RecommendUserId", SqlDbType.Int,4),
					new SqlParameter("@CompanyName", SqlDbType.VarChar,100),
					new SqlParameter("@IsSmsNotice", SqlDbType.Int,4),
					new SqlParameter("@IsEmailNotice", SqlDbType.Int,4),
					new SqlParameter("@IsWeiXinNotice", SqlDbType.Int,4),
					new SqlParameter("@LevelServiceTime", SqlDbType.DateTime),
					new SqlParameter("@YYZZ", SqlDbType.VarChar,100),
					new SqlParameter("@ZZDJZ", SqlDbType.VarChar,100),
					new SqlParameter("@SWDJZ", SqlDbType.VarChar,100),
					new SqlParameter("@SFZ1", SqlDbType.VarChar,100),
					new SqlParameter("@SFZ2", SqlDbType.VarChar,100),
					new SqlParameter("@CompanyAuditStatus", SqlDbType.Int,4),
					new SqlParameter("@CompanyAuditApplyTime", SqlDbType.DateTime),
					new SqlParameter("@CompanyAuditTime", SqlDbType.DateTime),
					new SqlParameter("@LoginTimes", SqlDbType.Int,4),
					new SqlParameter("@CreateByPlatform", SqlDbType.VarChar,50),
					new SqlParameter("@LastLoginPlatform", SqlDbType.VarChar,50),
					new SqlParameter("@ThirdLoginPartyName", SqlDbType.VarChar,50),
					new SqlParameter("@Sys_UserId", SqlDbType.Int,4),
					new SqlParameter("@CompanyId", SqlDbType.Int,4)};
			parameters[0].Value = model.UserNickName;
			parameters[1].Value = model.UserGUID;
			parameters[2].Value = model.Password;
			parameters[3].Value = model.UserName;
			parameters[4].Value = model.Description;
			parameters[5].Value = model.UserProfile;
			parameters[6].Value = model.Gender;
			parameters[7].Value = model.Address;
			parameters[8].Value = model.ContacterName;
			parameters[9].Value = model.TelephonePhone;
			parameters[10].Value = model.TelephonePhone2;
			parameters[11].Value = model.MobilePhone;
			parameters[12].Value = model.MobilePhone2;
			parameters[13].Value = model.Email;
			parameters[14].Value = model.QQ;
			parameters[15].Value = model.Fax;
			parameters[16].Value = model.DistrictId;
			parameters[17].Value = model.OnCreate;
			parameters[18].Value = model.Deleted;
			parameters[19].Value = model.ManufacturerGUID;
			parameters[20].Value = model.PostCode;
			parameters[21].Value = model.WebSite;
			parameters[22].Value = model.Notes;
			parameters[23].Value = model.DisplayOrder;
			parameters[24].Value = model.Scores;
			parameters[25].Value = model.LoginIp;
			parameters[26].Value = model.LastLoginTime;
			parameters[27].Value = model.LevelId;
			parameters[28].Value = model.LastLoginIp;
			parameters[29].Value = model.DefaultAddressId;
			parameters[30].Value = model.RecommenderId;
			parameters[31].Value = model.UserLoginType;
			parameters[32].Value = model.OpenId;
			parameters[33].Value = model.AccessToken;
			parameters[34].Value = model.RecommendUserId;
			parameters[35].Value = model.CompanyName;
			parameters[36].Value = model.IsSmsNotice;
			parameters[37].Value = model.IsEmailNotice;
			parameters[38].Value = model.IsWeiXinNotice;
			parameters[39].Value = model.LevelServiceTime;
			parameters[40].Value = model.YYZZ;
			parameters[41].Value = model.ZZDJZ;
			parameters[42].Value = model.SWDJZ;
			parameters[43].Value = model.SFZ1;
			parameters[44].Value = model.SFZ2;
			parameters[45].Value = model.CompanyAuditStatus;
			parameters[46].Value = model.CompanyAuditApplyTime;
			parameters[47].Value = model.CompanyAuditTime;
			parameters[48].Value = model.LoginTimes;
			parameters[49].Value = model.CreateByPlatform;
			parameters[50].Value = model.LastLoginPlatform;
			parameters[51].Value = model.ThirdLoginPartyName;
			parameters[52].Value = model.Sys_UserId;
			parameters[53].Value = model.CompanyId;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Delete(int Sys_UserId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Sys_Users ");
			strSql.Append(" where Sys_UserId=@Sys_UserId");
			SqlParameter[] parameters = {
					new SqlParameter("@Sys_UserId", SqlDbType.Int,4)
			};
			parameters[0].Value = Sys_UserId;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Delete(int CompanyId,int Sys_UserId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Sys_Users ");
			strSql.Append(" where CompanyId=@CompanyId and Sys_UserId=@Sys_UserId ");
			SqlParameter[] parameters = {
					new SqlParameter("@CompanyId", SqlDbType.Int,4),
					new SqlParameter("@Sys_UserId", SqlDbType.Int,4)			};
			parameters[0].Value = CompanyId;
			parameters[1].Value = Sys_UserId;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool DeleteList(string Sys_UserIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Sys_Users ");
			strSql.Append(" where Sys_UserId in ("+Sys_UserIdlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
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
		public GoBiding.Model.Sys_Users GetModel(int Sys_UserId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Sys_UserId,UserNickName,UserGUID,Password,UserName,Description,UserProfile,Gender,Address,ContacterName,TelephonePhone,TelephonePhone2,MobilePhone,MobilePhone2,Email,QQ,Fax,DistrictId,OnCreate,Deleted,ManufacturerGUID,PostCode,WebSite,Notes,DisplayOrder,Scores,LoginIp,LastLoginTime,LevelId,LastLoginIp,DefaultAddressId,RecommenderId,UserLoginType,OpenId,AccessToken,RecommendUserId,CompanyId,CompanyName,IsSmsNotice,IsEmailNotice,IsWeiXinNotice,LevelServiceTime,YYZZ,ZZDJZ,SWDJZ,SFZ1,SFZ2,CompanyAuditStatus,CompanyAuditApplyTime,CompanyAuditTime,LoginTimes,CreateByPlatform,LastLoginPlatform,ThirdLoginPartyName from Sys_Users ");
			strSql.Append(" where Sys_UserId=@Sys_UserId");
			SqlParameter[] parameters = {
					new SqlParameter("@Sys_UserId", SqlDbType.Int,4)
			};
			parameters[0].Value = Sys_UserId;

			GoBiding.Model.Sys_Users model=new GoBiding.Model.Sys_Users();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
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
		public GoBiding.Model.Sys_Users DataRowToModel(DataRow row)
		{
			GoBiding.Model.Sys_Users model=new GoBiding.Model.Sys_Users();
			if (row != null)
			{
				if(row["Sys_UserId"]!=null && row["Sys_UserId"].ToString()!="")
				{
					model.Sys_UserId=int.Parse(row["Sys_UserId"].ToString());
				}
				if(row["UserNickName"]!=null)
				{
					model.UserNickName=row["UserNickName"].ToString();
				}
				if(row["UserGUID"]!=null && row["UserGUID"].ToString()!="")
				{
					model.UserGUID= new Guid(row["UserGUID"].ToString());
				}
				if(row["Password"]!=null)
				{
					model.Password=row["Password"].ToString();
				}
				if(row["UserName"]!=null)
				{
					model.UserName=row["UserName"].ToString();
				}
				if(row["Description"]!=null)
				{
					model.Description=row["Description"].ToString();
				}
				if(row["UserProfile"]!=null)
				{
					model.UserProfile=row["UserProfile"].ToString();
				}
				if(row["Gender"]!=null && row["Gender"].ToString()!="")
				{
					model.Gender=int.Parse(row["Gender"].ToString());
				}
				if(row["Address"]!=null)
				{
					model.Address=row["Address"].ToString();
				}
				if(row["ContacterName"]!=null)
				{
					model.ContacterName=row["ContacterName"].ToString();
				}
				if(row["TelephonePhone"]!=null)
				{
					model.TelephonePhone=row["TelephonePhone"].ToString();
				}
				if(row["TelephonePhone2"]!=null)
				{
					model.TelephonePhone2=row["TelephonePhone2"].ToString();
				}
				if(row["MobilePhone"]!=null)
				{
					model.MobilePhone=row["MobilePhone"].ToString();
				}
				if(row["MobilePhone2"]!=null)
				{
					model.MobilePhone2=row["MobilePhone2"].ToString();
				}
				if(row["Email"]!=null)
				{
					model.Email=row["Email"].ToString();
				}
				if(row["QQ"]!=null)
				{
					model.QQ=row["QQ"].ToString();
				}
				if(row["Fax"]!=null)
				{
					model.Fax=row["Fax"].ToString();
				}
				if(row["DistrictId"]!=null && row["DistrictId"].ToString()!="")
				{
					model.DistrictId=int.Parse(row["DistrictId"].ToString());
				}
				if(row["OnCreate"]!=null && row["OnCreate"].ToString()!="")
				{
					model.OnCreate=DateTime.Parse(row["OnCreate"].ToString());
				}
				if(row["Deleted"]!=null && row["Deleted"].ToString()!="")
				{
					if((row["Deleted"].ToString()=="1")||(row["Deleted"].ToString().ToLower()=="true"))
					{
						model.Deleted=true;
					}
					else
					{
						model.Deleted=false;
					}
				}
				if(row["ManufacturerGUID"]!=null)
				{
					model.ManufacturerGUID=row["ManufacturerGUID"].ToString();
				}
				if(row["PostCode"]!=null)
				{
					model.PostCode=row["PostCode"].ToString();
				}
				if(row["WebSite"]!=null)
				{
					model.WebSite=row["WebSite"].ToString();
				}
				if(row["Notes"]!=null)
				{
					model.Notes=row["Notes"].ToString();
				}
				if(row["DisplayOrder"]!=null && row["DisplayOrder"].ToString()!="")
				{
					model.DisplayOrder=int.Parse(row["DisplayOrder"].ToString());
				}
				if(row["Scores"]!=null && row["Scores"].ToString()!="")
				{
					model.Scores=int.Parse(row["Scores"].ToString());
				}
				if(row["LoginIp"]!=null)
				{
					model.LoginIp=row["LoginIp"].ToString();
				}
				if(row["LastLoginTime"]!=null && row["LastLoginTime"].ToString()!="")
				{
					model.LastLoginTime=DateTime.Parse(row["LastLoginTime"].ToString());
				}
				if(row["LevelId"]!=null && row["LevelId"].ToString()!="")
				{
					model.LevelId=int.Parse(row["LevelId"].ToString());
				}
				if(row["LastLoginIp"]!=null)
				{
					model.LastLoginIp=row["LastLoginIp"].ToString();
				}
				if(row["DefaultAddressId"]!=null && row["DefaultAddressId"].ToString()!="")
				{
					model.DefaultAddressId=int.Parse(row["DefaultAddressId"].ToString());
				}
				if(row["RecommenderId"]!=null && row["RecommenderId"].ToString()!="")
				{
					model.RecommenderId=int.Parse(row["RecommenderId"].ToString());
				}
				if(row["UserLoginType"]!=null && row["UserLoginType"].ToString()!="")
				{
					model.UserLoginType=int.Parse(row["UserLoginType"].ToString());
				}
				if(row["OpenId"]!=null)
				{
					model.OpenId=row["OpenId"].ToString();
				}
				if(row["AccessToken"]!=null)
				{
					model.AccessToken=row["AccessToken"].ToString();
				}
				if(row["RecommendUserId"]!=null && row["RecommendUserId"].ToString()!="")
				{
					model.RecommendUserId=int.Parse(row["RecommendUserId"].ToString());
				}
				if(row["CompanyId"]!=null && row["CompanyId"].ToString()!="")
				{
					model.CompanyId=int.Parse(row["CompanyId"].ToString());
				}
				if(row["CompanyName"]!=null)
				{
					model.CompanyName=row["CompanyName"].ToString();
				}
				if(row["IsSmsNotice"]!=null && row["IsSmsNotice"].ToString()!="")
				{
					model.IsSmsNotice=int.Parse(row["IsSmsNotice"].ToString());
				}
				if(row["IsEmailNotice"]!=null && row["IsEmailNotice"].ToString()!="")
				{
					model.IsEmailNotice=int.Parse(row["IsEmailNotice"].ToString());
				}
				if(row["IsWeiXinNotice"]!=null && row["IsWeiXinNotice"].ToString()!="")
				{
					model.IsWeiXinNotice=int.Parse(row["IsWeiXinNotice"].ToString());
				}
				if(row["LevelServiceTime"]!=null && row["LevelServiceTime"].ToString()!="")
				{
					model.LevelServiceTime=DateTime.Parse(row["LevelServiceTime"].ToString());
				}
				if(row["YYZZ"]!=null)
				{
					model.YYZZ=row["YYZZ"].ToString();
				}
				if(row["ZZDJZ"]!=null)
				{
					model.ZZDJZ=row["ZZDJZ"].ToString();
				}
				if(row["SWDJZ"]!=null)
				{
					model.SWDJZ=row["SWDJZ"].ToString();
				}
				if(row["SFZ1"]!=null)
				{
					model.SFZ1=row["SFZ1"].ToString();
				}
				if(row["SFZ2"]!=null)
				{
					model.SFZ2=row["SFZ2"].ToString();
				}
				if(row["CompanyAuditStatus"]!=null && row["CompanyAuditStatus"].ToString()!="")
				{
					model.CompanyAuditStatus=int.Parse(row["CompanyAuditStatus"].ToString());
				}
				if(row["CompanyAuditApplyTime"]!=null && row["CompanyAuditApplyTime"].ToString()!="")
				{
					model.CompanyAuditApplyTime=DateTime.Parse(row["CompanyAuditApplyTime"].ToString());
				}
				if(row["CompanyAuditTime"]!=null && row["CompanyAuditTime"].ToString()!="")
				{
					model.CompanyAuditTime=DateTime.Parse(row["CompanyAuditTime"].ToString());
				}
				if(row["LoginTimes"]!=null && row["LoginTimes"].ToString()!="")
				{
					model.LoginTimes=int.Parse(row["LoginTimes"].ToString());
				}
				if(row["CreateByPlatform"]!=null)
				{
					model.CreateByPlatform=row["CreateByPlatform"].ToString();
				}
				if(row["LastLoginPlatform"]!=null)
				{
					model.LastLoginPlatform=row["LastLoginPlatform"].ToString();
				}
				if(row["ThirdLoginPartyName"]!=null)
				{
					model.ThirdLoginPartyName=row["ThirdLoginPartyName"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Sys_UserId,UserNickName,UserGUID,Password,UserName,Description,UserProfile,Gender,Address,ContacterName,TelephonePhone,TelephonePhone2,MobilePhone,MobilePhone2,Email,QQ,Fax,DistrictId,OnCreate,Deleted,ManufacturerGUID,PostCode,WebSite,Notes,DisplayOrder,Scores,LoginIp,LastLoginTime,LevelId,LastLoginIp,DefaultAddressId,RecommenderId,UserLoginType,OpenId,AccessToken,RecommendUserId,CompanyId,CompanyName,IsSmsNotice,IsEmailNotice,IsWeiXinNotice,LevelServiceTime,YYZZ,ZZDJZ,SWDJZ,SFZ1,SFZ2,CompanyAuditStatus,CompanyAuditApplyTime,CompanyAuditTime,LoginTimes,CreateByPlatform,LastLoginPlatform,ThirdLoginPartyName ");
			strSql.Append(" FROM Sys_Users ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" Sys_UserId,UserNickName,UserGUID,Password,UserName,Description,UserProfile,Gender,Address,ContacterName,TelephonePhone,TelephonePhone2,MobilePhone,MobilePhone2,Email,QQ,Fax,DistrictId,OnCreate,Deleted,ManufacturerGUID,PostCode,WebSite,Notes,DisplayOrder,Scores,LoginIp,LastLoginTime,LevelId,LastLoginIp,DefaultAddressId,RecommenderId,UserLoginType,OpenId,AccessToken,RecommendUserId,CompanyId,CompanyName,IsSmsNotice,IsEmailNotice,IsWeiXinNotice,LevelServiceTime,YYZZ,ZZDJZ,SWDJZ,SFZ1,SFZ2,CompanyAuditStatus,CompanyAuditApplyTime,CompanyAuditTime,LoginTimes,CreateByPlatform,LastLoginPlatform,ThirdLoginPartyName ");
			strSql.Append(" FROM Sys_Users ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM Sys_Users ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.Sys_UserId desc");
			}
			strSql.Append(")AS Row, T.*  from Sys_Users T ");
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
			parameters[0].Value = "Sys_Users";
			parameters[1].Value = "Sys_UserId";
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


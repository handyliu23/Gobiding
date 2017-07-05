using System;
namespace Mercury.Model
{
    /// <summary>
    /// Sys_Users:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Sys_Users
    {
        public Sys_Users()
        { }
        #region Model
        private int _sys_userid;
        private string _usernickname;
        private Guid _userguid;
        private string _password;
        private string _username;
        private string _description;
        private string _userprofile;
        private int? _gender;
        private string _address;
        private string _contactername;
        private string _telephonephone;
        private string _telephonephone2;
        private string _mobilephone;
        private string _mobilephone2;
        private string _email;
        private string _qq;
        private string _fax;
        private int? _districtid;
        private DateTime? _oncreate;
        private bool _deleted;
        private string _manufacturerguid;
        private string _postcode;
        private string _website;
        private string _notes;
        private int? _displayorder;
        private int? _scores;
        private string _loginip;
        private DateTime? _lastlogintime;
        private int? _levelid;
        private string _lastloginip;
        private int? _defaultaddressid;
        private int? _recommenderid;
        private int? _userlogintype;
        private string _openid;
        private string _accesstoken;
        private int? _recommenduserid;
        private int? _companyid;
        private string _companyname;
        private int? _issmsnotice;
        private int? _isemailnotice;
        private int? _isweixinnotice;
        private DateTime? _levelservicetime;
        private string _createByPlatform;
        /// <summary>
        /// 
        /// </summary>
        public int Sys_UserId
        {
            set { _sys_userid = value; }
            get { return _sys_userid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserNickName
        {
            set { _usernickname = value; }
            get { return _usernickname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid UserGUID
        {
            set { _userguid = value; }
            get { return _userguid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Password
        {
            set { _password = value; }
            get { return _password; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Description
        {
            set { _description = value; }
            get { return _description; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserProfile
        {
            set { _userprofile = value; }
            get { return _userprofile; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Gender
        {
            set { _gender = value; }
            get { return _gender; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Address
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ContacterName
        {
            set { _contactername = value; }
            get { return _contactername; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TelephonePhone
        {
            set { _telephonephone = value; }
            get { return _telephonephone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TelephonePhone2
        {
            set { _telephonephone2 = value; }
            get { return _telephonephone2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MobilePhone
        {
            set { _mobilephone = value; }
            get { return _mobilephone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MobilePhone2
        {
            set { _mobilephone2 = value; }
            get { return _mobilephone2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string QQ
        {
            set { _qq = value; }
            get { return _qq; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Fax
        {
            set { _fax = value; }
            get { return _fax; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? DistrictId
        {
            set { _districtid = value; }
            get { return _districtid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? OnCreate
        {
            set { _oncreate = value; }
            get { return _oncreate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool Deleted
        {
            set { _deleted = value; }
            get { return _deleted; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ManufacturerGUID
        {
            set { _manufacturerguid = value; }
            get { return _manufacturerguid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PostCode
        {
            set { _postcode = value; }
            get { return _postcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string WebSite
        {
            set { _website = value; }
            get { return _website; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Notes
        {
            set { _notes = value; }
            get { return _notes; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? DisplayOrder
        {
            set { _displayorder = value; }
            get { return _displayorder; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Scores
        {
            set { _scores = value; }
            get { return _scores; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LoginIp
        {
            set { _loginip = value; }
            get { return _loginip; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? LastLoginTime
        {
            set { _lastlogintime = value; }
            get { return _lastlogintime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? LevelId
        {
            set { _levelid = value; }
            get { return _levelid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LastLoginIp
        {
            set { _lastloginip = value; }
            get { return _lastloginip; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? DefaultAddressId
        {
            set { _defaultaddressid = value; }
            get { return _defaultaddressid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? RecommenderId
        {
            set { _recommenderid = value; }
            get { return _recommenderid; }
        }
        /// <summary>
        /// 1:QQ,2:新浪微博
        /// </summary>
        public int? UserLoginType
        {
            set { _userlogintype = value; }
            get { return _userlogintype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OpenId
        {
            set { _openid = value; }
            get { return _openid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AccessToken
        {
            set { _accesstoken = value; }
            get { return _accesstoken; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? RecommendUserId
        {
            set { _recommenduserid = value; }
            get { return _recommenduserid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? CompanyId
        {
            set { _companyid = value; }
            get { return _companyid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CompanyName
        {
            set { _companyname = value; }
            get { return _companyname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? IsSmsNotice
        {
            set { _issmsnotice = value; }
            get { return _issmsnotice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? IsEmailNotice
        {
            set { _isemailnotice = value; }
            get { return _isemailnotice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? IsWeiXinNotice
        {
            set { _isweixinnotice = value; }
            get { return _isweixinnotice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? LevelServiceTime
        {
            set { _levelservicetime = value; }
            get { return _levelservicetime; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string CreateByPlatform
        {
            set { _createByPlatform = value; }
            get { return _createByPlatform; }
        }

        #endregion Model

    }
}


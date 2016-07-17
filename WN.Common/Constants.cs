using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WN.Common
{
    public class Constants
    {
        //Defaul URL
        public const string NAVIGATE_DEFAULT_PAGE = "Default.aspx?ctr=";

        //User Control Dir
        public const string USER_CONTROL_DIR = "uc/{0}.ascx";

        //Server Respond
        public const string ERR_CODE = "ERR_CODE";

        //Upload Dir
        public const string BANNER_DIR = "ul/bn/";
        public const string PRODUCT_DIR = "ul/pro/";
        public const string MANUFACTURER_DIR = "ul/mf/";

        //Working Result
        public const string WR_ERROR = "ERROR";
        public const string WR_SUCCESS = "SUCCESS";
        public const string WR_EXIST_DATA = "EXIST_DATA";
        public const string WR_DUPLICATE_DATA = "DUPLICATE_DATA";
        public const string WR_NOT_EXIST_DATA = "NOT_EXIST_DATA";
        public const string WR_CONSTRAINT_DATA = "CONSTRAINT_DATA";
        
        //Working Status
        public const string WS_QUERY = "QUERY";
        public const string WS_DELETE = "DELETE";
        public const string WS_UPDATE = "UPDATE";
        public const string WS_INSERT = "INSERT";

        //Other Working Status
        public const string WS_LOGIN = "ADMIN_LOGIN";
        public const string WS_SEARCH_PRODUCT = "SEARCH_PRODUCT";
        public const string WS_AC_SEARCH_PRODUCT = "AC_SEARCH_PRODUCT";
        public const string WS_RETRIEVE_CONTACT_FOOTER = "RETRIEVE_CONTACT_FOOTER";
        public const string WS_RETRIEVE_CONTACT_PRODUCT_DETAIL = "RETRIEVE_CONTACT_PRODUCT_DETAIL";
        public const string WS_UPDATE_CONTACT_FOOTER = "UPDATE_CONTACT_FOOTER";
        public const string WS_UPDATE_CONTACT_PRODUCT_DETAIL = "UPDATE_CONTACT_PRODUCT_DETAIL";
        public const string WS_RETRIEVE_PRODUCT_BY_NAME = "RETRIEVE PRODUCT_BY_NAME";
        public const string WS_REMOVE_PRODUCT_FROM_HOME_PAGE = "REMOVE_PRODUCT_FROM_HOME_PAGE";
        public const string WS_RETRIEVE_PRODUCT_HOME_PAGE = "RETRIEVE_PRODUCT_HOME_PAGE_ITEM";
        public const string WS_AC_RETRIEVE_PRODUCT_HOME_PAGE = "AC_RETRIEVE_PRODUCT_HOME_PAGE_ITEM";
        public const string WS_RETRIEVE_PRODUCT_BY_CATEGORY = "RETRIEVE_PRODUCT_BY_CATEGORY";
        public const string WS_RETRIEVE_PRODUCT_DETAIL = "RETRIEVE_PRODUCT_DETAIL";
        public const string WS_RETRIEVE_PRODUCT_BY_MANUFACTURER = "RETRIEVE_PRODUCT_BY_MANUFACTURER";
        public const string WS_RETRIEVE_PRODUCT_SORT_BY_PRICE_ASC = "RETRIEVE_PRODUCT_SORT_BY_PRICE_ASC";

        public const string WS_ALSO_PURCHASED_PRODUCT = "ALSO_PURCHASED_PRODUCT";
        public const string WS_RETRIEVE_PRODUCT_BY_GENDER = "RETRIEVE_PRODUCT_RETRIEVE_BY_GENDER";
        public const string WS_RETRIEVE_PRODUCT_RETRIEVE_BY_CAT_L1 = "RETRIEVE_PRODUCT_RETRIEVE_BY_CAT_L1";
        public const string WS_RETRIEVE_PRODUCT_RETRIEVE_BY_CAT_L2 = "RETRIEVE_PRODUCT_RETRIEVE_BY_CAT_L2";
        public const string WS_RETRIEVE_CATEGORY_LEVEL2_BY_CAT_L1 = "RETRIEVE_CATEGORY_LEVEL2_BY_CAT_L1";
        //Return Value
        public const string DATATABLE = "DATATABLE";
        public const string DATASET = "DATASET";
        public const string STRING = "STRING";

        //Repeater Item Command
        public const string DELETE_ITEM = "DELETE_ITEM";
        public const string UPDATE_ITEM = "UPDATE_ITEM";

        //Select All
        public const string RETRIEVE_ALL = "ALL";
        

    }
}
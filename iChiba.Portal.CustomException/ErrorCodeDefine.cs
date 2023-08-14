namespace iChiba.Portal.CustomException
{
    public class ErrorCodeDefine : iChibaShopping.Core.CustomException.ErrorCodeDefine
    {
        public const string UN_AUTHORIZED = "Unauthorized";
        public const string UNKNOW_ERROR = "UnknowError";
        public const string NOT_FOUND = "NotFound";

        public const string ERROR_VERIFY_PHONE = "ErrorVerifyPhone";
        public const string BID_FAIL = "BID_FAIL";
        public const string REMOVE_BID_END_NOT_WIN_FAIL = "REMOVE_BID_END_NOT_WIN_FAIL";
        public const string ADVISORY_ADD_FAIL = "ADVISORY_ADD_FAIL";
        public const string CONTACT_ADD_FAIL = "CONTACT_ADD_FAIL";


        #region Shopping cart

        public const string SHOPPING_CART_WEUGHT_MUST_GT_OR_EQUAL_0 = "SHOPPING_CART_WEUGHT_MUST_GT_OR_EQUAL_0";
        public const string SHOPPING_CART_WIDTH_MUST_GT_OR_EQUAL_0 = "SHOPPING_CART_WIDTH_MUST_GT_OR_EQUAL_0";
        public const string SHOPPING_CART_HEIGHT_MUST_GT_OR_EQUAL_0 = "SHOPPING_CART_HEIGHT_MUST_GT_OR_EQUAL_0";
        public const string SHOPPING_CART_LENGTH_MUST_GT_OR_EQUAL_0 = "SHOPPING_CART_LENGTH_MUST_GT_OR_EQUAL_0";
        public const string SHOPPING_CART_PRICE_MUST_GT_0 = "SHOPPING_CART_PRICE_MUST_GT_0";
        public const string SHOPPING_CART_NOT_EXISTING = "SHOPPING_CART_NOT_EXISTING";
        public const string SHOPPING_CART_REF_REQUIRED = "SHOPPING_CART_REF_REQUIRED";
        public const string SHOPPING_CART_REF_TYPE_REQUIRED = "SHOPPING_CART_REF_TYPE_REQUIRED";
        public const string SHOPPING_CART_NOT_CONTAINS_PRODUCT = "SHOPPING_CART_NOT_CONTAINS_PRODUCT";

        #endregion Shopping cart


        public const string THERE_WAS_AN_ERROR_DURING_EXECUTION = "THERE_WAS_AN_ERROR_DURING_EXECUTION";
    }
}

namespace HR.Data.AppMetaData
{
    public static partial class Router
    {
        public const string SignleRoute = "/{id}";

        public const string root = "Api";
        public const string version = "V1";
        public const string Rule = root + "/" + version + "/";


        #region Employee
        public static class EmployeeRouting
        {
            public const string Prefix = Rule + "Employee";
            public const string List = Prefix + "/List";
            public const string GetByID = Prefix + SignleRoute;
            public const string Create = Prefix + "/Create";
            public const string Edit = Prefix + "/Edit";
            public const string Delete = Prefix + SignleRoute;
            public const string Paginated = Prefix + "/Paginated";

        }

        #endregion


        #region Adress
        #region Country  
        public static class CountryRouting
        {
            public const string Prefix = Rule + "Country";
            public const string List = Prefix + "/List";
            public const string GetByID = Prefix + SignleRoute;
            public const string Create = Prefix + "/Create";
            public const string Edit = Prefix + "/Edit";
            public const string Delete = Prefix + SignleRoute;
            public const string Paginated = Prefix + "/Paginated";

        }
        #endregion
        #region City
        public static class CityRouting
        {
            public const string Prefix = Rule + "City";
            public const string List = Prefix + "/List";
            public const string GetByID = Prefix + SignleRoute;
            public const string Create = Prefix + "/Create";
            public const string Edit = Prefix + "/Edit";
            public const string Delete = Prefix + SignleRoute;
            public const string Paginated = Prefix + "/Paginated";

        }
        #endregion
        #region District
        public static class DistrictRouting
        {
            public const string Prefix = Rule + "District";
            public const string List = Prefix + "/List";
            public const string GetByID = Prefix + SignleRoute;
            public const string Create = Prefix + "/Create";
            public const string Edit = Prefix + "/Edit";
            public const string Delete = Prefix + SignleRoute;
            public const string Paginated = Prefix + "/Paginated";

        }
        #endregion
        #endregion


        public static class DepartmentRouting
        {
            public const string Prefix = Rule + "Department";
            public const string GetByID = Prefix + "/Id";

        }
    }
}

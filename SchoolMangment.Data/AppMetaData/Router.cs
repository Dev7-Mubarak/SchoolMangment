﻿namespace SchoolMangment.Data.AppMetaData
{
    public static class Router
    {
        //public const string SingleRoute = "{}"

        public const string root = "Api";
        public const string version = "V1";
        public const string Rule = $"{root}/{version}/";

        public static class StudentRouting
        {
            public const string Prefix = Rule + "Student/";
            public const string List = Prefix + "List";
            public const string Paginted = Prefix + "Paginted";
            public const string GetById = Prefix + "{Id}";
            public const string Create = Prefix + "Create";
            public const string Update = Prefix + "Update";
            public const string Delete = Prefix + "{Id}";
        }

        public static class DepartmentRouting
        {
            public const string Prefix = Rule + "Department/";
            public const string List = Prefix + "List";
            public const string Paginted = Prefix + "Paginted";
            public const string GetById = Prefix + "{Id}";
            public const string Create = Prefix + "Create";
            public const string Update = Prefix + "Update";
            public const string Delete = Prefix + "{Id}";
        }

        public static class UsersRouting
        {
            public const string Prefix = Rule + "User/";
            public const string List = Prefix + "List";
            public const string Paginted = Prefix + "Paginted";
            public const string GetById = Prefix + "{Id}";
            public const string Create = Prefix + "Create";
            public const string Update = Prefix + "Update";
            public const string Delete = Prefix + "{Id}";
        }

        public static class Authenication
        {
            public const string Prefix = Rule + "Authenication/";
            public const string List = Prefix + "List";
            public const string Paginted = Prefix + "Paginted";
            public const string GetById = Prefix + "{Id}";
            public const string Create = Prefix + "Create";
            public const string Update = Prefix + "Update";
            public const string Delete = Prefix + "{Id}";
        }
    }
}

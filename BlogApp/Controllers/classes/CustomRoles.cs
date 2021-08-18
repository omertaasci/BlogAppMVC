using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogApp.Controllers.classes
{
    public class CustomRoles
    {
        public const string Admin = "A";
        public const string Editor = "B";
        public const string User = "C";
        public const string Admin_Editor = Admin + "," + Editor;
    }
}
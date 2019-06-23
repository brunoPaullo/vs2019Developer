using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace App.UI.WebForm.Common
{
    public class Helpers
    {
        public static void ConfigureDropDown(DropDownList cbo, string textField, string valueField, object data)
        {
            cbo.DataValueField = valueField;
            cbo.DataTextField = textField;
            cbo.DataSource = data;
            cbo.DataBind();
        }
    }
}
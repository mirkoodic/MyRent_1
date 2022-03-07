using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyRentApp_1
{
    public static  class UserHelperMethods
    {
        public static string GetSomeStar(object i)
        {
            int s = Convert.ToInt32(i); ;
            string star = "⭐";
            string html = "";

            for (int x = 0; x < s; x++)
            {
                html = html + star;
            }

            return html.ToString();
        }
    }

}
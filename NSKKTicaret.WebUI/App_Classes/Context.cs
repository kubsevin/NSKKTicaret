using NSKKTicaret.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NSKKTicaret.WebUI.App_Classes
{
    public class Context
    {
        private static NSKKTicaretModel connection;
        public static NSKKTicaretModel Connection
        {
            get
            {
                if (connection == null)
                    connection = new NSKKTicaretModel();
                return connection;
            }
            set
            {
                connection = value;
            }
        }
    }
}
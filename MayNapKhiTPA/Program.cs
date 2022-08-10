using MayNapKhiTPA.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using MayNapKhiTPA.Models;


namespace MayNapKhiTPA
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormLogin());

            //test update result
            try
            {
                ResultBusiness.UpdateResult(1);
                ResultBusiness.UpdateResult(2);
                ResultBusiness.UpdateResult(3);
                ResultBusiness.UpdateResult(4);
                ResultBusiness.UpdateResult(5);
                ResultBusiness.UpdateResult(6);
                ResultBusiness.UpdateResult(7);


            }
            catch
            {
                //none
            }



            if (Common.USERSESSION != null)
            {
                Application.Run(new FormMain());
            }

        }
    }
}

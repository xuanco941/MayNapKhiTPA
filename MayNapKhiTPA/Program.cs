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
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(Common.LicenseSyncfusion);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormLogin());

            //test update result
            try
            {
                ResultBusiness.UpdateResult(1, true);
                ResultBusiness.UpdateResult(2, true);
                ResultBusiness.UpdateResult(3, true);
                ResultBusiness.UpdateResult(4, true);
                ResultBusiness.UpdateResult(5, true);
                ResultBusiness.UpdateResult(6, true);
                ResultBusiness.UpdateResult(7, true);
                ResultBusiness.UpdateResult(8, true);


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

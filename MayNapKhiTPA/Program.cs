﻿using MayNapKhiTPA.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            FormLogin formLogin = new FormLogin();
            Application.Run(formLogin);

            if (Common.IsLoggedIn)
            {
                Application.Run(new FormMain());
            }

            //FormTestControl formTestControl = new FormTestControl();
            //Application.Run(formTestControl);
        }
    }
}

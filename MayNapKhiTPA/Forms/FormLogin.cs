﻿using MayNapKhiTPA.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MayNapKhiTPA.Models;

namespace MayNapKhiTPA
{
    public partial class FormLogin : Form
    {

        public FormLogin()
        {
            InitializeComponent();
            this.ActiveControl = textBoxTaiKhoan;
        }

        private void LoginActive()
        {
            string TaiKhoan = textBoxTaiKhoan.Texts.Trim();
            string MatKhau = textBoxMatKhau.Texts.Trim();
            if (String.IsNullOrEmpty(TaiKhoan) == true && String.IsNullOrEmpty(MatKhau) == true)
            {
                MessageBox.Show("Không để trống ô tài khoản và mật khẩu.", "Lỗi Cú Pháp", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    if (UserBusiness.AuthLogin(TaiKhoan, MatKhau) == true)
                    {
                        this.Close();
                        Common.UserNameCurrent = TaiKhoan;
                        Common.IsLoggedIn = true;

                    }
                    else
                    {
                        MessageBox.Show("Sai tài khoản hoặc mật khẩu.", "Lỗi Đăng Nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch
                {
                    MessageBox.Show("Lỗi server", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        }

        private void buttonDangNhap_Click(object sender, EventArgs e)
        {
            LoginActive();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBoxTaiKhoan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoginActive();
            }
        }
    }
}

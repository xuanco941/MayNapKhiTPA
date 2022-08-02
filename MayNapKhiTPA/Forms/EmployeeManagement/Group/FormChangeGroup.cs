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

namespace MayNapKhiTPA.Forms
{
    public partial class FormChangeGroup : Form
    {
        // tạo 1 delegate có 2 biến để call alert ở main
        public delegate void ChangeData(string msg, FormAlert.enmType enmType);
        // Create instance (null)
        public ChangeData changeData;
        public FormChangeGroup()
        {
            InitializeComponent();
            LoadComboBox();
        }

        private void LoadComboBox()
        {
            //lấy tất cả tên các quyền cho vào combobox
            var listGroups = GroupBusiness.GetAllGroups();
            var listNameGroup = from groupVar in listGroups select groupVar.Name;
            comboBoxSelectGroup.DataSource = listNameGroup.ToList();
        }

        private void comboBoxSelectGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            //vô hiệu hóa nút xóa khi đây là quyền admin mặc định
            if (comboBoxSelectGroup.Text == "Quyền Admin")
            {
                buttonUpdateGroup.Enabled = false;
                buttonDeleteGroup.Enabled = false;
            }
            else
            {
                buttonUpdateGroup.Enabled = true;
                buttonDeleteGroup.Enabled = true;
            }

            // lấy ra thông tin group có name group là text trên combobox
            var group = GroupBusiness.GetGroupFromName(comboBoxSelectGroup.Text);

            checkBoxIsManagementUser.Checked = group.IsManagementUser;
            checkBoxIsManagementGroup.Checked = group.IsManagementGroup;
            checkBoxIsControlMachine.Checked = group.IsControlMachine;
            checkBoxIsSettingMachine.Checked = group.IsSettingMachine;
            checkBoxIsSettingShift.Checked = group.IsSettingShift;
            checkBoxIsSettingTemplateMachine.Checked = group.IsSettingTemplateMachine;
            checkBoxIsViewResult.Checked = group.IsViewResult;
            checkBoxIsViewActivity.Checked = group.IsViewActivity;
            checkBoxIsDeleteResult.Checked = group.IsDeleteResult;
            checkBoxIsDeleteActivity.Checked = group.IsDeleteActivity;
        }

        private void buttonUpdateGroup_Click(object sender, EventArgs e)
        {
            Group group = new Group();
            group.Name = comboBoxSelectGroup.Text;
            group.IsManagementUser = checkBoxIsManagementUser.Checked;
            group.IsManagementGroup = checkBoxIsManagementGroup.Checked;
            group.IsControlMachine = checkBoxIsControlMachine.Checked;
            group.IsSettingMachine = checkBoxIsSettingMachine.Checked;
            group.IsSettingShift = checkBoxIsSettingShift.Checked;
            group.IsSettingTemplateMachine = checkBoxIsSettingTemplateMachine.Checked;
            group.IsViewResult = checkBoxIsViewResult.Checked;
            group.IsViewActivity = checkBoxIsViewActivity.Checked;
            group.IsDeleteResult = checkBoxIsDeleteResult.Checked;
            group.IsDeleteActivity = checkBoxIsDeleteActivity.Checked;

            if (String.IsNullOrEmpty(comboBoxSelectGroup.Text))
            {
                MessageBox.Show("Vui lòng điền đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    int ID_Group = GroupBusiness.GetGroupFromName(group.Name).ID_Group;
                    group.ID_Group = ID_Group;
                    GroupBusiness.UpdateGroup(group.ID_Group, group.Name, group.IsManagementUser, group.IsManagementGroup, group.IsControlMachine,
                        group.IsSettingMachine, group.IsSettingShift, group.IsSettingTemplateMachine, group.IsViewResult, group.IsViewActivity, group.IsDeleteResult, group.IsDeleteActivity);
                    //nếu group là group của user current thì thay đổi groupsession
                    if (group.Name == Common.GROUPSESSION.Name)
                    {
                        Common.GROUPSESSION = group;
                    }
                    //thông báo
                    changeData?.Invoke("Cập nhật thành công.", FormAlert.enmType.Success);
                }
                catch (Exception ex)
                {
                    changeData?.Invoke(ex.Message, FormAlert.enmType.Error);
                }

            }

            LoadComboBox();
            comboBoxSelectGroup.Text = group.Name;
        }

        private void buttonDeleteGroup_Click(object sender, EventArgs e)
        {
            string nameGroup = comboBoxSelectGroup.Text;

            DialogResult dialogResult = MessageBox.Show($"Bạn có chắc muốn xóa nhóm quyền {nameGroup}", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                DialogResult dialogResult2 = MessageBox.Show($"Xác nhận xóa đồng nghĩa với việc xóa mọi tài khoản trong nhóm quyền này.", "Thông báo quan trọng", MessageBoxButtons.YesNo, MessageBoxIcon.Error);

                if (dialogResult2 == DialogResult.Yes)
                {
                    //Xóa nhóm quyền, xóa xong sẽ load lại danh sách group của form
                    try
                    {
                        int id_group = GroupBusiness.GetGroupFromName(nameGroup).ID_Group;
                        GroupBusiness.DeleteGroup(id_group);
                        changeData?.Invoke($"Xóa thành công nhóm quyền {nameGroup}.", FormAlert.enmType.Success);
                    }
                    catch
                    {
                        changeData?.Invoke($"Gặp lỗi, xóa thất bại.", FormAlert.enmType.Error);
                    }
                    LoadComboBox();
                }

            }
        }
    }
}

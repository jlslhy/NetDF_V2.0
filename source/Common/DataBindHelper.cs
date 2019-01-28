using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Collections;
using System.Web.UI.WebControls;
using System.ComponentModel;
namespace Common
{
    /// <summary>
    /// 提供对页面快速绑定数据的操作
    /// </summary>
    public class DataBindHelper
    {

        #region DropDownList数据绑定&选择项绑定

        /// <summary>
        /// 邦定数据到下拉框
        /// </summary>
        /// <param name="pDrpList">下拉框对象</param>
        /// <param name="pDateSource">下拉框中数据源</param>
        /// <param name="pIsAddSel">是否添加表头文字</param>
        /// <param name="pStrTextName">下拉框中显示的文字在数据库中所属的字段名</param>
        /// <param name="pStrValue">下拉框中选择的值在数据库中所属的字段名</param>
        /// <param name="pStrDefaultValue">下拉框默认选择的项</param>
        /// <returns></returns>
        public static bool DropDownListDataBind(DropDownList pDrpList, IList pDateSource, bool pIsAddSel, string pStrTextName, string pStrValue, string pStrDefaultValue)
        {
            pDrpList.DataSource = pDateSource;
            pDrpList.DataTextField = pStrTextName;
            pDrpList.DataValueField = pStrValue;
            pDrpList.DataBind();

            if (pIsAddSel)
            {
                ListItem ColumnItem = new ListItem();
                ColumnItem.Value = "-1";
                ColumnItem.Text = "---------请选择--------";
                pDrpList.Items.Insert(0, ColumnItem);
            }

            //选定默认项
            if (pStrDefaultValue != "" && pStrDefaultValue != null)
            {
                for (int i = 0; i < pDrpList.Items.Count; i++)
                {
                    if (pDrpList.Items[i].Value == pStrDefaultValue)
                    {
                        pDrpList.SelectedIndex = i;
                        return true;
                    }
                }
            }
            return true;
        }
        #endregion


        #region 指定选择（DropdownList）
        /// <summary>
        /// 选定DropDownList选项
        /// </summary>
        /// <param name="pDrpList"></param>
        /// <param name="pSelValue"></param>
        public static void SelectedDropDownList(DropDownList pDrpList, string pSelValue)
        {
            if (pDrpList.Items.Count < 1)
                return;

            for (int i = 0; i < pDrpList.Items.Count; i++)
            {
                pDrpList.Items[i].Selected = false;
                if (pDrpList.Items[i].Value == pSelValue)
                {
                    pDrpList.Items[i].Selected = true;
                }
            }
        }

        #endregion

        #region 根据枚举的类型来邦定下拉列表
        /// <summary>
        /// 根据枚举的类型来邦定下拉列表
        /// </summary>
        /// <param name="pEnumType">枚举的类型</param>
        /// <param name="pDrpList">下拉列表控件名</param>
        public static void BindDropDownListUseEnum(Type pEnumType, DropDownList pDrpList)
        {
            if (pEnumType.IsEnum != true)
            {
                throw new InvalidOperationException();
            }
            Type typeDescription = typeof(DescriptionAttribute);
            System.Reflection.FieldInfo[] fields = pEnumType.GetFields();
            int _value = 0;
            string _text = string.Empty;
            //pDrpList.Items.Clear();
            foreach (System.Reflection.FieldInfo field in fields)
            {
                if (field.FieldType.IsEnum == true)
                {
                    _value = (int)pEnumType.InvokeMember(field.Name, System.Reflection.BindingFlags.GetField, null, null, null);
                    object[] arr = field.GetCustomAttributes(typeDescription, true);
                    if (arr.Length > 0)
                    {
                        DescriptionAttribute aa = (DescriptionAttribute)arr[0];
                        _text = aa.Description;
                    }
                    else
                    {
                        _text = field.Name;
                    }
                    ListItem item = new ListItem(_text, _value.ToString());
                    pDrpList.Items.Add(item);
                }
            }
        }

        /// <summary>
        /// 根据枚举的类型来邦定下拉列表
        /// </summary>
        /// <param name="pEnumType">枚举的类型</param>
        /// <param name="pDrpList">下拉列表控件名</param>
        /// <param name="pIsAddSel">是否添加表头文字</param>
        public static void BindDropDownListUseEnum(Type pEnumType, DropDownList pDrpList, bool pIsAddSel)
        {
            pDrpList.Items.Clear();
            if (pEnumType.IsEnum != true)
            {
                throw new InvalidOperationException();
            }
            Type typeDescription = typeof(DescriptionAttribute);
            System.Reflection.FieldInfo[] fields = pEnumType.GetFields();
            int _value = 0;
            string _text = string.Empty;

            if (pIsAddSel)
            {
                ListItem ColumnItem = new ListItem();
                ColumnItem.Value = "-1";
                ColumnItem.Text = "---------请选择--------";
                pDrpList.Items.Insert(0, ColumnItem);
            }

            foreach (System.Reflection.FieldInfo field in fields)
            {
                if (field.FieldType.IsEnum == true)
                {
                    _value = (int)pEnumType.InvokeMember(field.Name, System.Reflection.BindingFlags.GetField, null, null, null);
                    object[] arr = field.GetCustomAttributes(typeDescription, true);
                    if (arr.Length > 0)
                    {
                        DescriptionAttribute aa = (DescriptionAttribute)arr[0];
                        _text = aa.Description;
                    }
                    else
                    {
                        _text = field.Name;
                    }
                    ListItem item = new ListItem(_text, _value.ToString());
                    pDrpList.Items.Add(item);
                }
            }
        }
        #endregion

        #region 根据枚举的值得到枚举字段
        /// <summary>
        /// 根据枚举的值得到枚举字段
        /// </summary>
        /// <param name="pEnumType">枚举的类型</param>
        /// <param name="pValue">枚举的值</param>
        public static string GetEnumDescription(Type pEnumType, int pValue)
        {
            if (pEnumType.IsEnum != true)
            {
                throw new InvalidOperationException();
            }
            Type typeDescription = typeof(DescriptionAttribute);
            System.Reflection.FieldInfo[] fields = pEnumType.GetFields();
            string _text = string.Empty;
            foreach (System.Reflection.FieldInfo field in fields)
            {
                if (field.FieldType.IsEnum == true)
                {
                    if ((int)pEnumType.InvokeMember(field.Name, System.Reflection.BindingFlags.GetField, null, null, null) == pValue)
                    {
                        object[] arr = field.GetCustomAttributes(typeDescription, true);
                        if (arr.Length > 0)
                        {
                            DescriptionAttribute aa = (DescriptionAttribute)arr[0];
                            _text = aa.Description;
                        }
                        else
                        {
                            _text = field.Name;
                        }
                        break;
                    }
                }
            }
            return _text;
        }
        #endregion
    }
}

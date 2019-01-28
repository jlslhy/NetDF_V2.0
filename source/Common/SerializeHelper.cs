using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Xml;
using System.Reflection;

namespace Common
{
    /// <summary>
    /// 提供对象序列化与反序列化操作
    /// </summary>
    public class SerializeHelper
    {
        #region 序列化与反序列化
        /// <summary>
        /// 序列化对象
        /// </summary>
        /// <param name="pObj">要序列化的对象</param>
        /// <returns>返回二进制</returns>
        public static byte[] SerializeModel(Object pObj)
        {
            if (pObj != null)
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                MemoryStream ms = new MemoryStream();
                byte[] b;
                binaryFormatter.Serialize(ms, pObj);
                ms.Position = 0;
                b = new Byte[ms.Length];
                ms.Read(b, 0, b.Length);
                ms.Close();
                return b;
            }
            else
                return new byte[0];
        }

        /// <summary>
        /// 反序列化对象
        /// </summary>
        /// <param name="pByte">要反序列化的二进制</param>
        /// <param name="pSampleModel">Model的实体示例，New一个出来即可(默认返回对象)</param>
        /// <returns>返回对象</returns>
        public static object DeserializeModel(byte[] pByte, object pSampleModel)
        {
            if (pByte == null || pByte.Length == 0)
                return pSampleModel;
            else
            {
                object result = new object();
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                MemoryStream ms = new MemoryStream();
                try
                {
                    ms.Write(pByte, 0, pByte.Length);
                    ms.Position = 0;
                    result = binaryFormatter.Deserialize(ms);
                    ms.Close();
                }
                catch { }
                return result;
            }
        }
        #endregion

        #region Model与XML互相转换
        /// <summary>
        /// Model转化为XML的方法
        /// </summary>
        /// <param name="pModel">要转化的Model</param>
        /// <returns></returns>
        public static string ModelToXML(object pModel)
        {
            XmlDocument xmldoc = new XmlDocument();
            XmlElement ModelNode = xmldoc.CreateElement("Model");
            xmldoc.AppendChild(ModelNode);

            if (pModel != null)
            {
                foreach (PropertyInfo property in pModel.GetType().GetProperties())
                {
                    XmlElement attribute = xmldoc.CreateElement(property.Name);
                    if (property.GetValue(pModel, null) != null)
                        attribute.InnerText = property.GetValue(pModel, null).ToString();
                    else
                        attribute.InnerText = "[Null]";
                    ModelNode.AppendChild(attribute);
                }
            }

            return xmldoc.OuterXml;
        }

        /// <summary>
        /// XML转化为pModel的方法
        /// </summary>
        /// <param name="pXML">要转化的XML</param>
        /// <param name="pSampleModel">Model的实体示例，New一个出来即可</param>
        /// <returns></returns>
        public static object XMLToModel(string pXML, object pSampleModel)
        {
            if (string.IsNullOrEmpty(pXML))
                return pSampleModel;
            else
            {
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.LoadXml(pXML);

                XmlNodeList attributes = xmldoc.SelectSingleNode("Model").ChildNodes;
                foreach (XmlNode node in attributes)
                {
                    foreach (PropertyInfo property in pSampleModel.GetType().GetProperties())
                    {
                        if (node.Name == property.Name)
                        {
                            if (node.InnerText != "[Null]")
                            {
                                if (property.PropertyType == typeof(System.Guid))
                                    property.SetValue(pSampleModel, new Guid(node.InnerText), null);
                                else
                                    property.SetValue(pSampleModel, Convert.ChangeType(node.InnerText, property.PropertyType), null);
                            }
                            else
                                property.SetValue(pSampleModel, null, null);
                        }
                    }
                }
                return pSampleModel;
            }
        }
        #endregion
    }
}

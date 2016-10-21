/* ==============================================================================
 * 类名称:AjaxResult
 * 功能描述:Ajax的返回结果类
 * 创建人:王涛
 * 创建时间：2013/9/7 15:53:31
 * 创建人联系方式：wwwtao2003@163.com
 * 修改人:
 * 修改时间:
 * 修改人联系方式:
 * 修改备注：
 * @Version 1.0
* ==============================================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WX_TennisAssociation.Common
{
    public class AjaxResult
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="success"></param>
        /// <param name="sortMsg"></param>
        [Obsolete("请使用 Data 属性返回结果")]
        public AjaxResult(bool success, string sortMsg)
            : this(success, sortMsg, string.Empty)
        {
        }
        [Obsolete("请使用 Data 属性返回结果")]
        public AjaxResult(bool success, string sortMsg, string fullMsg)
        {
            Success = success;
            SortMsg = sortMsg;
            FullMsg = fullMsg;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="success"></param>
        /// <param name="result"></param>
        public AjaxResult(bool success, object resultData)
        {
            Success = success;
            Data = resultData;
        }

        /// <summary>
        /// <para>执行是否成功</para>
        /// </summary>
        public bool Success;

        /// <summary>
        /// <para>简短消息</para>
        /// </summary>
        public string SortMsg;

        /// <summary>
        /// <para>完整消息</para>
        /// </summary>
        public string FullMsg;

        /// <summary>
        /// <para>Json 数据</para>
        /// </summary>
        public Object Data;


        /// <summary>
        /// 结果在客户端浏览器中缓存时间（秒），默认为0，不缓存
        /// </summary>
        public int ResultCacheSecends { get; set; }
    }
}

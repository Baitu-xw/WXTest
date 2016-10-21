using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WX_TennisAssociation.DAL;
using WX_TennisAssociation.Common;

namespace WX_TennisAssociation.BLL
{
    #region 会员信息数据访问
    /// <summary>
    /// 会员信息数据访问
    /// </summary>
    public class PersonnalMemberBLL
    {
        PersonnalMemberDAL pmdal = new PersonnalMemberDAL();
        #region 添加微信成员
        /// <summary>
        /// 添加微信成员
        /// </summary>
        /// <param name="model">微信成员实体</param>
        /// <returns>返回是否添加成功</returns>
        public bool WX_PersonalMember_Insert(UserJson model)
        {
            return pmdal.WX_PersonalMember_Insert(model);
        }
        #endregion

        #region 判断微信用户是否是会员

        /// <summary>
        /// 判断微信用户是否是会员
        /// </summary>
        /// <returns>返回是否是会员</returns>
        public bool isMember(string strOpenId)
        {
            return pmdal.isMember(strOpenId);
        }
        #endregion
    }
    #endregion
}

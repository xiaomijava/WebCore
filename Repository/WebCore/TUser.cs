﻿using Repository.Bases;
using System.Collections.Generic;

namespace Repository.WebCore
{


    public class TUser:CUD
    {

        /// <summary>
        /// 用户名
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// 手机号
        /// </summary>
        public string Phone { get; set; }


        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }


        /// <summary>
        /// 密码
        /// </summary>
        public string PassWord { get; set; }


        public ICollection<TUserBindWeixin> TUserBindWeixin { get; set; }

    }
}

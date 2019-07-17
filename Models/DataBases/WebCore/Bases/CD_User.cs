﻿using Models.DataBases.Bases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.DataBases.WebCore.Bases
{

    /// <summary>
    /// 创建，编辑，删除，并关联了用户
    /// </summary>
    public class CD_User:CD
    {

        /// <summary>
        /// 创建人ID
        /// </summary>
     
        public string CreateUserId { get; set; }
        public TUser CreateUser { get; set; }



        /// <summary>
        /// 删除人ID
        /// </summary>
        public string DeleteUserId { get; set; }
        public TUser DeleteUser { get; set; }
    }
}

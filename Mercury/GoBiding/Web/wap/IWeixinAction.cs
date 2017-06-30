using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GoBiding.Web.wap.MessageEntity;

namespace GoBiding.Web.wap
{
    public interface IWeixinAction
    {
        /// <summary>
        /// 关注或取消关注
        /// </summary>
        /// <param name="info">文本信息实体</param>
        /// <returns></returns>
        string HandleSubscribeText(SubscribeEvent info);

        /// <summary>
        /// 对订阅请求事件进行处理
        /// </summary>
        /// <param name="info">订阅请求事件信息实体</param>
        /// <returns></returns>
        //string HandleEventSubscribe(RequestEventSubscribe info);

        /// <summary>
        /// 对菜单单击请求事件进行处理
        /// </summary>
        /// <param name="info">菜单单击请求事件信息实体</param>
        /// <returns></returns>
        //string HandleEventClick(RequestEventClick info);
    }
}
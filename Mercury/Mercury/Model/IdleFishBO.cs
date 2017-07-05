using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mercury.Model
{
    public class IdleFishBO
    {
        public int numFound { get; set; }
        public int currPage { get; set; }
        public int totalPage { get; set; }
        public int ershouCount { get; set; }
        public int idleCount { get; set; }
        //public int[] ershou { get; set; }
        public List<IdleFishDetailBO> idle { get; set; }

    }

    public class IdleFishDetailBO
    {
        public IdleFish_UserBO user { get; set; }
        public IdleFish_ItemBO item { get; set; }
    }

    public class IdleFish_UserBO
    {
        public string userIcon { get; set; }
        public string userNick { get; set; }
    }

    public class IdleFish_ItemBO
    {
        public string imageUrl { get; set; }
        public string itemUrl { get; set; }
        public string isBrandNew { get; set; }
        public decimal price { get; set; }
        public string provcity { get; set; }
        public string describe { get; set; }
        public string publishTime { get; set; }
        public string title { get; set; }
    }
}
//{
//    "numFound": 4071,
//    "currPage": 1,
//    "totalPage": 204,
//    "ershouCount": 0,
//    "idleCount": 20,
//    "ershou": [],
//    "idle": [
//        {
//            "user": {
//                "userIcon": "//wwc.alicdn.com/avatar/getAvatar.do?userNick=w2wsyt&width=30&height=30&type=sns",
//                "userNick": "w2wsyt",
//                "vipLevel": 0,
//                "userTypeId": [],
//                "isTaobaoWomen": false,
//                "taobaoWomenUrl": "//mm.taobao.com/2251478073.htm",
//                "userCreditUrl": "//s.2.taobao.com/list/list.htm?usernick=w2wsyt",
//                "userItemsUrl": "//s.2.taobao.com/list/list.htm?usernick=w2wsyt",
//                "isSinaV": false,
//                "yellowSeller": false
//            },
//            "item": {
//                "imageUrl": "//img.alicdn.com/bao/uploaded/i1/6000000001883/TB2.YQtveJ8puFjy1XbXXagqVXa_!!0-fleamarket.jpg_220x10000.jpg",
//                "imageHeight": 720,
//                "imageWidth": 1280,
//                "itemUrl": "//2.taobao.com/item.htm?id=554505705219&amp;from=list&amp;similarUrl=",
//                "isBrandNew": false,
//                "price": "1200.00",
//                "orgPrice": "",
//                "provcity": "云南红河哈尼族彝...",
//                "describe": "感兴趣的话给我留言吧！",
//                "publishTime": "1天前",
//                "itemFrom": "发布自Android客户端",
//                "itemFromDesc": "Android客户端",
//                "itemFromTarget": "//2.taobao.com/mobile/iphone.htm",
//                "commentCount": 0,
//                "commentUrl": "//2.taobao.com/item.htm?id=554505705219&amp;from=list&amp;similarUrl=#item-comments",
//                "collectCount": 0,
//                "title": "[&lt;font color=red&gt;求购&lt;/font&gt;]&lt;font color=red&gt;求购&lt;/font&gt;一台iphone6plus 64G 一定要自用的"
//            }
//        }
//    ]
//}
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEngine;

public class Lesson4 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region 知识点一 HttpWebRequest类
        //命名空间：System.Net
        //HttpWebRequest是主要用于发送客户端请求的类
        //主要用于：发送HTTP客户端请求给服务器，可以进行消息通信、上传、下载等等操作

        //重要方法
        //1.Create 创建新的WebRequest，用于进行HTTP相关操作
        HttpWebRequest req = HttpWebRequest.Create(new Uri("http://192.168.4.84:8048")) as HttpWebRequest;
        //2.Abort  如果正在进行文件传输，用此方法可以终止传输
        //req.Abort();
        //3.GetRequestStream 获取上传的流
        Stream s = req.GetRequestStream();
        //4.GetResponse 返回服务器响应
        HttpWebResponse res = req.GetResponse() as HttpWebResponse;
        //5.Begin/EndGetRequsetStream 异步获用于上传的流
        //6.Begin/EndGetResponse 异步获取返回的HTTP服务器响应

        //重要成员
        //1.Credentials 通信凭证，设置为NetWorkCrednetial对象
        req.Credentials = new NetworkCredential("", "");
        //2.PreAuthenticate 是否随请求发送一个身份验证标头，一般需要进行身份验证时需要将其设置为true
        req.PreAuthenticate = true;

        //3.Headers 构成标头的名称/值对的集合
        //4.ContentLength 发送信息的字节数 上传信息时需先设置该内容长度
        req.ContentLength = 100;
        //5.ContentType 在进行Post请求时，需要对发送的内容进行内容类型的设置
        req.ContentType = "";
        //6.Method 操作命令设置
        // WebRequestMethods.Http类中的操作命令属性
        // Get 获取请求，一般用于获取数据
        // Post 提交请求，一般用于上传数据
        req.Method = WebRequestMethods.Http.Post;
        #endregion

        #region 知识点二 HttpWebResponse类
        //命名空间：System.Net
        //它主要用于获取服务器反馈信息
        //它可以通过HtppWebRequest对象中的GetResponse()获取
        //当使用完毕时，要用Close释放

        //重要方法：
        //1.Close释放所有资源
        res.Close();
        //2.GetResponseStream：返回从FTP服务器下载数据的流

        //重要成员
        //1.ContentLength：接受到数据的长度
        //2.ContentType：接受数据的类型
        //3.StatusCode：Http服务器下发的最新状态码
        //4.StatusDescription：Http服务器下发的状态码文本
        //5.BannerMessage：登录前建立链接时HTTP服务器发送的消息
        //6.ExutMessage：HTTP会话结束时服务器发送的消息
        //7.LastModified：HTTP服务器上的文件上修改日期的时间

        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

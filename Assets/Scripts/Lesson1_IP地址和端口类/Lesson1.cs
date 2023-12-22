using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class Lesson1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region 知识点一 IP类和端口类用来干什么
        //通过之前的理论学习
        //我们知道想要进行网络通信，进行网络链接
        //首先我们需要找到对应设备，IP和端口号式定位网络中设备必不可少的关键元素
        //C#中提供了对应的IP和端口相关的类 来声明对应信息
        //对于之后的网络通信式必不可少的内容
        #endregion

        #region 知识点二 IPAddress类
        //命名空间：System.Net
        //类名：IPAddress

        //初始化IP信息的方式

        //1.用byte数组进行初始化
        byte[] ipAddress = new byte[] {255,255,255,1 };
        IPAddress ip1 = new IPAddress(ipAddress);
        //2.用long长整型进行初始化
        IPAddress ip2 = new IPAddress(0xFFFFFF1);
        //4字节对应的长整型 一般不建议大家使用

        //3.推荐使用的方式 使用字符串转换
        IPAddress ip3 = IPAddress.Parse("192.118.155.3");


        //特殊IP地址
        //127.0.0.1代表本机地址

        //一些静态成员
        //获取可用的IPv6地址
        //IPAddress.IPv6Any
        #endregion

        #region 知识点三 IPEndPoint类
        //命名空间：System.Net；
        //类名：IPEndPoint
        //IPEndPoint类将网络端点表示为IP地址和端口号，表现为IP地址和端口号的组合

        //初始化方式
        IPEndPoint iPEndPoint = new IPEndPoint(ip3, 8080);

        IPEndPoint iPEndPoint1 = new IPEndPoint(IPAddress.Parse("192.168.4.4"), 8080);

        #endregion

        #region 总结
        //程序表示IP信息
        IPAddress ip = IPAddress.Parse("IPv4地址");
        //程序表示通信目标
        IPEndPoint point = new IPEndPoint(ip, 8080);
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

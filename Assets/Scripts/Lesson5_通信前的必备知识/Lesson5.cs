using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class playerInfo
{
    public int age;
    public string name;
    public float atk;
    public int lev;

    public byte[] GetBytes()
    {
        //得到的 这个Info数据 如果转换成 字节数组 那么字节数组容器需要的容量
        int indexNum = sizeof(int) + //age int类型
        sizeof(int) + //代表nama字符串转换成字节数组后 数组的长度
                       Encoding.UTF8.GetBytes(name).Length + //字符串的具体长度
                       sizeof(int) + //lev int类型
                       sizeof(float);
        //2申明一个字节数组容器装载
        byte[] playerBytes = new byte[indexNum];

        //3.将对象中的所有信息转为字节数组并放入该容器当中 （可以利用数组中的CopeTo方法转存字节数组）
        //CopyTo方法的第二个参数代表 从容器的第几个位置开始存储
        int index = 0;
        //年龄
        BitConverter.GetBytes(age).CopyTo(playerBytes, index);
        index += sizeof(int);
        //姓名
        byte[] strBytes = Encoding.UTF8.GetBytes(name);
        int num = strBytes.Length;
        //存储的是姓名转换为字节数组后 字节数组的长度 
        BitConverter.GetBytes(num).CopyTo(playerBytes, index);
        index += sizeof(int);
        //存储字符串的具体内容
        strBytes.CopyTo(playerBytes, index);
        index += num;
        //等级
        BitConverter.GetBytes(lev).CopyTo(playerBytes, index);
        index += sizeof(int);
        //攻击力
        BitConverter.GetBytes(atk).CopyTo(playerBytes, index);
        index += sizeof(float);

        return playerBytes;
    }
}
public class Lesson5 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region 知识点一 非字符串类型转字节数组
        //关键类：BitConverter
        //所在命名空间：System
        //主要作用：除字符串的其他常用类型和字节数组相互转换

        byte[] byte1 = BitConverter.GetBytes(100);
        #endregion

        #region 知识点二 字符串类型转字节数组
        //关键类：Encoding
        //所在命名空间：System.Text
        //主要作用：将字符串类型和字节数组相转换，并决定转换时使用的编码格式，网络通信时建议使用UTF-8
        byte[] byte2 = Encoding.UTF8.GetBytes("你好我是刘qd");

        #endregion

        #region 知识点三 如何将一个类对象转换为二进制
        //注意：网络通信中我们不能直接使用 BinaryFormatter 2进制格式化类
        //因为客户端和服务器使用的语言可能不一样，BinaryFormatter是C#的序列化规则，和其他语言之间的兼容性不好
        //如果使用它，那么其他语言开发的服务器无法对其进行反序列化
        //我们需要自己来处理将类对象数据序列化为字节数组

        //单纯的转换一个变量为字节数组非常简单
        //但是我们如何将一个类对象携带的所有信息放入到一个字节数组中呢
        //我们需要做以下几步
        //1.明确字节数组的容量（注意：在确定字符串字节长度时要考虑解析时如何处理）
        playerInfo player1 = new playerInfo();
        player1.age = 22;
        player1.name = "刘庆典";
        player1.lev = 9999999;
        player1.atk = 99999999;
        #endregion
        #region 总结
        //对类对象的2进制序列化主要用到的是
        //1.BitConverter转换非字符串类型的变量为字节数组
        //2.Encoding.UTF8转换字符串类型的变量为字节数组（注意：为了考虑反序列化，在转存2进制，序列化字符串之前，先序列化字符串字节数组的长度）
        
        //转换流程是
        //1.明确字节数组的容量
        //2.申明一个装载信息的字节数组容器
        //3.将对象中的所有信息转为字节数组并放入该容器当中（利用数组中的CopyTo方法转存字节数组）
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

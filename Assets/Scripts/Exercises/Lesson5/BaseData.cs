using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public abstract class BaseData
{
    /// <summary>
    /// 用于子类重写，获取字节数组容器大小
    /// </summary>
    /// <returns></returns>
    public abstract int GetBytesNum();
    /// <summary>
    /// 把成员变量 序列化为 对应字节数组
    /// </summary>
    /// <returns></returns>
    public abstract byte[] Writing();
  
    /// <summary>
    /// 存储Int变量类型到指定的字节数组当中
    /// </summary>
    /// <param name="bytes">byte数组容器</param>
    /// <param name="value">传入的数据</param>
    /// <param name="index"></param>

    protected void WriteInt(byte[] bytes, int value, ref int index)
    {
        BitConverter.GetBytes(value).CopyTo(bytes, index);
        index += 4;
    }

    protected void WriteShort(byte[] bytes, short value, ref int index)
    {
        BitConverter.GetBytes(value).CopyTo (bytes, index);
        index += 2;
    }

    protected void WriteLong(byte[] bytes, long value, ref int index)
    {
        BitConverter.GetBytes(value).CopyTo (bytes, index);
        index += 8;
    }
    protected void WriteFloat(byte[] bytes, float value, ref int index)
    {
        BitConverter.GetBytes(value).CopyTo (bytes, index);
        index += 4;
    }
    protected void WriteByte(byte[] bytes, byte value, ref int index)
    {
        bytes[index] = value;
        index += 1;
    }
    protected void WriteBool(byte[] bytes, bool value, ref int index)
    {
        BitConverter.GetBytes(value).CopyTo(bytes, index);
        index += 1;
    }
    protected void WriteString(byte[] bytes, string value, ref int index)
    {
        //先存长度
        byte[] strBytes = Encoding.UTF8.GetBytes(value);
        WriteInt(bytes, strBytes.Length, ref index);
        index += 4;
        //再存字符串内容
        strBytes.CopyTo(bytes, index);
        index += strBytes.Length;
    }

    protected void WriteData(byte[] bytes, BaseData data, int index)
    {
        data.Writing().CopyTo(bytes, index);
        index += data.GetBytesNum();
    }
}

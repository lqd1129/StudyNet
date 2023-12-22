using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public abstract class BaseData
{
    /// <summary>
    /// ����������д����ȡ�ֽ�����������С
    /// </summary>
    /// <returns></returns>
    public abstract int GetBytesNum();
    /// <summary>
    /// �ѳ�Ա���� ���л�Ϊ ��Ӧ�ֽ�����
    /// </summary>
    /// <returns></returns>
    public abstract byte[] Writing();
  
    /// <summary>
    /// �洢Int�������͵�ָ�����ֽ����鵱��
    /// </summary>
    /// <param name="bytes">byte��������</param>
    /// <param name="value">���������</param>
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
        //�ȴ泤��
        byte[] strBytes = Encoding.UTF8.GetBytes(value);
        WriteInt(bytes, strBytes.Length, ref index);
        index += 4;
        //�ٴ��ַ�������
        strBytes.CopyTo(bytes, index);
        index += strBytes.Length;
    }

    protected void WriteData(byte[] bytes, BaseData data, int index)
    {
        data.Writing().CopyTo(bytes, index);
        index += data.GetBytesNum();
    }
}

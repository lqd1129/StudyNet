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
        //�õ��� ���Info���� ���ת���� �ֽ����� ��ô�ֽ�����������Ҫ������
        int indexNum = sizeof(int) + //age int����
        sizeof(int) + //����nama�ַ���ת�����ֽ������ ����ĳ���
                       Encoding.UTF8.GetBytes(name).Length + //�ַ����ľ��峤��
                       sizeof(int) + //lev int����
                       sizeof(float);
        //2����һ���ֽ���������װ��
        byte[] playerBytes = new byte[indexNum];

        //3.�������е�������ϢתΪ�ֽ����鲢������������� ���������������е�CopeTo����ת���ֽ����飩
        //CopyTo�����ĵڶ����������� �������ĵڼ���λ�ÿ�ʼ�洢
        int index = 0;
        //����
        BitConverter.GetBytes(age).CopyTo(playerBytes, index);
        index += sizeof(int);
        //����
        byte[] strBytes = Encoding.UTF8.GetBytes(name);
        int num = strBytes.Length;
        //�洢��������ת��Ϊ�ֽ������ �ֽ�����ĳ��� 
        BitConverter.GetBytes(num).CopyTo(playerBytes, index);
        index += sizeof(int);
        //�洢�ַ����ľ�������
        strBytes.CopyTo(playerBytes, index);
        index += num;
        //�ȼ�
        BitConverter.GetBytes(lev).CopyTo(playerBytes, index);
        index += sizeof(int);
        //������
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
        #region ֪ʶ��һ ���ַ�������ת�ֽ�����
        //�ؼ��ࣺBitConverter
        //���������ռ䣺System
        //��Ҫ���ã����ַ����������������ͺ��ֽ������໥ת��

        byte[] byte1 = BitConverter.GetBytes(100);
        #endregion

        #region ֪ʶ��� �ַ�������ת�ֽ�����
        //�ؼ��ࣺEncoding
        //���������ռ䣺System.Text
        //��Ҫ���ã����ַ������ͺ��ֽ�������ת����������ת��ʱʹ�õı����ʽ������ͨ��ʱ����ʹ��UTF-8
        byte[] byte2 = Encoding.UTF8.GetBytes("���������qd");

        #endregion

        #region ֪ʶ���� ��ν�һ�������ת��Ϊ������
        //ע�⣺����ͨ�������ǲ���ֱ��ʹ�� BinaryFormatter 2���Ƹ�ʽ����
        //��Ϊ�ͻ��˺ͷ�����ʹ�õ����Կ��ܲ�һ����BinaryFormatter��C#�����л����򣬺���������֮��ļ����Բ���
        //���ʹ��������ô�������Կ����ķ������޷�������з����л�
        //������Ҫ�Լ�������������������л�Ϊ�ֽ�����

        //������ת��һ������Ϊ�ֽ�����ǳ���
        //����������ν�һ�������Я����������Ϣ���뵽һ���ֽ���������
        //������Ҫ�����¼���
        //1.��ȷ�ֽ������������ע�⣺��ȷ���ַ����ֽڳ���ʱҪ���ǽ���ʱ��δ���
        playerInfo player1 = new playerInfo();
        player1.age = 22;
        player1.name = "�����";
        player1.lev = 9999999;
        player1.atk = 99999999;
        #endregion
        #region �ܽ�
        //��������2�������л���Ҫ�õ�����
        //1.BitConverterת�����ַ������͵ı���Ϊ�ֽ�����
        //2.Encoding.UTF8ת���ַ������͵ı���Ϊ�ֽ����飨ע�⣺Ϊ�˿��Ƿ����л�����ת��2���ƣ����л��ַ���֮ǰ�������л��ַ����ֽ�����ĳ��ȣ�
        
        //ת��������
        //1.��ȷ�ֽ����������
        //2.����һ��װ����Ϣ���ֽ���������
        //3.�������е�������ϢתΪ�ֽ����鲢������������У����������е�CopyTo����ת���ֽ����飩
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

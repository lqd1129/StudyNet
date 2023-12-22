using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class Lesson1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region ֪ʶ��һ IP��Ͷ˿���������ʲô
        //ͨ��֮ǰ������ѧϰ
        //����֪����Ҫ��������ͨ�ţ�������������
        //����������Ҫ�ҵ���Ӧ�豸��IP�Ͷ˿ں�ʽ��λ�������豸�ز����ٵĹؼ�Ԫ��
        //C#���ṩ�˶�Ӧ��IP�Ͷ˿���ص��� ��������Ӧ��Ϣ
        //����֮�������ͨ��ʽ�ز����ٵ�����
        #endregion

        #region ֪ʶ��� IPAddress��
        //�����ռ䣺System.Net
        //������IPAddress

        //��ʼ��IP��Ϣ�ķ�ʽ

        //1.��byte������г�ʼ��
        byte[] ipAddress = new byte[] {255,255,255,1 };
        IPAddress ip1 = new IPAddress(ipAddress);
        //2.��long�����ͽ��г�ʼ��
        IPAddress ip2 = new IPAddress(0xFFFFFF1);
        //4�ֽڶ�Ӧ�ĳ����� һ�㲻������ʹ��

        //3.�Ƽ�ʹ�õķ�ʽ ʹ���ַ���ת��
        IPAddress ip3 = IPAddress.Parse("192.118.155.3");


        //����IP��ַ
        //127.0.0.1��������ַ

        //һЩ��̬��Ա
        //��ȡ���õ�IPv6��ַ
        //IPAddress.IPv6Any
        #endregion

        #region ֪ʶ���� IPEndPoint��
        //�����ռ䣺System.Net��
        //������IPEndPoint
        //IPEndPoint�ཫ����˵��ʾΪIP��ַ�Ͷ˿ںţ�����ΪIP��ַ�Ͷ˿ںŵ����

        //��ʼ����ʽ
        IPEndPoint iPEndPoint = new IPEndPoint(ip3, 8080);

        IPEndPoint iPEndPoint1 = new IPEndPoint(IPAddress.Parse("192.168.4.4"), 8080);

        #endregion

        #region �ܽ�
        //�����ʾIP��Ϣ
        IPAddress ip = IPAddress.Parse("IPv4��ַ");
        //�����ʾͨ��Ŀ��
        IPEndPoint point = new IPEndPoint(ip, 8080);
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

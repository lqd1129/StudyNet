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
        #region ֪ʶ��һ HttpWebRequest��
        //�����ռ䣺System.Net
        //HttpWebRequest����Ҫ���ڷ��Ϳͻ����������
        //��Ҫ���ڣ�����HTTP�ͻ�������������������Խ�����Ϣͨ�š��ϴ������صȵȲ���

        //��Ҫ����
        //1.Create �����µ�WebRequest�����ڽ���HTTP��ز���
        HttpWebRequest req = HttpWebRequest.Create(new Uri("http://192.168.4.84:8048")) as HttpWebRequest;
        //2.Abort  ������ڽ����ļ����䣬�ô˷���������ֹ����
        //req.Abort();
        //3.GetRequestStream ��ȡ�ϴ�����
        Stream s = req.GetRequestStream();
        //4.GetResponse ���ط�������Ӧ
        HttpWebResponse res = req.GetResponse() as HttpWebResponse;
        //5.Begin/EndGetRequsetStream �첽�������ϴ�����
        //6.Begin/EndGetResponse �첽��ȡ���ص�HTTP��������Ӧ

        //��Ҫ��Ա
        //1.Credentials ͨ��ƾ֤������ΪNetWorkCrednetial����
        req.Credentials = new NetworkCredential("", "");
        //2.PreAuthenticate �Ƿ���������һ�������֤��ͷ��һ����Ҫ���������֤ʱ��Ҫ��������Ϊtrue
        req.PreAuthenticate = true;

        //3.Headers ���ɱ�ͷ������/ֵ�Եļ���
        //4.ContentLength ������Ϣ���ֽ��� �ϴ���Ϣʱ�������ø����ݳ���
        req.ContentLength = 100;
        //5.ContentType �ڽ���Post����ʱ����Ҫ�Է��͵����ݽ����������͵�����
        req.ContentType = "";
        //6.Method ������������
        // WebRequestMethods.Http���еĲ�����������
        // Get ��ȡ����һ�����ڻ�ȡ����
        // Post �ύ����һ�������ϴ�����
        req.Method = WebRequestMethods.Http.Post;
        #endregion

        #region ֪ʶ��� HttpWebResponse��
        //�����ռ䣺System.Net
        //����Ҫ���ڻ�ȡ������������Ϣ
        //������ͨ��HtppWebRequest�����е�GetResponse()��ȡ
        //��ʹ�����ʱ��Ҫ��Close�ͷ�

        //��Ҫ������
        //1.Close�ͷ�������Դ
        res.Close();
        //2.GetResponseStream�����ش�FTP�������������ݵ���

        //��Ҫ��Ա
        //1.ContentLength�����ܵ����ݵĳ���
        //2.ContentType���������ݵ�����
        //3.StatusCode��Http�������·�������״̬��
        //4.StatusDescription��Http�������·���״̬���ı�
        //5.BannerMessage����¼ǰ��������ʱHTTP���������͵���Ϣ
        //6.ExutMessage��HTTP�Ự����ʱ���������͵���Ϣ
        //7.LastModified��HTTP�������ϵ��ļ����޸����ڵ�ʱ��

        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

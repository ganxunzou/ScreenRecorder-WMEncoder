/***************************************************************************************
�� �� ��: IEncoder.cs
Copyright (c) 2008-2008 �ڹ�������޹�˾
�� �� �� : ��ΰ
�������� : 2008-11-3
�� �� �� : ��ΰ
�޸����� : 2008-11-3
�޸�˵�� : ������Resume�ӿڡ�
��Ҫ���� : 
		  ����ļ������б�����Ľӿڣ�Ҫ��ʵ�־���Ĺ��ܱ���ʵ������ࡣ���� ��WMV��ʽ
����ʱ���μ��������е�WMVEncoder�ࡣ 
***************************************************************************************/ 

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace TengGuang.VedioScreen.Core
{
    /// <summary>
    /// �������ӿ�
    /// </summary>
    public abstract class IEncoder
    {
        /// <summary>
        /// ��ͣ��ָ�ִ��
        /// </summary>
        internal abstract void Resume();

        /// <summary>
        /// ��ʼ����
        /// </summary>
        /// <param name="mediaInfo">Ŀ���ļ��������Ϣ</param>
        /// <param name="area">��¼�Ƶ���Ļ������</param>
        internal abstract void Start(MediaInfo mediaInfo, ScreenArea area);

        /// <summary>
        /// ��ͣ����
        /// </summary>
        internal abstract void Pause();

        /// <summary>
        /// ֹͣ����
        /// </summary>
        internal abstract void Stop();

        /// <summary>
        /// ��ȡѹ����ʽ�������б�
        /// </summary>
        /// <returns>
        /// key   ѹ����ʽ��
        /// value ѹ����ʽ���
        /// </returns>
        public abstract Hashtable GetProfileInfos();
    }
}

/***************************************************************************************
�� �� ��: MediaInfo.cs
Copyright (c) 2008-2008 �ڹ�������޹�˾
�� �� �� : ��ΰ
�������� : 2008-11-3
��Ҫ���� : 
		   ¼�Ƶ�ý�������Ϣ
***************************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;

namespace TengGuang.VedioScreen.Core
{
    /// <summary>
    /// ¼�Ƶ�ý�������Ϣ
    /// </summary>
    public struct MediaInfo
    {
        /// <summary>
        /// ���·��
        /// </summary>
        public string SavePath;

        /// <summary>
        /// ѹ�� ��ʽ ���� 
        /// </summary>
        public string ProfileName;

        /// <summary>
        /// ��Ƶ����Ƶѡ��
        /// </summary>
        public AudioVedioType AudioVedio;
    }
}

/***************************************************************************************
文 件 名: MediaInfo.cs
Copyright (c) 2008-2008 腾光软件有限公司
创 建 人 : 乔伟
创建日期 : 2008-11-3
简要介绍 : 
		   录制的媒体相关信息
***************************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;

namespace TengGuang.VedioScreen.Core
{
    /// <summary>
    /// 录制的媒体相关信息
    /// </summary>
    public struct MediaInfo
    {
        /// <summary>
        /// 存放路径
        /// </summary>
        public string SavePath;

        /// <summary>
        /// 压缩 方式 名称 
        /// </summary>
        public string ProfileName;

        /// <summary>
        /// 音频，视频选项
        /// </summary>
        public AudioVedioType AudioVedio;
    }
}

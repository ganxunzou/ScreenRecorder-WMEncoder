/***************************************************************************************
文 件 名: AudioVedioType.cs
Copyright (c) 2008-2008 腾光软件有限公司
创 建 人 : 乔伟
创建日期 : 2008-11-3
简要介绍 : 
		   录制的音/视频选项
***************************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;

namespace TengGuang.VedioScreen.Core
{
    /// <summary>
    /// 录制的音/视频选项
    /// </summary>
    public enum AudioVedioType
    {
        /// <summary>
        /// 只有音频
        /// </summary>
        AudioOnly,

        /// <summary> 
        /// 只有视频
        /// </summary>
        VedioOnly,

        /// <summary>
        /// 两者都有
        /// </summary>
        Both
    }
}

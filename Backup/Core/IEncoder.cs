/***************************************************************************************
文 件 名: IEncoder.cs
Copyright (c) 2008-2008 腾光软件有限公司
创 建 人 : 乔伟
创建日期 : 2008-11-3
修 改 人 : 乔伟
修改日期 : 2008-11-3
修改说明 : 加入了Resume接口。
简要介绍 : 
		  这个文件是所有编码类的接口，要想实现具体的功能必须实现这个类。例如 以WMV格式
保存时，参见本程序中的WMVEncoder类。 
***************************************************************************************/ 

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace TengGuang.VedioScreen.Core
{
    /// <summary>
    /// 编码器接口
    /// </summary>
    public abstract class IEncoder
    {
        /// <summary>
        /// 暂停后恢复执行
        /// </summary>
        internal abstract void Resume();

        /// <summary>
        /// 开始编码
        /// </summary>
        /// <param name="mediaInfo">目标文件的相关信息</param>
        /// <param name="area">欲录制的屏幕的区域</param>
        internal abstract void Start(MediaInfo mediaInfo, ScreenArea area);

        /// <summary>
        /// 暂停编码
        /// </summary>
        internal abstract void Pause();

        /// <summary>
        /// 停止编码
        /// </summary>
        internal abstract void Stop();

        /// <summary>
        /// 获取压缩方式的名称列表
        /// </summary>
        /// <returns>
        /// key   压缩格式名
        /// value 压缩格式简介
        /// </returns>
        public abstract Hashtable GetProfileInfos();
    }
}

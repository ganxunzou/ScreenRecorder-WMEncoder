/***************************************************************************************
文 件 名: Recordor.cs
Copyright (c) 2008-2008 腾光软件有限公司
创 建 人 : 乔伟
创建日期 : 2008-11-3
简要介绍 : 
		   录制器，本类是IEncoder接口的一个包装类，是本Assemble对外的唯一接口。
本类所有的一切操作，通过具体的IEncoder实现。方法的说明具体请见IEncoder接口说明
***************************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;

namespace TengGuang.VedioScreen.Core
{
    /// <summary>
    /// 录制器
    /// </summary>
    public class Recordor
    {
        private IEncoder _encoder;

        public IEncoder Encoder
        {
            get
            {
                return _encoder;
            }
        }

        public Recordor(IEncoder encoder)
        {
            _encoder = encoder;
        }

        public void Start( MediaInfo mediaInfo,ScreenArea area)
        {
            _encoder.Start(mediaInfo,area);
        }

        public void Pause()
        {
            _encoder.Pause();
        }

        public void Stop()
        {
            _encoder.Stop();
        }

        public void Resume()
        {
            _encoder.Resume();
        }
    }
}

/***************************************************************************************
文 件 名: ScreenArea.cs
Copyright (c) 2008-2008 腾光软件有限公司
创 建 人 : 乔伟
创建日期 : 2008-11-3
简要介绍 : 
		   屏幕区域
***************************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;

namespace TengGuang.VedioScreen.Core
{
    /// <summary>
    /// 屏幕区域
    /// </summary>
    public struct ScreenArea
    {
        /// <summary>
        /// 左上角坐标的X值
        /// </summary>
        public int X;

        /// <summary>
        /// 左上角坐标的Y值 
        /// </summary>
        public int Y;

        /// <summary>
        /// 高度
        /// </summary>
        public int Height;

        /// <summary>
        /// 宽度
        /// </summary>
        public int Weight;
    }
}

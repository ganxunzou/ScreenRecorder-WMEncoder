/***************************************************************************************
文 件 名: WMVEncoder.cs
Copyright (c) 2008-2008 腾光软件有限公司
创 建 人 : 乔伟
创建日期 : 2008-11-3
简要介绍 : 
		   IEncoder的实现类，实现了将录制的数据转成WMV格式编码的文件,此类的每个实例 对应
唯一一个 WMEncoderLib.WMEncoder .所以录制完成一个后，再重新录制另外一个时，必须重新new一个此类。
***************************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using WMEncoderLib;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace TengGuang.VedioScreen.Core
{
    /// <summary>
    /// 具体编码类，方法说明参见IEncoder
    /// </summary>
    public class WMVEncoder : IEncoder
    {
        // 重设鼠标的双击速度
        [DllImport("user32.dll", EntryPoint = "SetDoubleClickTime")]
        internal extern static int SetDoubleClickTime(int wCount);
        [DllImport("user32.dll", EntryPoint = "GetDoubleClickTime")]
        internal extern static int GetDoubleClickTime();

        private WMEncoder encoder;
        private Hashtable profileInfos = new Hashtable(); // 压缩方式信息集,key 压缩方式的名称 value 压缩方式简介
        private Hashtable profiles = new Hashtable(); // 压缩方式集

        public WMVEncoder()
        {
            encoder = new WMEncoderClass();
        }

        ~WMVEncoder()
        {
            try
            {
                encoder.Stop();
            }
            catch   
            {
            }
        }

        #region IEncoder 成员

        internal override void Resume()
        {
            encoder.Start();
        }

        /// <summary>
        /// 开始录制
        /// </summary>
        /// <param name="mediaInfo"></param>
        /// <param name="captureArea">捕获区域（录制的区域）</param>
        internal override void Start(MediaInfo mediaInfo, ScreenArea captureArea)
        {
            // 设置一些必要的变量
            IWMEncSourceGroupCollection sourceGroupCollection;
            IWMEncSourceGroup2 sourceGroup;
            IWMEncAudioSource audioSource;
            IWMEncVideoSource2 vedioSource;
            //IWMEncProfile2 Pro;

            sourceGroupCollection = encoder.SourceGroupCollection;
            sourceGroup = (IWMEncSourceGroup2)sourceGroupCollection.Add("SG_1");

            // 假如 是仅音频，或者是 音频视频 全有，则添加音频设备，并进行相关设置
            if (mediaInfo.AudioVedio == AudioVedioType.AudioOnly || mediaInfo.AudioVedio == AudioVedioType.Both)
            {
                audioSource = (IWMEncAudioSource)sourceGroup.AddSource(WMENC_SOURCE_TYPE.WMENC_AUDIO);
                audioSource.SetInput("Default_Audio_Device", "DEVICE", "");
            }

            // 假如 是仅视频，或者是 音频视频 全有，则添加视频设备
            if (mediaInfo.AudioVedio == AudioVedioType.VedioOnly || mediaInfo.AudioVedio == AudioVedioType.Both)
            {
                vedioSource = (IWMEncVideoSource2)sourceGroup.AddSource(WMENC_SOURCE_TYPE.WMENC_VIDEO);
                vedioSource.SetInput("ScreenCapture1", "ScreenCap", "");

                // 视频尺寸/显示器尺寸  缩放比
                Size screenSize = SystemInformation.PrimaryMonitorSize;
                float scaleX = (float)vedioSource.Height / (float)screenSize.Height;
                float scaleY = (float)vedioSource.Width / (float)screenSize.Width;

                // 设置左边和上部剪裁区
                vedioSource.CroppingLeftMargin = (int)((float)captureArea.X * scaleY);
                vedioSource.CroppingTopMargin = (int)((float)captureArea.Y * scaleX);

                // 设置右边和下部剪裁区
                int bottomMargin = screenSize.Height - captureArea.Height - captureArea.Y;
                int rightMargin = screenSize.Width - captureArea.Weight - captureArea.X;
                vedioSource.CroppingRightMargin = (int)((float)bottomMargin * scaleY );
                vedioSource.CroppingBottomMargin = (int)((float)rightMargin * scaleX);
            }

            // 设置压缩方式
            // 首先必须刷新一下信息
            IWMEncSourcePluginInfoManager sourcePluginInfoManager = encoder.SourcePluginInfoManager;
            sourcePluginInfoManager.Refresh();
            IWMEncProfileCollection wpfc = encoder.ProfileCollection;
            // 将压缩方式的名称添加进 profileNames 变量,将压缩方式对象本身添加到profiles 变量
            for (int i = 0; i < wpfc.Count; i++)
            {
                if (mediaInfo.ProfileName == wpfc.Item(i).Name)
                {
                    sourceGroup.set_Profile(wpfc.Item(i));
                    break;
                }
            }
            
            // 设置存放位置
            encoder.File.LocalFileName = mediaInfo.SavePath;

            // 启动
            encoder.Start();
        }

        internal override void Pause()
        {
            encoder.Pause();
        }

        internal override void Stop()
        {
            encoder.Stop();
        }

        public override Hashtable GetProfileInfos()
        {
            // 先清空
            profileInfos.Clear();

            // 声明必要变量
            IWMEncSourcePluginInfoManager sourceGroupCollection = encoder.SourcePluginInfoManager;
            IWMEncProfileCollection profileCollection = encoder.ProfileCollection;
            IWMEncProfile2 profile2 = new WMEncProfile2Class();

            // 刷新
            sourceGroupCollection.Refresh();

            // 将所有压缩方式的相关信息 依次存入 profileInfos（Hashtable）。
            for (int i = 0; i < profileCollection.Count; i++)
            {
                // 利用wp2获取压缩方式的相关信息
                profile2.LoadFromIWMProfile((IWMEncProfile)profileCollection.Item(i));
                
                // 获取压缩方式的相关描述
                StringBuilder profileInfo = new StringBuilder();
                profileInfo.AppendLine(profileCollection.Item(i).Description);
                for (int j = 0; j < profile2.AudienceCount; j++)
                {
                    IWMEncAudienceObj audienceObj = profile2.get_Audience(j);
                    // 假如此听众处于被选中状态
                    if (audienceObj.Selected)
                    {
                        object audioCodecName = null;
                        object videoCodecName = null;
                        try
                        {
                            // 得到音频编码名称
                            int audioCodecIndex = audienceObj.get_AudioCodec(0);
                            profile2.EnumAudioCodec(audioCodecIndex, out audioCodecName);

                            // 得到视频编码名称
                            int videoCodecIndex = audienceObj.get_VideoCodec(0);
                            profile2.EnumVideoCodec(videoCodecIndex, out videoCodecName);
                        }
                        catch
                        {

                        }

                        // 假如音频编码名称不为NULL
                        if (audioCodecName != null)
                        {
                            profileInfo.AppendLine("音频编码：" + audioCodecName.ToString());
                        }

                        // // 假如频编码名称不为NULL
                        if (videoCodecName != null)
                        {
                            profileInfo.AppendLine("视频编码：" + videoCodecName.ToString());
                            profileInfo.AppendLine("视频高度：" + Convert.ToString(audienceObj.get_VideoHeight(0)) + "\t视频宽度：" + Convert.ToString(audienceObj.get_VideoWidth(0)));
                        }
                    }
                }

                profileInfos.Add(profileCollection.Item(i).Name,profileInfo.ToString());
            }

            return profileInfos;
        }

        #endregion
    }
}
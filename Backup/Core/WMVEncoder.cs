/***************************************************************************************
�� �� ��: WMVEncoder.cs
Copyright (c) 2008-2008 �ڹ�������޹�˾
�� �� �� : ��ΰ
�������� : 2008-11-3
��Ҫ���� : 
		   IEncoder��ʵ���࣬ʵ���˽�¼�Ƶ�����ת��WMV��ʽ������ļ�,�����ÿ��ʵ�� ��Ӧ
Ψһһ�� WMEncoderLib.WMEncoder .����¼�����һ����������¼������һ��ʱ����������newһ�����ࡣ
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
    /// ��������࣬����˵���μ�IEncoder
    /// </summary>
    public class WMVEncoder : IEncoder
    {
        // ��������˫���ٶ�
        [DllImport("user32.dll", EntryPoint = "SetDoubleClickTime")]
        internal extern static int SetDoubleClickTime(int wCount);
        [DllImport("user32.dll", EntryPoint = "GetDoubleClickTime")]
        internal extern static int GetDoubleClickTime();

        private WMEncoder encoder;
        private Hashtable profileInfos = new Hashtable(); // ѹ����ʽ��Ϣ��,key ѹ����ʽ������ value ѹ����ʽ���
        private Hashtable profiles = new Hashtable(); // ѹ����ʽ��

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

        #region IEncoder ��Ա

        internal override void Resume()
        {
            encoder.Start();
        }

        /// <summary>
        /// ��ʼ¼��
        /// </summary>
        /// <param name="mediaInfo"></param>
        /// <param name="captureArea">��������¼�Ƶ�����</param>
        internal override void Start(MediaInfo mediaInfo, ScreenArea captureArea)
        {
            // ����һЩ��Ҫ�ı���
            IWMEncSourceGroupCollection sourceGroupCollection;
            IWMEncSourceGroup2 sourceGroup;
            IWMEncAudioSource audioSource;
            IWMEncVideoSource2 vedioSource;
            //IWMEncProfile2 Pro;

            sourceGroupCollection = encoder.SourceGroupCollection;
            sourceGroup = (IWMEncSourceGroup2)sourceGroupCollection.Add("SG_1");

            // ���� �ǽ���Ƶ�������� ��Ƶ��Ƶ ȫ�У��������Ƶ�豸���������������
            if (mediaInfo.AudioVedio == AudioVedioType.AudioOnly || mediaInfo.AudioVedio == AudioVedioType.Both)
            {
                audioSource = (IWMEncAudioSource)sourceGroup.AddSource(WMENC_SOURCE_TYPE.WMENC_AUDIO);
                audioSource.SetInput("Default_Audio_Device", "DEVICE", "");
            }

            // ���� �ǽ���Ƶ�������� ��Ƶ��Ƶ ȫ�У��������Ƶ�豸
            if (mediaInfo.AudioVedio == AudioVedioType.VedioOnly || mediaInfo.AudioVedio == AudioVedioType.Both)
            {
                vedioSource = (IWMEncVideoSource2)sourceGroup.AddSource(WMENC_SOURCE_TYPE.WMENC_VIDEO);
                vedioSource.SetInput("ScreenCapture1", "ScreenCap", "");

                // ��Ƶ�ߴ�/��ʾ���ߴ�  ���ű�
                Size screenSize = SystemInformation.PrimaryMonitorSize;
                float scaleX = (float)vedioSource.Height / (float)screenSize.Height;
                float scaleY = (float)vedioSource.Width / (float)screenSize.Width;

                // ������ߺ��ϲ�������
                vedioSource.CroppingLeftMargin = (int)((float)captureArea.X * scaleY);
                vedioSource.CroppingTopMargin = (int)((float)captureArea.Y * scaleX);

                // �����ұߺ��²�������
                int bottomMargin = screenSize.Height - captureArea.Height - captureArea.Y;
                int rightMargin = screenSize.Width - captureArea.Weight - captureArea.X;
                vedioSource.CroppingRightMargin = (int)((float)bottomMargin * scaleY );
                vedioSource.CroppingBottomMargin = (int)((float)rightMargin * scaleX);
            }

            // ����ѹ����ʽ
            // ���ȱ���ˢ��һ����Ϣ
            IWMEncSourcePluginInfoManager sourcePluginInfoManager = encoder.SourcePluginInfoManager;
            sourcePluginInfoManager.Refresh();
            IWMEncProfileCollection wpfc = encoder.ProfileCollection;
            // ��ѹ����ʽ��������ӽ� profileNames ����,��ѹ����ʽ��������ӵ�profiles ����
            for (int i = 0; i < wpfc.Count; i++)
            {
                if (mediaInfo.ProfileName == wpfc.Item(i).Name)
                {
                    sourceGroup.set_Profile(wpfc.Item(i));
                    break;
                }
            }
            
            // ���ô��λ��
            encoder.File.LocalFileName = mediaInfo.SavePath;

            // ����
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
            // �����
            profileInfos.Clear();

            // ������Ҫ����
            IWMEncSourcePluginInfoManager sourceGroupCollection = encoder.SourcePluginInfoManager;
            IWMEncProfileCollection profileCollection = encoder.ProfileCollection;
            IWMEncProfile2 profile2 = new WMEncProfile2Class();

            // ˢ��
            sourceGroupCollection.Refresh();

            // ������ѹ����ʽ�������Ϣ ���δ��� profileInfos��Hashtable����
            for (int i = 0; i < profileCollection.Count; i++)
            {
                // ����wp2��ȡѹ����ʽ�������Ϣ
                profile2.LoadFromIWMProfile((IWMEncProfile)profileCollection.Item(i));
                
                // ��ȡѹ����ʽ���������
                StringBuilder profileInfo = new StringBuilder();
                profileInfo.AppendLine(profileCollection.Item(i).Description);
                for (int j = 0; j < profile2.AudienceCount; j++)
                {
                    IWMEncAudienceObj audienceObj = profile2.get_Audience(j);
                    // ��������ڴ��ڱ�ѡ��״̬
                    if (audienceObj.Selected)
                    {
                        object audioCodecName = null;
                        object videoCodecName = null;
                        try
                        {
                            // �õ���Ƶ��������
                            int audioCodecIndex = audienceObj.get_AudioCodec(0);
                            profile2.EnumAudioCodec(audioCodecIndex, out audioCodecName);

                            // �õ���Ƶ��������
                            int videoCodecIndex = audienceObj.get_VideoCodec(0);
                            profile2.EnumVideoCodec(videoCodecIndex, out videoCodecName);
                        }
                        catch
                        {

                        }

                        // ������Ƶ�������Ʋ�ΪNULL
                        if (audioCodecName != null)
                        {
                            profileInfo.AppendLine("��Ƶ���룺" + audioCodecName.ToString());
                        }

                        // // ����Ƶ�������Ʋ�ΪNULL
                        if (videoCodecName != null)
                        {
                            profileInfo.AppendLine("��Ƶ���룺" + videoCodecName.ToString());
                            profileInfo.AppendLine("��Ƶ�߶ȣ�" + Convert.ToString(audienceObj.get_VideoHeight(0)) + "\t��Ƶ��ȣ�" + Convert.ToString(audienceObj.get_VideoWidth(0)));
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
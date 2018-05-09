using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using WMEncoderLib;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        WMEncoder Encoder = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Encoder = new WMEncoder();

                IWMEncSourceGroup SrcGrp;

                IWMEncSourceGroupCollection SrcGrpColl;

                SrcGrpColl = Encoder.SourceGroupCollection;

                SrcGrp = SrcGrpColl.Add("SG_1");

                IWMEncSource SrcVid = null;

                IWMEncSource SrcAud = null;

                SrcVid = SrcGrp.AddSource(WMENC_SOURCE_TYPE.WMENC_VIDEO);

                SrcAud = SrcGrp.AddSource(WMENC_SOURCE_TYPE.WMENC_AUDIO);

                SrcAud.SetInput("Default_Audio_Device", "Device", "");

                SrcVid.SetInput("ScreenCapture1", "ScreenCap", "");

                IWMEncProfileCollection ProColl;

                IWMEncProfile Pro;

                int i;

                long lLength;

                ProColl = Encoder.ProfileCollection;

                lLength = ProColl.Count;

                for (i = 0; i < lLength - 1; i++)
                {
                    Pro = ProColl.Item(i);

                    Console.WriteLine("<><>>"+Pro.Name);

                    if (Pro.Name == "屏幕视频/音频 - 高(CBR)")
                    {
                        SrcGrp.set_Profile(Pro);

                        break;
                    }
                }
                IWMEncDisplayInfo Descr;

                Descr = Encoder.DisplayInfo;

                Descr.Author = "";

                Descr.Copyright = "";

                Descr.Description = "";

                Descr.Rating = "";

                Descr.Title = "";

                IWMEncAttributes Attr;

                Attr = Encoder.Attributes;

                IWMEncFile File;

                File = Encoder.File;

                //if (label1.Text != string.Empty)
                //{
                //    File.LocalFileName = @"C:\1.WMA"; //保存路径
                //}
                //else
                //{
                //    MessageBox.Show("请先选择路径！");
                //    return;
                //}

                File.LocalFileName = @"C:\1.WMA"; //保存路径

                Encoder.Start();
            }
            catch (Exception ex)
            {
                Encoder.Stop();
            }
        }
    }
}

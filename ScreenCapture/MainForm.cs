using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace ScreenCapture
{
    public partial class MainForm : Form
    {
        #region ���췽��

        public MainForm()
        {
            InitializeComponent();
        }

        #endregion

        #region ��ť�¼�����

        private void btnFullScrn_Click(object sender, EventArgs e)
        {
            CommandFullScrn();
        }

        private void btnRegionScrn_Click(object sender, EventArgs e)
        {
            CommandRegionScrn();
        }

        private void btnPathScrn_Click(object sender, EventArgs e)
        {
            CommandPathScrn();
        }

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            CommandOpenFolder();
        }

        #endregion


        #region ��ť���õķ���

        /// <summary>
        /// ȫ����ͼ
        /// </summary>
        private void CommandFullScrn()
        {
            // ��ȡ��Ļ����
            FullScrn.Capture();

            // �ݴ浽������
            /* 
             * Clipboard.SetImage(FullScrn.Image);
             */
            // ����ͼƬ
            FullScrn.Image.Save(Application.StartupPath + "\\FullScrn.png");
        }

        /// <summary>
        /// �����ͼ
        /// </summary>
        private void CommandRegionScrn()
        {
            // ��ȡ��Ļ��С
            Size size = Screen.PrimaryScreen.Bounds.Size;
            // ������Ļ����
            Image image = new Bitmap(size.Width, size.Height);
            Graphics g = Graphics.FromImage(image);
            g.CopyFromScreen(0, 0, 0, 0, size);

            g.Dispose();

            // ��ʾ�����ͼ����
            RegionForm frm = new RegionForm();
            frm.Initialize();
            frm.BackgroundImage = image;
            frm.Show();
        }

        /// <summary>
        /// ·����ͼ
        /// </summary>
        private void CommandPathScrn()
        {

        }

        /// <summary>
        /// �򿪽�ͼ����Ŀ¼���ݶ�Ϊ��������Ŀ¼��
        /// </summary>
        private void CommandOpenFolder()
        {
            Process.Start(
                Environment.GetEnvironmentVariable("WINDIR") + "\\explorer.exe", 
                Application.StartupPath);
        }

        #endregion
    }
}
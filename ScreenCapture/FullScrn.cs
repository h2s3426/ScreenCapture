using System;
using System.Windows.Forms;
using System.Drawing;

namespace ScreenCapture
{
    class FullScrn
    {
        #region Members

        private static Image _image;

        #endregion

        #region Properties

        public static Image Image
        {
            get { return _image; }
            set { _image = value; }
        }

        #endregion

        public static void Capture()
        {
            // ��ȡ��Ļ��С
            Size size = Screen.PrimaryScreen.Bounds.Size;

            // �½�λͼ������Ļ
            _image = new Bitmap(size.Width, size.Height);
            Graphics g = Graphics.FromImage(_image);

            // ����Ļ���ձ�����λͼ��
            g.CopyFromScreen(0, 0, 0, 0, size);
            g.Dispose();

            // �ݴ浽������
            /* 
             * Clipboard.SetImage(FullScrn.Image);
             */
            // ����ͼƬ
            Image.Save(Application.StartupPath + "\\FullScrn.png");
        }
    }
}

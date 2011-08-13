using System;
using System.Windows.Forms;
using System.Drawing;

namespace ScreenCapture
{
    /// <summary>
    /// ������ͼ���󹤾ߵĻ���
    /// </summary>
    abstract class ToolObject : Tool
    {
        private Cursor cursor;

        /// <summary>
        /// ���ߵĹ��
        /// </summary>
        protected Cursor Cursor
        {
            get { return cursor; }
            set { cursor = value; }
        }

        /// <summary>
        /// �ͷ�������
        /// �ı���ƶ���Ĵ�С
        /// </summary>
        /// <param name="regionForm"></param>
        /// <param name="e"></param>
        public override void OnMouseUp(RegionForm regionForm, MouseEventArgs e)
        {
            regionForm.DrawRectangle.Normalize();
            // �л����϶�ģʽ
            regionForm.ActiveTool = RegionForm.RegionToolType.Pointer;

            regionForm.Capture = false;
            regionForm.Refresh();
        }

        /// <summary>
        /// ������������ʱ����
        /// ����ָ����ͼ����
        /// </summary>
        /// <param name="regionForm"></param>
        /// <param name="o"></param>
        protected void ChangeObject(RegionForm regionForm, DrawRectangle o)
        {
            regionForm.DrawRectangle = o;

            regionForm.Capture = true;
            regionForm.Refresh();
        }
    }
}

using System;
using System.Windows.Forms;
using System.Drawing;

namespace ScreenCapture
{
    /// <summary>
    /// ���ι��ߣ�������ͼ���󹤾ߵĻ���
    /// </summary>
    class ToolRectangle : Tool
    {
        private Cursor cursor;

        #region ����

        /// <summary>
        /// ���ߵĹ��
        /// </summary>
        protected Cursor Cursor
        {
            get { return cursor; }
            set { cursor = value; }
        }

        #endregion

        #region ���췽��

        public ToolRectangle()
        {
            Cursor = Cursors.Default;
        }

        #endregion

        #region ����¼�����

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

        public override void OnMouseDown(RegionForm regionForm, MouseEventArgs e)
        {
            ChangeObject(regionForm, new DrawRectangle(e.X, e.Y, 1, 1));
        }

        public override void OnMouseMove(RegionForm regionForm, MouseEventArgs e)
        {
            regionForm.Cursor = Cursor;

            if ( e.Button == MouseButtons.Left )
            {
                Point point = new Point(e.X, e.Y);
                regionForm.DrawRectangle.MoveHandleTo(point, 5);
                regionForm.Refresh();
            }
        }
        
        #endregion

        #region ��������

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

        #endregion
    }
}

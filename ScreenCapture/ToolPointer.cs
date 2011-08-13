using System;
using System.Windows.Forms;
using System.Drawing;

namespace ScreenCapture
{
    /// <summary>
    /// ָ�빤��
    /// </summary>
    class ToolPointer : Tool
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

        private enum SelectionMode
        {
            None,
            Move,       // �ƶ�����
            Size        // �϶�����
        }

        private SelectionMode selectMode = SelectionMode.None;

        // ��ǰҪ�϶��Ķ���
        private DrawRectangle resizedObject;
        private int resizedObjectHandle;

        // ������һ���͵�ǰ���״̬�������ƶ����϶�����
        private Point lastPoint = new Point(0, 0);
        private Point startPoint = new Point(0, 0);

        bool wasMove;

        /// <summary>
        /// ����������
        /// </summary>
        /// <param name="regionForm"></param>
        /// <param name="e"></param>
        public override void OnMouseDown(RegionForm regionForm, MouseEventArgs e)
        {
            wasMove = false;

            selectMode = SelectionMode.None;
            Point point = new Point(e.X, e.Y);

            int handleNumber = regionForm.DrawRectangle.HitTest(point);

            if (handleNumber > 0)
            {
                selectMode = SelectionMode.Size;


                resizedObject = regionForm.DrawRectangle;
                resizedObjectHandle = handleNumber;
            }

            if (selectMode == SelectionMode.None)
            {
                DrawRectangle o = null;

                if (regionForm.DrawRectangle.HitTest(point) == 0)
                {
                    o = regionForm.DrawRectangle;
                }

                if (o != null)
                {
                    selectMode = SelectionMode.Move;

                    regionForm.Cursor = Cursors.SizeAll;
                }
            }

            lastPoint.X = e.X;
            lastPoint.Y = e.Y;
            startPoint.X = e.X;
            startPoint.Y = e.Y;

            regionForm.Capture = true;

            regionForm.Refresh();
        }

        /// <summary>
        /// �ƶ����
        /// δ�����κμ����߰������
        /// </summary>
        /// <param name="regionForm"></param>
        /// <param name="e"></param>
        public override void OnMouseMove(RegionForm regionForm, MouseEventArgs e)
        {
            Point point = new Point(e.X, e.Y);
            Point oldPoint = lastPoint;

            wasMove = true;

            if (e.Button == MouseButtons.None)
            {
                Cursor cursor = null;

                int n = regionForm.DrawRectangle.HitTest(point);

                if (n > 0)
                {
                    cursor = regionForm.DrawRectangle.GetHandleCursor(n);
                }

                if (cursor == null)
                {
                    cursor = Cursors.Default;
                }

                regionForm.Cursor = cursor;

                return;
            }

            if (e.Button != MouseButtons.Left)
            {
                return;
            }

            // �������


            // �ҳ���һλ�ú͵�ǰλ�õĲ���
            int dx = e.X - lastPoint.X;
            int dy = e.Y - lastPoint.Y;

            lastPoint.X = e.X;
            lastPoint.Y = e.Y;

            // �϶�
            if (selectMode == SelectionMode.Size)
            {
                if (resizedObject != null)
                {
                    resizedObject.MoveHandleTo(point, resizedObjectHandle);
                    regionForm.Refresh();
                }
            }

            // �ƶ�
            if (selectMode == SelectionMode.Move)
            {
                regionForm.DrawRectangle.Move(dx, dy);

                regionForm.Cursor = Cursors.SizeAll;
                regionForm.Refresh();
            }
        }

        /// <summary>
        /// �ͷ�����Ҽ�
        /// </summary>
        /// <param name="regionForm"></param>
        /// <param name="e"></param>
        public override void OnMouseUp(RegionForm regionForm, MouseEventArgs e)
        {
            if (resizedObject != null)
            {
                // after resizing
                resizedObject.Normalize();
                resizedObject = null;
            }

            regionForm.Capture = false;
            regionForm.Refresh();
        }
    
        /// <summary>
        /// ˫��������
        /// </summary>
        /// <param name="regionForm"></param>
        /// <param name="e"></param>
        public override void OnMouseDoubleClick(RegionForm regionForm, MouseEventArgs e)
        {
            // ��ȡ��������
            Rectangle rect = ((DrawRectangle)regionForm.DrawRectangle).Rectangle;
            // �½�λͼ�����������
            Image = new Bitmap(rect.Width, rect.Height);
            Graphics g = Graphics.FromImage(_image);

            // ��������ձ�����λͼ��
            g.DrawImage(regionForm.BackgroundImage, 0, 0, rect, GraphicsUnit.Pixel);

            g.Dispose();

            // �ݴ浽������
            /* 
             * Clipboard.SetImage(FullScrn.Image);
             */
            // ����ͼƬ
            Image.Save(Application.StartupPath + "\\RegionScrn.png");
        }
    }
}

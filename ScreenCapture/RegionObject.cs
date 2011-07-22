using System;
using System.Windows.Forms;
using System.Drawing;

namespace ScreenCapture
{
    /// <summary>
    /// ���л��ƶ���Ļ���
    /// </summary>
    public abstract class RegionObject
    {
        #region ����

        /// <summary>
        /// �ϱ�������
        /// </summary>
        public virtual int HandleCount
        {
            get { return 0; }
        }

        #endregion

        #region �鷽��

        /// <summary>
        /// ���ƶ���
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        public virtual void Draw(Graphics g)
        {
        }

        /// <summary>
        /// ͨ���ϱ���ŵõ���Ӧ�ϱ�
        /// </summary>
        /// <param name="handleNumber"></param>
        /// <returns></returns>
        public virtual Point GetHandle(int handleNumber)
        {
            return new Point(0, 0);
        }

        /// <summary>
        /// ͨ���ϱ���ŵõ���Ӧ�ϱ�����
        /// </summary>
        /// <param name="handleNumber"></param>
        /// <returns></returns>
        public virtual Rectangle GetHandleRectangle(int handleNumber)
        {
            Point point = GetHandle(handleNumber);

            return new Rectangle(point.X - 3, point.Y - 3, 7, 7);
        }

        /// <summary>
        /// �����ϱ�
        /// </summary>
        /// <param name="g"></param>
        public virtual void DrawTracker(Graphics g)
        {
            SolidBrush brush = new SolidBrush(Color.Black);

            for ( int i = 1; i <= HandleCount; i++ )
            {
                g.FillRectangle(brush, GetHandleRectangle(i));
            }

            brush.Dispose();
        }

        /// <summary>
        /// Hit test.
        /// Return value: -1 - no hit
        ///                0 - hit anywhere
        ///                > 1 - handle number
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public virtual int HitTest(Point point)
        {
            return -1;
        }

        /// <summary>
        /// �жϵ��Ƿ��ڶ����ڲ�
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        protected virtual bool PointInObject(Point point)
        {
            return false;
        }

        /// <summary>
        /// ��ȡ�ϱ��Ĺ��
        /// </summary>
        /// <param name="handleNumber"></param>
        /// <returns></returns>
        public virtual Cursor GetHandleCursor(int handleNumber)
        {
            return Cursors.Default;
        }

        /// <summary>
        /// �ƶ�����
        /// </summary>
        /// <param name="deltaX"></param>
        /// <param name="deltaY"></param>
        public virtual void Move(int deltaX, int deltaY)
        {
        }

        /// <summary>
        /// �ƶ��ϱ���ָ����
        /// </summary>
        /// <param name="point"></param>
        /// <param name="handleNumber"></param>
        public virtual void MoveHandleTo(Point point, int handleNumber)
        {
        }

        /// <summary>
        /// Normalize object.
        /// �ڶ���ı��С��֮�����
        /// </summary>
        public virtual void Normalize()
        {
        }

        #endregion
    }
}

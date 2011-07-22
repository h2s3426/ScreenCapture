using System;
using System.Windows.Forms;
using System.Drawing;

namespace ScreenCapture
{
    /// <summary>
    /// ���л��ƹ��ߵĻ���
    /// </summary>
    abstract class Tool
    {
        /// <summary>
        /// ����������
        /// </summary>
        /// <param name="regionForm"></param>
        /// <param name="e"></param>
        public virtual void OnMouseDown(RegionForm regionForm, MouseEventArgs e)
        {
        }

        /// <summary>
        /// �����������δ���κμ�ʱ�ƶ����
        /// </summary>
        /// <param name="regionForm"></param>
        /// <param name="e"></param>
        public virtual void OnMouseMove(RegionForm regionForm, MouseEventArgs e)
        {
        }

        /// <summary>
        /// �ͷ�������
        /// </summary>
        /// <param name="regionForm"></param>
        /// <param name="e"></param>
        public virtual void OnMouseUp(RegionForm regionForm, MouseEventArgs e)
        {
        }

        /// <summary>
        /// ˫��������
        /// </summary>
        /// <param name="regionForm"></param>
        /// <param name="e"></param>
        public virtual void OnMouseDoubleClick(RegionForm regionForm, MouseEventArgs e)
        {
        }
    }
}

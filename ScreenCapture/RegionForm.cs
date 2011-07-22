using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ScreenCapture
{
    public partial class RegionForm : Form
    {
        #region ���췽��

        public RegionForm()
        {
            InitializeComponent();
        }

        #endregion

        #region ö��

        public enum RegionToolType
        {
            Pointer,
            Rectangle,
            NumberOfRegionTools
        };

        #endregion

        #region ��Ա

        private RegionObject regionObject;  // ���ƶ���

        private RegionToolType activeTool;  // ��ǰ���ƹ���
        private Tool[] tools;               // ��������

        #endregion

        #region ����

        /// <summary>
        /// ��ǰ���ƹ���
        /// </summary>
        public RegionToolType ActiveTool
        {
            get { return activeTool; }
            set { activeTool = value; }
        }

        /// <summary>
        /// �����ͼ��״
        /// </summary>
        public RegionObject RegionObject
        {
            get { return regionObject; }
            set { regionObject = value; }
        }

        #endregion

        #region �¼�����

        /// <summary>
        /// ����������״
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RegionForm_Paint(object sender, PaintEventArgs e)
        {
            if (regionObject != null)
            {
                regionObject.Draw(e.Graphics);
            }
        }

        /// <summary>
        /// ���ͷ��������¼����ݸ���ǰ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RegionForm_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                tools[(int)activeTool].OnMouseUp(this, e);
            }
        }

        /// <summary>
        /// �Ѱ�ס�������ƶ��Ͳ������ƶ��¼����ݸ���ǰ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RegionForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.None)
            {
                tools[(int)activeTool].OnMouseMove(this, e);
            }
            else
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// �����������¼����ݸ���ǰ����
        /// ��������Ҽ��¼�ֱ�ӹرձ�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RegionForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                tools[(int)activeTool].OnMouseDown(this, e);
            }
            else if (e.Button == MouseButtons.Right)
            {
                this.Close();
                this.Dispose();
            }
        }

        /// <summary>
        /// ������ƶ��������Ӧ��ͼƬ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RegionForm_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Rectangle rect = ((RegionRectangle)RegionObject).Rectangle;
                if (rect.Contains(new Point(e.X, e.Y)))
                {
                    tools[(int)activeTool].OnMouseDoubleClick(this, e);
                    this.Close();
                    this.Dispose();
                }
            }
        }

        #endregion


        #region ��������

        /// <summary>
        /// ��ʼ��
        /// </summary>
        public void Initialize()
        {
            SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.OptimizedDoubleBuffer, 
                true);

            // �������ƹ���
            tools = new Tool[(int)RegionToolType.NumberOfRegionTools];
            tools[(int)RegionToolType.Pointer] = new ToolPointer();
            tools[(int)RegionToolType.Rectangle] = new ToolRectangle();
        }

        #endregion
    }
}
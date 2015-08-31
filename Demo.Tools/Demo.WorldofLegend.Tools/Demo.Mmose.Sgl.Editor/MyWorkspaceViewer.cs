using System;
using System.Text;
using System.Collections.Generic;
using Atalasoft.Imaging.WinControls;
using System.Drawing;
using System.Windows.Forms;
using Demo.GOSE.SGL.Editor;

namespace Demo.Mmose.Sgl.Editor
{
    public class MyWorkspaceViewer : WorkspaceViewer
    {
        /// <summary>
        /// 
        /// </summary>
        public OpenImageControl m_OpenImageControl = null;

        /// <summary>
        /// 
        /// </summary>
        public MyWorkspaceViewer()
        {
            //base.ScrollPosition = new Point( 0, 0 );
        }

        /// <summary>
        /// 
        /// </summary>
        public Point m_Point = new Point( 0, 0 );
        public bool m_IsFirst = true;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourceRectangle"></param>
        /// <param name="destRectangle"></param>
        /// <param name="graphics"></param>
        protected override void OnImageDraw( Rectangle sourceRectangle, Rectangle destRectangle, Graphics graphics )
        {
            if ( m_IsFirst == true )
            {
                m_IsFirst = false;
                base.OnImageDraw( sourceRectangle, destRectangle, graphics );
            }
            else
            {
                Point point = new Point( m_Point.X - destRectangle.Size.Width / 2, m_Point.Y - destRectangle.Size.Height / 2 );

                Rectangle rectangle = new Rectangle( point, destRectangle.Size );
                base.OnImageDraw( sourceRectangle, rectangle, graphics );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseMove( MouseEventArgs e )
        {
            if ( e.Button == MouseButtons.Left && m_OpenImageControl.IsOpenImage )
            {
                m_Point = e.Location;

                m_OpenImageControl.axFlatEditX.Text = m_Point.X.ToString();
                m_OpenImageControl.axFlatEditY.Text = m_Point.Y.ToString();

                this.Invalidate();
            }

            base.OnMouseMove( e );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseDown( MouseEventArgs e )
        {
            base.OnMouseDown( e );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseMovePixel( MouseEventArgs e )
        {

            base.OnMouseMovePixel( e );
        }
    }
}

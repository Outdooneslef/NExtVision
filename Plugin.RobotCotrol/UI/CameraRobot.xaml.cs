﻿using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VisionCore;

namespace Plugin.RobotCotrol
{
    /// <summary>
    /// CameraRobot.xaml 的交互逻辑
    /// </summary>
    public partial class CameraRobot : UserControl
    {

        private ModuleObj frm_ModuleObj;

        public CameraRobot(ModuleObj frm_ModuleObj)
        {
            InitializeComponent();
            this.DataContext = this;
            this.frm_ModuleObj = frm_ModuleObj;
            //模块当前ID
            CurrentModelID = frm_ModuleObj.ModuleParam.ModuleName;
            if (!frm_ModuleObj.blnNewModule)
            {
                theFirsttime();
            }
            else
            {
                theSecondTime();
            }
        }

        public void theFirsttime() { }

        public void theSecondTime()
        {
            InputImage_x = frm_ModuleObj.m_InputImgX;   //输入图像坐标X
            InputImage_y = frm_ModuleObj.m_InputImgY;   //输入图像坐标Y
            InPutPhi = frm_ModuleObj.m_InputPhi;        //输入角度

            Tran_x = frm_ModuleObj.m_InputTranX;          //X平移
            Tran_y = frm_ModuleObj.m_InputTranY;          //Y平移
            Supple_Angle = frm_ModuleObj.m_InputSupple_Angle;    //补偿角度

        }

        #region 当前模块ID

        /// <summary>
        /// 当前模块ID
        /// </summary>
        public string CurrentModelID
        {
            get { return (string)this.GetValue(CurrentModelIDProperty); }
            set { this.SetValue(CurrentModelIDProperty, value); }
        }

        public static readonly DependencyProperty CurrentModelIDProperty =
            DependencyProperty.Register("CurrentModelID", typeof(string), typeof(CameraRobot), new PropertyMetadata(default(string)));

        #endregion

        #region 输入图像坐标X

        public string InputImage_x
        {
            get { return (string)this.GetValue(InputImage_xProperty); }
            set { this.SetValue(InputImage_xProperty, value); }
        }

        public static readonly DependencyProperty InputImage_xProperty =
            DependencyProperty.Register("InputImage_x", typeof(string), typeof(CameraRobot), new PropertyMetadata(default(string)));

        /// <summary>
        /// 获取变量，传入图像显示窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Gen_InputImageX_EValueAlarm(object sender, RoutedEventArgs e)
        {
            ModuleDataVar.DataVar data = (ModuleDataVar.DataVar)e.OriginalSource;
            //数据不为空，且是图像类型
            if (data.m_DataValue != null && data.m_DataType == ModuleDataVar.DataVarType.DataType.Double)
            {
                try
                {
                    frm_ModuleObj.m_InputImgX = data.m_DataTip + "." + data.m_DataName;
                    frm_ModuleObj.Link_InputImgX = data;
                }
                catch (Exception ex)
                {
                    Log.Error(ex.ToString());
                }
            }
        }

        #endregion

        #region 输入图像坐标Y

        public string InputImage_y
        {
            get { return (string)this.GetValue(InputImage_yProperty); }
            set { this.SetValue(InputImage_yProperty, value); }
        }

        public static readonly DependencyProperty InputImage_yProperty =
            DependencyProperty.Register("InputImage_y", typeof(string), typeof(CameraRobot), new PropertyMetadata(default(string)));

        /// <summary>
        /// 获取变量，传入图像显示窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Gen_InputImageY_EValueAlarm(object sender, RoutedEventArgs e)
        {
            ModuleDataVar.DataVar data = (ModuleDataVar.DataVar)e.OriginalSource;
            //数据不为空，且是图像类型
            if (data.m_DataValue != null && data.m_DataType == ModuleDataVar.DataVarType.DataType.Double)
            {
                try
                {
                    frm_ModuleObj.m_InputImgY = data.m_DataTip + "." + data.m_DataName;
                    frm_ModuleObj.Link_InputImgY = data;
                }
                catch (Exception ex)
                {
                    Log.Error(ex.ToString());
                }
            }
        }

        #endregion

        #region 输入角度

        public string InPutPhi
        {
            get { return (string)this.GetValue(InPutPhiProperty); }
            set { this.SetValue(InPutPhiProperty, value); }
        }

        public static readonly DependencyProperty InPutPhiProperty =
            DependencyProperty.Register("InPutPhi", typeof(string), typeof(CameraRobot), new PropertyMetadata(default(string)));

        /// <summary>
        /// 获取变量，传入图像显示窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Gen_InpuPhi_EValueAlarm(object sender, RoutedEventArgs e)
        {
            ModuleDataVar.DataVar data = (ModuleDataVar.DataVar)e.OriginalSource;
            //数据不为空，且是图像类型
            if (data.m_DataValue != null && data.m_DataType == ModuleDataVar.DataVarType.DataType.Double)
            {
                try
                {
                    frm_ModuleObj.m_InputPhi = data.m_DataTip + "." + data.m_DataName;
                    frm_ModuleObj.Link_InputPhi = data;
                }
                catch (Exception ex)
                {
                    Log.Error(ex.ToString());
                }
            }
        }

        #endregion

        #region X平移

        public string Tran_x
        {
            get { return (string)this.GetValue(Tran_xProperty); }
            set { this.SetValue(Tran_xProperty, value); }
        }

        public static readonly DependencyProperty Tran_xProperty =
            DependencyProperty.Register("Tran_x", typeof(string), typeof(CameraRobot), new PropertyMetadata(default(string)));

        /// <summary>
        /// 获取变量，传入图像显示窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Gen_Tran_x_EValueAlarm(object sender, RoutedEventArgs e)
        {
            ModuleDataVar.DataVar data = (ModuleDataVar.DataVar)e.OriginalSource;
            //数据不为空，且是图像类型
            if (data.m_DataValue != null && data.m_DataType == ModuleDataVar.DataVarType.DataType.Double)
            {
                try
                {
                    frm_ModuleObj.m_InputTranX = data.m_DataTip + "." + data.m_DataName;
                    frm_ModuleObj.Link_InputTranX = data;
                }
                catch (Exception ex)
                {
                    Log.Error(ex.ToString());
                }
            }
        }

        #endregion

        #region Y平移

        public string Tran_y
        {
            get { return (string)this.GetValue(Tran_yProperty); }
            set { this.SetValue(Tran_yProperty, value); }
        }

        public static readonly DependencyProperty Tran_yProperty =
            DependencyProperty.Register("Tran_y", typeof(string), typeof(CameraRobot), new PropertyMetadata(default(string)));

        /// <summary>
        /// 获取变量，传入图像显示窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Gen_Tran_y_EValueAlarm(object sender, RoutedEventArgs e)
        {
            ModuleDataVar.DataVar data = (ModuleDataVar.DataVar)e.OriginalSource;
            //数据不为空，且是图像类型
            if (data.m_DataValue != null && data.m_DataType == ModuleDataVar.DataVarType.DataType.Double)
            {
                try
                {
                    frm_ModuleObj.m_InputTranY = data.m_DataTip + "." + data.m_DataName;
                    frm_ModuleObj.Link_InputTranY = data;
                }
                catch (Exception ex)
                {
                    Log.Error(ex.ToString());
                }
            }
        }

        #endregion

        #region 补偿角度

        public string Supple_Angle
        {
            get { return (string)this.GetValue(Supple_AngleProperty); }
            set { this.SetValue(Supple_AngleProperty, value); }
        }

        public static readonly DependencyProperty Supple_AngleProperty =
            DependencyProperty.Register("Supple_Angle", typeof(string), typeof(CameraRobot), new PropertyMetadata(default(string)));

        /// <summary>
        /// 获取变量，传入图像显示窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Gen_Supple_Angle_EValueAlarm(object sender, RoutedEventArgs e)
        {
            ModuleDataVar.DataVar data = (ModuleDataVar.DataVar)e.OriginalSource;
            //数据不为空，且是图像类型
            if (data.m_DataValue != null && data.m_DataType == ModuleDataVar.DataVarType.DataType.Double)
            {
                try
                {
                    frm_ModuleObj.m_InputSupple_Angle = data.m_DataTip + "." + data.m_DataName;
                    frm_ModuleObj.Link_InputSupple_Angle = data;
                }
                catch (Exception ex)
                {
                    Log.Error(ex.ToString());
                }
            }
        }

        #endregion

    }
}

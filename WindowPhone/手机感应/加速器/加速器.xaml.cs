using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Devices.Sensors;

namespace Study.手机感应
{
    public partial class 加速器 : PhoneApplicationPage
    {
        private Accelerometer _ac;
        public 加速器()
        {
            InitializeComponent();
            _ac = new Accelerometer();

            //设置应用的方向为水平方向
            SupportedOrientations = SupportedPageOrientation.Portrait;

            //把球放在中间
            ball.SetValue(Canvas.LeftProperty,ContentGird.Width/2);
            ball.SetValue(Canvas.TagProperty,ContentGird.Height/2);

            //绑定加速器的值变化
            //_ac.CurrentValueChanged += ac_CurrentValueChanged;
            _ac.CurrentValueChanged += new EventHandler<SensorReadingEventArgs<AccelerometerReading>>(ac_CurrentValueChanged);

            //启动加速器
            _ac.Start();
         
        }

        private void ac_CurrentValueChanged(object sender, SensorReadingEventArgs<AccelerometerReading> e)
        {
			//启动UI线程进行界面更新
            Deployment.Current.Dispatcher.BeginInvoke(() => MyCurrentValueChanged(e));
        }



        private void MyCurrentValueChanged(SensorReadingEventArgs<AccelerometerReading> e)
        {
           
            double accelerationFactor = Math.Abs(e.SensorReading.Acceleration.Z) == 0 ? 0.1 : Math.Abs(e.SensorReading.Acceleration.Z);
            double X = e.SensorReading.Acceleration.X;
            double Y = e.SensorReading.Acceleration.Y;
            double Z = e.SensorReading.Acceleration.Z;


            double ballX = (double)ball.GetValue(Canvas.LeftProperty) + X / accelerationFactor;
            double ballY = (double)ball.GetValue(Canvas.TopProperty) - Y / accelerationFactor;
            double ballZ = (double)ball.GetValue(Canvas.HeightProperty) - Z / 10;
            if (ballX < 0)
            { 
                ballX = 0;
            } 
            else if (ballX > ContentGird.Width)
            {
                ballX = ContentGird.Width;
            } 
            if (ballY < 0) 
            { 
                ballY = 0;
            } 
            else if (ballY > ContentGird.Height)
            { 
                ballY = ContentGird.Height;
            }

            if (ballZ < 0)
            {
                ballZ = 10;
            }
            else if (ballZ > ContentGird.Width)
            {
                ballZ = ContentGird.Width;
            } 

            ball.SetValue(Canvas.LeftProperty, ballX);
            ball.SetValue(Canvas.TopProperty, ballY);
            ball.SetValue(Canvas.WidthProperty, ballZ);
            ball.SetValue(Canvas.HeightProperty, ballZ);
        }
    }
}
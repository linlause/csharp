//#define  BYTEQQ

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//指示詞
using System.IO.Ports;
using System.Threading;
using System.Timers;


namespace SerialQQ
{
    

    
    public partial class Form1 : Form
    {
        //console 參數
        private SerialPort My_SerialPort;
        private bool Console_receiving = false;
        private Thread t;
        //使用委派顯示 Console 畫面
        delegate void Display(Byte[] buffer);

        Motor motor1;
        Motor motor2;
        
        public int iSpeed;
        public int iPulses_One_Rev;
       
        public int exec_count;
        public int mode;
        public int com_status;
        public bool compensation;
        public bool stealthChop;
        private static System.Timers.Timer aTimer;
        //FileStream fs;
        //StreamWriter sw;


        System.Diagnostics.Stopwatch sw;

        public Form1()
        {
            InitializeComponent();
        }

        // process mcu respond code
        public void process_complete_respond(Byte[] buffer)
        {

            //Console_Output.AppendText(String.Format("{0} * {1}  {2}", buffer.Length, BitConverter.ToString(buffer), Environment.NewLine));
            //return;
            
            if (buffer[0] == 0xff)
            {

                //Console_Output.AppendText(String.Format("Pan/Tilt ACK{0}{1}{2}", buffer.Length, BitConverter.ToString(buffer), Environment.NewLine));
                Byte start_Byte;
                Byte ID_Byte = 0;
                int len = 0;
               // int checksum = 0;
               // string respond_str;

                start_Byte = buffer[0];

                if (buffer.Length >= 2)
                    ID_Byte = buffer[1];

                if (buffer.Length >= 3)
                    len = buffer[2];

                if (buffer.Length == (len + 4))
                {
                    switch (ID_Byte)
                    {
                        case 0x81:

                            Console_Output.AppendText(String.Format("m1/m2 ACK" + Environment.NewLine));
                            break;
                        case 0x8f://get pan/tilt position response hexValues = "FF 8F 08 80 16 00 00 6B 0A 00 00 A1"; 
#if  (BYTEQQ)
                            Console_Output.AppendText(String.Format("Debug {0}{1}", BitConverter.ToString(buffer), Environment.NewLine));
#endif
                            int qint;
                            int diff_angle;
                            int diff_velo;
                            int pDrv;
                            int tDrv;
                            int ipSG_RESULT;
                            int ipCSCURRENT;
                            int ipStallGuard;
                            int ipOverTemperature;
                            int itSG_RESULT;
                            int itCSCURRENT;
                            int itStallGuard;
                            int itOverTemperature;

                            qint = 0;
                            qint = Convert.ToInt32(buffer[3]);
                            qint += Convert.ToInt32(buffer[4]) << 8;
                            qint += Convert.ToInt32(buffer[5]) << 16;
                            qint += Convert.ToInt32(buffer[6]) << 24;
                            diff_angle = qint - motor1.iAngle;
                            this.motor1.iAngle = qint;

                            qint = 0;
                            qint = Convert.ToInt32(buffer[7]);
                            qint += Convert.ToInt32(buffer[8]) << 8;
                            qint += Convert.ToInt32(buffer[9]) << 16;
                            qint += Convert.ToInt32(buffer[10]) << 24;
                            this.motor2.iAngle = qint;

                            qint = 0;
                            qint = Convert.ToInt32(buffer[11]);
                            qint += Convert.ToInt32(buffer[12]) << 8;
                            qint += Convert.ToInt32(buffer[13]) << 16;
                            if (qint >= 16711680)
                                qint = -1 * (16777215 - qint + 1);

                            diff_velo = qint - motor1.iVelocity;

                            this.motor1.iVelocity = qint;

                            qint = 0;
                            qint = Convert.ToInt32(buffer[14]);
                            qint += Convert.ToInt32(buffer[15]) << 8;
                            qint += Convert.ToInt32(buffer[16]) << 16;
                            if (qint >= 16711680)
                                qint = -1 * (16777215 - qint + 1);
                            this.motor2.iVelocity = qint;


                            qint = 0;
                            qint = Convert.ToInt32(buffer[17]);
                            qint += Convert.ToInt32(buffer[18]) << 8;
                            qint += Convert.ToInt32(buffer[19]) << 16;
                            qint += Convert.ToInt32(buffer[20]) << 24;
                            pDrv = qint;
                            ipSG_RESULT = pDrv & 0x3FF;
                            ipCSCURRENT = (pDrv >> 16) & 0x1F;
                            ipStallGuard = (pDrv >> 24) & 0x1;
                            ipOverTemperature = (pDrv >> 25) & 0x3;
                            qint = 0;
                            qint = Convert.ToInt32(buffer[21]);
                            qint += Convert.ToInt32(buffer[22]) << 8;
                            qint += Convert.ToInt32(buffer[23]) << 16;
                            qint += Convert.ToInt32(buffer[24]) << 24;
                            tDrv = qint;
                            itSG_RESULT = tDrv & 0x3FF;
                            itCSCURRENT = (tDrv >> 16) & 0x1F;
                            itStallGuard = (tDrv >> 24) & 0x1;
                            itOverTemperature = (tDrv >> 25) & 0x3;

                            motor1.aAngle[exec_count] = motor1.iAngle;
                            motor2.aAngle[exec_count] = motor2.iAngle;
                            motor1.aVelocity[exec_count] = motor1.iVelocity;
                            motor2.aVelocity[exec_count] = motor2.iVelocity;

                            motor1.atSG_RESULT[exec_count] = pDrv;

                            motor2.atSG_RESULT[exec_count] = tDrv;
                           

                            exec_count++;
                            //Console_Output.AppendText(String.Format("Pan Angle:" + Convert.ToString(motor1.iAngle) + "Tilt Angle:" + Convert.ToString(motor2.iAngle) + "Pan vel:" + Convert.ToString(motor1.iVelocity) + "Tilt vel:" + Convert.ToString(motor2.iVelocity) + Environment.NewLine));
                            Console_Output.AppendText(String.Format("m1Angle:  " + Convert.ToString(motor1.iAngle) + "  diff Angle:  " + Convert.ToString(diff_angle) + "  m1 vel:  " + Convert.ToString(motor1.iVelocity) + "  diff vel:  " + Convert.ToString(diff_velo) + "  drv:  " + Convert.ToString(ipSG_RESULT) + "  cur:  " + Convert.ToString(ipCSCURRENT) + "  st:  " + Convert.ToString(ipStallGuard) + "  ot:  " + Convert.ToString(ipOverTemperature) + Environment.NewLine));
                            Console_Output.AppendText(String.Format("m2Angle:  " + Convert.ToString(motor2.iAngle) + "  diff Angle:  " + Convert.ToString(diff_angle) + "  m2 vel:  " + Convert.ToString(motor2.iVelocity) + "  diff vel:  " + Convert.ToString(diff_velo) + "  drv:  " + Convert.ToString(itSG_RESULT) + "  cur:  " + Convert.ToString(itCSCURRENT) + "  st:  " + Convert.ToString(itStallGuard) + "  ot:  " + Convert.ToString(itOverTemperature) + Environment.NewLine));
                            update_position(diff_angle);
                            update_compensation(diff_angle);
                            break;
                        case 0xD0://UART printf//get pan/tilt position response hexValues = "FF 8F 08 80 16 00 00 6B 0A 00 00 A1"; 
                            Console_Output.AppendText(String.Format("QQ {0}{1}", BitConverter.ToString(buffer), Environment.NewLine));
                           
                            byte value;
                            value = buffer[3];

                            if (len == 2)
                            {
                                /*
                                 QQ FF-D0-02-50-0A-00
                                 QQ FF-D0-02-54-0A-00
                                 */
                                if (value == 0x50)
                                { //Console_Output.AppendText(String.Format("PI P{0}", Environment.NewLine));
                                    motor1.iPICount++;
                                    lbl_pPI.Text = string.Format("PI: ") + Convert.ToString(motor1.iPICount);
                                }

                                if (value == 0x54)
                                { //Console_Output.AppendText(String.Format("PI P{0}", Environment.NewLine));
                                    motor2.iPICount++;
                                    lbl_tPI.Text = string.Format("PI: ") + Convert.ToString(motor2.iPICount);
                                } 
                                
                            }


                            break;
                        case 0x92://report motor state
                            Console_Output.AppendText(String.Format("{0}{1}", BitConverter.ToString(buffer), Environment.NewLine));
                            qint = 0;
                            qint = Convert.ToInt32(buffer[3]);
                            update_status(qint);

                            if ((compensation) && (mode != 1) && (buffer[3] == 0x00))
                                do_compensation();
                            
                            break;

                    }
                }


            }
        }
     
        
          public void parse_respond(Byte[] buffer)
        {
            int ibloop;
            int len = 0;

            for (ibloop = 0; ibloop < buffer.Length; ibloop++)
            {
                if (buffer[ibloop] == 0xff)
                {

                    //Console_Output.AppendText(String.Format("Pan/Tilt ACK{0}{1}{2}", buffer.Length, BitConverter.ToString(buffer), Environment.NewLine));
                    Byte start_Byte;
                    Byte ID_Byte = 0;
                    len = 0;
                   // int checksum = 0;
                    //string respond_str;

                    start_Byte = buffer[ibloop];

                    if ((buffer.Length - ibloop) >= 2)
                        ID_Byte = buffer[ibloop + 1];

                    if ((buffer.Length - ibloop) >= 3)
                        len = buffer[ibloop + 2];

                    if ((buffer.Length - ibloop) >= (len + 4))
                    {
                        Byte[] pbuf = new Byte[len + 4];
                        int iloop;
                        for (iloop = 0; iloop < (len + 4); iloop++)
                        {
                            pbuf[iloop] = buffer[ibloop+iloop];
                        }
                        process_complete_respond(pbuf);
                    }
                    ibloop =ibloop + len+3;
                }
            }
        }
        

        public void ConsoleShow(Byte[] buffer)
        {
   
 //           Console_Output.AppendText( String.Format("{0}{1}", BitConverter.ToString(buffer), Environment.NewLine));
            parse_respond(buffer);
 
        }

        //判斷TextBox輸入值是否為數字
         public static bool IsNumeric( string TextBoxValue)
         {
             try
             {
                 int i = Convert .ToInt32(TextBoxValue);
                 return true ;
             }
             catch
            {
                return false ;
            }
         }
     
        //連接 Console
        public void Console_Connect(string COM, Int32 baud)
        {
            try
            {
                My_SerialPort = new SerialPort();

                if (My_SerialPort.IsOpen)
                {
                    My_SerialPort.Close();
                }

                //設定 Serial Port 參數
                My_SerialPort.PortName = COM;
                My_SerialPort.BaudRate = baud;
                My_SerialPort.DataBits = 8;
                My_SerialPort.StopBits = StopBits.One;

                if (!My_SerialPort.IsOpen)
                {
                    //開啟 Serial Port
                    My_SerialPort.Open();

                    Console_receiving = true;

                    //開啟執行續做接收動作
                    t = new Thread(DoReceive);
                    t.IsBackground = true;
                    t.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //關閉 Console
        public void CloseComport()
        {
            try
            {
                My_SerialPort.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Console 接收資料
        private void DoReceive()
        {
            Byte[] buffer = new Byte[1024];

            try
            {
                while (Console_receiving)
                {
                    if (My_SerialPort.BytesToRead > 0)
                    {


                        Int32 length = My_SerialPort.Read(buffer, 0, buffer.Length);
                        Array.Resize(ref buffer, length);
                        Display d = new Display(ConsoleShow);
                        this.Invoke(d, new Object[] { buffer });
                        Array.Resize(ref buffer, 1024);

                    }

                    Thread.Sleep(10);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Console 發送資料
        public void SendData(Object sendBuffer)
        {
            if (sendBuffer != null)
            {
                Byte[] buffer = sendBuffer as Byte[];

                try
                {
                    My_SerialPort.Write(buffer, 0, buffer.Length);
                }
                catch (Exception ex)
                {
                    CloseComport();
                    MessageBox.Show(ex.Message);
                }
            }
        }


        public static byte[] FromHex(string hex)
        {
            hex = hex.Replace(" ", "");
            byte[] raw = new byte[hex.Length / 2];
            for (int i = 0; i < raw.Length; i++)
            {
                try
                {
                    raw[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
                }
                catch (System.Exception)
                {
                    //Do Nothing
                }

            }
            return raw;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Console_receiving = false;
            //關閉 Serial Port
            if (com_status==1)
            CloseComport();

       }

        private void Form1_Load(object sender, EventArgs e)
        {
            //取得存在的COM. 如果存在二個COM則是在COMPorts[0]和COMPorts[1], 以此類推
            String[] COMPorts = SerialPort.GetPortNames();

            foreach (string port in COMPorts) { comboBox1.Items.Add(port); }

            comboBox1.SelectedIndex = 0;
            motor1 = new Motor();
            motor2 = new Motor();
            //initialize speed and paulse value
            iSpeed = 55;
            iPulses_One_Rev = 89600;

            //initialize step value
            comboBox_Step.Items.Add("128");
            comboBox_Step.Items.Add("64");
            comboBox_Step.Items.Add("32");
            comboBox_Step.Items.Add("16");
            comboBox_Step.Items.Add("8");
            comboBox_Step.Items.Add("4");
            comboBox_Step.Items.Add("2");
            comboBox_Step.Items.Add("fullstep");
            comboBox_Step.SelectedIndex = 1;
            //initialize array 
            
            motor1.aAngle = new int[1024];
            motor2.aAngle = new int[1024];
            motor1.aVelocity = new int[1024];
            motor2.aVelocity = new int[1024];
            motor1.atSG_RESULT = new int[1024];
            motor2.atSG_RESULT = new int[1024];
            motor1.iPICount = 0;
            motor2.iPICount = 0;
            exec_count = 0;
            mode = 0;
            //initialize
            sw = new System.Diagnostics.Stopwatch();

            //com status
            com_status = 0;

            //compensation angle
            compensation = false;

            //
            comboBox_Acecleration.Items.Add("low");
            comboBox_Acecleration.Items.Add("medium");
            comboBox_Acecleration.Items.Add("high");

            //stealthChop
            stealthChop = false;

        }


        private void txtwrite(string str)
        {
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@".\MotoLog.txt", true))
            {
                file.WriteLine(str);
            }
        }

        private void logToFile(string str,int len,int[] angle,int[] velo,int[] iSG_RESULT)
        {
            txtwrite(str);
            int ibloop;
            for (ibloop = 0; ibloop < len; ibloop++)
            {
                string line_str;

                int ipSG_RESULT;
                int ipCSCURRENT;
                int ipStallGuard;
                int ipOverTemperature;
                int pDrv;
                pDrv = iSG_RESULT[ibloop];
                ipSG_RESULT = pDrv & 0x3FF;
                ipCSCURRENT = (pDrv >> 16) & 0x1F;
                ipStallGuard = (pDrv >> 24) & 0x1;
                ipOverTemperature = (pDrv >> 25) & 0x3;


                line_str = string.Format("angle: ") + Convert.ToString(angle[ibloop]) + string.Format(" velocity: ") + Convert.ToString(velo[ibloop]) + string.Format(" dvr: ") + Convert.ToString(ipSG_RESULT) + string.Format(" cur: ") + Convert.ToString(ipCSCURRENT) + string.Format(" stl: ") + Convert.ToString(ipStallGuard) + string.Format(" ot: ") + Convert.ToString(ipOverTemperature);
                txtwrite(line_str);
            }

        }

        public void get_position()
        {
            //送出字串
            string hexValues = "FF 0F 01 01 10";


            lbl_Status.Text = string.Format("Mode : GET POS") + Environment.NewLine + string.Format("Speed = QQ") + Environment.NewLine;


            byte[] byteArray1 = new byte[8];

            byteArray1 = FromHex(hexValues);


            My_SerialPort.Write(byteArray1, 0, 5);

        }

        //update left pannel status
        public void update_status(int status)
        {
            switch (status)
            {
                case 0:
                    sw.Stop();//碼錶停止
                    /*
                     CNT M2 MOVE CW Current ,m2Angle : 139 ,detail: 34646 ,Time eclipse = 5000.5982ms
                     */
                    lblTimeStatus.Text = string.Format(" ,Time eclipse = ") + sw.Elapsed.TotalMilliseconds.ToString() +
                        string.Format("ms") + Environment.NewLine;
                    if (mode == 2)
                    {
                        listBox1.Items.Add(string.Format("ABS M1 MOVE ") + lbl_pAngle.Text + lblTimeStatus.Text);
                        listBox1.Items.Add(string.Format("ABS M2 MOVE ") + lbl_tAngle.Text + lblTimeStatus.Text);
                        logToFile(string.Format("ABS M1 MOVE ") + lbl_pAngle.Text + lblTimeStatus.Text + lbl_pulse.Text + string.Format(" ,") + lbl_step.Text, exec_count, motor1.aAngle, motor1.aVelocity, motor1.atSG_RESULT);
                        logToFile(string.Format("ABS M2 MOVE ") + lbl_tAngle.Text + lblTimeStatus.Text + lbl_pulse.Text + string.Format(" ,") + lbl_step.Text, exec_count, motor2.aAngle, motor2.aVelocity, motor2.atSG_RESULT);
                    }
                    if (mode == 3)
                    {
                        listBox1.Items.Add(string.Format("REL M1 MOVE ") + lbl_pAngle.Text + lblTimeStatus.Text);
                        listBox1.Items.Add(string.Format("REL M2 MOVE ") + lbl_tAngle.Text + lblTimeStatus.Text);
                        logToFile(string.Format("REL M1 MOVE ") + lbl_pAngle.Text + lblTimeStatus.Text + lbl_pulse.Text + string.Format(" ,") + lbl_step.Text, exec_count, motor1.aAngle, motor1.aVelocity, motor1.atSG_RESULT);
                        logToFile(string.Format("REL M2 MOVE ") + lbl_tAngle.Text + lblTimeStatus.Text + lbl_pulse.Text + string.Format(" ,") + lbl_step.Text, exec_count, motor2.aAngle, motor2.aVelocity, motor2.atSG_RESULT);
                    }
                    break;
                case 7:
                    lblTimeStatus.Text = string.Format("Time eclipse = ") + sw.Elapsed.TotalMilliseconds.ToString() +
                        string.Format("BBBBBBBBBBB") + Environment.NewLine;
                    Console_Output.AppendText(String.Format("m1 stop" + Environment.NewLine));
                    break;
                case 8:
                    lblTimeStatus.Text = string.Format("Time eclipse = ") + sw.Elapsed.TotalMilliseconds.ToString() +
                        string.Format("BBBBBBBBBBB") + Environment.NewLine;
                    Console_Output.AppendText(String.Format("m2 stop" + Environment.NewLine));
                    break;
            }
        }

        //update left pannel status
        public void update_position(int direction)
        {

            if (direction >= 0)
            {
                lbl_pAngle.Text = string.Format("CW Current m1Angle : ") + Convert.ToString(motor1.iAngle * 360 / iPulses_One_Rev) + string.Format(" absolute pulse: ") + Convert.ToString(motor1.iAngle);
                lbl_tAngle.Text = string.Format("CW Current m2Angle : ") + Convert.ToString(motor2.iAngle * 360 / iPulses_One_Rev) + string.Format(" absolute pulse: ") + Convert.ToString(motor2.iAngle);
            }
            else
            {
                lbl_pAngle.Text = string.Format("CCW Current m1Angle : ") + Convert.ToString(motor1.iAngle * 360 / iPulses_One_Rev) + string.Format(" absolute pulse: ") + Convert.ToString(motor1.iAngle);
                lbl_tAngle.Text = string.Format("CCW Current m2Angle : ") + Convert.ToString(motor2.iAngle * 360 / iPulses_One_Rev) + string.Format(" absolute pulse: ") + Convert.ToString(motor2.iAngle);
            
            }
        }

        //update left pannel status
        public void update_compensation(int direction)
        {

            if (direction >= 0)
            {
                 compensation = false;
            }
            else
            {
            
                 compensation = true;
            }
        }
        
		public byte get_checksum(int len,byte[] byteArray1)
		{
			int i;
                byte check_sum = 0x00;
                for (i = 1; i < len; i++)
                {
                    check_sum += byteArray1[i];
                }
                check_sum--;
  			return check_sum;
		}
		
        public void do_compensation()
        { 

            compensation = false;
            int comAngle;
            comAngle = Convert.ToInt32(textBoxCompensation.Text);

            //mode = 2;
            if (comAngle > 0)
            {
                //sw.Reset();//碼表歸零

                //sw.Start();//碼表開始計時

                string hexValues = "FF 10 0A 64 00 00 19 00 00 80 70 00 00 86";
                lbl_Status.Text = string.Format("Mode : COM MOVE") + Environment.NewLine + string.Format("Speed =") + Convert.ToString(iSpeed) + Environment.NewLine;
                byte[] byteArray1 = new byte[16];

                byteArray1 = FromHex(hexValues);
                byteArray1[0] = 0xFF;//SYC Byte
                byteArray1[1] = 0x10;//ABS
                byteArray1[2] = 0x0A;//len

                int data = 55;//Int32.Parse(textBox_ASpeed.Text);
                int iPanAngleVal;
                int iTiltAngleVal;

                iPanAngleVal = (motor1.iAngle + comAngle) % iPulses_One_Rev;
                iTiltAngleVal = (motor2.iAngle + comAngle) % iPulses_One_Rev;

                //if (data < 0)
                //    data = 65535 + data + 1;
                byteArray1[3] = Convert.ToByte(data & 0xFF);// speed
                byteArray1[4] = Convert.ToByte((data >> 8) & 0xFF);// speed

                byteArray1[5] = Convert.ToByte(iPanAngleVal & 0xFF);//pan angle   2
                byteArray1[6] = Convert.ToByte((iPanAngleVal >> 8) & 0xFF);//pan angle  50
                byteArray1[7] = Convert.ToByte((iPanAngleVal >> 16) & 0xFF);//pan angle  1
                byteArray1[8] = Convert.ToByte((iPanAngleVal >> 24) & 0xFF);//pan angle

                byteArray1[9] = Convert.ToByte(iTiltAngleVal & 0xFF);//tilt angle   2
                byteArray1[10] = Convert.ToByte((iTiltAngleVal >> 8) & 0xFF);//tilt angle  50
                byteArray1[11] = Convert.ToByte((iTiltAngleVal >> 16) & 0xFF);//tilt angle  1
                byteArray1[12] = Convert.ToByte((iTiltAngleVal >> 24) & 0xFF);//tilt angle
 
				byteArray1[13] = get_checksum(13,byteArray1);//check sum

                My_SerialPort.Write(byteArray1, 0, 14);
            }
        }



/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//                              button action
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Getpos_btn_Click(object sender, EventArgs e)
        {
              get_position();
        }
        // Specify what you want to happen when the Elapsed event is raised.
        private  void OnTimedEvent(object source, ElapsedEventArgs e)
        {


            logToFile(string.Format("CNT M1 MOVE ") + lbl_pAngle.Text + lblTimeStatus.Text + lbl_pulse.Text + string.Format(" ,") + lbl_step.Text, exec_count, motor1.aAngle, motor1.aVelocity, motor1.atSG_RESULT);
            logToFile(string.Format("CNT M2 MOVE ") + lbl_tAngle.Text + lblTimeStatus.Text + lbl_pulse.Text + string.Format(" ,") + lbl_step.Text, exec_count, motor2.aAngle, motor2.aVelocity, motor2.atSG_RESULT);

            aTimer.Stop();
            aTimer.Dispose();
        }


        private void button_stop_Click(object sender, EventArgs e)
        {
            //送出字串
            string hexValues = "FF 01 04 00 00 00 00 04";


            lbl_Status.Text = string.Format("Mode : Stop ALL") + Environment.NewLine + string.Format("Speed = QQ") + Environment.NewLine;


            byte[] byteArray1 = new byte[8];

            byteArray1 = FromHex(hexValues);

            My_SerialPort.Write(byteArray1, 0, 8);

            sw.Stop();//碼錶停止
            
            lblTimeStatus.Text =  string.Format("Time eclipse = ") + sw.Elapsed.TotalMilliseconds.ToString() + 
                string.Format("ms") + Environment.NewLine;

            if (mode == 1)
            {

                listBox1.Items.Add(string.Format("CNT M1 MOVE ") + lbl_pAngle.Text + lblTimeStatus.Text);
                listBox1.Items.Add(string.Format("CNT M2 MOVE ") + lbl_tAngle.Text + lblTimeStatus.Text);
                
                // use timer function to keep latest data
                aTimer = new System.Timers.Timer();
                aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                aTimer.Interval = 2000;
                aTimer.Enabled = true;

                 
                if(compensation)
                    do_compensation();
            }
            
        }


        private void cleantxt_btn_Click(object sender, EventArgs e)
        {
            Console_Output.Clear();
        }

        private void Console_Output_KeyDown(object sender, KeyEventArgs e)
        {
            Console_Output.Select(0, Console_Output.Text.Length);
        }

        private void button_status(bool flag)
        {
            AbsMove_btn.Enabled = flag;
            CntMove_btn.Enabled = flag;
            RelMove_btn.Enabled = flag;
            Getpos_btn.Enabled = flag;
            button_stop.Enabled = flag;
            step_btn.Enabled = flag;
            drawpan_btn.Enabled = flag;
            drawtilt_btn.Enabled = flag;
            Accleration_btn.Enabled = flag;
            StealthChop_btn.Enabled = flag;

        }

        private void ComConnect_Click(object sender, EventArgs e)
        {
            //連接 Console
            //Console_Connect("COM3", 115200);comboBox1
            if (com_status == 0)
            {
                com_status = 1;
                MessageBox.Show(comboBox1.SelectedItem.ToString());
                Console_Connect(comboBox1.SelectedItem.ToString(), 115200);
                button_status(true);
         
                ComConnect.Text = "DisConnect";
            }
            else
            {
                com_status = 0;
                CloseComport();
                button_status(false);
                ComConnect.Text = "Connect";
            }
        }

        private void trackBarASpeed_Scroll(object sender, EventArgs e)
        {
            textBox_ASpeed.Text = Convert.ToString(trackBarASpeed.Value);
            iSpeed = trackBarASpeed.Value;
            lbl_pulse.Text = string.Format("Pulase Rate= ") + textBox_ASpeed.Text;
        }

        private void textBox_ASpeed_TextChanged(object sender, EventArgs e)
        {

            if (IsNumeric(textBox_ASpeed.Text))
            {
                trackBarASpeed.Value = Int32.Parse(textBox_ASpeed.Text);
                iSpeed = Convert.ToInt32(textBox_ASpeed.Text);
                lbl_pulse.Text = string.Format("Pulase Rate= ") + textBox_ASpeed.Text;
            }

        }

        private void textBoxPanAngle_TextChanged(object sender, EventArgs e)
        {
            trackBarPanAngle.Value = Int32.Parse(textBoxPanAngle.Text);
            label2.Text = string.Format("m1Angle : ") + Convert.ToString((trackBarPanAngle.Value * 360) / iPulses_One_Rev);
        }

        private void trackBarPanAngle_Scroll(object sender, EventArgs e)
        {
            textBoxPanAngle.Text = Convert.ToString(trackBarPanAngle.Value);
            label2.Text = string.Format("m1Angle : ") + Convert.ToString((trackBarPanAngle.Value * 360) / iPulses_One_Rev);
        }

        //private void textBox2_TextChanged(object sender, EventArgs e)
        private void textTiltAngle_TextChanged(object sender, EventArgs e)
        {
            trackBarTiltAngle.Value = Int32.Parse(textTiltAngle.Text);
            label3.Text = string.Format("m2Angle : ") + Convert.ToString((trackBarTiltAngle.Value * 360) / iPulses_One_Rev);
        }

        private void trackBarTiltAngle_Scroll(object sender, EventArgs e)
        {
            textTiltAngle.Text = Convert.ToString(trackBarTiltAngle.Value);
            label3.Text = string.Format("m2Angle : ") + Convert.ToString((trackBarTiltAngle.Value * 360) / iPulses_One_Rev);

        }

        private void CntMove_btn_Click(object sender, EventArgs e)
        {
            //送出字串
            //string hexValues = "FF 01 04 64 00 00 00 68";

            exec_count = 0;
            mode = 1;

            Array.Clear(motor1.aAngle, 0, motor1.aAngle.Length);
            Array.Clear(motor2.aAngle, 0, motor2.aAngle.Length);
            Array.Clear(motor1.aVelocity, 0, motor1.aVelocity.Length);
            Array.Clear(motor2.aVelocity, 0, motor2.aVelocity.Length);

            lbl_Status.Text = string.Format("Mode : CNT MOVE") + Environment.NewLine + string.Format("Speed = ") + textBox_ASpeed.Text + Environment.NewLine;

            byte[] byteArray1 = new byte[8];

            byteArray1[0] = 0xFF;
            byteArray1[1] = 0x01;
            byteArray1[2] = 0x04;
            int data = Int32.Parse(textBox_ASpeed.Text);

            if (data < 0)
                compensation = true;
            else
                compensation = false;

            if (data < 0)
                data = 65535 + data + 1;

            byteArray1[3] = Convert.ToByte(data & 0x00FF);
            byteArray1[4] = Convert.ToByte((data & 0xFF00) >> 8);
            byteArray1[5] = Convert.ToByte(data & 0x00FF); 
            byteArray1[6] = Convert.ToByte((data & 0xFF00) >> 8);

			byteArray1[7] = get_checksum(7,byteArray1);//check sum
			
            sw.Reset();//碼表歸零

            sw.Start();//碼表開始計時

            My_SerialPort.Write(byteArray1, 0, 8);

            

        }

        private void AbsMove_btn_Click(object sender, EventArgs e)
        {
            Array.Clear(motor1.aAngle, 0, motor1.aAngle.Length);
            Array.Clear(motor2.aAngle, 0, motor2.aAngle.Length);
            Array.Clear(motor1.aVelocity, 0, motor1.aVelocity.Length);
            Array.Clear(motor2.aVelocity, 0, motor2.aVelocity.Length);

            exec_count = 0;
            mode = 2;

            if (motor1.iAngle >= 0)
            {
                sw.Reset();//碼表歸零

                sw.Start();//碼表開始計時

                string hexValues = "FF 10 0A 64 00 00 19 00 00 80 70 00 00 86";
                lbl_Status.Text = string.Format("Mode : ABS MOVE") + Environment.NewLine + string.Format("Speed =") + Convert.ToString(iSpeed) + Environment.NewLine;
                byte[] byteArray1 = new byte[16];

                byteArray1 = FromHex(hexValues);
                byteArray1[0] = 0xFF;//SYC Byte
                byteArray1[1] = 0x10;//ABS
                byteArray1[2] = 0x0A;//len
                
                int data = Int32.Parse(textBox_ASpeed.Text);
//                if (data < 0)
//                    compensation = true;
//                else
//                    compensation = false;
                if (data < 0)
                    data = Math.Abs(data);
                byteArray1[3] = Convert.ToByte(data & 0xFF);// speed
                byteArray1[4] = Convert.ToByte((data >> 8) & 0xFF);// speed

                byteArray1[5] = Convert.ToByte(trackBarPanAngle.Value & 0xFF);//pan angle   2
                byteArray1[6] = Convert.ToByte((trackBarPanAngle.Value >> 8) & 0xFF);//pan angle  50
                byteArray1[7] = Convert.ToByte((trackBarPanAngle.Value >> 16) & 0xFF);//pan angle  1
                byteArray1[8] = Convert.ToByte((trackBarPanAngle.Value >> 24) & 0xFF);//pan angle

                byteArray1[9] = Convert.ToByte(trackBarTiltAngle.Value & 0xFF);//tilt angle   2
                byteArray1[10] = Convert.ToByte((trackBarTiltAngle.Value >> 8) & 0xFF);//tilt angle  50
                byteArray1[11] = Convert.ToByte((trackBarTiltAngle.Value >> 16) & 0xFF);//tilt angle  1
                byteArray1[12] = Convert.ToByte((trackBarTiltAngle.Value >> 24) & 0xFF);//tilt angle
                
				byteArray1[13] = get_checksum(13,byteArray1);//check sum

                My_SerialPort.Write(byteArray1, 0, 14);
            }
            else
                MessageBox.Show("ipanglo");
        }

        private void RelMove_btn_Click(object sender, EventArgs e)
        {
            Array.Clear(motor1.aAngle, 0, motor1.aAngle.Length);
            Array.Clear(motor2.aAngle, 0, motor2.aAngle.Length);
            Array.Clear(motor1.aVelocity, 0, motor1.aVelocity.Length);
            Array.Clear(motor2.aVelocity, 0, motor2.aVelocity.Length);

            exec_count = 0;
            mode = 3;

            if (motor1.iAngle >= 0)
            {
                sw.Reset();//碼表歸零

                sw.Start();//碼表開始計時
                string hexValues = "FF 10 0A 64 00 00 19 00 00 80 70 00 00 86";
                lbl_Status.Text = string.Format("Mode : REL MOVE") + Environment.NewLine + string.Format("Speed =") + Convert.ToString(iSpeed) + Environment.NewLine;
                byte[] byteArray1 = new byte[16];

                byteArray1 = FromHex(hexValues);
                byteArray1[0] = 0xFF;//SYC Byte
                byteArray1[1] = 0x10;//ABS
                byteArray1[2] = 0x0A;//len

                int iPanAngleVal;
                int iTiltAngleVal;

                iPanAngleVal = (motor1.iAngle + trackBarPanAngle.Value) % iPulses_One_Rev;
                iTiltAngleVal = (motor2.iAngle + trackBarTiltAngle.Value) % iPulses_One_Rev;
                
                int data = Int32.Parse(textBox_ASpeed.Text);
//                if (data < 0)
//                    compensation = true;
//                else
//                    compensation = false;
                if (data < 0)
                    data = Math.Abs(data);
                byteArray1[3] = Convert.ToByte(data & 0xFF);// speed
                byteArray1[4] = Convert.ToByte((data >> 8) & 0xFF);// speed

                byteArray1[5] = Convert.ToByte(iPanAngleVal & 0xFF);//pan angle   2
                byteArray1[6] = Convert.ToByte((iPanAngleVal >> 8) & 0xFF);//pan angle  50
                byteArray1[7] = Convert.ToByte((iPanAngleVal >> 16) & 0xFF);//pan angle  1
                byteArray1[8] = Convert.ToByte((iPanAngleVal >> 24) & 0xFF);//pan angle
                byteArray1[9] = Convert.ToByte(iTiltAngleVal & 0xFF);//tilt angle   2
                byteArray1[10] = Convert.ToByte((iTiltAngleVal >> 8) & 0xFF);//tilt angle  50
                byteArray1[11] = Convert.ToByte((iTiltAngleVal >> 16) & 0xFF);//tilt angle  1
                byteArray1[12] = Convert.ToByte((iTiltAngleVal >> 24) & 0xFF);//tilt angle
                
				byteArray1[13] = get_checksum(13,byteArray1);//check sum

                My_SerialPort.Write(byteArray1, 0, 14);
            }
        }

        private void Console_Output_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox_Step_SelectedIndexChanged(object sender, EventArgs e)
        {
           // MessageBox.Show(Convert.ToString(comboBox_Step.SelectedIndex));
            //MessageBox.Show(comboBox_Step.SelectedItem.ToString());
        }


        //invoke Modify micro step command
        private void step_btn_Click(object sender, EventArgs e)
        {
            //送出字串
           // string hexValues = "FF 20 01 02 22";

            int index = comboBox_Step.SelectedIndex;
            double qtmp = Math.Pow(2,index);
            iPulses_One_Rev = 2* 89600 / Convert.ToInt32(qtmp);

            trackBarPanAngle.Maximum = iPulses_One_Rev;
            trackBarTiltAngle.Maximum = iPulses_One_Rev;

            lbl_Status.Text = string.Format("Mode : Modify Step") + Environment.NewLine + string.Format("Speed = ") + textBox_ASpeed.Text + Environment.NewLine;

            byte[] byteArray1 = new byte[8];

            byteArray1[0] = 0xFF;
            byteArray1[1] = 0x20;
            byteArray1[2] = 0x01;
            byte data = Convert.ToByte(comboBox_Step.SelectedIndex);
            data++;
            byteArray1[3] = data;

			byteArray1[4] = get_checksum(4,byteArray1);//check sum

            My_SerialPort.Write(byteArray1, 0, 5);
           
            lbl_step.Text = string.Format("Micro Stepping = ") + comboBox_Step.SelectedItem.ToString() + string.Format("Micro Steps");
        }

        //invoke Form2 to draw pan Velocity/Angle
        private void drawpan_btn_Click(object sender, EventArgs e)
        {
            Form2 VILAS = new Form2(exec_count, motor1.aAngle, motor1.aVelocity);
            VILAS.Show(); 
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        //invoke Form2 to draw tilt Velocity/Angle
        private void drawtilt_btn_Click(object sender, EventArgs e)
        {
            Form2 VILAS = new Form2(exec_count, motor2.aAngle, motor2.aVelocity);
            VILAS.Show();
        }

        private void rtn_pi_btn_Click(object sender, EventArgs e)
        {
            //送出字串
            //string hexValues = "FF 20 01 02 22";

            lbl_Status.Text = string.Format("Mode : Initialize PI")  + Environment.NewLine;

            byte[] byteArray1 = new byte[8];

            byteArray1[0] = 0xFF;
            byteArray1[1] = 0x20;
            byteArray1[2] = 0x01;
            //cmd 0x21 initizlize PI
            byteArray1[3] = 0x21;

            byteArray1[4] = get_checksum(4,byteArray1);//check sum
			
            My_SerialPort.Write(byteArray1, 0, 5);
        }

        private void StealthChop_btn_Click(object sender, EventArgs e)
        {
            //送出字串
           // string hexValues = "FF 20 01 01 21";

            lbl_Status.Text = string.Format("Mode : Initialize PI") + Environment.NewLine;

            byte[] byteArray1 = new byte[8];

            byteArray1[0] = 0xFF;
            byteArray1[1] = 0x22;
            byteArray1[2] = 0x01;
            //cmd 0x21 initizlize PI
            if (stealthChop)
            {
                byteArray1[3] = 0x00;
                StealthChop_btn.Text = "Enable StealthChop";
                stealthChop = false;
            }
            else
            {
                stealthChop = true;
                byteArray1[3] = 0x01;
                StealthChop_btn.Text = "Disable StealthChop";
            }
			
            byteArray1[4] = get_checksum(4,byteArray1);//check sum

            My_SerialPort.Write(byteArray1, 0, 5);
        }



        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.C)
            {
                string s = listBox1.SelectedItem.ToString();
               // Clipboard.SetData(DataFormats.StringFormat, s);
                //copy all
                //Clipboard.SetText( string.Join( Environment.NewLine, ListBox1.Items.OfType<string>().ToArray() ) );
                //copy select
                Clipboard.SetText(string.Join(Environment.NewLine, listBox1.SelectedItems.OfType<string>().ToArray()));
            }
        }

        private void Accleration_btn_Click(object sender, EventArgs e)
        {
            //送出字串
            //string hexValues = "FF 20 01 01 21";

            lbl_Status.Text = string.Format("Mode : Initialize PI") + Environment.NewLine;

            byte[] byteArray1 = new byte[8];

            byteArray1[0] = 0xFF;
            byteArray1[1] = 0x23;
            byteArray1[2] = 0x01;
            //cmd 0x21 initizlize PI
            int index;
            index = comboBox_Acecleration.SelectedIndex;

            byteArray1[3] = Convert.ToByte(index);
            
			byteArray1[4] = get_checksum(4,byteArray1);//check sum
			

            lbl_mode.Text = string.Format("Acceleration mode= ") + comboBox_Acecleration.SelectedItem.ToString();

            My_SerialPort.Write(byteArray1, 0, 5);
        }

        private void comboBox_Acecleration_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(Convert.ToString(comboBox_Acecleration.SelectedIndex));
        }

        


    }
}

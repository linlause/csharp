namespace SerialQQ
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Console_Output = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Getpos_btn = new System.Windows.Forms.Button();
            this.button_stop = new System.Windows.Forms.Button();
            this.cleantxt_btn = new System.Windows.Forms.Button();
            this.ComConnect = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxCompensation = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.trackBarTiltAngle = new System.Windows.Forms.TrackBar();
            this.textTiltAngle = new System.Windows.Forms.TextBox();
            this.trackBarPanAngle = new System.Windows.Forms.TrackBar();
            this.textBoxPanAngle = new System.Windows.Forms.TextBox();
            this.trackBarASpeed = new System.Windows.Forms.TrackBar();
            this.textBox_ASpeed = new System.Windows.Forms.TextBox();
            this.RelMove_btn = new System.Windows.Forms.Button();
            this.AbsMove_btn = new System.Windows.Forms.Button();
            this.CntMove_btn = new System.Windows.Forms.Button();
            this.comboBox_Step = new System.Windows.Forms.ComboBox();
            this.step_btn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.drawpan_btn = new System.Windows.Forms.Button();
            this.lbl_pAngle = new System.Windows.Forms.Label();
            this.lbl_tAngle = new System.Windows.Forms.Label();
            this.lbl_Status = new System.Windows.Forms.Label();
            this.lblTimeStatus = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbl_tPI = new System.Windows.Forms.Label();
            this.lbl_pPI = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lbl_pulse = new System.Windows.Forms.Label();
            this.lbl_mode = new System.Windows.Forms.Label();
            this.lbl_current = new System.Windows.Forms.Label();
            this.lbl_step = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.drawtilt_btn = new System.Windows.Forms.Button();
            this.rtn_pi_btn = new System.Windows.Forms.Button();
            this.StealthChop_btn = new System.Windows.Forms.Button();
            this.Accleration_btn = new System.Windows.Forms.Button();
            this.comboBox_Acecleration = new System.Windows.Forms.ComboBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTiltAngle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPanAngle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarASpeed)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // Console_Output
            // 
            this.Console_Output.Location = new System.Drawing.Point(593, 301);
            this.Console_Output.Multiline = true;
            this.Console_Output.Name = "Console_Output";
            this.Console_Output.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Console_Output.Size = new System.Drawing.Size(545, 289);
            this.Console_Output.TabIndex = 2;
            this.Console_Output.TextChanged += new System.EventHandler(this.Console_Output_TextChanged);
            this.Console_Output.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Console_Output_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label1.Location = new System.Drawing.Point(539, 686);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 12);
            this.label1.TabIndex = 3;
            // 
            // Getpos_btn
            // 
            this.Getpos_btn.Enabled = false;
            this.Getpos_btn.Location = new System.Drawing.Point(464, 185);
            this.Getpos_btn.Name = "Getpos_btn";
            this.Getpos_btn.Size = new System.Drawing.Size(75, 23);
            this.Getpos_btn.TabIndex = 4;
            this.Getpos_btn.Text = "GetPosition";
            this.Getpos_btn.UseVisualStyleBackColor = true;
            this.Getpos_btn.Click += new System.EventHandler(this.Getpos_btn_Click);
            // 
            // button_stop
            // 
            this.button_stop.Enabled = false;
            this.button_stop.Location = new System.Drawing.Point(464, 253);
            this.button_stop.Name = "button_stop";
            this.button_stop.Size = new System.Drawing.Size(75, 23);
            this.button_stop.TabIndex = 5;
            this.button_stop.Text = "Stop";
            this.button_stop.UseVisualStyleBackColor = true;
            this.button_stop.Click += new System.EventHandler(this.button_stop_Click);
            // 
            // cleantxt_btn
            // 
            this.cleantxt_btn.Location = new System.Drawing.Point(1063, 253);
            this.cleantxt_btn.Name = "cleantxt_btn";
            this.cleantxt_btn.Size = new System.Drawing.Size(75, 23);
            this.cleantxt_btn.TabIndex = 10;
            this.cleantxt_btn.Text = "CleanTxt";
            this.cleantxt_btn.UseVisualStyleBackColor = true;
            this.cleantxt_btn.Click += new System.EventHandler(this.cleantxt_btn_Click);
            // 
            // ComConnect
            // 
            this.ComConnect.Location = new System.Drawing.Point(161, 27);
            this.ComConnect.Name = "ComConnect";
            this.ComConnect.Size = new System.Drawing.Size(75, 23);
            this.ComConnect.TabIndex = 12;
            this.ComConnect.Text = "Connect";
            this.ComConnect.UseVisualStyleBackColor = true;
            this.ComConnect.Click += new System.EventHandler(this.ComConnect_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(21, 30);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 13;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.textBoxCompensation);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.trackBarTiltAngle);
            this.groupBox2.Controls.Add(this.textTiltAngle);
            this.groupBox2.Controls.Add(this.trackBarPanAngle);
            this.groupBox2.Controls.Add(this.textBoxPanAngle);
            this.groupBox2.Controls.Add(this.trackBarASpeed);
            this.groupBox2.Controls.Add(this.textBox_ASpeed);
            this.groupBox2.Location = new System.Drawing.Point(12, 301);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(422, 289);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Move Parameters";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(117, 259);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 12);
            this.label6.TabIndex = 18;
            this.label6.Text = "compensation Step";
            // 
            // textBoxCompensation
            // 
            this.textBoxCompensation.Location = new System.Drawing.Point(16, 249);
            this.textBoxCompensation.Name = "textBoxCompensation";
            this.textBoxCompensation.Size = new System.Drawing.Size(95, 22);
            this.textBoxCompensation.TabIndex = 17;
            this.textBoxCompensation.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 12);
            this.label5.TabIndex = 16;
            this.label5.Text = "Paulse:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 199);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 12);
            this.label3.TabIndex = 15;
            this.label3.Text = "m2Angle:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "m1Angle:";
            // 
            // trackBarTiltAngle
            // 
            this.trackBarTiltAngle.Location = new System.Drawing.Point(130, 163);
            this.trackBarTiltAngle.Maximum = 89600;
            this.trackBarTiltAngle.Name = "trackBarTiltAngle";
            this.trackBarTiltAngle.Size = new System.Drawing.Size(286, 45);
            this.trackBarTiltAngle.TabIndex = 13;
            this.trackBarTiltAngle.Value = 55;
            this.trackBarTiltAngle.Scroll += new System.EventHandler(this.trackBarTiltAngle_Scroll);
            // 
            // textTiltAngle
            // 
            this.textTiltAngle.Location = new System.Drawing.Point(16, 163);
            this.textTiltAngle.Name = "textTiltAngle";
            this.textTiltAngle.Size = new System.Drawing.Size(95, 22);
            this.textTiltAngle.TabIndex = 12;
            this.textTiltAngle.Text = "55";
            this.textTiltAngle.TextChanged += new System.EventHandler(this.textTiltAngle_TextChanged);
            // 
            // trackBarPanAngle
            // 
            this.trackBarPanAngle.Location = new System.Drawing.Point(130, 92);
            this.trackBarPanAngle.Maximum = 89600;
            this.trackBarPanAngle.Name = "trackBarPanAngle";
            this.trackBarPanAngle.Size = new System.Drawing.Size(286, 45);
            this.trackBarPanAngle.TabIndex = 11;
            this.trackBarPanAngle.Value = 55;
            this.trackBarPanAngle.Scroll += new System.EventHandler(this.trackBarPanAngle_Scroll);
            // 
            // textBoxPanAngle
            // 
            this.textBoxPanAngle.Location = new System.Drawing.Point(16, 92);
            this.textBoxPanAngle.Name = "textBoxPanAngle";
            this.textBoxPanAngle.Size = new System.Drawing.Size(95, 22);
            this.textBoxPanAngle.TabIndex = 10;
            this.textBoxPanAngle.Text = "55";
            this.textBoxPanAngle.TextChanged += new System.EventHandler(this.textBoxPanAngle_TextChanged);
            // 
            // trackBarASpeed
            // 
            this.trackBarASpeed.Location = new System.Drawing.Point(130, 21);
            this.trackBarASpeed.Maximum = 6000;
            this.trackBarASpeed.Minimum = -6000;
            this.trackBarASpeed.Name = "trackBarASpeed";
            this.trackBarASpeed.Size = new System.Drawing.Size(286, 45);
            this.trackBarASpeed.TabIndex = 9;
            this.trackBarASpeed.Value = 55;
            this.trackBarASpeed.Scroll += new System.EventHandler(this.trackBarASpeed_Scroll);
            // 
            // textBox_ASpeed
            // 
            this.textBox_ASpeed.Location = new System.Drawing.Point(16, 21);
            this.textBox_ASpeed.Name = "textBox_ASpeed";
            this.textBox_ASpeed.Size = new System.Drawing.Size(95, 22);
            this.textBox_ASpeed.TabIndex = 0;
            this.textBox_ASpeed.Text = "55";
            this.textBox_ASpeed.TextChanged += new System.EventHandler(this.textBox_ASpeed_TextChanged);
            // 
            // RelMove_btn
            // 
            this.RelMove_btn.Enabled = false;
            this.RelMove_btn.Location = new System.Drawing.Point(464, 489);
            this.RelMove_btn.Name = "RelMove_btn";
            this.RelMove_btn.Size = new System.Drawing.Size(109, 23);
            this.RelMove_btn.TabIndex = 15;
            this.RelMove_btn.Text = "Relative_Move";
            this.RelMove_btn.UseVisualStyleBackColor = true;
            this.RelMove_btn.Click += new System.EventHandler(this.RelMove_btn_Click);
            // 
            // AbsMove_btn
            // 
            this.AbsMove_btn.Enabled = false;
            this.AbsMove_btn.Location = new System.Drawing.Point(464, 411);
            this.AbsMove_btn.Name = "AbsMove_btn";
            this.AbsMove_btn.Size = new System.Drawing.Size(109, 23);
            this.AbsMove_btn.TabIndex = 16;
            this.AbsMove_btn.Text = "Absolute_Move";
            this.AbsMove_btn.UseVisualStyleBackColor = true;
            this.AbsMove_btn.Click += new System.EventHandler(this.AbsMove_btn_Click);
            // 
            // CntMove_btn
            // 
            this.CntMove_btn.Enabled = false;
            this.CntMove_btn.Location = new System.Drawing.Point(464, 322);
            this.CntMove_btn.Name = "CntMove_btn";
            this.CntMove_btn.Size = new System.Drawing.Size(109, 23);
            this.CntMove_btn.TabIndex = 17;
            this.CntMove_btn.Text = "Continuous_Move";
            this.CntMove_btn.UseVisualStyleBackColor = true;
            this.CntMove_btn.Click += new System.EventHandler(this.CntMove_btn_Click);
            // 
            // comboBox_Step
            // 
            this.comboBox_Step.FormattingEnabled = true;
            this.comboBox_Step.Location = new System.Drawing.Point(11, 13);
            this.comboBox_Step.Name = "comboBox_Step";
            this.comboBox_Step.Size = new System.Drawing.Size(121, 20);
            this.comboBox_Step.TabIndex = 22;
            this.comboBox_Step.SelectedIndexChanged += new System.EventHandler(this.comboBox_Step_SelectedIndexChanged);
            // 
            // step_btn
            // 
            this.step_btn.Enabled = false;
            this.step_btn.Location = new System.Drawing.Point(168, 8);
            this.step_btn.Name = "step_btn";
            this.step_btn.Size = new System.Drawing.Size(101, 29);
            this.step_btn.TabIndex = 23;
            this.step_btn.Text = "Micro step";
            this.step_btn.UseVisualStyleBackColor = true;
            this.step_btn.Click += new System.EventHandler(this.step_btn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(244, 63);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Com Setting";
            // 
            // drawpan_btn
            // 
            this.drawpan_btn.Location = new System.Drawing.Point(462, 539);
            this.drawpan_btn.Name = "drawpan_btn";
            this.drawpan_btn.Size = new System.Drawing.Size(125, 23);
            this.drawpan_btn.TabIndex = 26;
            this.drawpan_btn.Text = "DrawCurrentPan";
            this.drawpan_btn.UseVisualStyleBackColor = true;
            this.drawpan_btn.Click += new System.EventHandler(this.drawpan_btn_Click);
            // 
            // lbl_pAngle
            // 
            this.lbl_pAngle.AutoSize = true;
            this.lbl_pAngle.BackColor = System.Drawing.Color.Green;
            this.lbl_pAngle.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_pAngle.Location = new System.Drawing.Point(17, 67);
            this.lbl_pAngle.Name = "lbl_pAngle";
            this.lbl_pAngle.Size = new System.Drawing.Size(78, 12);
            this.lbl_pAngle.TabIndex = 20;
            this.lbl_pAngle.Text = "Current Pangle:";
            // 
            // lbl_tAngle
            // 
            this.lbl_tAngle.AutoSize = true;
            this.lbl_tAngle.BackColor = System.Drawing.Color.Green;
            this.lbl_tAngle.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_tAngle.Location = new System.Drawing.Point(17, 89);
            this.lbl_tAngle.Name = "lbl_tAngle";
            this.lbl_tAngle.Size = new System.Drawing.Size(82, 12);
            this.lbl_tAngle.TabIndex = 21;
            this.lbl_tAngle.Text = "Current TAngle:";
            // 
            // lbl_Status
            // 
            this.lbl_Status.AutoSize = true;
            this.lbl_Status.BackColor = System.Drawing.Color.Green;
            this.lbl_Status.ForeColor = System.Drawing.Color.White;
            this.lbl_Status.Location = new System.Drawing.Point(17, 29);
            this.lbl_Status.Name = "lbl_Status";
            this.lbl_Status.Size = new System.Drawing.Size(32, 12);
            this.lbl_Status.TabIndex = 25;
            this.lbl_Status.Text = "Mode";
            // 
            // lblTimeStatus
            // 
            this.lblTimeStatus.AutoSize = true;
            this.lblTimeStatus.BackColor = System.Drawing.Color.Green;
            this.lblTimeStatus.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTimeStatus.Location = new System.Drawing.Point(211, 29);
            this.lblTimeStatus.Name = "lblTimeStatus";
            this.lblTimeStatus.Size = new System.Drawing.Size(22, 12);
            this.lblTimeStatus.TabIndex = 27;
            this.lblTimeStatus.Text = "TM";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Green;
            this.groupBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox3.Controls.Add(this.lbl_tPI);
            this.groupBox3.Controls.Add(this.lbl_pPI);
            this.groupBox3.Controls.Add(this.lblTimeStatus);
            this.groupBox3.Controls.Add(this.lbl_Status);
            this.groupBox3.Controls.Add(this.lbl_tAngle);
            this.groupBox3.Controls.Add(this.lbl_pAngle);
            this.groupBox3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox3.Location = new System.Drawing.Point(12, 158);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(416, 118);
            this.groupBox3.TabIndex = 28;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Status";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // lbl_tPI
            // 
            this.lbl_tPI.AutoSize = true;
            this.lbl_tPI.Location = new System.Drawing.Point(308, 89);
            this.lbl_tPI.Name = "lbl_tPI";
            this.lbl_tPI.Size = new System.Drawing.Size(27, 12);
            this.lbl_tPI.TabIndex = 29;
            this.lbl_tPI.Text = "PI: 0";
            // 
            // lbl_pPI
            // 
            this.lbl_pPI.AutoSize = true;
            this.lbl_pPI.Location = new System.Drawing.Point(308, 67);
            this.lbl_pPI.Name = "lbl_pPI";
            this.lbl_pPI.Size = new System.Drawing.Size(27, 12);
            this.lbl_pPI.TabIndex = 28;
            this.lbl_pPI.Text = "PI: 0";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(21, 621);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBox1.Size = new System.Drawing.Size(1117, 88);
            this.listBox1.TabIndex = 29;
            this.listBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBox1_KeyDown);
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.groupBox4.Controls.Add(this.lbl_pulse);
            this.groupBox4.Controls.Add(this.lbl_mode);
            this.groupBox4.Controls.Add(this.lbl_current);
            this.groupBox4.Controls.Add(this.lbl_step);
            this.groupBox4.Location = new System.Drawing.Point(593, 160);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(427, 116);
            this.groupBox4.TabIndex = 30;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Configuration";
            // 
            // lbl_pulse
            // 
            this.lbl_pulse.AutoSize = true;
            this.lbl_pulse.Location = new System.Drawing.Point(246, 58);
            this.lbl_pulse.Name = "lbl_pulse";
            this.lbl_pulse.Size = new System.Drawing.Size(76, 12);
            this.lbl_pulse.TabIndex = 3;
            this.lbl_pulse.Text = "Pulase Rate=55";
            // 
            // lbl_mode
            // 
            this.lbl_mode.AutoSize = true;
            this.lbl_mode.Location = new System.Drawing.Point(44, 32);
            this.lbl_mode.Name = "lbl_mode";
            this.lbl_mode.Size = new System.Drawing.Size(135, 12);
            this.lbl_mode.TabIndex = 2;
            this.lbl_mode.Text = "Acceleration mode= Default";
            // 
            // lbl_current
            // 
            this.lbl_current.AutoSize = true;
            this.lbl_current.Location = new System.Drawing.Point(246, 32);
            this.lbl_current.Name = "lbl_current";
            this.lbl_current.Size = new System.Drawing.Size(74, 12);
            this.lbl_current.TabIndex = 1;
            this.lbl_current.Text = "Max. Current=";
            // 
            // lbl_step
            // 
            this.lbl_step.AutoSize = true;
            this.lbl_step.Location = new System.Drawing.Point(44, 58);
            this.lbl_step.Name = "lbl_step";
            this.lbl_step.Size = new System.Drawing.Size(110, 12);
            this.lbl_step.TabIndex = 0;
            this.lbl_step.Text = "Micro Stepping = 1/64";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 593);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 12);
            this.label4.TabIndex = 31;
            this.label4.Text = "Result:";
            // 
            // drawtilt_btn
            // 
            this.drawtilt_btn.Location = new System.Drawing.Point(462, 582);
            this.drawtilt_btn.Name = "drawtilt_btn";
            this.drawtilt_btn.Size = new System.Drawing.Size(125, 23);
            this.drawtilt_btn.TabIndex = 32;
            this.drawtilt_btn.Text = "DrawCurrentTilt";
            this.drawtilt_btn.UseVisualStyleBackColor = true;
            this.drawtilt_btn.Click += new System.EventHandler(this.drawtilt_btn_Click);
            // 
            // rtn_pi_btn
            // 
            this.rtn_pi_btn.Location = new System.Drawing.Point(1063, 176);
            this.rtn_pi_btn.Name = "rtn_pi_btn";
            this.rtn_pi_btn.Size = new System.Drawing.Size(75, 23);
            this.rtn_pi_btn.TabIndex = 33;
            this.rtn_pi_btn.Text = "Return_PI";
            this.rtn_pi_btn.UseVisualStyleBackColor = true;
            this.rtn_pi_btn.Visible = false;
            this.rtn_pi_btn.Click += new System.EventHandler(this.rtn_pi_btn_Click);
            // 
            // StealthChop_btn
            // 
            this.StealthChop_btn.Enabled = false;
            this.StealthChop_btn.Location = new System.Drawing.Point(11, 90);
            this.StealthChop_btn.Name = "StealthChop_btn";
            this.StealthChop_btn.Size = new System.Drawing.Size(121, 29);
            this.StealthChop_btn.TabIndex = 34;
            this.StealthChop_btn.Text = "Enable StealthChop";
            this.StealthChop_btn.UseVisualStyleBackColor = true;
            this.StealthChop_btn.Click += new System.EventHandler(this.StealthChop_btn_Click);
            // 
            // Accleration_btn
            // 
            this.Accleration_btn.Enabled = false;
            this.Accleration_btn.Location = new System.Drawing.Point(173, 54);
            this.Accleration_btn.Name = "Accleration_btn";
            this.Accleration_btn.Size = new System.Drawing.Size(96, 28);
            this.Accleration_btn.TabIndex = 35;
            this.Accleration_btn.Text = "Accleration";
            this.Accleration_btn.UseVisualStyleBackColor = true;
            this.Accleration_btn.Click += new System.EventHandler(this.Accleration_btn_Click);
            // 
            // comboBox_Acecleration
            // 
            this.comboBox_Acecleration.FormattingEnabled = true;
            this.comboBox_Acecleration.Location = new System.Drawing.Point(11, 54);
            this.comboBox_Acecleration.Name = "comboBox_Acecleration";
            this.comboBox_Acecleration.Size = new System.Drawing.Size(121, 20);
            this.comboBox_Acecleration.TabIndex = 36;
            this.comboBox_Acecleration.SelectedIndexChanged += new System.EventHandler(this.comboBox_Acecleration_SelectedIndexChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.comboBox_Acecleration);
            this.groupBox5.Controls.Add(this.Accleration_btn);
            this.groupBox5.Controls.Add(this.StealthChop_btn);
            this.groupBox5.Controls.Add(this.step_btn);
            this.groupBox5.Controls.Add(this.comboBox_Step);
            this.groupBox5.Location = new System.Drawing.Point(582, 14);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(556, 136);
            this.groupBox5.TabIndex = 37;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "MCU Parameters";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1150, 731);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.rtn_pi_btn);
            this.Controls.Add(this.drawtilt_btn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.drawpan_btn);
            this.Controls.Add(this.CntMove_btn);
            this.Controls.Add(this.AbsMove_btn);
            this.Controls.Add(this.RelMove_btn);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.ComConnect);
            this.Controls.Add(this.cleantxt_btn);
            this.Controls.Add(this.button_stop);
            this.Controls.Add(this.Getpos_btn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Console_Output);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Notor Velocity Test";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTiltAngle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPanAngle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarASpeed)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Console_Output;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Getpos_btn;
        private System.Windows.Forms.Button button_stop;
        private System.Windows.Forms.Button cleantxt_btn;
        private System.Windows.Forms.Button ComConnect;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox_ASpeed;
        private System.Windows.Forms.TrackBar trackBarASpeed;
        private System.Windows.Forms.TrackBar trackBarTiltAngle;
        private System.Windows.Forms.TextBox textTiltAngle;
        private System.Windows.Forms.TrackBar trackBarPanAngle;
        private System.Windows.Forms.TextBox textBoxPanAngle;
        private System.Windows.Forms.Button RelMove_btn;
        private System.Windows.Forms.Button AbsMove_btn;
        private System.Windows.Forms.Button CntMove_btn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_Step;
        private System.Windows.Forms.Button step_btn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button drawpan_btn;
        private System.Windows.Forms.Label lbl_pAngle;
        private System.Windows.Forms.Label lbl_tAngle;
        private System.Windows.Forms.Label lbl_Status;
        private System.Windows.Forms.Label lblTimeStatus;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lbl_mode;
        private System.Windows.Forms.Label lbl_current;
        private System.Windows.Forms.Label lbl_step;
        private System.Windows.Forms.Label lbl_pulse;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button drawtilt_btn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxCompensation;
        private System.Windows.Forms.Button rtn_pi_btn;
        private System.Windows.Forms.Button StealthChop_btn;
        private System.Windows.Forms.Button Accleration_btn;
        private System.Windows.Forms.ComboBox comboBox_Acecleration;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label lbl_tPI;
        private System.Windows.Forms.Label lbl_pPI;
    }
}


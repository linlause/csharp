using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//
using ZedGraph;

namespace SerialQQ
{
    public partial class Form2 : Form
    {
       //
        //private ZedGraph.ZedGraphControl z1;
        public double[] iPAngle;//Byte[] buffer = new Byte[1024];
        public double[] iPVelocity;//Byte[] buffer = new Byte[1024];
        public int iexec_count;

        public Form2()
        {
            InitializeComponent();
        }

        public Form2(int exec_count,int[] qAngle,int[]qVelocity)
        {
            InitializeComponent();
            iexec_count = exec_count;
            int i;
            iPAngle = new double[qAngle.Length];
            
            Array.Clear(iPAngle, 0, iPAngle.Length);
            for(i = 0; i< qAngle.Length;i++)
            {
                iPAngle[i] = Convert.ToDouble(qAngle[i]);
            }

            iPVelocity = new double[qVelocity.Length];
            Array.Clear(iPVelocity, 0, iPVelocity.Length);
            for (i = 0; i < qVelocity.Length; i++)
            {
                iPVelocity[i] = Convert.ToDouble(qVelocity[i]);
            }
        }
		
        private void Form2_Load(object sender, EventArgs e)
        {

            zedGraphControl1.IsShowPointValues = true;
            zedGraphControl1.GraphPane.Title = "Test Case for C#";
            /*
            double[] x = new double[100];
            double[] y = new double[100];
            int i;
            for (i = 0; i < 100; i++)
            {
                x[i] = (double)i / 100.0 * Math.PI * 2.0;
                y[i] = Math.Sin(x[i]);
            }
            */
            //zedGraphControl1.GraphPane.AddCurve("Sine Wave", x, y, Color.Red, SymbolType.Square);
            zedGraphControl1.GraphPane.AddCurve("Velocity", iPAngle, iPVelocity, Color.Red, SymbolType.Square);
            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();


        }
    }
}

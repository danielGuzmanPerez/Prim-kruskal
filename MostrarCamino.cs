/*
 * Created by SharpDevelop.
 * User: vdgp_
 * Date: 17/03/2020
 * Time: 07:35 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Actividad3
{
	/// <summary>
	/// Description of MostrarCamino.
	/// </summary>
	/// 
	public partial class MostrarCamino : Form
	{
		Pen kruskalpen;
		Pen PrimPen;
		Bitmap bmpKruskal,bmpPrim;
		Graphics gKruskal,gPrim;
		float distanciaKruskal;
		float distanciaprim;
		public MostrarCamino(List<circulo>circulos,List<listaCandidato> kruskal,Bitmap bmpKruskal_,List<listaCandidato> Prim,Bitmap bmpPrim_)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			bmpKruskal=new Bitmap(bmpKruskal_);
			bmpPrim=new Bitmap(bmpPrim_);
			kruskalpen = new Pen(Color.DeepSkyBlue,10);
			PrimPen = new Pen(Color.LawnGreen,10);
			gKruskal= Graphics.FromImage(bmpKruskal);
			gPrim= Graphics.FromImage(bmpPrim);
			distanciaKruskal=0;
			distanciaprim=0;
			//crear bitmap Kruskal
			for (int j = 0; j <kruskal.Count; j++) {
				for (int i = 0; i < kruskal[j].l.Count; i++) {
					gKruskal.DrawLine(kruskalpen,circulos[kruskal[j].l[i].getA()-1].getX(),circulos[kruskal[j].l[i].getA()-1].getY(),circulos[kruskal[j].l[i].getB()-1].getX(),circulos[kruskal[j].l[i].getB()-1].getY());
					distanciaKruskal+=kruskal[j].l[i].getDistancia();
				}
			}
			pictureBox2.Image=bmpKruskal;
			label5.Text=distanciaKruskal.ToString();
			//crear bitmap PRIM
			for (int j = 0; j <Prim.Count; j++) {
				for (int i = 0; i < Prim[j].l.Count; i++) {
					gPrim.DrawLine(PrimPen,circulos[Prim[j].l[i].getA()-1].getX(),circulos[Prim[j].l[i].getA()-1].getY(),circulos[Prim[j].l[i].getB()-1].getX(),circulos[Prim[j].l[i].getB()-1].getY());
					distanciaprim+=Prim[j].l[i].getDistancia();
				}
			}
			pictureBox1.Image=bmpPrim;
			label6.Text=distanciaKruskal.ToString();
		}
		void linea(int x1, int y1, int x2, int y2,Color co,Bitmap bmp){
			float deltax=x2-x1;
			float deltay = y2-y1;
			if(Math.Abs(deltax)> Math.Abs(deltay)){  // pendiente <1
				float m= (float)deltay/(deltax);
				float b= y1-m*x1;
				if(deltax<0)
					deltax=-1;
				else
					deltax=1;
				while(x1!= x2){
					x1+=(int)deltax;
					y1=(int)Math.Round((double)m*(double)x1+(double)b);
					bmp.SetPixel(x1,y1,co);
					
			}
			}else
				if(deltay!=0){   //pendiente >=1
				float m=(float)deltax/(float)deltay;
				float b= x1-m*y1;
				if(deltay<0)
					deltay=-1;
				else
					deltay=1;
				while(y1!=y2){
					y1+= (int)deltay;
					x1=(int)Math.Round((double)m*(double)y1+(double)b);
					bmp.SetPixel(x1,y1,co);
					
				}
			}
		}
	}
}

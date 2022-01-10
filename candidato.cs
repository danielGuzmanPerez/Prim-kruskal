/*
 * Created by SharpDevelop.
 * User: vdgp_
 * Date: 16/03/2020
 * Time: 09:59 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Actividad3
{
	/// <summary>
	/// Description of candidato.
	/// </summary>
	public class candidato
	{
		int a;
		int b;
		float dist;
		public candidato()
		{
		}
		public void setDatos(int a_, int b_,float dist_)
		{
			a=a_;
			b=b_;
			dist=dist_;
		}
		public int  getA(){
			return a;
		}
		public int getB(){
			return b;
		}
		public float getDistancia(){
			return dist;
		}
	}
}

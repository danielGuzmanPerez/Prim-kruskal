/*
 * Created by SharpDevelop.
 * User: vdgp_
 * Date: 25/03/2020
 * Time: 04:13 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Actividad3
{
	/// <summary>
	/// Description of particula.
	/// </summary>
	public class particula
	{
		List<Point> coordenadas;
		int inicio,fin;
		int radio;
		public bool verificar;
		public particula(List<Point>cord, int inicio_, int fin_)
		{
			coordenadas= cord;
			inicio=inicio_;
			fin=fin_;
			verificar=false;
		}
		public bool termino(){
			if(coordenadas.Count==0)
				return true;
			return false;
		}
		public Point avanzar(){
			Point mandar= coordenadas[0];
			coordenadas.RemoveAt(0);
			return mandar;
		}
		public int getInicio(){
			return inicio;
		}
		public int getFin(){
			return fin;
		}
		public void setVerificar(bool ver){
			verificar=ver;
		}
		public bool getVerificar(){
			return verificar;
		}
		public int getRadio()
		{
			return radio;
		}
		public void setRadio(int r){
			radio=r;
		}
	}
}

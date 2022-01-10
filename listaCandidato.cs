/*
 * Created by SharpDevelop.
 * User: vdgp_
 * Date: 16/03/2020
 * Time: 10:06 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace Actividad3
{
	/// <summary>
	/// Description of listaPrometedor.
	/// </summary>
	public class listaCandidato
	{
		public List<candidato> l;
		public List<int >ID;
		public listaCandidato()
		{
			l=new List<candidato>();
			ID=new List<int>();
		}
		public void addCandidato(candidato c)
		{
			l.Add(c);
		}
		public void addId(int i){
			ID.Add(i);
		}
	}
}

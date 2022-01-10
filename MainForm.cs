/*
 * Created by SharpDevelop.
 * User: vdgp_
 * Date: 08/03/2020
 * Time: 10:44 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
namespace Actividad3
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form 
	{
			String imagen;
			Bitmap bmp,temporal;
			Color c;
			List<circulo> Lista;
			graph GrafoKruskal,GrafoPrim;
			List<vertex> vertice; 
			Graphics gra;
			//kruskal
			List<vertex> candidatos;
			List<listaCandidato> cc;
			candidato opcion;
			int cantidadCirculos;
			List<listaCandidato> krus;
			//prim
			List<listaCandidato> PrimCompleto;
			List<int> ListaVisitados;
			List<listaCandidato> ccPrim;
			candidato opcionPrim;
			List<int> ListaTotalVisitados;
			//Animar
			int verticeInicial;
			List<particula> particulas;
			List<particula> particulasAnimar;
			int radio;
		public MainForm()
		{
			Lista=new List<circulo>();
			int origen =-1;
			verticeInicial=1;
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			if(openFileDialog1.ShowDialog()==DialogResult.OK){
				if(bmp!=null){
					bmp.Dispose();
				pictureBox1.BackgroundImage.Dispose();
				}
				imagen= openFileDialog1.FileName;
				//pictureBox1.Image=Image.FromFile(imagen);
				bmp = new Bitmap(imagen);
				Lista.Clear();
				listBox1.Items.Clear();
				FindCircle();
				System.Drawing.Imaging.PixelFormat format = bmp.PixelFormat;
				RectangleF cloneRect = new RectangleF(0, 0, bmp.Width, bmp.Height);
				Bitmap bmpClon=bmp.Clone(cloneRect,format);
				GrafoKruskal= new graph(Lista,bmp);
				GrafoPrim= new graph(Lista,bmpClon);
				pictureBox1.BackgroundImage=GrafoPrim.getBmp();
					//pictureBox1.Scale(1);
				for(int i=0; i<Lista.Count;i++){
					listBox1.Items.Add(i+1);
				}
					//animar(Lista[i].x,Lista[i].y,Lista[i+1].x,Lista[i+1].y);
			}
		}
		void FindCircle(){
			
			for(int y=0;y<bmp.Height;y++){
				for(int x=0; x<bmp.Width;x++){
					c=bmp.GetPixel(x,y);
					if(c.R==0 && c.G==0 && c.B== 0){
						Lista.Add( SaveCircle(x,y));
			
					}
				}
			}
		 }
		circulo SaveCircle(int x, int y){
			int j=x;
			int i=y;
			//coordenadas del centro del circulo
			int puntoX;
			int puntoY;
			// guardan la cantidad de pixeles que hay del centro hasta la orilla
			int orillaDer;
			int orillaInf;
			//valor de pixel de cada limite
			int izqX;
			int derX;
			int arribaY;
			int abajoY;
			
			//Encontrar el punto medio de  arriba x
			while(j<bmp.Width ){
				c= bmp.GetPixel(j,i);
				if(c.R !=0 || c.G !=0 || c.B !=0){
					c= bmp.GetPixel(j+4,i);
					if(c.R !=255 || c.G !=255 || c.B !=255){
						bmp.SetPixel(j,i,Color.Black);
						
					}else{
						bmp.SetPixel(j,i,Color.White);
						break;
					}
				}else{
					j++;
				}
				
			}
			j=x+(j-x)/2;
			puntoX=j;
			arribaY=i;
			
			//Encontrar el medio de abajo  y centro
			while(i<bmp.Height ){
				c= bmp.GetPixel(j,i);
				if(c.R !=0 || c.G !=0 || c.B !=0){
					break;
				}else{
					i++;
				}
				
			}
			puntoY =(y+i)/2 ;
			//encontrar orilla derecha
			while(j<bmp.Width){
				c= bmp.GetPixel(j,puntoY);
				if(c.R !=0 || c.G !=0 || c.B !=0){
					break;
				}else{
					j++;
				}
				
			}
			derX=j;
			orillaDer=j-puntoX;
			orillaInf=i-puntoY;
			
			//encontrar limite izquierda
			j--;
			while(j>1 ){
				c= bmp.GetPixel(j,puntoY);
				if(c.R !=0 || c.G !=0 || c.B !=0){
					break;
				}else{
					j--;
				}
				
			}
			izqX=j;
			j=puntoY;//
			//encontrar limite abajo
			while(j<bmp.Height ){
				c= bmp.GetPixel(puntoX,j);
				if(c.R !=0 || c.G !=0 || c.B !=0){
					break;
				}else{
					j++;
				}
				
			}
			abajoY=j;
			pintarCirculo(puntoX,puntoY,izqX-4,arribaY-4,derX+4,abajoY+4);
			int radio=orillaDer;
			if(orillaInf>orillaDer){
				radio=orillaInf;
			}
			
				
			return new circulo(puntoX,puntoY,radio+3);
				
			
		}
		void pintarCirculo(int puntox,int puntoy,int izquierdax,int arribay,int derechax,int abajoy){
			
			//pintar 1/4
			for(int j=puntox; j>izquierdax;j--){
				for(int i=puntoy;i>arribay;i--){
					c=bmp.GetPixel(j,i);
						if(c.G!=255 && c.B!=255 && c.R!=255){
							bmp.SetPixel(j,i,Color.Red);
							
					}else{
						break;
					}
				}
			}
			//pintar 2/4
			for(int j=puntox; j<derechax;j++){
				for(int i=puntoy;i>arribay;i--){
					c=bmp.GetPixel(j,i);
						if(c.G!=255 && c.B!=255 && c.R!=255){
							bmp.SetPixel(j,i,Color.Red);
					}else{
						break;
					}
				}
			}
			//pintar 3/4
			for(int j=puntox; j<derechax;j++){
				for(int i=puntoy+1;i<abajoy;i++){
					c=bmp.GetPixel(j,i);
						if(c.G!=255 && c.B!=255 && c.R!=255){
							bmp.SetPixel(j,i,Color.Red);
					}else{
						break;
					}
				}
			}
			
			//pintar 4/4
			for(int j=puntox; j>izquierdax;j--){
				for(int i=puntoy+1;i<abajoy;i++){
					c=bmp.GetPixel(j,i);
						if(c.G!=255 && c.B!=255 && c.R!=255){
							bmp.SetPixel(j,i,Color.Red);
					}else{
						break;
					}
				}
			}
		}
		public int encontrarCirculo(int x, int y){
			for(int i=0; i<Lista.Count;i++){
				if((x>=Lista[i].x-50) && (x<=Lista[i].x+50) && (y>=Lista[i].y-50) && (y<=Lista[i].x+50)){
					return i;
				}
			}
			return -1;
		}
		void ListBox1MouseClick(object sender, MouseEventArgs e)
		{
			ListaVisitados= new List<int>();
			 verticeInicial=Int32.Parse(listBox1.GetItemText(listBox1.SelectedItem));
			ListaVisitados.Add(verticeInicial);
		}
		void PictureBox1MouseClick(object sender, MouseEventArgs e)
		{
			float w_p, h_p;
			float w_b, h_b;
			float k,k2;
			float d_x, d_y;
			float x_b;
			float y_b;
			
			w_p=pictureBox1.Width;
			h_p=pictureBox1.Height;
			w_b=bmp.Width;
			h_b=bmp.Height;
		
			k=w_p/w_b;
			k2=h_p/h_b;
			if(k2<k)
				k=k2;
			d_x = (w_p*w_b)/2;
			d_y= (h_p-k*h_b)/2;
			
			x_b=(e.X-d_x)/k;
			y_b=(e.Y-d_x)/k;
			Graphics g =Graphics.FromImage(bmp);
			Brush b1 = new SolidBrush(Color.Pink);
			g.FillEllipse(b1,x_b-15,y_b-15,30,30);
			pictureBox1.Image=bmp;
			/*if(Grafo.belongtovertex(x_b,y_b))//esto sirve para saber si las coordenadas pertenecen a un circulo
			{
				Particle p= new Particle();
			}*/
				
		}
	//**************************************KRUSKAL*********************************************************************
	//******************************************************************************************************************
		List<listaCandidato> kruskal(){
			candidatos= new List<vertex>(GrafoKruskal.v1);
			cc= new List<listaCandidato>();
			cantidadCirculos=0;
			while(true){
				if(cc.Count==1){
					if(cantidadDeVerticesKruskal()==Lista.Count-1)
						break;
				}if(cc.Count>=2){
					if( verificarSiYaTerminoKruskal())//esto revisa que ya no existan candidatos posibles
						break;
				}
				opcion=encontrarMenorKruskal();
				//si no pertenecen a la misma lista
				if(!buscarcc(opcion.getA(),opcion.getB())){
					int posA= encontrarLista(opcion.getA());
					int posB= encontrarLista(opcion.getB());
					float distancia=opcion.getDistancia();
					concatenar(posA,posB, distancia, opcion.getA(),opcion.getB());
				//si pertenecen a la misma se elimina la opcion
				}
				eliminarCandidatoKruskal(opcion.getA()-1,opcion.getB());
			}
			return cc;
		}
		 candidato encontrarMenorKruskal(){
			float menor=99999999;
			int a,b;
			candidato mandar=new candidato();
			for (int i = 0; i <candidatos.Count; i++) {
				for (int j = 0; j < candidatos[i].eL.Count; j++) {
					if(candidatos[i].eL[j].distancia<menor){
						menor=candidatos[i].eL[j].distancia;
						a=candidatos[i].id;
						b=candidatos[i].eL[j].v_d.id;
						mandar.setDatos(a,b,menor);
					}
				}
			}
			
			return mandar;
		}
		//Busca que las vertices no esten en la misma lista
		bool buscarcc(int a, int b){
			for(int i=0; i<cc.Count;i++){
				if(cc[i].ID.Contains(a) && cc[i].ID.Contains(b)){
					return true;
				}
			}
			return false;
		}
		// encuentra la lista de a y de b para concatenarlas 
		// retorna la posicion en cc de la lista a la que pertenece el dato
		int encontrarLista(int id){
			bool banderaA=false;
			int a_=0;
			for (int i = 0; i < cc.Count; i++) {
				if(cc[i].ID.Contains(id)){
					a_=i;
					banderaA=true;
				}
			}
			if(banderaA==false){
				listaCandidato listaA= new listaCandidato();
				listaA.addId(id);
				cc.Add(listaA);
				a_=cc.Count-1;
			}
			return a_;
		}
		void concatenar(int posA, int posB,float dist, int idA,int idB){
			// se agrega la union entre a y b
			candidato temporal = new candidato();
			temporal.setDatos(idA,idB,dist);
			cc[posA].addCandidato(temporal);
			cantidadCirculos++;
			//se concatenan las dos listas
			for (int i = 0; i < cc[posB].l.Count; i++) {
				cc[posA].l.Add(cc[posB].l[i]);
			}
			for (int i = 0; i < cc[posB].ID.Count; i++) {
				cc[posA].ID.Add(cc[posB].ID[i]);
			}
			cc.RemoveAt(posB);
		}
		
		void eliminarCandidatoKruskal(int a,int b){
			for (int i = 0; i <candidatos[a].eL.Count; i++) {
				if(candidatos[a].eL[i].v_d.id== b)
					candidatos[a].eL.RemoveAt(i);
		}
		}
		
	
		int cantidadDeVerticesKruskal(){
			int total=0;
			for (int i = 0; i < cc.Count; i++) {
				total+=cc[i].l.Count;
			}
			return total;
		}
		bool verificarSiYaTerminoKruskal(){
			int contador=0;
			for (int i = 0; i <candidatos.Count; i++) {
				if(candidatos[i].eL.Count==0){
						contador++;
				}
			}
			if(contador==candidatos.Count)
				return true;
			
			return false;
		}
		void crearBitmapKruskal(){
			pictureBox1.BackgroundImage.Dispose();
			Bitmap bmpKruskal=new Bitmap(GrafoKruskal.getBmp());
			Pen kruskalpen = new Pen(Color.DeepSkyBlue,10);
			Graphics gKruskal= Graphics.FromImage(bmpKruskal);
			//crear bitmap Kruskal
			for (int j = 0; j <krus.Count; j++) {
				for (int i = 0; i < krus[j].l.Count; i++) {
					gKruskal.DrawLine(kruskalpen,Lista[krus[j].l[i].getA()-1].getX(),Lista[krus[j].l[i].getA()-1].getY(),Lista[krus[j].l[i].getB()-1].getX(),Lista[krus[j].l[i].getB()-1].getY());
				}
			}
			pictureBox1.BackgroundImage=bmpKruskal;
		}
	//***************************************************PRIM***********************************************************
	//******************************************************************************************************************	
		List<listaCandidato> Prim(){
			candidatos= new List<vertex>(GrafoPrim.v1);
			ccPrim= new List<listaCandidato>();
			ccPrim.Add(new listaCandidato());
			ccPrim[0].ID.Add(verticeInicial);
			ListaTotalVisitados= new List<int>();//a esta lista se le van eliminando las vertices, si esta vacía ya terminó
			llenarVisitadosTotal();
			ListaTotalVisitados.Remove(verticeInicial);
			while(!verificarSiYaTerminoPrim()){
				opcionPrim=encontrarMenorPrim();
				if(factiblePrim(opcionPrim.getA(),opcionPrim.getB())){//Esto revisa que el vertice a y b no pertenezcan a la misma lista
					concatenarPrim(opcionPrim.getA(),opcionPrim.getB(),opcionPrim.getDistancia() );//agrega el nuevo candidato a la lista
				}
				eliminarCandidatoPrim(opcionPrim.getA(),opcionPrim.getB());
			}
			return ccPrim;
		}
		candidato encontrarMenorPrim(){
			float menor=99999999;
				int a,b;
				candidato mandar=new candidato();
				for (int i = 0; i <ListaVisitados.Count; i++) {
					for (int j = 0; j < candidatos[ListaVisitados[i]-1].eL.Count; j++) {
						if(candidatos[ListaVisitados[i]-1].eL[j].distancia<menor){
							menor=candidatos[ListaVisitados[i]-1].eL[j].distancia;
							a=candidatos[ListaVisitados[i]-1].id;
							b=candidatos[ListaVisitados[i]-1].eL[j].v_d.id;
							mandar.setDatos(a,b,menor);
						}
					}
				}
				
				return mandar;
		}
		bool factiblePrim(int a, int b){
			if(ccPrim[ccPrim.Count-1].ID.Contains(a) && !ccPrim[ccPrim.Count-1].ID.Contains(b)){
				return true;
			}
			return false;
		}
		void concatenarPrim(int a,int b,float distancia){
			candidato temporal= new candidato();
			temporal.setDatos(a,b,distancia);
			ccPrim[ccPrim.Count-1].addCandidato(temporal);
			ccPrim[ccPrim.Count-1].ID.Add(b);
			ListaVisitados.Add(b);
			ListaTotalVisitados.Remove(b);
		}
		void eliminarCandidatoPrim(int a, int b){
			for (int i = 0; i <candidatos[a-1].eL.Count; i++) {
					if(candidatos[a-1].eL[i].v_d.id== b)
						candidatos[a-1].eL.RemoveAt(i);
			}
		}
		bool verificarSiYaTerminoPrim(){
			int contador=0;
				for (int i = 0; i <ListaVisitados.Count; i++) {
					if(candidatos[ListaVisitados[i]-1].eL.Count==0){
								contador++;
						}
					}
			if(contador==ListaVisitados.Count){
				if(ListaTotalVisitados.Count==0){
					ListaVisitados.Clear();
					return true;
				}else{
					ListaVisitados.Clear();
					ListaVisitados.Add(ListaTotalVisitados[0]);
					ccPrim.Add(new listaCandidato());
					ccPrim[ccPrim.Count-1].ID.Add(ListaVisitados[0]);
					ListaTotalVisitados.Remove(ListaVisitados[0]);
				}
			}	
				return false;
		}
		void crearBitmapPrim(){
			pictureBox1.BackgroundImage.Dispose();
			Bitmap bmpPrim=new Bitmap(bmp);
			Pen Primpen = new Pen(Color.DeepSkyBlue,10);
			Graphics gPrim= Graphics.FromImage(bmpPrim);
			//crear bitmap Kruskal
			for (int j = 0; j <PrimCompleto.Count; j++) {
				for (int i = 0; i < PrimCompleto[j].l.Count; i++) {
					gPrim.DrawLine(Primpen,Lista[PrimCompleto[j].l[i].getA()-1].getX(),Lista[PrimCompleto[j].l[i].getA()-1].getY(),Lista[PrimCompleto[j].l[i].getB()-1].getX(),Lista[PrimCompleto[j].l[i].getB()-1].getY());
				}
			}
			pictureBox1.BackgroundImage=bmpPrim;
		}
		void llenarVisitadosTotal(){
			for (int i = 0; i < GrafoPrim.v1.Count; i++) {
				ListaTotalVisitados.Add(GrafoPrim.v1[i].id);
			}
		}
		List<vertex> copiarGrafo( List<vertex> copi){
			return new List<vertex>(copi);
		}
		void Button2Click(object sender, EventArgs e)
		{
			krus = kruskal();
			 crearBitmapKruskal();
		}
		void Button4Click(object sender, EventArgs e)
		{
			MostrarCamino camino = new MostrarCamino(Lista,cc,bmp,ccPrim,bmp);
			camino.Visible=true;
		}
		//*******************************************ANIMAR****************************************
		//*****************************************************************************************
		void Button5Click(object sender, EventArgs e)
		{  
			if(ListaVisitados==null)
				Help.ShowPopup(null,"Debes seleccionar un vertice en el Listbox",new Point(textBox1.Right, this.textBox1.Bottom));
			else{ 
				PrimCompleto =Prim();
				crearBitmapPrim();}
		}
		void Button6Click(object sender, EventArgs e)//BOTONES DE ANIMAR kruskal
		{
			if(textBox1.Text==""  ){
				Help.ShowPopup(null,"Debes definir un rango ",new Point(textBox1.Right, this.textBox1.Bottom));
				return;
			}
			particulas= new List<particula>();
			 particulasAnimar=new List<particula>();
			 llenarParticulasKruskal();//se llena la lista de las pariculas con las coordenadas a recorrer
			 buscarMasParticulasPrimeraVertice(verticeInicial,-1);
			 Point circulo;
			//esto sirve para copiar el bitmap
			System.Drawing.Imaging.PixelFormat format = bmp.PixelFormat;
			RectangleF cloneRect = new RectangleF(0, 0, bmp.Width, bmp.Height);
			//esto es para pintar el circulo
			Graphics gra2;
			Brush b1 = new SolidBrush(Color.Blue);
			Brush b2 = new SolidBrush(Color.FromArgb(0,Color.White));
			Bitmap temp=new Bitmap(bmp.Clone(cloneRect,format));
			gra2 = Graphics.FromImage(temp);
			pictureBox1.Image=temp;
			while(particulasAnimar.Count!=0){
				particulasQueYaTerminaron();//esta función elimina las particulas que ya terminaron y busca nuevas
				gra2.Clear(Color.Transparent);//Limpiar el bitmap
				for (int i = 0; i < particulasAnimar.Count; i++) {
					if(!particulasAnimar[i].termino()){
						circulo= particulasAnimar[i].avanzar();
						gra2.FillEllipse(b1,circulo.X-particulasAnimar[i].getRadio()/2,circulo.Y-particulasAnimar[i].getRadio()/2,particulasAnimar[i].getRadio(),particulasAnimar[i].getRadio());
					}
				}
				pictureBox1.Refresh();
			}
		}
		void Button3Click(object sender, EventArgs e)
		{
			if(textBox1.Text==""){
				Help.ShowPopup(null,"Debes definir un rango o crear el algoritmo",new Point(textBox1.Right, this.textBox1.Bottom));
				return;
			}
			particulas= new List<particula>();
			 particulasAnimar=new List<particula>();
			 llenarParticulasPrim();//se llena la lista de las pariculas con las coordenadas a recorrer
			 buscarMasParticulasPrimeraVertice(verticeInicial,-1);
			 Point circulo;
			//esto sirve para copiar el bitmap
			System.Drawing.Imaging.PixelFormat format = bmp.PixelFormat;
			RectangleF cloneRect = new RectangleF(0, 0, bmp.Width, bmp.Height);
			//esto es para pintar el circulo
			Graphics gra2;
			Brush b1 = new SolidBrush(Color.Blue);
			Brush b2 = new SolidBrush(Color.FromArgb(0,Color.White));
			Bitmap temp=new Bitmap(bmp.Clone(cloneRect,format));
			gra2 = Graphics.FromImage(temp);
			pictureBox1.Image=temp;
			while(particulasAnimar.Count!=0){
				particulasQueYaTerminaron();//esta función elimina las particulas que ya terminaron y busca nuevas
				gra2.Clear(Color.Transparent);//Limpiar el bitmap
				for (int i = 0; i < particulasAnimar.Count; i++) {
					if(!particulasAnimar[i].termino()){
						circulo= particulasAnimar[i].avanzar();
						gra2.FillEllipse(b1,circulo.X-particulasAnimar[i].getRadio()/2,circulo.Y-particulasAnimar[i].getRadio()/2,particulasAnimar[i].getRadio(),particulasAnimar[i].getRadio());
					}
				}
				pictureBox1.Refresh();
			}
		}
		void particulasQueYaTerminaron(){
			for (int i = 0; i < particulasAnimar.Count; i++) {
				if(particulasAnimar[i].termino()){
					//se buscan nuevas particulas a partir de la que se va a eliminar
					buscarParticulasNuevas(particulasAnimar[i].getFin(),particulasAnimar[i].getInicio(),particulasAnimar[i].getRadio());
					particulasAnimar.RemoveAt(i);
				}
			}
		}
		void buscarParticulasNuevas(int inicio,int fin,int r){
				int cantidad=0;
			int rad=1;
			//Busca la cantidad de particulas que ya terminaron para dividir el radio
			for (int i = 0; i < particulas.Count; i++){
				if(fin!=-1){
					if(particulas[i].getInicio()==inicio && particulas[i].getFin()!=fin){//no se guardan particulas inversas
							cantidad++;
					}
				}else{
					if(particulas[i].getInicio()==inicio ){//Primera particula
						cantidad++;
				}
				}
			}
				//agrega las nuevas particulas y divide el radio
				if(cantidad>0)
					rad=r/cantidad;
			for (int i = 0; i < particulas.Count; i++) {
				if(fin!=-1){
				if(particulas[i].getInicio()==inicio && particulas[i].getFin()!=fin){//no se guardan particulas inversas
							particulas[i].setRadio(rad);
							particulasAnimar.Add(particulas[i]);
				}
				}else{
					if(particulas[i].getInicio()==inicio ){//Primera particula
						particulas[i].setRadio(rad);
						particulasAnimar.Add(particulas[i]);
				}
				}
			}
		}
		void buscarMasParticulasPrimeraVertice(int inicio,int fin){
			int cantidad=0;
			int r;
			//Busca la cantidad de particulas para dividir el radio
			for (int i = 0; i < particulas.Count; i++){
					if(particulas[i].getInicio()==inicio ){//Primera particula
						cantidad++;
				}
			}
				//agrega las nuevas particulas y divide el radio
				r=radio/cantidad;
			for (int i = 0; i < particulas.Count; i++) {
					if(particulas[i].getInicio()==inicio ){//Primera particula
						particulas[i].setRadio(r);
						particulasAnimar.Add(particulas[i]);
				}
			}
		}
		void llenarParticulasKruskal(){
			int x1,x2,y1,y2;
			for (int j = 0; j <krus.Count; j++) {
				for (int i = 0; i <krus[j].l.Count; i++) {
					x1=Lista[krus[j].l[i].getA()-1].getX();
					y1=Lista[krus[j].l[i].getA()-1].getY();
					x2=Lista[krus[j].l[i].getB()-1].getX();
					y2=Lista[krus[j].l[i].getB()-1].getY();
					particula temp=new particula(AgregarListaPuntos(x1,y1,x2,y2),krus[j].l[i].getA(),krus[j].l[i].getB());
					particulas.Add(temp);
					//Aquí se guardan las particulas inversas 
					temp=new particula(AgregarListaPuntos(x2,y2,x1,y1),krus[j].l[i].getB(),krus[j].l[i].getA());
					particulas.Add(temp);
					
				}
				
			}
		}
		void llenarParticulasPrim(){
			int x1,x2,y1,y2;
			for (int j = 0; j <PrimCompleto.Count; j++) {
				for (int i = 0; i <PrimCompleto[j].l.Count; i++) {
					x1=Lista[PrimCompleto[j].l[i].getA()-1].getX();
					y1=Lista[PrimCompleto[j].l[i].getA()-1].getY();
					x2=Lista[PrimCompleto[j].l[i].getB()-1].getX();
					y2=Lista[PrimCompleto[j].l[i].getB()-1].getY();
					particula temp=new particula(AgregarListaPuntos(x1,y1,x2,y2),PrimCompleto[j].l[i].getA(),PrimCompleto[j].l[i].getB());
					particulas.Add(temp);
					//Aquí se guardan las particulas inversas 
					temp=new particula(AgregarListaPuntos(x2,y2,x1,y1),PrimCompleto[j].l[i].getB(),PrimCompleto[j].l[i].getA());
					particulas.Add(temp);
					
				}
				
			}
		}
		List<Point>AgregarListaPuntos(int x1_,int y1_,int x2_,int y2_ ){
			int x1=x1_;
			int x2=x2_;
			int y1=y1_;
			int y2=y2_;
			List<Point>mandar=new List<Point>();
			int xAnterior=x1_;
			int yAnterior=y1_;
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
					if(x1<=x2+4 && x1>=x2-4)break;
					if(xAnterior< x1){
						x1+=8;
					}else x1-=8;
					mandar.Add(new Point(x1,y1));
					xAnterior=x1;
					yAnterior=y1;
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
					//acelerar el proceso
					if(y1<=y2+4 && y1>=y2-4)break;
					if(yAnterior< y1){
						y1+=8;
					}else y1-=8;
					xAnterior=x1;
					yAnterior=y1;
					mandar.Add(new Point(x1,y1));
				}
			}
			return mandar;
		}
		void TextBox1TextChanged(object sender, EventArgs e)
		{
			
		}
		void TextBox1Leave(object sender, EventArgs e)
		{
			
		}
		void TextBox1Validated(object sender, EventArgs e)
		{
			try {
				 radio=Int32.Parse(textBox1.Text);
				if(radio<40&&radio >200){
					Help.ShowPopup(null,"cantidad fuera de rango",new Point(textBox1.Right, this.textBox1.Bottom));
				textBox1.Text="";
				}
			} catch (Exception) {
				Help.ShowPopup(null,"Solo se aceptan numeros",new Point(textBox1.Right, this.textBox1.Bottom));
				textBox1.Text="";
				//throw;
			}
		}
	
}
}
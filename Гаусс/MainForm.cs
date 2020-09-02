/*
 * Создано в SharpDevelop.
 * Пользователь: Danik
 * Дата: 11.10.2019
 * Время: 12:04
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Гаусс
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		public void Output(double[,] Mas, DataGridView Grid,int a)

	{
			dataGrid.Rows.Add();
			for (int i= 0;i<a;i++)
		    {
		    	dataGrid.Rows.Add();
		    	for(int j= 0;j<=a;j++)
		    	{
		    		dataGrid.Rows[i+a+1].Cells[j].Value = Mas[i, j];
		    	}
		    }
	}
		public double[] Gauss (double[,] m,double []B)
		{
			int a=B.Length;
			double k;
			int i=1;
			int j=0;
			double [,] Mas= new double[a,a+1];
			//Склейка массивов
			for (i=0;i<a;i++)
			{
				for (j=0;j<a;j++)
				{
					Mas[i,j]=m[i,j];
				}
				Mas[i,a]=B[i];
			}
			
			  for(int z=0;z<a;z++)
			  {
			  for(i=z+1;i<a;i++)
			  	 	{
			  	 	k=-Mas[i,z]/Mas[z,z];
			        
			  	for(j=z;j<=a;j++)
			 		 {
			  		   Mas[i,j]=Mas[i,j]+Mas[z,j]*k;
			  		 }
			  	   }
			  
			  }
			 double c;
	         double[]X=new double[a];
			  for(i = a-1;i>=0;i--)
			  	 	{
			  	      c=0;
			  	      if(i<a-1)
			  			{
			  				double b=X[i+1];
			  				for(int z = i;z>=0;z--)
			  				{
			  					Mas[z,i+1]=Mas[z,i+1]*b;
			  				}
			  			}
			  		for(j=a;j>i;j--)
			 			 {
			  				if(j==a)
			  				{
			  					c=c+Mas[i,j];
			  				}
			  			
			  				else c=c-Mas[i,j];
			  		  
			  			 }
			  		X[i]=c/Mas[i,i];
			  }
			  		return X;
			  		
			  		
		}
		//Добавление колонок
		void Button1Click(object sender, EventArgs e)
		{
			double a= Convert.ToDouble(textBox1.Text);
			for (double i=0;i<a;i++)
			{
				dataGrid.Columns.Add("a"+(i+1),"a"+(i+1));
				dataGrid.Rows.Add();
				
			}
	        dataGrid.Columns.Add("b","b");
	       
					
		}
		//Прямой ход
		void Button2Click(object sender, EventArgs e)
		{
			int a= Convert.ToInt32(textBox1.Text);
			double k;
			int i=1;
			int j=0;
			double [,] Mas= new double[a,a+1];
			
			
			  for (int rows = 0;rows<a;rows++ )
				{
				for (int col=0;col<=a;col++)
				    {
				 	Mas[rows,col] = Convert.ToDouble(dataGrid.Rows[rows].Cells[col].Value);
				
				    }
				} 
			 
			  for(int z=0;z<a;z++)
			  {
			  for(i=z+1;i<a;i++)
			  	 	{
			  	 	k=-Mas[i,z]/Mas[z,z];
			  	
			  	for(j=z;j<=a;j++)
			 		 {
			  		   Mas[i,j]=Mas[i,j]+Mas[z,j]*k;
			  		 }
			  	  
			  	  
			  	   }
			  }
			  
			  Output(Mas,dataGrid,a);
		    
		    
		}
		//Обратный ход
		void Button3Click(object sender, EventArgs e)
		{
	         int a= Convert.ToInt32(textBox1.Text);
	         double c;
	         double[]X=new double[a];
	         dataGrid.Rows.Add();
			  for(int i = 2*a;i>a;i--)
			  	 	{
			  	      c=0;
			  	      if(i<2*a)
			  		{
			  			double b=X[i-a];
			  			for(int z = i;z>a;z--)
			  			{
			  				dataGrid.Rows[z].Cells[i-a].Value=Convert.ToDouble(dataGrid.Rows[z].Cells[i-a].Value)*b;
			  			}
			  		}
			  		for(int j=a;j>=i-a;j--)
			 			 {
			  				if(j==a)
			  				{
			  					c=c+Convert.ToDouble(dataGrid.Rows[i].Cells[j].Value);
			  				}
			  			
			  				else c=c-Convert.ToDouble(dataGrid.Rows[i].Cells[j].Value);
			  		  
			  			 }
			  		X[ i-a-1]=c/Convert.ToDouble(dataGrid.Rows[i].Cells[i-a-1].Value);
			  		
			  		
			  	   }
			  	  
			  string[] x=new string[a];
			   for (int j=0;j<a;j++)
			  {
			   	x[j]="x"+(j+1);
			  }
			  dataGrid.Rows.Add(x);
			 for (int j=0;j<a;j++)
			  {
			 	dataGrid.Rows[2*a+2].Cells[j].Value=x[j];
			  }
			 
			  
			   for (int j=0;j<a;j++)
			  {
			   	dataGrid.Rows[2*a+3].Cells[j].Value=X[j];
			  }
		}
		//Очистка
		void Button4Click(object sender, EventArgs e)
		{
			dataGrid.Columns.Clear();
			
		}
		//тест кнопка полного хода
		void Button5Click(object sender, EventArgs e)
		{
			double[,]mas = new double[3,3];
			double[] b =new double[3];
			mas[0,0]=1;
			mas[0,1]=4;
			mas[0,2]=7;
			mas[1,0]=2;
			mas[1,1]=5;
			mas[1,2]=8;
			mas[2,0]=3;
			mas[2,1]=6;
			mas[2,2]=14;
			b[0]=11;
			b[1]=12;
			b[2]=11;
			double[] res =Gauss(mas,b);
			dataGrid.Rows[2].Cells[0].Value=res[0];
			dataGrid.Rows[2].Cells[1].Value=res[1];
		}
	}
}

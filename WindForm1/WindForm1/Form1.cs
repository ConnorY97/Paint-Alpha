using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection; 

namespace WindForm1
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			
			typeof(Panel).InvokeMember("DoubleBuffered",
				BindingFlags.SetProperty
				| BindingFlags.Instance
				| BindingFlags.NonPublic,
				null, panel1, new object[] { true });

		}


		private string m_LastFileName = "";
		private Rectangle m_Box = new Rectangle(100, 100, 250, 250); 


		//Creating a new image 
		private void newToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var result = MessageBox.Show("Do you want to save?", "New", MessageBoxButtons.YesNoCancel);

			if (result == DialogResult.Yes)
			{
				OpenFileDialog saveFile = new OpenFileDialog();

				saveFile.ShowDialog();
			}
			else if (result == DialogResult.No)
			{

			}
			else if (result == DialogResult.Cancel)
			{

			}
		}

		//Opening an already exisiting image 
		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFile = new OpenFileDialog();

			if (openFile.ShowDialog() == DialogResult.OK)
			{
				string fileName = openFile.FileName;
				Bitmap userImage = new Bitmap(fileName);

				pictureBox1.Image = userImage;
			}

		}

		private void DrawBox()
		{
			
		}

		
		//Where the image is displayed 
		private void pictureBox1_Click(object sender, EventArgs e)
		{
			
		}

		//Saving the image in the same location if a previous save exists 
		private void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (m_LastFileName == "")
			{
				Save();
			}
			else
			{
				pictureBox1.Image.Save(m_LastFileName); 
			}
		}

		//Save function 
		//	Checks if a file already exists of the same name 
		private void Save()
		{
			SaveFileDialog window = new SaveFileDialog();
			window.Title = "Save";
			window.Filter = "Png|*.png|Jpg|*.jpg"; 

			if (window.ShowDialog() == DialogResult.OK)
			{
				m_LastFileName = window.FileName;

				pictureBox1.Image.Save(m_LastFileName); 
			}
		}

		private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Save();
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//Close();
			Application.Exit();
		}	 
			 
		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void panel1_Paint(object sender, PaintEventArgs e)
		{
			SolidBrush brush = new SolidBrush(Color.Red);
			Graphics graphics;
			graphics = CreateGraphics();
			graphics.FillRectangle(brush, m_Box);
			brush.Dispose();
			graphics.Dispose(); 
		}
	}
}

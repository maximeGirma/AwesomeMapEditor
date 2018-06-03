using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private Color initialColor;
        public Color colorUpdate = Color.White;
        public VariableStorage storage = new VariableStorage();
        private List<CustomButton[,]> mapGroupButtons = new List<CustomButton[,]>(); 
       

        private int compteur = 0;

        private Panel panel = new Panel();
        
        public Form1()
        {
             
            InitializeComponent();
            panel.Size = new Size(200, 200);
        }

        void btnEvent_click(object sender, EventArgs e)
        {
            Console.WriteLine(sender.ToString());
           // this.BackColor = colorUpdate;
            
        }

        public Color getUpdatedColor()
        {
            return colorUpdate;
        }

        private void generateNewMap_Click(object sender, EventArgs e)
        {

            listBox1.Items.Insert(this.compteur, this.compteur.ToString());
               
            //this.mapGroupButtons.Add(new Button());
            CustomButton[,] btn = new CustomButton[20, 20];
             for (int x = 0; x < btn.GetLength(0); x++)
             {
                 for (int y = 0; y < btn.GetLength(1); y++)
                 {
                     if (x == 0) this.initialColor = Color.Blue;
                     else if (x == 19) this.initialColor = Color.Blue;
                     else if (y == 0) this.initialColor = Color.Blue;
                     else if (y == 19) this.initialColor = Color.Blue;
                     else this.initialColor = Color.White;
                    Console.WriteLine(this.compteur);
                    btn[x, y] = new CustomButton(this.initialColor, x, y, this.compteur.ToString(), this.storage);
                     btn[x, y].SetBounds(30 * x, 30 * y, 30, 30);
                     btn[x, y].Click += new EventHandler(this.btnEvent_click);
                     //Controls.Add(btn[x, y]);
                     //btn[x, y].BackColor = Color.Black;
                 }
             }
            mapGroupButtons.Add(btn);
          
          
           this.compteur++;
        }

        private void entryPoint_Click(object sender, EventArgs e)
        {
            this.storage.colorToUpdate = Color.Green;
        }

        private void obstacle_Click(object sender, EventArgs e)
        {
            this.storage.colorToUpdate = Color.Blue;
        }

        private void exitPoint_Click(object sender, EventArgs e)
        {
            this.storage.colorToUpdate = Color.Yellow;
        }

        private void emptyPlace_Click(object sender, EventArgs e)
        {
            this.storage.colorToUpdate = Color.White;
        }

        private void mapReset_Click(object sender, EventArgs e)
        {
            
        }

        private void saveMap_Click(object sender, EventArgs e)
        {
            //trying to writte a JSON
            List<Data> _data = new List<Data>();
            string json = "";

            foreach (Button[,] buttonList in mapGroupButtons)
            {
                foreach(CustomButton button in buttonList)
                {
                    _data.Add(new Data()
                    {
                        mapName = button.mapName,
                        numberNameX = button.numberNameX,
                        numberNameY = button.numberNameY,
                        color = button.color
                    });
                }
                
            }

            json = JsonConvert.SerializeObject(_data);

            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    
                    myStream.Close();
                }
                System.IO.File.WriteAllText(saveFileDialog1.FileName, json);
                MessageBox.Show("sauvegarde terminée (probablement ...)");
            }

            //write string to file
            // System.IO.File.WriteAllText(@"rawJSON.json", json);

            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            new Button();
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {
            Button a = new Button();
            Console.WriteLine("pouet");
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            foreach (Button[,] buttonlist in mapGroupButtons)
            {
                foreach (Button button in buttonlist)
                {
                    Controls.Remove(button);
                }
            }
            string index = listBox1.SelectedIndex.ToString();
            int index2 = Int32.Parse(index);
            Console.WriteLine(index);
            foreach (Button button in mapGroupButtons[index2])
            {
                Controls.Add(button);
            }
        }

        private void deleteMap_Click(object sender, EventArgs e)
        {

        }

        private void loadMaps_Click(object sender, EventArgs e)
        {
            System.IO.StreamReader file = null;
            string json = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                 file = new
                   System.IO.StreamReader(openFileDialog1.FileName);
                     json = file.ReadToEnd();
                file.Close();
            }


            int counter = 0;
            string line;

            // Read the file and display it line by line.  
            //System.IO.StreamReader file = new System.IO.StreamReader(@"rawJSON.json");

            try
            {
                List<Data> items = JsonConvert.DeserializeObject<List<Data>>(json);
           
            file.Close();
            int compteurPourri = 0;
            

            foreach (Data element in items)
            {
                compteurPourri++;
                
            }
            compteurPourri = compteurPourri / 400;

            for (int i = 0; i < compteurPourri; i++)
            {
                CustomButton[,] btn = new CustomButton[20, 20];
                mapGroupButtons.Add(btn);
                listBox1.Items.Insert(this.compteur, this.compteur.ToString());
                this.compteur++;
            }
            
            foreach ( Data element in items)
            {
                
                CustomButton a = new CustomButton(element.color, element.numberNameX, element.numberNameY, element.mapName, this.storage);
                a.SetBounds(30 * element.numberNameX, 30 * element.numberNameY, 30, 30);
                a.Click += new EventHandler(this.btnEvent_click);
                //Controls.Add(btn[x, y]);
                //btn[x, y].BackColor = Color.Black;
               
                mapGroupButtons[Int32.Parse(element.mapName)][element.numberNameX,element.numberNameY] = a;

            }
            Console.WriteLine("chargement terminé");
            }
            catch (System.ArgumentNullException errorReading) {
                MessageBox.Show("Erreur lecture" + errorReading);
            }
        }

        private void generateJsFile_Click(object sender, EventArgs e)
        {
            JsGenerator.generate(mapGroupButtons);
        }
    }
}

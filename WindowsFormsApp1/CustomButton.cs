using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class CustomButton : Button
    {
        public string mapName;
        public int numberNameX;
        public int numberNameY;
        public string asset;
        public Color color;
        public Color selectedColor;
        private VariableStorage storage;

        public CustomButton(Color colorInitialisation, int numberX, int numberY, string mapName, VariableStorage parent)
        {
            
            this.numberNameX = numberX;
            this.numberNameY = numberY;
            this.changeColor(colorInitialisation);
            this.Click += new EventHandler(this.btnEvent_click);
            this.storage = parent;
            this.mapName = mapName;
        }


        public void changeColor(Color colorChoice)
        {
            this.color = colorChoice;
            this.BackColor = colorChoice;
            
        }

        void btnEvent_click(object sender, EventArgs e)
        {
            Console.WriteLine(this.numberNameX);
            Console.WriteLine(this.numberNameY);
            this.changeColor(this.storage.colorToUpdate);
        }



    }
}

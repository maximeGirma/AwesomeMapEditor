using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    static class JsGenerator
    {
        public static void generate(List<CustomButton[,]> mapsList)
        {

            foreach (Button[,] map in mapsList)
            {
                
                foreach (CustomButton button in map)
                {
                    if (button.color == Color.Blue)
                    {
                        string code = "";
                        if (button.numberNameX == 0 || button.numberNameX == 19 || button.numberNameY == 0 || button.numberNameY == 19) code = "WALL";
                        else
                        {
                            if (mapsList[Int32.Parse(button.mapName)][button.numberNameX - 1, button.numberNameY].color == Color.Blue) code += "L";
                            if (mapsList[Int32.Parse(button.mapName)][button.numberNameX + 1, button.numberNameY].color == Color.Blue) code += "R";
                            if (mapsList[Int32.Parse(button.mapName)][button.numberNameX, button.numberNameY - 1].color == Color.Blue) code += "T";
                            if (mapsList[Int32.Parse(button.mapName)][button.numberNameX, button.numberNameY + 1].color == Color.Blue) code += "B";
                        }

                        string asset = "";

                        switch (code)
                        {
                            case "LRTB": asset = "empty";
                                break;
                            case "RTB" : asset = "vertical_left";
                                break;
                            case "TB": asset = "vertical_both";
                                break;
                            case "B": asset = "end_top";
                                break;
                            case "LTB":asset = "vertical_right";
                                break;
                            case "LT": asset = "corner_SE";
                                break;
                            case "LB": asset = "corner_NE";
                                break;
                            case "LR": asset = "horizontal_both";
                                break;
                            case "LRT": asset = "horizontal_bottom";
                                break;
                            case "LRB": asset = "horizontal_top";
                                break;
                            case "RB": asset = "corner_NO";
                                break;
                            case "RT": asset = "corner_SO";
                                break;
                            case "T": asset = "end_bottom";
                                break;
                            case "R": asset = "end_left";
                                break;
                            case "L": asset = "end_right";
                                break;
                            case "": asset = "square";
                                break;
                            case "WALL": asset = "ice_wall";
                                break;
                            default:
                                MessageBox.Show("Erreur GENERATION SWITCH CASE asset" );
                                break;

                            
                        }
                        button.asset = asset;

                    }
                    else if (button.color == Color.Yellow)
                    {
                        button.asset = "exit";
                        /*
                        string code = "";
                        if (mapsList[Int32.Parse(button.mapName)][button.numberNameX - 1, button.numberNameY -1].color == Color.Blue && button.numberNameX != 0) code += "TL";
                        if (mapsList[Int32.Parse(button.mapName)][button.numberNameX - 1, button.numberNameY +1].color == Color.Blue) code += "TR";
                        if (mapsList[Int32.Parse(button.mapName)][button.numberNameX + 1, button.numberNameY +1].color == Color.Blue ) code += "BR";
                        if (mapsList[Int32.Parse(button.mapName)][button.numberNameX + 1, button.numberNameY -1].color == Color.Blue && button.numberNameX != 0) code += "BL";
                    */
                    }
                    else
                    {
                        button.asset = "empty";
                    }
                }

                
            }

            /*

            List<Data> _data = new List<Data>();
            string json = "";

            foreach (Button[,] buttonList in mapsList)
            {
                foreach (CustomButton button in buttonList)
                {
                    _data.Add(new Data()
                    {
                        mapName = button.mapName,
                        numberNameX = button.numberNameX,
                        numberNameY = button.numberNameY,
                        color = button.color,
                        asset = button.asset
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


            */


            //obstacles
            
            string JSONToWrite = "export const getObstaclesDisposition =(level)=>{\n switch (level){\n ";
            int compteurMap = 1;

          foreach (Button[,] buttonList in mapsList)
            {
                JSONToWrite += "case " + compteurMap + " : return [";
                compteurMap++;
                foreach (CustomButton button in buttonList)
                {
                    if (button.color == Color.Blue) {
                        JSONToWrite += "\n{\nleft : " + (button.numberNameX * 0.05).ToString("0.00", CultureInfo.GetCultureInfo("en-US")) + ",\n";
                        JSONToWrite += "top : " + (button.numberNameY * 0.05).ToString("0.00", CultureInfo.GetCultureInfo("en-US")) + ",\n";
                        JSONToWrite += "percentageLeft : '" + (button.numberNameX * 5) + "%',\n";
                        JSONToWrite += "percentageTop : '" + (button.numberNameY * 5)+ "%',\n";
                        JSONToWrite += "asset : " + button.asset + ",\n},\n";
                    }
                }

                JSONToWrite += "\n]\n\n";
            }

            JSONToWrite += "default : return false\n}\n}";

            //start

            JSONToWrite += "\n\nexport const getStartingPoint = (level) =>{\n  switch (level){\n";
            compteurMap = 1;
            foreach (Button[,] buttonList in mapsList)
            {
                JSONToWrite += "case " + compteurMap + " : return {";
                compteurMap++;
                foreach (CustomButton button in buttonList)
                {
                    if (button.color == Color.Green)
                    {
                        JSONToWrite += "\n\nleft : " + (button.numberNameX * 0.05).ToString("0.00", CultureInfo.GetCultureInfo("en-US")) + ",\n";
                        JSONToWrite += "top : " + (button.numberNameY * 0.05).ToString("0.00", CultureInfo.GetCultureInfo("en-US")) + ",\n";
                        JSONToWrite += "asset : " + button.asset + "}\n";
                        
                    }
                }

                JSONToWrite += "\n\n";
            }
            JSONToWrite += "default : return false\n}\n}";

            //exit

            JSONToWrite += "\n\nexport const getExit =  (level) =>{\n  switch (level){\n";
            compteurMap = 1;
            foreach (Button[,] buttonList in mapsList)
            {
                JSONToWrite += "case " + compteurMap + " : return {";
                compteurMap++;
                foreach (CustomButton button in buttonList)
                {
                    if (button.color == Color.Yellow)
                    {
                        JSONToWrite += "\n\nleft : " + (button.numberNameX * 0.05).ToString("0.00", CultureInfo.GetCultureInfo("en-US")) + ",\n";
                        JSONToWrite += "top : " + (button.numberNameY * 0.05).ToString("0.00", CultureInfo.GetCultureInfo("en-US")) + ",\n";
                        JSONToWrite += "percentageLeft : '" + (button.numberNameX * 5) + "%',\n";
                        JSONToWrite += "percentageTop : '" + (button.numberNameY * 5) + "%',\n";
                        JSONToWrite += "asset : " + button.asset + ",\n}\n";

                    }
                }

                JSONToWrite += "\n\n";
            }
            JSONToWrite += "default : return false\n}\n}";


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
                System.IO.File.WriteAllText(saveFileDialog1.FileName, JSONToWrite);
                MessageBox.Show("sauvegarde terminée (probablement ...)");
            }


            //System.IO.File.WriteAllText(@"C:\Users\Maxime\Desktop\testJSON.txt", JSONToWrite);
            

        }
    }
}

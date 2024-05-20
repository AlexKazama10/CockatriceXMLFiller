using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace CockatriceXMLFiller
{
    public partial class Form1 : Form
    {


        public string name;
        public string set;
        public string type;
        public string maintype;
        public string manacost;
        public string cmc;
        public string colors;
        public string coloridentity;
        public static int power;
        public static int toughness;
        private string pt = power.ToString() + "/" + toughness.ToString();


        public Form1()
        {

        InitializeComponent();

        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            Application.Exit();
        
        }

            private void button1_Click(object sender, EventArgs e)
        {

            name = textBoxCardname.Text;
            set = textBoxSet.Text;
            type = textBoxType.Text;
            
            switch(type)
            {
                case string creatures when type.Contains("Creature") : maintype = "Creature";
                    break;
                case string artifacts when type.Contains("Artifact"): maintype = "Artifact";
                    break;
                case string enchantments when type.Contains("Enchantment"): maintype = "Enchantment";
                    break;
                case string lands when type.Contains("Lands"): maintype = "Land";
                    break;

            }

            manacost = textBoxManacost.Text;
            colors = Regex.Replace(manacost, @"[\d-]", string.Empty);
            power = Int32.Parse(textBoxPower.Text); 
            toughness = Int32.Parse(textBoxToughness.Text);
            coloridentity = textBoxIdentity.Text;



                


            using (XmlWriter writer = XmlWriter.Create(name + ".xml"))
            {
                writer.WriteStartElement("card");
                writer.WriteElementString("name", name);
                writer.WriteElementString("set", set);
                writer.WriteStartElement("prop");
                writer.WriteElementString("type", type);
                writer.WriteElementString("maintype", maintype);
                writer.WriteElementString("manacost", manacost);
                writer.WriteElementString("cmc", cmc);
                writer.WriteElementString("colors", colors);
                writer.WriteElementString("coloridentity", coloridentity);
                writer.WriteElementString("pt", pt);
                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.Flush();
            }


            MessageBox.Show("Card XML generated successfully");
            DialogResult dialogResult = MessageBox.Show("Would you like to open it now?", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start(@"C:\Users\Utilizador\source\repos\CockatriceXMLFiller\CockatriceXMLFiller\bin\Debug\" + name + ".xml");

            }
            else if (dialogResult == DialogResult.No)
            {
                //do nothing

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            panelCard.Visible = true;
            panelStart.Visible = false;
            label2.Visible = false;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

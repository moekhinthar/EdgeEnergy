using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace EdgeEnergy
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                doc.Load(@"C:\Users\panmo\source\repos\EdgeEnergy\App_Data\XMLFile1.xml");
                System.Xml.XmlElement root = doc.DocumentElement;
                System.Xml.XmlNodeList lst = root.GetElementsByTagName("list");

                foreach (System.Xml.XmlNode n in lst)
                {
                    ListBox1.Items.Add(n.InnerText);
                }
            }
        }

        protected void btnLeft_Click(object sender, EventArgs e)
        {
            if (ListBox2.SelectedIndex != -1)
            {
                ListBox1.Items.Add(ListBox2.SelectedValue);
                ListBox2.Items.Remove(ListBox2.SelectedValue);
            }
        }

        protected void btnRight_Click(object sender, EventArgs e)
        {
            if (ListBox1.SelectedIndex != -1)
            {
                ListBox2.Items.Add(ListBox1.SelectedValue);
                ListBox1.Items.Remove(ListBox1.SelectedValue);
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ListBox2.Items.Count; i++)
            {
                if ((i + 1) < ListBox2.Items.Count)
                    txtSubmit.Text += ListBox2.Items[i] + ",";
                else
                    txtSubmit.Text += ListBox2.Items[i];
            }
        }
    }



}

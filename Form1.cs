using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;


namespace WindowsFormsApp4
{
    /*
     * TODO outFile needs thread locking IT'S DONNNNNNNNNNNNNE
     * 
     */
    public partial class Form1 : Form
    {
        SqlConnection cn = new SqlConnection();
        Logger logger = new Logger();
        PerformanceCounter cpuCounter;
        PerformanceCounter ramCounter;
        private int items = 0;
        private string queryString = "";
        //private string fileOut = ""; //not used 
        private readonly List<string> fileOutPuts = new List<string>();
        private string item = "";
        //private int count = 0;

        public Form1()
        {
            InitializeComponent();
            //setup cpu and ram trackers
            cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            ramCounter = new PerformanceCounter("Memory", "Available MBytes");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            readSQLConfig("versionNumber - ");
            label7.Text = item;
            updateLogger("<----------------->>" + label7.Text + "<<----------------->");
            setColors();
            Thread thread1 = new Thread(new ThreadStart(TimeThread));
            thread1.Start();
            startLogger();
        }

        private void TimeThread() //updates data and time
        {
            while (true)
            {
                DateTime aDate = DateTime.Now;
                try
                {
                    Invoke(new Action(() => //allows us to access textBox in other thread
                    {
                        readSQLConfig("timeFormat - ");
                        DateTimeLabel.Text = aDate.ToString(item);
                    }));
                }
                catch
                {

                }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Thread mainQueryThread = new Thread(new ThreadStart(QueryThread));
            if (textBox1.Text != string.Empty) //checks textbox to make sure it's not empty
            {
                listBox3.Items.Add("<<Query Set Is Successful>> -- <<Update--Success>>");
                updateLogger("<<Query Set Is Successful>> -- <<Update--Success>>");
                queryString = textBox1.Text.ToString(); //adds queryString = textbox
                mainQueryThread.Start();
            }
            else //noting in textbox 
            {
                listBox3.Items.Add("<<Query Set Is Not Successull>> -- <<Update--Fail>>");
                updateLogger("<<Query Set Is Not Successull>> -- <<Update--Fail>>");
                textBox1.Text = string.Empty;
            }
        }

        private void setColors()
        {
            readSQLConfig("ThemeBackColour - ");
            listBox1.BackColor = Color.FromName(item); //set backcolours
            listBox2.BackColor = Color.FromName(item);
            listBox3.BackColor = Color.FromName(item);
            SProctxt.BackColor = Color.FromName(item);
            button1.BackColor = Color.FromName(item);
            button2.BackColor = Color.FromName(item);
            OpenLoggerbtn.BackColor = Color.FromName(item);
            this.BackColor = Color.FromName(item); //Form1 look

            //set forecolours
            readSQLConfig("ThemeForeColour - ");
            listBox1.ForeColor = Color.FromName(item);  
            button2.ForeColor = Color.FromName(item); 
            button1.ForeColor = Color.FromName(item); 
            SProctxt.ForeColor = Color.FromName(item); 
            listBox2.ForeColor = Color.FromName(item);
            OpenLoggerbtn.ForeColor = Color.FromName(item);
            this.ForeColor = Color.FromName(item); //Form1 look
        }

        private void QueryThread()
        {
            Invoke(new Action(() => //allows us to access textBox in other thread
            {
                listBox3.Items.Add("<<Connecting to database>> -- <<Update--Success>>");
                updateLogger("<<Connecting to database>> -- <<Update--Success>>");
            }));
            string con = "Data Source=BA-R9WLXVM\\MSSQLSERVER03;Initial Catalog=DATEBASE_TWO;Integrated Security=True;";
            //+ DataSource +                                                                                                            
            //";integrated Security=sspi;initial catalog=" + InitialCatalog + ";");  ";
            try
            {
                Invoke(new Action(() =>
                {
                    listBox3.Items.Add("<<Connections sucsessful>> -- <<Update--Success>>");
                    updateLogger("<<Connections sucsessful>> -- <<Update--Success>>");
                }));
                
                cn = new SqlConnection(con);
            }
            catch
            {
                Invoke(new Action(() => 
                {
                    listBox3.Items.Add("<<Connection failed>> -- <<Update--Fail>>");
                updateLogger("<<Connection failed>> -- <<Update--Fail>>");
                }));
            }
            //string con = "Server= BA-R9WLXVM\\MSSQLSERVER03; Database= CreditCardData; Integrated Security=True;";
            Invoke(new Action(() =>
            {
                listBox3.Items.Add("<<Opening database connection>> -- <<Update--Success>>");
                updateLogger("<<Opening database connection>> -- <<Update--Success>>");
            }));
            try
            {
                cn.Open();
            }
            catch
            {
                MessageBox.Show(cn.GetSchema().ToString());
            }

            using (SqlCommand cmd = new SqlCommand(queryString, cn))
            {
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader(); //If queryString is not a correct query
                    try
                    {
                        while (reader.Read()) // prints the output of the query
                        {
                            Invoke(new Action(() =>
                            {
                                //<summary>
                                //following lines format outputs for query into strings
                                //<summary>
                                listBox1.Items.Add(String.Format("{0}, {1}, {2}, {3}", reader[0], reader[1], reader[2], reader[3]));
                                listBox2.Items.Add("(" + String.Format("{0}, {1}, {2}", reader[0], reader[1], reader[2]) + ")");
                                fileOutPuts.Add("[" + String.Format("{0}, {1}, {2}", reader[0], reader[1], reader[2]) + "], ");
                                items++; // number of items found items
                                labelItems.Text = items.ToString(); // adds items to labelItems
                            }));
                        }
                    }
                    finally
                    {
                        // Always call Close when done reading.
                        reader.Close();
                        Thread fileThread = new Thread(new ThreadStart(writeOutData)); //starts file writeing thread
                        fileThread.Start(); 
                        //writeOut(fileOut);
                        Invoke(new Action(() =>
                        {
                            listBox3.Items.Add("<<Query done>>");
                        }));
                    }
                }
                catch
                {
                    Invoke(new Action(() =>
                    {
                        listBox3.Items.Clear(); //updates logger listbox
                        listBox3.Items.Add("<<Invalid Query String>> -- <<Update Fail>>");
                        updateLogger("<<Invalid Query String>> -- <<Update Fail>>");
                    }));
                }
            } // command disposed here
        }

        private void writeOutData()
        {
            lock (cn)
            {
                StreamWriter writer = new StreamWriter("C:/LogFiles/EllieSQLFileOut.txt"); //write query outputs
                updateLogger("<------------------->>{C:/LogFiles/EllieSQLFileOut.txt}[]<<------------------->");
                foreach (string line in fileOutPuts)
                {
                    writer.Write(line);
                }
                writer.Close();
                System.Diagnostics.Process.Start("C:/LogFiles/EllieSQLFileOut.txt"); //opens file
                SMS("Process Done One");
                StreamWriter writer2 = new StreamWriter("C:/LogFiles/Ones.txt"); //write out ones
                updateLogger("<------------------->>{C:/LogFiles/Ones.txt}[]<<------------------->");
                writer2.Write("[");
                for (int i = 0; i <= items; i++)
                {
                    //count++;
                    writer2.Write("1, ");
                }
                writer2.Write("]");
                writer2.Close();
                System.Diagnostics.Process.Start("C:/LogFiles/Ones.txt"); //opens file
                SMS("Process Two Done");
            }
        }

        private void storedProc()  //TODO add onto multi thread
        {
            lock (cn)
            {
                if(StoredProctxt.Text != string.Empty)
                {
                    int count = 0;
                    Invoke(new Action(() =>
                    {
                        SPLabel.Text = count.ToString();
                    }));
                    string con = "Data Source=BA-R9WLXVM\\MSSQLSERVER03;Initial Catalog=DATEBASE_TWO;Integrated Security=True;";
                    SqlConnection conn = new SqlConnection(con);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(StoredProctxt.Text.ToString(), conn);
                    //<summary>
                    //adds params
                    //<summary>
                    cmd.CommandType = CommandType.StoredProcedure;
                    if(radioButton1.Checked == true)
                    {
                        if (Param1txt.Text != "One")
                        {
                            cmd.Parameters.AddWithValue("@dataOne", Param1txt.Text.ToString());
                        }
                        if (ParamTwotxt.Text != "Two")
                        {
                            cmd.Parameters.AddWithValue("@dataTwo", ParamTwotxt.Text.ToString());
                        }
                        if (ParamThree.Text != "Three")
                        {
                            cmd.Parameters.AddWithValue("@dataThree", ParamThree.Text.ToString());
                        }
                        if (ParamFour.Text != "Four")
                        {
                            cmd.Parameters.AddWithValue("@dataFour", ParamFour.Text.ToString());
                        }
                    }
                    SqlDataReader reader = cmd.ExecuteReader();
                    //MessageBox.Show(reader.Read().ToString());
                    while (reader.Read())
                    {
                        Invoke(new Action(() =>
                        {
                            SPLabel.Text = count.ToString();
                        }));
                        count++;
                        Invoke(new Action(() =>
                        {
                            //<summary>
                            //formats & outputs query string
                            //<summary>
                            SProctxt.Items.Add("<-------------------------------------------------->");
                            SPLabel.Text = count.ToString();
                            count++;
                            SProctxt.Items.Add((reader[0].ToString()));
                            SProctxt.Items.Add("<---->");
                            count++;
                            SProctxt.Items.Add((reader[1].ToString()));
                            SProctxt.Items.Add("<---->");
                            count++;
                            SProctxt.Items.Add((reader[2].ToString()));
                            SProctxt.Items.Add("<---->");
                            count++;
                            SProctxt.Items.Add((reader[3].ToString()));
                            SProctxt.Items.Add("<---->");
                            count++;
                            SProctxt.Items.Add((reader[4].ToString()));
                            SProctxt.Items.Add("<------------------------------------------------->");
                        }));
                    }
                    //Close reader and connection
                    reader.Close();
                    conn.Close();
                    cn.Dispose();
                }
                else
                {
                    MessageBox.Show("No Procedre Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    updateLogger("<------------------->>[No Procedre Name]<<------------------->");
                }
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Thread procThread = new Thread(new ThreadStart(storedProc));
            procThread.Start();
            //storedProc();
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Label7_Click(object sender, EventArgs e)
        {
            
        }

        private void StoredProctxt_TextChanged(object sender, EventArgs e)
        {
            StoredProctxt.BackColor = Color.Orange;
        }

        private void Param1txt_TextChanged(object sender, EventArgs e)
        {
            Param1txt.BackColor = Color.Orange;
        }

        private void ParamTwotxt_TextChanged(object sender, EventArgs e)
        {
            ParamTwotxt.BackColor = Color.Orange;
        }

        private void ParamThree_TextChanged(object sender, EventArgs e)
        {
            ParamThree.BackColor = Color.Orange;
        }

        private void ParamFour_TextChanged(object sender, EventArgs e)
        {
            ParamFour.BackColor = Color.Orange;
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.Orange;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show("That's not going to get you anywhere", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void startLogger()
        {
            logger.openLogger(getAvailableRAM(), getCurrentCPU());
        }

        private void OpenLoggerbtn_Click(object sender, EventArgs e)
        {
            exitLogger();
            logger.viewLogger();
        }

        private void updateLogger(string data)
        {
            logger.writeToLogger(data, getAvailableRAM(), getCurrentCPU());
        }

        private void exitLogger()
        {
            string holdNULL = "NULL";
            updateLogger(holdNULL);
            logger.closeLogger();
        }

        public string getCurrentCPU()
        {
            return cpuCounter.NextValue().ToString();
        }

        public string getAvailableRAM()
        {
            return ramCounter.NextValue().ToString();
        }

        public void readSQLConfig(string idOfItem)
        {
            StreamReader read = new StreamReader("SQLConfig.txt");
            var lines = read.ReadToEnd().Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i != lines.Length; i++)
            {
                if (lines[i].Contains(idOfItem))
                {
                    item = lines[i].Replace(idOfItem, "");
                }
            }
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void SMS(string Mess)
        {
            if(useSMS() == true)
            {
                readSQLConfig("SMSActive - ");
                string itemOne = item;
                if (itemOne == "True")
                {
                    var message = new MailMessage();
                    message.From = new MailAddress("2074025424@vtext.com");
                    readSQLConfig("SMSPhoneNumber - ");
                    string itemTwo = item;
                    string number = itemTwo + "@vtext.com";
                    message.To.Add(new MailAddress(number));//See carrier destinations below
                                                            //message.To.Add(new MailAddress("2077477757@vtext.com"));
                                                            //message.To.Add(new MailAddress("5551234568@txt.att.net"));

                    //message.CC.Add(new MailAddress("carboncopy@foo.bar.com"));
                    message.Body = Mess;

                    var client = new SmtpClient();
                    using (SmtpClient client1 = new SmtpClient())
                    {
                        client.EnableSsl = true;
                        client.UseDefaultCredentials = false;
                        client.Credentials = new NetworkCredential("emmanoaa945@gmail.com", "EmmaIsBest");
                        client.Host = "	smtp.gmail.com";
                        client.Port = 587;
                        client.DeliveryMethod = SmtpDeliveryMethod.Network;

                        client.Send(message);
                    }
                }
                else
                {
                    notActivated();
                }
            }
            else
            {
                
            }
        }

        bool useSMS()
        {
            if(UseSMSRB.Checked == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        bool notActivated()
        {
            return true;
        }

        private void Phone_Click(object sender, EventArgs e)
        {
            SMS("Message");
        }

        private void ListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Mouse_ComeBack(object sender, EventArgs e)
        {
            updateLogger("<---------------->>[Mouse Left Form1]<<----------------------->");
        }
    }
}
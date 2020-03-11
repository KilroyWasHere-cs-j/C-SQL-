using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;


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
        private int items = 0;
        private string queryString = "";
        //private string fileOut = ""; //not used 
        private readonly List<string> fileOutPuts = new List<string>();
        //private int count = 0;

        public Form1()
        {
            InitializeComponent();
            listBox1.ForeColor = Color.AntiqueWhite;  //listBox one look
            listBox1.BackColor = Color.Black;
            listBox2.ForeColor = Color.AntiqueWhite; //listBox two look
            listBox2.BackColor = Color.Black;
            listBox3.ForeColor = Color.AntiqueWhite; //listBox three look
            listBox3.BackColor = Color.Black;
            SProctxt.ForeColor = Color.AntiqueWhite; //listBox Stored Procedure
            SProctxt.BackColor = Color.Black;
            this.ForeColor = Color.White; //Form1 look
            this.BackColor = Color.Black;
            button1.ForeColor = Color.AntiqueWhite; //button one look
            button1.BackColor = Color.Black;
            button2.ForeColor = Color.AntiqueWhite; //button two look
            button2.BackColor = Color.Black;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label7.Text = "V.2.0";
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
                        DateTimeLabel.Text = aDate.ToString("HH:mm:ss");
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
            listBox1.ForeColor = Color.AntiqueWhite;  //listBox one look
            listBox1.BackColor = Color.Black;
            listBox2.ForeColor = Color.AntiqueWhite; //listBox two look
            listBox2.BackColor = Color.Black;
            listBox3.ForeColor = Color.AntiqueWhite; //listBox three look
            listBox3.BackColor = Color.Black;
            SProctxt.ForeColor = Color.AntiqueWhite; //listBox Stored Procedure
            SProctxt.BackColor = Color.Black;
            this.ForeColor = Color.White; //Form1 look
            this.BackColor = Color.Black;
            button1.ForeColor = Color.AntiqueWhite; //button one look
            button1.BackColor = Color.Black;
            button2.ForeColor = Color.AntiqueWhite; //button two look
            button2.BackColor = Color.Black;
            OpenLoggerbtn.ForeColor = Color.White;
            OpenLoggerbtn.BackColor = Color.Black;
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
            cn.Open();

            using (SqlCommand cmd = new SqlCommand(queryString, cn))
            {
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader(); //If queryString is not a correct query
                    try
                    {
                        while (reader.Read())
                        {
                            Invoke(new Action(() =>
                            {
                                listBox1.Items.Add(String.Format("{0}, {1}, {2}, {3}", reader[0], reader[1], reader[2], reader[3]));
                                listBox2.Items.Add("(" + String.Format("{0}, {1}, {2}", reader[0], reader[1], reader[2]) + ")");
                                fileOutPuts.Add("[" + String.Format("{0}, {1}, {2}", reader[0], reader[1], reader[2]) + "], ");
                                items++;
                                labelItems.Text = items.ToString();
                            }));
                        }
                    }
                    finally
                    {
                        // Always call Close when done reading.
                        reader.Close();
                        Thread fileThread = new Thread(new ThreadStart(writeOutData));
                        fileThread.Start(); //fileOut needs locking
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
                        listBox3.Items.Clear();
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
                updateLogger("<------------------->>{writer}[C:/LogFiles/EllieSQLFileOut.txt]<<------------------->");
                foreach (string line in fileOutPuts)
                {
                    writer.Write(line);
                }
                writer.Close();
                System.Diagnostics.Process.Start("C:/LogFiles/EllieSQLFileOut.txt"); //opens file
                StreamWriter writer2 = new StreamWriter("C:/LogFiles/Ones.txt"); //write out ones
                updateLogger("<------------------->>{writer2}[C:/LogFiles/EllieSQLFileOut.txt]<<------------------->");
                writer2.Write("[");
                for (int i = 0; i <= items; i++)
                {
                    //count++;
                    writer2.Write("1, ");
                }
                writer2.Write("]");
                writer2.Close();
                System.Diagnostics.Process.Start("C:/LogFiles/Ones.txt"); //opens file
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
                    cmd.CommandType = CommandType.StoredProcedure;
                    if(Param1txt.Text != "One")
                    {
                        cmd.Parameters.AddWithValue("@dataOne", Param1txt.Text.ToString());
                    }
                    if(ParamTwotxt.Text != "Two")
                    {
                        cmd.Parameters.AddWithValue("@dataTwo", ParamTwotxt.Text.ToString());
                    }
                    if(ParamThree.Text != "Three")
                    {
                        cmd.Parameters.AddWithValue("@dataThree", ParamThree.Text.ToString());
                    }
                    if(ParamFour.Text != "Four")
                    {
                        cmd.Parameters.AddWithValue("@dataFour", ParamFour.Text.ToString());
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
                    updateLogger("<------------------->>[No Procedre Name]< ------------------->");
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
            logger.openLogger();
        }

        private void OpenLoggerbtn_Click(object sender, EventArgs e)
        {
            exitLogger();
            logger.viewLogger();
        }

        private void updateLogger(string data)
        {
            logger.writeToLogger(data);
        }

        private void exitLogger()
        {
            logger.closeLogger();
        }
    }
}
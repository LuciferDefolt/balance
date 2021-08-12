using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Balance
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (box1.Text != "" && box2.Text != "" && box4.Text != "" && box3.Text != "" && box7.Text != "" && box6.Text != "" && box5.Text != "")
            {
                MySqlConnection connection = DBUtils.GetDBConnection();
                connection.Open();
                try
                {
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "INSERT INTO assets(NematActive, ResultIssledov, OsnovSredstva, DoxodVlog, FinanVlog , OtlogNalogActive , ProchieVneoborot) VALUE (?NematActive, ?ResultIssledov, ?OsnovSredstva, ?DoxodVlog, ?FinanVlog , ?OtlogNalogActive , ?ProchieVneoborot)";
                    command.Parameters.Add("?NematActive", MySqlDbType.VarChar).Value = box1.Text;
                    command.Parameters.Add("?ResultIssledov", MySqlDbType.VarChar).Value = box2.Text;
                    command.Parameters.Add("?OsnovSredstva", MySqlDbType.VarChar).Value = box4.Text;
                    command.Parameters.Add("?DoxodVlog", MySqlDbType.VarChar).Value = box3.Text;
                    command.Parameters.Add("?FinanVlog", MySqlDbType.VarChar).Value = box7.Text;
                    command.Parameters.Add("?OtlogNalogActive", MySqlDbType.VarChar).Value = box6.Text;
                    command.Parameters.Add("?ProchieVneoborot", MySqlDbType.VarChar).Value = box5.Text;
                    command.ExecuteNonQuery();
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            else
            {
                MessageBox.Show("Please fill all cells");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            MySqlConnection connection = DBUtils.GetDBConnection();
            connection.Open();
            try
            {
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "Select * from assets";
                MySqlDataReader mySqlDataReader = command.ExecuteReader();
                int year = 2008;
                while (mySqlDataReader.Read())
                {
                    textBox1.Text += year++ + "\t";
                    textBox1.Text += mySqlDataReader["NematActive"].ToString().ToString() + "\t";
                    textBox1.Text += mySqlDataReader["ResultIssledov"].ToString().ToString() + "\t";
                    textBox1.Text += mySqlDataReader["OsnovSredstva"].ToString().ToString() + "\t";
                    textBox1.Text += mySqlDataReader["DoxodVlog"].ToString().ToString() + "\t";
                    textBox1.Text += mySqlDataReader["FinanVlog"].ToString().ToString() + "\t";
                    textBox1.Text += mySqlDataReader["OtlogNalogActive"].ToString().ToString() + "\t";
                    textBox1.Text += mySqlDataReader["ProchieVneoborot"].ToString().ToString() + "\t \r\n";
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox2.Text = string.Empty;
            int score = 1;
            double a11 = 0, a12 = 0, a13 = 0, a14 = 0, a15 = 0, a16 = 0, a17 = 0, a21 = 0, a22 = 0, a23 = 0, a24 = 0, a25 = 0, a26 = 0, a27 = 0;
            MySqlConnection connection = DBUtils.GetDBConnection();
            connection.Open();
            try
            {
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "Select * from assets";
                MySqlDataReader mySqlDataReader = command.ExecuteReader();
                while (mySqlDataReader.Read())

                {
                    score++;
                    if (score % 2 == 0)
                    {
                        a11 = Int32.Parse(mySqlDataReader["NematActive"].ToString());
                        a12 = Int32.Parse(mySqlDataReader["ResultIssledov"].ToString());
                        a13 = Int32.Parse(mySqlDataReader["OsnovSredstva"].ToString());
                        a14 = Int32.Parse(mySqlDataReader["DoxodVlog"].ToString());
                        a15 = Int32.Parse(mySqlDataReader["FinanVlog"].ToString());
                        a16 = Int32.Parse(mySqlDataReader["OtlogNalogActive"].ToString());
                        a17 = Int32.Parse(mySqlDataReader["ProchieVneoborot"].ToString());
                        if (score > 2)

                        {
                            if (a11 == 0 || a21 == 0)
                            {
                                textBox2.Text += "0   \r";
                            }
                            else
                            {
                                textBox2.Text += (a11 / a21 * 100).ToString() + "%   \r";
                            }
                            if (a12 == 0 || a22 == 0)
                            {
                                textBox2.Text += "0   \r";
                            }
                            else
                            {
                                textBox2.Text += (a12 / a22 * 100).ToString() + "%   \r";
                            }
                            if (a13 == 0 || a23 == 0)
                            {
                                textBox2.Text += "0   \r";
                            }
                            else
                            {
                                textBox2.Text += (a13 / a23 * 100).ToString() + "%   \r";
                            }
                            if (a14 == 0 || a24 == 0)
                            {
                                textBox2.Text += "0   \r";
                            }
                            else
                            {
                                textBox2.Text += (a14 / a24 * 100).ToString() + "%   \r";
                            }
                            if (a15 == 0 || a25 == 0)
                            {
                                textBox2.Text += "0   \r";
                            }
                            else
                            {
                                textBox2.Text += (a15 / a25 * 100).ToString() + "%   \r";
                            }
                            if (a16 == 0 || a26 == 0)
                            {
                                textBox2.Text += "0   \r";
                            }
                            else
                            {
                                textBox2.Text += (a16 / a26 * 100).ToString() + "%   \r";
                            }
                            if (a17 == 0 || a27 == 0)
                            {
                                textBox2.Text += "0   \r\n";
                            }
                            else
                            {
                                textBox2.Text += (a17 / a27 * 100).ToString() + "%   \r\n";
                            }
                        }
                    }
                    else
                    {
                        a21 = Int32.Parse(mySqlDataReader["NematActive"].ToString());
                        a22 = Int32.Parse(mySqlDataReader["ResultIssledov"].ToString());
                        a23 = Int32.Parse(mySqlDataReader["OsnovSredstva"].ToString());
                        a24 = Int32.Parse(mySqlDataReader["DoxodVlog"].ToString());
                        a25 = Int32.Parse(mySqlDataReader["FinanVlog"].ToString());
                        a26 = Int32.Parse(mySqlDataReader["OtlogNalogActive"].ToString());
                        a27 = Int32.Parse(mySqlDataReader["ProchieVneoborot"].ToString());
                        if (score > 2)
                        {

                            if (a11 == 0 || a21 == 0)
                            {
                                textBox2.Text += "0   \r";
                            }
                            else
                            {
                                textBox2.Text += (a21 / a11 * 100).ToString() + "%   \r";
                            }
                            if (a12 == 0 || a22 == 0)
                            {
                                textBox2.Text += "0   \r";
                            }
                            else
                            {
                                textBox2.Text += (a22 / a12 * 100).ToString() + "%   \r";
                            }
                            if (a13 == 0 || a23 == 0)
                            {
                                textBox2.Text += "0   \r";
                            }
                            else
                            {
                                textBox2.Text += (a23 / a13 * 100).ToString() + "%   \r";
                            }
                            if (a14 == 0 || a24 == 0)
                            {
                                textBox2.Text += "0   \r";
                            }
                            else
                            {
                                textBox2.Text += (a24 / a14 * 100).ToString() + "%   \r";
                            }
                            if (a15 == 0 || a25 == 0)
                            {
                                textBox2.Text += "0   \r";
                            }
                            else
                            {
                                textBox2.Text += (a25 / a15 * 100).ToString() + "%   \r";
                            }
                            if (a16 == 0 || a26 == 0)
                            {
                                textBox2.Text += "0   \r";
                            }
                            else
                            {
                                textBox2.Text += (a26 / a16 * 100).ToString() + "%   \r";
                            }
                            if (a17 == 0 || a27 == 0)
                            {
                                textBox2.Text += "0   \r\n";
                            }
                            else
                            {
                                textBox2.Text += (a27 / a17 * 100).ToString() + "%   \r\n";
                            }
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 FormOpen = new Form2();
            FormOpen.ShowDialog();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 FormOpen = new Form3();
            FormOpen.ShowDialog();
            this.Close();
        }
    }
}

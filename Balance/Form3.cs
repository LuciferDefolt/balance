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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (box1.Text != "" && box2.Text != "" && box4.Text != "" && box3.Text != "" && box6.Text != "" && box5.Text != "")
            {
                MySqlConnection connection = DBUtils.GetDBConnection();
                connection.Open();
                try
                {
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "INSERT INTO OborotActive(zapas, nalog, debitor_zadolg, , zadolg_12_posle , zadolg_12_do , finans_vlod , deneg_sredstva) VALUE (?zapas, ?nalog, ?debitor_zadolg, , ?zadolg_12_posle , ?zadolg_12_do , ?finans_vlod , ?deneg_sredstva)";
                    command.Parameters.Add("?zapas", MySqlDbType.VarChar).Value = box1.Text;
                    command.Parameters.Add("?nalog", MySqlDbType.VarChar).Value = box2.Text;
                    command.Parameters.Add("?debitor_zadolg", MySqlDbType.VarChar).Value = box3.Text;
                    command.Parameters.Add("?zadolg_12_posle", MySqlDbType.VarChar).Value = box4.Text;
                    command.Parameters.Add("?zadolg_12_do", MySqlDbType.VarChar).Value = box5.Text;
                    command.Parameters.Add("?finans_vlod", MySqlDbType.VarChar).Value = box6.Text;
                    command.Parameters.Add("?deneg_sredstva", MySqlDbType.VarChar).Value = box7.Text;
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
                command.CommandText = "Select * from OborotActive";
                MySqlDataReader mySqlDataReader = command.ExecuteReader();
                int year = 2008;
                while (mySqlDataReader.Read())
                {
                    textBox1.Text += year++ + "\t";
                    textBox1.Text += mySqlDataReader["zapas"].ToString().ToString() + "\t";
                    textBox1.Text += mySqlDataReader["nalog"].ToString().ToString() + "\t";
                    textBox1.Text += mySqlDataReader["debitor_zadolg"].ToString().ToString() + "\t";
                    textBox1.Text += mySqlDataReader["zadolg_12_posle"].ToString().ToString() + "\t";
                    textBox1.Text += mySqlDataReader["zadolg_12_do"].ToString().ToString() + "\t";
                    textBox1.Text += mySqlDataReader["finans_vlod"].ToString().ToString() + "\t";
                    textBox1.Text += mySqlDataReader["deneg_sredstva"].ToString().ToString() + "\t \r\n";
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
                command.CommandText = "Select * from OborotActive";
                MySqlDataReader mySqlDataReader = command.ExecuteReader();
                while (mySqlDataReader.Read())

                {
                    score++;
                    if (score % 2 == 0)
                    {
                        a11 = Int32.Parse(mySqlDataReader["zapas"].ToString());
                        a12 = Int32.Parse(mySqlDataReader["nalog"].ToString());
                        a13 = Int32.Parse(mySqlDataReader["debitor_zadolg"].ToString());
                        a14 = Int32.Parse(mySqlDataReader["zadolg_12_posle"].ToString());
                        a15 = Int32.Parse(mySqlDataReader["zadolg_12_do"].ToString());
                        a16 = Int32.Parse(mySqlDataReader["finans_vlod"].ToString());
                        a17 = Int32.Parse(mySqlDataReader["deneg_sredstva"].ToString());
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
    }
}

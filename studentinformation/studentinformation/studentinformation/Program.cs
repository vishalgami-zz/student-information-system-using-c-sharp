using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Security;

namespace studentinformation
{
    class Program
    {
        private string[] val = new string[5];
        public string this[int index]
        {
            get
            {

                return val[index];
            }
            set
            {
                val[index] = value;
            }
        } 

        static void Main(string[] args)
        {
            Console.WriteLine("\n\n\n\n\n\n\t\t\t\t\tWelcome To Student Information System");
            Console.WriteLine("\n\n\n\n\n\n\t\t\t\t\t\tPress Enter To countinue");
            Console.ReadLine();
            Console.Clear();
            login();
        }
        static void Adds()
        {
            Console.Clear();
            Console.WriteLine("\t\t-------------------------------------ADD Student Record-------------------------------------");
                string n,str, ln, fan, eid;
                int rn, m, p, c;
                SqlConnection con;
                long phn;

                Console.Write("Enter RollNo. :");
                rn = Convert.ToInt32(Console.ReadLine());

                str = @"Data Source=.\SQLEXPRESS;AttachDbFilename=E:\dot net\Project\studentinformation\studentinformation\studentinformation\student.mdf;Integrated Security=True;User Instance=True";
                    con = new SqlConnection(str);
                    con.Open();

                    string qu = "SELECT * FROM student WHERE rn like @rn";
                    SqlCommand inss = new SqlCommand(qu, con);
                    inss.Parameters.AddWithValue("@rn", rn);
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(inss);
                    da.Fill(ds);
                    con.Close();

                    bool check = ((ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0));
                    if (check)
                    {
                        Console.WriteLine("Roll No. already exists........");
                        Console.WriteLine("\n\nPress Any key to get back to main menu..........");
                        Console.ReadLine();
                        Console.Clear();
                        Selection();
                    }
                
                Console.Write("\nEnter First Name :");
                n = Console.ReadLine();
                Console.Write("Enter LastName :");
                ln = Console.ReadLine();
                Console.Write("Enter FatherName :");
                fan = Console.ReadLine();
                Console.Write("Enter Email_id :");
                eid = Console.ReadLine();
                Console.Write("Enter PhoneNo. :");
                phn = Convert.ToInt64(Console.ReadLine());
                Console.Write("Enter Marks in Maths :");
                m = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Marks in Chemistry :");
                c = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Marks in Physics :");
                p = Convert.ToInt32(Console.ReadLine());
                
            try{
                str = @"Data Source=.\SQLEXPRESS;AttachDbFilename=E:\dot net\Project\studentinformation\studentinformation\studentinformation\student.mdf;Integrated Security=True;User Instance=True";
                con = new SqlConnection(str);
                con.Open();
                Console.WriteLine("Database connected");

                string query = "INSERT into student(rn,n,ln,fan,eid,phn,p,c,m) VALUES('"+rn+"','"+n+"','"+ln+"','"+fan+"','"+eid+"','"+phn+"','"+p+"','"+c+"','"+m+"')";
                SqlCommand ins = new SqlCommand(query, con);
                ins.ExecuteNonQuery();
                Console.WriteLine("Data Recorded Sucssefully\n\n");
                Console.WriteLine("Press Any key to get back to main menu..........");
                Console.ReadLine();
                Console.Clear();
                Selection();

            }
            catch(Exception ex){
                Console.WriteLine(ex.Message);
            }
                
        }
        static void login()
        {
            SqlConnection con;
            String str;
            
            Console.WriteLine("\t\t------------------------------------- Login Admin -------------------------------------");
            string user, pass;
            Console.Write("\n\n\n\n\n\n\n\t\t\t\t\t\tEnter Username: ");
            user = Console.ReadLine();
            Console.Write("\n\t\t\t\t\t\tEnter Password: ");
            pass = Console.ReadLine();

            try
            {
                str = @"Data Source=.\SQLEXPRESS;AttachDbFilename=E:\dot net\Project\studentinformation\studentinformation\studentinformation\student.mdf;Integrated Security=True;User Instance=True";
                con = new SqlConnection(str);
                con.Open();
                Console.WriteLine("Database connected");

                string query = "SELECT * FROM login WHERE username like @user and password = @pass";
                SqlCommand ins = new SqlCommand(query, con);
                ins.Parameters.AddWithValue("@user", user);
                ins.Parameters.AddWithValue("@pass", pass);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(ins);
                da.Fill(ds);
                con.Close();

                bool logins = ((ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0));

                if (logins)
                {
                    Console.Clear();
                    Console.WriteLine("\t\t\t------------------------------Success Login------------------------------");
                    Selection();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid Details\n\n");
                    login();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            
        }
        static void view()
        {
            try
            {
                SqlConnection con;
                String str;
                str = @"Data Source=.\SQLEXPRESS;AttachDbFilename=E:\dot net\Project\studentinformation\studentinformation\studentinformation\student.mdf;Integrated Security=True;User Instance=True";
                con = new SqlConnection(str);
                con.Open();
                string query = "SELECT * FROM student";
                SqlCommand ins = new SqlCommand(query,con);
                SqlDataReader Reader = ins.ExecuteReader();
                Console.WriteLine("Roll No  Name    Last Name  Father Name  Email                    Phone No      Physics  Chemistry  Maths               ");
                Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
                while (Reader.Read())
                {
                    
                        Console.Write(Reader.GetValue(0) + "\t " + Reader.GetValue(1) + "\t " + Reader.GetValue(2) + "\t    " + Reader.GetValue(3) + "\t " + Reader.GetValue(4) + "\t  " + Reader.GetValue(5) + "\t " + Reader.GetValue(6) + "\t  " + Reader.GetValue(7) + "\t    " + Reader.GetValue(8) + "\t");
                        Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void modification()
        {
            SqlConnection con;
            String str;

            string roll;
            Console.Write("\n\t\t\t\t\t\tEnter Roll No: ");
            roll = Console.ReadLine();

            try
            {
                str = @"Data Source=.\SQLEXPRESS;AttachDbFilename=E:\dot net\Project\studentinformation\studentinformation\studentinformation\student.mdf;Integrated Security=True;User Instance=True";
                con = new SqlConnection(str);
                con.Open();
                Console.WriteLine("Database connected");

                string query = "SELECT * FROM student WHERE rn like @roll";
                SqlCommand ins = new SqlCommand(query, con);
                ins.Parameters.AddWithValue("@roll", roll);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(ins);
                da.Fill(ds);
                con.Close();

                bool modify = ((ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0));

                if (modify)
                {
                    Console.Clear();
                    Console.WriteLine("\t\t\t\t\t\tRoll No: " + roll);

                    SqlConnection co;
                    String st;
                    st = @"Data Source=.\SQLEXPRESS;AttachDbFilename=E:\dot net\Project\studentinformation\studentinformation\studentinformation\student.mdf;Integrated Security=True;User Instance=True";
                    co = new SqlConnection(st);
                    co.Open();
                    string q = "SELECT * FROM student WHERE rn like @roll";
                    SqlCommand inns = new SqlCommand(q, co);
                    inns.Parameters.AddWithValue("@roll", roll);
                    SqlDataReader Reader = inns.ExecuteReader();
                    while (Reader.Read())
                    {
                        Console.Write("------------------------------------------------------------------------------------------------------------------------");
                        Console.Write("\n\t\t\t\t\t\tFirst Name: " + Reader.GetValue(1) + "\n\t\t\t\t\t\tLast Name " + Reader.GetValue(2) + "\n\t\t\t\t\t\tFather Name:" + Reader.GetValue(3) + "\n\t\t\t\t\t\tEmail: " + Reader.GetValue(4) + "\n\t\t\t\t\t\tPhone No:" + Reader.GetValue(5) + "\n\t\t\t\t\t\tPhysics:" + Reader.GetValue(6) + "\n\t\t\t\t\t\tChemistry:  " + Reader.GetValue(7) + "\n\t\t\t\t\t\tMaths :" + Reader.GetValue(8));
                        Console.WriteLine();
                        Console.Write("\n------------------------------------------------------------------------------------------------------------------------");
                    }
                    co.Close();

                    string n, ln, fan, eid;
                    int m, p, c;
                    long phn;
                    Console.WriteLine("\nEnter First Name :");
                    n = Console.ReadLine();
                    Console.WriteLine("Enter LastName :");
                    ln = Console.ReadLine();
                    Console.WriteLine("Enter FatherName :");
                    fan = Console.ReadLine();
                    Console.WriteLine("Enter Email id :");
                    eid = Console.ReadLine();
                    Console.WriteLine("Enter PhoneNo. :");
                    phn = Convert.ToInt64(Console.ReadLine());
                    Console.WriteLine("Enter Marks in Maths :");
                    m = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter Marks in Chemistry :");
                    c = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter Marks in Physics :");
                    p = Convert.ToInt32(Console.ReadLine());

                    co.Open();
                    q = "UPDATE student SET n = '" + n + "',ln = '" + ln + "',fan = '" + fan + "',eid = '" + eid + "',phn = '" + phn + "',m = '" + m + "',c = '" + c + "',p = '" + p + "' WHERE rn = '"+ roll +"'";
                    inns = new SqlCommand(q, co);
                    inns.ExecuteNonQuery();
                    co.Close();
                    Console.WriteLine("Data updated");
                    Console.WriteLine("Press Any key to get back to main menu..........");
                    Console.ReadLine();
                    Console.Clear();
                    Selection();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("No Record Found \n\n");
                    modification();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        static void delete()
        {
            SqlConnection con;
            String str,confirm;

            string roll;
            Console.Write("\n\t\t\t\t\t\tEnter Roll No: ");
            roll = Console.ReadLine();

            try
            {
                str = @"Data Source=.\SQLEXPRESS;AttachDbFilename=E:\dot net\Project\studentinformation\studentinformation\studentinformation\student.mdf;Integrated Security=True;User Instance=True";
                con = new SqlConnection(str);
                con.Open();
                Console.WriteLine("Database connected");

                string query = "SELECT * FROM student WHERE rn like @roll";
                SqlCommand ins = new SqlCommand(query, con);
                ins.Parameters.AddWithValue("@roll", roll);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(ins);
                da.Fill(ds);
                con.Close();

                bool check = ((ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0));

                if (check)
                {
                    Console.Clear();
                    Console.WriteLine("\t\t\t\t\t\tRoll No: " + roll);

                    SqlConnection co;
                    String st;
                    st = @"Data Source=.\SQLEXPRESS;AttachDbFilename=E:\dot net\Project\studentinformation\studentinformation\studentinformation\student.mdf;Integrated Security=True;User Instance=True";
                    co = new SqlConnection(st);
                    co.Open();
                    string q = "SELECT * FROM student WHERE rn like @roll";
                    SqlCommand inns = new SqlCommand(q, co);
                    inns.Parameters.AddWithValue("@roll", roll);
                    SqlDataReader Reader = inns.ExecuteReader();
                    while (Reader.Read())
                    {
                        Console.Write("------------------------------------------------------------------------------------------------------------------------");
                        Console.Write("\n\t\t\t\t\t\tFirst Name: " + Reader.GetValue(1) + "\n\t\t\t\t\t\tLast Name " + Reader.GetValue(2) + "\n\t\t\t\t\t\tFather Name:" + Reader.GetValue(3) + "\n\t\t\t\t\t\tEmail: " + Reader.GetValue(4) + "\n\t\t\t\t\t\tPhone No:" + Reader.GetValue(5) + "\n\t\t\t\t\t\tPhysics:" + Reader.GetValue(6) + "\n\t\t\t\t\t\tChemistry:  " + Reader.GetValue(7) + "\n\t\t\t\t\t\tMaths :" + Reader.GetValue(8));
                        Console.WriteLine();
                        Console.Write("\n------------------------------------------------------------------------------------------------------------------------");
                    }
                    co.Close();

                    Console.Write("Do you want to delete (Y/N) : ");
                    confirm = Console.ReadLine();
                    if (confirm == "Y")
                    {
                        co.Open();
                        q = "DELETE FROM student WHERE rn = '" + roll + "'";
                        inns = new SqlCommand(q, co);
                        inns.ExecuteNonQuery();
                        co.Close();
                        Console.WriteLine("Data Deleted Successfully\n\n");
                        Console.WriteLine("Press Any key to get back to main menu..........");
                        Console.ReadLine();
                        Console.Clear();
                        Selection();
                    }
                    else
                    {
                        Console.Clear();
                        Selection();
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("No Record Found \n\n");
                    modification();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void indexer()
        {
            Program ic = new Program();

            ic[0] = "Yug Gondaliya";
            ic[1] = "yug@gmail.com";
            ic[2] = "9429631961";
            ic[3] = "Rajkot";
            ic[4] = "8.4";

            Console.Write("\t\t\t\t\t\t\nPrinting Student info used as indexer");

            // printing values  
            Console.WriteLine("\n\t\t\t\t\t\t\nName = {0}", ic[0]);
            Console.WriteLine("\t\t\t\t\t\t\nEmail = {0}", ic[1]);
            Console.WriteLine("\t\t\t\t\t\t\nPhone number = {0}", ic[2]);
            Console.WriteLine("\t\t\t\t\t\t\nAddress = {0}", ic[3]);
            Console.WriteLine("\t\t\t\t\t\t\nSPI = {0}", ic[4]);
            Console.ReadKey();

            Selection();

        }

        static void Selection()
        {
            Console.WriteLine("\n\n\n\n\n\t\t\t\t\t\t\tChoose Option\n");
            Console.WriteLine("\t\t\t\t\t\t1.ADD Student\n\t\t\t\t\t\t2.Delete\n\t\t\t\t\t\t3.Modify\n\t\t\t\t\t\t4.Display List\n\t\t\t\t\t\t5.Exit\n\t\t\t\t\t\t6. Indexer");

            ConsoleKeyInfo menu;
            menu = Console.ReadKey(true);

            switch (menu.KeyChar)
            {
                case '1':
                        Adds();
                        Console.ReadLine();
                        break;

                case'2':
                        delete();
                        Console.Clear();
                        break;

                case '3':
                        Console.WriteLine("\n\n\n\t\t\t---------------------------------Modify---------------------------------");
                        modification();
                        break;

                case '4':
                        Console.Clear();
                        view();
                        Console.ReadLine();
                        Console.Clear();
                        Selection();
                        break;

                case '5':
                        Console.Clear();
                        Environment.Exit(0);
                        break;

                case '6':
                        Console.Clear();
                        indexer();
                        Console.ReadLine();
                        Console.Clear();
                        break;
    
            }
        }
    }
}

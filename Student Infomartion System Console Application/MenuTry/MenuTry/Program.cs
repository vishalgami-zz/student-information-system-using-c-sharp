using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.SqlClient;
using System.Data;

namespace MenuTry
{
    class Program
    {
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
                Console.WriteLine("ADD Student Record");
                string n,str, ln, fan, eid = string.Empty;
                int rn, m, p, c;
                SqlConnection con;
            long phn;
                Console.WriteLine("Enter First Name :");
                n = Console.ReadLine();
                Console.WriteLine("Enter LastName :");
                ln = Console.ReadLine();
                Console.WriteLine("Enter FatherName :");
                fan = Console.ReadLine();
                Console.WriteLine("Enter RollNo. :");
                rn = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Email_id :");
                eid = Console.ReadLine();
                Console.WriteLine("Enter PhoneNo. :");
                phn = Convert.ToInt64(Console.ReadLine());
                Console.WriteLine("Enter Marks in Maths :");
                m = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Marks in Chemistry :");
                c = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Marks in Physics :");
                p = Convert.ToInt32(Console.ReadLine());
                
            try{
                str = @"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\The Rock\documents\visual studio 2010\Projects\MenuTry\MenuTry\student.mdf;Integrated Security=True;User Instance=True";
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

            Console.WriteLine("------------------------------------- Login Admin -------------------------------------");
            string user, pass;
            Console.WriteLine("\nEnter username");
            user = Console.ReadLine();
            Console.WriteLine("\nEnter password");
            pass = Console.ReadLine();

            try
            {
                str = @"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\The Rock\documents\visual studio 2010\Projects\MenuTry\MenuTry\student.mdf;Integrated Security=True;User Instance=True";
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
                    Console.WriteLine("Success Login");
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
                str = @"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\The Rock\documents\visual studio 2010\Projects\MenuTry\MenuTry\student.mdf;Integrated Security=True;User Instance=True";
                con = new SqlConnection(str);
                con.Open();
                string query = "SELECT * FROM student";
                SqlCommand ins = new SqlCommand(query,con);
                SqlDataReader Reader = ins.ExecuteReader();
                while (Reader.Read())
                {
                    Console.WriteLine(Reader.
);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void Selection()
        {
            Console.WriteLine("Chosse Option");
            Console.WriteLine("1.ADD Student\n2.Delete\n3.Modify\n4.Display List\n5.Exit");

            ConsoleKeyInfo menu;
            menu = Console.ReadKey(true);

            switch (menu.KeyChar)
            {
                case '1':
                    Console.WriteLine("ADD Student");
                    Adds();
                    Console.ReadLine();
                    break;
                case'2':
                    Console.WriteLine("Delete");
                        Console.ReadLine();
                    break;
                case '3':
                    Console.WriteLine("Modify");
                    Console.ReadLine();
                    break;
                case '4':
                    Console.WriteLine("Display List");
                    Console.Clear();
                    view();
                    Console.ReadLine();
                    Console.Clear();
                    Selection();
                    break;
                case '5':
                    System.Environment.Exit(0);
                    break;
    
            }
        }
    }
}

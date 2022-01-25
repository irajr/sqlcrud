using System;
using System.Data;
using System.Data.SqlClient;

class Program
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataAdapter da;
    DataSet ds;
    string StudentName { get; set; }
    string StudentEmail { get; set; }
    string NameForUpdate { get; set; }
    string EmailForUpdate { get; set; }
    string NewName { get; set; }
    string NewEmail { get; set; }
    int Deleteitem { get; set; }
    void mycon()
    {
        //Create Connection here
        con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Administrator\Downloads\Compressed\Sql\Sql\demo.mdf;Integrated Security=True");
        con.Open();
    }
    //Create the table
    public void CreateTable()
    {
        try 
        {
            mycon(); 
            cmd = new SqlCommand("create table student(id int IDENTITY(1,1)   ,name varchar(100),email varchar(50))", con);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Table Created Successfully.....");
        }
        catch(Exception e)
        {
            Console.WriteLine("Something went Wrong. " + e);
        }
        finally
        {
            con.Close();
        }
    }
    //Data for insert by user
    public void InsertData()
    {
        try
        {
            mycon();
            Console.WriteLine("Please Enter Student name");
            StudentName = Console.ReadLine().ToString();
            Console.WriteLine("Please Enter Email Address");
            StudentEmail = Console.ReadLine().ToString();
            cmd = new SqlCommand("insert into student(name,email) values(@nm,@em)",con);
            cmd.Parameters.AddWithValue("@nm",StudentName.ToString());
            cmd.Parameters.AddWithValue("@em",StudentEmail.ToString());
            cmd.ExecuteNonQuery();
            Console.WriteLine("Data Inserted Succesfully....");
        }
        catch (Exception e)
        {
            Console.WriteLine("Oops.....Something went Wrong " + e);
        }
        finally
        {
            con.Close();
        }
    }
    public void UpdateFun()
    {
        try
        {
            mycon();
            Console.WriteLine("make sure while Entring Name and Email address for update it is must Matched with Records");
            Console.WriteLine("Enter Name which you want to update");
            NameForUpdate = Console.ReadLine().ToString();
            Console.WriteLine("Enter Email which you want to update");
            EmailForUpdate = Console.ReadLine().ToString();
            cmd = new SqlCommand("select name,email from student where name=@nm and email=@em",con);
            cmd.Parameters.AddWithValue("@nm", NameForUpdate);
            cmd.Parameters.AddWithValue("@em", EmailForUpdate);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);    
            if(ds.Tables[0].Rows.Count > 0)
            {
                
                if (ds.Tables[0].Rows[0]["name"].ToString() == NameForUpdate)
                {
                    Console.WriteLine("It's Matched....Update it");
                    Console.WriteLine("Enter New Name :");
                    NewName = Console.ReadLine().ToString();
                    Console.WriteLine("Enter New Email :");
                    NewEmail = Console.ReadLine().ToString();
                    try
                    {
                        mycon();
                        cmd = new SqlCommand("UPDATE student SET name=@nnm,email=@nem where email=@cem", con);
                        cmd.Parameters.AddWithValue("@nnm", NewName);
                        cmd.Parameters.AddWithValue("@nem", NewEmail);
                        cmd.Parameters.AddWithValue("@cem", EmailForUpdate);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        cmd.ExecuteNonQuery();
                    Console.WriteLine("Update Successfully....");
                    }
                    
                    catch (Exception ex)
                    {
                        Console.WriteLine("Somthing went Wrong.." + ex);
                    }
                    finally
                    {

                    con.Close();
                    }
                }
                else
                {
                    Console.WriteLine("Entered Name not match with Records");
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Oops.....Something went Wrong " + e);
        }
        finally
        {
            con.Close();
        }
    }

    void DeleteData()
    {
        try
        {
// DELETE FROM Customers WHERE CustomerName = 'Alfreds Futterkiste';
            //show table here

            try
            {
                mycon();
                cmd = new SqlCommand("select * from student",con);
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                foreach(object item in ds)
                {
                    Console.WriteLine("{0}", item);
                }
            }
            catch(Exception ex)
            {

            }
            finally
            {

            }

            mycon();
            Console.WriteLine("Enter Id which you want to delete");
            Deleteitem = Convert.ToInt32(Console.ReadLine());
            cmd = new SqlCommand("DELETE FROM student where id=@did",con);
            cmd.Parameters.AddWithValue("@did", Deleteitem);


        }
        catch(Exception e)
        {

        }
        finally
        {

        }
    }

    static void Main(string[] args)
    {
        Program p1 = new Program();
        //p1.CreateTable();
        //p1.InsertData();
        //   p1.UpdateFun();
        p1.DeleteData();
    }
}
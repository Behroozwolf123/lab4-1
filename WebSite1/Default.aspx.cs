using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
public partial class _Default : System.Web.UI.Page
{
    StudentDAOImp imp  = new StudentDAOImp();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }
    }
    protected void tabrep_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        Label id_label;
        TextBox name_txt, last_name_txt;
        id_label = (Label)e.Item.FindControl("id_label");
        name_txt = (TextBox)e.Item.FindControl("name_txt");
        last_name_txt = (TextBox)e.Item.FindControl("last_name_txt");
        Student student = new Student(int.Parse(id_label.Text), name_txt.Text, last_name_txt.Text);
        if (e.CommandName == "Save")
        {
            if (imp.updateStudent(student)) HelloWorldLabel.Text = "Changes saved successfully!";
            else HelloWorldLabel.Text = "Something is wrong!";
        }
        else if(e.CommandName == "Delete")
        {
            if (imp.deleteStudent(student))
            {
                e.Item.Visible = false;
                HelloWorldLabel.Text = "Student successfully deleted!";
            }
            else HelloWorldLabel.Text = "Something is wrong!";
        }
    }
    protected void findIdStudent(object sender, EventArgs e)
    {
        if (TextInput.Text.Length != 0)
        {
            tabrep.DataSource = imp.findByID(int.Parse(TextInput.Text));
            tabrep.DataBind();
        }
    }
    protected void findNameStudent(object sender, EventArgs e)
    {
        if(TextInput.Text.Length != 0)
        {
            tabrep.DataSource = imp.findByName(TextInput.Text);
            tabrep.DataBind();
        }
    }
    protected void findAllStudent(object sender, EventArgs e)
    {
        tabrep.DataSource = imp.findAll();
        tabrep.DataBind();
    }
    protected void insertStudent(object sender, EventArgs e)
    {
        Student student = new Student(insStudent_name.Text, insStudent_lname.Text);
        if (imp.insertStudent(student))
        {
            HelloWorldLabel.Text = "Student inserted successfully";
        }
        else HelloWorldLabel.Text = "Something is wrong!";

    }
    public class Student
    {
        public int id{get; set;}
        public string name{get; set;}
        public string last_name { get; set; }
        public Student(int a, string b, string c)
        {
            id = a;
            name = b;
            last_name = c;
        }
        public Student(string b, string c)
        {
            name = b;
            last_name = c;
        }
    }
    
    public interface StudentDAO
    {
        List<Student> findAll();
        List<Student> findByID(int _id);
        List<Student> findByName(string _name);
        Boolean insertStudent(Student student);
        Boolean updateStudent(Student student);
        Boolean deleteStudent(Student student);
    }
    public class StudentDAOImp : StudentDAO
    {
        List<Student> students = new List<Student>();
        public List<Student> findAll()
        {
            students.Clear();
            try
            {
                String constr = "Server = localhost; Database = lab4; Uid = root; Pwd=";
                MySqlConnection con = new MySqlConnection(constr);
                con.Open();
                string query = "Select * from students";
                MySqlDataAdapter da = new MySqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    int id = (int)row["id"];
                    string name = row["name"].ToString();
                    string last_name = row["last_name"].ToString();
                    students.Add(new Student(id, name, last_name));
                }
                con.Close();

            }
            catch (Exception ex)
            {

            }
            return students;
        }
        public List<Student> findByName(string _name)
        {
            students.Clear();
            try
            {
                String constr = "Server = localhost; Database = lab4; Uid = root; Pwd=";
                MySqlConnection con = new MySqlConnection(constr);
                con.Open();
                string query = "Select * from students where name = '" + _name + "'";
                MySqlDataAdapter da = new MySqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    int id = (int)row["id"];
                    string name = row["name"].ToString();
                    string last_name = row["last_name"].ToString();
                    students.Add(new Student(id, name, last_name));
                }
                con.Close();

            }
            catch (Exception ex)
            {
                //HelloWorldLabel.Text = ex.ToString();
            }
            return students;
        }
        public List<Student> findByID(int _id)
        {
            students.Clear();
            try
            {
                String constr = "Server = localhost; Database = lab4; Uid = root; Pwd=";
                MySqlConnection con = new MySqlConnection(constr);
                con.Open();
                string query = "Select * from students where id = '" + _id.ToString() +"'";
                MySqlDataAdapter da = new MySqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    int id = (int)row["id"];
                    string name = row["name"].ToString();
                    string last_name = row["last_name"].ToString();
                    students.Add(new Student(id, name, last_name));
                }
                con.Close();

            }
            catch (Exception ex)
            {
                //HelloWorldLabel.Text = ex.ToString();
            }
            return students;
        }
        public Boolean insertStudent(Student student)
        {
            try
            {
                String constr = "Server = localhost; Database = lab4; Uid = root; Pwd=";
                MySqlConnection con = new MySqlConnection(constr);
                con.Open();
                string query = "Insert into students values(NULL,'"+student.name+"','"+student.last_name+"')";
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
               
            }
            return false;
        }
        public Boolean updateStudent(Student student)
        {
            try
            {
                String constr = "Server = localhost; Database = lab4; Uid = root; Pwd=";
                MySqlConnection con = new MySqlConnection(constr);
                con.Open();
                string query = "UPDATE students set name='" + student.name + "', last_name='" + student.last_name + "' where id='" + student.id.ToString() + "'";
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (Exception ex)
            {

            }
            return false;
        }
        public Boolean deleteStudent(Student student)
        {
            try
            {
                String constr = "Server = localhost; Database = lab4; Uid = root; Pwd=";
                MySqlConnection con = new MySqlConnection(constr);
                con.Open();
                string query = "DELETE from students where id='" + student.id.ToString() + "'";
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                //HelloWorldLabel.Text = ex.ToString();
            }
            return false;
        }
    }
}
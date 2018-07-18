using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Data;

namespace ERP_System_Project
{
    class My_control
    {
        ERP obj;
        Myconn conn = new Myconn();

        string[] prds = new string[50];
        int[] qty = new int[50];
        int[] pprice = new int[50];
        int counter = 0;

        string[] sellprds = new string[50];
        int[] sellqty = new int[50];
        int[] sellprice = new int[50];
        int sellcounter = 0;

        public My_control(ERP obj2)
        {
            obj = obj2;
        }

        public void administrator()
        {
            obj.button2.Hide();
            obj.label7.Hide();
            obj.panel2.Show();
            obj.panel3.Hide();
            obj.panel5.Hide();
        }

        public void admin_sign_in()
        {
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Select * from users where username= '" + obj.textBox1.Text + " ' AND upassword= '" + obj.textBox2.Text + " ' ", conn.oleDbConnection1);
                OleDbDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    String ue = dr["username"].ToString();
                    String up = dr["upassword"].ToString();
                    if (ue == obj.textBox1.Text || up == obj.textBox2.Text)
                    {
                        MessageBox.Show("Administrator Login Succesfully");
                        obj.label7.Show();
                        obj.button2.Show();
                        obj.button1.Hide();
                        obj.textBox1.Clear();
                        obj.textBox2.Clear();
                    }
                }
                else
                {
                    obj.textBox1.Clear();
                    obj.textBox2.Clear();
                    MessageBox.Show("Email or Password is invalid");
                }
            conn.oleDbConnection1.Close();
        }

        public void ad_signup()
        {
            conn.oleDbConnection1.Open();
            if (obj.textBox1.Text != "" && obj.textBox2.Text != "")
            {
                OleDbCommand cmd = new OleDbCommand("insert into users (username, upassword) values (@username, @upassword);", conn.oleDbConnection1);
                cmd.Parameters.AddWithValue("@username", obj.textBox1.Text);
                cmd.Parameters.AddWithValue("@upassword", obj.textBox2.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("User Reistered Successful");
                obj.textBox1.Clear();
                obj.textBox2.Clear();
            }
            else
            {
                MessageBox.Show("Fill All Fields");
                obj.textBox1.Clear();
                obj.textBox2.Clear();
            }
            conn.oleDbConnection1.Close();
        }


        public void vendor()
        {
            obj.panel3.Show();
            obj.panel4.Hide();
            obj.label8.Show();
            obj.label9.Show();
            obj.label10.Show();
            obj.dataGridView1.Hide();
            obj.comboBox1.Hide();
            obj.comboBox2.Hide();
            obj.comboBox3.Hide();
            obj.textBox3.Hide();
            obj.textBox4.Hide();
            obj.textBox5.Hide();
            obj.textBox6.Hide();
            obj.textBox7.Hide();
            obj.textBox8.Hide();
            obj.label14.Hide();
            obj.label15.Hide();
            obj.label17.Hide();
            obj.label18.Hide();
            obj.label19.Hide();
            obj.label20.Hide();
            obj.button3.Hide();
            obj.panel5.Hide();
        }

        public void vendor_dept()
        {
            obj.dataGridView1.Show();
            obj.comboBox1.Show();
            obj.comboBox2.Show();

            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("select deptname from Dept", conn.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                obj.comboBox1.Items.Add(dr["deptname"]).ToString();
            }
            conn.oleDbConnection1.Close();
        }

        public void search_vendor_combo()
        {
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("select * from Vendor where VGroup='" + obj.comboBox1.Text + "'", conn.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                obj.comboBox2.Items.Add(dr["VName"]).ToString();
            }
            conn.oleDbConnection1.Close();
        }

        public void search_vendor_data()
        {
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("select * from Vendor where VGroup= '" + obj.comboBox1.Text + " ' ", conn.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            obj.dataGridView1.DataSource = dt;
            conn.oleDbConnection1.Close();
        }

        public void apply_vendor_combopopulate()
        {
            obj.label8.Hide();
            obj.label9.Hide();
            obj.label10.Hide();
            obj.textBox3.Show();
            obj.textBox4.Show();
            obj.textBox5.Show();
            obj.textBox6.Show();
            obj.textBox7.Show();
            obj.textBox8.Show();
            obj.label14.Show();
            obj.label15.Show();
            obj.label17.Show();
            obj.label18.Show();
            obj.label19.Show();
            obj.label20.Show();
            obj.comboBox3.Show();
            obj.button3.Show();
            obj.panel5.Hide();

            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("select * from Dept", conn.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                obj.comboBox3.Items.Add(dr["Deptid"]).ToString();
            }
            conn.oleDbConnection1.Close();
        }

        public void add_Vendor()
        {
            int c = 0;
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("select count(POID) from PO where deptname= @deptname", conn.oleDbConnection1);
            cmd.Parameters.AddWithValue("@deptname", obj.comboBox1.Text);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                c = Convert.ToInt32(dr[0]);
                c++;
                obj.textBox3.Text = c.ToString() + "_" + System.DateTime.Today.Year;
                conn.oleDbConnection1.Close();
            }
        }

        public void enter_vendor_data()
        {
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("insert into Vendor (VID,VName,VCode,PH1,CPName,VGroup) values (@VID,@VName,@VCode,@PH1,@CPName,@VGroup)",conn.oleDbConnection1);
            cmd.Parameters.AddWithValue("@VID", obj.textBox3.Text);
            cmd.Parameters.AddWithValue("@VName", obj.textBox4.Text);
            cmd.Parameters.AddWithValue("@VCode", obj.textBox5.Text);
            cmd.Parameters.AddWithValue("@PH1", obj.textBox6.Text);
            cmd.Parameters.AddWithValue("@CPName", obj.textBox7.Text);
            cmd.Parameters.AddWithValue("@VGroup", obj.textBox8.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Vendor Successfully Added");
            conn.oleDbConnection1.Close();
        }

        public void purchase_order()
        {
            obj.panel4.Show();
            obj.panel5.Hide();

            {
                conn.oleDbConnection1.Open();
                obj.comboBox4.Items.Clear();
                OleDbCommand cmd = new OleDbCommand("select * from Dept", conn.oleDbConnection1);
                OleDbDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.comboBox4.Items.Add(dr["deptname"]).ToString();
                }
                conn.oleDbConnection1.Close();
            }

            {
                conn.oleDbConnection1.Open();
                OleDbCommand cmd = new OleDbCommand("select VID from Vendor", conn.oleDbConnection1);
                OleDbDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.comboBox9.Items.Add(dr["VID"].ToString());
                }
                conn.oleDbConnection1.Close();
            }

            {
                conn.oleDbConnection1.Open();
                OleDbCommand cmd = new OleDbCommand("select Pid from Products", conn.oleDbConnection1);
                OleDbDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.comboBox8.Items.Add(dr["Pid"].ToString());
                }
                conn.oleDbConnection1.Close();
            }
        }

        public void po_id()
        {
            int c = 0;
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("select count(POID) from PO where deptname= @deptname", conn.oleDbConnection1);
            cmd.Parameters.AddWithValue("@deptname", obj.comboBox4.Text);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (obj.comboBox4.Text == "Consumer")
                {
                    c = Convert.ToInt32(dr[0]);
                    c++;
                    obj.textBox14.Text = "Cons_" + c.ToString() + "_" + System.DateTime.Today.Year;
                }
                if (obj.comboBox4.Text == "HR")
                {
                    c = Convert.ToInt32(dr[0]);
                    c++;
                    obj.textBox14.Text = "HR_" + c.ToString() + "_" + System.DateTime.Today.Year;
                }
                if (obj.comboBox4.Text == "Marketing")
                {
                    c = Convert.ToInt32(dr[0]);
                    c++;
                    obj.textBox14.Text = "MR_" + c.ToString() + "_" + System.DateTime.Today.Year;
                }
                if (obj.comboBox4.Text == "Sales")
                {
                    c = Convert.ToInt32(dr[0]);
                    c++;
                    obj.textBox14.Text = "Sale_" + c.ToString() + "_" + System.DateTime.Today.Year;
                }
            }
            conn.oleDbConnection1.Close();
        }

        public void po_vid()
        {
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Select * from Vendor where VID='" + obj.comboBox9.Text + "'", conn.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                obj.textBox9.Text = dr["VName"].ToString();
                obj.textBox10.Text = dr["VFax"].ToString();
                obj.textBox11.Text = dr["CPName"].ToString();
                obj.textBox12.Text = dr["PH1"].ToString();
            }
            conn.oleDbConnection1.Close();
        }

        public void po_model()
        {
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Select * from Products where Pid='" + obj.comboBox8.Text + "'", conn.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                obj.textBox20.Text = dr["PName"].ToString();
                obj.textBox19.Text = dr["BasePrice"].ToString();
            }
            conn.oleDbConnection1.Close();
        }

        public void add_purchaseorder()
        {
            prds[counter] = obj.comboBox8.Text;
            pprice[counter] = Convert.ToInt32(obj.textBox19.Text) * (qty[counter]);
            qty[counter] = Convert.ToInt32(obj.textBox18.Text);
            counter++;
        }

        public void enter_purchaseorder()
        {
                int i = 0;

                conn.oleDbConnection1.Open();
                for (i = 0; i < prds.Length; i++)
                {
                    OleDbCommand cmd = new OleDbCommand("insert into POProducts (POID,Pid,Pprice,PQty) values(@POID,@Pid,@Pprice,@PQty)", conn.oleDbConnection1);
                    cmd.Parameters.AddWithValue("@POID", obj.comboBox9.Text);
                    cmd.Parameters.AddWithValue("@Pid", prds[i]);
                    cmd.Parameters.AddWithValue("@Pprice", qty[i]);
                    cmd.Parameters.AddWithValue("@PQty", pprice[counter]);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Inserted");
                }
                conn.oleDbConnection1.Close();
      }

        public void show_purchaseorder()
        {
            conn.oleDbConnection1.Open();
            OleDbCommand cm = new OleDbCommand("Select * from POProducts", conn.oleDbConnection1);
            OleDbDataReader dr = cm.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            obj.dataGridView2.DataSource = dt;
            conn.oleDbConnection1.Close();
        }

        public void grn()
        {
            obj.panel5.Show();
            obj.panel6.Hide();
            obj.groupBox3.Hide();
            obj.button8.Hide();
            obj.comboBox5.Hide();
        }

        public void grncombo_populate()
        {
            obj.comboBox5.Show();

            conn.oleDbConnection1.Open(); 
            OleDbCommand cmd = new OleDbCommand("select POID from PO where Status='Open'", conn.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                obj.comboBox5.Items.Add(dr["POID"].ToString());
            }
            conn.oleDbConnection1.Close();
        }

        public void grn_data()
        {
            obj.button8.Show();

            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Select VID,SNO,DDate,VName,Status from PO where POID='" + obj.comboBox5.Text + "'", conn.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                obj.textBox21.Text = obj.comboBox5.Text;
                obj.textBox23.Text = dr["VID"].ToString();
                obj.textBox17.Text = dr["SNO"].ToString();
                obj.textBox16.Text = dr["DDate"].ToString();
                obj.textBox15.Text = dr["VName"].ToString();
                obj.textBox13.Text = dr["Status"].ToString();
            }
            conn.oleDbConnection1.Close();
        }

        public void generate_grn()
        {
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("insert into GRN (GRNID,POID,Status,VName,DDate,GRDate,SNO) values(@GRNID,@POID,@Status,@VName,@DDate,@GRDate,@SNO)", conn.oleDbConnection1);
            cmd.Parameters.AddWithValue("@GRNID", obj.textBox21.Text);
            cmd.Parameters.AddWithValue("@POID", obj.comboBox5.Text);
            cmd.Parameters.AddWithValue("@Status", obj.textBox13.Text);
            cmd.Parameters.AddWithValue("@VName", obj.textBox15.Text);
            cmd.Parameters.AddWithValue("@DDate", obj.textBox16.Text);
            cmd.Parameters.AddWithValue("@GRDate", obj.dateTimePicker3);
            cmd.Parameters.AddWithValue("@SNO", obj.textBox17.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("GRN Created");
            conn.oleDbConnection1.Close();
        }

        public void invoice()
        {
            obj.panel6.Show();
            obj.comboBox6.Items.Clear();
            conn.oleDbConnection1.Open();
            OleDbCommand f = new OleDbCommand("select GRNID from GRN where Status='Open'", conn.oleDbConnection1);
            OleDbDataReader dr = f.ExecuteReader();
            while (dr.Read())
            {
                obj.comboBox6.Items.Add(dr["GRNID"].ToString());
            }
            conn.oleDbConnection1.Close();
        }

        public void invoice_combo()
        {
            conn.oleDbConnection1.Open();
            OleDbCommand cc = new OleDbCommand("Select POID,VName,DDate,GRDate,SNO from GRN where GRNID='" + obj.comboBox6.Text + "'", conn.oleDbConnection1);
            OleDbDataReader drr = cc.ExecuteReader();
            if (drr.Read())
            {
                obj.textBox28.Text = obj.comboBox6.Text;
                obj.textBox27.Text = drr["VName"].ToString();
                obj.textBox30.Text = drr["DDate"].ToString();
                obj.textBox22.Text = drr["GRDate"].ToString();
                obj.textBox31.Text = drr["SNO"].ToString();

            }
            conn.oleDbConnection1.Close();

            {
                conn.oleDbConnection1.Open();
                OleDbCommand cm = new OleDbCommand("Select VID,VContectPerson,VCPPH,TotalAmount from PO", conn.oleDbConnection1);
                OleDbDataReader ds = cm.ExecuteReader();
                if (ds.Read())
                {
                    obj.textBox26.Text = ds["VID"].ToString();
                    obj.textBox25.Text = ds["VContectPerson"].ToString();
                    obj.textBox24.Text = ds["VCPPH"].ToString();
                    obj.textBox29.Text = ds["TotalAmount"].ToString();
                }
                conn.oleDbConnection1.Close();
            }
        }

        public void generate_invoice()
        {
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("insert into Invoice (InvoiceID,VendorID,VendorName,ContectPerson,CPPH,GRNDate,CDate,AmountPayable,GRNID) values(@InvoiceID,@VendorID,@VendorName,@ContectPerson,@CPPH,@GRNDate,@CDate,@AmountPayable,@GRNID)", conn.oleDbConnection1);
            cmd.Parameters.AddWithValue("@InvoiceID", obj.textBox28.Text);
            cmd.Parameters.AddWithValue("@VendorID", obj.textBox26.Text);
            cmd.Parameters.AddWithValue("@VendorName", obj.textBox27.Text);
            cmd.Parameters.AddWithValue("@ContectPerson", obj.textBox25.Text);
            cmd.Parameters.AddWithValue("@CPPH", obj.textBox24.Text);
            cmd.Parameters.AddWithValue("@GRNDate", obj.textBox22.Text);
            cmd.Parameters.AddWithValue("@CDate", obj.dateTimePicker5);
            cmd.Parameters.AddWithValue("@AmountPayable", obj.textBox29.Text);
            cmd.Parameters.AddWithValue("@GRNID", obj.comboBox6.Text);
            try
            {
                cmd.ExecuteNonQuery();
            OleDbCommand cmd1 = new OleDbCommand("Select * from POProducts", conn.oleDbConnection1);
            OleDbDataReader dr = cmd1.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            obj.dataGridView3.DataSource = dt;
     
            }
            catch (Exception ae)
            {
                MessageBox.Show("Error: " + ae);
            }
            conn.oleDbConnection1.Close();
        }

        public void sales_order()
        {
            obj.panel7.Show();

            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("select deptname from Dept", conn.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                obj.comboBox10.Items.Add(dr["deptname"]).ToString();
            }
            conn.oleDbConnection1.Close();

        }

        public void so_id()
        {
            int c = 0;
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("select count(POID) from PO where deptname= @deptname", conn.oleDbConnection1);
            cmd.Parameters.AddWithValue("@deptname", obj.comboBox4.Text);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (obj.comboBox10.Text == "Consumer")
                {
                    c = Convert.ToInt32(dr[0]);
                    c++;
                    obj.textBox45.Text = "Cons_" + c.ToString() + "_" + System.DateTime.Today.Year;
                }
                if (obj.comboBox10.Text == "HR")
                {
                    c = Convert.ToInt32(dr[0]);
                    c++;
                    obj.textBox45.Text = "HR_" + c.ToString() + "_" + System.DateTime.Today.Year;
                }
                if (obj.comboBox10.Text == "Marketing")
                {
                    c = Convert.ToInt32(dr[0]);
                    c++;
                    obj.textBox45.Text = "MR_" + c.ToString() + "_" + System.DateTime.Today.Year;
                }
                if (obj.comboBox10.Text == "Sales")
                {
                    c = Convert.ToInt32(dr[0]);
                    c++;
                    obj.textBox45.Text = "Sale_" + c.ToString() + "_" + System.DateTime.Today.Year;
                }
            }
            conn.oleDbConnection1.Close();
        }

        public void add_sellorder()
        {
            sellprds[sellcounter] = obj.comboBox10.Text;
            sellprice[sellcounter] = Convert.ToInt32(obj.textBox40.Text) * (sellqty[sellcounter]);
            sellqty[sellcounter] = Convert.ToInt32(obj.textBox39.Text);
            sellcounter++;
        }

        public void enter_sellorder()
        {
            int i = 0;

            conn.oleDbConnection1.Open();
            for (i = 0; i < prds.Length; i++)
            {
                OleDbCommand cmd = new OleDbCommand("insert into SO (SOID,CID,VID,PName,,PPrice,Pqty,Group) values(@SOID,@CID,@VID,@PName,@Pqty,@Group)", conn.oleDbConnection1);
                cmd.Parameters.AddWithValue("@SOID", obj.textBox45.Text);
                cmd.Parameters.AddWithValue("@CID", obj.textBox32.Text);
                cmd.Parameters.AddWithValue("@VID", obj.textBox33.Text);
                cmd.Parameters.AddWithValue("@PID", obj.textBox44.Text);
                cmd.Parameters.AddWithValue("@PName", obj.textBox43.Text);
                cmd.Parameters.AddWithValue("@PID", sellprds[i]);
                cmd.Parameters.AddWithValue("@Pprice", sellqty[i]);
                cmd.Parameters.AddWithValue("@PQty", pprice[counter]);
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Inserted");
                }
                catch (Exception ae)
                {
                    MessageBox.Show("Error: " + ae);
                }
            }
            conn.oleDbConnection1.Close();
        }

        public void delivery_chalan()
        {
            obj.panel8.Show();
        }

        public void invoice_payable()
        {
            obj.panel9.Show();
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP_System_Project
{
    public partial class ERP : Form
    {
        My_control obj;

        public ERP()
        {
            InitializeComponent();
        }

        private void ERP_Load(object sender, EventArgs e)
        {
            obj = new My_control(this);
            this.panel2.Hide();
            this.panel3.Hide();
            this.panel4.Hide();
            this.panel5.Hide();
            this.panel6.Hide();
            this.panel7.Hide();
            this.panel8.Hide();
            this.panel9.Hide();
        }

        private void administrator_Click(object sender, EventArgs e) //Administrator click
        {
            obj.administrator();
        }

        private void label2_Click(object sender, EventArgs e) //vendor click
        {
            obj.vendor();
        }

        private void label16_Click(object sender, EventArgs e) //purchase order click
        {
            obj.purchase_order();
        }

        private void label3_Click(object sender, EventArgs e) // grn click
        {
            obj.grn();
        }

        private void label53_Click(object sender, EventArgs e)  //invoice click
        {
            obj.invoice();
        }

        private void label4_Click_1(object sender, EventArgs e) //sales order
        {
            obj.sales_order();
        }

        private void label5_Click(object sender, EventArgs e)  //sales marketing click
        {
            obj.delivery_chalan();
        }

        private void label6_Click(object sender, EventArgs e)  //invoice paybale click
        {
            obj.invoice_payable();
        }

        private void button2_Click(object sender, EventArgs e)  //administrator sign-up button
        {
            obj.ad_signup();
        }

        private void button1_Click(object sender, EventArgs e)  //administrator sign-in button
        {
            obj.admin_sign_in();
        }

        private void label7_Click(object sender, EventArgs e)   //add new user administrator
        {
            
        }

        private void label8_Click(object sender, EventArgs e)   //apply for vendor
        {
            obj.apply_vendor_combopopulate();
        }

        private void label9_Click(object sender, EventArgs e)   //search vendor
        {
            obj.vendor_dept();
        }

        private void label10_Click(object sender, EventArgs e)  //approve vendor
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) //vendor dept combo
        {
            obj.search_vendor_combo();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) //vendor combo 2
        {
            obj.search_vendor_data();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e) //apply vendor combo
        {
            obj.add_Vendor();
        }

        private void button3_Click(object sender, EventArgs e)  //add vendor button
        {

        }

        private void button4_Click(object sender, EventArgs e)  //purchase add order
        {
            obj.add_purchaseorder();
        }

        private void button5_Click(object sender, EventArgs e)  //create purchase order
        {
            obj.enter_purchaseorder();
        }

        private void button6_Click(object sender, EventArgs e)  //show purchase order
        {
            obj.show_purchaseorder();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)  //purchase order combo
        {
            obj.po_id();
        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e) //vid combo in purchase order
        {
            obj.po_vid();
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e) //pmodel combo in purchase order
        {
            obj.po_model();
        }

        private void button7_Click(object sender, EventArgs e)  //generate GRN only for show data
        {
            this.groupBox3.Show();
            obj.grncombo_populate();
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e) //grn combo
        {
            obj.grn_data();
        }

        private void button7_Click_1(object sender, EventArgs e)    //generate GRN only for show data
        {
            this.groupBox3.Show();
            obj.grncombo_populate();
        }

        private void comboBox5_SelectedIndexChanged_1(object sender, EventArgs e)   //grn combo
        {
            obj.grn_data();
        }

        private void button8_Click(object sender, EventArgs e)  //generate grn
        {
            obj.generate_grn();
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e) //invoice combo load
        {
            obj.invoice_combo();
        }

        private void button9_Click(object sender, EventArgs e)  //invoice button
        {
            obj.generate_invoice();
        }

        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)    //sell order combo
        {
            obj.so_id();
        }

        private void button14_Click(object sender, EventArgs e) //add sell order
        {

        }


        private void button13_Click(object sender, EventArgs e) // create sell order
        {
            obj.enter_sellorder();
        
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e) //delivery chalan combo
        {

        }

        private void button10_Click(object sender, EventArgs e) //generate delivery chalan button
        {

        }








    }
}

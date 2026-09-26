using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mini_Pizza_Order_Project
{
    public partial class Form1 : Form
    {

            public enum PzSize
            {
                Small = 20,Medium = 30, Large = 40
            }

            public enum PzCrust
            {
                Thin = 5, Thick = 10
            }
            
            public enum PzWhereToEat
        {
            EatIn = 1,TakeOut = 2
        }

        public PzSize Size = PzSize.Medium;
        public PzCrust Crust = PzCrust.Thin;

        public PzWhereToEat WhereToEat = PzWhereToEat.EatIn;
            public static int GetPrice(PzSize size,PzCrust crust)
            {
                return Convert.ToInt32(size) + Convert.ToInt32(crust);
            }
            

        public int GetToppingsTotal()
        {
            int total = 0;


            foreach (Control c in gbToppings.Controls)
            {
                if (c is CheckBox box)
                {
                    if (box.Checked)
                        total += Convert.ToInt32(box.Tag);
                }
            }


            return total;
        }

        public int GetOrderTotal()
        {
            return GetPrice(Size,Crust) + GetToppingsTotal();
        }

        public Form1()
        {
            InitializeComponent();

        }

        void ChangeTotal()
        {
            lblTotal.Text = "$" + Convert.ToString(GetOrderTotal());
        }

        void UpdateToppings()
        {
            bool Empty = true;
            List<string> toppings = new List<string>();
            foreach (Control c in gbToppings.Controls)
            {
                if (c is CheckBox box)
                {
                    if (box.Checked)
                    {
                        Empty = false;
                        toppings.Add(box.Text);
                    }
                }
            }
            if (Empty)
                lblOrderToppings.Text = "No Toppings";
            else
            lblOrderToppings.Text = string.Join(", ", toppings);
        }

        void UpdateSize()
        {
            switch (Size)
            {
                case PzSize.Small:
                    lblOrderSize.Text = "Small";
                    break;
                case PzSize.Medium:
                    lblOrderSize.Text = "Medium";
                    break;
                case PzSize.Large:
                    lblOrderSize.Text = "Large";
                    break;
            }
        }

        void UpdateCrust()
        {
            switch (Crust)
            {
                case PzCrust.Thin:
                    lblOrderCrust.Text = "Thin";
                    break;
                case PzCrust.Thick:
                    lblOrderCrust.Text = "Thick";
                    break;
            }
        }

        void UpdateWhereToEat()
        {
            switch (WhereToEat)
            {
                case PzWhereToEat.EatIn:
                    lblOrderWhereToEat.Text = "Eat In";
                    break;
                case PzWhereToEat.TakeOut:
                    lblOrderWhereToEat.Text = "Take Out";
                    break;
            }
        }

        void OrderComplete()
        {
            gbSize.Enabled = false;
            gbCrust.Enabled = false;
            gbToppings.Enabled = false;
            gbWhereToEat.Enabled = false;
            btnOrderPizza.Enabled = false;
        }

        void ResetSize()
        {
            rbMedium.Checked = true;
        }

        void ResetCrust()
        {
            rbThinCrust.Checked = true;
        }

        void ResetToppings()
        {
            foreach (Control c in gbToppings.Controls)
            {
                if (c is CheckBox box)
                {
                    box.Checked = false;
                }
            }
        }

        void ResetWhereToEat()
        {
            rbEatIn.Checked = true;
        }

        void OrderReset()
        {
            gbSize.Enabled = true;
            gbCrust.Enabled = true;
            gbToppings.Enabled = true;
            gbWhereToEat.Enabled = true;
            ResetWhereToEat();
            ResetSize();
            ResetToppings();
            ResetCrust();
        }

        private void lblTotal_Click(object sender, EventArgs e)
        {

        }

        private void rbSmall_CheckedChanged(object sender, EventArgs e)
        {
            Size = PzSize.Small;
            ChangeTotal();
            UpdateSize();
        }

        private void rbMedium_CheckedChanged(object sender, EventArgs e)
        {
            Size = PzSize.Medium;
            ChangeTotal();
            UpdateSize();
        }

        private void rbLarge_CheckedChanged(object sender, EventArgs e)
        {
            Size = PzSize.Large;
            ChangeTotal();
            UpdateSize();
        }

        private void rbThinCrust_CheckedChanged(object sender, EventArgs e)
        {
            Crust = PzCrust.Thin;
            ChangeTotal();
            UpdateCrust();
        }

        private void rbThickCrust_CheckedChanged(object sender, EventArgs e)
        {
            Crust = PzCrust.Thick;
            ChangeTotal();
            UpdateCrust();
        }

        private void chkExtraCheese_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
            ChangeTotal();
        }

        private void chkMushrooms_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
            ChangeTotal();
        }

        private void chkTomatoes_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
            ChangeTotal();
        }

        private void chkOnion_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
            ChangeTotal();
        }

        private void chkOlives_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
            ChangeTotal();
        }

        private void chkGreenPeppers_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
            ChangeTotal();
        }

        private void lblOrderCrust_Click(object sender, EventArgs e)
        {

        }

        private void lblOrderSize_Click(object sender, EventArgs e)
        {

        }

        private void rbEatIn_CheckedChanged(object sender, EventArgs e)
        {
            WhereToEat = PzWhereToEat.EatIn;
            UpdateWhereToEat();
        }

        private void rbTakeOut_CheckedChanged(object sender, EventArgs e)
        {
            WhereToEat = PzWhereToEat.TakeOut;
            UpdateWhereToEat();
        }

        private void btnOrderPizza_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure?", "Order Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                MessageBox.Show("Order was Completed!","Complete",MessageBoxButtons.OK,MessageBoxIcon.Information);
                OrderComplete();
            }
        }

        private void btnResetOrder_Click(object sender, EventArgs e)
        {
            OrderReset();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ChangeTotal();
        }
    }
}

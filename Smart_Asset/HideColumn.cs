using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_Asset.Images
{
    public partial class HideColumn : Form
    {
        Settings1 s1 = new Settings1();
        public HideColumn()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }


        private void HideColumn_Load(object sender, EventArgs e)
        {
            MyOtherMethods.CenterInPanel(topLabel_Lbl, panel1);

            LoadCheckboxes();
        }


        public void LoadCheckboxes()
        {
            //Load all checkbox if check or not
            if (s1.type)
            {
                type_Cb.Checked = true;
            }
            else
            {
                type_Cb.Checked = false;
            }

            if (s1.brand)
            {
                brand_Cb.Checked = true;
            }
            else
            {
                brand_Cb.Checked = false;
            }

            if (s1.model)
            {
                model_Cb.Checked = true;
            }
            else
            {
                model_Cb.Checked = false;
            }

            if (s1.propertyID)
            {
                propertyID_Cb.Checked = true;
            }
            else
            {
                propertyID_Cb.Checked = false;
            }

            if (s1.serialNo)
            {
                serialNo_Cb.Checked = true;
            }
            else
            {
                serialNo_Cb.Checked = false;
            }

            if (s1.poNumber)
            {
                poNumber_Cb.Checked = true;
            }
            else
            {
                poNumber_Cb.Checked = false;
            }

            if (s1.siNumber)
            {
                siNumber_Cb.Checked = true;
            }
            else
            {
                siNumber_Cb.Checked = false;
            }

            if (s1.cost)
            {
                cost_Cb.Checked = true;
            }
            else
            {
                cost_Cb.Checked = false;
            }

            if (s1.warranty)
            {
                warranty_Cb.Checked = true;
            }
            else
            {
                warranty_Cb.Checked = false;
            }

            if (s1.supplier)
            {
                supplier_Cb.Checked = true;
            }
            else
            {
                supplier_Cb.Checked = false;
            }

            if (s1.warrantyStatus)
            {
                warrantyStatus_Cb.Checked = true;
            }
            else
            {
                warrantyStatus_Cb.Checked = false;
            }

            if (s1.purchaseDate)
            {
                purchaseDate_Cb.Checked = true;
            }
            else
            {
                purchaseDate_Cb.Checked = false;
            }

            if (s1.usage)
            {
                usage_Cb.Checked = true;
            }
            else
            {
                usage_Cb.Checked = false;
            }

            if (s1.location)
            {
                location_Cb.Checked = true;
            }
            else
            {
                location_Cb.Checked = false;
            }
        }

        public void HideColumns()
        {
            // Check if the column exists before trying to set its visibility
            if (Read.StaticDataGridView.Columns["Type"] != null)
                Read.StaticDataGridView.Columns["Type"].Visible = !s1.type;

            if (Read.StaticDataGridView.Columns["Brand"] != null)
                Read.StaticDataGridView.Columns["Brand"].Visible = !s1.brand;

            if (Read.StaticDataGridView.Columns["Model"] != null)
                Read.StaticDataGridView.Columns["Model"].Visible = !s1.model;

            if (Read.StaticDataGridView.Columns["PropertyID"] != null)
                Read.StaticDataGridView.Columns["PropertyID"].Visible = !s1.propertyID;

            if (Read.StaticDataGridView.Columns["SerialNo"] != null)
                Read.StaticDataGridView.Columns["SerialNo"].Visible = !s1.serialNo;

            if (Read.StaticDataGridView.Columns["PONumber"] != null)
                Read.StaticDataGridView.Columns["PONumber"].Visible = !s1.poNumber;

            if (Read.StaticDataGridView.Columns["SINumber"] != null)
                Read.StaticDataGridView.Columns["SINumber"].Visible = !s1.siNumber;

            if (Read.StaticDataGridView.Columns["Cost"] != null)
                Read.StaticDataGridView.Columns["Cost"].Visible = !s1.cost;

            if (Read.StaticDataGridView.Columns["Warranty"] != null)
                Read.StaticDataGridView.Columns["Warranty"].Visible = !s1.warranty;

            if (Read.StaticDataGridView.Columns["Supplier"] != null)
                Read.StaticDataGridView.Columns["Supplier"].Visible = !s1.supplier;

            if (Read.StaticDataGridView.Columns["WarrantyStatus"] != null)
                Read.StaticDataGridView.Columns["WarrantyStatus"].Visible = !s1.warrantyStatus;

            if (Read.StaticDataGridView.Columns["PurchaseDate"] != null)
                Read.StaticDataGridView.Columns["PurchaseDate"].Visible = !s1.purchaseDate;

            if (Read.StaticDataGridView.Columns["Usage"] != null)
                Read.StaticDataGridView.Columns["Usage"].Visible = !s1.usage;

            if (Read.StaticDataGridView.Columns["Location"] != null)
                Read.StaticDataGridView.Columns["Location"].Visible = !s1.location;
        }


        private void selectAll_Btn_Click(object sender, EventArgs e)
        {
            type_Cb.Checked = true;
            brand_Cb.Checked = true;
            model_Cb.Checked = true;
            propertyID_Cb.Checked = true;
            serialNo_Cb.Checked = true;
            poNumber_Cb.Checked = true;
            siNumber_Cb.Checked = true;
            cost_Cb.Checked = true;
            warranty_Cb.Checked = true;
            supplier_Cb.Checked = true;
            warrantyStatus_Cb.Checked = true;
            purchaseDate_Cb.Checked = true;
            usage_Cb.Checked = true;
            location_Cb.Checked = true;
        }

        private void clear_Btn_Click(object sender, EventArgs e)
        {
            type_Cb.Checked = false;
            brand_Cb.Checked = false;
            model_Cb.Checked = false;
            propertyID_Cb.Checked = false;
            serialNo_Cb.Checked = false;
            poNumber_Cb.Checked = false;
            siNumber_Cb.Checked = false;
            cost_Cb.Checked = false;
            warranty_Cb.Checked = false;
            supplier_Cb.Checked = false;
            warrantyStatus_Cb.Checked = false;
            purchaseDate_Cb.Checked = false;
            usage_Cb.Checked = false;
            location_Cb.Checked = false;
        }

        private void hide_Btn_Click(object sender, EventArgs e)
        {
            // Update the settings based on the CheckBox states
            s1.type = type_Cb.Checked;
            s1.brand = brand_Cb.Checked;
            s1.model = model_Cb.Checked;
            s1.propertyID = propertyID_Cb.Checked;
            s1.serialNo = serialNo_Cb.Checked;
            s1.poNumber = poNumber_Cb.Checked;
            s1.siNumber = siNumber_Cb.Checked;
            s1.cost = cost_Cb.Checked;
            s1.warranty = warranty_Cb.Checked;
            s1.supplier = supplier_Cb.Checked;
            s1.warrantyStatus = warrantyStatus_Cb.Checked;
            s1.purchaseDate = purchaseDate_Cb.Checked;
            s1.usage = usage_Cb.Checked;
            s1.location = location_Cb.Checked;

            // Save the changes to the settings file
            s1.Save();
            s1.Reload();


            HideColumns();
        }

    }
}

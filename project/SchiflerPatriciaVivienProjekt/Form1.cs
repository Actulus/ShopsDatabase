using Microsoft.EntityFrameworkCore;
using SchiflerPatriciaVivienProjekt.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SchiflerPatriciaVivienProjekt.Program;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SchiflerPatriciaVivienProjekt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            feltoltGrid();
        }

        private System.Threading.Timer colorResetTimer1;
        private System.Threading.Timer colorResetTimer2;
        private System.Threading.Timer colorResetTimer3;

        private void btnInsert_Click(object sender, EventArgs e)
        {
           
            using (var db = new LocationDbContext())
            {
                try
                {
                    var newLoc = new Models.Location
                    {
                        LocationName = tbLocName.Text,

                        LocationCountry = tBLocCountry.Text,

                        ShortLocationCountry = tBLocCountryCode.Text,

                        LocationCounty = tBLocCounty.Text,
                        ShortLocationCounty = tBLocCounty.Text,
                        
                        /*Bills = null,
                        Customers = null,
                        Employees = null,
                        Shops = null, 
                        Suppliers = null,
                        SupplyPlaces = null*/

                    };

                    db.Locations!.Add(newLoc);
                    db.SaveChanges();
                    tbLocName.Text = "";
                    tBLocCountry.Text = "";
                    tBLocCountryCode.Text = "";
                    tBLocCounty.Text = "";
                    tBLocCountyCode.Text = "";
                    feltoltGrid();

                }
                catch
                {
                    MessageBox.Show("Invalid insert");
                }
            }

            btnInsert.BackColor = Color.Aquamarine;
            btnInsert.ForeColor = SystemColors.ActiveCaptionText;
            colorResetTimer1 = new System.Threading.Timer(new TimerCallback(ResetButtonColor), btnInsert, 300, Timeout.Infinite);

        }

        private void feltoltGrid()
        {

            using (var db = new ModelContext())
            {
               // var loc = db.Locations.Select(l => new { l.LocationId, l.LocationName, l.LocationCountry, l.ShortLocationCountry, l.LocationCounty, l.ShortLocationCounty }).ToList();
                //dataGridView1.DataSource = loc;
                dataGridView1.DataSource = db.Locations.ToList();
            }
        }

        Decimal locID;
        
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                return;
            }
            DataGridViewRow row = dataGridView1.SelectedRows[0];
            locID = (Decimal)dataGridView1.SelectedRows[0].Index;
            using (var db = new ModelContext())
            {
                Location searchedLoc = db.Locations.Find(locID);
                tbLocName.Text = searchedLoc.LocationName;
                tBLocCountry.Text = searchedLoc.LocationCountry;
                tBLocCountryCode.Text = searchedLoc.ShortLocationCountry;
                tBLocCounty.Text = searchedLoc.LocationCounty;
                tBLocCountyCode.Text = searchedLoc.ShortLocationCounty;
            }
            
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }

       
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            btnUpdate.BackColor = Color.Aquamarine;
            btnUpdate.ForeColor = SystemColors.ActiveCaptionText;
            colorResetTimer2 = new System.Threading.Timer(new TimerCallback(ResetButtonColor), btnUpdate, 300, Timeout.Infinite);

            using (var db = new ModelContext())
            {
                Location searchedLoc = db.Locations.Find(locID);
                searchedLoc.LocationName = tbLocName.Text;
                searchedLoc.LocationCountry = tBLocCountry.Text;
                searchedLoc.ShortLocationCountry = tBLocCountryCode.Text;
                searchedLoc.LocationCounty = tBLocCounty.Text;
                searchedLoc.ShortLocationCounty = tBLocCountyCode.Text;
                db.SaveChanges();
                tbLocName.Text = "";
                tBLocCountry.Text = "";
                tBLocCountryCode.Text = "";
                tBLocCounty.Text = "";
                tBLocCountyCode.Text = "";
            }
            feltoltGrid();
        }

       
        private void btnDelete_Click(object sender, EventArgs e)
        {
            btnDelete.BackColor = Color.Aquamarine;
            btnDelete.ForeColor = SystemColors.ActiveCaptionText;
            colorResetTimer3 = new System.Threading.Timer(new TimerCallback(ResetButtonColor), btnDelete, 300, Timeout.Infinite);

            using (var db = new ModelContext())
            {
                Location searchedLoc = db.Locations.Find(locID);
                db.Locations.Remove(searchedLoc);
                db.SaveChanges();
                tbLocName.Text = "";
                tBLocCountry.Text = "";
                tBLocCountryCode.Text = "";
                tBLocCounty.Text = "";
                tBLocCountyCode.Text = "";
            }
            feltoltGrid();
        }

        private void ResetButtonColor(object button)
        {
            System.Windows.Forms.Button btn = button as System.Windows.Forms.Button;
            if (btn.InvokeRequired)
            {
                btn.BeginInvoke((MethodInvoker)delegate
                {
                    btn.BackColor = Color.SlateBlue;
                    btn.ForeColor = SystemColors.Control;
                });
            }
            else
            {
                btn.BackColor = SystemColors.Control;
            }
        }
    }
}

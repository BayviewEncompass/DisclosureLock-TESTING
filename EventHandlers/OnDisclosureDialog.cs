using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using System.Xml.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.ComponentModel;
//
using System.ServiceModel;
using System.Runtime.Serialization;
using System.Xml.Serialization;
//
using EllieMae.Encompass.ComponentModel;
using EllieMae.Encompass.Automation;
using EllieMae.Encompass.BusinessObjects;
using EllieMae.Encompass.BusinessObjects.Users;
using EllieMae.Encompass.BusinessObjects.Loans;
using EllieMae.Encompass.Client;
//
using WINFORM = System.Windows.Forms;
using EMFORM = EllieMae.Encompass.Forms;
//
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
//using NLog;
//
using CLS.SharedCode.UIHelpers;
using System.Windows.Forms;

namespace CLS.DisclosureLock
{
    public partial class DisclosureLock : EMFORM.Form
    {
        public void On_DisclosureDialogShown(object oSender, EventArgs oEvt)
        {
            try
            {
                // WNW - De-reference to our target control.
                var oBorrowerPairsCBO = (WINFORM.ComboBox)(m_ActiveForm.Controls[3]).Controls[1];
                oBorrowerPairsCBO_Focused();
                oBorrowerPairsCBO.SelectedIndex = 0;
                oBorrowerPairsCBO.SelectedIndexChanged += OBorrowerPairsCBO_SelectedIndexChanged;
                oBorrowerPairsCBO.SelectedIndex = 0;
                
            }
            catch (Exception oEx)
            {
                ApplicationLog.WriteError(MethodBase.GetCurrentMethod().DeclaringType.Name, $"Error in On: {oEx.Message}");
            }
        }


        private void oBorrowerPairsCBO_Focused()
        {
            var oBorrowerPairsCBO = (WINFORM.ComboBox)(m_ActiveForm.Controls[3]).Controls[1];
            var oProcessButton = (WINFORM.Button)m_ActiveForm.Controls.Find("processBtn", true)[0];
            if (oBorrowerPairsCBO.Focused)
            {
                //int pair = EncompassApplication.CurrentLoan.Log.Disclosures2015.Loan.BorrowerPairs.Count;
                int disCount = EncompassApplication.CurrentLoan.Log.Disclosures2015.Count;
                var disSent = EncompassApplication.CurrentLoan.Log.Disclosures2015;
                //var pair = EncompassApplication.CurrentLoan.BorrowerPairs;

                List<string> borName = new List<string>();
                for (int i = 0; i < disCount; i++)
                {
                    borName.Add(disSent[i].BorrowerName);
                }

                
                foreach (string bpair in borName)
                {
                    if (oBorrowerPairsCBO.SelectedItem.ToString().Contains(bpair))
                    {
                        oProcessButton.Enabled = false;
                        MessageBox.Show("Disclosures were already sent for this borrower pair.  Please choose another pair that has not received disclosures yet.");
                        break;
                    }
                    else
                    {
                        oProcessButton.Enabled = true;
                    }
                }

            }
        }


        private void OBorrowerPairsCBO_SelectedIndexChanged(object sender, EventArgs e)
        {
            var oBorrowerPairsCBO = (WINFORM.ComboBox)(m_ActiveForm.Controls[3]).Controls[1];
            var oProcessButton = (WINFORM.Button)m_ActiveForm.Controls.Find("processBtn", true)[0];
            
            //int pair = EncompassApplication.CurrentLoan.Log.Disclosures2015.Loan.BorrowerPairs.Count;
            int disCount = EncompassApplication.CurrentLoan.Log.Disclosures2015.Count;
            var disSent = EncompassApplication.CurrentLoan.Log.Disclosures2015;
            //var pair = EncompassApplication.CurrentLoan.BorrowerPairs;

            List<string> borName = new List<string>();
            for (int i = 0; i < disCount; i++)
            {
                borName.Add(disSent[i].BorrowerName);
            }
            
            
            foreach (string bpair in borName)
            {
                if (oBorrowerPairsCBO.SelectedItem.ToString().Contains(bpair))
                {
                    oProcessButton.Enabled = false;
                    MessageBox.Show("Disclosures were already sent for this borrower pair.  Please choose another pair that has not received disclosures yet.");
                    break;
                }
                else if (!oBorrowerPairsCBO.SelectedItem.ToString().Contains(bpair))
                {
                    oProcessButton.Enabled = true;
                }
            }

        }
    }
}

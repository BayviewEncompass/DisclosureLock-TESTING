using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using System.Xml.Linq;
using System.Reflection;
//
using System.ServiceModel;
using System.Runtime.Serialization;
using System.Xml.Serialization;
//
using EllieMae.Encompass.BusinessObjects;
using EllieMae.Encompass.Client;
using EllieMae.Encompass.BusinessObjects.Users;
using EllieMae.Encompass.BusinessObjects.Loans.Logging;
using EllieMae.Encompass.BusinessObjects.TradeManagement;
// 
using EMLog = EllieMae.EMLite.DataEngine.Log;

//
using EllieMae.Encompass.Automation;
using EMFORM = EllieMae.Encompass.Forms;
//
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using NLog;
//


namespace CSharp.DefaultCodebase
{
    public partial class DefaultCodebase : EMFORM.Form
    {
        protected bool mInitializedTest = false;

        public void On_LoanOpened(object oSender, EventArgs oEvt)
        {
            try
            {
                var oDisclosureTrackingType = EMLog.DisclosureTracking2015Log.DisclosureTrackingType.LE;

                var oBPs = EncompassApplication.CurrentLoan.Log.Disclosures2015.borrowerPairIDsDistribution(oDisclosureTrackingType);

                try
                {
                    foreach (string oUserType in new[] { "LP", "CL", "UW" })
                    {
                        var oUser = EncompassApplication.Session.Users.GetUser($"{oUserType}ID");

                        IdentifyOutsourceUsers(oUser, oUserType);
                    }
                }
                catch (NullReferenceException oEx)
                {
                    ApplicationLog.WriteError(MethodBase.GetCurrentMethod().DeclaringType.Name, $"USER TYPE NOT DEFINED: {oEx.Message}");

                }
            }
            catch (Exception oEx)
            {

                ApplicationLog.WriteError(MethodBase.GetCurrentMethod().DeclaringType.Name, $"On_LoanOpened Error {oEx.Message}");

            }
            finally
            {
                EncompassApplication.CurrentLoan.FieldChange += this.On_FieldChanged;
                EncompassApplication.CurrentLoan.BeforeCommit += this.On_LoanPreSave;
                EncompassApplication.CurrentLoan.Committed += this.On_LoanPostSave;

            }
        }


        public void On_LoanClosing(object oSender, EventArgs oEvt)
        {
            try
            {
                mInitializedTest = false;

                EncompassApplication.CurrentLoan.Fields["CUST95FV"].Value = "N";

            }
            catch (Exception oEx)
            {

                ApplicationLog.WriteError(MethodBase.GetCurrentMethod().DeclaringType.Name, $"On_LoanClosing Error {oEx.Message}");

            }
            finally
            {
                EncompassApplication.CurrentLoan.FieldChange -= this.On_FieldChanged;
                EncompassApplication.CurrentLoan.BeforeCommit -= this.On_LoanPreSave;
                EncompassApplication.CurrentLoan.Committed -= this.On_LoanPostSave;
            }
        }
    }
}

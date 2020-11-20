using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using System.Xml.Linq;
using System.Linq.Expressions;
using System.Reflection;
//
using System.ServiceModel;
using System.Runtime.Serialization;
using System.Xml.Serialization;
//
using EllieMae.Encompass.BusinessObjects;
using EllieMae.Encompass.BusinessObjects.Users;
using EllieMae.Encompass.BusinessObjects.Loans;
using EllieMae.Encompass.BusinessObjects.Loans.Logging;
using EllieMae.Encompass.Client;
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
        public void On_LoanPreSave(object oSender, CancelableEventArgs oEvt)
        {
            try
            {
                var oBorrowerPairDis = EncompassApplication.CurrentLoan.Log.Disclosures2015;
            }
            catch (Exception oEx)
            {
                ApplicationLog.WriteError(MethodBase.GetCurrentMethod().DeclaringType.Name, $"On_LoanPreSave Error {oEx.Message}");
            }
        }

        public void On_LoanPostSave(object oSender, PersistentObjectEventArgs oEvt)
        {
            try
            {

            }
            catch (Exception oEx)
            {
                ApplicationLog.WriteError(MethodBase.GetCurrentMethod().DeclaringType.Name, $"On_LoanPostSave Error {oEx.Message}");
            }
        }
    }
}

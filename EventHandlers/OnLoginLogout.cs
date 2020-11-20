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
using EllieMae.Encompass.Client;
//
using EllieMae.Encompass.Automation;
using EMFORM = EllieMae.Encompass.Forms;
//
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using NLog;
//
using CSharp.DefaultCodebase.CDO.Helpers;
using CSharp.DefaultCodebase.Models;


namespace CSharp.DefaultCodebase
{
    public partial class DefaultCodebase : EMFORM.Form
    {
        private DefaultCodebaseConfig oCodebaseConfig;

        public void On_Login(object oSender, EventArgs oEvt)
        {
            try
            {
                if (oCodebaseConfig == null)
                    oCodebaseConfig = CDOHelper.ReadCDO<DefaultCodebaseConfig>(CDOType.GlobalLevel, "CLS.DefaultCodebaseConfig");
            }
            catch (Exception oEx)
            {
                Macro.Alert("Unable to read and initalize Default Codebase Configuration.");

                ApplicationLog.WriteError(MethodBase.GetCurrentMethod().DeclaringType.Name, $"On_Login Error {oEx.Message}");
            }
            finally
            {
                EncompassApplication.LoanOpened += this.On_LoanOpened;
                EncompassApplication.LoanClosing += this.On_LoanClosing;
            }
        }

        public void On_Logout(object oSender, EventArgs oEvt)
        {
            try
            {


            }
            catch (Exception oEx)
            {

                ApplicationLog.WriteError(MethodBase.GetCurrentMethod().DeclaringType.Name, $"On_Logout Error {oEx.Message}");

            }
            finally
            {
                EncompassApplication.LoanOpened -= this.On_LoanOpened;
                EncompassApplication.LoanClosing -= this.On_LoanClosing;
            }
        }
    }
}

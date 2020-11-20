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


namespace CSharp.DefaultCodebase
{
    public partial class DefaultCodebase : EMFORM.Form
    {
        public void On_FieldChanged(object oSender, FieldChangeEventArgs oEvt)
        {
            try
            {

            }
            catch (Exception oEx)
            {
                ApplicationLog.WriteError(MethodBase.GetCurrentMethod().DeclaringType.Name, $"On_FieldChanged Error {oEx.Message}");
            }
        }
    }
}

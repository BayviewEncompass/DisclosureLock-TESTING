using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using System.Xml.Linq;
using System.Linq.Expressions;
//
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


namespace CLS.DisclosureLock
{
    public partial class DisclosureLock : EMFORM.Form
    {

        public override void CreateControls()
        {
            try
            {
                
            }
            catch (Exception oEx)
            {
                ApplicationLog.WriteError(MethodBase.GetCurrentMethod().DeclaringType.Name, $"Error on CreateControls: {oEx.Message}");
            }
        }
    }
}

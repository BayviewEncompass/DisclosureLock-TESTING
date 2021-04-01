using System;
//
using System.Reflection;
//
//
using EllieMae.Encompass.Client;
//
using EMFORM = EllieMae.Encompass.Forms;
//
//using NLog;
//


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

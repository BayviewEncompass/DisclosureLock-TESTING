using System;
//
using System.Reflection;
//
//
using EllieMae.Encompass.Automation;
using EllieMae.Encompass.Client;
//
using WINFORM = System.Windows.Forms;
using EMFORM = EllieMae.Encompass.Forms;
//
//using NLog;
//
using CLS.SharedCode.UIHelpers;
using System.Windows.Forms;

namespace CLS.DisclosureLock
{
    public partial class DisclosureLock : EMFORM.Form
    {
        string oCurrentProcess;
        DateTime oProcessStartTime;

        WINFORM.Form m_ActiveForm = null;

        private void On_FormOpened(object sender, FormOpenedEventArgs e)
        {

            try
            {
                oCurrentProcess   = "FormOpen";
                oProcessStartTime = DateTime.Now;

                // WNW - Restricts to Forms opened from LoanScreen 
                if (EncompassApplication.CurrentLoan != null)
                {
                    if (e.OpenedForm?.IsDisposed == false)
                    {
                        m_ActiveForm = e.OpenedForm;
                        var contPanel = e.OpenedForm.Controls.Find("gradientPanel2", true);

                        switch (e.OpenedForm.Name.ToLower())
                        {

                            case "efolderdialog":
                                var oButtonsToDisable = new string[] { "btnDisclosures" };

                                foreach (var oButtonID in oButtonsToDisable)
                                {
                                    if (e.OpenedForm.Controls?.Find(oButtonID, true).Length > 0)
                                    {
                                        Button oButton = (Button)e.OpenedForm.Controls.Find(oButtonID, true)[0];
                                        oButton.Enabled = true;
                                    }
                                }
                                break;
                            case "orderdisclosuredialog":
                                e.OpenedForm.Shown -= On_DisclosureDialogShown;
                                e.OpenedForm.Shown += On_DisclosureDialogShown;
                                break;
                        }
                    }
                }
            }
            catch (Exception oEx)
            {
                ApplicationLog.WriteError(MethodBase.GetCurrentMethod().DeclaringType.Name, $"On_FormOpened Error {oEx.Message}");
            }
        }
    }
}
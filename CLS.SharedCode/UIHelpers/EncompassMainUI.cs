using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace CLS.SharedCode.UIHelpers
{
    public static class EncompassMainUI
    {
        public static event FormOpenedHandler FormOpened;

        #pragma warning disable IDE0044 // Add readonly modifier

        private static Dictionary<Form, IntPtr> m_OpenForms;

        private static System.Timers.Timer m_MainUITimer = null;

        public static Form MainUI
        {
            get
            {
                return Application.OpenForms[0];
            }
        }

        static EncompassMainUI()
        {
            try
            {
                try
                {
                    m_OpenForms = new Dictionary<Form, IntPtr>();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                try
                {
                    Application.OpenForms[0].Deactivate += EncompassMainUI_Deactivated;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                try
                {
                    m_MainUITimer = new System.Timers.Timer(300);
                    m_MainUITimer.Elapsed += OnTimer;
                    m_MainUITimer.AutoReset = false;
                    m_MainUITimer.SynchronizingObject = Application.OpenForms[0];
                    m_MainUITimer.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                try
                {
                    CheckAndAdd();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private static void EncompassMainUI_Deactivated(object sender, EventArgs e)
        {
            try
            {
                CheckAndAdd();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private static void OnTimer(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                CheckAndAdd();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                CheckDictionary();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                if (m_MainUITimer != null)
                {
                    m_MainUITimer.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private static void CheckDictionary()
        {
            try
            {
                if (m_OpenForms != null)
                {
                    foreach (var s in m_OpenForms.Where(p => p.Key == null || p.Key.IsDisposed).ToList())
                    {
                        try
                        {
                            m_OpenForms.Remove(s.Key);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private static void CheckAndAdd()
        {
            try
            {
                if (Application.OpenForms != null && m_OpenForms != null)
                {
                    foreach (Form oForm in Application.OpenForms)
                    {
                        if (oForm?.IsDisposed == false)
                        {
                            if (!m_OpenForms.Keys.Contains(oForm))
                            {
                                AddNewForm(oForm);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private static void AddNewForm(Form oForm)
        {
            try
            {
                if (oForm?.IsDisposed == false)
                {
                    oForm.FormClosing += On_FormClosing;

                    m_OpenForms.Add(oForm, oForm.Handle);

                    FormOpenEventTrigger(oForm);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private static void On_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (sender != null)
                {
                    Form oForm = (Form)sender;

                    if (oForm?.IsDisposed == false)
                    {
                        if (m_OpenForms?.Keys.Contains(oForm) == true)
                        {
                            m_OpenForms.Remove(oForm);
                        }

                        oForm.FormClosing -= On_FormClosing;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private static void FormOpenEventTrigger(Form oForm)
        {
            try
            {
                if (oForm?.IsDisposed == false)
                {
                    FormOpenedEventArgs eventArgs = new FormOpenedEventArgs(oForm);

                    FormOpened?.Invoke(null, eventArgs);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

    public static class ExtensionMethods
    {
        public static void RemoveButtonClickHandlers(Button oAnyButton)
        {
            FieldInfo oFieldInfo = typeof(Control).GetField("EventClick", BindingFlags.Static | BindingFlags.NonPublic);

            object oValue = oFieldInfo.GetValue(oAnyButton);

            PropertyInfo oPropertyInfo = oAnyButton.GetType().GetProperty("Events", BindingFlags.NonPublic | BindingFlags.Instance);

            EventHandlerList oEventHandlerList = (EventHandlerList)oPropertyInfo.GetValue(oAnyButton, null);

            oEventHandlerList.RemoveHandler(oValue, oEventHandlerList[oValue]);
        }

        public static void RemoveEventHandlers<T>(this Control target, string Event)
        {
            FieldInfo fieldInfo = typeof(Control).GetField(Event, BindingFlags.Static | BindingFlags.NonPublic);

            object obj = fieldInfo.GetValue(target.CastTo<T>());

            PropertyInfo propertyInfo = target.CastTo<T>().GetType().GetProperty("Events", BindingFlags.NonPublic | BindingFlags.Instance);

            EventHandlerList list = (EventHandlerList)propertyInfo.GetValue(target.CastTo<T>(), null);

            list.RemoveHandler(obj, list[obj]);
        }

        public static T CastTo<T>(this object objectToCast)
        {
            return (T)objectToCast;
        }
    }
}
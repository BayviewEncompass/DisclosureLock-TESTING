using System;
using System.Windows.Forms;

namespace CLS.SharedCode.UIHelpers
{
    public class FormOpenedEventArgs : EventArgs
    {
        private Form m_Form;

        public Form OpenedForm
        {
            get { return m_Form; }
            private set {m_Form = value; }
        }

        public FormOpenedEventArgs(Form frm)
        {
            m_Form = frm;
        }
        public FormOpenedEventArgs()
        {

        }
    }
}

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
	[Plugin]
	public partial class DisclosureLock : EMFORM.Form
	{

		public DisclosureLock()
		{
			EncompassMainUI.FormOpened += On_FormOpened;
		}

		~DisclosureLock()
		{
			EncompassMainUI.FormOpened -= On_FormOpened;
		}
	}
}

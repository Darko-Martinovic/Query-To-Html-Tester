using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace SqlClrHtmlTester
{
    public class Helper
    {
        public static void writeConfig(MyFormState state,string queryText, string paramsText,string cmbStyleText,string serverText, string captionText, string footerText, string authText, string userName, string passText,string databaseText, string rotateText, string rcoText,string customStyleText,string listConnection)
        {

            XmlWriterSettings ws = new XmlWriterSettings();
            ws.NewLineHandling = NewLineHandling.Entitize;
            state = new MyFormState();
            state.ListBoxText = listConnection;
            state.QueryText = queryText;
            state.ParamText = paramsText;
            state.StyleText = cmbStyleText;
            state.ServerText = serverText;
            state.CaptionText = captionText;
            state.FooterText = footerText;
            state.AuthText = authText;
            state.UserNameText = userName;
            state.PasswordText = passText;
            state.DataBaseText = databaseText;
            state.RotateText = rotateText;
            state.RcoText = rcoText;
            state.CustomStyleText = customStyleText;

            XmlSerializer ser = new XmlSerializer(typeof(MyFormState));
            using (XmlWriter wr = XmlWriter.Create(ConfigurationManager.AppSettings["fileToSaveInput"], ws))
            {
                ser.Serialize(wr, state);
            }
            //ser.Serialize(sw, state);

        }
        public static MyFormState loadConfig()
        {
            MyFormState state = null;
            XmlSerializer ser = new XmlSerializer(typeof(MyFormState));
            using (FileStream fs = File.OpenRead("config.xml"))
            {
                try
                {
                    state = (MyFormState)ser.Deserialize(fs);
                }
                catch (Exception ex)
                {
                    state = null;
                }
                return state;
            }
        }




    }
}

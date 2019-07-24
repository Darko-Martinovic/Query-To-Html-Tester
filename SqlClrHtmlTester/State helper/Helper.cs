using System;
using System.Configuration;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace SqlClrHtmlTester
{
    public class Helper
    {
        public static void WriteConfig(MyFormState state,
                                       string queryText,
                                       string paramsText,
                                       string cmbStyleText,
                                       string serverText,
                                       string captionText,
                                       string footerText,
                                       string authText,
                                       string userName,
                                       string passText,
                                       string databaseText,
                                       string rotateText,
                                       string rcoText,
                                       string customStyleText,
                                       string listConnection)
        {

            var ws = new XmlWriterSettings {NewLineHandling = NewLineHandling.Entitize};
            state = new MyFormState
            {
                ListBoxText = listConnection,
                QueryText = queryText,
                ParamText = paramsText,
                StyleText = cmbStyleText,
                ServerText = serverText,
                CaptionText = captionText,
                FooterText = footerText,
                AuthText = authText,
                UserNameText = userName,
                PasswordText = passText,
                DataBaseText = databaseText,
                RotateText = rotateText,
                RcoText = rcoText,
                CustomStyleText = customStyleText
            };

            var ser = new XmlSerializer(typeof(MyFormState));
            using (var wr = XmlWriter.Create(ConfigurationManager.AppSettings["fileToSaveInput"], ws))
            {
                ser.Serialize(wr, state);
            }
            //ser.Serialize(sw, state);

        }
        public static MyFormState LoadConfig()
        {
            var ser = new XmlSerializer(typeof(MyFormState));
            using (var fs = File.OpenRead("config.xml"))
            {
                MyFormState state = null;
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

using Microsoft.CSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;
using System.CodeDom.Compiler;
using System.Reflection;
using System.IO;
using System.Xml;

namespace Utilities
{


    [Serializable()]
    public class Evaluator
    {

        private string m_includeCode = "";
        private string[] m_includeReferencies;
        private string[] m_includeImports;
        private string[] m_includeOption;
        private CompilerErrorCollection m_errors = null;
        private int m_fatalErrors = 0;
        private string m_errorMessage = "";
        private int m_includeLines = 0;

        private string sourcePathAssembly = string.Empty;

        public Evaluator(string myPath, string WIncludeCode = "", string[] WIncludeReferencies = null, string[] WIncludeImports = null, string[] WIncludeOption = null)
        {
            m_includeCode = WIncludeCode;
            m_includeReferencies = WIncludeReferencies;
            m_includeImports = WIncludeImports;
            m_includeOption = WIncludeOption;
            sourcePathAssembly = myPath;

        }


        #region " Compile "

        /// <summary>
        /// Rutina u kojoj se vrši evaluacija 
        /// </summary>
        /// <params>Kod upisan na client strani npr. u multiline text box-u </params>
        /// <params> Različito(!)  od include code</params>
        public object Compile(string vbCode, bool oneFunction, string myNameSpace, ref string errorMessage)
        {
            object o = null;
            Dictionary<string, string> provOptions = new Dictionary<string, string>();
            provOptions.Add("CompilerVersion", "v4.0");

            CSharpCodeProvider c = new Microsoft.CSharp.CSharpCodeProvider(provOptions);

            CompilerParameters cp = new CompilerParameters();
            cp.ReferencedAssemblies.Add("system.dll");
            cp.ReferencedAssemblies.Add("system.xml.dll");
            cp.ReferencedAssemblies.Add("system.data.dll");
            cp.ReferencedAssemblies.Add("system.drawing.dll");
            //try
            //{
            //    cp.ReferencedAssemblies.Add(System.Data.DataRowComparer<System.Data.DataRow>.Default.GetType().Assembly.Location);
            //}
            //catch (Exception ex)
            //{
            //}

            //Dim c11 As String = "C:\Program Files\Reference Assemblies\Microsoft\Framework\v3.5\System.Data.Linq.dll"
            //cp.ReferencedAssemblies.Add(c11)

            if ((m_includeReferencies != null))
            {
                for (int i = 0; i <= m_includeReferencies.Length - 1; i++)
                {
                    if (!string.IsNullOrEmpty(m_includeReferencies[i]))
                    {
                        cp.ReferencedAssemblies.Add(m_includeReferencies[i]);
                    }
                }
            }
            cp.CompilerOptions = "/t:library";



            cp.TempFiles = new TempFileCollection(Path.GetTempPath(), false);

            cp.GenerateInMemory = true;




#if DEBUG

            {
                cp.IncludeDebugInformation = true;
                cp.TempFiles.KeepFiles = false;
                cp.GenerateInMemory = false;
                string dirName = ".";
                if (!System.IO.Directory.Exists(dirName))
                {
                    try
                    {
                        System.IO.Directory.CreateDirectory(dirName);
                        dirName = "c:\\tmp";
                        if (!System.IO.Directory.Exists(dirName))
                        {
                            System.IO.Directory.CreateDirectory(dirName);
                        }
                    }
                    catch (Exception ex)
                    {
                        if (Debugger.IsAttached)
                        {
                            Debugger.Break();
                        }
                        else
                        {
                            string ex1 = ex.Message;
                        }
                    }
                }
                else
                    dirName = "c:\\tmp";

                cp.TempFiles = new TempFileCollection(dirName, true);
#else

	cp.TempFiles.KeepFiles = false;

	cp.CompilerOptions = "/Optimize+";
	cp.GenerateInMemory = true;
#endif
            }




            StringBuilder sb = new StringBuilder("");


            if ((m_includeOption != null))
            {
                foreach (string s in m_includeOption)
                {
                    sb.Append(s + Environment.NewLine);
                }
            }
            sb.Append("using System;" + Environment.NewLine).Append("using System.Diagnostics;" + Environment.NewLine).Append("using System.Xml;" + Environment.NewLine).Append("using System.Data;" + Environment.NewLine).Append("using System.Collections;" + Environment.NewLine).Append("using System.Collections.Generic;" + Environment.NewLine).Append("using System.Data.SqlClient;" + Environment.NewLine).Append("using System.Runtime.CompilerServices;" + Environment.NewLine).Append("using System.Reflection;" + Environment.NewLine);
            m_includeLines = 5;

            if ((m_includeImports != null))
            {
                for (int i = 0; i <= m_includeImports.Length - 1; i++)
                {
                    if (!string.IsNullOrEmpty(m_includeImports[i]))
                    {
                        sb.Append("using " + m_includeImports[i] + ";" + Environment.NewLine);
                        m_includeLines += 1;
                    }
                }
            }

            //[Serializable()]

            sb.Append("namespace " + myNameSpace.Trim() + Environment.NewLine + "{" + Environment.NewLine);
            sb.Append("[Serializable()]" + Environment.NewLine + "public class EvalLib " + Environment.NewLine + "{" + Environment.NewLine);
            m_includeLines += 2;
            if (oneFunction)
                sb.Append("public static void EvalCode(string p)" + Environment.NewLine + "{" + Environment.NewLine);
            if (!string.IsNullOrEmpty(m_includeCode))
                sb.Append(m_includeCode + Environment.NewLine);
            sb.Append(vbCode + Environment.NewLine);
            m_includeLines += 1;
            if (oneFunction)
                sb.Append("} " + Environment.NewLine);

            //End 

            sb.Append("} " + Environment.NewLine);
            sb.Append("}" + Environment.NewLine);

            CompilerResults cr = null;

            try
            {
                //cp.OutputAssembly = "c:\TestExcel.dll"
                cr = c.CompileAssemblyFromSource(cp, sb.ToString());

                if ((ProcessErrors(cr.Errors) == 0))
                {

                    o = cr.CompiledAssembly.CreateInstance(myNameSpace + ".EvalLib");
                }
            }
            catch (Exception ex)
            {
                errorMessage = sb.ToString() + Environment.NewLine + ex.Message;
            }
            sb = null;
            return o;
        }

        private string assemblyName = string.Empty;


        #endregion

        #region " Process errors "

        public string WriteErrors(CompilerErrorCollection ce = null, bool includeBr = true)
        {
            if (ce == null)
                ce = this.Errors;
            if (ce == null)
                return string.Empty;
            StringBuilder sb = new StringBuilder("");
            foreach (CompilerError e in ce)
            {
                if (!e.IsWarning)
                    sb.Append(e.ErrorNumber + " " + e.ErrorText + " Linija:" + (e.Line - m_includeLines).ToString() + Environment.NewLine);
            }
            return sb.ToString();
        }



        private int ProcessErrors(CompilerErrorCollection ce)
        {
            int retValue = 0;
            foreach (CompilerError e in ce)
            {
                if (!e.IsWarning)
                    retValue += 1;
            }
            this.Errors = ce;
            this.FatalErrors = retValue;
            this.ErrorMessage = WriteErrors(ce);

            return retValue;
        }

        #endregion

        #region " Public Properties "

        public int FatalErrors
        {
            get
            {
                return m_fatalErrors;
            }
            set
            {
                m_fatalErrors = value;
            }
        }

        public CompilerErrorCollection Errors
        {
            get
            {
                return m_errors;
            }
            set
            {
                m_errors = value;
            }
        }

        public string ErrorMessage
        {
            get
            {
                return m_errorMessage;
            }
            set
            {
                m_errorMessage = value;
            }
        }

        #endregion

        #region " Evaluation "

        public static object Eval(string memberName, object o, object param, ref string errorMessage)
        {
            object retResult = null;
            try
            {
                retResult = o.GetType().InvokeMember(memberName, System.Reflection.BindingFlags.InvokeMethod, null, o, new Object[] { param });
            }
            catch (Exception ex)
            {
                errorMessage = "Error : " + memberName + " " + ex.Message;
            }
            return retResult;
        }




        public static object Eval(string memberName, object o, object[] param, ref string errorMessage)
        {
            object retResult = null;
            try
            {
                retResult = o.GetType().InvokeMember(memberName, System.Reflection.BindingFlags.InvokeMethod, null, o, new Object[] { param });
            }
            catch (Exception ex)
            {
                errorMessage = "Error : " + memberName + " " + ex.Message;
            }
            return retResult;
        }


        public static object EvalWithGenerics(string memberName, object o, object[] param, ref string errorMessage)
        {
            object retResult = null;
            try
            {
                retResult = o.GetType().GetMethod(memberName).Invoke(o, param);
            }
            catch (Exception ex)
            {
                errorMessage = "Error : " + memberName + " " + ex.Message;
            }
            return retResult;
        }


        #endregion


    }

}

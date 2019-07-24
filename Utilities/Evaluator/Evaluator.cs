using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.CodeDom.Compiler;
using System.IO;

namespace Utilities
{


    [Serializable()]
    public class Evaluator
    {

        private readonly string _mIncludeCode;
        private readonly string[] _mIncludeReferencies;
        private readonly string[] _mIncludeImports;
        private readonly string[] _mIncludeOption;
        private int _mIncludeLines = 0;

        public Evaluator(string myPath, string assemblyName, string wIncludeCode = "",
                         string[] wIncludeReferencies = null,
                         string[] wIncludeImports = null,
                         string[] wIncludeOption = null)
        {
            _mIncludeCode = wIncludeCode;
            _mIncludeReferencies = wIncludeReferencies;
            _mIncludeImports = wIncludeImports;
            _mIncludeOption = wIncludeOption;
        }


        #region  Compile 

        public object Compile(string netCode, bool oneFunction, string myNameSpace, ref string errorMessage)
        {
            object o = null;
            var provOptions = new Dictionary<string, string>
            {
                { "CompilerVersion", "v4.0" }
            };

            var c = new Microsoft.CSharp.CSharpCodeProvider(provOptions);

            var cp = new CompilerParameters();
            cp.ReferencedAssemblies.Add("system.dll");
            cp.ReferencedAssemblies.Add("system.xml.dll");
            cp.ReferencedAssemblies.Add("system.data.dll");
            cp.ReferencedAssemblies.Add("system.drawing.dll");


            if ((_mIncludeReferencies != null))
            {
                for (var i = 0; i <= _mIncludeReferencies.Length - 1; i++)
                {
                    if (!string.IsNullOrEmpty(_mIncludeReferencies[i]))
                    {
                        cp.ReferencedAssemblies.Add(_mIncludeReferencies[i]);
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
                if (!Directory.Exists(dirName))
                {
                    try
                    {
                        Directory.CreateDirectory(dirName);
                        dirName = "c:\\tmp";
                        if (!Directory.Exists(dirName))
                        {
                            Directory.CreateDirectory(dirName);
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
                            var ex1 = ex.Message;
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




            var sb = new StringBuilder("");


            if ((_mIncludeOption != null))
            {
                foreach (var s in _mIncludeOption)
                {
                    sb.Append(s + Environment.NewLine);
                }
            }
            sb.Append("using System;" + Environment.NewLine).Append("using System.Diagnostics;" + Environment.NewLine)
                .Append("using System.Xml;" + Environment.NewLine).Append("using System.Data;" + Environment.NewLine)
                .Append("using System.Collections;" + Environment.NewLine)
                .Append("using System.Collections.Generic;" + Environment.NewLine)
                .Append("using System.Data.SqlClient;" + Environment.NewLine)
                .Append("using System.Runtime.CompilerServices;" + Environment.NewLine)
                .Append("using System.Reflection;" + Environment.NewLine);
            _mIncludeLines = 5;

            if ((_mIncludeImports != null))
            {
                for (var i = 0; i <= _mIncludeImports.Length - 1; i++)
                {
                    if (!string.IsNullOrEmpty(_mIncludeImports[i]))
                    {
                        sb.Append("using " + _mIncludeImports[i] + ";" + Environment.NewLine);
                        _mIncludeLines += 1;
                    }
                }
            }

            //[Serializable()]

            sb.Append($"namespace {myNameSpace.Trim()}{Environment.NewLine}{{{Environment.NewLine}");
            sb.Append(
                $"[Serializable()]{Environment.NewLine}public class EvalLib {Environment.NewLine}{{{Environment.NewLine}");
            _mIncludeLines += 2;
            if (oneFunction)
                sb.Append($"public static void EvalCode(string p){Environment.NewLine}{{{Environment.NewLine}");
            if (!string.IsNullOrEmpty(_mIncludeCode))
                sb.Append(_mIncludeCode + Environment.NewLine);
            sb.Append(netCode + Environment.NewLine);
            _mIncludeLines += 1;
            if (oneFunction)
                sb.Append("} " + Environment.NewLine);

            //End 

            sb.Append("} " + Environment.NewLine);
            sb.Append("}" + Environment.NewLine);

            try
            {
                //cp.OutputAssembly = "c:\TestExcel.dll"
                var cr = c.CompileAssemblyFromSource(cp, sb.ToString());

                if ((ProcessErrors(cr.Errors) == 0))
                {

                    o = cr.CompiledAssembly.CreateInstance(myNameSpace + ".EvalLib");
                }
            }
            catch (Exception ex)
            {
                errorMessage = $"{sb}{Environment.NewLine}{ex.Message}";
            }
            sb = null;
            return o;
        }

        #endregion

        #region " Process errors "

        public string WriteErrors(CompilerErrorCollection ce = null, bool includeBr = true)
        {
            if (ce == null)
                ce = Errors;
            if (ce == null)
                return string.Empty;
            StringBuilder sb = new StringBuilder("");
            foreach (CompilerError e in ce)
            {
                if (!e.IsWarning)
                    sb.Append(e.ErrorNumber + " " + e.ErrorText + " Linija:" + (e.Line - _mIncludeLines) +
                              Environment.NewLine);
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
            Errors = ce;
            FatalErrors = retValue;
            ErrorMessage = WriteErrors(ce);

            return retValue;
        }

        #endregion

        #region " Public Properties "

        public int FatalErrors { get; set; } = 0;
        public CompilerErrorCollection Errors { get; set; } = null;

        public string ErrorMessage { get; set; } = "";

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
                errorMessage = $"Error : {memberName} {ex.Message}";
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
                errorMessage = $"Error : {memberName} {ex.Message}";
            }
            return retResult;
        }


        public static object EvalWithGenerics(string memberName, object o, object[] param, ref string errorMessage)
        {
            object retResult = null;
            try
            {
                retResult = o.GetType().GetMethod(memberName)?.Invoke(o, param);
            }
            catch (Exception ex)
            {
                errorMessage = $"Error : {memberName} {ex.Message}";
            }
            return retResult;
        }


        #endregion


    }

}

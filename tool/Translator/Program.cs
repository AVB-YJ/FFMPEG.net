using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CppSharp;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using CppSharp.AST;

namespace Translator
{
    class Program
    {
        static private ClangParser parser = null;
        static private ParserResult result = null;
        static readonly string help =
            @"translator --include [path] --namespace [namespace] --class [class name] --dll [dll name] source";

        private static string includePath = string.Empty;
        private static string nameSpace = string.Empty;
        private static string className = string.Empty;
        private static string dllName = string.Empty;
        private static string sourceFile = string.Empty;
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine(help);
                return;
            }

            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == "--include")
                {
                    if (args.Length == i)
                    {
                        Console.WriteLine(help);
                        return;
                    }
                    includePath = args[i + 1];
                    i++;
                }

                if (args[i] == "--namespace")
                {
                    if (args.Length == i)
                    {
                        Console.WriteLine(help);
                        return;
                    }
                    nameSpace = args[i + 1];
                    i++;
                }

                if (args[i] == "--class")
                {
                    if (args.Length == i)
                    {
                        Console.WriteLine(help);
                        return;
                    }
                    className = args[i + 1];
                    i++;
                }

                if (args[i] == "--dll")
                {
                    if (args.Length == i)
                    {
                        Console.WriteLine(help);
                        return;
                    }
                    dllName = args[i + 1];
                    i++;
                }

            }

            sourceFile = args[args.Length - 1];
            if (string.IsNullOrEmpty(includePath) ||
                string.IsNullOrEmpty(nameSpace) ||
                string.IsNullOrEmpty(className) ||
                string.IsNullOrEmpty(dllName))
            {
                Console.WriteLine(help);
                return;
            }


            ParserOptions options = new ParserOptions();
            options.IncludeDirs.Add(includePath);
            options.MicrosoftMode = true;
            options.ASTContext = new CppSharp.AST.ASTContext();
            options.FileName = includePath + "\\" + sourceFile;
            options.Defines.Add("__STDC_CONSTANT_MACROS");

            SourceFile source = new SourceFile(options.FileName);
            parser = new ClangParser();
            //parser.ASTContext = new CppSharp.AST.ASTContext();
            result = parser.ParseSourceFile(source, options);
            if (result.Kind != ParserResultKind.Success)
            {
                foreach (var diag in result.Diagnostics)
                    Console.WriteLine(diag.FileName + "(" + diag.LineNumber.ToString() + "):" + diag.Message);
            }

            GenerateInteropFiles(result);

        }

        private static void GenerateInteropFiles(ParserResult result)
        {
            var info = Directory.CreateDirectory("output");
            var savedPath = Environment.CurrentDirectory;
            Environment.CurrentDirectory = info.FullName;
            foreach (var unit in result.ASTContext.TranslationUnits)
            {
                GenerateInteropFile(unit);
            }
            Environment.CurrentDirectory = savedPath;

        }

        private static void GenerateInteropFile(CppSharp.AST.TranslationUnit unit)
        {
            if (unit.FilePath.IndexOf("Microsoft") != -1)
                return;

            TypeWrapperFactory.CurrentPrefix = unit.FileNameWithoutExtension;
            var outFile = unit.FileNameWithoutExtension + ".cs";
            var folder = unit.FilePath.Replace(includePath, "").Replace(unit.FileName, "").Replace("\\", "");

            if (sourceFile.IndexOf(folder) == -1)
                return;

            DirectoryInfo info = null;
            if (string.IsNullOrEmpty(folder))
            {
                info = new DirectoryInfo(Environment.CurrentDirectory);
            }
            else
            {
                info = Directory.CreateDirectory(folder);
            }
            var savedPath = Environment.CurrentDirectory;
            Environment.CurrentDirectory = info.FullName;

            if (File.Exists(outFile))
            {
                File.Delete(outFile);
            }
            TextWriter writer = new StreamWriter(outFile);

            GenerateFileBeginning(writer, unit);

            GenerateContext(writer, unit);

            GenerateFileEnd(writer, unit);

            

            writer.Flush();
            writer.Close();

            Environment.CurrentDirectory = savedPath;

        }

        private static void GenerateFileEnd(TextWriter writer, CppSharp.AST.TranslationUnit unit)
        {
            writer.WriteLine("}\r\n}\r\n");
        }

        private static void GenerateContext(TextWriter writer, CppSharp.AST.TranslationUnit unit)
        {
            TranslatMacro(writer, unit);
            TranslatEnum(writer, unit);
            TranslatFunction(writer, unit);
            TranslateClass(writer, unit);
            TranslateDelegate(writer, unit);
        }

        private static void TranslateDelegate(TextWriter writer, TranslationUnit unit)
        {
            foreach (var deleg in TypeWrapperFactory.DelegateGenerator)
            {
                writer.WriteLine(deleg.Value.fullName);
                writer.WriteLine();
            }

            TypeWrapperFactory.DelegateGenerator.Clear();
        }

        private static void TranslateClass(TextWriter writer, CppSharp.AST.TranslationUnit unit)
        {
            foreach (var @class in unit.Classes)
            {
                if (@class.Fields.Count == 0)
                    continue;
                writer.WriteLine("public struct " + @class.Name + "{");

                foreach (var field in @class.Fields)
                {
                    string marshalTag = TypeHeloer.GetMarshalTag(field.Type);
                    if (!string.IsNullOrEmpty(marshalTag))
                        writer.WriteLine("\t"+marshalTag);

                    string type = TypeHeloer.GetSystemTypeName(field.Type, true);
                    writer.Write("\tpublic ");
                    writer.Write(type);
                    writer.Write(" ");
                    writer.WriteLine(field.Name+";");
                    writer.WriteLine();
                }

                writer.WriteLine("};");
                writer.WriteLine();
            }
        }


        private static void TranslatFunction(TextWriter writer, CppSharp.AST.TranslationUnit unit)
        {
            /*
             * [DllImport(AVCODEC), SuppressUnmanagedCodeSecurity]
             * public static extern int avcodec_default_get_buffer2(IntPtr pAVCodecContext, IntPtr pAVFrame, int flags);
             */
            foreach (var function in unit.Functions)
            {
                writer.WriteLine("[DllImport(" + unit.FileNameWithoutExtension.ToUpper() + "), SuppressUnmanagedCodeSecurity]");
                writer.Write("public static extern ");
                writer.Write(TypeHeloer.GetSystemTypeName(function.ReturnType.Type, true));
                writer.Write(" ");
                writer.Write(function.Name);
                writer.Write("(\r\n");

                for (int i = 0; i < function.Parameters.Count; i++)
                {
                    var param = function.Parameters[i];
                    string marshalTag = TypeHeloer.GetMarshalTag(param.Type);
                    if (!string.IsNullOrEmpty(marshalTag))
                        writer.WriteLine("\t"+marshalTag);
                    writer.Write("\t"+TypeHeloer.GetSystemTypeName(param.Type, true));
                    writer.Write(" ");
                    if (!string.IsNullOrEmpty(param.Name))
                        writer.Write(param.Name);
                    else
                        writer.Write(" __arg" + i.ToString());
                    if (i != (function.Parameters.Count - 1))
                        writer.Write(", \r\n");
                }

                writer.Write(");");
                writer.Write("\r\n\r\n");
            }
        }

        private static void TranslatEnum(TextWriter writer, CppSharp.AST.TranslationUnit unit)
        {
            foreach (var enums in unit.Enums)
            {
                writer.WriteLine("public enum " + enums.Name);
                writer.WriteLine("{");
                foreach (var item in enums.Items)
                {
                    writer.WriteLine("\t" + item.Name + " = " + item.Value.ToString() + ",");
                }
                writer.WriteLine("}");
                writer.WriteLine("");
            }
        }

        private static string ParseEnums(string name)
        {
            foreach (var unit in result.ASTContext.TranslationUnits)
            {
                foreach (var enums in unit.Enums)
                {
                    if (enums.ItemsByName.ContainsKey(name))
                    {
                        return enums.Name + "." + name;
                    }
                }
            }

            return name;
        }
        private static void TranslatMacro(TextWriter writer, CppSharp.AST.TranslationUnit unit)
        {
            foreach (var macro in unit.Macros)
            {
                string target = macro.ToString();
                var enums = ParseEnums(target);
                writer.WriteLine("public static readonly uint " + macro.Name + " = " + enums + ";");
            }
        }

        private static void GenerateFileBeginning(TextWriter writer, CppSharp.AST.TranslationUnit unit)
        {
            string beggings = @"/*
 * copyright (c) 2013 Crazyender
 *
 * This file is part of FFmpeg.mono
 *
 * FFmpeg.mono is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public
 * License as published by the Free Software Foundation; either
 * version 2.1 of the License, or (at your option) any later version.
 *
 * FFmpeg.mono is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 * Lesser General Public License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public
 * License along with FFmpeg; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA
 */


using System;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Security;";
            writer.WriteLine(beggings);
            writer.WriteLine("namespace " + nameSpace + "\r\n" +
                "{\r\n"+
                "    public partial class " + className + " \r\n" + 
    "{\r\n" +
    "public const string "+unit.FileNameWithoutExtension.ToUpper()+" = \"" + dllName + "\";\r\n\r\n"); ;
        }
    }
}

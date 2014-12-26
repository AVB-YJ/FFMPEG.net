using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Translator
{
    public interface ITypeWrapper
    {
        string GetRawTypeName();
        string GetSystemTypeName(bool addComment = false);
        string GetMarshalTag();
    }

    public struct DelegateDefine
    {
        public string tag;
        public string name;
        public string fullName;
    }

    public static class TypeWrapperFactory
    {
        // function tag -> delegate define
        public static Dictionary<string, DelegateDefine> DelegateGenerator = new Dictionary<string, DelegateDefine>();
        public static string CurrentPrefix = "";
        public static ITypeWrapper CreateTypeWrapper(CppSharp.AST.Type rawType)
        {
            if (rawType is CppSharp.AST.FunctionType)
            {
                return new FunctionTypeWrapper(rawType);
            }
            else if (rawType is CppSharp.AST.BuiltinType)
            {
                return new BuildinTypeWrapper(rawType);
            }
            else if (rawType is CppSharp.AST.DecayedType)
            {
                return new DecayedTypeWrapper(rawType);
            }
            else if (rawType is CppSharp.AST.TagType)
            {
                return new TagedTypeWrapper(rawType);
            }
            else if (rawType is CppSharp.AST.TypedefType)
            {
                return new TypedefTypeWrapper(rawType);
            }
            else if (rawType is CppSharp.AST.PointerType)
            {
                return new PointerTypeWrapper(rawType);
            }
            else if (rawType is CppSharp.AST.ArrayType)
            {
                return new ArrayTypeWrapper(rawType);
            }
            else
            {
                return new UnknowTypeWrapper(rawType);
            }
        }
    }

    internal class UnknowTypeWrapper : ITypeWrapper
    {
        private CppSharp.AST.Type rawType;
        public UnknowTypeWrapper(CppSharp.AST.Type rawType)
        {
            this.rawType = rawType;
        }

        public string GetRawTypeName()
        {
            return "FIXME Unknow";
        }

        public string GetSystemTypeName(bool addComment = false)
        {
            return "FIXME Unknow";
        }

        public string GetMarshalTag()
        {
            return "FIXME Unknow";
        }
    }

    internal class FunctionTypeWrapper : ITypeWrapper
    {
        private CppSharp.AST.Type rawType;
        private CppSharp.AST.FunctionType type;
        public FunctionTypeWrapper(CppSharp.AST.Type rawType)
        {
            this.rawType = rawType;
            type = rawType as CppSharp.AST.FunctionType;
        }

        public string GetRawTypeName()
        {
            string functionTag = "";
            functionTag += TypeWrapperFactory.CreateTypeWrapper(type.ReturnType.Type).GetSystemTypeName();
            functionTag += "(";
            for (int i = 0; i < type.Parameters.Count; i++)
            {
                var param = type.Parameters[i];
                functionTag += TypeWrapperFactory.CreateTypeWrapper(param.Type).GetSystemTypeName();
                if (i != (type.Parameters.Count - 1))
                    functionTag += ",";
            }
            functionTag += ")";
            return functionTag;
        }

        public string GetSystemTypeName(bool addComment = false)
        {
            string tag = GetRawTypeName();
            if (TypeWrapperFactory.DelegateGenerator.ContainsKey(tag))
            {
                return TypeWrapperFactory.DelegateGenerator[tag].name;
            }
            else
            {
                DelegateDefine deleg = new DelegateDefine();
                deleg.tag = tag;
                deleg.name = TypeWrapperFactory.CurrentPrefix + "_func_" + TypeWrapperFactory.DelegateGenerator.Count.ToString();
                //public delegate int GetBufferCallback(IntPtr pAVCodecContext, IntPtr pAVFrame);
                deleg.fullName = "public delegate ";
                deleg.fullName += TypeWrapperFactory.CreateTypeWrapper(type.ReturnType.Type).GetSystemTypeName(true);
                deleg.fullName += " " + deleg.name + "(\r\n";
                for (int i = 0; i < type.Parameters.Count; i++)
                {
                    var param = type.Parameters[i];
                    deleg.fullName += "\t"+TypeWrapperFactory.CreateTypeWrapper(param.Type).GetMarshalTag();
                    deleg.fullName += TypeWrapperFactory.CreateTypeWrapper(param.Type).GetSystemTypeName(true);
                    if (!string.IsNullOrEmpty(param.Name))
                        deleg.fullName += " " + param.Name;
                    else
                        deleg.fullName += " __arg" + i.ToString();
                    if (i != (type.Parameters.Count - 1))
                        deleg.fullName += ", \r\n";
                }
                deleg.fullName += ");";
                TypeWrapperFactory.DelegateGenerator.Add(tag, deleg);
                return deleg.name;
            }
        }

        public string GetMarshalTag()
        {
            return "[MarshalAs(UnmanagedType.FunctionPtr)]";
        }
    }

    internal class BuildinTypeWrapper : ITypeWrapper
    {
        private CppSharp.AST.Type rawType;
        CppSharp.AST.BuiltinType type;
        public BuildinTypeWrapper(CppSharp.AST.Type rawType)
        {
            this.rawType = rawType;
            type = rawType as CppSharp.AST.BuiltinType;
        }

        public string GetRawTypeName()
        {
            return type.Type.ToString();
        }

        public string GetSystemTypeName(bool addComment = false)
        {
            string ret = "";
            switch (type.Type)
            {
                case CppSharp.AST.PrimitiveType.Bool:
                    ret = "System.Bool";
                    break;
                //case CppSharp.AST.PrimitiveType.Char:
                case CppSharp.AST.PrimitiveType.Int8:
                    ret = "System.Char";
                    break;
                case CppSharp.AST.PrimitiveType.Double:
                    ret = "System.Double";
                    break;
                case CppSharp.AST.PrimitiveType.Float:
                    ret = "float";
                    break;
                case CppSharp.AST.PrimitiveType.Int16:
                    ret = "System.Int16";
                    break;
                case CppSharp.AST.PrimitiveType.Int32:
                    ret = "System.Int32";
                    break;
                case CppSharp.AST.PrimitiveType.Int64:
                    ret = "System.Int64";
                    break;
                case CppSharp.AST.PrimitiveType.IntPtr:
                    ret = "System.IntPtr";
                    break;
                case CppSharp.AST.PrimitiveType.Null:
                    ret = "null";
                    break;
                case CppSharp.AST.PrimitiveType.UInt8:
                    ret = "System.Byte";
                    break;
                case CppSharp.AST.PrimitiveType.UInt16:
                    ret = "System.UInt16";
                    break;
                case CppSharp.AST.PrimitiveType.UInt32:
                    ret = "System.UInt32";
                    break;
                case CppSharp.AST.PrimitiveType.UInt64:
                    ret = "System.UInt64";
                    break;;
                case CppSharp.AST.PrimitiveType.Void:
                    ret = "void";
                    break;
                case CppSharp.AST.PrimitiveType.WideChar:
                    ret = "System.UInt16";
                    break;
                default:
                    ret = "";
                    break;
            }
            return ret;
        }

        public string GetMarshalTag()
        {
            string ret = "";
            switch (type.Type)
            {
                case CppSharp.AST.PrimitiveType.Bool:
                    ret = "[MarshalAs(UnmanagedType.I1)]";
                    break;
                //case CppSharp.AST.PrimitiveType.Char:
                case CppSharp.AST.PrimitiveType.Int8:
                    ret = "[MarshalAs(UnmanagedType.I1)]";
                    break;
                case CppSharp.AST.PrimitiveType.Double:
                    ret = "[MarshalAs(UnmanagedType.R8)]";
                    break;
                case CppSharp.AST.PrimitiveType.Float:
                    ret = "[MarshalAs(UnmanagedType.R4)]";
                    break;
                case CppSharp.AST.PrimitiveType.Int16:
                    ret = "[MarshalAs(UnmanagedType.I2)]";
                    break;
                case CppSharp.AST.PrimitiveType.Int32:
                    ret = "[MarshalAs(UnmanagedType.I4)]";
                    break;
                case CppSharp.AST.PrimitiveType.Int64:
                    ret = "[MarshalAs(UnmanagedType.I8)]";
                    break;
                case CppSharp.AST.PrimitiveType.IntPtr:
                    ret = "";
                    break;
                case CppSharp.AST.PrimitiveType.Null:
                    ret = "";
                    break;
                case CppSharp.AST.PrimitiveType.UInt8:
                    ret = "[MarshalAs(UnmanagedType.I1)]";
                    break;
                case CppSharp.AST.PrimitiveType.UInt16:
                    ret = "[MarshalAs(UnmanagedType.I2)]";
                    break;
                case CppSharp.AST.PrimitiveType.UInt32:
                    ret = "[MarshalAs(UnmanagedType.I4)]";
                    break;
                case CppSharp.AST.PrimitiveType.UInt64:
                    ret = "[MarshalAs(UnmanagedType.I8)]";
                    break; ;
                case CppSharp.AST.PrimitiveType.Void:
                    ret = "";
                    break;
                case CppSharp.AST.PrimitiveType.WideChar:
                    ret = "[MarshalAs(UnmanagedType.I2)]";
                    break;
                default:
                    ret = "";
                    break;
            }
            return ret;
        }
    }

    internal class DecayedTypeWrapper : ITypeWrapper
    {
        private CppSharp.AST.Type rawType;
        CppSharp.AST.DecayedType type;
        public DecayedTypeWrapper(CppSharp.AST.Type rawType)
        {
            this.rawType = rawType;
            type = rawType as CppSharp.AST.DecayedType;
        }

        public string GetRawTypeName()
        {
            return TypeWrapperFactory.CreateTypeWrapper(type.Decayed.Type).GetRawTypeName();
        }

        public string GetSystemTypeName(bool addComment = false)
        {
            return TypeWrapperFactory.CreateTypeWrapper(type.Decayed.Type).GetSystemTypeName();
        }

        public string GetMarshalTag()
        {
            return TypeWrapperFactory.CreateTypeWrapper(type.Decayed.Type).GetMarshalTag();
        }
    }

    internal class TagedTypeWrapper : ITypeWrapper
    {
        private CppSharp.AST.Type rawType;
        CppSharp.AST.TagType type;
        public TagedTypeWrapper(CppSharp.AST.Type rawType)
        {
            this.rawType = rawType;
            type = rawType as CppSharp.AST.TagType;
        }

        public string GetRawTypeName()
        {
            return type.Declaration.Name;
        }

        public string GetSystemTypeName(bool addComment = false)
        {
            return GetRawTypeName();
        }

        public string GetMarshalTag()
        {
            return "";
        }
    }

    internal class TypedefTypeWrapper : ITypeWrapper
    {
        private CppSharp.AST.Type rawType;
        CppSharp.AST.TypedefType type;
        public TypedefTypeWrapper(CppSharp.AST.Type rawType)
        {
            this.rawType = rawType;
            type = rawType as CppSharp.AST.TypedefType;
        }

        public string GetRawTypeName()
        {
            return TypeWrapperFactory.CreateTypeWrapper(type.Declaration.Type).GetRawTypeName();
        }

        public string GetSystemTypeName(bool addComment = false)
        {
            return TypeWrapperFactory.CreateTypeWrapper(type.Declaration.Type).GetSystemTypeName();
        }

        public string GetMarshalTag()
        {
            return TypeWrapperFactory.CreateTypeWrapper(type.Declaration.Type).GetMarshalTag();
        }
    }

    internal class PointerTypeWrapper : ITypeWrapper
    {
        private CppSharp.AST.Type rawType;
        CppSharp.AST.PointerType type;
        public PointerTypeWrapper(CppSharp.AST.Type rawType)
        {
            this.rawType = rawType;
            type = rawType as CppSharp.AST.PointerType;
        }

        public string GetRawTypeName()
        {
            return "IntPtr";
        }

        public string GetSystemTypeName(bool addComment = false)
        {
            if (type.Pointee is CppSharp.AST.FunctionType)
            {
                return TypeWrapperFactory.CreateTypeWrapper(type.Pointee).GetSystemTypeName();
            }
            else if (type.Pointee is CppSharp.AST.BuiltinType)
            {
                CppSharp.AST.BuiltinType buildin = type.Pointee as CppSharp.AST.BuiltinType;
                if (buildin.Type == CppSharp.AST.PrimitiveType.UInt8 ||
                    buildin.Type == CppSharp.AST.PrimitiveType.Int8 ||
                    buildin.Type == CppSharp.AST.PrimitiveType.Char ||
                    buildin.Type == CppSharp.AST.PrimitiveType.UChar)
                    return "string";
            }
            string pointeeTypeName = TypeWrapperFactory.CreateTypeWrapper(type.Pointee).GetSystemTypeName();
            string ret = "IntPtr";
            if (addComment)
               ret += "/* " + pointeeTypeName + "*  */";
            return ret;
        }

        public string GetMarshalTag()
        {
            if (type.Pointee is CppSharp.AST.FunctionType)
            {
                return TypeWrapperFactory.CreateTypeWrapper(type.Pointee).GetMarshalTag();
            }

            else if (type.Pointee is CppSharp.AST.BuiltinType)
            {
                CppSharp.AST.BuiltinType buildin = type.Pointee as CppSharp.AST.BuiltinType;
                if (buildin.Type == CppSharp.AST.PrimitiveType.UInt8 ||
                    buildin.Type == CppSharp.AST.PrimitiveType.Int8 ||
                    buildin.Type == CppSharp.AST.PrimitiveType.Char ||
                    buildin.Type == CppSharp.AST.PrimitiveType.UChar)
                    return "[MarshalAs(UnmanagedType.LPStr)]";
            }

            return "";
        }
    }

    internal class ArrayTypeWrapper : ITypeWrapper
    {
        private CppSharp.AST.Type rawType;
        CppSharp.AST.ArrayType type;
        public ArrayTypeWrapper(CppSharp.AST.Type rawType)
        {
            this.rawType = rawType;
            type = rawType as CppSharp.AST.ArrayType;
        }

        public string GetRawTypeName()
        {
            string typeName = TypeWrapperFactory.CreateTypeWrapper(type.Type).GetRawTypeName();
            return typeName;
        }

        public string GetSystemTypeName(bool addComment = false)
        {
            return GetRawTypeName() + "[]";
        }

        public string GetMarshalTag()
        {
            return "[MarshalAs(UnmanagedType.ByValArray, SizeConst=" + type.Size.ToString() + ")]";
        }
    }

    public class TypeHeloer
    {
        public static string GetRawTypeName(CppSharp.AST.Type type)
        {
            return TypeWrapperFactory.CreateTypeWrapper(type).GetRawTypeName();
        }

        public static string GetSystemTypeName(CppSharp.AST.Type type, bool addComment = false)
        {
            return TypeWrapperFactory.CreateTypeWrapper(type).GetSystemTypeName(addComment);
        }

        public static string GetMarshalTag(CppSharp.AST.Type type)
        {
            return TypeWrapperFactory.CreateTypeWrapper(type).GetMarshalTag();
        }
    }
}

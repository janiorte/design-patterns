using System;
using System.Collections.Generic;
using System.Text;

namespace Coding.Exercise
{
    public class CodeBuilder
    {
        public string ClassName { get; set; }
        public IDictionary<string, string> Fields { get; set; }
        private CodeBuilder codeBuilder { get; set; }

        public CodeBuilder(string className)
        {
            ClassName = className;
            Fields = new Dictionary<string, string>();
        }

        public CodeBuilder AddField(string fieldName, string typeName)
        {
            Fields.Add(fieldName, typeName);
            return this;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("public class ").AppendLine(ClassName);
            sb.AppendLine("{");
            foreach (var field in Fields)
            {
                sb.Append("  public ").Append(field.Value).Append(" ").Append(field.Key).AppendLine(";");
            }
            sb.AppendLine("}");

            return sb.ToString();
        }

        public static void Main(string[] args)
        {
            var cb = new CodeBuilder("Person").AddField("Name", "string").AddField("Age", "int");
            Console.WriteLine(cb);
        }
    }
}

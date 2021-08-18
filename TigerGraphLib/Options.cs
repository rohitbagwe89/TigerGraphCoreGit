using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TigerGraphLib
{
    public class Options
    {
      

        public static Dictionary<string, object> Parse(string o)
        {
            Dictionary<string, object> options = new Dictionary<string, object>();
            Regex re = new Regex(@"(\w+)\=([^\,]+)", RegexOptions.Compiled);
            string[] pairs = o.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string s in pairs)
            {
                Match m = re.Match(s);
                if (!m.Success)
                {
                    options.Add("_ERROR_", s);
                }
                else if (options.ContainsKey(m.Groups[1].Value))
                {
                    options[m.Groups[1].Value] = m.Groups[2].Value;
                }
                else
                {
                    options.Add(m.Groups[1].Value, m.Groups[2].Value);
                }
            }
            return options;
        }
    }

    public class ApiOptions : Options
    {
        
        public string Token { get; set; }

    
        public string RestServerUrl { get; set; }

        
        public string GsqlServerUrl { get; set; }

        
        public string User { get; set; }

        
        public string Pass { get; set; }
    }

    
    public class PingOptions : ApiOptions {}

    
    public class EndpointsOptions : ApiOptions {}

    
    public class SchemaOptions : ApiOptions 
    {
        
        public string Graph { get; set; }

        
        public string Vertex { get; set; }

        
        public string Edge { get; set; }
    }

    
    public class VerticesOptions : ApiOptions
    {
        
        public string Graph { get; set; }

        
        public string Vertex { get; set; }

        
        public string Id { get; set; }

        
        public bool Count { get; set; }
    }

    
    public class EdgesOptions : ApiOptions
    {
        
        public string Graph { get; set; }

        
        public string Source { get; set; }

        
        public string Id { get; set; }
        
        
        public string Edge { get; set; }

        
        public string Target { get; set; }

        
        public string Tid { get; set; }

        
        public bool Count { get; set; }
    }
    
    
    
    
    public class UpsertOptions : ApiOptions
    {
        //[Option('g', "graph", Required = false, Default = "MyGraph", HelpText = "The name of the graph.")]
        public string Graph { get; set; }

        //[Option('f', "file", Required = true, HelpText = "File containing the JSON data to upsert.")]
        public string File { get; set; }
    }

    //[Verb("query", HelpText = "Run a GSQL interpreted query on the specified graph using the specified parameters.")]
    public class QueryOptions : ApiOptions
    {
        //[Option('s', "source", Required = false, HelpText = "The GSQL query to run.")]
        public string Source { get; set; }

        //[Option('f', "file", Required = false, HelpText = "A file containing the GSQL query to run.")]
        public string File { get; set; }

        //[Option('p', "params", Required = false, HelpText = "A comma-delimited list of query parameters in the form p1=v1,p2=v2,...")]
        public string Parameters { get; set; }
    }

    //[Verb("exec", HelpText = "Execute a GSQL command on the specified graph using the specified parameters.")]
    public class ExecOptions : ApiOptions
    {
        //[Option('s', "source", Required = false, HelpText = "The GSQL command to run.")]
        public string Source { get; set; }

        //[Option('f', "file", Required = false, HelpText = "A file containing the GSQL command to run.")]
        public string File { get; set; }

    }

    //[Verb("builtin", HelpText = "Execute a builtin function on the specified graph.")]
    public class BuiltinOptions : ApiOptions
    {
        //[Option('g', "graph", Required = false, Default = "MyGraph", HelpText = "The name of the graph.")]
        public string Graph { get; set; }

       // [Option('f', "func", Required = true, HelpText = "The name of the builtin function to execute.")]
        public string Fn { get; set; }

        //[Option('t', "function", Required = false, Default = "", HelpText = "The vertex or edge type to execute the function against.")]
        public string FnType { get; set; }
    }
}

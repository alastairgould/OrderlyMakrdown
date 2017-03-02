using System.IO;
using OrderlyMarkdown.Adapter.Parser.CommonMark;
using OrderlyMarkdown.PrettyPrinter;
using CommandLine;
using CommandLine.Text;

namespace OrderlyMarkdown.Adapter.Console
{
    public class Program
    {
        public static void Main(params string[] args)
        {
            var result = CommandLine.Parser.Default.ParseArguments<Options>(args);
            result.WithParsed(ReformatMarkdown);
        }

        private static void ReformatMarkdown(Options options)
        {
            var parser = new CommonMarkParserAdapter();

            using (var inputStream = File.OpenText(options.InputFile))
            using (var outputStream = File.CreateText(options.OutputFile))
            {
                var doc = parser.CreateDocumentFromStream(inputStream);
                var prettyPrinter = new StandardMarkdownPrettyPrinter(outputStream);
                prettyPrinter.PrintDocument(doc);
            }
        }
    }
}

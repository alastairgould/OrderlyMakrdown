using CommandLine;

namespace OrderlyMarkdown.Adapter.Console
{
    public class Options
    {
        [Option('i', "inputfile", Required = true)]
        public string InputFile { get; set; }

        [Option('o', "outputfile", Required = true)]
        public string OutputFile { get; set; }
    }
}

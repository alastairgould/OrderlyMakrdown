using OrderlyMarkdown.PrettyPrinter;

namespace OrderlyMarkdown.DocumentObjectModel
{
    public class Heading : IDocumentElement
    {
        public string Value { get; set; }

        public int HeaderLevel { get; set; }

        public Heading(string value, int level)
        {
            Value = value;
            HeaderLevel = level;
        }

        public void Traverse(IPrettyPrinter prettyPrinter)
        {
            prettyPrinter.PrintHeader(this);
        }
    }
}

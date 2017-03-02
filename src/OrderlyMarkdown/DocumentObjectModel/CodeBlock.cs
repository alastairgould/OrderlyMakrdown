using OrderlyMarkdown.PrettyPrinter;

namespace OrderlyMarkdown.DocumentObjectModel
{
    public class CodeBlock : IDocumentElement
    {
        public string Value { get; set; }

        public string Language { get; set; }

        public void Traverse(IPrettyPrinter prettyPrinter)
        {
            prettyPrinter.PrintCodeBlock(this);
        }
    }
}

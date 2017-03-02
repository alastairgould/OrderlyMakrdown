using OrderlyMarkdown.PrettyPrinter;

namespace OrderlyMarkdown.DocumentObjectModel
{
    public class Paragraph : IDocumentElement
    {
        public string Value { get; set; }

        public Paragraph(string paragraph)
        {
            Value = paragraph;
        }

        public void Traverse(IPrettyPrinter prettyPrinter)
        {
            prettyPrinter.PrintParagraph(this);
        }
    }
}

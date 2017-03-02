using OrderlyMarkdown.DocumentObjectModel;

namespace OrderlyMarkdown.PrettyPrinter
{
    public interface IPrettyPrinter
    {
        void PrintDocument(Document document);
        void PrintParagraph(Paragraph paragraph);
        void PrintHeader(Heading header);
        void PrintCodeBlock(CodeBlock codeBlock);
    }
}

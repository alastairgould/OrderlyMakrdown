using OrderlyMarkdown.PrettyPrinter;

namespace OrderlyMarkdown.DocumentObjectModel
{
    public interface IDocumentElement
    {
        void Traverse(IPrettyPrinter prettyPrinter);
    }
}

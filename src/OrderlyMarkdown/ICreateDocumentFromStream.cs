using OrderlyMarkdown.DocumentObjectModel;
using System.IO;

namespace OrderlyMarkdown
{
    public interface ICreateDocumentFromStream
    {
        Document CreateDocumentFromStream(TextReader reader);
    }
}

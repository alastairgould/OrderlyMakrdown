using System.IO;
using OrderlyMarkdown.DocumentObjectModel;
using CommonMark;

namespace OrderlyMarkdown.Adapter.Parser.CommonMark
{
    public class CommonMarkParserAdapter : ICreateDocumentFromStream
    {
        public Document CreateDocumentFromStream(TextReader reader)
        {
            var commonMarkDocument = CommonMarkConverter.Parse(reader);

            var converter = new ConvertFromCommonMarkToOrderly();
            return converter.Convert(commonMarkDocument);
        }
    }
}

using CommonMark.Syntax;
using OrderlyMarkdown.DocumentObjectModel;

namespace OrderlyMarkdown.Adapter.Parser.CommonMark
{
    public interface IConvertFromCommonMarkToOrderly
    {
        Document Convert(Block block);
    }
}

using System;
using CommonMark.Syntax;

namespace OrderlyMarkdown.Adapter.Parser.CommonMark
{
    public static class LiteralContentSerializer
    {
        public static string FlattenLiteralContent(Inline inline)
        {
            var flattenedContent = "";

            while (inline != null)
            {
                flattenedContent = ProccessNode(inline, flattenedContent);
                inline = inline.NextSibling;
            }
            return flattenedContent;
        }

        private static string ProccessNode(Inline node, string currentString)
        {
            switch(node.Tag)
            {
                case InlineTag.String:
                    return String(node, currentString);
                case InlineTag.SoftBreak:
                    return SoftBreak(node, currentString);
                case InlineTag.Link:
                    return Link(node, currentString);
                case InlineTag.Code:
                    return Code(node, currentString);
                case InlineTag.Emphasis:
                    return Emphasis(node, currentString);

                default:
                    throw new NotImplementedException("Unsurported element " + node.Tag.ToString());
            }
        }

        private static string String(Inline node, string currentString)
        {
            return currentString + node.LiteralContent;
        }

        private static string Code(Inline node, string currentString)
        {
            return currentString + node.LiteralContent;
        }

        private static string SoftBreak(Inline node, string currentString)
        {
            return currentString + " ";
        }

        private static string Link(Inline node, string currentString)
        {
            return currentString + "[" + node.FirstChild.LiteralContent + "](" + node.TargetUrl + ")";
        }

        private static string Emphasis(Inline node, string currentString)
        {
            var literalValue = node.Emphasis.DelimiterCharacter
                + node.FirstChild.LiteralContent
                + node.Emphasis.DelimiterCharacter;

            return currentString + literalValue ;
        }
    }
}

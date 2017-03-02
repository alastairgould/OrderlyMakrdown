using System;
using System.Collections.Generic;
using CommonMark.Syntax;
using OrderlyMarkdown.DocumentObjectModel;


namespace OrderlyMarkdown.Adapter.Parser.CommonMark
{
    public class ConvertFromCommonMarkToOrderly : IConvertFromCommonMarkToOrderly
    {
        public Document Convert(Block block)
        {
            return Document(block);
        }

        private Document Document(Block block)
        {
            if (block.Tag != BlockTag.Document)
                throw new Exception("Expected document node for first element in tree");

            var childElements = new List<IDocumentElement>();

            var node = block.FirstChild;

            while (node != null)
            {
                childElements.Add(ProcessNode(node));
                node = node.NextSibling;
            }
            return new Document(childElements);
        }

        private IDocumentElement ProcessNode(Block block)
        {
            switch(block.Tag)
            {
                case BlockTag.AtxHeading:
                    return AtxHeading(block);
                case BlockTag.BlockQuote:
                    return BlockQuote(block);                
                case BlockTag.FencedCode:
                    return FencedCode(block);
                case BlockTag.HtmlBlock:
                    return HtmlBlock(block);
                case BlockTag.IndentedCode:
                    return IndentedCode(block);
                case BlockTag.List:
                    return List(block);
                case BlockTag.ListItem:
                    return ListItem(block);
                case BlockTag.Paragraph:
                    return Paragraph(block);
                case BlockTag.ReferenceDefinition:
                    return ReferenceDefinition(block);
                case BlockTag.SetextHeading:
                    return SetextHeading(block);
                case BlockTag.ThematicBreak:
                    return ThematicBreak(block);

                default:
                    throw new NotImplementedException("Unsurported element " + block.Tag.ToString());
            }
        }

        private IDocumentElement AtxHeading(Block block)
        {
            return new Heading(LiteralContentSerializer
                .FlattenLiteralContent(block.InlineContent), block.Heading.Level);
        }

        private IDocumentElement BlockQuote(Block block)
        {
            throw new NotImplementedException("Unsurported element = BlockQuote");
        }

        private IDocumentElement FencedCode(Block block)
        {
            var codeBlock = new CodeBlock();
            codeBlock.Language = block.FencedCodeData.Info;
            codeBlock.Value = block.StringContent.ToString();

            //Seems to only output /n on any platform. 
            codeBlock.Value = codeBlock.Value.Replace("\n", Environment.NewLine);    
            return codeBlock;
        }

        private IDocumentElement HtmlBlock(Block block)
        {
            throw new NotImplementedException("Unsurported element = HtmlBlock");
        }

        private IDocumentElement IndentedCode(Block block)
        {
            throw new NotImplementedException("Unsurported element = IndentedCode");
        }

        private IDocumentElement List(Block block)
        {
            throw new NotImplementedException("Unsurported element = List");
        }

        private IDocumentElement ListItem(Block block)
        {
            throw new NotImplementedException("Unsurported element = ListItem");
        }

        private IDocumentElement Paragraph(Block block)
        {
            var paragraphString = "";

            if (block.InlineContent != null)
                paragraphString = LiteralContentSerializer.FlattenLiteralContent(block.InlineContent);

            return new Paragraph(paragraphString);
        }

        private IDocumentElement ReferenceDefinition(Block block)
        {
            throw new NotImplementedException("Unsurported element = ReferenceDefinition");
        }

        private IDocumentElement SetextHeading(Block block)
        {
            throw new NotImplementedException("Unsurported element = SETextHeading");
        }

        private IDocumentElement ThematicBreak(Block block)
        {
            throw new NotImplementedException("Unsurported element = ThematicBreak");
        }
    }
}

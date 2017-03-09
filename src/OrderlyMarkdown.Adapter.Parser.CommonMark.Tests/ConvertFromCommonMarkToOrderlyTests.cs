using Xunit;
using OrderlyMarkdown.DocumentObjectModel;
using CommonMark.Syntax;
using System;

namespace OrderlyMarkdown.Adapter.Parser.CommonMark.Tests
{
    public class ConvertFromCommonMarkToOrderlyTests
    {
        [Fact]
        public void ConvertingADocument()
        {
            var converter = new ConvertFromCommonMarkToOrderly();
            var block = CreateDocumentBlock();
            var result = converter.Convert(block);

            Assert.NotNull(result);
            Assert.IsType<Document>(result);
            Assert.Empty(result.ChildrenAsEnumerable());
        }

        [Fact]
        public void ConvertingAHeader()
        {
            var converter = new ConvertFromCommonMarkToOrderly();
            var headerBlock = new Block(BlockTag.AtxHeading, 0)
            {
                Heading = new HeadingData(5),
                InlineContent = new Inline("Header")
            };
            var block = CreateDocumentBlock(headerBlock);

            var result = converter.Convert(block);

            Assert.Collection(result.ChildrenAsEnumerable(), element =>
            {
                Assert.IsType<Heading>(element);
                var header = (Heading)element;
                Assert.Equal(header.Value, "Header");
                Assert.Equal(header.HeaderLevel, 5);
            });
        }

        

        [Fact]
        public void ConvertingAParagraph()
        {
            var paragraphText = @"Lorem ipsum dolor sit amet, choro dolorum vocibus est et";
            var converter = new ConvertFromCommonMarkToOrderly();
            var paragraphBlock = new Block(BlockTag.Paragraph, 0)
            {
                InlineContent = new Inline(paragraphText)
            };
            var block = CreateDocumentBlock(paragraphBlock);

            var result = converter.Convert(block);

            Assert.Collection(result.ChildrenAsEnumerable(), element =>
            {
                Assert.IsType<Paragraph>(element);
                var paragraph = (Paragraph)element;
                Assert.Equal(paragraph.Value, paragraphText);
            });
        }


        [Fact]
        public void ConvertingACodeBlock()
        {
            var code = "class testing \n { \n private string _test; } \n}";
            var stringContent = new StringContent();
            stringContent.Append(code, 0, code.Length);

            var converter = new ConvertFromCommonMarkToOrderly();
            var codeBlock = new Block(BlockTag.FencedCode, 0)
            {
                StringContent = stringContent,
                FencedCodeData = new FencedCodeData()
                {
                    Info = "csharp"
                }
            };
            var block = CreateDocumentBlock(codeBlock);

            var result = converter.Convert(block);

            Assert.Collection(result.ChildrenAsEnumerable(), element =>
            {
                Assert.IsType<CodeBlock>(element);
                var codeBlockElement = (CodeBlock)element;
                Assert.Equal(code.Replace("\n", Environment.NewLine), codeBlockElement.Value);
                Assert.Equal(codeBlockElement.Language, "csharp");

            });
        }

        private Block CreateDocumentBlock(Block child)
        {
            var document = CreateDocumentBlock();
            document.FirstChild = child;
            return document;
        }

        private Block CreateDocumentBlock()
        {
            var document = new Block(BlockTag.Document, 0);
            return document;
        }
    }
}

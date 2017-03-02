using System.Collections.Generic;
using Xunit;
using NSubstitute;
using OrderlyMarkdown.DocumentObjectModel;
using OrderlyMarkdown.PrettyPrinter;

namespace OrderlyMarkdown.Tests
{
    public class DocumentObjectModelTests
    {
        [Fact]
        public void WhenTraversingDocumentNode()
        {
            var document = new Document(new List<IDocumentElement>());
            var visitor = Substitute.For<IPrettyPrinter>();

            document.Traverse(visitor);

            visitor
                .Received(1)
                .PrintDocument(Arg.Is(document));
        }

        [Fact]
        public void WhenTraversingAHeaderNode()
        {
            var header = new Heading("Testing", 1);
            var visitor = Substitute.For<IPrettyPrinter>();

            header.Traverse(visitor);

            visitor
                .Received(1)
                .PrintHeader(Arg.Is<Heading>(param =>
                    param.Value == header.Value && 
                    param.HeaderLevel == header.HeaderLevel));
        }

        [Fact]
        public void WhenTraversingAParagraphNode()
        {
            var paragraph = new Paragraph("Testing");
            var visitor = Substitute.For<IPrettyPrinter>();

            paragraph.Traverse(visitor);

            visitor
                .Received(1)
                .PrintParagraph(Arg.Is<Paragraph>(param =>
                    param.Value == paragraph.Value));
        }

        [Fact]
        public void WhenTraversingACodeBlock()
        {
            var header = new CodeBlock()
            {
                Value = "test",
                Language = "csharp"
            };

            var visitor = Substitute.For<IPrettyPrinter>();

            header.Traverse(visitor);

            visitor
                .Received(1)
                .PrintCodeBlock(Arg.Is<CodeBlock>(param =>
                    param.Value == header.Value &&
                    param.Language == header.Language));
        }
    }
}

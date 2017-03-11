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
            var SUT = new Document(new List<IDocumentElement>());
            var visitor = Substitute.For<IPrettyPrinter>();

            SUT.Traverse(visitor);

            visitor.Received(1).PrintDocument(Arg.Is(SUT));
        }

        [Fact]
        public void WhenTraversingAHeaderNode()
        {
            var SUT = new Heading("Testing", 1);
            var visitor = Substitute.For<IPrettyPrinter>();

            SUT.Traverse(visitor);

            visitor.Received(1).PrintHeader(Arg.Is(SUT));
        }

        [Fact]
        public void WhenTraversingAParagraphNode()
        {
            var SUT = new Paragraph("Testing");
            var visitor = Substitute.For<IPrettyPrinter>();

            SUT.Traverse(visitor);

            visitor.Received(1).PrintParagraph(Arg.Is(SUT));
        }

        [Fact]
        public void WhenTraversingACodeBlock()
        {
            var SUT = new CodeBlock();
            var visitor = Substitute.For<IPrettyPrinter>();

            SUT.Traverse(visitor);

            visitor.Received(1).PrintCodeBlock(Arg.Is(SUT));
        }
    }
}

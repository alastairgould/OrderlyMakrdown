using System.IO;
using OrderlyMarkdown.DocumentObjectModel;

namespace OrderlyMarkdown.PrettyPrinter
{
    public class StandardMarkdownPrettyPrinter : IPrettyPrinter
    {
        private TextWriter _textWriter;

        public StandardMarkdownPrettyPrinter(TextWriter textWriter)
        {
            _textWriter = textWriter;
        }

        public void PrintDocument(Document document)
        {
            foreach(var node in document.ChildrenAsEnumerable())
            {
                node.Traverse(this);
            }
        }

        public void PrintHeader(Heading header)
        {
            PrintHeaderLevelHash(header.HeaderLevel);
            _textWriter.WriteLine(header.Value);
            _textWriter.WriteLine();
        }

        public void PrintParagraph(Paragraph paragraph)
        {
            var text = new Simpler.Net.Text.SimplerTextWrapper(paragraph.Value, 80)
                .GetWrappedText();

            _textWriter.WriteLine(text);
            _textWriter.WriteLine();
        }

        private void PrintHeaderLevelHash(int headerLevel)
        {
            for (int level = 0; level < headerLevel; level++)
                _textWriter.Write("#");

            _textWriter.Write(" ");
        }

        public void PrintCodeBlock(CodeBlock codeBlock)
        {
            _textWriter.WriteLine("```" + codeBlock.Language);
            _textWriter.Write(codeBlock.Value);
            _textWriter.WriteLine("```");
            _textWriter.WriteLine();
        }
    }
}

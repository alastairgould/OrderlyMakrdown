using System.Collections.Generic;
using OrderlyMarkdown.PrettyPrinter;

namespace OrderlyMarkdown.DocumentObjectModel
{
    public class Document : IDocumentElement, IHasChildElements
    {
        private IEnumerable<IDocumentElement> Children { get; set; }

        public Document(IEnumerable<IDocumentElement> childElements)
        {
            Children = childElements;
        }

        public void Traverse(IPrettyPrinter prettyPrinter)
        {
            prettyPrinter.PrintDocument(this);
        }

        public IEnumerable<IDocumentElement> ChildrenAsEnumerable()
        {
            return Children;
        }
    }
}

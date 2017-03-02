using System.Collections.Generic;

namespace OrderlyMarkdown.DocumentObjectModel
{
    public interface IHasChildElements
    {
        IEnumerable<IDocumentElement> ChildrenAsEnumerable();
    }
}

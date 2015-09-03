using System.Linq;
using System.Xml.Linq;

namespace XdsKit
{
    public static partial class XDocumentExtensions
    {
        public static XDocument Normalize(this XDocument source)
        {
            return new XDocument(
                source.Declaration,
                source.Nodes().Select(n => n.Normalize()));
        }

        // Filter some nodes, trim text whitespace, normalize children
        private static XNode Normalize(this XNode node)
        {
            if (node.IsInstruction())
                return null;

            var txt = node as XText;
            if (txt != null)
                return (txt.Parent == txt.Document.Root) ? null : txt.Normalize();

            var element = node as XElement;
            return element != null ? element.Normalize() : node;
        }

        // Sort attributes, strip namespaces, and normalize children
        private static XElement Normalize(this XElement element)
        {
            return new XElement(
                element.Name,
                element.Attributes()
                    .Where(a => !a.IsNamespaceDeclaration)
                    .OrderBy(a => a.Name.NamespaceName)
                    .ThenBy(a => a.Name.LocalName),
                element.Nodes()
                    .Select(n => n.Normalize())
                );
        }

        // Trim leading / trailing white-space
        private static XText Normalize(this XText text)
        {
            return new XText(text.Value.Trim());
        }

        // Instructions can be safely removed
        private static bool IsInstruction(this XNode node)
        {
            return (node is XProcessingInstruction || node is XDocumentType || node is XComment);
        }
    }
}

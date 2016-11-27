using System.Xml.Linq;
using Sitecore;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;

namespace DynamicDatasource.Pipeline
{
    public class CustomXmlBasedRenderingParser : XmlBasedRenderingParser
    {
        public override Rendering Parse(XElement node, bool parseChildNodes)
        {
            Rendering rendering = base.Parse(node, parseChildNodes);
            ResolveRenderingItemDataSource(rendering);
            return rendering;
        }

        private static void ResolveRenderingItemDataSource(Rendering rendering)
        {
            if (rendering.DataSource != null && rendering.DataSource.StartsWith("query:"))
            {
                string query = rendering.DataSource.Substring("query:".Length);
                Item contextItem = Context.Item;
                Item queryItem = contextItem.Axes.SelectSingleItem(query);
                if (queryItem != null)
                {
                    rendering.DataSource = queryItem.Paths.FullPath;
                }
            }
        }
    }
}
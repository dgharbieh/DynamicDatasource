using Sitecore.Mvc.Configuration;
using Sitecore.Mvc.Presentation;
using Sitecore.Pipelines;

namespace DynamicDatasource.Pipeline
{
    public class RegisterCustomXmlBasedRenderingParser
    {
        public virtual void Process(PipelineArgs args)
        {
            MvcSettings.RegisterObject<XmlBasedRenderingParser>(() => new CustomXmlBasedRenderingParser());
        }
    }
}
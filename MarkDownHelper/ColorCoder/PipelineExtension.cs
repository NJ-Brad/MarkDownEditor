using System;
using System.Linq;
using Markdig;

namespace MarkDownHelper.ColorCoder
{
    public static class PipelineExtension
    {
        public static MarkdownPipelineBuilder UseSyntaxHighlighting(this MarkdownPipelineBuilder pipeline)
        {
            pipeline.Extensions.Add(new SyntaxHighlightExtension());
            return pipeline;
        }
    }
}
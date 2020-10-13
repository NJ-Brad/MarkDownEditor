using System;
using System.Linq;
using Markdig;
using Markdig.Renderers;
using Markdig.Renderers.Html;

namespace MarkDownHelper.ColorCoder
{
    public class SyntaxHighlightExtension : IMarkdownExtension {
        public void Setup(MarkdownPipelineBuilder pipeline) {}

        public void Setup(MarkdownPipeline pipeline, IMarkdownRenderer renderer)
        {
        //}

        //public void Setup(IMarkdownRenderer renderer)
        //{
            if (renderer == null)
            {
                throw new ArgumentNullException("renderer");
            }

            var htmlRenderer = renderer as TextRendererBase<HtmlRenderer>;
            if (htmlRenderer == null) {
                return;
            }

            var originalCodeBlockRenderer = htmlRenderer.ObjectRenderers.FindExact<CodeBlockRenderer>();
            if (originalCodeBlockRenderer != null) {
                htmlRenderer.ObjectRenderers.Remove(originalCodeBlockRenderer);
            }

            htmlRenderer.ObjectRenderers.AddIfNotAlready(
                new SyntaxHighlightingCodeBlockRenderer(originalCodeBlockRenderer));
        }
    }
}
using Markdig;
using System.Text;

namespace Agent.Controls;

public class MarkdownViewer : WebBrowser
{
    private readonly MarkdownPipeline _pipeline;

    public MarkdownViewer()
    {
        _pipeline = new MarkdownPipelineBuilder()
            .UseAdvancedExtensions()
            .Build();
        
        ScriptErrorsSuppressed = true;
    }

    public void SetMarkdownContent(string markdown)
    {
        var html = Markdown.ToHtml(markdown, _pipeline);
        var styledHtml = GetStyledHtml(html);
        DocumentText = styledHtml;
    }

    public void AppendMarkdownContent(string markdown)
    {
        var html = Markdown.ToHtml(markdown, _pipeline);
        var currentContent = DocumentText ?? "";
        
        // Extract content from existing HTML
        var bodyStart = currentContent.IndexOf("<body>");
        var bodyEnd = currentContent.IndexOf("</body>");
        
        if (bodyStart >= 0 && bodyEnd >= 0)
        {
            var existingContent = currentContent.Substring(bodyStart + 6, bodyEnd - bodyStart - 6);
            var newContent = existingContent + html;
            var styledHtml = GetStyledHtml(newContent);
            DocumentText = styledHtml;
        }
        else
        {
            SetMarkdownContent(markdown);
        }
    }

    private string GetStyledHtml(string content)
    {
        return $@"
<!DOCTYPE html>
<html>
<head>
    <meta charset='utf-8'>
    <style>
        body {{
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            line-height: 1.6;
            color: #333;
            max-width: 100%;
            margin: 0;
            padding: 20px;
            background-color: #fafafa;
        }}
        h1, h2, h3, h4, h5, h6 {{
            color: #2c3e50;
            margin-top: 20px;
            margin-bottom: 10px;
        }}
        h1 {{ font-size: 24px; border-bottom: 2px solid #3498db; padding-bottom: 10px; }}
        h2 {{ font-size: 20px; border-bottom: 1px solid #bdc3c7; padding-bottom: 5px; }}
        h3 {{ font-size: 18px; }}
        p {{ margin-bottom: 16px; }}
        code {{
            background-color: #f1f2f6;
            padding: 2px 4px;
            border-radius: 3px;
            font-family: 'Consolas', 'Monaco', 'Courier New', monospace;
            font-size: 14px;
        }}
        pre {{
            background-color: #2f3640;
            color: #ddd;
            padding: 16px;
            border-radius: 6px;
            overflow-x: auto;
            margin: 16px 0;
        }}
        pre code {{
            background-color: transparent;
            color: #ddd;
            padding: 0;
        }}
        blockquote {{
            border-left: 4px solid #3498db;
            margin: 16px 0;
            padding: 0 16px;
            color: #666;
            background-color: #ecf0f1;
        }}
        ul, ol {{
            margin-bottom: 16px;
            padding-left: 30px;
        }}
        li {{
            margin-bottom: 4px;
        }}
        a {{
            color: #3498db;
            text-decoration: none;
        }}
        a:hover {{
            text-decoration: underline;
        }}
        table {{
            border-collapse: collapse;
            width: 100%;
            margin: 16px 0;
        }}
        th, td {{
            border: 1px solid #ddd;
            padding: 8px;
            text-align: left;
        }}
        th {{
            background-color: #f2f2f2;
            font-weight: bold;
        }}
        .user-message {{
            background-color: #e3f2fd;
            border-left: 4px solid #2196f3;
            padding: 10px;
            margin: 10px 0;
            border-radius: 4px;
        }}
        .assistant-message {{
            background-color: #f3e5f5;
            border-left: 4px solid #9c27b0;
            padding: 10px;
            margin: 10px 0;
            border-radius: 4px;
        }}
        .error-message {{
            background-color: #ffebee;
            border-left: 4px solid #f44336;
            padding: 10px;
            margin: 10px 0;
            border-radius: 4px;
            color: #c62828;
        }}
    </style>
</head>
<body>
    {content}
</body>
</html>";
    }
}
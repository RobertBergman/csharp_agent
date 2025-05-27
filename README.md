# C# AI Agent Application

A comprehensive Windows Forms application that leverages OpenAI's GPT models to provide intelligent agent capabilities including multi-modal chat, document processing, receipt analysis, and trip planning.

**Lead Architect:** Robert L. Bergman

## ✨ Features

### 🤖 **AI Chat Interface**
- Multi-modal conversations with text and image support
- Markdown rendering for rich response formatting
- Real-time streaming responses from OpenAI GPT models

### 🧾 **Receipt Processing**
- Extract structured data from receipt images or text
- Automatic categorization and amount detection
- Support for multiple receipt formats

### ✈️ **Trip Planning**
- Generate detailed travel itineraries
- Flight, hotel, and car rental recommendations
- Cost analysis and comparison

### 📄 **Document Search**
- PDF document ingestion and processing
- Semantic search through document collections
- Text extraction and indexing

### 🎨 **Modern UI**
- Windows Forms interface with custom markdown viewer
- File attachment support for images and PDFs
- Specialized action buttons for different AI tasks

## 🏗️ Architecture

The application follows a modular architecture with dependency injection:

```
Agent/
├── Agents/              # AI workflow orchestration
├── Configuration/       # Service registration and DI setup
├── Controls/           # Custom UI controls (MarkdownViewer)
├── Models/             # Data models and DTOs
├── Services/           # Core business logic and AI integration
├── Form1.cs/.Designer  # Main UI form
└── Program.cs          # Application entry point
```

### 🔧 **Key Components**

- **Services**: Chat, document ingestion, search, structured extraction
- **Models**: Document, ReceiptData, TripOption, UriAttachment  
- **Agents**: AgentOrchestrator for coordinating AI workflows
- **Controls**: Custom MarkdownViewer for rich text display

## 🚀 Getting Started

### Prerequisites

- .NET 9.0 Windows Desktop Runtime
- Windows operating system (Windows Forms dependency)
- OpenAI API key

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/RobertBergman/csharp_agent.git
   cd csharp_agent
   ```

2. **Configure API settings**
   ```bash
   cp appsettings.sample.json appsettings.json
   ```
   Edit `appsettings.json` and add your OpenAI API key:
   ```json
   {
     "OpenAI": {
       "ApiKey": "your-actual-openai-api-key-here",
       "Model": "gpt-4o-mini"
     }
   }
   ```

3. **Build and run**
   ```bash
   dotnet build
   dotnet run
   ```

## 📦 Dependencies

- **OpenAI**: Official OpenAI .NET client library
- **iText7**: PDF processing and text extraction
- **Markdig**: Markdown parsing and HTML conversion
- **Microsoft.Extensions.***: Dependency injection, configuration, hosting

## 🎯 Usage

### Basic Chat
1. Type your message in the text box
2. Click "Send" or press Enter
3. View AI responses with rich markdown formatting

### Receipt Processing
1. Enter receipt details or attach receipt images
2. Click "Process Receipts"
3. View extracted structured data with categories and amounts

### Trip Planning
1. Describe your travel requirements
2. Click "Plan Trip" 
3. Review generated itinerary options with costs

### Document Search
1. Ingest PDF documents using the document service
2. Enter search queries
3. Click "Search Docs" to find relevant content

## 🔒 Security

- API keys are stored in `appsettings.json` (excluded from git)
- Use `appsettings.sample.json` as a template
- Never commit sensitive configuration files

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 👨‍💻 Authors

**Robert L. Bergman** - *Lead Architect & Principal Developer*
- Project architecture and design
- Core AI integration implementation
- Windows Forms UI development
- System architecture and patterns

## 🙏 Acknowledgments

- Built with [OpenAI's GPT models](https://openai.com/)
- Markdown rendering powered by [Markdig](https://github.com/xoofx/markdig)
- PDF processing using [iText7](https://itextpdf.com/itext-7)

---

🤖 *This project was created with assistance from [Claude Code](https://claude.ai/code)*
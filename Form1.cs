using Agent.Agents;
using Agent.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;

namespace Agent
{
    public partial class Form1 : Form
    {
        private readonly IAgentOrchestrator _agentOrchestrator;
        private readonly List<UriAttachment> _attachments = new();

        public Form1(IAgentOrchestrator agentOrchestrator)
        {
            InitializeComponent();
            _agentOrchestrator = agentOrchestrator;
            UpdateAttachedFilesLabel();
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMessage.Text))
                return;

            var message = txtMessage.Text;
            AppendChatMessage($"**User:** {message}", "user");
            txtMessage.Clear();

            try
            {
                var response = await _agentOrchestrator.ProcessMessageAsync(message, _attachments.Any() ? _attachments : null);
                AppendChatMessage($"**Assistant:** {response}", "assistant");
                
                _attachments.Clear();
                UpdateAttachedFilesLabel();
            }
            catch (Exception ex)
            {
                AppendChatMessage($"**Error:** {ex.Message}", "error");
            }
        }

        private void btnAttachFile_Click(object sender, EventArgs e)
        {
            using var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All files (*.*)|*.*|Images (*.jpg;*.jpeg;*.png;*.gif)|*.jpg;*.jpeg;*.png;*.gif|PDF files (*.pdf)|*.pdf";
            
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var fileName = openFileDialog.FileName;
                var contentType = GetContentType(fileName);
                
                _attachments.Add(new UriAttachment
                {
                    Uri = $"file://{fileName}",
                    ContentType = contentType,
                    FileName = Path.GetFileName(fileName)
                });
                
                UpdateAttachedFilesLabel();
            }
        }

        private async void btnProcessReceipts_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMessage.Text))
            {
                MessageBox.Show("Please enter receipt details or attach receipt images.");
                return;
            }

            try
            {
                var receipts = await _agentOrchestrator.ProcessReceiptsAsync(txtMessage.Text, _attachments.Any() ? _attachments : null);
                
                var receiptMarkdown = $"## Processed {receipts.Count} Receipts\n\n";
                foreach (var receipt in receipts)
                {
                    receiptMarkdown += $"- **{receipt.Description}**: ${receipt.Amount:F2} (*{receipt.Category}*)\n";
                }
                
                AppendChatMessage(receiptMarkdown, "assistant");
                
                txtMessage.Clear();
                _attachments.Clear();
                UpdateAttachedFilesLabel();
            }
            catch (Exception ex)
            {
                AppendChatMessage($"**Error processing receipts:** {ex.Message}", "error");
            }
        }

        private async void btnPlanTrip_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMessage.Text))
            {
                MessageBox.Show("Please enter trip requirements.");
                return;
            }

            try
            {
                var tripOptions = await _agentOrchestrator.PlanTripAsync(txtMessage.Text);
                
                var tripMarkdown = $"## Generated {tripOptions.Count} Trip Options\n\n";
                foreach (var option in tripOptions)
                {
                    tripMarkdown += $"### 🌍 {option.Destination}\n";
                    tripMarkdown += $"📅 **Dates:** {option.DepartureDate:MMM dd} - {option.ReturnDate:MMM dd}\n";
                    tripMarkdown += $"💰 **Total Price:** ${option.TotalPrice:F2}\n\n";
                }
                
                AppendChatMessage(tripMarkdown, "assistant");
                
                txtMessage.Clear();
            }
            catch (Exception ex)
            {
                AppendChatMessage($"**Error planning trip:** {ex.Message}", "error");
            }
        }

        private async void btnSearchDocs_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMessage.Text))
            {
                MessageBox.Show("Please enter search query.");
                return;
            }

            try
            {
                var documents = await _agentOrchestrator.SearchDocumentsAsync(txtMessage.Text);
                
                var docsMarkdown = $"## 📄 Found {documents.Count} Relevant Documents\n\n";
                foreach (var doc in documents)
                {
                    var preview = doc.Text.Substring(0, Math.Min(150, doc.Text.Length));
                    docsMarkdown += $"### 📖 {doc.FileName} (Page {doc.PageNumber})\n";
                    docsMarkdown += $"> {preview}...\n\n";
                }
                
                AppendChatMessage(docsMarkdown, "assistant");
                
                txtMessage.Clear();
            }
            catch (Exception ex)
            {
                AppendChatMessage($"**Error searching documents:** {ex.Message}", "error");
            }
        }

        private void AppendChatMessage(string message, string messageType)
        {
            var styledMessage = messageType switch
            {
                "user" => $"<div class='user-message'>{message}</div>\n\n",
                "assistant" => $"<div class='assistant-message'>{message}</div>\n\n",
                "error" => $"<div class='error-message'>{message}</div>\n\n",
                _ => $"{message}\n\n"
            };

            markdownViewer.AppendMarkdownContent(styledMessage);
        }

        private void UpdateAttachedFilesLabel()
        {
            if (_attachments.Any())
            {
                lblAttachedFiles.Text = $"Attached: {string.Join(", ", _attachments.Select(a => a.FileName))}";
            }
            else
            {
                lblAttachedFiles.Text = "";
            }
        }

        private static string GetContentType(string fileName)
        {
            var extension = Path.GetExtension(fileName).ToLowerInvariant();
            return extension switch
            {
                ".jpg" or ".jpeg" => "image/jpeg",
                ".png" => "image/png",
                ".gif" => "image/gif",
                ".pdf" => "application/pdf",
                ".txt" => "text/plain",
                _ => "application/octet-stream"
            };
        }
    }
}

using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;

using DocumentFormat.OpenXml.Packaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeOpenXml;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace Smart_Asset
{



    public partial class Ai_ChatBot : Form
    {
        private Point firstTypingPosition; // Stores the position when typing starts
        private bool isTypingStarted = false; // Tracks whether typing has started
        private int previousLineCountBeforeFocus; // Stores the line count before losing focus

        private int previousLineCount = 0;
        private const int MaxLines = 30;
        private bool isAdjustingHeight = false;
        private string dbData; // To store the entire file content





        public Ai_ChatBot()
        {
            InitializeComponent();

            // Enable double buffering for the entire form
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.UserPaint |
                          ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();

            // Attach KeyUp event to handle backspace/delete actions
            typeQuestion_Rt.KeyUp += typeQuestion_Rt_KeyUp;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // WS_EX_COMPOSITED
                return cp;
            }
        }

        private async void AiChat_Load(object sender, EventArgs e)
        {
            typeQuestion_Rt.MaxLength = 0; // No character limit
        }



        private void AddBubble(string message, bool isUser)
        {
            int panelWidth = mainFlowLayoutPanel.ClientSize.Width;

            Panel bubble = new Panel
            {
                Padding = new Padding(10),
                Margin = new Padding(5),
                AutoSize = true,
                BackColor = isUser ? Color.LightBlue : Color.LightGray,
                MaximumSize = new Size(panelWidth - 100, 0)
            };

            Label lblMessage = new Label
            {
                Text = message,
                AutoSize = true,
                MaximumSize = new Size(bubble.MaximumSize.Width - 20, 0),
                ForeColor = Color.Black,
                BackColor = Color.Transparent
            };

            bubble.Controls.Add(lblMessage);

            if (isUser)
            {
                bubble.Anchor = AnchorStyles.Right;
                bubble.Location = new Point(panelWidth - bubble.PreferredSize.Width - 20, mainFlowLayoutPanel.Controls.Count * (bubble.Height + 10));
                bubble.Dock = DockStyle.None;
                bubble.Margin = new Padding(panelWidth - bubble.PreferredSize.Width - 40, 5, 10, 5);
            }
            else
            {
                bubble.Anchor = AnchorStyles.Left;
                bubble.Location = new Point(10, mainFlowLayoutPanel.Controls.Count * (bubble.Height + 10));
                bubble.Dock = DockStyle.None;
                bubble.Margin = new Padding(10, 5, panelWidth - bubble.PreferredSize.Width - 40, 5);
            }

            bubble.Paint += (s, e) =>
            {
                using (GraphicsPath path = new GraphicsPath())
                {
                    path.AddArc(0, 0, 20, 20, 180, 90);
                    path.AddArc(bubble.Width - 20, 0, 20, 20, 270, 90);
                    path.AddArc(bubble.Width - 20, bubble.Height - 20, 20, 20, 0, 90);
                    path.AddArc(0, bubble.Height - 20, 20, 20, 90, 90);
                    path.CloseAllFigures();

                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    using (Pen pen = new Pen(Color.DarkGray, 1))
                    {
                        e.Graphics.DrawPath(pen, path);
                    }

                    bubble.Region = new Region(path);
                }
            };

            mainFlowLayoutPanel.Controls.Add(bubble);
            mainFlowLayoutPanel.VerticalScroll.Value = mainFlowLayoutPanel.VerticalScroll.Maximum;
            mainFlowLayoutPanel.AutoScrollPosition = new Point(0, mainFlowLayoutPanel.VerticalScroll.Maximum);
            mainFlowLayoutPanel.PerformLayout();



            // Scroll to the bottom to show the latest added content
            mainFlowLayoutPanel.ScrollControlIntoView(bubble);
        }

        private void AdjustRichTextBoxHeightUpwards(RichTextBox richTextBox)
        {
            if (isAdjustingHeight)
                return;

            isAdjustingHeight = true;

            try
            {
                int lineCount = string.IsNullOrEmpty(richTextBox.Text)
                    ? 1
                    : richTextBox.GetLineFromCharIndex(richTextBox.TextLength) + 1;

                int lineHeight = TextRenderer.MeasureText("A", richTextBox.Font).Height;
                int newHeight = Math.Min(lineCount, MaxLines) * lineHeight + 10;

                if (richTextBox.Height != newHeight || lineCount != previousLineCount)
                {
                    int heightDifference = newHeight - richTextBox.Height;
                    richTextBox.Height = newHeight;
                    richTextBox.Top -= heightDifference;
                    previousLineCount = lineCount;
                    EnsureRichTextBoxOnTop(richTextBox);
                }

                richTextBox.ScrollBars = lineCount >= MaxLines
                    ? RichTextBoxScrollBars.Vertical
                    : RichTextBoxScrollBars.None;

                richTextBox.Focus();
            }
            finally
            {
                isAdjustingHeight = false;
            }
        }

        private void EnsureRichTextBoxOnTop(RichTextBox richTextBox)
        {
            if (richTextBox.Parent != this)
            {
                Point screenLocation = richTextBox.PointToScreen(Point.Empty);
                richTextBox.Parent = this;
                richTextBox.Location = this.PointToClient(screenLocation);
            }

            richTextBox.BringToFront();
        }

        private void typeQuestion_Rt_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
            {
                this.BeginInvoke((MethodInvoker)(() =>
                {
                    AdjustRichTextBoxHeightUpwards(typeQuestion_Rt);
                }));
            }
        }

        private void typeQuestion_Rt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Shift)
            {
                int selectionStart = typeQuestion_Rt.SelectionStart;
                typeQuestion_Rt.Text = typeQuestion_Rt.Text.Insert(selectionStart, Environment.NewLine);
                typeQuestion_Rt.SelectionStart = selectionStart + Environment.NewLine.Length;
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                send_Btn.PerformClick();
            }
            else if (e.Control && e.KeyCode == Keys.V)
            {
                HandlePaste();
            }
        }

        private void HandlePaste()
        {
            this.BeginInvoke((MethodInvoker)(() =>
            {
                AdjustRichTextBoxHeightUpwards(typeQuestion_Rt);
            }));
        }

        private void ResetRichTextBoxHeight(RichTextBox richTextBox)
        {
            int lineHeight = TextRenderer.MeasureText("A", richTextBox.Font).Height;
            int minimalHeight = lineHeight + 10;

            int heightDifference = richTextBox.Height - minimalHeight;
            richTextBox.Height = minimalHeight;
            richTextBox.Top += heightDifference;
        }

        private async void insertFile_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "All Supported Files|*.pdf;*.docx;*.xlsx;*.csv|PDF Files|*.pdf|Word Files|*.docx|Excel Files|*.xlsx|CSV Files|*.csv|All Files|*.*";
                    openFileDialog.Title = "Select a File";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = openFileDialog.FileName;
                        progress_Lbl.Text = "Reading file...";

                        // Read the file content directly
                        string fileContent = await Task.Run(() => ReadFileContent(filePath));

                        if (!string.IsNullOrEmpty(fileContent))
                        {
                            // Add start and end markers to the file content
                            dbData = $"Start of Data:\n{fileContent}\nEnd of Data.";

                            progress_Lbl.Text = "File loaded successfully.";
                            isFileUploaded = true; // Update state
                            MessageBox.Show("File successfully uploaded and processed!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            progress_Lbl.Text = "Failed to read file content.";
                            MessageBox.Show("The selected file could not be read or is empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                progress_Lbl.Text = "Error loading file.";
                MessageBox.Show($"Error reading the file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }






        private string ReadFileContent(string filePath)
        {
            string fileExtension = Path.GetExtension(filePath).ToLower();

            switch (fileExtension)
            {
                case ".pdf":
                    return ReadPdfContent(filePath);
                case ".docx":
                    return ReadWordContent(filePath);
                case ".xlsx":
                    return ReadExcelContent(filePath);
                case ".csv":
                    return ReadCsvContent(filePath);
                default:
                    throw new NotSupportedException($"File type {fileExtension} is not supported.");
            }
        }

        private string ReadPdfContent(string filePath)
        {
            using (var reader = new PdfReader(filePath))
            {
                using (var document = new PdfDocument(reader))
                {
                    StringBuilder content = new StringBuilder();
                    for (int i = 1; i <= document.GetNumberOfPages(); i++)
                    {
                        content.Append(PdfTextExtractor.GetTextFromPage(document.GetPage(i)));
                    }
                    return content.ToString();
                }
            }
        }

        private string ReadWordContent(string filePath)
        {
            using (WordprocessingDocument doc = WordprocessingDocument.Open(filePath, false))
            {
                return doc.MainDocumentPart.Document.Body.InnerText;
            }
        }

        private string ReadExcelContent(string filePath)
        {
            // Set the license context for EPPlus
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var worksheet = package.Workbook.Worksheets[0];
                StringBuilder content = new StringBuilder();
                for (int row = 1; row <= worksheet.Dimension.Rows; row++)
                {
                    for (int col = 1; col <= worksheet.Dimension.Columns; col++)
                    {
                        content.Append(worksheet.Cells[row, col].Text + "\t");
                    }
                    content.AppendLine();
                }
                return content.ToString();
            }
        }

        private string ReadCsvContent(string filePath)
        {
            return File.ReadAllText(filePath);
        }


        private void typeQuestion_Rt_TextChanged(object sender, EventArgs e)
        {
            if (!isTypingStarted)
            {
                // Save the position where the first typing occurred
                firstTypingPosition = typeQuestion_Rt.Location;
                isTypingStarted = true;
            }

            // Adjust the height dynamically
            AdjustRichTextBoxHeightUpwards(typeQuestion_Rt);
        }




        private void AiChat_MouseDown(object sender, MouseEventArgs e)
        {
            base.OnMouseDown(e);

            // Find the control at the clicked location
            Control clickedControl = this.GetChildAtPoint(e.Location);

            if (clickedControl != null)
            {
                MessageBox.Show($"Clicked control: {clickedControl.Name}");
            }
            else
            {
                MessageBox.Show("Clicked outside any control.");


            }

        }




        private void mainFlowLayoutPanel_Click(object sender, EventArgs e)
        {
            ResetRichBoxToNormal();
        }





        void ResetRichBoxToNormal()
        {
            if (previousLineCount >= 30)
            {
                previousLineCount = 20;
                // Save the current value of previousLineCount
                previousLineCountBeforeFocus = previousLineCount;
            }

            // Reset previousLineCount to 0 when RichTextBox loses focus
            previousLineCount = 0;

            // Adjust the height and move it down to simulate minimal size
            ResetRichTextBoxHeight(typeQuestion_Rt);
        }




        private void typeQuestion_Rt_Click(object sender, EventArgs e)
        {
            // Force height adjustment regardless of line count
            previousLineCount = 0;

            // Reapply the height adjustment, even if lineCount >= MaxLines
            AdjustRichTextBoxHeightUpwards(typeQuestion_Rt);
        }






        private void mainFlowLayoutPanel_Resize(object sender, EventArgs e)
        {
            foreach (Control control in mainFlowLayoutPanel.Controls)
            {
                if (control is Panel bubble)
                {
                    // Get the current width of the FlowLayoutPanel
                    int panelWidth = mainFlowLayoutPanel.ClientSize.Width;

                    // Adjust the bubble's maximum size
                    bubble.MaximumSize = new Size(panelWidth - 100, 0);

                    // Adjust the bubble's position
                    if (bubble.BackColor == Color.LightBlue) // User bubble
                    {
                        bubble.Location = new Point(panelWidth - bubble.PreferredSize.Width - 20, bubble.Location.Y);
                        bubble.Margin = new Padding(panelWidth - bubble.PreferredSize.Width - 40, 5, 10, 5);
                    }
                    else // System bubble
                    {
                        bubble.Location = new Point(10, bubble.Location.Y);
                        bubble.Margin = new Padding(10, 5, panelWidth - bubble.PreferredSize.Width - 40, 5);
                    }

                    bubble.Invalidate(); // Redraw the bubble
                }
            }

        }

        private void panel4_Click(object sender, EventArgs e)
        {
            ResetRichBoxToNormal();
        }













        private Dictionary<string, int> ParseCounts(string aiResponse)
        {
            var counts = new Dictionary<string, int>();
            if (string.IsNullOrWhiteSpace(aiResponse)) return counts;

            var lines = aiResponse.Split('\n');
            foreach (var line in lines)
            {
                var parts = line.Split(':');
                if (parts.Length == 2)
                {
                    string type = parts[0].Trim();
                    if (int.TryParse(parts[1].Trim(), out int count))
                    {
                        if (!string.IsNullOrWhiteSpace(type))
                            counts[type] = count;
                    }
                }
            }

            if (counts.Count == 0)
                Console.WriteLine("No valid counts parsed from response: " + aiResponse);

            return counts;
        }








        private void DisplayDataInGridViewFromMarkdown(string markdownTable)
        {
            // Parse markdown table to extract headers and rows
            var lines = markdownTable.Split('\n')
                                     .Where(line => !string.IsNullOrWhiteSpace(line) && line.Contains('|'))
                                     .ToArray();

            if (lines.Length < 2)
                throw new ArgumentException("Invalid markdown table format.");

            // Extract headers
            var headers = lines[0].Split('|', StringSplitOptions.RemoveEmptyEntries)
                                  .Select(h => h.Trim())
                                  .ToArray();

            // Extract rows (skip the separator line with "---")
            var rows = lines.Skip(2)
                            .Select(line => line.Split('|', StringSplitOptions.RemoveEmptyEntries)
                                                .Select(cell => cell.Trim())
                                                .ToArray())
                            .Where(row => row.Length == headers.Length) // Ensure row length matches headers
                            .ToList();

            // Create a new DataGridView
            DataGridView dataGridView = new DataGridView
            {
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToResizeRows = false,
                ScrollBars = ScrollBars.Both, // Enable scrolling
                Margin = new Padding(10),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill // Ensure columns adjust to fill the width
            };

            // Add headers to the DataGridView
            foreach (var header in headers)
            {
                dataGridView.Columns.Add(header, header);
            }

            // Add rows to the DataGridView
            foreach (var row in rows)
            {
                dataGridView.Rows.Add(row);
            }

            // Maximize the DataGridView width to fit within the FlowLayoutPanel
            dataGridView.Width = mainFlowLayoutPanel.ClientSize.Width - 40; // Subtract margins/padding

            // Wrap the DataGridView in a scrollable panel
            Panel containerPanel = new Panel
            {
                AutoScroll = true,
                BorderStyle = BorderStyle.FixedSingle,
                Width = mainFlowLayoutPanel.ClientSize.Width - 20,
                Height = 300, // Fixed height for scrolling
                Margin = new Padding(10)
            };

            containerPanel.Controls.Add(dataGridView);
            mainFlowLayoutPanel.Controls.Add(containerPanel);

            // Scroll to the newly added content
            mainFlowLayoutPanel.VerticalScroll.Value = mainFlowLayoutPanel.VerticalScroll.Maximum;
            mainFlowLayoutPanel.PerformLayout();
        }
















        private bool isFileUploaded = false; // Tracks if a file has been uploaded
        private bool isFirstConversation = true; // Tracks if this is the first conversation
        private bool isTableNeed = false; // Tracks if the user wants to use a table/DataGridView

        // Store all chat history with message numbers
        private List<(int MessageNumber, string UserMessage, string AiResponse)> chatHistory = new List<(int, string, string)>();
        private int messageCounter = 0; // Counter for messages

        private async void send_Btn_Click(object sender, EventArgs e)
        {
            string userText = typeQuestion_Rt.Text.Trim();

            if (!string.IsNullOrWhiteSpace(userText))
            {
                messageCounter++; // Increment message counter
                AddBubble($"[{messageCounter}] {userText}", true); // Display user message with message count

                typeQuestion_Rt.Clear();
                typeQuestion_Rt.ClearUndo();

                await Task.Delay(500);

                try
                {
                    // Combine chat history for context
                    StringBuilder contextBuilder = new StringBuilder();
                    foreach (var (msgNum, userMsg, aiResp) in chatHistory)
                    {
                        contextBuilder.AppendLine($"User: {userMsg}");
                        contextBuilder.AppendLine($"AI: {aiResp}");
                    }
                    contextBuilder.AppendLine($"User: {userText}"); // Add the current user input

                    string fullContext = contextBuilder.ToString();
                    string command = "You are a helpful AI assistant. When the user's input requires a table, " +
                 "provide it in a well-formed markdown table format as follows:\n" +
                 "| Column1 | Column2 | Column3 |\n" +
                 "|---------|---------|---------|\n" +
                 "| Value1  | Value2  | Value3  |\n" +
                 "Ensure all rows have the same number of columns as the header. " +
                 "If a table is not needed, respond directly without using table formatting.";

                    string aiResponse;

                    // Check if a file is uploaded and include its content
                    if (isFileUploaded && !string.IsNullOrEmpty(dbData))
                    {
                        progress_Lbl.Text = "Processing based on uploaded file...";
                        aiResponse = await AiMethods.GetChatResponseWithRetryAsync(
                            model: "gpt-4o-mini",
                            systemMessage: command,
                            userPrompt: $"{fullContext}\n\nFile Data:\n{dbData}",
                            maxTokens: 1500
                        );
                    }
                    else
                    {
                        progress_Lbl.Text = "Processing user input...";
                        aiResponse = await AiMethods.GetChatResponseWithRetryAsync(
                            model: "gpt-4o-mini",
                            systemMessage: command,
                            userPrompt: fullContext,
                            maxTokens: 1500
                        );
                    }

                    // Check if the response contains a table
                    if (aiResponse.Contains('|') && aiResponse.Contains("---"))
                    {
                        isTableNeed = true; // Set table need to true
                        try
                        {
                            DisplayDataInGridViewFromMarkdown(aiResponse); // Display the table
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error parsing table: {ex.Message}", "Parsing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        isTableNeed = false; // Table is not needed
                        AddBubble($"**Response [{messageCounter}]**\n\n{aiResponse.Trim()}", false); // Display response directly
                    }

                    // Save the conversation to history
                    chatHistory.Add((messageCounter, userText, aiResponse));
                }
                catch (Exception ex)
                {
                    progress_Lbl.Text = "Error during processing.";
                    MessageBox.Show($"Error processing your request: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid message.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Ai_ChatBot_Resize(object sender, EventArgs e)
        {
            MyOtherMethods.CenterInPanel(insertFile_Btn, panel6);
        }
    }
}

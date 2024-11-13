using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;
using Newtonsoft.Json;
using System.Xml;
using MigraDoc.Rendering;
using System.Text;
using PdfSharp.Drawing;
using MigraDoc.DocumentObjectModel;

namespace Smart_Asset
{
    public static class Exporter
    {
        private static void ShowWaitMessage()
        {
            MessageBox.Show("Please wait, the file is exporting...", "Export In Progress", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // 1. Export to Excel
        public static async Task ExportDataGridViewToExcel(DataGridView dataGridView, string filePath, bool includeHeaders)
        {
            Excel.Application excelApp = null;
            Excel.Workbook workbook = null;
            Excel.Worksheet worksheet = null;

            try
            {
                Cursor.Current = Cursors.WaitCursor; // Set cursor to wait state

                await Task.Run(() =>
                {
                    excelApp = new Excel.Application { Visible = false, DisplayAlerts = false };
                    workbook = excelApp.Workbooks.Add(Type.Missing);
                    worksheet = (Excel.Worksheet)workbook.Sheets[1];
                    int startRow = 1;

                    if (includeHeaders)
                    {
                        int colIndex = 1;
                        foreach (DataGridViewColumn column in dataGridView.Columns)
                        {
                            if (column.Visible)
                            {
                                worksheet.Cells[startRow, colIndex] = column.HeaderText;
                                colIndex++;
                            }
                        }
                        startRow++;
                    }

                    for (int i = 0; i < dataGridView.Rows.Count; i++)
                    {
                        if (dataGridView.Rows[i].IsNewRow) continue;

                        int colIndex = 1;
                        foreach (DataGridViewColumn column in dataGridView.Columns)
                        {
                            if (column.Visible)
                            {
                                worksheet.Cells[i + startRow, colIndex] = dataGridView.Rows[i].Cells[column.Index].Value?.ToString() ?? string.Empty;
                                colIndex++;
                            }
                        }
                    }

                    workbook.SaveAs(filePath);
                });

                // Show success message after Task completion
                MessageBox.Show("Data exported successfully to Excel!", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting to Excel: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Cleanup Excel resources
                if (worksheet != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
                if (workbook != null)
                {
                    workbook.Close(false);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                }
                if (excelApp != null)
                {
                    excelApp.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
                }

                Cursor.Current = Cursors.Default; // Reset cursor
            }
        }



        // 2. Export to Word
        public static async Task ExportDataGridViewToWord(DataGridView dataGridView, string filePath, bool includeHeaders)
        {
            Word.Application wordApp = null;
            Word.Document document = null;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                await Task.Run(() =>
                {
                    wordApp = new Word.Application { Visible = false };
                    document = wordApp.Documents.Add();
                    int visibleColumnCount = 0;

                    // Count visible columns
                    foreach (DataGridViewColumn column in dataGridView.Columns)
                    {
                        if (column.Visible) visibleColumnCount++;
                    }

                    // Add the table to the Word document
                    Word.Table table = document.Tables.Add(document.Range(0, 0), dataGridView.Rows.Count + (includeHeaders ? 1 : 0), visibleColumnCount);
                    table.Borders.Enable = 1;
                    table.AutoFitBehavior(Word.WdAutoFitBehavior.wdAutoFitContent);

                    // Set default font size
                    table.Range.Font.Size = 8;

                    // Add headers if needed
                    if (includeHeaders)
                    {
                        int colIndex = 1;
                        foreach (DataGridViewColumn column in dataGridView.Columns)
                        {
                            if (column.Visible)
                            {
                                var cell = table.Cell(1, colIndex);
                                cell.Range.Text = column.HeaderText;
                                cell.Range.Font.Bold = 1;
                                cell.Range.Font.Size = 8;
                                cell.Shading.BackgroundPatternColor = Word.WdColor.wdColorGray20;
                                colIndex++;
                            }
                        }
                    }

                    // Add data rows
                    for (int i = 0; i < dataGridView.Rows.Count; i++)
                    {
                        if (dataGridView.Rows[i].IsNewRow) continue;

                        int colIndex = 1;
                        foreach (DataGridViewColumn column in dataGridView.Columns)
                        {
                            if (column.Visible)
                            {
                                var cell = table.Cell(i + (includeHeaders ? 2 : 1), colIndex);
                                cell.Range.Text = dataGridView.Rows[i].Cells[column.Index].Value?.ToString() ?? string.Empty;
                                cell.Range.Font.Size = 8;
                                colIndex++;
                            }
                        }
                    }

                    // Save the Word document
                    document.SaveAs2(filePath);
                });

                MessageBox.Show("Data exported successfully to Word!", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting to Word: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (document != null) document.Close();
                if (wordApp != null) wordApp.Quit();

                Cursor.Current = Cursors.Default;
            }
        }




        // 3. Export to PDF
        public static async Task ExportDataGridViewToPdf(DataGridView dataGridView, string filePath, bool includeHeaders)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                await Task.Run(() =>
                {
                    var document = new Document();
                    var pageWidth = Unit.FromCentimeter(29.7); // A4 landscape width
                    var maxColumnsPerPage = 8; // Maximum columns per page, adjust as needed

                    int totalColumns = dataGridView.Columns.Cast<DataGridViewColumn>().Count(c => c.Visible);
                    int pagesNeeded = (int)Math.Ceiling((double)totalColumns / maxColumnsPerPage);

                    for (int pageIndex = 0; pageIndex < pagesNeeded; pageIndex++)
                    {
                        var section = document.AddSection();
                        section.PageSetup.Orientation = MigraDoc.DocumentObjectModel.Orientation.Landscape;

                        // Set margins to reduce white space
                        section.PageSetup.LeftMargin = Unit.FromCentimeter(1);
                        section.PageSetup.RightMargin = Unit.FromCentimeter(1);

                        // Create a table and align it to the left
                        var table = section.AddTable();
                        table.Borders.Width = 0.5;
                        table.Rows.LeftIndent = 0; // Align table to the left

                        // Define columns and calculate widths for the current page
                        int startColumnIndex = pageIndex * maxColumnsPerPage;
                        int endColumnIndex = Math.Min(startColumnIndex + maxColumnsPerPage, totalColumns);
                        double totalWidth = 0;
                        var columnWidths = new List<Unit>();

                        foreach (DataGridViewColumn column in dataGridView.Columns.Cast<DataGridViewColumn>().Skip(startColumnIndex).Take(endColumnIndex - startColumnIndex))
                        {
                            if (column.Visible)
                            {
                                double maxLength = column.HeaderText.Length;
                                foreach (DataGridViewRow row in dataGridView.Rows)
                                {
                                    if (row.IsNewRow) continue;
                                    var cellValue = row.Cells[column.Index].Value?.ToString() ?? string.Empty;
                                    maxLength = Math.Max(maxLength, cellValue.Length);
                                }

                                var columnWidth = Unit.FromCentimeter(Math.Max(2, maxLength * 0.15));
                                columnWidths.Add(columnWidth);
                                totalWidth += columnWidth.Point;
                            }
                        }

                        // Scale down columns if total width exceeds page width
                        if (totalWidth > pageWidth.Point)
                        {
                            double scaleFactor = pageWidth.Point / totalWidth;
                            for (int i = 0; i < columnWidths.Count; i++)
                            {
                                columnWidths[i] = Unit.FromPoint(columnWidths[i].Point * scaleFactor);
                            }
                        }

                        // Add columns to the table
                        int colIndex = 0;
                        foreach (DataGridViewColumn column in dataGridView.Columns.Cast<DataGridViewColumn>().Skip(startColumnIndex).Take(endColumnIndex - startColumnIndex))
                        {
                            if (column.Visible)
                            {
                                table.AddColumn(columnWidths[colIndex]);
                                colIndex++;
                            }
                        }

                        // Add header row if needed
                        if (includeHeaders)
                        {
                            var headerRow = table.AddRow();
                            headerRow.Shading.Color = Colors.LightGray;
                            headerRow.Format.Font.Bold = true;
                            headerRow.Format.Alignment = ParagraphAlignment.Center;

                            colIndex = 0;
                            foreach (DataGridViewColumn column in dataGridView.Columns.Cast<DataGridViewColumn>().Skip(startColumnIndex).Take(endColumnIndex - startColumnIndex))
                            {
                                if (column.Visible)
                                {
                                    var paragraph = headerRow.Cells[colIndex].AddParagraph(column.HeaderText);
                                    paragraph.Format.Font.Size = 6; // Smaller font size
                                    paragraph.Format.Alignment = ParagraphAlignment.Center;
                                    colIndex++;
                                }
                            }
                        }

                        // Add data rows
                        for (int i = 0; i < dataGridView.Rows.Count; i++)
                        {
                            if (dataGridView.Rows[i].IsNewRow) continue;

                            var row = table.AddRow();
                            colIndex = 0;

                            foreach (DataGridViewColumn column in dataGridView.Columns.Cast<DataGridViewColumn>().Skip(startColumnIndex).Take(endColumnIndex - startColumnIndex))
                            {
                                if (column.Visible)
                                {
                                    string cellValue = dataGridView.Rows[i].Cells[column.Index].Value?.ToString() ?? string.Empty;
                                    var paragraph = row.Cells[colIndex].AddParagraph(cellValue);
                                    paragraph.Format.Font.Size = 6; // Smaller font size
                                    paragraph.Format.Alignment = ParagraphAlignment.Left;
                                    colIndex++;
                                }
                            }
                        }
                    }

                    // Render the MigraDoc document to a PDF
                    var pdfRenderer = new PdfDocumentRenderer(true);
                    pdfRenderer.Document = document;
                    pdfRenderer.RenderDocument();
                    pdfRenderer.PdfDocument.Save(filePath);
                });

                MessageBox.Show("Data exported successfully to PDF!", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting to PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }











        // 4. Export to CSV
        public static async Task ExportDataGridViewToCSV(DataGridView dataGridView, string filePath)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                await Task.Run(() =>
                {
                    using (var writer = new StreamWriter(filePath))
                    {
                        // Write the header row for visible columns only
                        var headers = new List<string>();
                        foreach (DataGridViewColumn column in dataGridView.Columns)
                        {
                            if (column.Visible)
                            {
                                headers.Add(column.HeaderText);
                            }
                        }
                        writer.WriteLine(string.Join(",", headers));

                        // Write the data rows
                        foreach (DataGridViewRow row in dataGridView.Rows)
                        {
                            if (row.IsNewRow) continue;

                            var rowData = new List<string>();
                            foreach (DataGridViewColumn column in dataGridView.Columns)
                            {
                                if (column.Visible)
                                {
                                    // Fetch cell value properly
                                    var cellValue = row.Cells[column.Index].FormattedValue?.ToString() ?? string.Empty;
                                    rowData.Add(EscapeCsvValue(cellValue));
                                }
                            }
                            writer.WriteLine(string.Join(",", rowData));
                        }
                    }
                });

                MessageBox.Show("Data exported successfully to CSV!", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting to CSV: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        // Helper method to handle special CSV characters
        private static string EscapeCsvValue(string value)
        {
            if (string.IsNullOrEmpty(value))
                return string.Empty;

            // Escape quotes and wrap in quotes if necessary
            if (value.Contains(",") || value.Contains("\"") || value.Contains("\n"))
            {
                value = value.Replace("\"", "\"\"");
                return $"\"{value}\"";
            }

            return value;
        }




        // 5. Export to XML
        public static async Task ExportDataGridViewToXML(DataGridView dataGridView, string filePath)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                await Task.Run(() =>
                {
                    DataTable dt = new DataTable("Data");
                    foreach (DataGridViewColumn column in dataGridView.Columns)
                    {
                        if (column.Visible)
                        {
                            dt.Columns.Add(column.HeaderText);
                        }
                    }

                    foreach (DataGridViewRow row in dataGridView.Rows)
                    {
                        if (row.IsNewRow) continue;

                        DataRow dr = dt.NewRow();
                        int colIndex = 0;
                        foreach (DataGridViewColumn column in dataGridView.Columns)
                        {
                            if (column.Visible)
                            {
                                dr[colIndex] = row.Cells[column.Index].Value ?? string.Empty;
                                colIndex++;
                            }
                        }
                        dt.Rows.Add(dr);
                    }

                    dt.WriteXml(filePath);
                });

                MessageBox.Show("Data exported successfully to XML!", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting to XML: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }



        // 6. Export to JSON
        public static async Task ExportDataGridViewToJSON(DataGridView dataGridView, string filePath)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                await Task.Run(() =>
                {
                    var rows = new List<Dictionary<string, object>>();
                    foreach (DataGridViewRow row in dataGridView.Rows)
                    {
                        if (row.IsNewRow) continue;

                        var rowData = new Dictionary<string, object>();
                        foreach (DataGridViewColumn column in dataGridView.Columns)
                        {
                            if (column.Visible)
                            {
                                rowData[column.HeaderText] = row.Cells[column.Index].Value ?? string.Empty;
                            }
                        }
                        rows.Add(rowData);
                    }

                    File.WriteAllText(filePath, JsonConvert.SerializeObject(rows, Newtonsoft.Json.Formatting.Indented));
                });

                MessageBox.Show("Data exported successfully to JSON!", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting to JSON: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }




        // 7. Export to HTML
        public static async Task ExportDataGridViewToHTML(DataGridView dataGridView, string filePath)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                await Task.Run(() =>
                {
                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        writer.WriteLine("<html><body><table border='1'>");

                        writer.WriteLine("<tr>");
                        foreach (DataGridViewColumn column in dataGridView.Columns)
                        {
                            if (column.Visible)
                            {
                                writer.WriteLine($"<th>{column.HeaderText}</th>");
                            }
                        }
                        writer.WriteLine("</tr>");

                        foreach (DataGridViewRow row in dataGridView.Rows)
                        {
                            if (row.IsNewRow) continue;

                            writer.WriteLine("<tr>");
                            foreach (DataGridViewColumn column in dataGridView.Columns)
                            {
                                if (column.Visible)
                                {
                                    writer.WriteLine($"<td>{row.Cells[column.Index].Value?.ToString() ?? string.Empty}</td>");
                                }
                            }
                            writer.WriteLine("</tr>");
                        }

                        writer.WriteLine("</table></body></html>");
                    }
                });

                MessageBox.Show("Data exported successfully to HTML!", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting to HTML: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }




        // 8. Export to TXT
        public static async Task ExportDataGridViewToTXT(DataGridView dataGridView, string filePath)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                await Task.Run(() =>
                {
                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        foreach (DataGridViewColumn column in dataGridView.Columns)
                        {
                            if (column.Visible)
                            {
                                writer.Write($"{column.HeaderText}\t");
                            }
                        }
                        writer.WriteLine();

                        foreach (DataGridViewRow row in dataGridView.Rows)
                        {
                            if (row.IsNewRow) continue;

                            foreach (DataGridViewColumn column in dataGridView.Columns)
                            {
                                if (column.Visible)
                                {
                                    writer.Write($"{row.Cells[column.Index].Value?.ToString() ?? string.Empty}\t");
                                }
                            }
                            writer.WriteLine();
                        }
                    }
                });

                MessageBox.Show("Data exported successfully to TXT!", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting to TXT: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }


    }
}
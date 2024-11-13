using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;
using Newtonsoft.Json;
using MigraDoc.Rendering;
using MigraDoc.DocumentObjectModel;
using PdfSharp.Drawing;

namespace Smart_Asset
{
    public static class Exporter
    {
        private static void ReleaseComObject(object obj)
        {
            if (obj != null && Marshal.IsComObject(obj))
            {
                Marshal.FinalReleaseComObject(obj);
            }
        }

        // 1. Export to Excel
        public static async Task ExportDataGridViewToExcel(DataGridView dataGridView, string filePath, bool includeHeaders)
        {
            Excel.Application excelApp = null;
            Excel.Workbook workbook = null;
            Excel.Worksheet worksheet = null;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                await Task.Run(() =>
                {
                    excelApp = new Excel.Application { Visible = false, DisplayAlerts = false };
                    workbook = excelApp.Workbooks.Add(Type.Missing);
                    worksheet = workbook.Sheets[1];

                    int startRow = 1;
                    if (includeHeaders)
                    {
                        int colIndex = 1;
                        foreach (DataGridViewColumn column in dataGridView.Columns)
                        {
                            if (column.Visible)
                            {
                                worksheet.Cells[startRow, colIndex++] = column.HeaderText;
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
                                worksheet.Cells[i + startRow, colIndex++] = dataGridView.Rows[i].Cells[column.Index].Value?.ToString() ?? string.Empty;
                            }
                        }
                    }

                    workbook.SaveAs(filePath);
                });

                MessageBox.Show("Data exported successfully to Excel!", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                ReleaseComObject(worksheet);
                workbook?.Close(false);
                ReleaseComObject(workbook);
                excelApp?.Quit();
                ReleaseComObject(excelApp);

                GC.Collect();
                GC.WaitForPendingFinalizers();
                Cursor.Current = Cursors.Default;
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
                    foreach (DataGridViewColumn column in dataGridView.Columns)
                    {
                        if (column.Visible) visibleColumnCount++;
                    }

                    Word.Table table = document.Tables.Add(document.Range(0, 0), dataGridView.Rows.Count + (includeHeaders ? 1 : 0), visibleColumnCount);
                    table.Borders.Enable = 1;
                    table.Range.Font.Size = 8;

                    if (includeHeaders)
                    {
                        int colIndex = 1;
                        foreach (DataGridViewColumn column in dataGridView.Columns)
                        {
                            if (column.Visible)
                            {
                                table.Cell(1, colIndex++).Range.Text = column.HeaderText;
                            }
                        }
                    }

                    for (int i = 0; i < dataGridView.Rows.Count; i++)
                    {
                        if (dataGridView.Rows[i].IsNewRow) continue;

                        int colIndex = 1;
                        foreach (DataGridViewColumn column in dataGridView.Columns)
                        {
                            if (column.Visible)
                            {
                                table.Cell(i + (includeHeaders ? 2 : 1), colIndex++).Range.Text =
                                    dataGridView.Rows[i].Cells[column.Index].Value?.ToString() ?? string.Empty;
                            }
                        }
                    }

                    document.SaveAs2(filePath);
                });

                MessageBox.Show("Data exported successfully to Word!", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                document?.Close();
                wordApp?.Quit();
                ReleaseComObject(document);
                ReleaseComObject(wordApp);

                GC.Collect();
                GC.WaitForPendingFinalizers();
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
                    var section = document.AddSection();

                    var table = section.AddTable();
                    table.Borders.Width = 0.5;

                    // Keep track of the visible columns
                    var visibleColumns = new List<DataGridViewColumn>();
                    foreach (DataGridViewColumn column in dataGridView.Columns)
                    {
                        if (column.Visible)
                        {
                            table.AddColumn(Unit.FromCentimeter(3));
                            visibleColumns.Add(column);
                        }
                    }

                    // Add header row if needed
                    if (includeHeaders)
                    {
                        var headerRow = table.AddRow();
                        headerRow.Shading.Color = Colors.LightGray;
                        int colIndex = 0;

                        foreach (var column in visibleColumns)
                        {
                            headerRow.Cells[colIndex].AddParagraph(column.HeaderText);
                            colIndex++;
                        }
                    }

                    // Add data rows
                    foreach (DataGridViewRow row in dataGridView.Rows)
                    {
                        // Skip hidden rows
                        if (row.IsNewRow || !row.Visible) continue;

                        var dataRow = table.AddRow();
                        int colIndex = 0;

                        foreach (var column in visibleColumns)
                        {
                            string cellValue = row.Cells[column.Index].Value?.ToString() ?? string.Empty;
                            dataRow.Cells[colIndex].AddParagraph(cellValue);
                            colIndex++;
                        }
                    }

                    // Render the MigraDoc document to a PDF
                    var renderer = new PdfDocumentRenderer(true);
                    renderer.Document = document;
                    renderer.RenderDocument();
                    renderer.PdfDocument.Save(filePath);
                });

                MessageBox.Show("Data exported successfully to PDF!", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during export: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
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
                        var headers = new List<string>();
                        foreach (DataGridViewColumn column in dataGridView.Columns)
                        {
                            if (column.Visible) headers.Add(column.HeaderText);
                        }
                        writer.WriteLine(string.Join(",", headers));

                        foreach (DataGridViewRow row in dataGridView.Rows)
                        {
                            if (row.IsNewRow) continue;

                            var rowData = new List<string>();
                            foreach (DataGridViewColumn column in dataGridView.Columns)
                            {
                                if (column.Visible)
                                {
                                    rowData.Add(row.Cells[column.Index].Value?.ToString()?.Replace(",", " ") ?? string.Empty);
                                }
                            }
                            writer.WriteLine(string.Join(",", rowData));
                        }
                    }
                });

                MessageBox.Show("Data exported successfully to CSV!", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                Cursor.Current = Cursors.Default;
            }
        }

        // 5. Export to XML
        public static async Task ExportDataGridViewToXML(DataGridView dataGridView, string filePath)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                await Task.Run(() =>
                {
                    DataTable dataTable = new DataTable("Data");

                    // Add columns
                    foreach (DataGridViewColumn column in dataGridView.Columns)
                    {
                        if (column.Visible)
                        {
                            dataTable.Columns.Add(column.HeaderText);
                        }
                    }

                    // Add rows
                    foreach (DataGridViewRow row in dataGridView.Rows)
                    {
                        if (row.IsNewRow) continue;

                        DataRow dataRow = dataTable.NewRow();
                        int colIndex = 0;
                        foreach (DataGridViewColumn column in dataGridView.Columns)
                        {
                            if (column.Visible)
                            {
                                dataRow[colIndex++] = row.Cells[column.Index].Value ?? string.Empty;
                            }
                        }
                        dataTable.Rows.Add(dataRow);
                    }

                    // Write XML file
                    using (var writer = new StreamWriter(filePath, false, Encoding.UTF8))
                    {
                        dataTable.WriteXml(writer, XmlWriteMode.WriteSchema);
                    }
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
                GC.Collect();
                GC.WaitForPendingFinalizers();
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

                    // Write JSON file
                    var json = JsonConvert.SerializeObject(rows, Formatting.Indented);
                    File.WriteAllText(filePath, json, Encoding.UTF8);
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
                GC.Collect();
                GC.WaitForPendingFinalizers();
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
                    var sb = new StringBuilder();
                    sb.AppendLine("<html><body><table border='1'>");

                    // Add header row
                    sb.AppendLine("<tr>");
                    foreach (DataGridViewColumn column in dataGridView.Columns)
                    {
                        if (column.Visible)
                        {
                            sb.AppendLine($"<th>{column.HeaderText}</th>");
                        }
                    }
                    sb.AppendLine("</tr>");

                    // Add data rows
                    foreach (DataGridViewRow row in dataGridView.Rows)
                    {
                        if (row.IsNewRow) continue;

                        sb.AppendLine("<tr>");
                        foreach (DataGridViewColumn column in dataGridView.Columns)
                        {
                            if (column.Visible)
                            {
                                string cellValue = row.Cells[column.Index].Value?.ToString() ?? string.Empty;
                                sb.AppendLine($"<td>{System.Net.WebUtility.HtmlEncode(cellValue)}</td>");
                            }
                        }
                        sb.AppendLine("</tr>");
                    }

                    sb.AppendLine("</table></body></html>");

                    // Write HTML file
                    File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
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
                GC.Collect();
                GC.WaitForPendingFinalizers();
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
                    var sb = new StringBuilder();

                    // Add headers
                    foreach (DataGridViewColumn column in dataGridView.Columns)
                    {
                        if (column.Visible)
                        {
                            sb.Append($"{column.HeaderText}\t");
                        }
                    }
                    sb.AppendLine();

                    // Add rows
                    foreach (DataGridViewRow row in dataGridView.Rows)
                    {
                        if (row.IsNewRow) continue;

                        foreach (DataGridViewColumn column in dataGridView.Columns)
                        {
                            if (column.Visible)
                            {
                                string cellValue = row.Cells[column.Index].Value?.ToString() ?? string.Empty;
                                sb.Append($"{cellValue}\t");
                            }
                        }
                        sb.AppendLine();
                    }

                    // Write TXT file
                    File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
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
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }
    }
}



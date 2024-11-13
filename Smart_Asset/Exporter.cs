using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Newtonsoft.Json;
using System.Xml;

namespace Smart_Asset
{
    public static class Exporter
    {
        private static void ShowWaitMessage()
        {
            MessageBox.Show("Please wait, the file is exporting...", "Export In Progress", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // 1. Export to Excel
        public static async void ExportDataGridViewToExcel(DataGridView dataGridView, string filePath, bool includeHeaders)
        {
            Excel.Application excelApp = null;
            Excel.Workbook workbook = null;
            Excel.Worksheet worksheet = null;

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                await Task.Run(() => ShowWaitMessage());

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
                MessageBox.Show("Data exported successfully to Excel!", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting to Excel: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
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

                Cursor.Current = Cursors.Default;
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }

        // 2. Export to Word
        public static async void ExportDataGridViewToWord(DataGridView dataGridView, string filePath, bool includeHeaders)
        {
            Word.Application wordApp = null;
            Word.Document document = null;

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                await Task.Run(() => ShowWaitMessage());

                wordApp = new Word.Application { Visible = false };
                document = wordApp.Documents.Add();
                int visibleColumnCount = 0;

                foreach (DataGridViewColumn column in dataGridView.Columns)
                {
                    if (column.Visible) visibleColumnCount++;
                }

                Word.Table table = document.Tables.Add(document.Range(0, 0), dataGridView.Rows.Count + (includeHeaders ? 1 : 0), visibleColumnCount);
                table.Borders.Enable = 1;

                if (includeHeaders)
                {
                    int colIndex = 1;
                    foreach (DataGridViewColumn column in dataGridView.Columns)
                    {
                        if (column.Visible)
                        {
                            table.Cell(1, colIndex).Range.Text = column.HeaderText;
                            colIndex++;
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
                            table.Cell(i + (includeHeaders ? 2 : 1), colIndex).Range.Text = dataGridView.Rows[i].Cells[column.Index].Value?.ToString() ?? string.Empty;
                            colIndex++;
                        }
                    }
                }

                document.SaveAs2(filePath);
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
        public static async void ExportDataGridViewToPDF(DataGridView dataGridView, string filePath)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                await Task.Run(() => ShowWaitMessage());

                using (var stream = new FileStream(filePath, FileMode.Create))
                using (var pdfDoc = new Document(PageSize.A4))
                {
                    PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();
                    var pdfTable = new PdfPTable(dataGridView.Columns.Count);

                    foreach (DataGridViewColumn column in dataGridView.Columns)
                    {
                        if (column.Visible)
                        {
                            pdfTable.AddCell(new Phrase(column.HeaderText));
                        }
                    }

                    foreach (DataGridViewRow row in dataGridView.Rows)
                    {
                        if (row.IsNewRow) continue;

                        foreach (DataGridViewColumn column in dataGridView.Columns)
                        {
                            if (column.Visible)
                            {
                                pdfTable.AddCell(row.Cells[column.Index].Value?.ToString() ?? string.Empty);
                            }
                        }
                    }

                    pdfDoc.Add(pdfTable);
                }

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
        public static async void ExportDataGridViewToCSV(DataGridView dataGridView, string filePath)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                await Task.Run(() => ShowWaitMessage());

                using (var writer = new StreamWriter(filePath))
                {
                    foreach (DataGridViewColumn column in dataGridView.Columns)
                    {
                        if (column.Visible)
                        {
                            writer.Write(column.HeaderText + ",");
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
                                writer.Write(row.Cells[column.Index].Value?.ToString() ?? string.Empty + ",");
                            }
                        }
                        writer.WriteLine();
                    }
                }

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

        // 5. Export to XML
        public static async void ExportDataGridViewToXML(DataGridView dataGridView, string filePath)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                await Task.Run(() => ShowWaitMessage());

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
        public static async void ExportDataGridViewToJSON(DataGridView dataGridView, string filePath)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                await Task.Run(() => ShowWaitMessage());

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
        public static async void ExportDataGridViewToHTML(DataGridView dataGridView, string filePath)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                await Task.Run(() => ShowWaitMessage());

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine("<html><body><table border='1'>");

                    // Write headers
                    writer.WriteLine("<tr>");
                    foreach (DataGridViewColumn column in dataGridView.Columns)
                    {
                        if (column.Visible)
                        {
                            writer.WriteLine($"<th>{column.HeaderText}</th>");
                        }
                    }
                    writer.WriteLine("</tr>");

                    // Write data rows
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
        public static async void ExportDataGridViewToTXT(DataGridView dataGridView, string filePath)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                await Task.Run(() => ShowWaitMessage());

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    // Write headers
                    foreach (DataGridViewColumn column in dataGridView.Columns)
                    {
                        if (column.Visible)
                        {
                            writer.Write($"{column.HeaderText}\t");
                        }
                    }
                    writer.WriteLine();

                    // Write data rows
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
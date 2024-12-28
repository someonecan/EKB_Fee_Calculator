using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace EKB_Fee_Calculator
{
    public partial class Form1 : Form
    {
        private decimal referenceValue = 1m; // Default reference value
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLoadExcel_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Excel Files|*.xlsx;*.xls";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    ProcessExcel(filePath);
                }
            }
        }
        private void ProcessExcel(string filePath)
        {
            try
            {
                using (var workbook = new XLWorkbook(filePath))
                {
                    var worksheet = workbook.Worksheets.FirstOrDefault();
                    if (worksheet == null)
                    {
                        MessageBox.Show("Excel file does not contain any worksheets.");
                        return;
                    }

                    int rowCount = worksheet.RowsUsed().Count();
                    decimal totalAmount = 0;

                    // Add a new column for calculated fees
                    int newColumnIndex = worksheet.LastColumnUsed().ColumnNumber() + 1;
                    worksheet.Cell(1, newColumnIndex).Value = "Calculated Fee";

                    for (int row = 2; row <= rowCount; row++)
                    {
                        var cellValue = worksheet.Cell(row, 2).Value;

                        if (decimal.TryParse(cellValue.ToString(), out decimal area))
                        {
                            // Geçerli bir sayıysa, hesaplama yapmaya devam edin
                        }
                        else
                        {
                            // Hatalı veri durumunda bir işlem yapın (örn. uyarı mesajı gösterin veya varsayılan değer atayın)
                            area = 0;
                        }
                        decimal fee = CalculateFee(area);
                        worksheet.Cell(row, newColumnIndex).Value = fee;
                        totalAmount += fee;
                    }

                    lblTotalAmount.Text = $"Total Amount: {totalAmount:C}";

                    // Save the modified file
                    SaveExcel(workbook, filePath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private decimal CalculateFee(decimal area)
        {
            decimal fee = 0;

            if (area > 50000) { fee += (area - 50000) * 0.01m * referenceValue; area = 50000; }
            if (area > 10000) { fee += (area - 10000) * 0.02m * referenceValue; area = 10000; }
            if (area > 5000) { fee += (area - 5000) * 0.03m * referenceValue; area = 5000; }
            if (area > 2000) { fee += (area - 2000) * 0.04m * referenceValue; area = 2000; }
            if (area > 1000) { fee += (area - 1000) * 0.05m * referenceValue; area = 1000; }
            if (area > 500) { fee += (area - 500) * 0.1m * referenceValue; area = 500; }
            if (area > 250) { fee += (area - 250) * 0.15m * referenceValue; area = 250; }
            fee += area * 0.3m * referenceValue;

            return Math.Round(fee, 2);
        }

        private void SaveExcel(XLWorkbook workbook,string originalFilePath)
        {
            string directory = Path.GetDirectoryName(originalFilePath);
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(originalFilePath);
            string extension = Path.GetExtension(originalFilePath);

            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string newFileName = Path.Combine(directory, $"{fileNameWithoutExtension}_Modified_{timestamp}{extension}");

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel Files|*.xlsx";
                saveFileDialog.FileName = newFileName;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    workbook.SaveAs(saveFileDialog.FileName);
                    MessageBox.Show("File saved successfully.");
                }
            }
        }

        private void btnSetReferenceValue_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtReferenceValue.Text, out decimal newReferenceValue))
            {
                referenceValue = newReferenceValue;
                MessageBox.Show($"Reference value updated to {referenceValue:C}");
            }
            else
            {
                MessageBox.Show("Please enter a valid number for the reference value.");
            }
        }
    }
}

using Assignment_2.Models;
using Assignment_2.ViewModels.Interfaces;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Assignment_2.ViewModels.HelperClasses
{
    class PDFFile : IFile
    {
        private const string _format = "Pdf Files|*.pdf";
        private SaveFileDialog _saveFileDialog;
        private IEnumerable<Ad> _result;

        public PDFFile(IEnumerable<Ad> result)
        {
            _saveFileDialog = new SaveFileDialog();
            _saveFileDialog.Filter = _format;
            _result = result;
        }
        public void GenerateReport()
        {
            var tb = ToDataTable<Ad>(_result.ToList());

            if (_saveFileDialog.ShowDialog() == true)
            {
                using (FileStream stream = new FileStream(_saveFileDialog.FileName, FileMode.Create))
                {
                    Document pdf = new Document(PageSize.A1, 10f, 10f, 10f, 0f);
                    PdfWriter.GetInstance(pdf, stream);
                    pdf.Open();
                    pdf.Add(ToPdfTable(tb));
                    pdf.Close();
                    stream.Close();
                }
            }
        }

        public static DataTable ToDataTable<T>(List<T> items)
        {
            var tb = new DataTable(typeof(T).Name);

            PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var prop in props)
            {
                tb.Columns.Add(prop.Name, prop.PropertyType);
            }

            foreach (var item in items)
            {
                var values = new object[props.Length];
                for (var i = 0; i < props.Length; i++)
                {
                    values[i] = props[i].GetValue(item, null);
                }

                tb.Rows.Add(values);
            }

            return tb;
        }

        public static PdfPTable ToPdfTable(DataTable dataTable)
        {
            PdfPTable table = new PdfPTable(dataTable.Columns.Count);
            table.WidthPercentage = 100;

            for (int k = 0; k < dataTable.Columns.Count; k++)
            {
                PdfPCell cell = new PdfPCell(new Phrase(dataTable.Columns[k].ColumnName));

                cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cell.VerticalAlignment = PdfPCell.ALIGN_CENTER;
                cell.BackgroundColor = new iTextSharp.text.BaseColor(51, 102, 102);

                table.AddCell(cell);
            }

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                for (int j = 0; j < dataTable.Columns.Count; j++)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(dataTable.Rows[i][j].ToString()));

                    cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    cell.VerticalAlignment = PdfPCell.ALIGN_CENTER;

                    table.AddCell(cell);
                }
            }

            return table;
        }
    }
}

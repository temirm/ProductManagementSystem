using ClosedXML.Excel;
using ProductManagementSystem.Core.Entities;
using ProductManagementSystem.Core.Interfaces;

namespace ProductManagementSystem.Infrastructure;

public class ExcelParser : IExcelParser
{
    private const string NAME_COLUMN = "Наименование";
    private const string UNIT_NAME_COLUMN = "Единица измерения";
    private const string UNIT_PRICE_COLUMN = "Цена за единицу, евро";
    private const string UNIT_NUMBER_COLUMN = "Количество, шт.";

    private readonly ExcelValidator validator;

    public ExcelParser()
    {
        validator = new ExcelValidator();
    }

    public IEnumerable<Product> ParseProductData(string fileName)
    {
        using XLWorkbook workBook = new(fileName);
        
        var workSheet = workBook.Worksheets.First();

        var table = workSheet.RangeUsed().AsTable();

        validator.ValidateTable(table);

        return table
            .DataRange
            .Rows()
            .Select(ParseProductFromTableRow)
            .ToList();
    }

    private Product ParseProductFromTableRow(IXLTableRow row)
    {
        string name = row.Field(NAME_COLUMN).GetText();
        string unitName = row.Field(UNIT_NAME_COLUMN).GetText();
        double unitPrice = row.Field(UNIT_PRICE_COLUMN).GetDouble();
        int unitNumber = Convert.ToInt32(row.Field(UNIT_NUMBER_COLUMN).GetDouble());

        return new Product(name, unitName, unitPrice, unitNumber);
    }

    private class ExcelValidator
    {
        internal void ValidateTable(IXLTable table)
        {
            // TODO: Add unit tests for the following cases
            var columns = table.Fields;
            ThrowIf(columns.Count() != 4, $"The table is expected to have four columns, {columns.Count()} were found.");           

            var nameColumn = columns.FirstOrDefault(c => c.Name == NAME_COLUMN);
            var unitNameColumn = columns.FirstOrDefault(c => c.Name == UNIT_NAME_COLUMN);
            var unitPriceColumn = columns.FirstOrDefault(c => c.Name == UNIT_PRICE_COLUMN);
            var unitNumberColumn = columns.FirstOrDefault(c => c.Name == UNIT_NUMBER_COLUMN);
            
            ThrowIf(nameColumn is null, $"\"{NAME_COLUMN}\" column was not found.");
            ThrowIf(unitNameColumn is null, $"\"{UNIT_NAME_COLUMN}\" column was not found.");
            ThrowIf(unitPriceColumn is null, $"\"{UNIT_PRICE_COLUMN}\" column was not found.");
            ThrowIf(unitNumberColumn is null, $"\"{UNIT_NUMBER_COLUMN}\" column was not found.");

            ThrowIf(!nameColumn!.IsConsistentDataType(), $"\"{NAME_COLUMN}\" column has inconsistent data.");
            ThrowIf(!unitNameColumn!.IsConsistentDataType(), $"\"{UNIT_NAME_COLUMN}\" column has inconsistent data.");
            ThrowIf(!unitPriceColumn!.IsConsistentDataType(), $"\"{UNIT_PRICE_COLUMN}\" column has inconsistent data.");
            ThrowIf(!unitNumberColumn!.IsConsistentDataType(), $"\"{UNIT_NUMBER_COLUMN}\" column has inconsistent data.");

            ThrowIf(
                nameColumn.DataCells.First().DataType != XLDataType.Text,
                $"\"{NAME_COLUMN}\" column contains non-text data.");
            ThrowIf(
                unitNameColumn.DataCells.First().DataType != XLDataType.Text,
                $"\"{UNIT_NAME_COLUMN}\" column contains non-text data.");
            ThrowIf(
                unitPriceColumn.DataCells.First().DataType != XLDataType.Number,
                $"\"{UNIT_PRICE_COLUMN}\" column contains non-number data.");
            ThrowIf(
                unitNumberColumn.DataCells.First().DataType != XLDataType.Number,
                $"\"{UNIT_NUMBER_COLUMN}\" column contains non-number data.");
        }

        private void ThrowIf(bool condition, string reason)
        {
            if (condition)
            {
                throw new Exception(reason); // TODO: Use custom exception
            }
        }
    }
}

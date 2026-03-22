namespace OpticsShop.Services.Printer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class AsciiTable
    {
        private readonly List<string> _headers = new();
        private readonly List<List<string>> _rows = new();
        private readonly Dictionary<int, int> _maxColumnWidths = new();

        public string? Title { get; set; }

        public AsciiTable AddColumn(string header, int? maxWidth = null)
        {
            _headers.Add(header);
            if (maxWidth.HasValue)
            {
                _maxColumnWidths[_headers.Count - 1] = maxWidth.Value;
            }
            return this;
        }

        public AsciiTable AddRow(params object[] values)
        {
            var row = values.Select(v => v?.ToString() ?? string.Empty).ToList();
            _rows.Add(row);
            return this;
        }

        public void Write()
        {
            if (_headers.Count == 0)
            {
                Console.WriteLine("(Няма дефинирани колони)");
                return;
            }

            var widths = CalculateColumnWidths();
            int tableWidth = GetTableWidth(widths);

            // Title
            if (!string.IsNullOrEmpty(Title))
            {
                WriteBorder(widths);

                Console.Write("| ");
                Console.Write(CenterText(Title, tableWidth - 4));
                Console.WriteLine(" |");

                WriteBorder(widths);
            }


            WriteBorder(widths);
            WriteRow(_headers, widths, isHeader: true);
            WriteBorder(widths);

            foreach (var row in _rows)
            {
                var normalized = NormalizeRow(row);
                WriteRow(normalized, widths, isHeader: false);
            }

            WriteBorder(widths);
        }

        private List<string> NormalizeRow(List<string> row)
        {
            var result = new List<string>();

            for (int i = 0; i < _headers.Count; i++)
            {
                var value = i < row.Count ? row[i] : string.Empty;
                result.Add(value);
            }

            return result;
        }

        private int[] CalculateColumnWidths()
        {
            var widths = new int[_headers.Count];

            for (int col = 0; col < _headers.Count; col++)
            {
                int max = _headers[col].Length;

                foreach (var row in _rows)
                {
                    var value = col < row.Count ? row[col] : string.Empty;
                    max = Math.Max(max, value.Length);
                }

                if (_maxColumnWidths.TryGetValue(col, out int limit))
                {
                    max = Math.Min(max, limit);
                }

                widths[col] = max;
            }

            return widths;
        }

        private void WriteBorder(int[] widths)
        {
            Console.Write("+");
            foreach (var width in widths)
            {
                Console.Write(new string('-', width + 2));
                Console.Write("+");
            }
            Console.WriteLine();
        }

        private void WriteRow(List<string> row, int[] widths, bool isHeader)
        {
            Console.Write("|");

            for (int i = 0; i < widths.Length; i++)
            {
                var value = row[i] ?? string.Empty;
                value = Truncate(value, widths[i]);

                Console.Write(" ");
                Console.Write(value.PadRight(widths[i]));
                Console.Write(" |");
            }

            Console.WriteLine();
        }

        private int GetTableWidth(int[] widths)
        {
            // +1 за всяка вертикална граница + padding
            return widths.Sum(w => w + 3) + 1;
        }

        private string CenterText(string text, int width)
        {
            if (text.Length >= width)
                return text[..width];

            int padding = width - text.Length;
            int padLeft = padding / 2 + text.Length;

            return text.PadLeft(padLeft).PadRight(width);
        }

        private string Truncate(string value, int width)
        {
            if (value.Length <= width)
                return value;

            if (width <= 3)
                return value[..width];

            return value[..(width - 3)] + "...";
        }
    }
}

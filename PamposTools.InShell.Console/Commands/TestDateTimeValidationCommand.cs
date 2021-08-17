using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace PamposTools.InShell.Console
{
    public class TestDateTimeValidationCommand : ICommand
    {
        const string DATE_DMY = "ddMMyyyy";
        const string DATE_DMY_FS = "dd/MM/yyyy";
        const string DATE_YMD = "yyyyMMdd";
        const string DATE_YMD_FS = "yyyy/MM/dd";

        const string TIME = "HHmmss";
        const string TIME_C = "HH:mm:ss";


        public void Execute() {

            var formats = new SupportedDateTimeFormats(new string[] { DATE_DMY, DATE_DMY_FS });

            DateTime dateTime = InputHelper.GetDateTime("Give me a date: ", formats.Default);
            PrintHelper.PrintLine($"{FormatDateTime(dateTime, DATE_DMY_FS)}? Good answer!", LogLevel.Success);

            formats.SetDefault(DATE_DMY_FS);
            dateTime = InputHelper.GetDateTime("Give me a date: ", formats.ToArray());
            PrintHelper.PrintLine($"{FormatDateTime(dateTime, DATE_DMY_FS)}? Good answer!", LogLevel.Success);

            DateTime startDate = new DateTime(DateTime.Today.Year, 1, 1);
            DateTime endDate = DateTime.Today;
            dateTime = InputHelper.GetDateTime($"Give me a date between {FormatDateTime(startDate, DATE_DMY_FS)} and {FormatDateTime(endDate, DATE_DMY_FS)}: ", startDate, endDate, formats.Default);
            PrintHelper.PrintLine($"Your date/time is: {FormatDateTime(dateTime, DATE_DMY_FS)}.", LogLevel.Success);

            dateTime = InputHelper.GetDateTime($"Give me a date between {FormatDateTime(startDate, DATE_DMY_FS)} and {FormatDateTime(endDate, DATE_DMY_FS)}: ", startDate, endDate, formats.ToArray());
            PrintHelper.PrintLine($"Your date/time is: {FormatDateTime(dateTime, DATE_DMY_FS)}.", LogLevel.Success);

            startDate = new DateTime();
            endDate = DateTime.Now;
            formats = new SupportedDateTimeFormats(new string[] { TIME_C, TIME });
            dateTime = InputHelper.GetDateTime($"Give me a time between {FormatDateTime(startDate, TIME_C)} and {FormatDateTime(endDate, TIME_C)}: ", startDate, endDate, formats.ToArray());
            PrintHelper.PrintLine($"Your time is: {FormatDateTime(dateTime, TIME_C)}.", LogLevel.Success);

            formats = new SupportedDateTimeFormats(new string[] { DATE_DMY, DATE_DMY_FS, DATE_YMD, DATE_YMD_FS });
            dateTime = InputHelper.GetDateTime("What's today's date? ", IsDateTimeEqualToToday, formats.Default);
            PrintHelper.PrintLine($"{FormatDateTime(dateTime, DATE_DMY_FS)}? That's correct!", LogLevel.Success);

        }

        private bool IsDateTimeEqualToToday(DateTime dt) {
            bool isEqual = dt.Date == DateTime.Today;

            if (!isEqual) {
                PrintHelper.PrintLine($"Liar! Today is not the {FormatDateTime(dt, DATE_DMY_FS)}.");
            }

            return isEqual;
        }

        private static string FormatDateTime(DateTime dateTime, string format) {
            return dateTime.ToString(format, CultureInfo.InvariantCulture);
        }

        private class SupportedDateTimeFormats : IEnumerable<string>
        {
            LinkedList<string> _formats;

            public string Default { get => _formats.FirstOrDefault(); }

            public SupportedDateTimeFormats(string format) :
                this(new string[] { format }) {
            }

            public SupportedDateTimeFormats(string[] formats) {
                _formats = new LinkedList<string>(formats);
            }

            public void SetDefault(string format) {
                var element = _formats.Find(format);
                if (element != null) {
                    _formats.Remove(element);
                }

                _formats.AddFirst(format);
            }

            public void Add(string format) {
                var element = _formats.Find(format);
                if (element == null) {
                    _formats.AddLast(format);
                }
            }

            public IEnumerator<string> GetEnumerator() {
                return ((IEnumerable<string>)_formats).GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator() {
                return ((IEnumerable)_formats).GetEnumerator();
            }
        }
    }
}

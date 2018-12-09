using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trady.Core.Infrastructure;
using Trady.Importer.Csv;
using Trady.Analysis.Indicator;
using Trady.Analysis.Extension;
using Trady.Analysis.Infrastructure;
using System.Globalization;
using System.Diagnostics;
using Trady.Analysis;

namespace TradyIndicator
{
    public partial class Main : Form
    {

        static int AdxperiodCount = 0;
        static int AdxrperiodCount = 0;
        static int AroonperiodCount = 0;
        static int AroonOscperiodCountv = 0;
        static int AtrperiodCount = 0;
        static int BbperiodCountv = 0;
        static decimal BbsdCountv = 0;
        static int BbWidthperiodCount = 0;
        static decimal BbWidthsdCount = 0;
        static int CciperiodCount = 0;
        static int ChandlrperiodCount = 0;
        static decimal ChandlratrCount = 0;
        static int DmiperiodCount = 0;
        static int DymoisdPeriod = 0;
        static int DymoismoothedSdPeriod = 0;
        static int DymoirsiPeriod = 0;
        static int DymoiupLimit = 0;
        static int DymoilowLimit = 0;
        static int EmaperiodCount = 0;
        static int EmaOscperiodCount1 = 0;
        static int EmaOscperiodCount2 = 0;
        static int FastStoperiodCount = 0;
        static int FastStosmaPeriodCount = 0;
        static int FastStoOscperiodCount = 0;
        static int FastStoOscsmaPeriodCount = 0;
        static int FullStoperiodCount = 0;
        static int FullStosmaPeriodCountK = 0;
        static int FullStosmaPeriodCountD = 0;
        static int FullStoOscperiodCount = 0;
        static int FullStoOscsmaPeriodCountK = 0;
        static int FullStoOscsmaPeriodCountD = 0;
        static int HighCloseperiodCount = 0;
        static int HighHighperiodCount = 0;
        static int IchimokushortPeriodCount = 0;
        static int IchimokumiddlePeriodCount = 0;
        static int IchimokulongPeriodCount = 0;
        static int KamaperiodCount = 0;
        static int KamaemaFastPeriodCount = 0;
        static int KamaemaSlowPeriodCount = 0;
        static int KcperiodCoun = 0;
        static decimal KcsdCount = 0;
        static int KcatrPeriodCount = 0;
        static int LowCloseperiodCount = 0;
        static int LowLowperiodCount = 0;
        static int MacdemaPeriodCount1 = 0;
        static int MacdemaPeriodCount2 = 0;
        static int MacddemPeriodCount = 0;
        static int MacdHistemaPeriodCount1 = 0;
        static int emaPeriodCount2 = 0;
        static int demPeriodCount = 0;
        static int MdiperiodCount = 0;
        static int MedianperiodCount = 0;
        static int MmaperiodCount = 0;
        static int MtmnumberOfDays = 0;
        static int NmoperiodCount = 0;
        static int PdiperiodCount = 0;
        static int PercentileperiodCount = 0;
        static decimal Percentilepercent = 0;
        static int RmrmiPeriod = 0;
        static int RmmtmPeriod = 0;
        static int RmirmiPeriod = 0;
        static int RmimtmPeriod = 0;
        static int RocnumberOfDays = 0;
        static int RsperiodCount = 0;
        static int RsvperiodCount = 0;
        static int periodCount = 0;
        static decimal Sarstep = 0;
        static decimal vmaximumStep = 0;
        static int SdperiodCount = 0;
        static int SlowStoperiodCount = 0;
        static int SlowStosmaPeriodCountD = 0;
        static int SlowStoOscperiodCount = 0;
        static int SlowStoOscsmaPeriodCountD = 0;
        static int SmaperiodCount = 0;
        static int SmaOscperiodCount1 = 0;
        static int SmaOscperiodCount2 = 0;
        static int SmiperiodCount = 0;
        static int SmismoothingPeriodA = 0;
        static int SmismoothingPeriodB = 0;
        static int StochRsiperiodCount = 0;
        static int WmaperiodCount = 0;
        static int ErPeriod = 0;
        int Aroonperiod=0;


        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }



        protected async static Task<IEnumerable<IOhlcv>> importData(string file, string symbol)
        {
            var csvImport = new CsvImporter(file, CultureInfo.GetCultureInfo("en-US"));
            return await csvImport.ImportAsync(symbol);

        }
        public static void writeToCsv(IReadOnlyList<Trady.Analysis.AnalyzableTick<decimal?>> list, string ind)
        {

        }

        public static void writeToCsv(IReadOnlyList<AnalyzableTick<(decimal? Up, decimal? Down)>> list, string ind)
        {

        }

        public static void writeToCsv(IReadOnlyList<AnalyzableTick<(decimal? LowerBand, decimal? MiddleBand, decimal? UpperBand)>> list, string ind)
        {

        }
        public static async Task ProcessData()

        {
            var candles = await importData("", "");

            var result2 = candles.Aroon(AroonperiodCount);
            writeToCsv(result2, "Aroon");

            var result = candles.AroonOsc(AroonOscperiodCountv);
            writeToCsv(result, "AroonOsc");

            result = candles.Atr(AtrperiodCount);
            writeToCsv(result, "Atr");

            var result3 = candles.Bb(BbperiodCountv,BbsdCountv);
            writeToCsv(result3, "Bb");

            result = candles.BbWidth(BbWidthperiodCount, BbWidthsdCount);
            writeToCsv(result, "BbWidth");

            result = candles.Cci(CciperiodCount);
            writeToCsv(result, "Cci");


            result2 = candles.Chandlr(ChandlrperiodCount,ChandlratrCount);
            writeToCsv(result2, "Chandlr");

            result = candles.Dmi(DmiperiodCount);
            writeToCsv(result, "Dmi");

             result = candles.Dymoi(DymoirsiPeriod,DymoismoothedSdPeriod,DymoirsiPeriod,DymoiupLimit,DymoilowLimit);
             writeToCsv(result, "Dymoi");

            result = candles.Ema(EmaperiodCount);
            writeToCsv(result, "Ema");

            result = candles.EmaOsc(EmaOscperiodCount1,emaPeriodCount2);
            writeToCsv(result, "EmaOsc");

            result = candles.Er(ErPeriod);
            writeToCsv(result, "Er");

            result3 = candles.FastSto(FastStoOscperiodCount,FastStoOscsmaPeriodCount);
            writeToCsv(result3, "FastSto");

            result3 = candles.FullSto(FullStoOscperiodCount, FullStoOscsmaPeriodCountD, FullStoOscsmaPeriodCountD);
            writeToCsv(result3, "FastSto");


            result = candles.FullStoOsc(FullStoOscperiodCount, FullStoOscsmaPeriodCountK, FullStoOscsmaPeriodCountD);
            writeToCsv(result, "FullStoOsc");

            result = candles.HighClose(HighCloseperiodCount);
            writeToCsv(result, "HighClose");

            result = candles.HighHigh(HighHighperiodCount);
            writeToCsv(result, "HighHigh");

            result = candles.HistHighClose();
            writeToCsv(result, "HistHighClose");









        }

        public void er()
        {


        }

    }
}

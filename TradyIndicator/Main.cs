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
using System.IO;

namespace TradyIndicator
{
    public partial class Main : Form
    {


        static string directory = "";
        static int AdxperiodCount = 1;
        static int AdxrperiodCount = 1;
        static int AroonperiodCount = 1;
        static int AroonOscperiodCountv = 1;
        static int AtrperiodCount = 1;
        static int BbperiodCountv = 1;
        static decimal BbsdCountv = 1;
        static int BbWidthperiodCount = 1;
        static decimal BbWidthsdCount = 1;
        static int CciperiodCount = 1;
        static int ChandlrperiodCount = 1;
        static decimal ChandlratrCount = 1;
        static int DmiperiodCount = 1;

    

        static int DymoisdPeriod = 3;
        static int DymoismoothedSdPeriod = 2;
        static int DymoirsiPeriod = 1;
        static int DymoiupLimit = 4;
        static int DymoilowLimit = 5;


        static int EmaperiodCount = 1;
        static int EmaOscperiodCount1 = 1;
        static int EmaOscperiodCount2 = 1;
        static int FastStoperiodCount = 1;
        static int FastStosmaPeriodCount = 1;
        static int FastStoOscperiodCount = 1;
        static int FastStoOscsmaPeriodCount = 1;
        static int FullStoperiodCount = 1;
        static int FullStosmaPeriodCountK = 1;
        static int FullStosmaPeriodCountD = 1;
        static int FullStoOscperiodCount = 1;
        static int FullStoOscsmaPeriodCountK = 1;
        static int FullStoOscsmaPeriodCountD = 1;
        static int HighCloseperiodCount = 1;
        static int HighHighperiodCount = 1;

        static int IchimokushortPeriodCount = 9;
        static int IchimokumiddlePeriodCount = 26;
        static int IchimokulongPeriodCount = 52;

        static int KamaperiodCount = 10;
        static int KamaemaFastPeriodCount = 2;
        static int KamaemaSlowPeriodCount = 30;
        static int KcperiodCoun = 1;
        static decimal KcsdCount = 1;
        static int KcatrPeriodCount = 1;
        static int LowCloseperiodCount = 1;
        static int LowLowperiodCount = 1;
        static int MacdemaPeriodCount1 = 1;
        static int MacdemaPeriodCount2 = 1;
        static int MacddemPeriodCount = 1;
        static int MacdHistemaPeriodCount1 = 1;
        static int MacdHistemaPeriodCount2 = 1;
        static int MacdHistDemoPeriodCount = 1;
        static int emaPeriodCount2 = 1;
        static int demPeriodCount = 1;
        static int MdiperiodCount = 14;
        static int MedianperiodCount = 1;
        static int MmaperiodCount = 1;
        static int MtmnumberOfDays = 1;
        static int NmoperiodCount = 1;
        static int PdiperiodCount = 1;
        static int PercentileperiodCount = 1;
        static decimal Percentilepercent = 1;
        static int RmrmiPeriod = 1;
        static int RmmtmPeriod = 1;
        static int RmirmiPeriod = 1;
        static int RmimtmPeriod = 1;
        static int RocnumberOfDays = 1;
        static int RsperiodCount = 1;
        static int RsvperiodCount = 1;
        static int periodCount = 1;
        static decimal Sarstep = 1;
        static decimal SarmaximumStep = 1;
        static int SdperiodCount = 1;
        static int SlowStoperiodCount = 1;
        static int SlowStosmaPeriodCountD = 1;
        static int SlowStoOscperiodCount = 1;
        static int SlowStoOscsmaPeriodCountD = 1;
        static int SmaperiodCount = 1;
        static int SmaOscperiodCount1 = 1;
        static int SmaOscperiodCount2 = 1;
        static int SmiperiodCount = 1;
        static int SmismoothingPeriodA = 1;
        static int SmismoothingPeriodB = 1;
        static int StochRsiperiodCount = 1;
        static int WmaperiodCount = 1;
        static int ErPeriod = 1;
        static int HmaPeriod = 1;
        static int Aroonperiod = 1;


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
        public static void writeToCsv(IReadOnlyList<Trady.Analysis.AnalyzableTick<decimal?>> list, string ind,string file)
        {
            new CsvLib().addToCsvColData(file, list.Select(c => c.Tick.HasValue ? c.Tick.Value.ToString(): "0").ToArray(), ind );

        }


        public static void writeToCsv(IReadOnlyList<AnalyzableTick<(decimal? ConversionLine, decimal? BaseLine, decimal? LeadingSpanA, decimal? LeadingSpanB, decimal? LaggingSpan)>> list, string ind,string file)
        {


            new CsvLib().addToCsvColData(file, list.Select(c => c.Tick.ConversionLine!=null ? c.Tick.ConversionLine.Value.ToString() : "0").ToArray(), ind + " ConversionLine");

            new CsvLib().addToCsvColData(file, list.Select(c => c.Tick.LeadingSpanA != null ? c.Tick.LeadingSpanA.Value.ToString() : "0"  ).ToArray(), ind + " LeadingSpanA");
            new CsvLib().addToCsvColData(file, list.Select(c => c.Tick.LeadingSpanB != null ? c.Tick.LeadingSpanB.Value.ToString() : "0").ToArray(), ind + " LeadingSpanB");

            new CsvLib().addToCsvColData(file, list.Select(c => c.Tick.LaggingSpan != null ? c.Tick.LaggingSpan.Value.ToString() : "0").ToArray(), ind + " LaggingSpan");

        }


        public static void writeToCsv(IReadOnlyList<AnalyzableTick<(decimal? Up, decimal? Down)>> list, string ind,string file)
        {
            new CsvLib().addToCsvColData(file, list.Select(c => c.Tick.Up != null ? c.Tick.Up.Value.ToString() : "0").ToArray(), ind + " Up");

            new CsvLib().addToCsvColData(file, list.Select(c => c.Tick.Down != null ? c.Tick.Down.Value.ToString() : "0").ToArray(), ind + " Down");

        }
        public static void writeFirstToCsv(IReadOnlyList<AnalyzableTick<(decimal? Up, decimal? Down)>> list, string ind, string file)
        {

        }

        public static void writeToCsv(IReadOnlyList<AnalyzableTick<(decimal? LowerBand, decimal? MiddleBand, decimal? UpperBand)>> list, string ind, string file)
        {


            new CsvLib().addToCsvColData(file, list.Select(c => c.Tick.LowerBand != null ? c.Tick.LowerBand.Value.ToString() : "0").ToArray(), ind + " LowerBand");

            new CsvLib().addToCsvColData(file, list.Select(c => c.Tick.MiddleBand != null ? c.Tick.MiddleBand.Value.ToString() : "0").ToArray(), ind + " MiddleBand");

            new CsvLib().addToCsvColData(file, list.Select(c => c.Tick.UpperBand != null ? c.Tick.UpperBand.Value.ToString() : "0").ToArray(), ind + " UpperBand");
        }


        public void er()
        {


        }

        public int convertodecimal(string c)
        {

            try


            {

                return int.Parse(c);

            }
          catch

            {
                return 1;


            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string[] files = Directory.GetFiles(fbd.SelectedPath);

                    directory = fbd.SelectedPath;

                    System.IO.Directory.CreateDirectory(@directory + @"\results\");
                    label1.Text = directory;
                    System.Windows.Forms.MessageBox.Show("Files found: " + files.Length.ToString(), "Message");
                }
            }
        }

        public static async Task ProcessData()
        {


            try

            {

                Cursor.Current = Cursors.WaitCursor;
                DirectoryInfo d = new DirectoryInfo(directory);//Assuming Test is your Folder
                FileInfo[] Files = d.GetFiles("*.csv"); //Getting Text files
                string str = "";
                foreach (FileInfo file in Files)
                {


                    try

                    { 
                    var candles = await importData(file.FullName, "");
                    var directory = file.Directory + @"/results/";



                    new CsvLib().addFirstCsvColData(directory+file.Name, candles.Select(c => c.DateTime.ToString()).ToList(), "Date");

                    var result2 = candles.Aroon(AroonperiodCount);
                    writeToCsv(result2, "Aroon", directory + file.Name);

                    var result = candles.AroonOsc(AroonOscperiodCountv);
                    writeToCsv(result, "Aroon Oscillator", directory + file.Name);

                    result = candles.Atr(AtrperiodCount);
                    writeToCsv(result, "Average True Range", directory + file.Name);

                    var result3 = candles.Bb(BbperiodCountv, BbsdCountv);
                    writeToCsv(result3, "Bollinger Bands", directory + file.Name);

                    result = candles.BbWidth(BbWidthperiodCount, BbWidthsdCount);
                    writeToCsv(result, "Bollinger BandWidth", directory + file.Name);

                    result = candles.Cci(CciperiodCount);
                    writeToCsv(result, "Commodity Channel Index", directory + file.Name);


                    result2 = candles.Chandlr(ChandlrperiodCount, ChandlratrCount);
                    writeToCsv(result2, "Chandelier Exit", directory + file.Name);

                    result = candles.Dmi(DmiperiodCount);
                    writeToCsv(result, "Directional Movement Index", directory + file.Name);



                    result = candles.Ema(EmaperiodCount);
                    writeToCsv(result, "Exponential Moving Average", directory + file.Name);

                    result = candles.EmaOsc(EmaOscperiodCount1, emaPeriodCount2);
                    writeToCsv(result, "Exponential Moving Average Oscillator", directory + file.Name);

                    result = candles.Er(ErPeriod);
                    writeToCsv(result, "Efficiency  Ratio", directory + file.Name);

                    result3 = candles.FastSto(FastStoperiodCount, FastStosmaPeriodCount);
                    writeToCsv(result3, "Stochastics Fast", directory + file.Name);

                    result3 = candles.FullSto(FullStoperiodCount, FullStosmaPeriodCountD, FullStosmaPeriodCountD);
                    writeToCsv(result3, "Stochastics Full", directory + file.Name);


                    result = candles.FullStoOsc(FullStoOscperiodCount, FullStoOscsmaPeriodCountK, FullStoOscsmaPeriodCountD);
                    writeToCsv(result, "Stochastics Oscillator Full", directory + file.Name);

                    result = candles.HighClose(HighCloseperiodCount);
                    writeToCsv(result, "Highest Close", directory + file.Name);

                    result = candles.HighHigh(HighHighperiodCount);
                    writeToCsv(result, "HighestHigh", directory + file.Name);


                    result = candles.HistHighClose();
                    writeToCsv(result, "Historical Highest Close", directory + file.Name);

                    result = candles.HistHighHigh();
                    writeToCsv(result, "Historical Highest High", directory + file.Name);


                    result = candles.HistLowClose();
                    writeToCsv(result, "Historical Lowest Close", directory + file.Name);

                    result = candles.HistLowLow();
                    writeToCsv(result, "Historical Lowest Low", directory + file.Name);

                    result = candles.Hma(HmaPeriod);
                    writeToCsv(result, "Hull Moving Average", directory + file.Name);



                    result3 = candles.Kc(KcperiodCoun, KcsdCount, KcatrPeriodCount);
                    writeToCsv(result3, "Keltner Channels", directory + file.Name);

                    result = candles.LowClose(LowCloseperiodCount);

                    writeToCsv(result, "Lowest Close", directory + file.Name);


                    result = candles.LowLow(LowLowperiodCount);
                    writeToCsv(result, "Lowest Low", directory + file.Name);

                    result3 = candles.Macd(MacdemaPeriodCount1, MacdemaPeriodCount2, MacddemPeriodCount);
                    writeToCsv(result, "Moving Average Convergence Divergence", directory + file.Name);

                    result = candles.MacdHist(MacdHistemaPeriodCount1, MacdHistemaPeriodCount2, MacdHistDemoPeriodCount);
                    writeToCsv(result, "Moving Average Convergence Divergence Histogram", directory + file.Name);

                    result = candles.Mdi(MdiperiodCount);
                    writeToCsv(result, "Minus Directional Indicator", directory + file.Name); ;

    


                    result = candles.Median(MedianperiodCount);
                    writeToCsv(result, "Median", directory + file.Name);


                    result = candles.Mma(MmaperiodCount);
                    writeToCsv(result, "Modified Moving Average", directory + file.Name);

                    result = candles.Mtm();
                    writeToCsv(result, "Momentum", directory + file.Name);

                    result = candles.Nmo(NmoperiodCount);
                    writeToCsv(result, "Net Momentum Oscillator", directory + file.Name);

                    result = candles.Obv();
                    writeToCsv(result, "On Balance Volume", directory + file.Name);

                    result = candles.Pdi(PdiperiodCount);
                    writeToCsv(result, "Plus Directional Indicator", directory + file.Name);


                    result = candles.Pdm(PdiperiodCount);
                    writeToCsv(result, "Plus Directional Movement", directory + file.Name);


                    result = candles.Percentile(PercentileperiodCount, Percentilepercent);
                    writeToCsv(result, "Percentile", directory + file.Name);

                    result = candles.Rm(RmrmiPeriod, RmmtmPeriod);
                    writeToCsv(result, "Rm", directory + file.Name); ;


                    result = candles.Rmi(RmirmiPeriod, RmimtmPeriod);
                    writeToCsv(result, "Relative Momentum Index", directory + file.Name);


                    result = candles.Roc();
                    writeToCsv(result, "Rate Of Change", directory + file.Name);

                    result = candles.Rs(RsperiodCount);
                    writeToCsv(result, "Relative Strength", directory + file.Name);

                    result  = candles.Rsi(RsperiodCount);
                    writeToCsv(result, "Relative Strength Index", directory + file.Name);

                    result = candles.Rsv(RsvperiodCount);
                    writeToCsv(result, "Raw Stochastics Value", directory + file.Name); ;

                    result = candles.Sar(Sarstep, SarmaximumStep);
                    writeToCsv(result, "Parabolic Stop And Reverse", directory + file.Name);

                    result = candles.Sd(SdperiodCount);
                    writeToCsv(result, "Standard Deviation", directory + file.Name);


                    result3 = candles.SlowSto(SlowStoOscperiodCount, SlowStosmaPeriodCountD);
                    writeToCsv(result, "Stochastics Slow", directory + file.Name);


                    result = candles.SlowStoOsc(SlowStoOscperiodCount, SlowStoOscsmaPeriodCountD);
                    writeToCsv(result, "Stochastics Oscillator low", directory + file.Name); ;

                    result = candles.Sma(SmaperiodCount);
                    writeToCsv(result, "Simple Moving Average", directory + file.Name);

                    result = candles.SmaOsc(SmaOscperiodCount1, SmaOscperiodCount2);
                    writeToCsv(result, "Simple Moving Average Oscillator", directory + file.Name);

                    result = candles.Smi(SmiperiodCount, SmismoothingPeriodA, SmismoothingPeriodB);
                    writeToCsv(result, "Stochastics Momentum Index", directory + file.Name);

                    result = candles.StochRsi(StochRsiperiodCount);
                    writeToCsv(result, "Stochastics Rsi Oscillator", directory + file.Name);

                    result = candles.Tr();
                    writeToCsv(result, "True Range", directory + file.Name);


                    result = candles.Wma(WmaperiodCount);
                    writeToCsv(result, "Weighted Moving Average", directory + file.Name);
                    var result4 = candles.Ichimoku(IchimokushortPeriodCount, IchimokumiddlePeriodCount, IchimokulongPeriodCount);
                    writeToCsv(result4, "Ichimoku Cloud", directory + file.Name);

                    result = candles.Mdm(MdiperiodCount);
                    writeToCsv(result, "Minus Directional Movement", directory + file.Name);
                    result = candles.Kama(KamaperiodCount, KamaemaFastPeriodCount, KamaemaSlowPeriodCount);
                    writeToCsv(result, "Kaufman Adaptive Moving Average", directory + file.Name);

                        //Dymoi DOES NOT WORK HE  HAS MORE PROBLEMS THE PROBLEM IS FROM THE LIBRARY 
                        //result = candles.Dymoi(DymoirsiPeriod, DymoismoothedSdPeriod, DymoisdPeriod, DymoiupLimit, DymoilowLimit);
                        //writeToCsv(result, "Dymoi", directory + file.Name);



                    }

                    catch (Exception)


                    {
                        Cursor.Current = Cursors.Default;

                        MessageBox.Show("Invalid parameter");
                        return;

                    }



                }
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Done");
            }

            catch (Exception ex)

            {
                Cursor.Current = Cursors.Default;




            }




        }

        private async void button3_Click(object sender, EventArgs e)
        {

 
            AdxperiodCount = convertodecimal(AdxperiodCountTxt.Text);
            AdxrperiodCount = convertodecimal(AdxrperiodCountTxt.Text);
            AroonperiodCount = convertodecimal(AroonperiodCountTxt.Text);
            AroonOscperiodCountv = convertodecimal(AroonOscperiodCountTxt.Text );
            AtrperiodCount = convertodecimal(AtrperiodCountTxt.Text);
            BbperiodCountv = convertodecimal(BbperiodCountTxt.Text);
            BbsdCountv = convertodecimal(BbsdCountTxt.Text);
            BbWidthperiodCount = convertodecimal(BbWidthperiodCountTxt.Text );
            BbWidthsdCount = convertodecimal(BbWidthsdCountTxt.Text);
            CciperiodCount = convertodecimal(CciperiodCountTxt.Text );
            ChandlrperiodCount = convertodecimal(ChandlrperiodCountTxt.Text);
            ChandlratrCount = convertodecimal(ChandlratrCountTxt.Text);
            DmiperiodCount = convertodecimal(DmiperiodCountTxt.Text);



            DymoisdPeriod = convertodecimal(DymoisdPeriodTxt.Text);
            DymoismoothedSdPeriod = convertodecimal(DymoismoothedSdPeriodTxt.Text);
            DymoirsiPeriod = convertodecimal(DymoirsiPeriodTxt.Text );
            DymoiupLimit = convertodecimal(DymoiupLimitTxt.Text );
            DymoilowLimit = convertodecimal(DymoilowLimitTxt.Text);


            EmaperiodCount = convertodecimal(EmaperiodCountTxt.Text);
            EmaOscperiodCount1 = convertodecimal(EmaOscperiodCount1Txt.Text);
            EmaOscperiodCount2 = convertodecimal(EmaOscperiodCount2Txt.Text);
            FastStoperiodCount = convertodecimal(FastStoperiodCountTxt.Text);
            FastStosmaPeriodCount = convertodecimal(FastStosmaPeriodCountTxt.Text);
            FastStoOscperiodCount = convertodecimal(FastStoOscperiodCountTxt.Text);
            FastStoOscsmaPeriodCount = convertodecimal(FastStoOscsmaPeriodCountTxt.Text);
            FullStoperiodCount = convertodecimal(FullStoperiodCountTxt.Text);
            FullStosmaPeriodCountK = convertodecimal(FullStosmaPeriodCountKTxt.Text);
            FullStosmaPeriodCountD = convertodecimal(FullStosmaPeriodCountDTxt.Text);
            FullStoOscperiodCount = convertodecimal(FullStoOscperiodCountTxt.Text);
            FullStoOscsmaPeriodCountK = convertodecimal(FullStoOscsmaPeriodCountKTxt.Text);
            FullStoOscsmaPeriodCountD = convertodecimal(FullStoOscsmaPeriodCountDTxt.Text);
            HighCloseperiodCount = convertodecimal(HighCloseperiodCountTxt.Text);
            HighHighperiodCount = convertodecimal(HighHighperiodCounttxt.Text);

            IchimokushortPeriodCount = convertodecimal(IchimokushortPeriodCountTxt.Text);
            IchimokumiddlePeriodCount = convertodecimal(IchimokumiddlePeriodCountTxt.Text);
            IchimokulongPeriodCount = convertodecimal(IchimokulongPeriodCountTxt.Text);

            KamaperiodCount = convertodecimal(KamaperiodCountTxt.Text );
            KamaemaFastPeriodCount = convertodecimal(KamaemaFastPeriodCountTxt.Text);
            KamaemaSlowPeriodCount = convertodecimal(KamaemaSlowPeriodCountTxt.Text);
            KcperiodCoun = convertodecimal(KcperiodCounTxt.Text);
            KcsdCount = convertodecimal(KcsdCountTxt.Text);
            KcatrPeriodCount = convertodecimal(KcatrPeriodCountTxt.Text);
            LowCloseperiodCount = convertodecimal(LowCloseperiodCountTxt.Text);
            LowLowperiodCount = convertodecimal(LowLowperiodCountTxt.Text );
            MacdemaPeriodCount1 = convertodecimal(MacdemaPeriodCount1Txt.Text);
            MacdemaPeriodCount2 = convertodecimal(MacdemaPeriodCount2Txt.Text);
            MacddemPeriodCount = convertodecimal(MacddemPeriodCountTxt.Text);
            MacdHistemaPeriodCount1 = convertodecimal(MacdHistemaPeriodCount1Txt.Text);
            MacdHistemaPeriodCount2 = convertodecimal(MacdHistemaPeriodCount2Txt.Text);
            MacdHistDemoPeriodCount = convertodecimal(MacdHistDemoPeriodCountTxt.Text);
            emaPeriodCount2 = convertodecimal(EmaOsPeriodCount2Txt.Text);
 
            MdiperiodCount = convertodecimal(MdiperiodCountTxt.Text);
            MedianperiodCount = convertodecimal(MedianperiodCountTxt.Text);
            MmaperiodCount = convertodecimal(MmaperiodCountTxt.Text);
            MtmnumberOfDays = convertodecimal(MtmnumberOfDaysTxt.Text);
            NmoperiodCount = convertodecimal(NmoperiodCountTxt.Text );
            PdiperiodCount = convertodecimal(PdiperiodCountTxt.Text);
            PercentileperiodCount = convertodecimal(PercentileperiodCountTxt.Text);
            Percentilepercent = convertodecimal(PercentilepercentTxt.Text);
            RmrmiPeriod = convertodecimal(RmrmiPeriodTxt.Text );
            RmmtmPeriod = convertodecimal(RmmtmPeriodTxt.Text);
            RmirmiPeriod = convertodecimal(RmirmiPeriodTxt.Text);
            RmimtmPeriod = convertodecimal(RmimtmPeriodTxt.Text);
            RocnumberOfDays = convertodecimal(RocnumberOfDaysTxt.Text);
            RsperiodCount = convertodecimal(RsperiodCountTxt.Text);
            RsvperiodCount = convertodecimal(RsvperiodCountTxt.Text);
       
            Sarstep = convertodecimal(SarstepTxt.Text);
            SarmaximumStep = convertodecimal(SarmaximumStepTxt.Text);
            SdperiodCount = convertodecimal(SdperiodCountTxt.Text);
            SlowStoperiodCount = convertodecimal(SlowStoperiodCountTxt.Text);
            SlowStosmaPeriodCountD = convertodecimal(SlowStosmaPeriodCountDTxt.Text);
            SlowStoOscperiodCount = convertodecimal(SlowStoOscperiodCountTxt.Text);
            SlowStoOscsmaPeriodCountD = convertodecimal(SlowStoOscsmaPeriodCountDTxt.Text);
            SmaperiodCount = convertodecimal(SmaperiodCountTxt.Text);
            SmaOscperiodCount1 = convertodecimal(SmaOscperiodCount1Txt.Text );
            SmaOscperiodCount2 = convertodecimal(SmaOscperiodCount2Txt.Text);
            SmiperiodCount = convertodecimal(SmiperiodCountTxt.Text);
            SmismoothingPeriodA = convertodecimal(SmismoothingPeriodATxt.Text);
            SmismoothingPeriodB = convertodecimal(SmismoothingPeriodBTxt.Text);
            StochRsiperiodCount =  convertodecimal(StochRsiperiodCountTxt.Text );
            WmaperiodCount = convertodecimal(WmaperiodCountTxt.Text);
            ErPeriod = convertodecimal(ErPeriodTxt.Text );
            HmaPeriod = convertodecimal(HmaPeriodTxt.Text);
            Aroonperiod = convertodecimal(AdxperiodCountTxt.Text);


            using ( WaitCursor c = new WaitCursor())
            {
                await ProcessData();
            }

      


     


        }

        private void MacdHistemaPeriodCount2Txt_TextChanged(object sender, EventArgs e)
        {

        }
    }
    class WaitCursor : System.IDisposable
    {
        public WaitCursor()
        {
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
        }

        public void Dispose()
        {
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
        }
    }


}



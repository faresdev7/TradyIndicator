using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradyIndicator
{
  public class CsvLib
    {
        int count;
        public void addFirstCsvColData(string filePath, List<string> colsData, string colName)
        {



            try

            {
                var myFile = File.Create(filePath);
                myFile.Close();
                count = colsData.Count;
                List<string> csv = new List<string>();
                csv.Add(colName);
                csv.AddRange((colsData));
                File.WriteAllLines(filePath, csv);
                myFile.Close();

            }

            catch (Exception exxx)

            {

              

            }
        }
        public List<string> getListString(double[] colsData)

        {

            List<string> strings = new List<string>();
            foreach (double d in colsData)
            {

                strings.Add(d.ToString());
            }
            return strings;
        }






        public void addToCsvColData(string filePath, double[] colsData, string colName)
        {



            List<string> dataL = new List<string>();
            var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                int i = 0;
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {

                    dataL.Add(line);
                    i++;

                }
            }
            fileStream.Close();

            List<string> newList = new List<string>();
            if (dataL.Count >= colsData.Length + 1)
            {

                for (int i = 0; i < dataL.Count; i++)
                {
                    if (i == 0)
                    { newList.Add(dataL[i] + "," + colName); }
                    else
                    {

                        if (i <= colsData.Length)
                            newList.Add(dataL[i] + "," + colsData[i - 1].ToString().Replace(",", "."));
                        else
                            newList.Add(dataL[i] + "," + "0");

                    }
                }


            }
            else
            {
                for (int i = 0; i < colsData.Length; i++)
                {
                    if (i == 0)
                    { newList.Add(dataL[i] + "," + colName); }
                    else
                    {

                        if (i <= dataL.Count)
                            newList.Add(dataL[i] + "," + colsData[i - 1].ToString().Replace(",", "."));
                        else
                            newList.Add("" + "," + colsData[i - 1].ToString().Replace(",", "."));

                    }
                }
            }


            File.WriteAllLines(filePath, newList);

        }


        public void addToCsvColData(string filePath, int[] colsData, string colName)
        {



            List<string> dataL = new List<string>();
            var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                int i = 0;
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {

                    dataL.Add(line);
                    i++;

                }
            }
            fileStream.Close();

            List<string> newList = new List<string>();
            if (dataL.Count >= colsData.Length)
            {

                for (int i = 0; i < dataL.Count; i++)
                {
                    if (i == 0)
                    { newList.Add(dataL[i] + "," + colName); }
                    else
                    {

                        if (i < colsData.Length)
                            newList.Add(dataL[i] + "," + colsData[i].ToString().Replace(",", "."));
                        else
                            newList.Add(dataL[i] + "," + "0");

                    }
                }


            }
            else
            {
                for (int i = 0; i < colsData.Length; i++)
                {
                    if (i == 0)
                    { newList.Add(dataL[i] + "," + colName); }
                    else
                    {

                        if (i <= dataL.Count)
                            newList.Add(dataL[i - 1] + "," + colsData[i].ToString().Replace(",", "."));
                        else
                            newList.Add("" + "," + colsData[i].ToString().Replace(",", "."));

                    }
                }
            }


            File.WriteAllLines(filePath, newList);

        }
        public List<string> readData(string _File_ )

        {

            List<string> dataLine = new List<string>();
            var fileStream = new FileStream(_File_, FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))

            {

                int i = 0;
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {


                    if (i != 0)

                    {
                        dataLine.Add(line);



                    }
                    i++;
                }


            }
            return dataLine;
        }
    }
}

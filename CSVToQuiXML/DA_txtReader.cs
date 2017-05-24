using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;
using System.Data;

namespace CSVtoQuiXML
{

    public class DA_txtReader
    {

        //public static void test()
        //{

        //    string[] txtFiles = new string[1];

        //    txtFiles[0] = "I:\\wrk\\iTRAQ_estadistica\\samples\\datos_abian\\Salida_Peptidos_Filtrados.txt";
        //    OutData.databases whichDB = OutData.databases.Target;

        //    ArrayList testing = readTXT(txtFiles, whichDB);
            

        //}

        public static ArrayList readTXT(string[] txtFiles,
                                        string[] readingOrder,
                                        OutData.databases whichDB)
        {

            ArrayList outsList = new ArrayList();
            //FormHeaderSelection frmHeader = new FormHeaderSelection();

            //frmHeader.Show();
                        
            foreach (string file in txtFiles)
            {
                try
                {
                    StreamReader sr = new StreamReader(File.OpenRead(file));
                    ArrayList myAL = new ArrayList();

                    try
                    {
                        while (sr.Peek() != -1) //equivalente a feof en C
                        {
                            myAL.Add(sr.ReadLine());
                        }
                    }
                    catch
                    {
                        //Console.WriteLine(" Parse error: " + e);
                    }

                    //int r = myAL.Count;

                    //object ob = (object)myAL[0];
                    //myAL.Remove(ob);


                    foreach (object o in myAL)
                    {
                        try
                        {
                            OutData sd = new OutData(whichDB,OutData.XCorrTypes.regular);
                            int RAWFilePos = findInArray(readingOrder, "*RAW file name");
                            int FirstScanPos = findInArray(readingOrder, "*FirstScan [- LastScan]");
                            int LastScanPos = findInArray(readingOrder, "LastScan");
                            int ProteinDescriptionPos = findInArray(readingOrder, "*Protein description");
                            int MHpPos = findInArray(readingOrder, "MH+");
                            int deltaMPos = findInArray(readingOrder, "DeltaM");
                            int ChargePos = findInArray(readingOrder, "*Charge");
                            int SequencePos = findInArray(readingOrder, "*Sequence");
                            int PpepPos = findInArray(readingOrder, "P (pep)");
                            int Xcorr1Pos = findInArray(readingOrder, "Xcorr1");
                            //int Xcorr2Pos = findInArray(readingOrder, "Xcorr2");
                            int DeltaCnPos = findInArray(readingOrder, "DeltaCn");
                            int SpPos = findInArray(readingOrder, "Sp");
                            int SpRankPos = findInArray(readingOrder, "Sp Rank");
                            int ionsPos = findInArray(readingOrder, "Ions");
                            int XcTeoricPos = findInArray(readingOrder, "XcTeoric");
                            int ScorePos = findInArray(readingOrder, "Score");
                            
                            sd.FileName = file;

                            string[] str;
                            
                            str = Regex.Split(o.ToString(), "\t");

                            
                            sd.RAWFile = str[RAWFilePos];

                            string[] scans = Regex.Split(str[FirstScanPos],"-");
                            sd.FirstScan = int.Parse(scans[0]);
                            if (scans.Length > 1)
                            {
                                sd.LastScan = int.Parse(scans[scans.Length - 1]);
                            }
                            else 
                            {
                                sd.LastScan = sd.FirstScan;
                            }

                            // If there is a specific column for the LastScan, then it is overwritten in next file
                            if (LastScanPos != -1)
                                sd.LastScan = int.Parse(str[LastScanPos]);

                            sd.ProteinDescription = str[ProteinDescriptionPos];

                            if(MHpPos != -1)
                                sd.MHp = float.Parse(str[MHpPos]);
                                sd.PrecursorMass = float.Parse(str[MHpPos]);
                            if(deltaMPos !=-1)
                                sd.deltaM = float.Parse(str[deltaMPos]);

                            sd.Charge = short.Parse(str[ChargePos]);

                            // Sequence is written only if selected
                            if (SequencePos != -1)
                                sd.Sequence = str[SequencePos];

                            if (PpepPos != -1)
                                sd.Ppep = float.Parse(str[PpepPos]);

                            if (Xcorr1Pos != -1)
                                sd.Xcorr1 = float.Parse(str[Xcorr1Pos]);

                            if (DeltaCnPos != -1)
                            {
                                sd.DeltaCn = float.Parse(str[DeltaCnPos]);
                                sd.Xcorr2 = sd.Xcorr1Search * (1 - sd.DeltaCn);
                                sd.XcorrRandom = sd.Xcorr2;
                            }

                            if (SpPos != -1)
                                sd.Sp = float.Parse(str[SpPos]);

                            if (SpRankPos != -1)
                                sd.SpRank = short.Parse(str[SpRankPos]);

                            if (ionsPos != -1)
                            {
                                string[] ions = str[ionsPos].Split('/');
                                sd.IonsMatched = short.Parse(ions[0]);
                                if (ions.Length > 1)
                                {
                                    sd.IonsCompared = short.Parse(ions[ions.Length - 1]);
                                }
                            }

                            if (ScorePos != -1)
                                sd.Score = double.Parse(str[ScorePos]);

                            if (XcTeoricPos != -1)
                                sd.XcTeoric = float.Parse(str[XcTeoricPos]);
                  

                            // Here to implement redundances
                            //int numOfReds = 3;
                            //Redundance[] allReds = new Redundance[numOfReds];

                            //Redundance myRed = new Redundance();
                            //allReds[0].FASTAIndex = 12345;
                            //allReds[0].FASTAProteinDescription = "la proteina que le falta al Marco";

                            //sd.Redundances = (Redundance[]) allReds.Clone();

                            outsList.Add(sd);
                        }
                        catch { }
                    }


                    sr.Close();

                }
                catch
                {
                    
                }
            }

            return outsList;
        }

           
       
        
        private static int findInArray(string[] readingOrder, string stringToFind)
        {
            // if stringToFind is not found, the result will be -1
            int val = -1;
            int a = 0;

            while (val == -1 && a < readingOrder.Length)
            {   
                if (readingOrder[a] == stringToFind)
                {
                    val = a;
                    break;
                }
                a++;
            }

            return val;
        }

        public class Quality
        {
            public enum QualityType
            {
                Xc2,
                Xc3,
                Xc4,
                XcAveraged
            }

            public DA_txtReader.Quality.QualityType whichQuality
            {
                get { return whichQualityVal; }
                set { whichQualityVal = value; }
            }

            private DA_txtReader.Quality.QualityType whichQualityVal;
        }

    }

}

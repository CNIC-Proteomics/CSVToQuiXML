using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;
using System.Data;

namespace CSVtoQuiXML
{

    class PrecMassId
    {

        private int scanNumber_MS2val;
        private int scanNumber_MS3val;
        //private string mgfFileVal;
        private double MHplusval;

        public int scanNumber_MS3
        {
            get{return scanNumber_MS3val;}
            set{scanNumber_MS3val = value;}
        }
        public int scanNumber_MS2
        {
            get { return scanNumber_MS2val; }
            set { scanNumber_MS2val = value; }
        }
        public double MHplus
        {
            get { return MHplusval; }
            set { MHplusval = value; }
        }
        //public string mgfFile
        //{
        //    get { return mgfFileVal; }
        //    set { mgfFileVal = value; }
        //}


    }

    class Utilities
    {
        //Without schema
        public static void writeQuiXML(ArrayList targetList,
                                double FDR,
                                string foldername)
        {

            System.IO.DirectoryInfo di = System.IO.Directory.GetParent(foldername);

            XmlDocument doc = new XmlDocument();

            XmlNode IdentificationArchive = doc.CreateElement("IdentificationArchive");

            XmlNode Identifications = doc.CreateElement("Identifications");

            doc.AppendChild(IdentificationArchive);
            IdentificationArchive.AppendChild(Identifications);


            foreach (OutData sd in targetList)
            {
                if (sd.FDR <= FDR)
                {

                    XmlNode peptide_match = doc.CreateElement("peptide_match");

                    XmlNode RAWFileName = doc.CreateElement("RAWFileName");
                    RAWFileName.InnerText = sd.RAWFile;
                    peptide_match.AppendChild(RAWFileName);

                    XmlNode FileName = doc.CreateElement("FileName");
                    FileName.InnerText = sd.FileName;
                    peptide_match.AppendChild(FileName);

                    XmlNode FirstScan = doc.CreateElement("FirstScan");
                    FirstScan.InnerText = sd.FirstScan.ToString();
                    peptide_match.AppendChild(FirstScan);

                    XmlNode LastScan = doc.CreateElement("LastScan");
                    LastScan.InnerText = sd.LastScan.ToString();
                    peptide_match.AppendChild(LastScan);

                    XmlNode Charge = doc.CreateElement("Charge");
                    Charge.InnerText = sd.Charge.ToString();
                    peptide_match.AppendChild(Charge);

                    XmlNode FDRx = doc.CreateElement("FDR");
                    FDRx.InnerText = sd.FDR.ToString();
                    peptide_match.AppendChild(FDRx);

                    XmlNode FASTAProteinDescription = doc.CreateElement("FASTAProteinDescription");
                    try
                    {
                        FASTAProteinDescription.InnerText = sd.ProteinDescription.ToString();
                    }
                    catch { }
                    peptide_match.AppendChild(FASTAProteinDescription);

                    XmlNode Sequence = doc.CreateElement("Sequence");
                    if (sd.Sequence != null)
                    {
                        if (sd.Sequence.Contains("."))
                        {
                            Sequence.InnerText = sd.Sequence.ToString();
                        }
                        else { Sequence.InnerText = "." + sd.Sequence.ToString() + "."; }
                    }
                    peptide_match.AppendChild(Sequence);

                    XmlNode pI = doc.CreateElement("pI");
                    pI.InnerText = sd.pI.ToString();
                    peptide_match.AppendChild(pI);

                    XmlNode PrecursorMass = doc.CreateElement("PrecursorMass");
                    if (sd.PrecursorMass != 0)
                    {
                        PrecursorMass.InnerText = sd.PrecursorMass.ToString();
                    }
                    else 
                    {
                        PrecursorMass.InnerText = sd.MHp.ToString();
                    }

                    peptide_match.AppendChild(PrecursorMass);

                    XmlNode Score = doc.CreateElement("Score");
                    if (sd.Score.ToString() != double.NaN.ToString())
                    {
                        Score.InnerText = sd.Score.ToString();
                        peptide_match.AppendChild(Score);
                    }

                    XmlNode XC1D = doc.CreateElement("XC1D");
                    XC1D.InnerText = sd.Xcorr1Search.ToString();
                    peptide_match.AppendChild(XC1D);

                    XmlNode XC2D = doc.CreateElement("XC2D");
                    XC2D.InnerText = sd.Xcorr2Search.ToString();
                    peptide_match.AppendChild(XC2D);

                    XmlNode deltaCn = doc.CreateElement("deltaCn");
                    deltaCn.InnerText = sd.DeltaCn.ToString();
                    peptide_match.AppendChild(deltaCn);

                    XmlNode Sp = doc.CreateElement("Sp");
                    Sp.InnerText = sd.Sp.ToString();
                    peptide_match.AppendChild(Sp);

                    XmlNode SpRank = doc.CreateElement("SpRank");
                    SpRank.InnerText = sd.SpRank.ToString();
                    peptide_match.AppendChild(SpRank);

                    XmlNode Proteinswithpeptide = doc.CreateElement("Proteinswithpeptide");
                    Proteinswithpeptide.InnerText = sd.ProteinsWithPeptide.ToString();
                    peptide_match.AppendChild(Proteinswithpeptide);

                    XmlNode rankings = doc.CreateElement("rankings");
                    XmlNode rnkXc1D = doc.CreateElement("rnkXc1D");
                    XmlNode rnkXc2D = doc.CreateElement("rnkXc2D");
                    XmlNode rnkXc1I = doc.CreateElement("rnkXc1I");
                    XmlNode rnkXc2I = doc.CreateElement("rnkXc2I");
                    rnkXc1D.InnerText = sd.rnkXc1.ToString();
                    rnkXc2D.InnerText = sd.rnkXcRandom.ToString();
                    rnkXc1I.InnerText = "0";
                    rnkXc2I.InnerText = "0";
                    rankings.AppendChild(rnkXc1D);
                    rankings.AppendChild(rnkXc2D);
                    rankings.AppendChild(rnkXc1I);
                    rankings.AppendChild(rnkXc2I);

                    peptide_match.AppendChild(rankings);

                    XmlNode Redundances = doc.CreateElement("Redundances");

                    if (sd.ProteinsWithPeptide > 0)
                    {
                        try
                        {
                            foreach (CSVtoQuiXML.Redundance myRed in sd.Redundances)
                            {

                                XmlNode Red = doc.CreateElement("Red");
                                XmlNode FASTAIndex_red = doc.CreateElement("FASTAIndex");
                                XmlNode FASTAProteinDescription_red = doc.CreateElement("FASTAProteinDescription");
                                FASTAIndex_red.InnerText = myRed.FASTAIndex.ToString();
                                FASTAProteinDescription_red.InnerText = myRed.FASTAProteinDescription.ToString();

                                Red.AppendChild(FASTAIndex_red);
                                Red.AppendChild(FASTAProteinDescription_red);

                                Redundances.AppendChild(Red);

                            }
                        }
                        catch { }

                    }
                    peptide_match.AppendChild(Redundances);

                    Identifications.AppendChild(peptide_match);



                }
            }

            string filename = foldername.Trim() + "\\" + di.Name.Trim() + "_QuiXML.xml";

            doc.Save(filename);


        }

        //When using schema
        public static void writeQuiXML(string[] txtFiles,
                                       string[] readingOrder,
                                       double FDR,
                                       string foldername)
        {
            ArrayList myAL = new ArrayList();

            System.IO.DirectoryInfo di = System.IO.Directory.GetParent(foldername);

            XmlDocument doc = new XmlDocument();

            XmlNode IdentificationArchive = doc.CreateElement("IdentificationArchive");

            XmlNode Identifications = doc.CreateElement("Identifications");

            doc.AppendChild(IdentificationArchive);
            IdentificationArchive.AppendChild(Identifications);

            foreach (string file in txtFiles)
            {
                try
                {
                    StreamReader sr = new StreamReader(File.OpenRead(file));
                   
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

                    sr.Close();
                }
                catch { }

                
            }


            bool scanHeader = true;
            foreach (object o in myAL)
            {                
                if (!scanHeader)
                {
                    XmlNode peptide_match = doc.CreateElement("peptide_match");

                    string[] str;

                    str = Regex.Split(o.ToString(), "\t");

                    int min = str.Length < readingOrder.Length ? str.Length : readingOrder.Length;

                    for (int i = 0; i < min; i++)
                    {
                        if (!(readingOrder[i] == null))
                        {
                            if (!readingOrder[i].StartsWith("(") && str[i].Length > 0)
                            {
                                XmlNode node = doc.CreateElement(readingOrder[i]);

                                if (node.Name == "Sequence")
                                {
                                    if (!str[i].Contains("."))
                                    {
                                        str[i] = "." + str[i] + ".";
                                    }
                                }

                                node.InnerText = str[i];


                                peptide_match.AppendChild(node);
                            }
                        }
                    }
                    
                    /*
                        XmlNode Redundances = doc.CreateElement("Redundances");

                        if (sd.ProteinsWithPeptide > 0)
                        {
                            try
                            {
                                foreach (abToQuiXML.Redundance myRed in sd.Redundances)
                                {

                                    XmlNode Red = doc.CreateElement("Red");
                                    XmlNode FASTAIndex_red = doc.CreateElement("FASTAIndex");
                                    XmlNode FASTAProteinDescription_red = doc.CreateElement("FASTAProteinDescription");
                                    FASTAIndex_red.InnerText = myRed.FASTAIndex.ToString();
                                    FASTAProteinDescription_red.InnerText = myRed.FASTAProteinDescription.ToString();

                                    Red.AppendChild(FASTAIndex_red);
                                    Red.AppendChild(FASTAProteinDescription_red);

                                    Redundances.AppendChild(Red);

                                }
                            }
                            catch { }

                        }
                        peptide_match.AppendChild(Redundances);

                     */

                    Identifications.AppendChild(peptide_match);

                }

                
                scanHeader = false;

                
            }


            
            string filename = foldername.Trim() + "\\" + di.Name.Trim() + "_QuiXML.xml";

            doc.Save(filename);


        }


        public static void getMHplusFromMgf(string QuiXMLfile,
                                            string XMLschema,
                                            string mgffolder,
                                            char[] split_chars,
                                            int scanField, 
                                            bool swapMgfRaw)
        {
            string titleID = "TITLE";
            string chargeID = "CHARGE";
            string pepMassID = "PEPMASS";
            float protonMass = 1.007F;

            //Open the QuiXML file created
            DataSet ds = new DataSet();
            ds.ReadXmlSchema(XMLschema);
            //ds.ReadXmlSchema(CSVtoQuiXML.Properties.Settings.Default.idSchema);
            ds.ReadXml(QuiXMLfile);

            DataView dv = new DataView(ds.Tables["peptide_match"]);
            DataView dvFiltered = new DataView(ds.Tables["peptide_match"]);

            //sort the dataset by RAWfilename, ScanNumber, charge
            dv.Sort = "RawFileName, FirstScan, Charge";

            DataRowView firstId = dv[0];            
            
            
            FileInfo file = new FileInfo(mgffolder);
            DirectoryInfo di = new DirectoryInfo(mgffolder);
            FileInfo[] files = di.GetFiles("*.mgf");
                        
            string previousMgf = di.FullName + "\\" + dv[0]["RawFileName"].ToString();
            StreamReader sr = new StreamReader(previousMgf);


            string line = "";

            for (int i = 0; i < dv.Count; i++)
            {                
                //Check wether we need to open a new file or not
                if (dv[i]["RawFileName"].ToString() != previousMgf)
                {
                    sr.Close();
                    sr = new StreamReader(di.FullName + "\\" + dv[i]["RawFileName"].ToString());
                    previousMgf = di.FullName + "\\" + dv[i]["RawFileName"].ToString();


                    //read the file, and locate the desired scannumber (MS2 previous to the id in MS3)
                    try
                    {
                        while (sr.Peek() != -1)
                        {
                            line = sr.ReadLine();
                            if (line.ToUpper().Contains(titleID))
                            {
                                //obtain the scannumber of the current spectrum
                                int tentativeScanNumberMS2 = Mgfutils.getScanNumber(line, split_chars, scanField);


                                //We need the PREVIOUS scannumber
                                int tentativeScanNumberMS3 = tentativeScanNumberMS2 + 1;

                                //get the charge of the spectrum
                                int charge = 0;
                                line = sr.ReadLine();
                                if (line.ToUpper().Contains(chargeID))
                                {
                                    string[] charge_sp = line.Split('=', '+');
                                    charge = int.Parse(charge_sp[1].Trim());
                                }

                                //is this spectrum in our list??
                                dvFiltered.RowFilter = "rawfilename = '" + dv[i]["RawFileName"].ToString()
                                                    + "' and firstscan =" + dv[i]["FirstScan"].ToString()
                                                    + " and charge = " + dv[i]["Charge"].ToString();

                                if (dvFiltered.Count > 0)
                                {
                                    bool massLocated = false;
                                    while (!massLocated)
                                    {
                                        line = sr.ReadLine();
                                        if (line.ToUpper().Contains(pepMassID))
                                        {
                                            massLocated = true;
                                            string[] pepMass_split = line.Split('=');
                                            float mz = float.Parse(pepMass_split[1]);
                                            float MHp = mz * charge - (charge - 1) * protonMass;
                                           
                                            dvFiltered[0]["Charge"] = charge;
                                            dvFiltered[0]["PrecursorMass"] = MHp; 
                                           
                                        }
                                    }
                                 
                                }
                                
                                

                            }
                        }

                    }
                    catch { }

                }
            }


            //swapping .mgf to .raw
            if (swapMgfRaw)
            {
                dv.RowFilter = "";
                dv.Sort = "";
                for (int i = 0; i < dv.Count; i++)
                {
                    string strold = dv[i]["RawFileName"].ToString();
                    string strnew = strold.Replace(".mgf", ".RAW");
                    strnew = strnew.Replace(".MGF", ".RAW");
                    dv[i]["RawFileName"] = strnew;
                }
            }


            ds.WriteXml(QuiXMLfile);
            
 
        }

        public static ArrayList getMHplusFromMgf(ArrayList identifications,
                                            string mgffolder,
                                            char[] split_chars,
                                            int scanField) 
        {
            
            string titleID = "TITLE";
            string chargeID = "CHARGE";
            string pepMassID = "PEPMASS";
            float protonMass= 1.007F;

            //Declaration of a comparer for OutData by key (RAWfilename, ScanNumber, charge)
            OutData.OutsComparer cmpKey = new OutData.OutsComparer();
            cmpKey.WhichComparison = OutData.OutsComparer.ComparisonType.key;

            //Sort up the identifications by the key comparer
            identifications.Sort(cmpKey);



            ArrayList identificationsWithMassCorrected = new ArrayList();
            
            FileInfo file = new FileInfo(mgffolder);
            DirectoryInfo di = new DirectoryInfo(mgffolder);
            FileInfo[] files = di.GetFiles("*.mgf");

            OutData firstId = (OutData) identifications[0];

            string previousMgf = di.FullName + "\\" + firstId.RAWFile;
            StreamReader sr = new StreamReader(previousMgf);
 
            
            string line = "";
            
            for(int i=0;i<identifications.Count;i++)
            {
                OutData currId = (OutData) identifications[i];

                //Check wether we need to open a new file or not
                if (currId.RAWFile != previousMgf)
                {
                    sr.Close();
                    sr = new StreamReader(di.FullName + "\\" + currId.RAWFile);
                    previousMgf = di.FullName + "\\" + currId.RAWFile;


                    //read the file, and locate the desired scannumber (MS2 previous to the id in MS3)
                    try
                    {
                        while (sr.Peek() != -1)
                        {
                            line = sr.ReadLine();
                            if (line.ToUpper().Contains(titleID))
                            {
                                //obtain the scannumber of the current spectrum
                                int tentativeScanNumberMS2 = Mgfutils.getScanNumber(line, split_chars, scanField);


                                //We need the PREVIOUS scannumber
                                int tentativeScanNumberMS3 = tentativeScanNumberMS2 + 1;

                                //get the charge of the spectrum
                                int charge = 0;
                                line = sr.ReadLine();
                                if (line.ToUpper().Contains(chargeID))
                                {
                                    string[] charge_sp = line.Split('=','+');
                                    charge = int.Parse(charge_sp[1].Trim());
                                }

                                //is this spectrum in our list??
                                OutData spectrumToFind = new OutData(OutData.databases.Target, OutData.XCorrTypes.normalized);
                                spectrumToFind.RAWFile = currId.RAWFile;
                                spectrumToFind.FirstScan = tentativeScanNumberMS3;
                                spectrumToFind.Charge = currId.Charge;
                                int specFoundPos = identifications.BinarySearch(spectrumToFind, cmpKey);

                                if (specFoundPos > -1)
                                {
                                    bool massLocated = false;
                                    while (!massLocated)
                                    {
                                        line = sr.ReadLine();
                                        if (line.ToUpper().Contains(pepMassID))
                                        {
                                            massLocated = true;
                                            string[] pepMass_split = line.Split('=');
                                            float mz = float.Parse(pepMass_split[1]);
                                            OutData spectrumToSwapMass = (OutData)identifications[specFoundPos];
                                            float MHp = mz*charge-(charge-1)*protonMass;
                                            spectrumToSwapMass.MHp = MHp;
                                            spectrumToSwapMass.Charge = (short)charge;

                                            identificationsWithMassCorrected.Add(spectrumToSwapMass);
                                            identifications.RemoveAt(specFoundPos);
                                        }
                                    }
                                }

                            }
                        }

                    }
                    catch { }

                }
            }



            return identificationsWithMassCorrected;
        }


        

        public static ArrayList substituteExtension(ArrayList _identifications,
                                                    string _oldExtension,
                                                    string _newExtension)
        {
            
            ArrayList substituted = new ArrayList(_identifications.Count);

            for (int i = 0; i < _identifications.Count; i++)
            {
                OutData currId = (OutData)_identifications[i];

                currId.RAWFile = currId.RAWFile.Replace(_oldExtension, _newExtension);

                substituted.Add(currId);
            }



            return substituted;
        }
    
    }
}

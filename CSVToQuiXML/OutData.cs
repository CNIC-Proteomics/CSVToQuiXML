using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Diagnostics;

namespace CSVtoQuiXML
{

    public class Redundance
    {
        public int FASTAIndex
        {
            get { return FASTAIndexVal; }
            set { FASTAIndexVal = value; }
        }
        public string FASTAProteinDescription
        {
            get { return FASTAProteinDescriptionVal; }
            set { FASTAProteinDescriptionVal = value; }
        }

        private int FASTAIndexVal;
        private string FASTAProteinDescriptionVal;
    }


    //[DebuggerDisplay("{dbType},{rnkXc1},{rnkXcRandom},FDR={FDR}")]
    //[DebuggerDisplay("{dbType},rnkXc1={rnkXc1},pRatio={pRatio}")]
    [DebuggerDisplay("{RAWFile},{FirstScan},{Charge},{MHp}")]
    //[DebuggerDisplay("pRatioT={pRatioTarget},pRatioD={pRatioDecoy}")]
    //[DebuggerDisplay("rnkT1={rnkXc1},rnkT2={rnkXcRandom}")]
    public class OutData : IComparable
    {
        public OutData(OutData.databases db, OutData.XCorrTypes _XCorrType)
        {
            dbType = db;
            FileNameVal = "";
            RAWFileVal = "";
            ProteinDescriptionVal = "";
            SequenceVal = "";
            xcorrType = _XCorrType;
            Score = double.NaN;

        }

        public override string ToString()
        {
            string s = Xcorr1Val.ToString(); //FileNameVal.ToString();
            return s;
        }

        public int FirstScan
        {
            get { return FirstScanVal; }
            set { FirstScanVal = value; }
        }
        public int LastScan
        {
            get { return LastScanVal; }
            set { LastScanVal = value; }
        }
        public short Charge
        {
            get { return ChargeVal; }
            set { ChargeVal = value; }
        }
        public float LowestSpScore
        {
            get { return LowestSpScoreVal; }
            set { LowestSpScoreVal = value; }
        }
        public double PrecursorMass
        {
            get { return PrecursorMassVal; }
            set { PrecursorMassVal = value; }
        }
        public float pI
        {
            get { return pIVal; }
            set { pIVal = value; }
        }
        public float TotalIntensity
        {
            get { return TotalIntensityVal; }
            set { TotalIntensityVal = value; }
        }

        public float Xcorr1
        {
            get { return Xcorr1Val; }
            set
            {
                Xcorr1SearchVal = value;
                switch (xcorrType)
                {
                    case XCorrTypes.regular:
                        Xcorr1Val = value;
                        break;
                    case XCorrTypes.normalized:
                        float R = 1;
                        if (Charge < 3)
                        {
                            R = 1.0F;
                        }
                        else
                        {
                            R = 1.22F;
                        }

                        Xcorr1Val = (float)(Math.Log10((double)value / (double)R) / Math.Log10(2 * Mass / (double)110));

                        break;
                }

            }
        }
        public float Xcorr2
        {
            get { return Xcorr2Val; }
            set
            {
                Xcorr2SearchVal = value;
                switch (xcorrType)
                {
                    case XCorrTypes.regular:
                        Xcorr2Val = value;
                        break;
                    case XCorrTypes.normalized:
                        float R = 1;
                        if (Charge < 3)
                        {
                            R = 1.0F;
                        }
                        else
                        {
                            R = 1.22F;
                        }

                        Xcorr2Val = (float)(Math.Log10((double)value / (double)R) / Math.Log10(2 * Mass / (double)110));

                        break;
                }

            }
        }
        public float Xcorr3
        {
            get { return Xcorr3Val; }
            set
            {
                Xcorr3SearchVal = value;
                switch (xcorrType)
                {
                    case XCorrTypes.regular:
                        Xcorr3Val = value;
                        break;
                    case XCorrTypes.normalized:
                        float R = 1;
                        if (Charge < 3)
                        {
                            R = 1.0F;
                        }
                        else
                        {
                            R = 1.22F;
                        }

                        Xcorr3Val = (float)(Math.Log10((double)value / (double)R) / Math.Log10(2 * Mass / (double)110));

                        break;
                }

            }
        }
        public float Xcorr4
        {
            get { return Xcorr4Val; }
            set
            {
                Xcorr4SearchVal = value;
                switch (xcorrType)
                {
                    case XCorrTypes.regular:
                        Xcorr4Val = value;
                        break;
                    case XCorrTypes.normalized:
                        float R = 1;
                        if (Charge < 3)
                        {
                            R = 1.0F;
                        }
                        else
                        {
                            R = 1.22F;
                        }

                        Xcorr4Val = (float)(Math.Log10((double)value / (double)R) / Math.Log10(2 * Mass / (double)110));

                        break;
                }

            }
        }

        public float Xcorr1Search
        {
            get { return Xcorr1SearchVal; }
        }
        public float Xcorr2Search
        {
            get { return Xcorr2SearchVal; }
        }
        public float Xcorr3Search
        {
            get { return Xcorr3SearchVal; }
        }
        public float Xcorr4Search
        {
            get { return Xcorr4SearchVal; }
        }

        public string FileName
        {
            get { return FileNameVal; }
            set
            {
                string fil = value;
                int first = fil.LastIndexOf('\\') + 1;
                int length = fil.Length - first;
                FileNameVal = fil.Substring(first, length).Trim(); ;
            }
        }
        public string RAWFile
        {
            get { return RAWFileVal; }
            set
            {
                string fil = value;
                int first = fil.LastIndexOf('\\') + 1;
                int length = fil.Length - first;
                RAWFileVal = fil.Substring(first, length).Trim();

            }
        }
        public float DeltaCn
        {
            get { return DeltaCnVal; }
            set { DeltaCnVal = value; }
        }
        public int FASTAIndex
        {
            get { return FASTAIndexVal; }
            set { FASTAIndexVal = value; }
        }
        public short IonsCompared
        {
            get { return IonsComparedVal; }
            set { IonsComparedVal = value; }
        }
        public short IonsMatched
        {
            get { return IonsMatchedVal; }
            set { IonsMatchedVal = value; }
        }
        public double Mass
        {
            get { return MassVal; }
            set { MassVal = value; }
        }
        public int MatchRank
        {
            get { return MatchRankVal; }
            set { MatchRankVal = value; }
        }
        public string ProteinDescription
        {
            get { return ProteinDescriptionVal; }
            set { ProteinDescriptionVal = value; }
        }
        public float ProteinMass
        {
            get { return ProteinMassVal; }
            set { ProteinMassVal = value; }
        }
        public short ProteinsWithPeptide
        {
            get { return ProteinsWithPeptideVal; }
            set { ProteinsWithPeptideVal = value; }
        }
        public string Sequence
        {
            get { return SequenceVal; }
            set { SequenceVal = value; }
        }
        public float Sp
        {
            get { return SpVal; }
            set { SpVal = value; }
        }
        public short SpRank
        {
            get { return SpRankVal; }
            set { SpRankVal = value; }
        }

        public float MHp
        {
            get { return MHpVal; }
            set { MHpVal = value; }
        }
        public float deltaM
        {
            get { return deltaMVal; }
            set { deltaMVal = value; }
        }

        public float XcTeoric
        {
            get { return XcTeoricVal; }
            set { XcTeoricVal = value; }
        }
        public float Ppep
        {
            get { return ppepVal; }
            set { ppepVal = value; }
        }


        
        public Redundance[] Redundances
        {
            get { return RedundancesVal; }
            set { RedundancesVal = value; }
        }

        public float XcorrRandom
        {
            get { return XcorrRandomVal; }
            set { XcorrRandomVal = value; }
        }
        public int rnkXc1
        {
            get { return rnkXc1Val; }
            set { rnkXc1Val = value; }
        }
        public int rnkXcRandom
        {
            get { return rnkXcRandomVal; }
            set { rnkXcRandomVal = value; }
        }
        public double pRatio
        {
            get { return pRatioVal; }
            set { pRatioVal = value; }
        }
        public double pRatioTarget
        {
            get { return pRatioTargetVal; }
            set { pRatioTargetVal = value; }
        }
        public double pRatioDecoy
        {
            get { return pRatioDecoyVal; }
            set { pRatioDecoyVal = value; }
        }
        public float XCorr1SearchOther
        {
            get { return XCorr1SearchOtherVal; }
            set { XCorr1SearchOtherVal = value; }
        }
        public double FDR
        {
            get { return FDRVal; }
            set { FDRVal = value; }
        }
        public OutData.databases dbType
        {
            get { return dbTypeVal; }
            set { dbTypeVal = value; }
        }
        public OutData.XCorrTypes xcorrType
        {
            get { return xcorrTypeVal; }
            set { xcorrTypeVal = value; }
        }

        public double Score
        {
            get { return ScoreVal; }
            set { ScoreVal = value; }
        }

        private int FirstScanVal;
        private int LastScanVal;
        private short ChargeVal;
        private float LowestSpScoreVal;
        private double PrecursorMassVal;
        private float pIVal;
        private float TotalIntensityVal;
        private float Xcorr1Val;
        private float Xcorr2Val;
        private float Xcorr3Val;
        private float Xcorr4Val;
        private float Xcorr1SearchVal;
        private float Xcorr2SearchVal;
        private float Xcorr3SearchVal;
        private float Xcorr4SearchVal;
        private string FileNameVal;
        private string RAWFileVal;
        private float DeltaCnVal;
        private int FASTAIndexVal;
        private short IonsComparedVal;
        private short IonsMatchedVal;
        private double MassVal;
        private int MatchRankVal;
        private string ProteinDescriptionVal;
        private float ProteinMassVal;
        private short ProteinsWithPeptideVal;
        private string SequenceVal;
        private float SpVal;
        private short SpRankVal;
        private Redundance[] RedundancesVal;
        private double ScoreVal;

        private float MHpVal;
        private float deltaMVal;
        private float XcTeoricVal;
        private float ppepVal;

        private float XcorrRandomVal;
        private int rnkXc1Val;
        private int rnkXcRandomVal;
        private double pRatioVal;
        private double pRatioTargetVal;
        private double pRatioDecoyVal;
        private float XCorr1SearchOtherVal;
        private double FDRVal;
        public enum databases
        {
            Decoy,
            Target
        }
        private OutData.databases dbTypeVal;
        public enum XCorrTypes
        {
            normalized,
            regular
        }
        private OutData.XCorrTypes xcorrTypeVal;


        public int CompareTo(Object rhs)
        {
            OutData r = (OutData)rhs;
            return this.Xcorr1.CompareTo(r.Xcorr1);
        }

        // Special implementation to be called by custom comparer 
        public int CompareTo(
           OutData rhs,
           OutData.OutsComparer.ComparisonType which)
        {
            switch (which)
            {
                case OutData.OutsComparer.ComparisonType.Xcorr1:
                    return this.Xcorr1.CompareTo(rhs.Xcorr1);
                case OutData.OutsComparer.ComparisonType.XcorrRandomVSXcorr1:
                    return this.Xcorr1.CompareTo(rhs.XcorrRandom);
                case OutData.OutsComparer.ComparisonType.XcorrRandomVSXcorrRandom:
                    return this.XcorrRandom.CompareTo(rhs.XcorrRandom);
                case OutData.OutsComparer.ComparisonType.pRatio:
                    return this.pRatio.CompareTo(rhs.pRatio);
                case OutData.OutsComparer.ComparisonType.FDR:
                    return this.FDR.CompareTo(rhs.FDR);
                case OutData.OutsComparer.ComparisonType.RAWfile:
                    return this.RAWFile.CompareTo(rhs.RAWFile);
                case OutData.OutsComparer.ComparisonType.key:
                    {

                        int result = 0;
                        result = this.RAWFile.CompareTo(rhs.RAWFile);
                        if (result != 0)
                        {
                            return result;
                        }
                        result = this.FirstScan.CompareTo(rhs.FirstScan);
                        if (result != 0)
                        {
                            return result;
                        }
                        result = this.Charge.CompareTo(rhs.Charge);
                        if (result != 0)
                        {
                            return result;
                        }
                        return result;
                    }
                case OutData.OutsComparer.ComparisonType.RnkXc1:
                    return this.rnkXc1.CompareTo(rhs.rnkXc1);
            }
            return 0;

        }


        // nested class which implements IComparer 
        public class OutsComparer : IComparer
        {
            // enumeration of comparsion types 
            public enum ComparisonType
            {
                Xcorr1,
                XcorrRandomVSXcorr1,
                XcorrRandomVSXcorrRandom,
                RAWfile,
                key,
                pRatio,
                FDR,
                RnkXc1
            };

            // Tell the OutData objects to compare themselves 
            public int Compare(object lhs, object rhs)
            {
                OutData l = (OutData)lhs;
                OutData r = (OutData)rhs;
                return l.CompareTo(r, WhichComparison);
            }

            public OutData.OutsComparer.ComparisonType WhichComparison
            {
                get
                {
                    return whichComparisonVal;
                }
                set
                {
                    whichComparisonVal = value;
                }
            }

            // private state variable 
            private OutData.OutsComparer.ComparisonType whichComparisonVal;
        }




    }



}

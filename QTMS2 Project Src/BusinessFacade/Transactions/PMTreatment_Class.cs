using System;
using System.Collections.Generic;
using System.Text;
using DataFacade;
using System.Data;
using System.Data.SqlClient;

namespace BusinessFacade.Transactions
{
    public class PMTreatment_Class
    {
        #region Variables
        private long PMTransID;
        private long Quantity;
        private long PMTreatID;
        private long PMSupplierCOCID;
        private long FGMethodNo;
       
        
        private string Description;
        private string Comment;
        private string LotSize;
        private string TestName;
        private string InspectionMethod;
        private string Status;
        private string AQLReading;
        private string AQLZReading;
        private string AQLCReading;
        private string AQLMReading;
        private string AQLM1Reading;
     

        private int CurrentFlag;
        private int Treatmented;
        private int TreatmentDone;
        private int SampleSizeReading;
        private int LoginID;


        #endregion

        #region Properties

        public int  currentflag
        {
            get { return CurrentFlag; }

            set { CurrentFlag = value; }

        }

        public int loginid
        {
            get { return LoginID; }

            set { LoginID = value; }

        }


        public int samplesizereading
        {
            get { return SampleSizeReading; }

            set { SampleSizeReading = value; }

        }


        public int treatmented
        {
            get { return Treatmented; }

            set { Treatmented = value; }

        }

        public int treatmentdone
        {
            get { return TreatmentDone; }

            set { TreatmentDone = value; }

        }

        
        
        
        public long pmtransid
        {
            get { return PMTransID; }

            set { PMTransID = value; }

        }

        public long fgmethodno
        {
            get { return FGMethodNo; }

            set { FGMethodNo = value; }

        }

        public long pmsuppliercocid
        {
            get { return PMSupplierCOCID; }

            set { PMSupplierCOCID = value; }

        }

        public long quantity
        {
            get { return Quantity; }

            set { Quantity = value; }

        }


        public long pmtreatid
        {
            get { return PMTreatID; }

            set { PMTreatID = value; }

        }


        public string lotsize
        {
            get { return LotSize; }

            set { LotSize = value; }

        }

       
        public string testname
        {
            get { return TestName; }
            set { TestName = value; }
        }

        public string status
        {
            get { return Status; }
            set { Status = value; }
        }

     
        public string description
        {
            get { return Description; }

            set { Description = value; }

        }

        public string comment
        {
            get { return Comment; }

            set { Comment = value; }

        }

        public string inspectionmethod
        {
            get { return InspectionMethod; }
            set { InspectionMethod = value; }
        }

        public string aqlreading
        {
            get { return AQLReading; }
            set { AQLReading = value; }
        }

        public string aqlzreading
        {
            get { return AQLZReading; }
            set { AQLZReading = value; }
        }

        public string aqlcreading
        {
            get { return AQLCReading; }
            set { AQLCReading = value; }
        }


        public string aqlmreading
        {
            get { return AQLMReading; }
            set { AQLMReading = value; }
        }


        public string aqlm1reading
        {
            get { return AQLM1Reading; }
            set { AQLM1Reading = value; }
        }


        

        #endregion

        #region Functions

        

        

        #endregion
    }
}

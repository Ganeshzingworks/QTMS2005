using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Configuration;
using System.Reflection;
using QTMS.Tools;
using QTMS.User_Permissions;
using BusinessFacade.Transactions;
using QTMS.Forms;
using QTMS.Reports_Forms;
using System.Security.Cryptography;
using System.Text;
using System.Net;
using System.IO;
using QTMS.Scoop;
using System.Threading;
using QTMS.OOS;
using QTMS.LineValidation;
using System.IO.Ports;
using System.Deployment.Application;
using QTMS.Mettler;

namespace QTMS
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class FrmMain : System.Windows.Forms.Form
    {
        #region "MENU"
        private ToolStripButton toolStripButton1;
        private MenuStrip menuStripADMINH;
        private ToolStripMenuItem aDMINToolStripMenuItem;
        private MenuStrip menuStripFDAH;
        private ToolStripMenuItem fDAHmasterToolStripMenuItem;
        private MenuStrip menuStripPMH;
        private ToolStripMenuItem pMHMasterToolStripMenuItem;
        private MenuStrip menuStripRMH;
        private ToolStripMenuItem rMHMasterToolStripMenuItem;
        private MenuStrip menuStripQTMSH;
        private ToolStripMenuItem QTMSHmasterToolStripMenuItem;
        private ToolStripMenuItem QTMSHtransactionToolStripMenuItem;
        private ToolStripMenuItem QTMSHmodificationToolStripMenuItem;
        private ToolStripMenuItem FDAHtransactionToolStripMenuItem;
        private ToolStripMenuItem FDAHmodificationToolStripMenuItem;
        private ToolStripMenuItem PMHtransactionToolStripMenuItem;
        private ToolStripMenuItem PMHmodificationToolStripMenuItem;
        private ToolStripMenuItem RMHtransactionToolStripMenuItem;
        private ToolStripMenuItem RMHmodificationToolStripMenuItem;
        private ToolStripMenuItem testMasterToolStripMenuItem;
        private ToolStripMenuItem bulkTechnicalFamilyMasterToolStripMenuItem1;
        private ToolStripMenuItem formulaMasterToolStripMenuItem;
        private ToolStripMenuItem packingFamilyMasterToolStripMenuItem;
        private ToolStripMenuItem lineMasterToolStripMenuItem;
        private ToolStripMenuItem tankMasterToolStripMenuItem;
        private ToolStripMenuItem vesselMasterToolStripMenuItem;
        private ToolStripMenuItem preservativeMasterToolStripMenuItem1;
        private ToolStripMenuItem preservativeMethodMasterToolStripMenuItem1;
        private ToolStripMenuItem finishGoodMasterToolStripMenuItem;
        private ToolStripMenuItem fGFamilyMethodMasterToolStripMenuItem;
        private ToolStripMenuItem finishGoodMethodMasterToolStripMenuItem;
        private ToolStripMenuItem fGPhysicoChemicalTestMethodMasterToolStripMenuItem;
        private ToolStripMenuItem fGGlobalFamilyMasterToolStripMenuItem1;
        private ToolStripMenuItem bulkTestDetailsToolStripMenuItem;
        private ToolStripMenuItem lineSamplePackingDetailsToolStripMenuItem;
        private ToolStripMenuItem lineSampleDetailsToolStripMenuItem;
        private ToolStripMenuItem preservativeTestToolStripMenuItem;
        private ToolStripMenuItem microbiologyTestToolStripMenuItem;
        private ToolStripMenuItem kitDetailsToolStripMenuItem2;
        private ToolStripMenuItem finishedGoodTestToolStripMenuItem;
        private ToolStripMenuItem finishedGoodTreatmentToolStripMenuItem;
        private ToolStripMenuItem bulkTestDetailsToolStripMenuItem1;
        private ToolStripMenuItem lineSamplePackingToolStripMenuItem;
        private ToolStripMenuItem lineSampleDetailsToolStripMenuItem1;
        private ToolStripMenuItem preservativeTestToolStripMenuItem1;
        private ToolStripMenuItem microbiologyTestToolStripMenuItem1;
        private ToolStripMenuItem kitDetailsToolStripMenuItem3;
        private ToolStripMenuItem finishedGoodTestToolStripMenuItem2;
        private ToolStripMenuItem toolStripMenuItem8;
        private ToolStripMenuItem PMHReportstoolStripMenuItem;
        private ToolStripMenuItem RMHReportstoolStripMenuItem;
        private ToolStripMenuItem QTMSHDossiertoolStripMenuItem;
        private ToolStripMenuItem QTMSHTDBtoolStripMenuItem;
        private ToolStripMenuItem QTMSHSummarytoolStripMenuItem;
        private ToolStripMenuItem QTMSHDetailtoolStripMenuItem;
        private ToolStripMenuItem QTMSHMasterReporttoolStripMenuItem;
        private ToolStripMenuItem rMSupplierMasterToolStripMenuItem1;
        private ToolStripMenuItem rMFamilyMasterToolStripMenuItem1;
        private ToolStripMenuItem rMParameterMasterToolStripMenuItem1;
        private ToolStripMenuItem rMParameterDescriptionMasterToolStripMenuItem;
        private ToolStripMenuItem rMCodeMasterToolStripMenuItem1;
        private ToolStripMenuItem rMCodeTestMethodMasterToolStripMenuItem1;
        private ToolStripMenuItem rMSamplingToolStripMenuItem1;
        private ToolStripMenuItem rMTransactionToolStripMenuItem1;
        private ToolStripMenuItem fDAMasterToolStripMenuItem;
        private ToolStripMenuItem fDATransactionToolStripMenuItem;
        private ToolStripMenuItem pMSupplierMasterToolStripMenuItem;
        private ToolStripMenuItem pMFamilyMasterToolStripMenuItem;
        private ToolStripMenuItem pMCodeMasterToolStripMenuItem;
        private ToolStripMenuItem pMTestMasterToolStripMenuItem1;
        private ToolStripMenuItem pMTestMethodMasterToolStripMenuItem1;
        private ToolStripMenuItem pMTransactionToolStripMenuItem2;
        private ToolStripMenuItem pMStatusChangeToolStripMenuItem;
        private ToolStripMenuItem pMTreatmentToolStripMenuItem;
        private ToolStripMenuItem rMStatusChangeToolStripMenuItem1;
        private ToolStripMenuItem rMValidityReportToolStripMenuItem1;
        private ToolStripMenuItem formulaHistoryReportToolStripMenuItem;
        private ToolStripMenuItem bulkTestReportToolStripMenuItem1;
        private ToolStripMenuItem testMethodMasterReportToolStripMenuItem1;
        private ToolStripMenuItem bulkTDBReportToolStripMenuItem;
        private ToolStripMenuItem microbiologyTDBReportToolStripMenuItem;
        private ToolStripMenuItem globalFGTDBReportToolStripMenuItem1;
        private ToolStripMenuItem bulkTestDetailsReportToolStripMenuItem;
        private ToolStripMenuItem linePackingDetailsReportToolStripMenuItem;
        private ToolStripMenuItem lineSampleSummaryReportToolStripMenuItem;
        private ToolStripMenuItem microbiologySummaryReportToolStripMenuItem;
        private ToolStripMenuItem finishedGoodTransactionReportToolStripMenuItem;
        private ToolStripMenuItem finishedGoodSummaryReportToolStripMenuItem1;
        private ToolStripMenuItem lotDossierSummaryReportToolStripMenuItem;
        private ToolStripMenuItem bulkAnalysisReportToolStripMenuItem1;
        private ToolStripMenuItem bulkTransactionReportToolStripMenuItem1;
        private ToolStripMenuItem lineSampleDetailsReportToolStripMenuItem;
        private ToolStripMenuItem preservativeTestReportToolStripMenuItem;
        private ToolStripMenuItem microbiologyTestReportToolStripMenuItem;
        private ToolStripMenuItem fGAnalysisReportToolStripMenuItem1;
        private ToolStripMenuItem fGTestMethodMasterReportToolStripMenuItem2;
        private ToolStripMenuItem pMTestMethodMasterReportToolStripMenuItem;
        private ToolStripMenuItem pMTransactionReportToolStripMenuItem;
        private ToolStripMenuItem rMTestMethodMasterReportToolStripMenuItem1;
        private ToolStripMenuItem rMTransactionReportToolStripMenuItem1;
        private ToolStripMenuItem rMTDBReportToolStripMenuItem1;
        private ToolStripMenuItem pendingRMReportToolStripMenuItem;
        private ToolStripMenuItem rMAnalysisReportToolStripMenuItem1;
        private ToolStripMenuItem rMValidityAnalysisReportToolStripMenuItem1;
        private ToolStripMenuItem preLotDossierReportToolStripMenuItem;
        private ToolStripMenuItem lotDossierReportToolStripMenuItem;
        private ToolStripMenuItem lotDossierDetailReportToolStripMenuItem1;
        private ToolStripMenuItem fillingAndPackingQualityReportToolStripMenuItem1;
        private ToolStripMenuItem oxidationHairDyeToolStripMenuItem;
        private ToolStripMenuItem pMRejectionDetailReportToolStripMenuItem1;
        private ToolStripMenuItem pMTDBReportToolStripMenuItem1;
        private ToolStripMenuItem pMSupplierTDBReportToolStripMenuItem1;
        private ToolStripMenuItem pMFamilyTDBReportToolStripMenuItem1;
        private ToolStripMenuItem pMAnalysisToolStripMenuItem1;
        private ToolStripMenuItem pMCOCListToolStripMenuItem1;
        private ToolStripMenuItem formulaDescriptionReportToolStripMenuItem;
        private ToolStripMenuItem pMCodeDescriptionReportToolStripMenuItem;
        private ToolStripMenuItem rMCodeHistoryReportToolStripMenuItem;
        private ToolStripMenuItem fGLineDetailsTDBReportToolStripMenuItem;
        private ToolStripMenuItem finishedGoodNonBPCReportToolStripMenuItem;
        private ToolStripMenuItem bulkTestNonBPCReportToolStripMenuItem;
        private ToolStripMenuItem pMModificationToolStripMenuItem;
        private ToolStripMenuItem rMSupplierTDBReportToolStripMenuItem;
        private ToolStripMenuItem sFDetailsToolStripMenuItem;
        private ToolStripMenuItem finishedGoodTestSFPackingToolStripMenuItem;
        private ToolStripMenuItem packingTestMasterToolStripMenuItem;
        private ToolStripMenuItem rejectionNoteFGToolStripMenuItem;
        private ToolStripMenuItem pMRejectionNoteToolStripMenuItem;
        private ToolStripMenuItem bMRSummaryReportToolStripMenuItem;
        private ToolStripMenuItem bMRLotDossierReportToolStripMenuItem;
        private ToolStripMenuItem fGAnalysisBMRReportToolStripMenuItem;
        private ToolStripMenuItem bMRPreSummaryReportToolStripMenuItem;
        private ToolStripMenuItem fGFormulaHistoryReportToolStripMenuItem;
        private ToolStripMenuItem qStatusSummaryReportToolStripMenuItem;
        private ToolStripMenuItem fGReportToolStripMenuItem;
        private ToolStripMenuItem bulkPendingReportToolStripMenuItem;
        private ToolStripMenuItem fGBulkPendingReportToolStripMenuItem;
        private TableLayoutPanel tableLayoutPanel1;
        private Button btnOTHER;
        private Button btnFDA;
        private Button btnPM;
        private Button btnRM;
        private Button btnADMIN;
        private Button btnFG;
        private Panel panel1;
        private Panel panelMenu;
        private MenuStrip menuStripOther;
        private ToolStripMenuItem OtherTransactionToolStripMenuItem;
        private ToolStripMenuItem consumerComplaintToolStripMenuItem;
        private ToolStripMenuItem waterAnalysisToolStripMenuItem1;
        private ToolStripMenuItem compatibilityToolStripMenuItem1;
        private ToolStripMenuItem userManagementToolStripMenuItem;
        private Panel panel3;
        private Panel panel2;
        private Button btnLogin;
        private ToolStripMenuItem OtherReportstoolStripMenuItem;
        private ToolStripMenuItem consumerComplaintSummaryReportToolStripMenuItem;
        private ToolStripMenuItem consumerComplaintAnalysisReportToolStripMenuItem1;
        private ToolStripMenuItem consumerComplaintTDBReportToolStripMenuItem1;
        private ToolStripMenuItem waterAnalysisReportToolStripMenuItem1;
        private ToolStripMenuItem monthlyWaterAnalysisReportToolStripMenuItem;
        private ToolStripMenuItem fDAModificationToolStripMenuItem;
        private ToolStripMenuItem bulkTestNewLaunchReportToolStripMenuItem;
        private ToolStripMenuItem bulkTestNonValidatedReportToolStripMenuItem;
        private ToolStripMenuItem pMNewLaunchReportToolStripMenuItem;
        private ToolStripMenuItem pMSupplierReportReceivedReportToolStripMenuItem;
        private ToolStripMenuItem preservativeSummaryReportToolStripMenuItem;
        private ToolStripMenuItem analysisSummaryReportToolStripMenuItem;
        private ToolStripMenuItem fGReleaseDossierToolStripMenuItem;
        private ToolStripMenuItem fGReleaseDossierToolStripMenuItem1;
        private ToolStripMenuItem rMSupllierReportReceivedReportToolStripMenuItem;
        private ToolStripMenuItem pMDefectNoteToolStripMenuItem;
        private ToolStripMenuItem pMDefectNoteToolStripMenuItem1;
        private ToolStripMenuItem rMCodeRetainerLabelToolStripMenuItem;
        private ToolStripMenuItem pMCOCTransactionReportToolStripMenuItem;
        private ToolStripMenuItem adjustmentTransactionToolStripMenuItem;
        private ToolStripMenuItem pMReanalysisToolStripMenuItem;
        private ToolStripMenuItem userPermissionToolStripMenuItem;
        private ToolStripMenuItem referenceSampleManageToolStripMenuItem;
        private ToolStripMenuItem OthermasterToolStripMenuItem;
        private ToolStripMenuItem retainerLocationMasterToolStripMenuItem1;
        private ToolStripMenuItem instrumentMasterToolStripMenuItem1;
        private ToolStripMenuItem countryMasterToolStripMenuItem;
        private ToolStripMenuItem locationMasterToolStripMenuItem;
        private ToolStripMenuItem oEEToolStripMenuItem;
        private ToolStripMenuItem oEETransactionsToolStripMenuItem;
        private ToolStripMenuItem oEEActivityMasterToolStripMenuItem;
        private ToolStripMenuItem activityRelationMasterToolStripMenuItem;
        private ToolStripMenuItem oEETMTMasterToolStripMenuItem;
        private ToolStripMenuItem oEEAnalysisReportToolStripMenuItem;
        private ToolStripMenuItem rMSafetySymbolMasterToolStripMenuItem;
        private ToolStripMenuItem rMRetainerLocationMasterToolStripMenuItem;
        private ToolStripMenuItem oEEModificationToolStripMenuItem;
        private ToolStripMenuItem sFDetailsToolStripMenuItem1;
        private ToolStripMenuItem rMMicrobiologyTestToolStripMenuItem;
        private ToolStripMenuItem rMMicrobiologyTestReportToolStripMenuItem;
        private ToolStripMenuItem rMRetainerLocationReportToolStripMenuItem;
        private Label lblMenuName;
        private ToolStripMenuItem rMMicrobiologyTestModificationToolStripMenuItem;
        private ToolStripMenuItem pMDefectNoteDetailReportToolStripMenuItem;
        private ToolStripMenuItem mOMMasterToolStripMenuItem;
        private ToolStripMenuItem mOMReportToolStripMenuItem;
        private ToolStripMenuItem AnnextureTankMaster;
        private ToolStripMenuItem QualityIssueMaster;
        private ToolStripMenuItem DocumentMaster;
        private ToolStripMenuItem AgitationMaster;
        private ToolStripMenuItem referenceSampleManagementRMToolStripMenuItem;
        private ToolStripMenuItem fGRefSampleMgmtDetailReportToolStripMenuItem;
        private ToolStripMenuItem rMRefSampleMgmtDetailReportToolStripMenuItem;
        private ToolStripMenuItem retainerLocationReportToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem imageComparisionToolStripMenuItem;
        private ToolStripMenuItem oEEDetailProcessReportToolStripMenuItem;
        private ToolStripMenuItem imageComparisonToolStripMenuItem;
        private ToolStripMenuItem autoLineOEETransationToolStripMenuItem;
        private ToolStripMenuItem lineOEEActivityMasterToolStripMenuItem;
        private ToolStripMenuItem mOMSignaRoleToolStripMenuItem;
        private ToolStripMenuItem uploadLineOEEMasterToolStripMenuItem;
        private ToolStripMenuItem lineOEEActivityRelationMasterToolStripMenuItem;
        private ToolStripMenuItem lineOEEDataJunctionReportToolStripMenuItem;
        private ToolStripMenuItem lineOEEFGMasterToolStripMenuItem;
        private ToolStripMenuItem viewUploadLineOEEMasterToolStripMenuItem;
        private ToolStripMenuItem lineOEEUPTdbReportToolStripMenuItem;
        private ToolStripMenuItem lineOEEGraphReportToolStripMenuItem;
        private ToolStripMenuItem rMParameterwiseReportToolStripMenuItem;
        private ToolStripMenuItem rMControlTypeReportToolStripMenuItem;
        private ToolStripMenuItem groupMasterToolStripMenuItem;
        private ToolStripMenuItem userGroupMasterRelationToolStripMenuItem;
        private ToolStripMenuItem refSampleMgmtSummaryReportToolStripMenuItem;
        private ToolStripMenuItem fGReferenceManagementToolStripMenuItem1;
        private ToolStripMenuItem physicoChemicalWaterAToolStripMenuItem;
        private ToolStripMenuItem pMSupplierCorrectiveNoteToolStripMenuItem;
        private ToolStripMenuItem hPLCReferenceMgmtToolStripMenuItem;
        private ToolStripMenuItem pMCOCHistoryReportToolStripMenuItem;
        private ToolStripMenuItem reagentMgtToolStripMenuItem;
        private ToolStripMenuItem reagentMasterToolStripMenuItem;
        private ToolStripMenuItem reagentTransactionToolStripMenuItem;
        private ToolStripMenuItem reaToolStripMenuItem;
        private ToolStripMenuItem reagentConsumptionToolStripMenuItem;
        private ToolStripMenuItem dimensionParameterMasterToolStripMenuItem;
        private ToolStripMenuItem reagentModificationToolStripMenuItem;
        private ToolStripMenuItem reagentAvailableStockReportToolStripMenuItem;
        private ToolStripMenuItem reagentDetailsReportToolStripMenuItem;
        private ToolStripMenuItem reagentReorderLevelReportToolStripMenuItem;
        private ToolStripMenuItem lastProductionFormulaReportToolStripMenuItem;
        private ToolStripMenuItem aOCSheetToolStripMenuItem;
        private ToolStripMenuItem nAtureofACRefMasterToolStripMenuItem;
        private ToolStripMenuItem aCMaterialRefMasterToolStripMenuItem;
        private ToolStripMenuItem fGPendingReportToolStripMenuItem;
        private ToolStripMenuItem changePasswordToolStripMenuItem;
        private ToolStripMenuItem fGBulkRejectionDetailsReportToolStripMenuItem;
        private ToolStripMenuItem rMCodeReportToolStripMenuItem;
        private ToolStripMenuItem consumerComplaintTDBYearlyReportToolStripMenuItem;
        private ToolStripMenuItem fGRefToolStripMenuItem;
        private ToolStripMenuItem bAGManagementToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem2;
        private MenuStrip menuStripScoop;
        private ToolStripMenuItem masterToolStripMenuItem;
        private ToolStripMenuItem lineSamplingPointMasterToolStripMenuItem;
        private ToolStripMenuItem transactionToolStripMenuItem;
        private ToolStripMenuItem uPToolStripMenuItem;
        private ToolStripMenuItem scoopTestMethodMasterToolStripMenuItem;
        private ToolStripMenuItem lineSamplingPointInfoToolStripMenuItem1;
        private ToolStripMenuItem uPAuthorityToolStripMenuItem;
        private ToolStripMenuItem qualityAuthorityToolStripMenuItem;
        private ToolStripMenuItem tDBToolStripMenuItem;
        private ToolStripMenuItem globalFGTDBToolStripMenuItem;
        private ToolStripMenuItem fGLineTDBReportToolStripMenuItem;
        private ToolStripMenuItem detailToolStripMenuItem;
        private ToolStripMenuItem fGAnalysisReportToolStripMenuItem;
        private ToolStripMenuItem bagViewertoolStrip;
        private ToolStripMenuItem rMAlignmentReportToolStripMenuItem;
        private ToolStripMenuItem plantwiseWaterAnalysisToolStripMenuItem;
        private ToolStripMenuItem pMComponentHistoryReportToolStripMenuItem;
        private ToolStripMenuItem fGAnalysisNotDoneReportToolStripMenuItem;
        private ToolStripMenuItem rMRejectionNoteToolStripMenuItem;
        private ToolStripMenuItem Mnu_fGSupplierMaster;
        private ToolStripMenuItem bulkTestDeailsSubcontractToolStripMenuItem;
        private ToolStripMenuItem finishedGoodTestQuality1ToolStripMenuItem;
        private Button button1;
        private Button btnSubCon;
        private MenuStrip menuStripSubCon;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem toolStripMenuItem4;
        private ToolStripMenuItem toolStripMenuItem7;
        private ToolStripMenuItem toolStripMenuItem9;
        private ToolStripMenuItem toolStripMenuItem10;
        private ToolStripMenuItem toolStripMenuItem11;
        private ToolStripMenuItem toolStripMenuItem12;
        private ToolStripMenuItem toolStripMenuItem13;
        private ToolStripMenuItem toolStripMenuItem14;
        private ToolStripMenuItem toolStripMenuItem15;
        private ToolStripMenuItem toolStripMenuItem16;
        private ToolStripMenuItem toolStripMenuItem17;
        private ToolStripMenuItem toolStripMenuItem18;
        private ToolStripMenuItem modificationToolStripMenuItem;
        private ToolStripMenuItem finishGoodTestToolStripMenuItem;
        private ToolStripMenuItem fGTransactionAnalysisReportToolStripMenuItem;
        private ToolStripMenuItem settingToolStripMenuItem;
        private ToolStripMenuItem tRRMCodeHalalReport;
        private ToolStripMenuItem retainerLocationReportToolStripMenuItem1;
        private ToolStripMenuItem finishedGoodSummaryReportToolStripMenuItem;
        private ToolStripMenuItem fGMfgWoAnalysisReportToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem5;
        private ToolStripMenuItem aOCReportToolStripMenuItem;
        private ToolStripMenuItem testFormToolStripMenuItem;
        private MenuStrip menuStripLineValidation;
        private Button btnLineValidation;
        private ToolStripMenuItem toolStripMenuItem20;
        private ToolStripMenuItem LineValidationtoolStripMenuItem;
        private ToolStripMenuItem LayoutstoolStripMenuItem;
        private ToolStripMenuItem TrainingMaterialtoolStripMenuItem;
        private ToolStripMenuItem HistorytoolStripMenuItem;
        private ToolStripMenuItem lineValidationTransactionToolStripMenuItem;
        private ToolStripMenuItem lineViewToolStripMenuItem;
        private ToolStripMenuItem lineLayoutToolStripMenuItem;
        private ToolStripMenuItem LineValidationTransactionformtoolStripMenuItem;
        private ToolStripMenuItem lineTransactionToolStripMenuItem;
        private ToolStripMenuItem LineValidationmodificationToolStripMenuItem1;
        private ToolStripMenuItem lineTransactionModificationToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem19;
        private ToolStripMenuItem lineTransactionReportToolStripMenuItem;
        private ToolStripMenuItem rMBarcodeToolStripMenuItem;
        private ToolStripMenuItem oOSLogReportToolStripMenuItem;
        private ToolStripMenuItem oOSDetailsReportToolStripMenuItem;
        private ToolStripMenuItem lineDetailsToolStripMenuItem;
        private ToolStripMenuItem lineToolStripMenuItem;
        private ToolStripMenuItem lineRejectionHistoryReportToolStripMenuItem;
        private ToolStripMenuItem consumerComplaintResponceReportToolStripMenuItem;
        private ToolStripMenuItem fGDueReportToolStripMenuItem;
        private ToolStripMenuItem rMDueReportToolStripMenuItem;
        private ToolStripMenuItem pMDueReportToolStripMenuItem;
        private ToolStripMenuItem fGMasterReportToolStripMenuItem;
        private ToolStripMenuItem formulaMasterReportToolStripMenuItem;
        private Button btnMettler;
        private ToolStripMenuItem oEEPUEExcelUploadToolStripMenuItem;
        private ToolStripMenuItem madeLastProductionFormulaToolStripMenuItem;
        private ToolStripMenuItem bulkQuaterReportToolStripMenuItem;
        private ToolStripMenuItem bulkValidateNonvalidatedMenuItem6;
        private ToolStripMenuItem retainerLocationDistractedToolStripMenuItem;
        private ToolStripMenuItem destructionDetailsToolStripMenuItem;
        private ToolStripMenuItem DestructedLocation;
        private ToolStripMenuItem fGOutSourceToolStripMenuItem;
        private ToolStripMenuItem fGOutSourceReportToolStripMenuItem;
        private ToolStripMenuItem rMRejectionToolStripMenuItem;
        private ToolStripMenuItem tankSelectionToolStripMenuItem;
        private Label lblVersion;
        private ToolStripMenuItem tankSelectionReportToolStripMenuItem;
        private ToolStripMenuItem fDARMAnalysisReportToolStripMenuItem;
        private ToolStripMenuItem reagentSupplierMasterToolStripMenuItem;
        private ToolStripMenuItem reagentSupplierPOMappingMasterToolStripMenuItem;
        private MenuStrip menuStripMettler;
        private ToolStripMenuItem toolStripMenuItem6;
        private ToolStripMenuItem toolStripMenuItem40;
        private ToolStripMenuItem tareWeightToolStripMenuItem;
        private ToolStripMenuItem normalWeightToolStripMenuItem;
        private ToolStripMenuItem reagentLabelRePrintReportToolStripMenuItem;
        private ToolStripMenuItem PendingDestructLocationtoolStripMenuItem;
        private ToolStripMenuItem sPCMasterToolStripMenuItem;
        private ToolStripMenuItem manualWeightToolStripMenuItem;
        private ToolStripMenuItem FGDeclarationLotNoReporttoolStripMenuItem;
        private ToolStripMenuItem stabilityTestToolStripMenuItem;
        private ToolStripMenuItem stabilityTestConfigurationToolStripMenuItem;
        private ToolStripMenuItem ageingTestToolStripMenuItem;
        private ToolStripMenuItem stabilityTestReportToolStripMenuItem;
        private ToolStripMenuItem ageingTestReportToolStripMenuItem;
        private ToolStripMenuItem stabilityTraceEmailToolStripMenuItem;
        private ToolStripMenuItem lineOEEMachineMasterToolStripMenuItem;
        private ToolStripMenuItem lineOEEBreakDownReportToolStripMenuItem;
        private ToolStripMenuItem demoToolStripMenuItem;

        private IContainer components;

        #endregion

        #region "CONSTRUCTOR"
        public FrmMain()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// 

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #endregion

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.menuStripADMINH = new System.Windows.Forms.MenuStrip();
            this.aDMINToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userPermissionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userGroupMasterRelationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripFDAH = new System.Windows.Forms.MenuStrip();
            this.fDAHmasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fDAMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FDAHtransactionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fDATransactionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FDAHmodificationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fDAModificationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.oxidationHairDyeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripPMH = new System.Windows.Forms.MenuStrip();
            this.pMHMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pMSupplierMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pMFamilyMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pMCodeMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pMTestMasterToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pMTestMethodMasterToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dimensionParameterMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bAGManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PMHtransactionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pMTransactionToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.pMStatusChangeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pMDefectNoteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pMTreatmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pMReanalysisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pMSupplierCorrectiveNoteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bagViewertoolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.PMHmodificationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pMModificationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PMHReportstoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pMCodeDescriptionReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pMTestMethodMasterReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pMTransactionReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pMNewLaunchReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pMSupplierReportReceivedReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pMDefectNoteDetailReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pMRejectionDetailReportToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pMTDBReportToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pMSupplierTDBReportToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pMFamilyTDBReportToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pMAnalysisToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pMCOCListToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pMCOCTransactionReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pMDefectNoteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pMRejectionNoteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pMCOCHistoryReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pMComponentHistoryReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pMDueReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripRMH = new System.Windows.Forms.MenuStrip();
            this.rMHMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rMSupplierMasterToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.rMFamilyMasterToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.rMParameterMasterToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.rMParameterDescriptionMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rMCodeMasterToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.rMCodeTestMethodMasterToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.rMCodeRetainerLabelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rMSafetySymbolMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rMRetainerLocationMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RMHtransactionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rMSamplingToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.rMTransactionToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.rMStatusChangeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.rMValidityReportToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.rMMicrobiologyTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RMHmodificationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rMMicrobiologyTestModificationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RMHReportstoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rMCodeHistoryReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rMTestMethodMasterReportToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.rMTransactionReportToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.rMSupllierReportReceivedReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rMMicrobiologyTestReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rMTDBReportToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.rMSupplierTDBReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pendingRMReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rMAnalysisReportToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.rMValidityAnalysisReportToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.rMRetainerLocationReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rMParameterwiseReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rMControlTypeReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rMCodeReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rMAlignmentReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rMRejectionNoteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tRRMCodeHalalReport = new System.Windows.Forms.ToolStripMenuItem();
            this.rMBarcodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rMDueReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rMRejectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fDARMAnalysisReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripQTMSH = new System.Windows.Forms.MenuStrip();
            this.QTMSHmasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vesselMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tankMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lineMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bulkTechnicalFamilyMasterToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.testMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formulaMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preservativeMasterToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.preservativeMethodMasterToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.fGGlobalFamilyMasterToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.packingFamilyMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fGFamilyMethodMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fGPhysicoChemicalTestMethodMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.finishGoodMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.finishGoodMethodMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.packingTestMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Mnu_fGSupplierMaster = new System.Windows.Forms.ToolStripMenuItem();
            this.fGOutSourceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.QTMSHtransactionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adjustmentTransactionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bulkTestDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hPLCReferenceMgmtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preservativeTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.microbiologyTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tankSelectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lineSamplePackingDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lineSampleDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kitDetailsToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.sFDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fGReferenceManagementToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.finishedGoodTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.finishedGoodTreatmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.finishedGoodTestSFPackingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fGReleaseDossierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aOCSheetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bulkTestDeailsSubcontractToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.finishedGoodTestQuality1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.retainerLocationDistractedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stabilityTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stabilityTestConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ageingTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.QTMSHmodificationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bulkTestDetailsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.lineSamplePackingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lineSampleDetailsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.microbiologyTestToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.preservativeTestToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.kitDetailsToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.sFDetailsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.finishedGoodTestToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.QTMSHDossiertoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preLotDossierReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lotDossierReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lotDossierDetailReportToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.bMRLotDossierReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.QTMSHTDBtoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bulkTDBReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.microbiologyTDBReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.globalFGTDBReportToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.fGLineDetailsTDBReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fillingAndPackingQualityReportToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.QTMSHSummarytoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bulkTestDetailsReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bulkTestNonBPCReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bulkTestNewLaunchReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bulkTestNonValidatedReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bMRPreSummaryReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bMRSummaryReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bulkPendingReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.linePackingDetailsReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lineSampleSummaryReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preservativeSummaryReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.microbiologySummaryReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.finishedGoodTransactionReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.finishedGoodSummaryReportToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.finishedGoodNonBPCReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fGBulkPendingReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.qStatusSummaryReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lotDossierSummaryReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fGReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rejectionNoteFGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.analysisSummaryReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fGReleaseDossierToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.FGDeclarationLotNoReporttoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.retainerLocationReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.fGRefToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aOCReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oOSLogReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fGDueReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.madeLastProductionFormulaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bulkQuaterReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bulkValidateNonvalidatedMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.DestructedLocation = new System.Windows.Forms.ToolStripMenuItem();
            this.PendingDestructLocationtoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.QTMSHDetailtoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bulkAnalysisReportToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.bulkTransactionReportToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.lineSampleDetailsReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preservativeTestReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.microbiologyTestReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fGAnalysisReportToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.fGAnalysisBMRReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fGPendingReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fGBulkRejectionDetailsReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oOSDetailsReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.destructionDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tankSelectionReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stabilityTestReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stabilityTraceEmailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ageingTestReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.QTMSHMasterReporttoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formulaHistoryReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fGFormulaHistoryReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formulaDescriptionReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bulkTestReportToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.testMethodMasterReportToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.fGTestMethodMasterReportToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.fGMasterReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formulaMasterReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fGOutSourceReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnADMIN = new System.Windows.Forms.Button();
            this.btnOTHER = new System.Windows.Forms.Button();
            this.btnFDA = new System.Windows.Forms.Button();
            this.btnPM = new System.Windows.Forms.Button();
            this.btnRM = new System.Windows.Forms.Button();
            this.btnFG = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblVersion = new System.Windows.Forms.Label();
            this.btnMettler = new System.Windows.Forms.Button();
            this.btnLineValidation = new System.Windows.Forms.Button();
            this.btnSubCon = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnLogin = new System.Windows.Forms.Button();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.lblMenuName = new System.Windows.Forms.Label();
            this.menuStripMettler = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.sPCMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tareWeightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.normalWeightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manualWeightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem40 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripLineValidation = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem20 = new System.Windows.Forms.ToolStripMenuItem();
            this.LineValidationtoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LayoutstoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TrainingMaterialtoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HistorytoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lineValidationTransactionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lineViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lineLayoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lineDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LineValidationTransactionformtoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lineTransactionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LineValidationmodificationToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.lineTransactionModificationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem19 = new System.Windows.Forms.ToolStripMenuItem();
            this.lineTransactionReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lineRejectionHistoryReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripOther = new System.Windows.Forms.MenuStrip();
            this.OthermasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.retainerLocationMasterToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.instrumentMasterToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.countryMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.locationMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mOMMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AnnextureTankMaster = new System.Windows.Forms.ToolStripMenuItem();
            this.QualityIssueMaster = new System.Windows.Forms.ToolStripMenuItem();
            this.DocumentMaster = new System.Windows.Forms.ToolStripMenuItem();
            this.AgitationMaster = new System.Windows.Forms.ToolStripMenuItem();
            this.mOMSignaRoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nAtureofACRefMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aCMaterialRefMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OtherTransactionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consumerComplaintToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.waterAnalysisToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.compatibilityToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.referenceSampleManageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.referenceSampleManagementRMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.plantwiseWaterAnalysisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OtherReportstoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consumerComplaintSummaryReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consumerComplaintResponceReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consumerComplaintAnalysisReportToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.consumerComplaintTDBReportToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.waterAnalysisReportToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.monthlyWaterAnalysisReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oEEAnalysisReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mOMReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fGRefSampleMgmtDetailReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rMRefSampleMgmtDetailReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oEEDetailProcessReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refSampleMgmtSummaryReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.physicoChemicalWaterAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lastProductionFormulaReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consumerComplaintTDBYearlyReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oEEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oEETransactionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oEEModificationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oEEActivityMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.activityRelationMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oEETMTMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oEEPUEExcelUploadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.autoLineOEETransationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lineOEEFGMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lineOEEActivityMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lineOEEMachineMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lineOEEActivityRelationMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uploadLineOEEMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lineOEEDataJunctionReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lineOEEBreakDownReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewUploadLineOEEMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lineOEEUPTdbReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lineOEEGraphReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageComparisionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageComparisonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reagentMgtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reagentSupplierMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reagentSupplierPOMappingMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reagentMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reagentTransactionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reagentModificationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reagentConsumptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reagentAvailableStockReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reagentDetailsReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reagentReorderLevelReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reagentLabelRePrintReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripScoop = new System.Windows.Forms.MenuStrip();
            this.masterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lineSamplingPointMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lineSamplingPointInfoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.scoopTestMethodMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transactionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uPAuthorityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.qualityAuthorityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.globalFGTDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fGLineTDBReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fGAnalysisReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fGTransactionAnalysisReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fGAnalysisNotDoneReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripSubCon = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem12 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem13 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem14 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem15 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem16 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem17 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem18 = new System.Windows.Forms.ToolStripMenuItem();
            this.retainerLocationReportToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.finishedGoodSummaryReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fGMfgWoAnalysisReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.finishGoodTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.demoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripADMINH.SuspendLayout();
            this.menuStripFDAH.SuspendLayout();
            this.menuStripPMH.SuspendLayout();
            this.menuStripRMH.SuspendLayout();
            this.menuStripQTMSH.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelMenu.SuspendLayout();
            this.menuStripMettler.SuspendLayout();
            this.menuStripLineValidation.SuspendLayout();
            this.menuStripOther.SuspendLayout();
            this.menuStripScoop.SuspendLayout();
            this.menuStripSubCon.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 23);
            // 
            // menuStripADMINH
            // 
            this.menuStripADMINH.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.menuStripADMINH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuStripADMINH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStripADMINH.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aDMINToolStripMenuItem});
            this.menuStripADMINH.Location = new System.Drawing.Point(0, 0);
            this.menuStripADMINH.Name = "menuStripADMINH";
            this.menuStripADMINH.Padding = new System.Windows.Forms.Padding(0);
            this.menuStripADMINH.Size = new System.Drawing.Size(1179, 28);
            this.menuStripADMINH.TabIndex = 0;
            this.menuStripADMINH.Text = "menuStrip4";
            this.menuStripADMINH.Visible = false;
            // 
            // aDMINToolStripMenuItem
            // 
            this.aDMINToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.aDMINToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userManagementToolStripMenuItem,
            this.userPermissionToolStripMenuItem,
            this.groupMasterToolStripMenuItem,
            this.userGroupMasterRelationToolStripMenuItem,
            this.changePasswordToolStripMenuItem,
            this.testFormToolStripMenuItem});
            this.aDMINToolStripMenuItem.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.aDMINToolStripMenuItem.Name = "aDMINToolStripMenuItem";
            this.aDMINToolStripMenuItem.Size = new System.Drawing.Size(188, 28);
            this.aDMINToolStripMenuItem.Text = "Manage Permissions";
            this.aDMINToolStripMenuItem.Click += new System.EventHandler(this.aDMINToolStripMenuItem_Click);
            // 
            // userManagementToolStripMenuItem
            // 
            this.userManagementToolStripMenuItem.Name = "userManagementToolStripMenuItem";
            this.userManagementToolStripMenuItem.Size = new System.Drawing.Size(303, 26);
            this.userManagementToolStripMenuItem.Text = "User Management";
            this.userManagementToolStripMenuItem.Click += new System.EventHandler(this.userManagementToolStripMenuItem_Click);
            // 
            // userPermissionToolStripMenuItem
            // 
            this.userPermissionToolStripMenuItem.Name = "userPermissionToolStripMenuItem";
            this.userPermissionToolStripMenuItem.Size = new System.Drawing.Size(303, 26);
            this.userPermissionToolStripMenuItem.Text = "User Permission";
            this.userPermissionToolStripMenuItem.Click += new System.EventHandler(this.userPermissionToolStripMenuItem_Click);
            // 
            // groupMasterToolStripMenuItem
            // 
            this.groupMasterToolStripMenuItem.Name = "groupMasterToolStripMenuItem";
            this.groupMasterToolStripMenuItem.Size = new System.Drawing.Size(303, 26);
            this.groupMasterToolStripMenuItem.Text = "Group Master";
            this.groupMasterToolStripMenuItem.Click += new System.EventHandler(this.groupMasterToolStripMenuItem_Click);
            // 
            // userGroupMasterRelationToolStripMenuItem
            // 
            this.userGroupMasterRelationToolStripMenuItem.Name = "userGroupMasterRelationToolStripMenuItem";
            this.userGroupMasterRelationToolStripMenuItem.Size = new System.Drawing.Size(303, 26);
            this.userGroupMasterRelationToolStripMenuItem.Text = "User Group Master Relation";
            this.userGroupMasterRelationToolStripMenuItem.Click += new System.EventHandler(this.userGroupMasterRelationToolStripMenuItem_Click);
            // 
            // changePasswordToolStripMenuItem
            // 
            this.changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            this.changePasswordToolStripMenuItem.Size = new System.Drawing.Size(303, 26);
            this.changePasswordToolStripMenuItem.Text = "Change Password";
            this.changePasswordToolStripMenuItem.Click += new System.EventHandler(this.changePasswordToolStripMenuItem_Click);
            // 
            // testFormToolStripMenuItem
            // 
            this.testFormToolStripMenuItem.Name = "testFormToolStripMenuItem";
            this.testFormToolStripMenuItem.Size = new System.Drawing.Size(303, 26);
            this.testFormToolStripMenuItem.Text = "Test Form";
            this.testFormToolStripMenuItem.Visible = false;
            this.testFormToolStripMenuItem.Click += new System.EventHandler(this.testFormToolStripMenuItem_Click);
            // 
            // menuStripFDAH
            // 
            this.menuStripFDAH.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.menuStripFDAH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuStripFDAH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStripFDAH.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fDAHmasterToolStripMenuItem,
            this.FDAHtransactionToolStripMenuItem,
            this.FDAHmodificationToolStripMenuItem,
            this.toolStripMenuItem8});
            this.menuStripFDAH.Location = new System.Drawing.Point(0, 0);
            this.menuStripFDAH.Name = "menuStripFDAH";
            this.menuStripFDAH.Padding = new System.Windows.Forms.Padding(0);
            this.menuStripFDAH.Size = new System.Drawing.Size(1179, 28);
            this.menuStripFDAH.TabIndex = 0;
            this.menuStripFDAH.Text = "menuStrip3";
            this.menuStripFDAH.Visible = false;
            // 
            // fDAHmasterToolStripMenuItem
            // 
            this.fDAHmasterToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.fDAHmasterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fDAMasterToolStripMenuItem});
            this.fDAHmasterToolStripMenuItem.ForeColor = System.Drawing.Color.LightSlateGray;
            this.fDAHmasterToolStripMenuItem.Name = "fDAHmasterToolStripMenuItem";
            this.fDAHmasterToolStripMenuItem.Size = new System.Drawing.Size(76, 28);
            this.fDAHmasterToolStripMenuItem.Text = "Master";
            // 
            // fDAMasterToolStripMenuItem
            // 
            this.fDAMasterToolStripMenuItem.Name = "fDAMasterToolStripMenuItem";
            this.fDAMasterToolStripMenuItem.Size = new System.Drawing.Size(175, 26);
            this.fDAMasterToolStripMenuItem.Text = "FDA Master";
            this.fDAMasterToolStripMenuItem.Click += new System.EventHandler(this.fDAMasterToolStripMenuItem_Click);
            // 
            // FDAHtransactionToolStripMenuItem
            // 
            this.FDAHtransactionToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.FDAHtransactionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fDATransactionToolStripMenuItem});
            this.FDAHtransactionToolStripMenuItem.ForeColor = System.Drawing.Color.LightSlateGray;
            this.FDAHtransactionToolStripMenuItem.Name = "FDAHtransactionToolStripMenuItem";
            this.FDAHtransactionToolStripMenuItem.Size = new System.Drawing.Size(117, 28);
            this.FDAHtransactionToolStripMenuItem.Text = "Transaction";
            // 
            // fDATransactionToolStripMenuItem
            // 
            this.fDATransactionToolStripMenuItem.Name = "fDATransactionToolStripMenuItem";
            this.fDATransactionToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.fDATransactionToolStripMenuItem.Text = "FDA Transaction";
            this.fDATransactionToolStripMenuItem.Click += new System.EventHandler(this.fDATransactionToolStripMenuItem_Click);
            // 
            // FDAHmodificationToolStripMenuItem
            // 
            this.FDAHmodificationToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.FDAHmodificationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fDAModificationToolStripMenuItem});
            this.FDAHmodificationToolStripMenuItem.ForeColor = System.Drawing.Color.LightSlateGray;
            this.FDAHmodificationToolStripMenuItem.Name = "FDAHmodificationToolStripMenuItem";
            this.FDAHmodificationToolStripMenuItem.Size = new System.Drawing.Size(117, 28);
            this.FDAHmodificationToolStripMenuItem.Text = "Modification";
            // 
            // fDAModificationToolStripMenuItem
            // 
            this.fDAModificationToolStripMenuItem.Name = "fDAModificationToolStripMenuItem";
            this.fDAModificationToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.fDAModificationToolStripMenuItem.Text = "FDA Modification";
            this.fDAModificationToolStripMenuItem.Click += new System.EventHandler(this.fDAModificationToolStripMenuItem_Click);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripMenuItem8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.toolStripMenuItem8.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oxidationHairDyeToolStripMenuItem});
            this.toolStripMenuItem8.ForeColor = System.Drawing.Color.LightSlateGray;
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(85, 28);
            this.toolStripMenuItem8.Text = "Reports";
            // 
            // oxidationHairDyeToolStripMenuItem
            // 
            this.oxidationHairDyeToolStripMenuItem.Name = "oxidationHairDyeToolStripMenuItem";
            this.oxidationHairDyeToolStripMenuItem.Size = new System.Drawing.Size(231, 26);
            this.oxidationHairDyeToolStripMenuItem.Text = "Oxidation Hair Dye";
            this.oxidationHairDyeToolStripMenuItem.Click += new System.EventHandler(this.oxidationHairDyeToolStripMenuItem_Click);
            // 
            // menuStripPMH
            // 
            this.menuStripPMH.AutoSize = false;
            this.menuStripPMH.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.menuStripPMH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuStripPMH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStripPMH.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pMHMasterToolStripMenuItem,
            this.PMHtransactionToolStripMenuItem,
            this.PMHmodificationToolStripMenuItem,
            this.PMHReportstoolStripMenuItem});
            this.menuStripPMH.Location = new System.Drawing.Point(0, 0);
            this.menuStripPMH.Name = "menuStripPMH";
            this.menuStripPMH.Padding = new System.Windows.Forms.Padding(0);
            this.menuStripPMH.Size = new System.Drawing.Size(1179, 28);
            this.menuStripPMH.TabIndex = 0;
            this.menuStripPMH.Text = "menuStrip2";
            this.menuStripPMH.Visible = false;
            // 
            // pMHMasterToolStripMenuItem
            // 
            this.pMHMasterToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.pMHMasterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pMSupplierMasterToolStripMenuItem,
            this.pMFamilyMasterToolStripMenuItem,
            this.pMCodeMasterToolStripMenuItem,
            this.pMTestMasterToolStripMenuItem1,
            this.pMTestMethodMasterToolStripMenuItem1,
            this.dimensionParameterMasterToolStripMenuItem,
            this.bAGManagementToolStripMenuItem});
            this.pMHMasterToolStripMenuItem.ForeColor = System.Drawing.Color.OrangeRed;
            this.pMHMasterToolStripMenuItem.Name = "pMHMasterToolStripMenuItem";
            this.pMHMasterToolStripMenuItem.Size = new System.Drawing.Size(76, 28);
            this.pMHMasterToolStripMenuItem.Text = "Master";
            // 
            // pMSupplierMasterToolStripMenuItem
            // 
            this.pMSupplierMasterToolStripMenuItem.Name = "pMSupplierMasterToolStripMenuItem";
            this.pMSupplierMasterToolStripMenuItem.Size = new System.Drawing.Size(311, 26);
            this.pMSupplierMasterToolStripMenuItem.Text = "PM Supplier Master";
            this.pMSupplierMasterToolStripMenuItem.Click += new System.EventHandler(this.pMSupplierMasterToolStripMenuItem_Click);
            // 
            // pMFamilyMasterToolStripMenuItem
            // 
            this.pMFamilyMasterToolStripMenuItem.Name = "pMFamilyMasterToolStripMenuItem";
            this.pMFamilyMasterToolStripMenuItem.Size = new System.Drawing.Size(311, 26);
            this.pMFamilyMasterToolStripMenuItem.Text = "PM Family Master";
            this.pMFamilyMasterToolStripMenuItem.Click += new System.EventHandler(this.pMFamilyMasterToolStripMenuItem_Click);
            // 
            // pMCodeMasterToolStripMenuItem
            // 
            this.pMCodeMasterToolStripMenuItem.Name = "pMCodeMasterToolStripMenuItem";
            this.pMCodeMasterToolStripMenuItem.Size = new System.Drawing.Size(311, 26);
            this.pMCodeMasterToolStripMenuItem.Text = "PM Code Master";
            this.pMCodeMasterToolStripMenuItem.Click += new System.EventHandler(this.pMCodeMasterToolStripMenuItem_Click);
            // 
            // pMTestMasterToolStripMenuItem1
            // 
            this.pMTestMasterToolStripMenuItem1.Name = "pMTestMasterToolStripMenuItem1";
            this.pMTestMasterToolStripMenuItem1.Size = new System.Drawing.Size(311, 26);
            this.pMTestMasterToolStripMenuItem1.Text = "PM Test Master";
            this.pMTestMasterToolStripMenuItem1.Click += new System.EventHandler(this.pMTestMasterToolStripMenuItem1_Click);
            // 
            // pMTestMethodMasterToolStripMenuItem1
            // 
            this.pMTestMethodMasterToolStripMenuItem1.Name = "pMTestMethodMasterToolStripMenuItem1";
            this.pMTestMethodMasterToolStripMenuItem1.Size = new System.Drawing.Size(311, 26);
            this.pMTestMethodMasterToolStripMenuItem1.Text = "PM Test Method Master";
            this.pMTestMethodMasterToolStripMenuItem1.Click += new System.EventHandler(this.pMTestMethodMasterToolStripMenuItem1_Click);
            // 
            // dimensionParameterMasterToolStripMenuItem
            // 
            this.dimensionParameterMasterToolStripMenuItem.Name = "dimensionParameterMasterToolStripMenuItem";
            this.dimensionParameterMasterToolStripMenuItem.Size = new System.Drawing.Size(311, 26);
            this.dimensionParameterMasterToolStripMenuItem.Text = "Dimension Parameter Master";
            this.dimensionParameterMasterToolStripMenuItem.Click += new System.EventHandler(this.dimensionParameterMasterToolStripMenuItem_Click);
            // 
            // bAGManagementToolStripMenuItem
            // 
            this.bAGManagementToolStripMenuItem.Name = "bAGManagementToolStripMenuItem";
            this.bAGManagementToolStripMenuItem.Size = new System.Drawing.Size(311, 26);
            this.bAGManagementToolStripMenuItem.Text = "BAG Upload";
            this.bAGManagementToolStripMenuItem.Click += new System.EventHandler(this.bAGManagementToolStripMenuItem_Click);
            // 
            // PMHtransactionToolStripMenuItem
            // 
            this.PMHtransactionToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.PMHtransactionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pMTransactionToolStripMenuItem2,
            this.pMStatusChangeToolStripMenuItem,
            this.pMDefectNoteToolStripMenuItem,
            this.pMTreatmentToolStripMenuItem,
            this.pMReanalysisToolStripMenuItem,
            this.pMSupplierCorrectiveNoteToolStripMenuItem,
            this.bagViewertoolStrip});
            this.PMHtransactionToolStripMenuItem.ForeColor = System.Drawing.Color.OrangeRed;
            this.PMHtransactionToolStripMenuItem.Name = "PMHtransactionToolStripMenuItem";
            this.PMHtransactionToolStripMenuItem.Size = new System.Drawing.Size(117, 28);
            this.PMHtransactionToolStripMenuItem.Text = "Transaction";
            // 
            // pMTransactionToolStripMenuItem2
            // 
            this.pMTransactionToolStripMenuItem2.Name = "pMTransactionToolStripMenuItem2";
            this.pMTransactionToolStripMenuItem2.Size = new System.Drawing.Size(307, 26);
            this.pMTransactionToolStripMenuItem2.Text = "PM Transaction";
            this.pMTransactionToolStripMenuItem2.Click += new System.EventHandler(this.pMTransactionToolStripMenuItem2_Click);
            // 
            // pMStatusChangeToolStripMenuItem
            // 
            this.pMStatusChangeToolStripMenuItem.Name = "pMStatusChangeToolStripMenuItem";
            this.pMStatusChangeToolStripMenuItem.Size = new System.Drawing.Size(307, 26);
            this.pMStatusChangeToolStripMenuItem.Text = "PM Status Change";
            this.pMStatusChangeToolStripMenuItem.Visible = false;
            this.pMStatusChangeToolStripMenuItem.Click += new System.EventHandler(this.pMStatusChangeToolStripMenuItem_Click);
            // 
            // pMDefectNoteToolStripMenuItem
            // 
            this.pMDefectNoteToolStripMenuItem.Name = "pMDefectNoteToolStripMenuItem";
            this.pMDefectNoteToolStripMenuItem.Size = new System.Drawing.Size(307, 26);
            this.pMDefectNoteToolStripMenuItem.Text = "PM Defect Note";
            this.pMDefectNoteToolStripMenuItem.Click += new System.EventHandler(this.pMDefectNoteToolStripMenuItem_Click);
            // 
            // pMTreatmentToolStripMenuItem
            // 
            this.pMTreatmentToolStripMenuItem.Name = "pMTreatmentToolStripMenuItem";
            this.pMTreatmentToolStripMenuItem.Size = new System.Drawing.Size(307, 26);
            this.pMTreatmentToolStripMenuItem.Text = "PM Treatment";
            this.pMTreatmentToolStripMenuItem.Visible = false;
            this.pMTreatmentToolStripMenuItem.Click += new System.EventHandler(this.pMTreatmentToolStripMenuItem_Click);
            // 
            // pMReanalysisToolStripMenuItem
            // 
            this.pMReanalysisToolStripMenuItem.Name = "pMReanalysisToolStripMenuItem";
            this.pMReanalysisToolStripMenuItem.Size = new System.Drawing.Size(307, 26);
            this.pMReanalysisToolStripMenuItem.Text = "PM Reanalysis";
            this.pMReanalysisToolStripMenuItem.Click += new System.EventHandler(this.pMReanalysisToolStripMenuItem_Click);
            // 
            // pMSupplierCorrectiveNoteToolStripMenuItem
            // 
            this.pMSupplierCorrectiveNoteToolStripMenuItem.Name = "pMSupplierCorrectiveNoteToolStripMenuItem";
            this.pMSupplierCorrectiveNoteToolStripMenuItem.Size = new System.Drawing.Size(307, 26);
            this.pMSupplierCorrectiveNoteToolStripMenuItem.Text = "PM Supplier Corrective Note";
            this.pMSupplierCorrectiveNoteToolStripMenuItem.Click += new System.EventHandler(this.pMSupplierCorrectiveNoteToolStripMenuItem_Click);
            // 
            // bagViewertoolStrip
            // 
            this.bagViewertoolStrip.Name = "bagViewertoolStrip";
            this.bagViewertoolStrip.Size = new System.Drawing.Size(307, 26);
            this.bagViewertoolStrip.Text = "BAG Viewer";
            this.bagViewertoolStrip.Visible = false;
            this.bagViewertoolStrip.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // PMHmodificationToolStripMenuItem
            // 
            this.PMHmodificationToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.PMHmodificationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pMModificationToolStripMenuItem});
            this.PMHmodificationToolStripMenuItem.ForeColor = System.Drawing.Color.OrangeRed;
            this.PMHmodificationToolStripMenuItem.Name = "PMHmodificationToolStripMenuItem";
            this.PMHmodificationToolStripMenuItem.Size = new System.Drawing.Size(117, 28);
            this.PMHmodificationToolStripMenuItem.Text = "Modification";
            // 
            // pMModificationToolStripMenuItem
            // 
            this.pMModificationToolStripMenuItem.Name = "pMModificationToolStripMenuItem";
            this.pMModificationToolStripMenuItem.Size = new System.Drawing.Size(206, 26);
            this.pMModificationToolStripMenuItem.Text = "PM Modification";
            this.pMModificationToolStripMenuItem.Click += new System.EventHandler(this.pMModificationToolStripMenuItem_Click);
            // 
            // PMHReportstoolStripMenuItem
            // 
            this.PMHReportstoolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.PMHReportstoolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.PMHReportstoolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pMCodeDescriptionReportToolStripMenuItem,
            this.pMTestMethodMasterReportToolStripMenuItem,
            this.pMTransactionReportToolStripMenuItem,
            this.pMNewLaunchReportToolStripMenuItem,
            this.pMSupplierReportReceivedReportToolStripMenuItem,
            this.pMDefectNoteDetailReportToolStripMenuItem,
            this.pMRejectionDetailReportToolStripMenuItem1,
            this.pMTDBReportToolStripMenuItem1,
            this.pMSupplierTDBReportToolStripMenuItem1,
            this.pMFamilyTDBReportToolStripMenuItem1,
            this.pMAnalysisToolStripMenuItem1,
            this.pMCOCListToolStripMenuItem1,
            this.pMCOCTransactionReportToolStripMenuItem,
            this.pMDefectNoteToolStripMenuItem1,
            this.pMRejectionNoteToolStripMenuItem,
            this.pMCOCHistoryReportToolStripMenuItem,
            this.pMComponentHistoryReportToolStripMenuItem,
            this.pMDueReportToolStripMenuItem});
            this.PMHReportstoolStripMenuItem.ForeColor = System.Drawing.Color.OrangeRed;
            this.PMHReportstoolStripMenuItem.Name = "PMHReportstoolStripMenuItem";
            this.PMHReportstoolStripMenuItem.Size = new System.Drawing.Size(85, 28);
            this.PMHReportstoolStripMenuItem.Text = "Reports";
            // 
            // pMCodeDescriptionReportToolStripMenuItem
            // 
            this.pMCodeDescriptionReportToolStripMenuItem.Name = "pMCodeDescriptionReportToolStripMenuItem";
            this.pMCodeDescriptionReportToolStripMenuItem.Size = new System.Drawing.Size(375, 26);
            this.pMCodeDescriptionReportToolStripMenuItem.Text = "PM Code Description Report";
            this.pMCodeDescriptionReportToolStripMenuItem.Click += new System.EventHandler(this.pMCodeDescriptionReportToolStripMenuItem_Click);
            // 
            // pMTestMethodMasterReportToolStripMenuItem
            // 
            this.pMTestMethodMasterReportToolStripMenuItem.Name = "pMTestMethodMasterReportToolStripMenuItem";
            this.pMTestMethodMasterReportToolStripMenuItem.Size = new System.Drawing.Size(375, 26);
            this.pMTestMethodMasterReportToolStripMenuItem.Text = "PM Test Method Master Report";
            this.pMTestMethodMasterReportToolStripMenuItem.Click += new System.EventHandler(this.pMTestMethodMasterReportToolStripMenuItem_Click);
            // 
            // pMTransactionReportToolStripMenuItem
            // 
            this.pMTransactionReportToolStripMenuItem.Name = "pMTransactionReportToolStripMenuItem";
            this.pMTransactionReportToolStripMenuItem.Size = new System.Drawing.Size(375, 26);
            this.pMTransactionReportToolStripMenuItem.Text = "PM Transaction Report";
            this.pMTransactionReportToolStripMenuItem.Click += new System.EventHandler(this.pMTransactionReportToolStripMenuItem_Click);
            // 
            // pMNewLaunchReportToolStripMenuItem
            // 
            this.pMNewLaunchReportToolStripMenuItem.Name = "pMNewLaunchReportToolStripMenuItem";
            this.pMNewLaunchReportToolStripMenuItem.Size = new System.Drawing.Size(375, 26);
            this.pMNewLaunchReportToolStripMenuItem.Text = "PM New Launch Report";
            this.pMNewLaunchReportToolStripMenuItem.Click += new System.EventHandler(this.pMNewLaunchReportToolStripMenuItem_Click);
            // 
            // pMSupplierReportReceivedReportToolStripMenuItem
            // 
            this.pMSupplierReportReceivedReportToolStripMenuItem.Name = "pMSupplierReportReceivedReportToolStripMenuItem";
            this.pMSupplierReportReceivedReportToolStripMenuItem.Size = new System.Drawing.Size(375, 26);
            this.pMSupplierReportReceivedReportToolStripMenuItem.Text = "PM Supplier Report Received Report";
            this.pMSupplierReportReceivedReportToolStripMenuItem.Click += new System.EventHandler(this.pMSupplierReportReceivedReportToolStripMenuItem_Click);
            // 
            // pMDefectNoteDetailReportToolStripMenuItem
            // 
            this.pMDefectNoteDetailReportToolStripMenuItem.Name = "pMDefectNoteDetailReportToolStripMenuItem";
            this.pMDefectNoteDetailReportToolStripMenuItem.Size = new System.Drawing.Size(375, 26);
            this.pMDefectNoteDetailReportToolStripMenuItem.Text = "PM Defect Note Detail Report";
            this.pMDefectNoteDetailReportToolStripMenuItem.Click += new System.EventHandler(this.pMDefectNoteDetailReportToolStripMenuItem_Click);
            // 
            // pMRejectionDetailReportToolStripMenuItem1
            // 
            this.pMRejectionDetailReportToolStripMenuItem1.Name = "pMRejectionDetailReportToolStripMenuItem1";
            this.pMRejectionDetailReportToolStripMenuItem1.Size = new System.Drawing.Size(375, 26);
            this.pMRejectionDetailReportToolStripMenuItem1.Text = "PM Rejection Detail Report";
            this.pMRejectionDetailReportToolStripMenuItem1.Click += new System.EventHandler(this.pMRejectionDetailReportToolStripMenuItem1_Click);
            // 
            // pMTDBReportToolStripMenuItem1
            // 
            this.pMTDBReportToolStripMenuItem1.Name = "pMTDBReportToolStripMenuItem1";
            this.pMTDBReportToolStripMenuItem1.Size = new System.Drawing.Size(375, 26);
            this.pMTDBReportToolStripMenuItem1.Text = "PM TDB Report";
            this.pMTDBReportToolStripMenuItem1.Click += new System.EventHandler(this.pMTDBReportToolStripMenuItem1_Click);
            // 
            // pMSupplierTDBReportToolStripMenuItem1
            // 
            this.pMSupplierTDBReportToolStripMenuItem1.Name = "pMSupplierTDBReportToolStripMenuItem1";
            this.pMSupplierTDBReportToolStripMenuItem1.Size = new System.Drawing.Size(375, 26);
            this.pMSupplierTDBReportToolStripMenuItem1.Text = "PM Supplier TDB Report";
            this.pMSupplierTDBReportToolStripMenuItem1.Click += new System.EventHandler(this.pMSupplierTDBReportToolStripMenuItem1_Click);
            // 
            // pMFamilyTDBReportToolStripMenuItem1
            // 
            this.pMFamilyTDBReportToolStripMenuItem1.Name = "pMFamilyTDBReportToolStripMenuItem1";
            this.pMFamilyTDBReportToolStripMenuItem1.Size = new System.Drawing.Size(375, 26);
            this.pMFamilyTDBReportToolStripMenuItem1.Text = "PM Family TDB Report";
            this.pMFamilyTDBReportToolStripMenuItem1.Click += new System.EventHandler(this.pMFamilyTDBReportToolStripMenuItem1_Click);
            // 
            // pMAnalysisToolStripMenuItem1
            // 
            this.pMAnalysisToolStripMenuItem1.Name = "pMAnalysisToolStripMenuItem1";
            this.pMAnalysisToolStripMenuItem1.Size = new System.Drawing.Size(375, 26);
            this.pMAnalysisToolStripMenuItem1.Text = "PM Analysis";
            this.pMAnalysisToolStripMenuItem1.Click += new System.EventHandler(this.pMAnalysisToolStripMenuItem1_Click);
            // 
            // pMCOCListToolStripMenuItem1
            // 
            this.pMCOCListToolStripMenuItem1.Name = "pMCOCListToolStripMenuItem1";
            this.pMCOCListToolStripMenuItem1.Size = new System.Drawing.Size(375, 26);
            this.pMCOCListToolStripMenuItem1.Text = "PM COC List";
            this.pMCOCListToolStripMenuItem1.Click += new System.EventHandler(this.pMCOCListToolStripMenuItem1_Click);
            // 
            // pMCOCTransactionReportToolStripMenuItem
            // 
            this.pMCOCTransactionReportToolStripMenuItem.Name = "pMCOCTransactionReportToolStripMenuItem";
            this.pMCOCTransactionReportToolStripMenuItem.Size = new System.Drawing.Size(375, 26);
            this.pMCOCTransactionReportToolStripMenuItem.Text = "PM COC Transaction Report";
            this.pMCOCTransactionReportToolStripMenuItem.Click += new System.EventHandler(this.pMCOCTransactionReportToolStripMenuItem_Click);
            // 
            // pMDefectNoteToolStripMenuItem1
            // 
            this.pMDefectNoteToolStripMenuItem1.Name = "pMDefectNoteToolStripMenuItem1";
            this.pMDefectNoteToolStripMenuItem1.Size = new System.Drawing.Size(375, 26);
            this.pMDefectNoteToolStripMenuItem1.Text = "PM Defect Note";
            this.pMDefectNoteToolStripMenuItem1.Click += new System.EventHandler(this.pMDefectNoteToolStripMenuItem1_Click);
            // 
            // pMRejectionNoteToolStripMenuItem
            // 
            this.pMRejectionNoteToolStripMenuItem.Name = "pMRejectionNoteToolStripMenuItem";
            this.pMRejectionNoteToolStripMenuItem.Size = new System.Drawing.Size(375, 26);
            this.pMRejectionNoteToolStripMenuItem.Text = "PM Rejection Note";
            this.pMRejectionNoteToolStripMenuItem.Click += new System.EventHandler(this.pMRejectionNoteToolStripMenuItem_Click);
            // 
            // pMCOCHistoryReportToolStripMenuItem
            // 
            this.pMCOCHistoryReportToolStripMenuItem.Name = "pMCOCHistoryReportToolStripMenuItem";
            this.pMCOCHistoryReportToolStripMenuItem.Size = new System.Drawing.Size(375, 26);
            this.pMCOCHistoryReportToolStripMenuItem.Text = "PM COC History Report";
            this.pMCOCHistoryReportToolStripMenuItem.Click += new System.EventHandler(this.pMCOCHistoryReportToolStripMenuItem_Click);
            // 
            // pMComponentHistoryReportToolStripMenuItem
            // 
            this.pMComponentHistoryReportToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pMComponentHistoryReportToolStripMenuItem.Name = "pMComponentHistoryReportToolStripMenuItem";
            this.pMComponentHistoryReportToolStripMenuItem.Size = new System.Drawing.Size(375, 26);
            this.pMComponentHistoryReportToolStripMenuItem.Text = "PM Component History Report";
            this.pMComponentHistoryReportToolStripMenuItem.Click += new System.EventHandler(this.pMComponentHistoryReportToolStripMenuItem_Click);
            // 
            // pMDueReportToolStripMenuItem
            // 
            this.pMDueReportToolStripMenuItem.Name = "pMDueReportToolStripMenuItem";
            this.pMDueReportToolStripMenuItem.Size = new System.Drawing.Size(375, 26);
            this.pMDueReportToolStripMenuItem.Text = "PM Due Report";
            this.pMDueReportToolStripMenuItem.Click += new System.EventHandler(this.pMDueReportToolStripMenuItem_Click);
            // 
            // menuStripRMH
            // 
            this.menuStripRMH.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.menuStripRMH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuStripRMH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStripRMH.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rMHMasterToolStripMenuItem,
            this.RMHtransactionToolStripMenuItem,
            this.RMHmodificationToolStripMenuItem,
            this.RMHReportstoolStripMenuItem});
            this.menuStripRMH.Location = new System.Drawing.Point(0, 0);
            this.menuStripRMH.Name = "menuStripRMH";
            this.menuStripRMH.Padding = new System.Windows.Forms.Padding(0);
            this.menuStripRMH.Size = new System.Drawing.Size(1179, 28);
            this.menuStripRMH.TabIndex = 0;
            this.menuStripRMH.Text = "menuRM_Rejection_Note";
            this.menuStripRMH.Visible = false;
            // 
            // rMHMasterToolStripMenuItem
            // 
            this.rMHMasterToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.rMHMasterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rMSupplierMasterToolStripMenuItem1,
            this.rMFamilyMasterToolStripMenuItem1,
            this.rMParameterMasterToolStripMenuItem1,
            this.rMParameterDescriptionMasterToolStripMenuItem,
            this.rMCodeMasterToolStripMenuItem1,
            this.rMCodeTestMethodMasterToolStripMenuItem1,
            this.rMCodeRetainerLabelToolStripMenuItem,
            this.rMSafetySymbolMasterToolStripMenuItem,
            this.rMRetainerLocationMasterToolStripMenuItem});
            this.rMHMasterToolStripMenuItem.ForeColor = System.Drawing.Color.ForestGreen;
            this.rMHMasterToolStripMenuItem.Name = "rMHMasterToolStripMenuItem";
            this.rMHMasterToolStripMenuItem.Size = new System.Drawing.Size(76, 28);
            this.rMHMasterToolStripMenuItem.Text = "Master";
            // 
            // rMSupplierMasterToolStripMenuItem1
            // 
            this.rMSupplierMasterToolStripMenuItem1.Name = "rMSupplierMasterToolStripMenuItem1";
            this.rMSupplierMasterToolStripMenuItem1.Size = new System.Drawing.Size(349, 26);
            this.rMSupplierMasterToolStripMenuItem1.Text = "RM Supplier Master";
            this.rMSupplierMasterToolStripMenuItem1.Click += new System.EventHandler(this.rMSupplierMasterToolStripMenuItem1_Click);
            // 
            // rMFamilyMasterToolStripMenuItem1
            // 
            this.rMFamilyMasterToolStripMenuItem1.Name = "rMFamilyMasterToolStripMenuItem1";
            this.rMFamilyMasterToolStripMenuItem1.Size = new System.Drawing.Size(349, 26);
            this.rMFamilyMasterToolStripMenuItem1.Text = "RM Family Master";
            this.rMFamilyMasterToolStripMenuItem1.Click += new System.EventHandler(this.rMFamilyMasterToolStripMenuItem1_Click);
            // 
            // rMParameterMasterToolStripMenuItem1
            // 
            this.rMParameterMasterToolStripMenuItem1.Name = "rMParameterMasterToolStripMenuItem1";
            this.rMParameterMasterToolStripMenuItem1.Size = new System.Drawing.Size(349, 26);
            this.rMParameterMasterToolStripMenuItem1.Text = "RM Parameter Master";
            this.rMParameterMasterToolStripMenuItem1.Click += new System.EventHandler(this.rMParameterMasterToolStripMenuItem1_Click);
            // 
            // rMParameterDescriptionMasterToolStripMenuItem
            // 
            this.rMParameterDescriptionMasterToolStripMenuItem.Name = "rMParameterDescriptionMasterToolStripMenuItem";
            this.rMParameterDescriptionMasterToolStripMenuItem.Size = new System.Drawing.Size(349, 26);
            this.rMParameterDescriptionMasterToolStripMenuItem.Text = "RM Parameter Description Master";
            this.rMParameterDescriptionMasterToolStripMenuItem.Click += new System.EventHandler(this.rMParameterDescriptionMasterToolStripMenuItem_Click);
            // 
            // rMCodeMasterToolStripMenuItem1
            // 
            this.rMCodeMasterToolStripMenuItem1.Name = "rMCodeMasterToolStripMenuItem1";
            this.rMCodeMasterToolStripMenuItem1.Size = new System.Drawing.Size(349, 26);
            this.rMCodeMasterToolStripMenuItem1.Text = "RM Code Master";
            this.rMCodeMasterToolStripMenuItem1.Click += new System.EventHandler(this.rMCodeMasterToolStripMenuItem1_Click);
            // 
            // rMCodeTestMethodMasterToolStripMenuItem1
            // 
            this.rMCodeTestMethodMasterToolStripMenuItem1.Name = "rMCodeTestMethodMasterToolStripMenuItem1";
            this.rMCodeTestMethodMasterToolStripMenuItem1.Size = new System.Drawing.Size(349, 26);
            this.rMCodeTestMethodMasterToolStripMenuItem1.Text = "RM Code Test Method Master";
            this.rMCodeTestMethodMasterToolStripMenuItem1.Click += new System.EventHandler(this.rMCodeTestMethodMasterToolStripMenuItem1_Click);
            // 
            // rMCodeRetainerLabelToolStripMenuItem
            // 
            this.rMCodeRetainerLabelToolStripMenuItem.Name = "rMCodeRetainerLabelToolStripMenuItem";
            this.rMCodeRetainerLabelToolStripMenuItem.Size = new System.Drawing.Size(349, 26);
            this.rMCodeRetainerLabelToolStripMenuItem.Text = "RM Code Retainer Label";
            this.rMCodeRetainerLabelToolStripMenuItem.Click += new System.EventHandler(this.rMRetainerLabelToolStripMenuItem_Click);
            // 
            // rMSafetySymbolMasterToolStripMenuItem
            // 
            this.rMSafetySymbolMasterToolStripMenuItem.Name = "rMSafetySymbolMasterToolStripMenuItem";
            this.rMSafetySymbolMasterToolStripMenuItem.Size = new System.Drawing.Size(349, 26);
            this.rMSafetySymbolMasterToolStripMenuItem.Text = "RM Safety Symbol Master";
            this.rMSafetySymbolMasterToolStripMenuItem.Click += new System.EventHandler(this.rMSafetySymbolMasterToolStripMenuItem_Click);
            // 
            // rMRetainerLocationMasterToolStripMenuItem
            // 
            this.rMRetainerLocationMasterToolStripMenuItem.Name = "rMRetainerLocationMasterToolStripMenuItem";
            this.rMRetainerLocationMasterToolStripMenuItem.Size = new System.Drawing.Size(349, 26);
            this.rMRetainerLocationMasterToolStripMenuItem.Text = "RM Retainer Location Master";
            this.rMRetainerLocationMasterToolStripMenuItem.Click += new System.EventHandler(this.rMRetainerLocationMasterToolStripMenuItem_Click);
            // 
            // RMHtransactionToolStripMenuItem
            // 
            this.RMHtransactionToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.RMHtransactionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rMSamplingToolStripMenuItem1,
            this.rMTransactionToolStripMenuItem1,
            this.rMStatusChangeToolStripMenuItem1,
            this.rMValidityReportToolStripMenuItem1,
            this.rMMicrobiologyTestToolStripMenuItem});
            this.RMHtransactionToolStripMenuItem.ForeColor = System.Drawing.Color.ForestGreen;
            this.RMHtransactionToolStripMenuItem.Name = "RMHtransactionToolStripMenuItem";
            this.RMHtransactionToolStripMenuItem.Size = new System.Drawing.Size(117, 28);
            this.RMHtransactionToolStripMenuItem.Text = "Transaction";
            // 
            // rMSamplingToolStripMenuItem1
            // 
            this.rMSamplingToolStripMenuItem1.Name = "rMSamplingToolStripMenuItem1";
            this.rMSamplingToolStripMenuItem1.Size = new System.Drawing.Size(253, 26);
            this.rMSamplingToolStripMenuItem1.Text = "RM Sampling";
            this.rMSamplingToolStripMenuItem1.Visible = false;
            this.rMSamplingToolStripMenuItem1.Click += new System.EventHandler(this.rMSamplingToolStripMenuItem1_Click);
            // 
            // rMTransactionToolStripMenuItem1
            // 
            this.rMTransactionToolStripMenuItem1.Name = "rMTransactionToolStripMenuItem1";
            this.rMTransactionToolStripMenuItem1.Size = new System.Drawing.Size(253, 26);
            this.rMTransactionToolStripMenuItem1.Text = "RM Transaction";
            this.rMTransactionToolStripMenuItem1.Click += new System.EventHandler(this.rMTransactionToolStripMenuItem1_Click);
            // 
            // rMStatusChangeToolStripMenuItem1
            // 
            this.rMStatusChangeToolStripMenuItem1.Name = "rMStatusChangeToolStripMenuItem1";
            this.rMStatusChangeToolStripMenuItem1.Size = new System.Drawing.Size(253, 26);
            this.rMStatusChangeToolStripMenuItem1.Text = "RM Status Change";
            this.rMStatusChangeToolStripMenuItem1.Click += new System.EventHandler(this.rMStatusChangeToolStripMenuItem1_Click);
            // 
            // rMValidityReportToolStripMenuItem1
            // 
            this.rMValidityReportToolStripMenuItem1.Name = "rMValidityReportToolStripMenuItem1";
            this.rMValidityReportToolStripMenuItem1.Size = new System.Drawing.Size(253, 26);
            this.rMValidityReportToolStripMenuItem1.Text = "RM Validity Report";
            this.rMValidityReportToolStripMenuItem1.Click += new System.EventHandler(this.rMValidityReportToolStripMenuItem1_Click);
            // 
            // rMMicrobiologyTestToolStripMenuItem
            // 
            this.rMMicrobiologyTestToolStripMenuItem.Name = "rMMicrobiologyTestToolStripMenuItem";
            this.rMMicrobiologyTestToolStripMenuItem.Size = new System.Drawing.Size(253, 26);
            this.rMMicrobiologyTestToolStripMenuItem.Text = "RM Microbiology Test";
            this.rMMicrobiologyTestToolStripMenuItem.Click += new System.EventHandler(this.rMMicrobiologyTestToolStripMenuItem_Click);
            // 
            // RMHmodificationToolStripMenuItem
            // 
            this.RMHmodificationToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.RMHmodificationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rMMicrobiologyTestModificationToolStripMenuItem});
            this.RMHmodificationToolStripMenuItem.ForeColor = System.Drawing.Color.ForestGreen;
            this.RMHmodificationToolStripMenuItem.Name = "RMHmodificationToolStripMenuItem";
            this.RMHmodificationToolStripMenuItem.Size = new System.Drawing.Size(117, 28);
            this.RMHmodificationToolStripMenuItem.Text = "Modification";
            // 
            // rMMicrobiologyTestModificationToolStripMenuItem
            // 
            this.rMMicrobiologyTestModificationToolStripMenuItem.Name = "rMMicrobiologyTestModificationToolStripMenuItem";
            this.rMMicrobiologyTestModificationToolStripMenuItem.Size = new System.Drawing.Size(353, 26);
            this.rMMicrobiologyTestModificationToolStripMenuItem.Text = "RM Microbiology Test Modification";
            this.rMMicrobiologyTestModificationToolStripMenuItem.Click += new System.EventHandler(this.rMMicrobiologyTestModificationToolStripMenuItem_Click);
            // 
            // RMHReportstoolStripMenuItem
            // 
            this.RMHReportstoolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.RMHReportstoolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.RMHReportstoolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rMCodeHistoryReportToolStripMenuItem,
            this.rMTestMethodMasterReportToolStripMenuItem1,
            this.rMTransactionReportToolStripMenuItem1,
            this.rMSupllierReportReceivedReportToolStripMenuItem,
            this.rMMicrobiologyTestReportToolStripMenuItem,
            this.rMTDBReportToolStripMenuItem1,
            this.rMSupplierTDBReportToolStripMenuItem,
            this.pendingRMReportToolStripMenuItem,
            this.rMAnalysisReportToolStripMenuItem1,
            this.rMValidityAnalysisReportToolStripMenuItem1,
            this.rMRetainerLocationReportToolStripMenuItem,
            this.rMParameterwiseReportToolStripMenuItem,
            this.rMControlTypeReportToolStripMenuItem,
            this.rMCodeReportToolStripMenuItem,
            this.rMAlignmentReportToolStripMenuItem,
            this.rMRejectionNoteToolStripMenuItem,
            this.tRRMCodeHalalReport,
            this.rMBarcodeToolStripMenuItem,
            this.rMDueReportToolStripMenuItem,
            this.rMRejectionToolStripMenuItem,
            this.fDARMAnalysisReportToolStripMenuItem});
            this.RMHReportstoolStripMenuItem.ForeColor = System.Drawing.Color.ForestGreen;
            this.RMHReportstoolStripMenuItem.Name = "RMHReportstoolStripMenuItem";
            this.RMHReportstoolStripMenuItem.Size = new System.Drawing.Size(85, 28);
            this.RMHReportstoolStripMenuItem.Text = "Reports";
            // 
            // rMCodeHistoryReportToolStripMenuItem
            // 
            this.rMCodeHistoryReportToolStripMenuItem.Name = "rMCodeHistoryReportToolStripMenuItem";
            this.rMCodeHistoryReportToolStripMenuItem.Size = new System.Drawing.Size(370, 26);
            this.rMCodeHistoryReportToolStripMenuItem.Text = "RM Code History Report";
            this.rMCodeHistoryReportToolStripMenuItem.Click += new System.EventHandler(this.rMCodeHistoryReportToolStripMenuItem_Click);
            // 
            // rMTestMethodMasterReportToolStripMenuItem1
            // 
            this.rMTestMethodMasterReportToolStripMenuItem1.Name = "rMTestMethodMasterReportToolStripMenuItem1";
            this.rMTestMethodMasterReportToolStripMenuItem1.Size = new System.Drawing.Size(370, 26);
            this.rMTestMethodMasterReportToolStripMenuItem1.Text = "RM Test Method Master Report ";
            this.rMTestMethodMasterReportToolStripMenuItem1.Click += new System.EventHandler(this.rMTestMethodMasterReportToolStripMenuItem1_Click);
            // 
            // rMTransactionReportToolStripMenuItem1
            // 
            this.rMTransactionReportToolStripMenuItem1.Name = "rMTransactionReportToolStripMenuItem1";
            this.rMTransactionReportToolStripMenuItem1.Size = new System.Drawing.Size(370, 26);
            this.rMTransactionReportToolStripMenuItem1.Text = "RM Transaction Report";
            this.rMTransactionReportToolStripMenuItem1.Click += new System.EventHandler(this.rMTransactionReportToolStripMenuItem1_Click);
            // 
            // rMSupllierReportReceivedReportToolStripMenuItem
            // 
            this.rMSupllierReportReceivedReportToolStripMenuItem.Name = "rMSupllierReportReceivedReportToolStripMenuItem";
            this.rMSupllierReportReceivedReportToolStripMenuItem.Size = new System.Drawing.Size(370, 26);
            this.rMSupllierReportReceivedReportToolStripMenuItem.Text = "RM Supllier Report Received Report";
            this.rMSupllierReportReceivedReportToolStripMenuItem.Click += new System.EventHandler(this.rMSupllierReportReceivedReportToolStripMenuItem_Click);
            // 
            // rMMicrobiologyTestReportToolStripMenuItem
            // 
            this.rMMicrobiologyTestReportToolStripMenuItem.Name = "rMMicrobiologyTestReportToolStripMenuItem";
            this.rMMicrobiologyTestReportToolStripMenuItem.Size = new System.Drawing.Size(370, 26);
            this.rMMicrobiologyTestReportToolStripMenuItem.Text = "RM MicrobiologyTest_Report";
            this.rMMicrobiologyTestReportToolStripMenuItem.Click += new System.EventHandler(this.rMMicrobiologyTestReportToolStripMenuItem_Click);
            // 
            // rMTDBReportToolStripMenuItem1
            // 
            this.rMTDBReportToolStripMenuItem1.Name = "rMTDBReportToolStripMenuItem1";
            this.rMTDBReportToolStripMenuItem1.Size = new System.Drawing.Size(370, 26);
            this.rMTDBReportToolStripMenuItem1.Text = "RM Family TDB Report";
            this.rMTDBReportToolStripMenuItem1.Click += new System.EventHandler(this.rMTDBReportToolStripMenuItem1_Click);
            // 
            // rMSupplierTDBReportToolStripMenuItem
            // 
            this.rMSupplierTDBReportToolStripMenuItem.Name = "rMSupplierTDBReportToolStripMenuItem";
            this.rMSupplierTDBReportToolStripMenuItem.Size = new System.Drawing.Size(370, 26);
            this.rMSupplierTDBReportToolStripMenuItem.Text = "RM Supplier TDB Report";
            this.rMSupplierTDBReportToolStripMenuItem.Click += new System.EventHandler(this.rMSupplierTDBReportToolStripMenuItem_Click);
            // 
            // pendingRMReportToolStripMenuItem
            // 
            this.pendingRMReportToolStripMenuItem.Name = "pendingRMReportToolStripMenuItem";
            this.pendingRMReportToolStripMenuItem.Size = new System.Drawing.Size(370, 26);
            this.pendingRMReportToolStripMenuItem.Text = "Pending RM Report";
            this.pendingRMReportToolStripMenuItem.Click += new System.EventHandler(this.pendingRMReportToolStripMenuItem_Click);
            // 
            // rMAnalysisReportToolStripMenuItem1
            // 
            this.rMAnalysisReportToolStripMenuItem1.Name = "rMAnalysisReportToolStripMenuItem1";
            this.rMAnalysisReportToolStripMenuItem1.Size = new System.Drawing.Size(370, 26);
            this.rMAnalysisReportToolStripMenuItem1.Text = "RM Analysis Report";
            this.rMAnalysisReportToolStripMenuItem1.Click += new System.EventHandler(this.rMAnalysisReportToolStripMenuItem1_Click);
            // 
            // rMValidityAnalysisReportToolStripMenuItem1
            // 
            this.rMValidityAnalysisReportToolStripMenuItem1.Name = "rMValidityAnalysisReportToolStripMenuItem1";
            this.rMValidityAnalysisReportToolStripMenuItem1.Size = new System.Drawing.Size(370, 26);
            this.rMValidityAnalysisReportToolStripMenuItem1.Text = "RM Validity Analysis Report";
            this.rMValidityAnalysisReportToolStripMenuItem1.Click += new System.EventHandler(this.rMValidityAnalysisReportToolStripMenuItem1_Click);
            // 
            // rMRetainerLocationReportToolStripMenuItem
            // 
            this.rMRetainerLocationReportToolStripMenuItem.Name = "rMRetainerLocationReportToolStripMenuItem";
            this.rMRetainerLocationReportToolStripMenuItem.Size = new System.Drawing.Size(370, 26);
            this.rMRetainerLocationReportToolStripMenuItem.Text = "RM RetainerLocation Report";
            this.rMRetainerLocationReportToolStripMenuItem.Click += new System.EventHandler(this.rMRetainerLocationReportToolStripMenuItem_Click);
            // 
            // rMParameterwiseReportToolStripMenuItem
            // 
            this.rMParameterwiseReportToolStripMenuItem.Name = "rMParameterwiseReportToolStripMenuItem";
            this.rMParameterwiseReportToolStripMenuItem.Size = new System.Drawing.Size(370, 26);
            this.rMParameterwiseReportToolStripMenuItem.Text = "RM Parameterwise Report";
            this.rMParameterwiseReportToolStripMenuItem.Click += new System.EventHandler(this.rMParameterwiseReportToolStripMenuItem_Click);
            // 
            // rMControlTypeReportToolStripMenuItem
            // 
            this.rMControlTypeReportToolStripMenuItem.Name = "rMControlTypeReportToolStripMenuItem";
            this.rMControlTypeReportToolStripMenuItem.Size = new System.Drawing.Size(370, 26);
            this.rMControlTypeReportToolStripMenuItem.Text = "RM Control Type Report";
            this.rMControlTypeReportToolStripMenuItem.Click += new System.EventHandler(this.rMControlTypeReportToolStripMenuItem_Click);
            // 
            // rMCodeReportToolStripMenuItem
            // 
            this.rMCodeReportToolStripMenuItem.Name = "rMCodeReportToolStripMenuItem";
            this.rMCodeReportToolStripMenuItem.Size = new System.Drawing.Size(370, 26);
            this.rMCodeReportToolStripMenuItem.Text = "RM Code Report";
            this.rMCodeReportToolStripMenuItem.Click += new System.EventHandler(this.rMCodeReportToolStripMenuItem_Click);
            // 
            // rMAlignmentReportToolStripMenuItem
            // 
            this.rMAlignmentReportToolStripMenuItem.Name = "rMAlignmentReportToolStripMenuItem";
            this.rMAlignmentReportToolStripMenuItem.Size = new System.Drawing.Size(370, 26);
            this.rMAlignmentReportToolStripMenuItem.Text = "RM Alignment Report";
            this.rMAlignmentReportToolStripMenuItem.Click += new System.EventHandler(this.rMAlignmentRreportToolStripMenuItem_Click);
            // 
            // rMRejectionNoteToolStripMenuItem
            // 
            this.rMRejectionNoteToolStripMenuItem.Name = "rMRejectionNoteToolStripMenuItem";
            this.rMRejectionNoteToolStripMenuItem.Size = new System.Drawing.Size(370, 26);
            this.rMRejectionNoteToolStripMenuItem.Text = "RM Rejection Note";
            this.rMRejectionNoteToolStripMenuItem.Click += new System.EventHandler(this.rMRejectionNoteToolStripMenuItem_Click);
            // 
            // tRRMCodeHalalReport
            // 
            this.tRRMCodeHalalReport.Name = "tRRMCodeHalalReport";
            this.tRRMCodeHalalReport.Size = new System.Drawing.Size(370, 26);
            this.tRRMCodeHalalReport.Text = "RM Code Halal Report";
            this.tRRMCodeHalalReport.Click += new System.EventHandler(this.tRRMCodeHalalReport_Click);
            // 
            // rMBarcodeToolStripMenuItem
            // 
            this.rMBarcodeToolStripMenuItem.Name = "rMBarcodeToolStripMenuItem";
            this.rMBarcodeToolStripMenuItem.Size = new System.Drawing.Size(370, 26);
            this.rMBarcodeToolStripMenuItem.Text = "RM Barcode";
            this.rMBarcodeToolStripMenuItem.Click += new System.EventHandler(this.rMBarcodeToolStripMenuItem_Click);
            // 
            // rMDueReportToolStripMenuItem
            // 
            this.rMDueReportToolStripMenuItem.Name = "rMDueReportToolStripMenuItem";
            this.rMDueReportToolStripMenuItem.Size = new System.Drawing.Size(370, 26);
            this.rMDueReportToolStripMenuItem.Text = "RM Due Report";
            this.rMDueReportToolStripMenuItem.Click += new System.EventHandler(this.rMDueReportToolStripMenuItem_Click);
            // 
            // rMRejectionToolStripMenuItem
            // 
            this.rMRejectionToolStripMenuItem.Name = "rMRejectionToolStripMenuItem";
            this.rMRejectionToolStripMenuItem.Size = new System.Drawing.Size(370, 26);
            this.rMRejectionToolStripMenuItem.Text = "RM Rejection Note Details";
            this.rMRejectionToolStripMenuItem.Click += new System.EventHandler(this.rMRejectionToolStripMenuItem_Click);
            // 
            // fDARMAnalysisReportToolStripMenuItem
            // 
            this.fDARMAnalysisReportToolStripMenuItem.Name = "fDARMAnalysisReportToolStripMenuItem";
            this.fDARMAnalysisReportToolStripMenuItem.Size = new System.Drawing.Size(370, 26);
            this.fDARMAnalysisReportToolStripMenuItem.Text = "FDA RM Analysis Report";
            this.fDARMAnalysisReportToolStripMenuItem.Click += new System.EventHandler(this.fDARMAnalysisReportToolStripMenuItem_Click);
            // 
            // menuStripQTMSH
            // 
            this.menuStripQTMSH.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.menuStripQTMSH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuStripQTMSH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStripQTMSH.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.QTMSHmasterToolStripMenuItem,
            this.QTMSHtransactionToolStripMenuItem,
            this.QTMSHmodificationToolStripMenuItem,
            this.QTMSHDossiertoolStripMenuItem,
            this.QTMSHTDBtoolStripMenuItem,
            this.QTMSHSummarytoolStripMenuItem,
            this.QTMSHDetailtoolStripMenuItem,
            this.QTMSHMasterReporttoolStripMenuItem});
            this.menuStripQTMSH.Location = new System.Drawing.Point(0, 0);
            this.menuStripQTMSH.Name = "menuStripQTMSH";
            this.menuStripQTMSH.Padding = new System.Windows.Forms.Padding(0);
            this.menuStripQTMSH.Size = new System.Drawing.Size(1179, 28);
            this.menuStripQTMSH.TabIndex = 0;
            this.menuStripQTMSH.Text = "menuStrip1";
            this.menuStripQTMSH.Visible = false;
            // 
            // QTMSHmasterToolStripMenuItem
            // 
            this.QTMSHmasterToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.QTMSHmasterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vesselMasterToolStripMenuItem,
            this.tankMasterToolStripMenuItem,
            this.lineMasterToolStripMenuItem,
            this.bulkTechnicalFamilyMasterToolStripMenuItem1,
            this.testMasterToolStripMenuItem,
            this.formulaMasterToolStripMenuItem,
            this.preservativeMasterToolStripMenuItem1,
            this.preservativeMethodMasterToolStripMenuItem1,
            this.fGGlobalFamilyMasterToolStripMenuItem1,
            this.packingFamilyMasterToolStripMenuItem,
            this.fGFamilyMethodMasterToolStripMenuItem,
            this.fGPhysicoChemicalTestMethodMasterToolStripMenuItem,
            this.finishGoodMasterToolStripMenuItem,
            this.finishGoodMethodMasterToolStripMenuItem,
            this.packingTestMasterToolStripMenuItem,
            this.Mnu_fGSupplierMaster,
            this.fGOutSourceToolStripMenuItem});
            this.QTMSHmasterToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Highlight;
            this.QTMSHmasterToolStripMenuItem.Name = "QTMSHmasterToolStripMenuItem";
            this.QTMSHmasterToolStripMenuItem.Size = new System.Drawing.Size(76, 28);
            this.QTMSHmasterToolStripMenuItem.Text = "Master";
            this.QTMSHmasterToolStripMenuItem.Click += new System.EventHandler(this.QTMSHmasterToolStripMenuItem_Click);
            // 
            // vesselMasterToolStripMenuItem
            // 
            this.vesselMasterToolStripMenuItem.Name = "vesselMasterToolStripMenuItem";
            this.vesselMasterToolStripMenuItem.Size = new System.Drawing.Size(417, 26);
            this.vesselMasterToolStripMenuItem.Text = "Vessel Master";
            this.vesselMasterToolStripMenuItem.Click += new System.EventHandler(this.vesselMasterToolStripMenuItem_Click);
            // 
            // tankMasterToolStripMenuItem
            // 
            this.tankMasterToolStripMenuItem.Name = "tankMasterToolStripMenuItem";
            this.tankMasterToolStripMenuItem.Size = new System.Drawing.Size(417, 26);
            this.tankMasterToolStripMenuItem.Text = "Tank Master";
            this.tankMasterToolStripMenuItem.Click += new System.EventHandler(this.tankMasterToolStripMenuItem_Click);
            // 
            // lineMasterToolStripMenuItem
            // 
            this.lineMasterToolStripMenuItem.Name = "lineMasterToolStripMenuItem";
            this.lineMasterToolStripMenuItem.Size = new System.Drawing.Size(417, 26);
            this.lineMasterToolStripMenuItem.Text = "Line Master";
            this.lineMasterToolStripMenuItem.Click += new System.EventHandler(this.lineMasterToolStripMenuItem_Click);
            // 
            // bulkTechnicalFamilyMasterToolStripMenuItem1
            // 
            this.bulkTechnicalFamilyMasterToolStripMenuItem1.Name = "bulkTechnicalFamilyMasterToolStripMenuItem1";
            this.bulkTechnicalFamilyMasterToolStripMenuItem1.Size = new System.Drawing.Size(417, 26);
            this.bulkTechnicalFamilyMasterToolStripMenuItem1.Text = "Bulk Technical Family Master";
            this.bulkTechnicalFamilyMasterToolStripMenuItem1.Click += new System.EventHandler(this.bulkTechnicalFamilyMasterToolStripMenuItem1_Click);
            // 
            // testMasterToolStripMenuItem
            // 
            this.testMasterToolStripMenuItem.Name = "testMasterToolStripMenuItem";
            this.testMasterToolStripMenuItem.Size = new System.Drawing.Size(417, 26);
            this.testMasterToolStripMenuItem.Text = "Physico-Chemical Test Master";
            this.testMasterToolStripMenuItem.Click += new System.EventHandler(this.testMasterToolStripMenuItem_Click);
            // 
            // formulaMasterToolStripMenuItem
            // 
            this.formulaMasterToolStripMenuItem.Name = "formulaMasterToolStripMenuItem";
            this.formulaMasterToolStripMenuItem.Size = new System.Drawing.Size(417, 26);
            this.formulaMasterToolStripMenuItem.Text = "Formula Master";
            this.formulaMasterToolStripMenuItem.Click += new System.EventHandler(this.formulaMasterToolStripMenuItem_Click);
            // 
            // preservativeMasterToolStripMenuItem1
            // 
            this.preservativeMasterToolStripMenuItem1.Name = "preservativeMasterToolStripMenuItem1";
            this.preservativeMasterToolStripMenuItem1.Size = new System.Drawing.Size(417, 26);
            this.preservativeMasterToolStripMenuItem1.Text = "Preservative Master";
            this.preservativeMasterToolStripMenuItem1.Click += new System.EventHandler(this.preservativeMasterToolStripMenuItem1_Click);
            // 
            // preservativeMethodMasterToolStripMenuItem1
            // 
            this.preservativeMethodMasterToolStripMenuItem1.Name = "preservativeMethodMasterToolStripMenuItem1";
            this.preservativeMethodMasterToolStripMenuItem1.Size = new System.Drawing.Size(417, 26);
            this.preservativeMethodMasterToolStripMenuItem1.Text = "Preservative Method Master";
            this.preservativeMethodMasterToolStripMenuItem1.Click += new System.EventHandler(this.preservativeMethodMasterToolStripMenuItem1_Click);
            // 
            // fGGlobalFamilyMasterToolStripMenuItem1
            // 
            this.fGGlobalFamilyMasterToolStripMenuItem1.Name = "fGGlobalFamilyMasterToolStripMenuItem1";
            this.fGGlobalFamilyMasterToolStripMenuItem1.Size = new System.Drawing.Size(417, 26);
            this.fGGlobalFamilyMasterToolStripMenuItem1.Text = "FG Global Family Master";
            this.fGGlobalFamilyMasterToolStripMenuItem1.Click += new System.EventHandler(this.fGGlobalFamilyMasterToolStripMenuItem1_Click);
            // 
            // packingFamilyMasterToolStripMenuItem
            // 
            this.packingFamilyMasterToolStripMenuItem.Name = "packingFamilyMasterToolStripMenuItem";
            this.packingFamilyMasterToolStripMenuItem.Size = new System.Drawing.Size(417, 26);
            this.packingFamilyMasterToolStripMenuItem.Text = "Packing Technical Family Master";
            this.packingFamilyMasterToolStripMenuItem.Click += new System.EventHandler(this.packingFamilyMasterToolStripMenuItem_Click);
            // 
            // fGFamilyMethodMasterToolStripMenuItem
            // 
            this.fGFamilyMethodMasterToolStripMenuItem.Name = "fGFamilyMethodMasterToolStripMenuItem";
            this.fGFamilyMethodMasterToolStripMenuItem.Size = new System.Drawing.Size(417, 26);
            this.fGFamilyMethodMasterToolStripMenuItem.Text = "FG Family Method Master";
            this.fGFamilyMethodMasterToolStripMenuItem.Visible = false;
            this.fGFamilyMethodMasterToolStripMenuItem.Click += new System.EventHandler(this.fGFamilyMethodMasterToolStripMenuItem_Click);
            // 
            // fGPhysicoChemicalTestMethodMasterToolStripMenuItem
            // 
            this.fGPhysicoChemicalTestMethodMasterToolStripMenuItem.Name = "fGPhysicoChemicalTestMethodMasterToolStripMenuItem";
            this.fGPhysicoChemicalTestMethodMasterToolStripMenuItem.Size = new System.Drawing.Size(417, 26);
            this.fGPhysicoChemicalTestMethodMasterToolStripMenuItem.Text = "FG Physico-Chemical Test Method Master";
            this.fGPhysicoChemicalTestMethodMasterToolStripMenuItem.Click += new System.EventHandler(this.fGPhysicoChemicalTestMethodMasterToolStripMenuItem_Click);
            // 
            // finishGoodMasterToolStripMenuItem
            // 
            this.finishGoodMasterToolStripMenuItem.Name = "finishGoodMasterToolStripMenuItem";
            this.finishGoodMasterToolStripMenuItem.Size = new System.Drawing.Size(417, 26);
            this.finishGoodMasterToolStripMenuItem.Text = "Finish Good Master";
            this.finishGoodMasterToolStripMenuItem.Click += new System.EventHandler(this.finishGoodMasterToolStripMenuItem_Click);
            // 
            // finishGoodMethodMasterToolStripMenuItem
            // 
            this.finishGoodMethodMasterToolStripMenuItem.Name = "finishGoodMethodMasterToolStripMenuItem";
            this.finishGoodMethodMasterToolStripMenuItem.Size = new System.Drawing.Size(417, 26);
            this.finishGoodMethodMasterToolStripMenuItem.Text = "Finish Good Method Master";
            this.finishGoodMethodMasterToolStripMenuItem.Click += new System.EventHandler(this.finishGoodMethodMasterToolStripMenuItem_Click);
            // 
            // packingTestMasterToolStripMenuItem
            // 
            this.packingTestMasterToolStripMenuItem.Name = "packingTestMasterToolStripMenuItem";
            this.packingTestMasterToolStripMenuItem.Size = new System.Drawing.Size(417, 26);
            this.packingTestMasterToolStripMenuItem.Text = "Packing Test Master";
            this.packingTestMasterToolStripMenuItem.Click += new System.EventHandler(this.packingTestMasterToolStripMenuItem_Click);
            // 
            // Mnu_fGSupplierMaster
            // 
            this.Mnu_fGSupplierMaster.Name = "Mnu_fGSupplierMaster";
            this.Mnu_fGSupplierMaster.Size = new System.Drawing.Size(417, 26);
            this.Mnu_fGSupplierMaster.Text = "FG SubContractor Master";
            this.Mnu_fGSupplierMaster.Click += new System.EventHandler(this.Mnu_fGSupplierMaster_Click);
            // 
            // fGOutSourceToolStripMenuItem
            // 
            this.fGOutSourceToolStripMenuItem.Name = "fGOutSourceToolStripMenuItem";
            this.fGOutSourceToolStripMenuItem.Size = new System.Drawing.Size(417, 26);
            this.fGOutSourceToolStripMenuItem.Text = "FG Out Source";
            this.fGOutSourceToolStripMenuItem.Click += new System.EventHandler(this.fGOutSourceToolStripMenuItem_Click);
            // 
            // QTMSHtransactionToolStripMenuItem
            // 
            this.QTMSHtransactionToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.QTMSHtransactionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adjustmentTransactionToolStripMenuItem,
            this.bulkTestDetailsToolStripMenuItem,
            this.hPLCReferenceMgmtToolStripMenuItem,
            this.preservativeTestToolStripMenuItem,
            this.microbiologyTestToolStripMenuItem,
            this.tankSelectionToolStripMenuItem,
            this.lineSamplePackingDetailsToolStripMenuItem,
            this.lineSampleDetailsToolStripMenuItem,
            this.kitDetailsToolStripMenuItem2,
            this.sFDetailsToolStripMenuItem,
            this.fGReferenceManagementToolStripMenuItem1,
            this.finishedGoodTestToolStripMenuItem,
            this.finishedGoodTreatmentToolStripMenuItem,
            this.finishedGoodTestSFPackingToolStripMenuItem,
            this.fGReleaseDossierToolStripMenuItem,
            this.aOCSheetToolStripMenuItem,
            this.bulkTestDeailsSubcontractToolStripMenuItem,
            this.finishedGoodTestQuality1ToolStripMenuItem,
            this.retainerLocationDistractedToolStripMenuItem,
            this.stabilityTestToolStripMenuItem,
            this.stabilityTestConfigurationToolStripMenuItem,
            this.ageingTestToolStripMenuItem});
            this.QTMSHtransactionToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Highlight;
            this.QTMSHtransactionToolStripMenuItem.Name = "QTMSHtransactionToolStripMenuItem";
            this.QTMSHtransactionToolStripMenuItem.Size = new System.Drawing.Size(117, 28);
            this.QTMSHtransactionToolStripMenuItem.Text = "Transaction";
            // 
            // adjustmentTransactionToolStripMenuItem
            // 
            this.adjustmentTransactionToolStripMenuItem.Name = "adjustmentTransactionToolStripMenuItem";
            this.adjustmentTransactionToolStripMenuItem.Size = new System.Drawing.Size(335, 26);
            this.adjustmentTransactionToolStripMenuItem.Text = "Adjustment Transaction";
            this.adjustmentTransactionToolStripMenuItem.Click += new System.EventHandler(this.adjustmentTransactionToolStripMenuItem_Click);
            // 
            // bulkTestDetailsToolStripMenuItem
            // 
            this.bulkTestDetailsToolStripMenuItem.Name = "bulkTestDetailsToolStripMenuItem";
            this.bulkTestDetailsToolStripMenuItem.Size = new System.Drawing.Size(335, 26);
            this.bulkTestDetailsToolStripMenuItem.Text = "Bulk Test Details";
            this.bulkTestDetailsToolStripMenuItem.Click += new System.EventHandler(this.bulkTestDetailsToolStripMenuItem_Click);
            // 
            // hPLCReferenceMgmtToolStripMenuItem
            // 
            this.hPLCReferenceMgmtToolStripMenuItem.Name = "hPLCReferenceMgmtToolStripMenuItem";
            this.hPLCReferenceMgmtToolStripMenuItem.Size = new System.Drawing.Size(335, 26);
            this.hPLCReferenceMgmtToolStripMenuItem.Text = "HPLC Reference Mgmt";
            this.hPLCReferenceMgmtToolStripMenuItem.Click += new System.EventHandler(this.hPLCReferenceMgmtToolStripMenuItem_Click);
            // 
            // preservativeTestToolStripMenuItem
            // 
            this.preservativeTestToolStripMenuItem.Name = "preservativeTestToolStripMenuItem";
            this.preservativeTestToolStripMenuItem.Size = new System.Drawing.Size(335, 26);
            this.preservativeTestToolStripMenuItem.Text = "Preservative Test";
            this.preservativeTestToolStripMenuItem.Click += new System.EventHandler(this.preservativeTestToolStripMenuItem_Click);
            // 
            // microbiologyTestToolStripMenuItem
            // 
            this.microbiologyTestToolStripMenuItem.Name = "microbiologyTestToolStripMenuItem";
            this.microbiologyTestToolStripMenuItem.Size = new System.Drawing.Size(335, 26);
            this.microbiologyTestToolStripMenuItem.Text = "Microbiology Test";
            this.microbiologyTestToolStripMenuItem.Click += new System.EventHandler(this.microbiologyTestToolStripMenuItem_Click);
            // 
            // tankSelectionToolStripMenuItem
            // 
            this.tankSelectionToolStripMenuItem.Name = "tankSelectionToolStripMenuItem";
            this.tankSelectionToolStripMenuItem.Size = new System.Drawing.Size(335, 26);
            this.tankSelectionToolStripMenuItem.Text = "Tank Selection";
            this.tankSelectionToolStripMenuItem.Click += new System.EventHandler(this.tankSelectionToolStripMenuItem_Click);
            // 
            // lineSamplePackingDetailsToolStripMenuItem
            // 
            this.lineSamplePackingDetailsToolStripMenuItem.Name = "lineSamplePackingDetailsToolStripMenuItem";
            this.lineSamplePackingDetailsToolStripMenuItem.Size = new System.Drawing.Size(335, 26);
            this.lineSamplePackingDetailsToolStripMenuItem.Text = "Line Sample Packing Details";
            this.lineSamplePackingDetailsToolStripMenuItem.Click += new System.EventHandler(this.lineSamplePackingDetailsToolStripMenuItem_Click);
            // 
            // lineSampleDetailsToolStripMenuItem
            // 
            this.lineSampleDetailsToolStripMenuItem.Name = "lineSampleDetailsToolStripMenuItem";
            this.lineSampleDetailsToolStripMenuItem.Size = new System.Drawing.Size(335, 26);
            this.lineSampleDetailsToolStripMenuItem.Text = "Line Sample Details";
            this.lineSampleDetailsToolStripMenuItem.Click += new System.EventHandler(this.lineSampleDetailsToolStripMenuItem_Click);
            // 
            // kitDetailsToolStripMenuItem2
            // 
            this.kitDetailsToolStripMenuItem2.Name = "kitDetailsToolStripMenuItem2";
            this.kitDetailsToolStripMenuItem2.Size = new System.Drawing.Size(335, 26);
            this.kitDetailsToolStripMenuItem2.Text = "Kit Details";
            this.kitDetailsToolStripMenuItem2.Click += new System.EventHandler(this.kitDetailsToolStripMenuItem2_Click);
            // 
            // sFDetailsToolStripMenuItem
            // 
            this.sFDetailsToolStripMenuItem.Name = "sFDetailsToolStripMenuItem";
            this.sFDetailsToolStripMenuItem.Size = new System.Drawing.Size(335, 26);
            this.sFDetailsToolStripMenuItem.Text = "SF Details";
            this.sFDetailsToolStripMenuItem.Click += new System.EventHandler(this.sFDetailsToolStripMenuItem_Click);
            // 
            // fGReferenceManagementToolStripMenuItem1
            // 
            this.fGReferenceManagementToolStripMenuItem1.Name = "fGReferenceManagementToolStripMenuItem1";
            this.fGReferenceManagementToolStripMenuItem1.Size = new System.Drawing.Size(335, 26);
            this.fGReferenceManagementToolStripMenuItem1.Text = "FG Reference Management";
            this.fGReferenceManagementToolStripMenuItem1.Click += new System.EventHandler(this.fGReferenceManagementToolStripMenuItem1_Click);
            // 
            // finishedGoodTestToolStripMenuItem
            // 
            this.finishedGoodTestToolStripMenuItem.Name = "finishedGoodTestToolStripMenuItem";
            this.finishedGoodTestToolStripMenuItem.Size = new System.Drawing.Size(335, 26);
            this.finishedGoodTestToolStripMenuItem.Text = "Finished Good Test Quality";
            this.finishedGoodTestToolStripMenuItem.Click += new System.EventHandler(this.finishedGoodTestToolStripMenuItem_Click);
            // 
            // finishedGoodTreatmentToolStripMenuItem
            // 
            this.finishedGoodTreatmentToolStripMenuItem.Name = "finishedGoodTreatmentToolStripMenuItem";
            this.finishedGoodTreatmentToolStripMenuItem.Size = new System.Drawing.Size(335, 26);
            this.finishedGoodTreatmentToolStripMenuItem.Text = "Finished Good Treatment";
            this.finishedGoodTreatmentToolStripMenuItem.Click += new System.EventHandler(this.finishedGoodTreatmentToolStripMenuItem_Click);
            // 
            // finishedGoodTestSFPackingToolStripMenuItem
            // 
            this.finishedGoodTestSFPackingToolStripMenuItem.Name = "finishedGoodTestSFPackingToolStripMenuItem";
            this.finishedGoodTestSFPackingToolStripMenuItem.Size = new System.Drawing.Size(335, 26);
            this.finishedGoodTestSFPackingToolStripMenuItem.Text = "Finished Good Test SF Packing";
            this.finishedGoodTestSFPackingToolStripMenuItem.Click += new System.EventHandler(this.finishedGoodTestSFPackingToolStripMenuItem_Click);
            // 
            // fGReleaseDossierToolStripMenuItem
            // 
            this.fGReleaseDossierToolStripMenuItem.Name = "fGReleaseDossierToolStripMenuItem";
            this.fGReleaseDossierToolStripMenuItem.Size = new System.Drawing.Size(335, 26);
            this.fGReleaseDossierToolStripMenuItem.Text = "First FG release dossier";
            this.fGReleaseDossierToolStripMenuItem.Click += new System.EventHandler(this.fGReleaseDossierToolStripMenuItem_Click);
            // 
            // aOCSheetToolStripMenuItem
            // 
            this.aOCSheetToolStripMenuItem.Name = "aOCSheetToolStripMenuItem";
            this.aOCSheetToolStripMenuItem.Size = new System.Drawing.Size(335, 26);
            this.aOCSheetToolStripMenuItem.Text = "AOC Sheet";
            this.aOCSheetToolStripMenuItem.Click += new System.EventHandler(this.aOCSheetToolStripMenuItem_Click);
            // 
            // bulkTestDeailsSubcontractToolStripMenuItem
            // 
            this.bulkTestDeailsSubcontractToolStripMenuItem.Name = "bulkTestDeailsSubcontractToolStripMenuItem";
            this.bulkTestDeailsSubcontractToolStripMenuItem.Size = new System.Drawing.Size(335, 26);
            this.bulkTestDeailsSubcontractToolStripMenuItem.Text = "BulkTestDeails-Subcontract";
            this.bulkTestDeailsSubcontractToolStripMenuItem.Click += new System.EventHandler(this.bulkTestDeailsSubcontractToolStripMenuItem_Click);
            // 
            // finishedGoodTestQuality1ToolStripMenuItem
            // 
            this.finishedGoodTestQuality1ToolStripMenuItem.Name = "finishedGoodTestQuality1ToolStripMenuItem";
            this.finishedGoodTestQuality1ToolStripMenuItem.Size = new System.Drawing.Size(335, 26);
            this.finishedGoodTestQuality1ToolStripMenuItem.Text = "Finished Good Test Quality 1";
            this.finishedGoodTestQuality1ToolStripMenuItem.Visible = false;
            this.finishedGoodTestQuality1ToolStripMenuItem.Click += new System.EventHandler(this.finishedGoodTestQuality1ToolStripMenuItem_Click);
            // 
            // retainerLocationDistractedToolStripMenuItem
            // 
            this.retainerLocationDistractedToolStripMenuItem.Name = "retainerLocationDistractedToolStripMenuItem";
            this.retainerLocationDistractedToolStripMenuItem.Size = new System.Drawing.Size(335, 26);
            this.retainerLocationDistractedToolStripMenuItem.Text = "Retainer Location Destruction";
            this.retainerLocationDistractedToolStripMenuItem.Click += new System.EventHandler(this.retainerLocationDistractedToolStripMenuItem_Click);
            // 
            // stabilityTestToolStripMenuItem
            // 
            this.stabilityTestToolStripMenuItem.Name = "stabilityTestToolStripMenuItem";
            this.stabilityTestToolStripMenuItem.Size = new System.Drawing.Size(335, 26);
            this.stabilityTestToolStripMenuItem.Text = "Stability Test Configuration";
            this.stabilityTestToolStripMenuItem.Click += new System.EventHandler(this.stabilityTestConfigurationToolStripMenuItem_Click);
            // 
            // stabilityTestConfigurationToolStripMenuItem
            // 
            this.stabilityTestConfigurationToolStripMenuItem.Name = "stabilityTestConfigurationToolStripMenuItem";
            this.stabilityTestConfigurationToolStripMenuItem.Size = new System.Drawing.Size(335, 26);
            this.stabilityTestConfigurationToolStripMenuItem.Text = "Stability Test ";
            this.stabilityTestConfigurationToolStripMenuItem.Click += new System.EventHandler(this.stabilityTestToolStripMenuItem_Click);
            // 
            // ageingTestToolStripMenuItem
            // 
            this.ageingTestToolStripMenuItem.Name = "ageingTestToolStripMenuItem";
            this.ageingTestToolStripMenuItem.Size = new System.Drawing.Size(335, 26);
            this.ageingTestToolStripMenuItem.Text = "Ageing Test";
            this.ageingTestToolStripMenuItem.Click += new System.EventHandler(this.ageingTestToolStripMenuItem_Click);
            // 
            // QTMSHmodificationToolStripMenuItem
            // 
            this.QTMSHmodificationToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.QTMSHmodificationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bulkTestDetailsToolStripMenuItem1,
            this.lineSamplePackingToolStripMenuItem,
            this.lineSampleDetailsToolStripMenuItem1,
            this.microbiologyTestToolStripMenuItem1,
            this.preservativeTestToolStripMenuItem1,
            this.kitDetailsToolStripMenuItem3,
            this.sFDetailsToolStripMenuItem1,
            this.finishedGoodTestToolStripMenuItem2});
            this.QTMSHmodificationToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Highlight;
            this.QTMSHmodificationToolStripMenuItem.Name = "QTMSHmodificationToolStripMenuItem";
            this.QTMSHmodificationToolStripMenuItem.Size = new System.Drawing.Size(117, 28);
            this.QTMSHmodificationToolStripMenuItem.Text = "Modification";
            // 
            // bulkTestDetailsToolStripMenuItem1
            // 
            this.bulkTestDetailsToolStripMenuItem1.Name = "bulkTestDetailsToolStripMenuItem1";
            this.bulkTestDetailsToolStripMenuItem1.Size = new System.Drawing.Size(248, 26);
            this.bulkTestDetailsToolStripMenuItem1.Text = "Bulk Test Details";
            this.bulkTestDetailsToolStripMenuItem1.Click += new System.EventHandler(this.bulkTestDetailsToolStripMenuItem1_Click);
            // 
            // lineSamplePackingToolStripMenuItem
            // 
            this.lineSamplePackingToolStripMenuItem.Name = "lineSamplePackingToolStripMenuItem";
            this.lineSamplePackingToolStripMenuItem.Size = new System.Drawing.Size(248, 26);
            this.lineSamplePackingToolStripMenuItem.Text = "Line Sample Packing";
            this.lineSamplePackingToolStripMenuItem.Click += new System.EventHandler(this.lineSamplePackingToolStripMenuItem_Click);
            // 
            // lineSampleDetailsToolStripMenuItem1
            // 
            this.lineSampleDetailsToolStripMenuItem1.Name = "lineSampleDetailsToolStripMenuItem1";
            this.lineSampleDetailsToolStripMenuItem1.Size = new System.Drawing.Size(248, 26);
            this.lineSampleDetailsToolStripMenuItem1.Text = "Line Sample Details";
            this.lineSampleDetailsToolStripMenuItem1.Click += new System.EventHandler(this.lineSampleDetailsToolStripMenuItem1_Click);
            // 
            // microbiologyTestToolStripMenuItem1
            // 
            this.microbiologyTestToolStripMenuItem1.Name = "microbiologyTestToolStripMenuItem1";
            this.microbiologyTestToolStripMenuItem1.Size = new System.Drawing.Size(248, 26);
            this.microbiologyTestToolStripMenuItem1.Text = "Microbiology Test";
            this.microbiologyTestToolStripMenuItem1.Click += new System.EventHandler(this.microbiologyTestToolStripMenuItem1_Click);
            // 
            // preservativeTestToolStripMenuItem1
            // 
            this.preservativeTestToolStripMenuItem1.Name = "preservativeTestToolStripMenuItem1";
            this.preservativeTestToolStripMenuItem1.Size = new System.Drawing.Size(248, 26);
            this.preservativeTestToolStripMenuItem1.Text = "Preservative Test";
            this.preservativeTestToolStripMenuItem1.Click += new System.EventHandler(this.preservativeTestToolStripMenuItem1_Click);
            // 
            // kitDetailsToolStripMenuItem3
            // 
            this.kitDetailsToolStripMenuItem3.Name = "kitDetailsToolStripMenuItem3";
            this.kitDetailsToolStripMenuItem3.Size = new System.Drawing.Size(248, 26);
            this.kitDetailsToolStripMenuItem3.Text = "Kit Details";
            this.kitDetailsToolStripMenuItem3.Click += new System.EventHandler(this.kitDetailsToolStripMenuItem3_Click);
            // 
            // sFDetailsToolStripMenuItem1
            // 
            this.sFDetailsToolStripMenuItem1.Name = "sFDetailsToolStripMenuItem1";
            this.sFDetailsToolStripMenuItem1.Size = new System.Drawing.Size(248, 26);
            this.sFDetailsToolStripMenuItem1.Text = "SF Details";
            this.sFDetailsToolStripMenuItem1.Click += new System.EventHandler(this.sFDetailsToolStripMenuItem1_Click);
            // 
            // finishedGoodTestToolStripMenuItem2
            // 
            this.finishedGoodTestToolStripMenuItem2.Name = "finishedGoodTestToolStripMenuItem2";
            this.finishedGoodTestToolStripMenuItem2.Size = new System.Drawing.Size(248, 26);
            this.finishedGoodTestToolStripMenuItem2.Text = "Finished Good Test";
            this.finishedGoodTestToolStripMenuItem2.Click += new System.EventHandler(this.finishedGoodTestToolStripMenuItem2_Click);
            // 
            // QTMSHDossiertoolStripMenuItem
            // 
            this.QTMSHDossiertoolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.QTMSHDossiertoolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.QTMSHDossiertoolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.preLotDossierReportToolStripMenuItem,
            this.lotDossierReportToolStripMenuItem,
            this.lotDossierDetailReportToolStripMenuItem1,
            this.bMRLotDossierReportToolStripMenuItem});
            this.QTMSHDossiertoolStripMenuItem.ForeColor = System.Drawing.SystemColors.Highlight;
            this.QTMSHDossiertoolStripMenuItem.Name = "QTMSHDossiertoolStripMenuItem";
            this.QTMSHDossiertoolStripMenuItem.Size = new System.Drawing.Size(83, 28);
            this.QTMSHDossiertoolStripMenuItem.Text = "Dossier";
            // 
            // preLotDossierReportToolStripMenuItem
            // 
            this.preLotDossierReportToolStripMenuItem.Name = "preLotDossierReportToolStripMenuItem";
            this.preLotDossierReportToolStripMenuItem.Size = new System.Drawing.Size(281, 26);
            this.preLotDossierReportToolStripMenuItem.Text = "Pre Lot Dossier Report";
            this.preLotDossierReportToolStripMenuItem.Click += new System.EventHandler(this.preLotDossierReportToolStripMenuItem_Click_1);
            // 
            // lotDossierReportToolStripMenuItem
            // 
            this.lotDossierReportToolStripMenuItem.Name = "lotDossierReportToolStripMenuItem";
            this.lotDossierReportToolStripMenuItem.Size = new System.Drawing.Size(281, 26);
            this.lotDossierReportToolStripMenuItem.Text = "Lot Dossier Report";
            this.lotDossierReportToolStripMenuItem.Click += new System.EventHandler(this.lotDossierReportToolStripMenuItem_Click_1);
            // 
            // lotDossierDetailReportToolStripMenuItem1
            // 
            this.lotDossierDetailReportToolStripMenuItem1.Name = "lotDossierDetailReportToolStripMenuItem1";
            this.lotDossierDetailReportToolStripMenuItem1.Size = new System.Drawing.Size(281, 26);
            this.lotDossierDetailReportToolStripMenuItem1.Text = "Lot Dossier Detail Report";
            this.lotDossierDetailReportToolStripMenuItem1.Click += new System.EventHandler(this.lotDossierDetailReportToolStripMenuItem1_Click);
            // 
            // bMRLotDossierReportToolStripMenuItem
            // 
            this.bMRLotDossierReportToolStripMenuItem.Name = "bMRLotDossierReportToolStripMenuItem";
            this.bMRLotDossierReportToolStripMenuItem.Size = new System.Drawing.Size(281, 26);
            this.bMRLotDossierReportToolStripMenuItem.Text = "BMR Lot Dossier Report";
            this.bMRLotDossierReportToolStripMenuItem.Click += new System.EventHandler(this.bMRLotDossierReportToolStripMenuItem_Click);
            // 
            // QTMSHTDBtoolStripMenuItem
            // 
            this.QTMSHTDBtoolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.QTMSHTDBtoolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.QTMSHTDBtoolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bulkTDBReportToolStripMenuItem,
            this.microbiologyTDBReportToolStripMenuItem,
            this.globalFGTDBReportToolStripMenuItem1,
            this.fGLineDetailsTDBReportToolStripMenuItem,
            this.fillingAndPackingQualityReportToolStripMenuItem1});
            this.QTMSHTDBtoolStripMenuItem.ForeColor = System.Drawing.SystemColors.Highlight;
            this.QTMSHTDBtoolStripMenuItem.Name = "QTMSHTDBtoolStripMenuItem";
            this.QTMSHTDBtoolStripMenuItem.Size = new System.Drawing.Size(59, 28);
            this.QTMSHTDBtoolStripMenuItem.Text = "TDB";
            // 
            // bulkTDBReportToolStripMenuItem
            // 
            this.bulkTDBReportToolStripMenuItem.Name = "bulkTDBReportToolStripMenuItem";
            this.bulkTDBReportToolStripMenuItem.Size = new System.Drawing.Size(351, 26);
            this.bulkTDBReportToolStripMenuItem.Text = "Bulk TDB Report";
            this.bulkTDBReportToolStripMenuItem.Click += new System.EventHandler(this.bulkTDBReportToolStripMenuItem_Click);
            // 
            // microbiologyTDBReportToolStripMenuItem
            // 
            this.microbiologyTDBReportToolStripMenuItem.Name = "microbiologyTDBReportToolStripMenuItem";
            this.microbiologyTDBReportToolStripMenuItem.Size = new System.Drawing.Size(351, 26);
            this.microbiologyTDBReportToolStripMenuItem.Text = "Microbiology TDB Report";
            this.microbiologyTDBReportToolStripMenuItem.Click += new System.EventHandler(this.microbiologyTDBReportToolStripMenuItem_Click);
            // 
            // globalFGTDBReportToolStripMenuItem1
            // 
            this.globalFGTDBReportToolStripMenuItem1.Name = "globalFGTDBReportToolStripMenuItem1";
            this.globalFGTDBReportToolStripMenuItem1.Size = new System.Drawing.Size(351, 26);
            this.globalFGTDBReportToolStripMenuItem1.Text = "Global FG TDB Report";
            this.globalFGTDBReportToolStripMenuItem1.Click += new System.EventHandler(this.globalFGTDBReportToolStripMenuItem1_Click);
            // 
            // fGLineDetailsTDBReportToolStripMenuItem
            // 
            this.fGLineDetailsTDBReportToolStripMenuItem.Name = "fGLineDetailsTDBReportToolStripMenuItem";
            this.fGLineDetailsTDBReportToolStripMenuItem.Size = new System.Drawing.Size(351, 26);
            this.fGLineDetailsTDBReportToolStripMenuItem.Text = "FG Line Details TDB Report";
            this.fGLineDetailsTDBReportToolStripMenuItem.Click += new System.EventHandler(this.fGLineDetailsTDBReportToolStripMenuItem_Click);
            // 
            // fillingAndPackingQualityReportToolStripMenuItem1
            // 
            this.fillingAndPackingQualityReportToolStripMenuItem1.Name = "fillingAndPackingQualityReportToolStripMenuItem1";
            this.fillingAndPackingQualityReportToolStripMenuItem1.Size = new System.Drawing.Size(351, 26);
            this.fillingAndPackingQualityReportToolStripMenuItem1.Text = "Filling and Packing Quality Report";
            this.fillingAndPackingQualityReportToolStripMenuItem1.Click += new System.EventHandler(this.fillingAndPackingQualityReportToolStripMenuItem1_Click);
            // 
            // QTMSHSummarytoolStripMenuItem
            // 
            this.QTMSHSummarytoolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.QTMSHSummarytoolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.QTMSHSummarytoolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bulkTestDetailsReportToolStripMenuItem,
            this.bulkTestNonBPCReportToolStripMenuItem,
            this.bulkTestNewLaunchReportToolStripMenuItem,
            this.bulkTestNonValidatedReportToolStripMenuItem,
            this.bMRPreSummaryReportToolStripMenuItem,
            this.bMRSummaryReportToolStripMenuItem,
            this.bulkPendingReportToolStripMenuItem,
            this.linePackingDetailsReportToolStripMenuItem,
            this.lineSampleSummaryReportToolStripMenuItem,
            this.preservativeSummaryReportToolStripMenuItem,
            this.microbiologySummaryReportToolStripMenuItem,
            this.finishedGoodTransactionReportToolStripMenuItem,
            this.finishedGoodSummaryReportToolStripMenuItem1,
            this.finishedGoodNonBPCReportToolStripMenuItem,
            this.fGBulkPendingReportToolStripMenuItem,
            this.qStatusSummaryReportToolStripMenuItem,
            this.lotDossierSummaryReportToolStripMenuItem,
            this.fGReportToolStripMenuItem,
            this.rejectionNoteFGToolStripMenuItem,
            this.analysisSummaryReportToolStripMenuItem,
            this.fGReleaseDossierToolStripMenuItem1,
            this.FGDeclarationLotNoReporttoolStripMenuItem,
            this.retainerLocationReportToolStripMenuItem,
            this.toolStripMenuItem5,
            this.fGRefToolStripMenuItem,
            this.aOCReportToolStripMenuItem,
            this.oOSLogReportToolStripMenuItem,
            this.fGDueReportToolStripMenuItem,
            this.madeLastProductionFormulaToolStripMenuItem,
            this.bulkQuaterReportToolStripMenuItem,
            this.bulkValidateNonvalidatedMenuItem6,
            this.DestructedLocation,
            this.PendingDestructLocationtoolStripMenuItem});
            this.QTMSHSummarytoolStripMenuItem.ForeColor = System.Drawing.SystemColors.Highlight;
            this.QTMSHSummarytoolStripMenuItem.Name = "QTMSHSummarytoolStripMenuItem";
            this.QTMSHSummarytoolStripMenuItem.Size = new System.Drawing.Size(97, 28);
            this.QTMSHSummarytoolStripMenuItem.Text = "Summary";
            // 
            // bulkTestDetailsReportToolStripMenuItem
            // 
            this.bulkTestDetailsReportToolStripMenuItem.Name = "bulkTestDetailsReportToolStripMenuItem";
            this.bulkTestDetailsReportToolStripMenuItem.Size = new System.Drawing.Size(390, 26);
            this.bulkTestDetailsReportToolStripMenuItem.Text = "Bulk Test Details Report";
            this.bulkTestDetailsReportToolStripMenuItem.Click += new System.EventHandler(this.bulkTestDetailsReportToolStripMenuItem_Click_1);
            // 
            // bulkTestNonBPCReportToolStripMenuItem
            // 
            this.bulkTestNonBPCReportToolStripMenuItem.Name = "bulkTestNonBPCReportToolStripMenuItem";
            this.bulkTestNonBPCReportToolStripMenuItem.Size = new System.Drawing.Size(390, 26);
            this.bulkTestNonBPCReportToolStripMenuItem.Text = "Bulk Test Non BPC Report";
            this.bulkTestNonBPCReportToolStripMenuItem.Click += new System.EventHandler(this.bulkTestNonBPCReportToolStripMenuItem_Click);
            // 
            // bulkTestNewLaunchReportToolStripMenuItem
            // 
            this.bulkTestNewLaunchReportToolStripMenuItem.Name = "bulkTestNewLaunchReportToolStripMenuItem";
            this.bulkTestNewLaunchReportToolStripMenuItem.Size = new System.Drawing.Size(390, 26);
            this.bulkTestNewLaunchReportToolStripMenuItem.Text = "Bulk Test New Launch Report";
            this.bulkTestNewLaunchReportToolStripMenuItem.Click += new System.EventHandler(this.bulkTestNewLaunchReportToolStripMenuItem_Click);
            // 
            // bulkTestNonValidatedReportToolStripMenuItem
            // 
            this.bulkTestNonValidatedReportToolStripMenuItem.Name = "bulkTestNonValidatedReportToolStripMenuItem";
            this.bulkTestNonValidatedReportToolStripMenuItem.Size = new System.Drawing.Size(390, 26);
            this.bulkTestNonValidatedReportToolStripMenuItem.Text = "Bulk Test Non Validated Report";
            this.bulkTestNonValidatedReportToolStripMenuItem.Click += new System.EventHandler(this.bulkTestNonValidatedReportToolStripMenuItem_Click);
            // 
            // bMRPreSummaryReportToolStripMenuItem
            // 
            this.bMRPreSummaryReportToolStripMenuItem.Name = "bMRPreSummaryReportToolStripMenuItem";
            this.bMRPreSummaryReportToolStripMenuItem.Size = new System.Drawing.Size(390, 26);
            this.bMRPreSummaryReportToolStripMenuItem.Text = "BMR Pre-Summary Report";
            this.bMRPreSummaryReportToolStripMenuItem.Click += new System.EventHandler(this.bMRPreSummaryReportToolStripMenuItem_Click);
            // 
            // bMRSummaryReportToolStripMenuItem
            // 
            this.bMRSummaryReportToolStripMenuItem.Name = "bMRSummaryReportToolStripMenuItem";
            this.bMRSummaryReportToolStripMenuItem.Size = new System.Drawing.Size(390, 26);
            this.bMRSummaryReportToolStripMenuItem.Text = "BMR Summary Report";
            this.bMRSummaryReportToolStripMenuItem.Click += new System.EventHandler(this.bMRSummaryReportToolStripMenuItem_Click);
            // 
            // bulkPendingReportToolStripMenuItem
            // 
            this.bulkPendingReportToolStripMenuItem.Name = "bulkPendingReportToolStripMenuItem";
            this.bulkPendingReportToolStripMenuItem.Size = new System.Drawing.Size(390, 26);
            this.bulkPendingReportToolStripMenuItem.Text = "Bulk Pending Report";
            this.bulkPendingReportToolStripMenuItem.Click += new System.EventHandler(this.bulkPendingReportToolStripMenuItem_Click);
            // 
            // linePackingDetailsReportToolStripMenuItem
            // 
            this.linePackingDetailsReportToolStripMenuItem.Name = "linePackingDetailsReportToolStripMenuItem";
            this.linePackingDetailsReportToolStripMenuItem.Size = new System.Drawing.Size(390, 26);
            this.linePackingDetailsReportToolStripMenuItem.Text = "Line Packing Details Report";
            this.linePackingDetailsReportToolStripMenuItem.Click += new System.EventHandler(this.linePackingDetailsReportToolStripMenuItem_Click_1);
            // 
            // lineSampleSummaryReportToolStripMenuItem
            // 
            this.lineSampleSummaryReportToolStripMenuItem.Name = "lineSampleSummaryReportToolStripMenuItem";
            this.lineSampleSummaryReportToolStripMenuItem.Size = new System.Drawing.Size(390, 26);
            this.lineSampleSummaryReportToolStripMenuItem.Text = "Line Sample Summary Report";
            this.lineSampleSummaryReportToolStripMenuItem.Click += new System.EventHandler(this.lineSampleSummaryReportToolStripMenuItem_Click);
            // 
            // preservativeSummaryReportToolStripMenuItem
            // 
            this.preservativeSummaryReportToolStripMenuItem.Name = "preservativeSummaryReportToolStripMenuItem";
            this.preservativeSummaryReportToolStripMenuItem.Size = new System.Drawing.Size(390, 26);
            this.preservativeSummaryReportToolStripMenuItem.Text = "Preservative Summary Report";
            this.preservativeSummaryReportToolStripMenuItem.Click += new System.EventHandler(this.preservativeSummaryReportToolStripMenuItem_Click);
            // 
            // microbiologySummaryReportToolStripMenuItem
            // 
            this.microbiologySummaryReportToolStripMenuItem.Name = "microbiologySummaryReportToolStripMenuItem";
            this.microbiologySummaryReportToolStripMenuItem.Size = new System.Drawing.Size(390, 26);
            this.microbiologySummaryReportToolStripMenuItem.Text = "Microbiology Summary Report";
            this.microbiologySummaryReportToolStripMenuItem.Click += new System.EventHandler(this.microbiologySummaryReportToolStripMenuItem_Click_1);
            // 
            // finishedGoodTransactionReportToolStripMenuItem
            // 
            this.finishedGoodTransactionReportToolStripMenuItem.Name = "finishedGoodTransactionReportToolStripMenuItem";
            this.finishedGoodTransactionReportToolStripMenuItem.Size = new System.Drawing.Size(390, 26);
            this.finishedGoodTransactionReportToolStripMenuItem.Text = "Finished Good Transaction Report";
            this.finishedGoodTransactionReportToolStripMenuItem.Click += new System.EventHandler(this.finishedGoodTransactionReportToolStripMenuItem_Click_1);
            // 
            // finishedGoodSummaryReportToolStripMenuItem1
            // 
            this.finishedGoodSummaryReportToolStripMenuItem1.Name = "finishedGoodSummaryReportToolStripMenuItem1";
            this.finishedGoodSummaryReportToolStripMenuItem1.Size = new System.Drawing.Size(390, 26);
            this.finishedGoodSummaryReportToolStripMenuItem1.Text = "Finished Good Summary Report";
            this.finishedGoodSummaryReportToolStripMenuItem1.Click += new System.EventHandler(this.finishedGoodSummaryReportToolStripMenuItem1_Click);
            // 
            // finishedGoodNonBPCReportToolStripMenuItem
            // 
            this.finishedGoodNonBPCReportToolStripMenuItem.Name = "finishedGoodNonBPCReportToolStripMenuItem";
            this.finishedGoodNonBPCReportToolStripMenuItem.Size = new System.Drawing.Size(390, 26);
            this.finishedGoodNonBPCReportToolStripMenuItem.Text = "Finished Good Non BPC Report";
            this.finishedGoodNonBPCReportToolStripMenuItem.Click += new System.EventHandler(this.finishedGoodNonBPCReportToolStripMenuItem_Click);
            // 
            // fGBulkPendingReportToolStripMenuItem
            // 
            this.fGBulkPendingReportToolStripMenuItem.Name = "fGBulkPendingReportToolStripMenuItem";
            this.fGBulkPendingReportToolStripMenuItem.Size = new System.Drawing.Size(390, 26);
            this.fGBulkPendingReportToolStripMenuItem.Text = "FG Bulk Pending Report";
            this.fGBulkPendingReportToolStripMenuItem.Click += new System.EventHandler(this.fGBulkPendingReportToolStripMenuItem_Click);
            // 
            // qStatusSummaryReportToolStripMenuItem
            // 
            this.qStatusSummaryReportToolStripMenuItem.Name = "qStatusSummaryReportToolStripMenuItem";
            this.qStatusSummaryReportToolStripMenuItem.Size = new System.Drawing.Size(390, 26);
            this.qStatusSummaryReportToolStripMenuItem.Text = "QStatus Summary Report";
            this.qStatusSummaryReportToolStripMenuItem.Click += new System.EventHandler(this.qStatusSummaryReportToolStripMenuItem_Click);
            // 
            // lotDossierSummaryReportToolStripMenuItem
            // 
            this.lotDossierSummaryReportToolStripMenuItem.Name = "lotDossierSummaryReportToolStripMenuItem";
            this.lotDossierSummaryReportToolStripMenuItem.Size = new System.Drawing.Size(390, 26);
            this.lotDossierSummaryReportToolStripMenuItem.Text = "Lot Dossier Summary Report";
            this.lotDossierSummaryReportToolStripMenuItem.Click += new System.EventHandler(this.lotDossierSummaryReportToolStripMenuItem_Click_1);
            // 
            // fGReportToolStripMenuItem
            // 
            this.fGReportToolStripMenuItem.Name = "fGReportToolStripMenuItem";
            this.fGReportToolStripMenuItem.Size = new System.Drawing.Size(390, 26);
            this.fGReportToolStripMenuItem.Text = "FG Report";
            this.fGReportToolStripMenuItem.Click += new System.EventHandler(this.fGReportToolStripMenuItem_Click);
            // 
            // rejectionNoteFGToolStripMenuItem
            // 
            this.rejectionNoteFGToolStripMenuItem.Name = "rejectionNoteFGToolStripMenuItem";
            this.rejectionNoteFGToolStripMenuItem.Size = new System.Drawing.Size(390, 26);
            this.rejectionNoteFGToolStripMenuItem.Text = "FG Rejection Note";
            this.rejectionNoteFGToolStripMenuItem.Click += new System.EventHandler(this.rejectionNoteFGToolStripMenuItem_Click);
            // 
            // analysisSummaryReportToolStripMenuItem
            // 
            this.analysisSummaryReportToolStripMenuItem.Name = "analysisSummaryReportToolStripMenuItem";
            this.analysisSummaryReportToolStripMenuItem.Size = new System.Drawing.Size(390, 26);
            this.analysisSummaryReportToolStripMenuItem.Text = "Analysis Summary Report";
            this.analysisSummaryReportToolStripMenuItem.Click += new System.EventHandler(this.analysisSummaryReportToolStripMenuItem_Click);
            // 
            // fGReleaseDossierToolStripMenuItem1
            // 
            this.fGReleaseDossierToolStripMenuItem1.Name = "fGReleaseDossierToolStripMenuItem1";
            this.fGReleaseDossierToolStripMenuItem1.Size = new System.Drawing.Size(390, 26);
            this.fGReleaseDossierToolStripMenuItem1.Text = "FG Release Dossier";
            this.fGReleaseDossierToolStripMenuItem1.Click += new System.EventHandler(this.fGReleaseDossierToolStripMenuItem1_Click);
            // 
            // FGDeclarationLotNoReporttoolStripMenuItem
            // 
            this.FGDeclarationLotNoReporttoolStripMenuItem.Name = "FGDeclarationLotNoReporttoolStripMenuItem";
            this.FGDeclarationLotNoReporttoolStripMenuItem.Size = new System.Drawing.Size(390, 26);
            this.FGDeclarationLotNoReporttoolStripMenuItem.Text = "FG Declaration Lot No";
            this.FGDeclarationLotNoReporttoolStripMenuItem.Click += new System.EventHandler(this.FGDeclarationLotNoReporttoolStripMenuItem_Click);
            // 
            // retainerLocationReportToolStripMenuItem
            // 
            this.retainerLocationReportToolStripMenuItem.Name = "retainerLocationReportToolStripMenuItem";
            this.retainerLocationReportToolStripMenuItem.Size = new System.Drawing.Size(390, 26);
            this.retainerLocationReportToolStripMenuItem.Text = "Retainer Location Report";
            this.retainerLocationReportToolStripMenuItem.Click += new System.EventHandler(this.retainerLocationReportToolStripMenuItem_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(390, 26);
            this.toolStripMenuItem5.Text = "Retainer Location Report PkgWo";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem5_Click);
            // 
            // fGRefToolStripMenuItem
            // 
            this.fGRefToolStripMenuItem.Name = "fGRefToolStripMenuItem";
            this.fGRefToolStripMenuItem.Size = new System.Drawing.Size(390, 26);
            this.fGRefToolStripMenuItem.Text = "FG Reference Mgmt Summary Report";
            this.fGRefToolStripMenuItem.Click += new System.EventHandler(this.fGRefToolStripMenuItem_Click);
            // 
            // aOCReportToolStripMenuItem
            // 
            this.aOCReportToolStripMenuItem.Name = "aOCReportToolStripMenuItem";
            this.aOCReportToolStripMenuItem.Size = new System.Drawing.Size(390, 26);
            this.aOCReportToolStripMenuItem.Text = "AOC Report";
            this.aOCReportToolStripMenuItem.Click += new System.EventHandler(this.aOCReportToolStripMenuItem_Click);
            // 
            // oOSLogReportToolStripMenuItem
            // 
            this.oOSLogReportToolStripMenuItem.Name = "oOSLogReportToolStripMenuItem";
            this.oOSLogReportToolStripMenuItem.Size = new System.Drawing.Size(390, 26);
            this.oOSLogReportToolStripMenuItem.Text = "OOS Log Report";
            this.oOSLogReportToolStripMenuItem.Click += new System.EventHandler(this.oOSLogReportToolStripMenuItem_Click);
            // 
            // fGDueReportToolStripMenuItem
            // 
            this.fGDueReportToolStripMenuItem.Name = "fGDueReportToolStripMenuItem";
            this.fGDueReportToolStripMenuItem.Size = new System.Drawing.Size(390, 26);
            this.fGDueReportToolStripMenuItem.Text = "FG Due Report";
            this.fGDueReportToolStripMenuItem.Click += new System.EventHandler(this.fGDueReportToolStripMenuItem_Click);
            // 
            // madeLastProductionFormulaToolStripMenuItem
            // 
            this.madeLastProductionFormulaToolStripMenuItem.Name = "madeLastProductionFormulaToolStripMenuItem";
            this.madeLastProductionFormulaToolStripMenuItem.Size = new System.Drawing.Size(390, 26);
            this.madeLastProductionFormulaToolStripMenuItem.Text = "Made Last Production Formula";
            this.madeLastProductionFormulaToolStripMenuItem.Click += new System.EventHandler(this.madeLastProductionFormulaToolStripMenuItem_Click);
            // 
            // bulkQuaterReportToolStripMenuItem
            // 
            this.bulkQuaterReportToolStripMenuItem.Name = "bulkQuaterReportToolStripMenuItem";
            this.bulkQuaterReportToolStripMenuItem.Size = new System.Drawing.Size(390, 26);
            this.bulkQuaterReportToolStripMenuItem.Text = "Mercury Sample Refrence Managment";
            this.bulkQuaterReportToolStripMenuItem.Click += new System.EventHandler(this.bulkQuaterReportToolStripMenuItem_Click);
            // 
            // bulkValidateNonvalidatedMenuItem6
            // 
            this.bulkValidateNonvalidatedMenuItem6.Name = "bulkValidateNonvalidatedMenuItem6";
            this.bulkValidateNonvalidatedMenuItem6.Size = new System.Drawing.Size(390, 26);
            this.bulkValidateNonvalidatedMenuItem6.Text = "Bulk Batchsize Validated/NonValidated";
            this.bulkValidateNonvalidatedMenuItem6.Click += new System.EventHandler(this.bulkValidateNonvalidatedMenuItem6_Click);
            // 
            // DestructedLocation
            // 
            this.DestructedLocation.Name = "DestructedLocation";
            this.DestructedLocation.Size = new System.Drawing.Size(390, 26);
            this.DestructedLocation.Text = "Destructed Location";
            this.DestructedLocation.Click += new System.EventHandler(this.DestructedLocation_Click);
            // 
            // PendingDestructLocationtoolStripMenuItem
            // 
            this.PendingDestructLocationtoolStripMenuItem.Name = "PendingDestructLocationtoolStripMenuItem";
            this.PendingDestructLocationtoolStripMenuItem.Size = new System.Drawing.Size(390, 26);
            this.PendingDestructLocationtoolStripMenuItem.Text = "Pending Destructed Location";
            this.PendingDestructLocationtoolStripMenuItem.Click += new System.EventHandler(this.PendingDestructLocationtoolStripMenuItem_Click);
            // 
            // QTMSHDetailtoolStripMenuItem
            // 
            this.QTMSHDetailtoolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.QTMSHDetailtoolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.QTMSHDetailtoolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bulkAnalysisReportToolStripMenuItem1,
            this.bulkTransactionReportToolStripMenuItem1,
            this.lineSampleDetailsReportToolStripMenuItem,
            this.preservativeTestReportToolStripMenuItem,
            this.microbiologyTestReportToolStripMenuItem,
            this.fGAnalysisReportToolStripMenuItem1,
            this.fGAnalysisBMRReportToolStripMenuItem,
            this.fGPendingReportToolStripMenuItem,
            this.fGBulkRejectionDetailsReportToolStripMenuItem,
            this.oOSDetailsReportToolStripMenuItem,
            this.destructionDetailsToolStripMenuItem,
            this.tankSelectionReportToolStripMenuItem,
            this.stabilityTestReportToolStripMenuItem,
            this.stabilityTraceEmailToolStripMenuItem,
            this.ageingTestReportToolStripMenuItem});
            this.QTMSHDetailtoolStripMenuItem.ForeColor = System.Drawing.SystemColors.Highlight;
            this.QTMSHDetailtoolStripMenuItem.Name = "QTMSHDetailtoolStripMenuItem";
            this.QTMSHDetailtoolStripMenuItem.Size = new System.Drawing.Size(68, 28);
            this.QTMSHDetailtoolStripMenuItem.Text = "Detail";
            // 
            // bulkAnalysisReportToolStripMenuItem1
            // 
            this.bulkAnalysisReportToolStripMenuItem1.Name = "bulkAnalysisReportToolStripMenuItem1";
            this.bulkAnalysisReportToolStripMenuItem1.Size = new System.Drawing.Size(344, 26);
            this.bulkAnalysisReportToolStripMenuItem1.Text = "Bulk Analysis Report";
            this.bulkAnalysisReportToolStripMenuItem1.Click += new System.EventHandler(this.bulkAnalysisReportToolStripMenuItem1_Click_1);
            // 
            // bulkTransactionReportToolStripMenuItem1
            // 
            this.bulkTransactionReportToolStripMenuItem1.Name = "bulkTransactionReportToolStripMenuItem1";
            this.bulkTransactionReportToolStripMenuItem1.Size = new System.Drawing.Size(344, 26);
            this.bulkTransactionReportToolStripMenuItem1.Text = "Bulk Transaction Report";
            this.bulkTransactionReportToolStripMenuItem1.Click += new System.EventHandler(this.bulkTransactionReportToolStripMenuItem1_Click);
            // 
            // lineSampleDetailsReportToolStripMenuItem
            // 
            this.lineSampleDetailsReportToolStripMenuItem.Name = "lineSampleDetailsReportToolStripMenuItem";
            this.lineSampleDetailsReportToolStripMenuItem.Size = new System.Drawing.Size(344, 26);
            this.lineSampleDetailsReportToolStripMenuItem.Text = "Line Sample Details Report";
            this.lineSampleDetailsReportToolStripMenuItem.Click += new System.EventHandler(this.lineSampleDetailsReportToolStripMenuItem_Click_1);
            // 
            // preservativeTestReportToolStripMenuItem
            // 
            this.preservativeTestReportToolStripMenuItem.Name = "preservativeTestReportToolStripMenuItem";
            this.preservativeTestReportToolStripMenuItem.Size = new System.Drawing.Size(344, 26);
            this.preservativeTestReportToolStripMenuItem.Text = "Preservative Test Report";
            this.preservativeTestReportToolStripMenuItem.Click += new System.EventHandler(this.preservativeTestReportToolStripMenuItem_Click_1);
            // 
            // microbiologyTestReportToolStripMenuItem
            // 
            this.microbiologyTestReportToolStripMenuItem.Name = "microbiologyTestReportToolStripMenuItem";
            this.microbiologyTestReportToolStripMenuItem.Size = new System.Drawing.Size(344, 26);
            this.microbiologyTestReportToolStripMenuItem.Text = "Microbiology Test Report";
            this.microbiologyTestReportToolStripMenuItem.Click += new System.EventHandler(this.microbiologyTestReportToolStripMenuItem_Click_1);
            // 
            // fGAnalysisReportToolStripMenuItem1
            // 
            this.fGAnalysisReportToolStripMenuItem1.Name = "fGAnalysisReportToolStripMenuItem1";
            this.fGAnalysisReportToolStripMenuItem1.Size = new System.Drawing.Size(344, 26);
            this.fGAnalysisReportToolStripMenuItem1.Text = "FG Analysis Report";
            this.fGAnalysisReportToolStripMenuItem1.Click += new System.EventHandler(this.fGAnalysisReportToolStripMenuItem1_Click_1);
            // 
            // fGAnalysisBMRReportToolStripMenuItem
            // 
            this.fGAnalysisBMRReportToolStripMenuItem.Name = "fGAnalysisBMRReportToolStripMenuItem";
            this.fGAnalysisBMRReportToolStripMenuItem.Size = new System.Drawing.Size(344, 26);
            this.fGAnalysisBMRReportToolStripMenuItem.Text = "FG Analysis BMR Report";
            this.fGAnalysisBMRReportToolStripMenuItem.Click += new System.EventHandler(this.fGAnalysisBMRReportToolStripMenuItem_Click);
            // 
            // fGPendingReportToolStripMenuItem
            // 
            this.fGPendingReportToolStripMenuItem.Name = "fGPendingReportToolStripMenuItem";
            this.fGPendingReportToolStripMenuItem.Size = new System.Drawing.Size(344, 26);
            this.fGPendingReportToolStripMenuItem.Text = "FG Pending Report";
            this.fGPendingReportToolStripMenuItem.Click += new System.EventHandler(this.fGPendingReportToolStripMenuItem_Click);
            // 
            // fGBulkRejectionDetailsReportToolStripMenuItem
            // 
            this.fGBulkRejectionDetailsReportToolStripMenuItem.Name = "fGBulkRejectionDetailsReportToolStripMenuItem";
            this.fGBulkRejectionDetailsReportToolStripMenuItem.Size = new System.Drawing.Size(344, 26);
            this.fGBulkRejectionDetailsReportToolStripMenuItem.Text = "FG Bulk Rejection Details Report";
            this.fGBulkRejectionDetailsReportToolStripMenuItem.Click += new System.EventHandler(this.fGBulkRejectionDetailsReportToolStripMenuItem_Click);
            // 
            // oOSDetailsReportToolStripMenuItem
            // 
            this.oOSDetailsReportToolStripMenuItem.Name = "oOSDetailsReportToolStripMenuItem";
            this.oOSDetailsReportToolStripMenuItem.Size = new System.Drawing.Size(344, 26);
            this.oOSDetailsReportToolStripMenuItem.Text = "OOS Details Report";
            this.oOSDetailsReportToolStripMenuItem.Click += new System.EventHandler(this.oOSDetailsReportToolStripMenuItem_Click);
            // 
            // destructionDetailsToolStripMenuItem
            // 
            this.destructionDetailsToolStripMenuItem.Name = "destructionDetailsToolStripMenuItem";
            this.destructionDetailsToolStripMenuItem.Size = new System.Drawing.Size(344, 26);
            this.destructionDetailsToolStripMenuItem.Text = "Destruction Location Details ";
            this.destructionDetailsToolStripMenuItem.Click += new System.EventHandler(this.destructionDetailsToolStripMenuItem_Click);
            // 
            // tankSelectionReportToolStripMenuItem
            // 
            this.tankSelectionReportToolStripMenuItem.Name = "tankSelectionReportToolStripMenuItem";
            this.tankSelectionReportToolStripMenuItem.Size = new System.Drawing.Size(344, 26);
            this.tankSelectionReportToolStripMenuItem.Text = "Tank Selection Report";
            this.tankSelectionReportToolStripMenuItem.Click += new System.EventHandler(this.tankSelectionReportToolStripMenuItem_Click);
            // 
            // stabilityTestReportToolStripMenuItem
            // 
            this.stabilityTestReportToolStripMenuItem.Name = "stabilityTestReportToolStripMenuItem";
            this.stabilityTestReportToolStripMenuItem.Size = new System.Drawing.Size(344, 26);
            this.stabilityTestReportToolStripMenuItem.Text = "Stability Test Report";
            this.stabilityTestReportToolStripMenuItem.Click += new System.EventHandler(this.stabiToolStripMenuItem_Click);
            // 
            // stabilityTraceEmailToolStripMenuItem
            // 
            this.stabilityTraceEmailToolStripMenuItem.Name = "stabilityTraceEmailToolStripMenuItem";
            this.stabilityTraceEmailToolStripMenuItem.Size = new System.Drawing.Size(344, 26);
            this.stabilityTraceEmailToolStripMenuItem.Text = "Stability Trace Email";
            this.stabilityTraceEmailToolStripMenuItem.Click += new System.EventHandler(this.stabilityTraceEmailToolStripMenuItem_Click);
            // 
            // ageingTestReportToolStripMenuItem
            // 
            this.ageingTestReportToolStripMenuItem.Name = "ageingTestReportToolStripMenuItem";
            this.ageingTestReportToolStripMenuItem.Size = new System.Drawing.Size(344, 26);
            this.ageingTestReportToolStripMenuItem.Text = "Ageing Test Report";
            this.ageingTestReportToolStripMenuItem.Click += new System.EventHandler(this.ageingTestReportToolStripMenuItem_Click);
            // 
            // QTMSHMasterReporttoolStripMenuItem
            // 
            this.QTMSHMasterReporttoolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.QTMSHMasterReporttoolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.QTMSHMasterReporttoolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.formulaHistoryReportToolStripMenuItem,
            this.fGFormulaHistoryReportToolStripMenuItem,
            this.formulaDescriptionReportToolStripMenuItem,
            this.bulkTestReportToolStripMenuItem1,
            this.testMethodMasterReportToolStripMenuItem1,
            this.fGTestMethodMasterReportToolStripMenuItem2,
            this.fGMasterReportToolStripMenuItem,
            this.formulaMasterReportToolStripMenuItem,
            this.fGOutSourceReportToolStripMenuItem});
            this.QTMSHMasterReporttoolStripMenuItem.ForeColor = System.Drawing.SystemColors.Highlight;
            this.QTMSHMasterReporttoolStripMenuItem.Name = "QTMSHMasterReporttoolStripMenuItem";
            this.QTMSHMasterReporttoolStripMenuItem.Size = new System.Drawing.Size(76, 28);
            this.QTMSHMasterReporttoolStripMenuItem.Text = "Master";
            // 
            // formulaHistoryReportToolStripMenuItem
            // 
            this.formulaHistoryReportToolStripMenuItem.Name = "formulaHistoryReportToolStripMenuItem";
            this.formulaHistoryReportToolStripMenuItem.Size = new System.Drawing.Size(328, 26);
            this.formulaHistoryReportToolStripMenuItem.Text = "Formula History Report";
            this.formulaHistoryReportToolStripMenuItem.Click += new System.EventHandler(this.formulaHistoryReportToolStripMenuItem_Click_1);
            // 
            // fGFormulaHistoryReportToolStripMenuItem
            // 
            this.fGFormulaHistoryReportToolStripMenuItem.Name = "fGFormulaHistoryReportToolStripMenuItem";
            this.fGFormulaHistoryReportToolStripMenuItem.Size = new System.Drawing.Size(328, 26);
            this.fGFormulaHistoryReportToolStripMenuItem.Text = "FG Formula History Report";
            this.fGFormulaHistoryReportToolStripMenuItem.Click += new System.EventHandler(this.fGFormulaHistoryReportToolStripMenuItem_Click);
            // 
            // formulaDescriptionReportToolStripMenuItem
            // 
            this.formulaDescriptionReportToolStripMenuItem.Name = "formulaDescriptionReportToolStripMenuItem";
            this.formulaDescriptionReportToolStripMenuItem.Size = new System.Drawing.Size(328, 26);
            this.formulaDescriptionReportToolStripMenuItem.Text = "Formula Description Report";
            this.formulaDescriptionReportToolStripMenuItem.Click += new System.EventHandler(this.formulaDescriptionReportToolStripMenuItem_Click);
            // 
            // bulkTestReportToolStripMenuItem1
            // 
            this.bulkTestReportToolStripMenuItem1.Name = "bulkTestReportToolStripMenuItem1";
            this.bulkTestReportToolStripMenuItem1.Size = new System.Drawing.Size(328, 26);
            this.bulkTestReportToolStripMenuItem1.Text = "Bulk Test Report";
            this.bulkTestReportToolStripMenuItem1.Click += new System.EventHandler(this.bulkTestReportToolStripMenuItem1_Click_1);
            // 
            // testMethodMasterReportToolStripMenuItem1
            // 
            this.testMethodMasterReportToolStripMenuItem1.Name = "testMethodMasterReportToolStripMenuItem1";
            this.testMethodMasterReportToolStripMenuItem1.Size = new System.Drawing.Size(328, 26);
            this.testMethodMasterReportToolStripMenuItem1.Text = "Test Method Master Report";
            this.testMethodMasterReportToolStripMenuItem1.Click += new System.EventHandler(this.testMethodMasterReportToolStripMenuItem1_Click);
            // 
            // fGTestMethodMasterReportToolStripMenuItem2
            // 
            this.fGTestMethodMasterReportToolStripMenuItem2.Name = "fGTestMethodMasterReportToolStripMenuItem2";
            this.fGTestMethodMasterReportToolStripMenuItem2.Size = new System.Drawing.Size(328, 26);
            this.fGTestMethodMasterReportToolStripMenuItem2.Text = "FG Test Method Master Report";
            this.fGTestMethodMasterReportToolStripMenuItem2.Click += new System.EventHandler(this.fGTestMethodMasterReportToolStripMenuItem2_Click);
            // 
            // fGMasterReportToolStripMenuItem
            // 
            this.fGMasterReportToolStripMenuItem.Name = "fGMasterReportToolStripMenuItem";
            this.fGMasterReportToolStripMenuItem.Size = new System.Drawing.Size(328, 26);
            this.fGMasterReportToolStripMenuItem.Text = "FG Master Report";
            this.fGMasterReportToolStripMenuItem.Click += new System.EventHandler(this.fGMasterReportToolStripMenuItem_Click);
            // 
            // formulaMasterReportToolStripMenuItem
            // 
            this.formulaMasterReportToolStripMenuItem.Name = "formulaMasterReportToolStripMenuItem";
            this.formulaMasterReportToolStripMenuItem.Size = new System.Drawing.Size(328, 26);
            this.formulaMasterReportToolStripMenuItem.Text = "Formula Master Report";
            this.formulaMasterReportToolStripMenuItem.Click += new System.EventHandler(this.formulaMasterReportToolStripMenuItem_Click);
            // 
            // fGOutSourceReportToolStripMenuItem
            // 
            this.fGOutSourceReportToolStripMenuItem.Name = "fGOutSourceReportToolStripMenuItem";
            this.fGOutSourceReportToolStripMenuItem.Size = new System.Drawing.Size(328, 26);
            this.fGOutSourceReportToolStripMenuItem.Text = "FG Out Source Report";
            this.fGOutSourceReportToolStripMenuItem.Click += new System.EventHandler(this.fGOutSourceReportToolStripMenuItem_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.btnADMIN, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.btnOTHER, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnFDA, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnPM, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnRM, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnFG, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.button1, 0, 6);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(68, 419);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnADMIN
            // 
            this.btnADMIN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnADMIN.Image = global::QTMS.Properties.Resources.ADMIN;
            this.btnADMIN.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnADMIN.Location = new System.Drawing.Point(3, 303);
            this.btnADMIN.Name = "btnADMIN";
            this.btnADMIN.Size = new System.Drawing.Size(62, 54);
            this.btnADMIN.TabIndex = 5;
            this.btnADMIN.Text = "ADMIN";
            this.btnADMIN.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnADMIN.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnADMIN.UseVisualStyleBackColor = true;
            this.btnADMIN.Click += new System.EventHandler(this.btnADMIN_Click);
            // 
            // btnOTHER
            // 
            this.btnOTHER.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOTHER.Image = global::QTMS.Properties.Resources.OTHER;
            this.btnOTHER.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnOTHER.Location = new System.Drawing.Point(3, 243);
            this.btnOTHER.Name = "btnOTHER";
            this.btnOTHER.Size = new System.Drawing.Size(62, 54);
            this.btnOTHER.TabIndex = 4;
            this.btnOTHER.Text = "OTHER";
            this.btnOTHER.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnOTHER.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnOTHER.UseVisualStyleBackColor = true;
            this.btnOTHER.Click += new System.EventHandler(this.btnOTHER_Click);
            // 
            // btnFDA
            // 
            this.btnFDA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFDA.Image = global::QTMS.Properties.Resources.FDA;
            this.btnFDA.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnFDA.Location = new System.Drawing.Point(3, 183);
            this.btnFDA.Name = "btnFDA";
            this.btnFDA.Size = new System.Drawing.Size(62, 54);
            this.btnFDA.TabIndex = 3;
            this.btnFDA.Text = "FDA";
            this.btnFDA.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnFDA.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnFDA.UseVisualStyleBackColor = true;
            this.btnFDA.Click += new System.EventHandler(this.btnFDA_Click);
            // 
            // btnPM
            // 
            this.btnPM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPM.Image = global::QTMS.Properties.Resources.PM;
            this.btnPM.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPM.Location = new System.Drawing.Point(3, 123);
            this.btnPM.Name = "btnPM";
            this.btnPM.Size = new System.Drawing.Size(62, 54);
            this.btnPM.TabIndex = 2;
            this.btnPM.Text = "PM";
            this.btnPM.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPM.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPM.UseVisualStyleBackColor = true;
            this.btnPM.Click += new System.EventHandler(this.btnPM_Click);
            // 
            // btnRM
            // 
            this.btnRM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRM.Image = global::QTMS.Properties.Resources.RM;
            this.btnRM.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRM.Location = new System.Drawing.Point(3, 63);
            this.btnRM.Name = "btnRM";
            this.btnRM.Size = new System.Drawing.Size(62, 54);
            this.btnRM.TabIndex = 1;
            this.btnRM.Text = "RM";
            this.btnRM.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRM.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRM.UseVisualStyleBackColor = true;
            this.btnRM.Click += new System.EventHandler(this.btnRM_Click);
            // 
            // btnFG
            // 
            this.btnFG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFG.Image = global::QTMS.Properties.Resources.FG;
            this.btnFG.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnFG.Location = new System.Drawing.Point(3, 3);
            this.btnFG.Name = "btnFG";
            this.btnFG.Size = new System.Drawing.Size(62, 54);
            this.btnFG.TabIndex = 0;
            this.btnFG.Text = "FG";
            this.btnFG.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnFG.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnFG.UseVisualStyleBackColor = true;
            this.btnFG.Click += new System.EventHandler(this.btnFG_Click);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.Location = new System.Drawing.Point(3, 363);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(62, 53);
            this.button1.TabIndex = 6;
            this.button1.Text = "SCOOP";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(68, 662);
            this.panel1.TabIndex = 43;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblVersion);
            this.panel3.Controls.Add(this.btnMettler);
            this.panel3.Controls.Add(this.btnLineValidation);
            this.panel3.Controls.Add(this.tableLayoutPanel1);
            this.panel3.Controls.Add(this.btnSubCon);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 28);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(68, 634);
            this.panel3.TabIndex = 47;
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(12, 617);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(101, 21);
            this.lblVersion.TabIndex = 47;
            this.lblVersion.Text = "Version: {0}";
            this.lblVersion.Visible = false;
            // 
            // btnMettler
            // 
            this.btnMettler.Image = global::QTMS.Properties.Resources.mettler;
            this.btnMettler.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMettler.Location = new System.Drawing.Point(3, 560);
            this.btnMettler.Name = "btnMettler";
            this.btnMettler.Size = new System.Drawing.Size(62, 53);
            this.btnMettler.TabIndex = 9;
            this.btnMettler.Text = "Mettler";
            this.btnMettler.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMettler.UseVisualStyleBackColor = true;
            this.btnMettler.Click += new System.EventHandler(this.btnMettler_Click);
            // 
            // btnLineValidation
            // 
            this.btnLineValidation.Image = global::QTMS.Properties.Resources.Line;
            this.btnLineValidation.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnLineValidation.Location = new System.Drawing.Point(3, 495);
            this.btnLineValidation.Name = "btnLineValidation";
            this.btnLineValidation.Size = new System.Drawing.Size(62, 59);
            this.btnLineValidation.TabIndex = 8;
            this.btnLineValidation.Text = "Line Validation";
            this.btnLineValidation.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLineValidation.UseVisualStyleBackColor = true;
            this.btnLineValidation.Click += new System.EventHandler(this.btnLineValidation_Click);
            // 
            // btnSubCon
            // 
            this.btnSubCon.Image = ((System.Drawing.Image)(resources.GetObject("btnSubCon.Image")));
            this.btnSubCon.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSubCon.Location = new System.Drawing.Point(3, 422);
            this.btnSubCon.Name = "btnSubCon";
            this.btnSubCon.Size = new System.Drawing.Size(62, 67);
            this.btnSubCon.TabIndex = 6;
            this.btnSubCon.Text = "Sub Contract";
            this.btnSubCon.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSubCon.UseVisualStyleBackColor = true;
            this.btnSubCon.Click += new System.EventHandler(this.btnSubCon_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnLogin);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(68, 28);
            this.panel2.TabIndex = 47;
            // 
            // btnLogin
            // 
            this.btnLogin.BackgroundImage = global::QTMS.Properties.Resources.Log11;
            this.btnLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLogin.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.Navy;
            this.btnLogin.Location = new System.Drawing.Point(0, 0);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(68, 28);
            this.btnLogin.TabIndex = 0;
            this.btnLogin.UseVisualStyleBackColor = true;
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.Transparent;
            this.panelMenu.Controls.Add(this.lblMenuName);
            this.panelMenu.Controls.Add(this.menuStripADMINH);
            this.panelMenu.Controls.Add(this.menuStripFDAH);
            this.panelMenu.Controls.Add(this.menuStripPMH);
            this.panelMenu.Controls.Add(this.menuStripRMH);
            this.panelMenu.Controls.Add(this.menuStripQTMSH);
            this.panelMenu.Controls.Add(this.menuStripMettler);
            this.panelMenu.Controls.Add(this.menuStripLineValidation);
            this.panelMenu.Controls.Add(this.menuStripOther);
            this.panelMenu.Controls.Add(this.menuStripScoop);
            this.panelMenu.Controls.Add(this.menuStripSubCon);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMenu.Location = new System.Drawing.Point(68, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(1179, 28);
            this.panelMenu.TabIndex = 45;
            this.panelMenu.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMenu_Paint);
            // 
            // lblMenuName
            // 
            this.lblMenuName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMenuName.AutoSize = true;
            this.lblMenuName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblMenuName.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMenuName.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblMenuName.Location = new System.Drawing.Point(551, 3);
            this.lblMenuName.Name = "lblMenuName";
            this.lblMenuName.Size = new System.Drawing.Size(0, 33);
            this.lblMenuName.TabIndex = 3;
            this.lblMenuName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menuStripMettler
            // 
            this.menuStripMettler.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.menuStripMettler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuStripMettler.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStripMettler.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem6,
            this.toolStripMenuItem40});
            this.menuStripMettler.Location = new System.Drawing.Point(0, 0);
            this.menuStripMettler.Name = "menuStripMettler";
            this.menuStripMettler.Padding = new System.Windows.Forms.Padding(0);
            this.menuStripMettler.Size = new System.Drawing.Size(1179, 28);
            this.menuStripMettler.TabIndex = 7;
            this.menuStripMettler.Text = "menuStrip";
            this.menuStripMettler.Visible = false;
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.toolStripMenuItem6.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sPCMasterToolStripMenuItem,
            this.tareWeightToolStripMenuItem,
            this.normalWeightToolStripMenuItem,
            this.manualWeightToolStripMenuItem});
            this.toolStripMenuItem6.ForeColor = System.Drawing.Color.LightSlateGray;
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(76, 28);
            this.toolStripMenuItem6.Text = "Mettler";
            // 
            // sPCMasterToolStripMenuItem
            // 
            this.sPCMasterToolStripMenuItem.Name = "sPCMasterToolStripMenuItem";
            this.sPCMasterToolStripMenuItem.Size = new System.Drawing.Size(237, 26);
            this.sPCMasterToolStripMenuItem.Text = "SPC Master";
            this.sPCMasterToolStripMenuItem.Click += new System.EventHandler(this.sPCMasterToolStripMenuItem_Click);
            // 
            // tareWeightToolStripMenuItem
            // 
            this.tareWeightToolStripMenuItem.Name = "tareWeightToolStripMenuItem";
            this.tareWeightToolStripMenuItem.Size = new System.Drawing.Size(237, 26);
            this.tareWeightToolStripMenuItem.Text = "Tare Weight";
            this.tareWeightToolStripMenuItem.Click += new System.EventHandler(this.tareWeightToolStripMenuItem_Click);
            // 
            // normalWeightToolStripMenuItem
            // 
            this.normalWeightToolStripMenuItem.Name = "normalWeightToolStripMenuItem";
            this.normalWeightToolStripMenuItem.Size = new System.Drawing.Size(237, 26);
            this.normalWeightToolStripMenuItem.Text = "Mettler/Auto Weight";
            this.normalWeightToolStripMenuItem.Click += new System.EventHandler(this.normalWeightToolStripMenuItem_Click);
            // 
            // manualWeightToolStripMenuItem
            // 
            this.manualWeightToolStripMenuItem.Name = "manualWeightToolStripMenuItem";
            this.manualWeightToolStripMenuItem.Size = new System.Drawing.Size(237, 26);
            this.manualWeightToolStripMenuItem.Text = "Manual Weight";
            this.manualWeightToolStripMenuItem.Click += new System.EventHandler(this.manualWeightToolStripMenuItem_Click);
            // 
            // toolStripMenuItem40
            // 
            this.toolStripMenuItem40.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripMenuItem40.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.toolStripMenuItem40.ForeColor = System.Drawing.Color.OrangeRed;
            this.toolStripMenuItem40.Name = "toolStripMenuItem40";
            this.toolStripMenuItem40.Size = new System.Drawing.Size(85, 28);
            this.toolStripMenuItem40.Text = "Reports";
            // 
            // menuStripLineValidation
            // 
            this.menuStripLineValidation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.menuStripLineValidation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuStripLineValidation.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem20,
            this.LineValidationTransactionformtoolStripMenuItem,
            this.LineValidationmodificationToolStripMenuItem1,
            this.toolStripMenuItem19});
            this.menuStripLineValidation.Location = new System.Drawing.Point(0, 0);
            this.menuStripLineValidation.Name = "menuStripLineValidation";
            this.menuStripLineValidation.Size = new System.Drawing.Size(878, 28);
            this.menuStripLineValidation.TabIndex = 6;
            this.menuStripLineValidation.Text = "menuStrip1";
            this.menuStripLineValidation.Visible = false;
            // 
            // toolStripMenuItem20
            // 
            this.toolStripMenuItem20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.toolStripMenuItem20.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LineValidationtoolStripMenuItem,
            this.LayoutstoolStripMenuItem,
            this.TrainingMaterialtoolStripMenuItem,
            this.HistorytoolStripMenuItem,
            this.lineValidationTransactionToolStripMenuItem,
            this.lineViewToolStripMenuItem,
            this.lineLayoutToolStripMenuItem,
            this.lineDetailsToolStripMenuItem});
            this.toolStripMenuItem20.ForeColor = System.Drawing.Color.Teal;
            this.toolStripMenuItem20.Name = "toolStripMenuItem20";
            this.toolStripMenuItem20.Size = new System.Drawing.Size(78, 24);
            this.toolStripMenuItem20.Text = "Master";
            // 
            // LineValidationtoolStripMenuItem
            // 
            this.LineValidationtoolStripMenuItem.Name = "LineValidationtoolStripMenuItem";
            this.LineValidationtoolStripMenuItem.Size = new System.Drawing.Size(213, 30);
            this.LineValidationtoolStripMenuItem.Text = "Line Master";
            this.LineValidationtoolStripMenuItem.Click += new System.EventHandler(this.LineValidationtoolStripMenuItem_Click);
            // 
            // LayoutstoolStripMenuItem
            // 
            this.LayoutstoolStripMenuItem.Name = "LayoutstoolStripMenuItem";
            this.LayoutstoolStripMenuItem.Size = new System.Drawing.Size(213, 30);
            this.LayoutstoolStripMenuItem.Text = "Layouts";
            this.LayoutstoolStripMenuItem.Visible = false;
            // 
            // TrainingMaterialtoolStripMenuItem
            // 
            this.TrainingMaterialtoolStripMenuItem.Name = "TrainingMaterialtoolStripMenuItem";
            this.TrainingMaterialtoolStripMenuItem.Size = new System.Drawing.Size(213, 30);
            this.TrainingMaterialtoolStripMenuItem.Text = "Training Material";
            this.TrainingMaterialtoolStripMenuItem.Visible = false;
            // 
            // HistorytoolStripMenuItem
            // 
            this.HistorytoolStripMenuItem.Name = "HistorytoolStripMenuItem";
            this.HistorytoolStripMenuItem.Size = new System.Drawing.Size(213, 30);
            this.HistorytoolStripMenuItem.Text = "History";
            this.HistorytoolStripMenuItem.Visible = false;
            this.HistorytoolStripMenuItem.Click += new System.EventHandler(this.HistorytoolStripMenuItem_Click);
            // 
            // lineValidationTransactionToolStripMenuItem
            // 
            this.lineValidationTransactionToolStripMenuItem.Name = "lineValidationTransactionToolStripMenuItem";
            this.lineValidationTransactionToolStripMenuItem.Size = new System.Drawing.Size(213, 30);
            this.lineValidationTransactionToolStripMenuItem.Text = "Line Validation";
            this.lineValidationTransactionToolStripMenuItem.Click += new System.EventHandler(this.lineValidationTransactionToolStripMenuItem_Click);
            // 
            // lineViewToolStripMenuItem
            // 
            this.lineViewToolStripMenuItem.Name = "lineViewToolStripMenuItem";
            this.lineViewToolStripMenuItem.Size = new System.Drawing.Size(213, 30);
            this.lineViewToolStripMenuItem.Text = "Line View";
            this.lineViewToolStripMenuItem.Visible = false;
            this.lineViewToolStripMenuItem.Click += new System.EventHandler(this.lineViewToolStripMenuItem_Click);
            // 
            // lineLayoutToolStripMenuItem
            // 
            this.lineLayoutToolStripMenuItem.Name = "lineLayoutToolStripMenuItem";
            this.lineLayoutToolStripMenuItem.Size = new System.Drawing.Size(213, 30);
            this.lineLayoutToolStripMenuItem.Text = "Line Layout";
            this.lineLayoutToolStripMenuItem.Visible = false;
            // 
            // lineDetailsToolStripMenuItem
            // 
            this.lineDetailsToolStripMenuItem.Name = "lineDetailsToolStripMenuItem";
            this.lineDetailsToolStripMenuItem.Size = new System.Drawing.Size(213, 30);
            this.lineDetailsToolStripMenuItem.Text = "Line Details";
            this.lineDetailsToolStripMenuItem.Click += new System.EventHandler(this.lineDetailsToolStripMenuItem_Click);
            // 
            // LineValidationTransactionformtoolStripMenuItem
            // 
            this.LineValidationTransactionformtoolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lineTransactionToolStripMenuItem});
            this.LineValidationTransactionformtoolStripMenuItem.ForeColor = System.Drawing.Color.Teal;
            this.LineValidationTransactionformtoolStripMenuItem.Name = "LineValidationTransactionformtoolStripMenuItem";
            this.LineValidationTransactionformtoolStripMenuItem.Size = new System.Drawing.Size(112, 24);
            this.LineValidationTransactionformtoolStripMenuItem.Text = "Transaction";
            // 
            // lineTransactionToolStripMenuItem
            // 
            this.lineTransactionToolStripMenuItem.Name = "lineTransactionToolStripMenuItem";
            this.lineTransactionToolStripMenuItem.Size = new System.Drawing.Size(208, 30);
            this.lineTransactionToolStripMenuItem.Text = "Line Transaction";
            this.lineTransactionToolStripMenuItem.Click += new System.EventHandler(this.lineTransactionToolStripMenuItem_Click);
            // 
            // LineValidationmodificationToolStripMenuItem1
            // 
            this.LineValidationmodificationToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lineTransactionModificationToolStripMenuItem});
            this.LineValidationmodificationToolStripMenuItem1.ForeColor = System.Drawing.Color.Teal;
            this.LineValidationmodificationToolStripMenuItem1.Name = "LineValidationmodificationToolStripMenuItem1";
            this.LineValidationmodificationToolStripMenuItem1.Size = new System.Drawing.Size(124, 24);
            this.LineValidationmodificationToolStripMenuItem1.Text = "Modification";
            // 
            // lineTransactionModificationToolStripMenuItem
            // 
            this.lineTransactionModificationToolStripMenuItem.Name = "lineTransactionModificationToolStripMenuItem";
            this.lineTransactionModificationToolStripMenuItem.Size = new System.Drawing.Size(220, 30);
            this.lineTransactionModificationToolStripMenuItem.Text = "Line Modification";
            this.lineTransactionModificationToolStripMenuItem.Click += new System.EventHandler(this.lineTransactionModificationToolStripMenuItem_Click);
            // 
            // toolStripMenuItem19
            // 
            this.toolStripMenuItem19.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripMenuItem19.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lineTransactionReportToolStripMenuItem,
            this.lineToolStripMenuItem,
            this.lineRejectionHistoryReportToolStripMenuItem});
            this.toolStripMenuItem19.ForeColor = System.Drawing.Color.Teal;
            this.toolStripMenuItem19.Name = "toolStripMenuItem19";
            this.toolStripMenuItem19.Size = new System.Drawing.Size(85, 24);
            this.toolStripMenuItem19.Text = "Reports";
            // 
            // lineTransactionReportToolStripMenuItem
            // 
            this.lineTransactionReportToolStripMenuItem.Name = "lineTransactionReportToolStripMenuItem";
            this.lineTransactionReportToolStripMenuItem.Size = new System.Drawing.Size(315, 30);
            this.lineTransactionReportToolStripMenuItem.Text = "Line Transaction Report";
            this.lineTransactionReportToolStripMenuItem.Click += new System.EventHandler(this.lineTransactionReportToolStripMenuItem_Click);
            // 
            // lineToolStripMenuItem
            // 
            this.lineToolStripMenuItem.Name = "lineToolStripMenuItem";
            this.lineToolStripMenuItem.Size = new System.Drawing.Size(315, 30);
            this.lineToolStripMenuItem.Text = "Line Validation Master Report";
            this.lineToolStripMenuItem.Visible = false;
            this.lineToolStripMenuItem.Click += new System.EventHandler(this.lineToolStripMenuItem_Click);
            // 
            // lineRejectionHistoryReportToolStripMenuItem
            // 
            this.lineRejectionHistoryReportToolStripMenuItem.Name = "lineRejectionHistoryReportToolStripMenuItem";
            this.lineRejectionHistoryReportToolStripMenuItem.Size = new System.Drawing.Size(315, 30);
            this.lineRejectionHistoryReportToolStripMenuItem.Text = "Line Rejection History Report";
            this.lineRejectionHistoryReportToolStripMenuItem.Click += new System.EventHandler(this.lineRejectionHistoryReportToolStripMenuItem_Click);
            // 
            // menuStripOther
            // 
            this.menuStripOther.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.menuStripOther.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuStripOther.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStripOther.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OthermasterToolStripMenuItem,
            this.OtherTransactionToolStripMenuItem,
            this.OtherReportstoolStripMenuItem,
            this.oEEToolStripMenuItem,
            this.toolStripMenuItem1,
            this.imageComparisionToolStripMenuItem,
            this.reagentMgtToolStripMenuItem});
            this.menuStripOther.Location = new System.Drawing.Point(0, 0);
            this.menuStripOther.Name = "menuStripOther";
            this.menuStripOther.Padding = new System.Windows.Forms.Padding(0);
            this.menuStripOther.Size = new System.Drawing.Size(1179, 28);
            this.menuStripOther.TabIndex = 1;
            this.menuStripOther.Text = "menuStrip";
            this.menuStripOther.Visible = false;
            // 
            // OthermasterToolStripMenuItem
            // 
            this.OthermasterToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.OthermasterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.retainerLocationMasterToolStripMenuItem1,
            this.instrumentMasterToolStripMenuItem1,
            this.countryMasterToolStripMenuItem,
            this.locationMasterToolStripMenuItem,
            this.mOMMasterToolStripMenuItem,
            this.AnnextureTankMaster,
            this.QualityIssueMaster,
            this.DocumentMaster,
            this.AgitationMaster,
            this.mOMSignaRoleToolStripMenuItem,
            this.nAtureofACRefMasterToolStripMenuItem,
            this.aCMaterialRefMasterToolStripMenuItem});
            this.OthermasterToolStripMenuItem.ForeColor = System.Drawing.Color.LightSlateGray;
            this.OthermasterToolStripMenuItem.Name = "OthermasterToolStripMenuItem";
            this.OthermasterToolStripMenuItem.Size = new System.Drawing.Size(76, 28);
            this.OthermasterToolStripMenuItem.Text = "Master";
            // 
            // retainerLocationMasterToolStripMenuItem1
            // 
            this.retainerLocationMasterToolStripMenuItem1.Name = "retainerLocationMasterToolStripMenuItem1";
            this.retainerLocationMasterToolStripMenuItem1.Size = new System.Drawing.Size(295, 26);
            this.retainerLocationMasterToolStripMenuItem1.Text = "Retainer Location Master";
            this.retainerLocationMasterToolStripMenuItem1.Click += new System.EventHandler(this.retainerLocationMasterToolStripMenuItem1_Click);
            // 
            // instrumentMasterToolStripMenuItem1
            // 
            this.instrumentMasterToolStripMenuItem1.Name = "instrumentMasterToolStripMenuItem1";
            this.instrumentMasterToolStripMenuItem1.Size = new System.Drawing.Size(295, 26);
            this.instrumentMasterToolStripMenuItem1.Text = "Instrument Master";
            this.instrumentMasterToolStripMenuItem1.Click += new System.EventHandler(this.instrumentMasterToolStripMenuItem1_Click);
            // 
            // countryMasterToolStripMenuItem
            // 
            this.countryMasterToolStripMenuItem.Name = "countryMasterToolStripMenuItem";
            this.countryMasterToolStripMenuItem.Size = new System.Drawing.Size(295, 26);
            this.countryMasterToolStripMenuItem.Text = "Country Master";
            this.countryMasterToolStripMenuItem.Click += new System.EventHandler(this.countryMasterToolStripMenuItem_Click);
            // 
            // locationMasterToolStripMenuItem
            // 
            this.locationMasterToolStripMenuItem.Name = "locationMasterToolStripMenuItem";
            this.locationMasterToolStripMenuItem.Size = new System.Drawing.Size(295, 26);
            this.locationMasterToolStripMenuItem.Text = "Reference Location Master";
            this.locationMasterToolStripMenuItem.Click += new System.EventHandler(this.locationMasterToolStripMenuItem_Click);
            // 
            // mOMMasterToolStripMenuItem
            // 
            this.mOMMasterToolStripMenuItem.Name = "mOMMasterToolStripMenuItem";
            this.mOMMasterToolStripMenuItem.Size = new System.Drawing.Size(295, 26);
            this.mOMMasterToolStripMenuItem.Text = "MOM Master";
            this.mOMMasterToolStripMenuItem.Click += new System.EventHandler(this.mOMMasterToolStripMenuItem_Click);
            // 
            // AnnextureTankMaster
            // 
            this.AnnextureTankMaster.Name = "AnnextureTankMaster";
            this.AnnextureTankMaster.Size = new System.Drawing.Size(295, 26);
            this.AnnextureTankMaster.Text = "Annex Tank Master";
            this.AnnextureTankMaster.Click += new System.EventHandler(this.AnnextureTankMaster_Click);
            // 
            // QualityIssueMaster
            // 
            this.QualityIssueMaster.Name = "QualityIssueMaster";
            this.QualityIssueMaster.Size = new System.Drawing.Size(295, 26);
            this.QualityIssueMaster.Text = "Quality Issue Master";
            this.QualityIssueMaster.Click += new System.EventHandler(this.QualityIssueMaster_Click);
            // 
            // DocumentMaster
            // 
            this.DocumentMaster.Name = "DocumentMaster";
            this.DocumentMaster.Size = new System.Drawing.Size(295, 26);
            this.DocumentMaster.Text = "Document Master";
            this.DocumentMaster.Click += new System.EventHandler(this.DocumentMaster_Click);
            // 
            // AgitationMaster
            // 
            this.AgitationMaster.Name = "AgitationMaster";
            this.AgitationMaster.Size = new System.Drawing.Size(295, 26);
            this.AgitationMaster.Text = "Agitation Master";
            this.AgitationMaster.Click += new System.EventHandler(this.AgitationMaster_Click);
            // 
            // mOMSignaRoleToolStripMenuItem
            // 
            this.mOMSignaRoleToolStripMenuItem.Name = "mOMSignaRoleToolStripMenuItem";
            this.mOMSignaRoleToolStripMenuItem.Size = new System.Drawing.Size(295, 26);
            this.mOMSignaRoleToolStripMenuItem.Text = "MOM Signature Role";
            this.mOMSignaRoleToolStripMenuItem.Visible = false;
            this.mOMSignaRoleToolStripMenuItem.Click += new System.EventHandler(this.mOMSignaRoleToolStripMenuItem_Click);
            // 
            // nAtureofACRefMasterToolStripMenuItem
            // 
            this.nAtureofACRefMasterToolStripMenuItem.Name = "nAtureofACRefMasterToolStripMenuItem";
            this.nAtureofACRefMasterToolStripMenuItem.Size = new System.Drawing.Size(295, 26);
            this.nAtureofACRefMasterToolStripMenuItem.Text = "Nature of AC Ref Master";
            this.nAtureofACRefMasterToolStripMenuItem.Click += new System.EventHandler(this.nAtureofACRefMasterToolStripMenuItem_Click);
            // 
            // aCMaterialRefMasterToolStripMenuItem
            // 
            this.aCMaterialRefMasterToolStripMenuItem.Name = "aCMaterialRefMasterToolStripMenuItem";
            this.aCMaterialRefMasterToolStripMenuItem.Size = new System.Drawing.Size(295, 26);
            this.aCMaterialRefMasterToolStripMenuItem.Text = "AC Material Ref Master";
            this.aCMaterialRefMasterToolStripMenuItem.Click += new System.EventHandler(this.aCMaterialRefMasterToolStripMenuItem_Click);
            // 
            // OtherTransactionToolStripMenuItem
            // 
            this.OtherTransactionToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.OtherTransactionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consumerComplaintToolStripMenuItem,
            this.waterAnalysisToolStripMenuItem1,
            this.compatibilityToolStripMenuItem1,
            this.referenceSampleManageToolStripMenuItem,
            this.referenceSampleManagementRMToolStripMenuItem,
            this.plantwiseWaterAnalysisToolStripMenuItem});
            this.OtherTransactionToolStripMenuItem.ForeColor = System.Drawing.Color.LightSlateGray;
            this.OtherTransactionToolStripMenuItem.Name = "OtherTransactionToolStripMenuItem";
            this.OtherTransactionToolStripMenuItem.Size = new System.Drawing.Size(117, 28);
            this.OtherTransactionToolStripMenuItem.Text = "Transaction";
            // 
            // consumerComplaintToolStripMenuItem
            // 
            this.consumerComplaintToolStripMenuItem.Name = "consumerComplaintToolStripMenuItem";
            this.consumerComplaintToolStripMenuItem.Size = new System.Drawing.Size(380, 26);
            this.consumerComplaintToolStripMenuItem.Text = "Consumer Complaint";
            this.consumerComplaintToolStripMenuItem.Click += new System.EventHandler(this.consumerComplaintToolStripMenuItem_Click);
            // 
            // waterAnalysisToolStripMenuItem1
            // 
            this.waterAnalysisToolStripMenuItem1.Name = "waterAnalysisToolStripMenuItem1";
            this.waterAnalysisToolStripMenuItem1.Size = new System.Drawing.Size(380, 26);
            this.waterAnalysisToolStripMenuItem1.Text = "Water Analysis";
            this.waterAnalysisToolStripMenuItem1.Click += new System.EventHandler(this.waterAnalysisToolStripMenuItem1_Click);
            // 
            // compatibilityToolStripMenuItem1
            // 
            this.compatibilityToolStripMenuItem1.Name = "compatibilityToolStripMenuItem1";
            this.compatibilityToolStripMenuItem1.Size = new System.Drawing.Size(380, 26);
            this.compatibilityToolStripMenuItem1.Text = "Compatibility";
            this.compatibilityToolStripMenuItem1.Click += new System.EventHandler(this.compatibilityToolStripMenuItem1_Click);
            // 
            // referenceSampleManageToolStripMenuItem
            // 
            this.referenceSampleManageToolStripMenuItem.Name = "referenceSampleManageToolStripMenuItem";
            this.referenceSampleManageToolStripMenuItem.Size = new System.Drawing.Size(380, 26);
            this.referenceSampleManageToolStripMenuItem.Text = "Reference Sample Management";
            this.referenceSampleManageToolStripMenuItem.Click += new System.EventHandler(this.referenceSampleManageToolStripMenuItem_Click);
            // 
            // referenceSampleManagementRMToolStripMenuItem
            // 
            this.referenceSampleManagementRMToolStripMenuItem.Name = "referenceSampleManagementRMToolStripMenuItem";
            this.referenceSampleManagementRMToolStripMenuItem.Size = new System.Drawing.Size(380, 26);
            this.referenceSampleManagementRMToolStripMenuItem.Text = "Reference Sample Management (RM)";
            this.referenceSampleManagementRMToolStripMenuItem.Click += new System.EventHandler(this.referenceSampleManagementRMToolStripMenuItem_Click);
            // 
            // plantwiseWaterAnalysisToolStripMenuItem
            // 
            this.plantwiseWaterAnalysisToolStripMenuItem.Name = "plantwiseWaterAnalysisToolStripMenuItem";
            this.plantwiseWaterAnalysisToolStripMenuItem.Size = new System.Drawing.Size(380, 26);
            this.plantwiseWaterAnalysisToolStripMenuItem.Text = "Plantwise water analysis";
            this.plantwiseWaterAnalysisToolStripMenuItem.Click += new System.EventHandler(this.plantwiseWaterAnalysisToolStripMenuItem_Click);
            // 
            // OtherReportstoolStripMenuItem
            // 
            this.OtherReportstoolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.OtherReportstoolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.OtherReportstoolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consumerComplaintSummaryReportToolStripMenuItem,
            this.consumerComplaintResponceReportToolStripMenuItem,
            this.consumerComplaintAnalysisReportToolStripMenuItem1,
            this.consumerComplaintTDBReportToolStripMenuItem1,
            this.waterAnalysisReportToolStripMenuItem1,
            this.monthlyWaterAnalysisReportToolStripMenuItem,
            this.oEEAnalysisReportToolStripMenuItem,
            this.mOMReportToolStripMenuItem,
            this.fGRefSampleMgmtDetailReportToolStripMenuItem,
            this.rMRefSampleMgmtDetailReportToolStripMenuItem,
            this.oEEDetailProcessReportToolStripMenuItem,
            this.refSampleMgmtSummaryReportToolStripMenuItem,
            this.physicoChemicalWaterAToolStripMenuItem,
            this.lastProductionFormulaReportToolStripMenuItem,
            this.consumerComplaintTDBYearlyReportToolStripMenuItem});
            this.OtherReportstoolStripMenuItem.ForeColor = System.Drawing.Color.OrangeRed;
            this.OtherReportstoolStripMenuItem.Name = "OtherReportstoolStripMenuItem";
            this.OtherReportstoolStripMenuItem.Size = new System.Drawing.Size(85, 28);
            this.OtherReportstoolStripMenuItem.Text = "Reports";
            // 
            // consumerComplaintSummaryReportToolStripMenuItem
            // 
            this.consumerComplaintSummaryReportToolStripMenuItem.Name = "consumerComplaintSummaryReportToolStripMenuItem";
            this.consumerComplaintSummaryReportToolStripMenuItem.Size = new System.Drawing.Size(406, 26);
            this.consumerComplaintSummaryReportToolStripMenuItem.Text = "Consumer Complaint Summary Report";
            this.consumerComplaintSummaryReportToolStripMenuItem.Click += new System.EventHandler(this.consumerComplaintSummaryReportToolStripMenuItem_Click);
            // 
            // consumerComplaintResponceReportToolStripMenuItem
            // 
            this.consumerComplaintResponceReportToolStripMenuItem.Name = "consumerComplaintResponceReportToolStripMenuItem";
            this.consumerComplaintResponceReportToolStripMenuItem.Size = new System.Drawing.Size(406, 26);
            this.consumerComplaintResponceReportToolStripMenuItem.Text = "Consumer Complaint Responce Report";
            this.consumerComplaintResponceReportToolStripMenuItem.Click += new System.EventHandler(this.consumerComplaintResponceReportToolStripMenuItem_Click);
            // 
            // consumerComplaintAnalysisReportToolStripMenuItem1
            // 
            this.consumerComplaintAnalysisReportToolStripMenuItem1.Name = "consumerComplaintAnalysisReportToolStripMenuItem1";
            this.consumerComplaintAnalysisReportToolStripMenuItem1.Size = new System.Drawing.Size(406, 26);
            this.consumerComplaintAnalysisReportToolStripMenuItem1.Text = "Consumer Complaint Analysis Report";
            this.consumerComplaintAnalysisReportToolStripMenuItem1.Click += new System.EventHandler(this.consumerComplaintAnalysisReportToolStripMenuItem1_Click);
            // 
            // consumerComplaintTDBReportToolStripMenuItem1
            // 
            this.consumerComplaintTDBReportToolStripMenuItem1.Name = "consumerComplaintTDBReportToolStripMenuItem1";
            this.consumerComplaintTDBReportToolStripMenuItem1.Size = new System.Drawing.Size(406, 26);
            this.consumerComplaintTDBReportToolStripMenuItem1.Text = "Consumer Complaint TDB Report";
            this.consumerComplaintTDBReportToolStripMenuItem1.Click += new System.EventHandler(this.consumerComplaintTDBReportToolStripMenuItem1_Click);
            // 
            // waterAnalysisReportToolStripMenuItem1
            // 
            this.waterAnalysisReportToolStripMenuItem1.Name = "waterAnalysisReportToolStripMenuItem1";
            this.waterAnalysisReportToolStripMenuItem1.Size = new System.Drawing.Size(406, 26);
            this.waterAnalysisReportToolStripMenuItem1.Text = "Water Analysis Report";
            this.waterAnalysisReportToolStripMenuItem1.Click += new System.EventHandler(this.waterAnalysisReportToolStripMenuItem1_Click);
            // 
            // monthlyWaterAnalysisReportToolStripMenuItem
            // 
            this.monthlyWaterAnalysisReportToolStripMenuItem.Name = "monthlyWaterAnalysisReportToolStripMenuItem";
            this.monthlyWaterAnalysisReportToolStripMenuItem.Size = new System.Drawing.Size(406, 26);
            this.monthlyWaterAnalysisReportToolStripMenuItem.Text = "Monthly Water Analysis Report";
            this.monthlyWaterAnalysisReportToolStripMenuItem.Click += new System.EventHandler(this.monthlyWaterAnalysisReportToolStripMenuItem_Click);
            // 
            // oEEAnalysisReportToolStripMenuItem
            // 
            this.oEEAnalysisReportToolStripMenuItem.Name = "oEEAnalysisReportToolStripMenuItem";
            this.oEEAnalysisReportToolStripMenuItem.Size = new System.Drawing.Size(406, 26);
            this.oEEAnalysisReportToolStripMenuItem.Text = "OEE Analysis Report";
            this.oEEAnalysisReportToolStripMenuItem.Click += new System.EventHandler(this.oEEAnalysisReportToolStripMenuItem_Click);
            // 
            // mOMReportToolStripMenuItem
            // 
            this.mOMReportToolStripMenuItem.Name = "mOMReportToolStripMenuItem";
            this.mOMReportToolStripMenuItem.Size = new System.Drawing.Size(406, 26);
            this.mOMReportToolStripMenuItem.Text = "MOM Report";
            this.mOMReportToolStripMenuItem.Click += new System.EventHandler(this.mOMReportToolStripMenuItem_Click);
            // 
            // fGRefSampleMgmtDetailReportToolStripMenuItem
            // 
            this.fGRefSampleMgmtDetailReportToolStripMenuItem.Name = "fGRefSampleMgmtDetailReportToolStripMenuItem";
            this.fGRefSampleMgmtDetailReportToolStripMenuItem.Size = new System.Drawing.Size(406, 26);
            this.fGRefSampleMgmtDetailReportToolStripMenuItem.Text = "FG Ref Sample Mgmt Detail Report";
            this.fGRefSampleMgmtDetailReportToolStripMenuItem.Click += new System.EventHandler(this.fGRefSampleMgmtDetailReportToolStripMenuItem_Click);
            // 
            // rMRefSampleMgmtDetailReportToolStripMenuItem
            // 
            this.rMRefSampleMgmtDetailReportToolStripMenuItem.Name = "rMRefSampleMgmtDetailReportToolStripMenuItem";
            this.rMRefSampleMgmtDetailReportToolStripMenuItem.Size = new System.Drawing.Size(406, 26);
            this.rMRefSampleMgmtDetailReportToolStripMenuItem.Text = "RM Ref Sample Mgmt Detail Report";
            this.rMRefSampleMgmtDetailReportToolStripMenuItem.Click += new System.EventHandler(this.rMRefSampleMgmtDetailReportToolStripMenuItem_Click);
            // 
            // oEEDetailProcessReportToolStripMenuItem
            // 
            this.oEEDetailProcessReportToolStripMenuItem.Name = "oEEDetailProcessReportToolStripMenuItem";
            this.oEEDetailProcessReportToolStripMenuItem.Size = new System.Drawing.Size(406, 26);
            this.oEEDetailProcessReportToolStripMenuItem.Text = "OEE Detail Process Report";
            this.oEEDetailProcessReportToolStripMenuItem.Click += new System.EventHandler(this.oEEDetailProcessReportToolStripMenuItem_Click);
            // 
            // refSampleMgmtSummaryReportToolStripMenuItem
            // 
            this.refSampleMgmtSummaryReportToolStripMenuItem.Name = "refSampleMgmtSummaryReportToolStripMenuItem";
            this.refSampleMgmtSummaryReportToolStripMenuItem.Size = new System.Drawing.Size(406, 26);
            this.refSampleMgmtSummaryReportToolStripMenuItem.Text = "Ref Sample Mgmt Summary Report";
            this.refSampleMgmtSummaryReportToolStripMenuItem.Click += new System.EventHandler(this.refSampleMgmtSummaryReportToolStripMenuItem_Click);
            // 
            // physicoChemicalWaterAToolStripMenuItem
            // 
            this.physicoChemicalWaterAToolStripMenuItem.Name = "physicoChemicalWaterAToolStripMenuItem";
            this.physicoChemicalWaterAToolStripMenuItem.Size = new System.Drawing.Size(406, 26);
            this.physicoChemicalWaterAToolStripMenuItem.Text = "Physico Chemical Water Analysis Report";
            this.physicoChemicalWaterAToolStripMenuItem.Click += new System.EventHandler(this.physicoChemicalWaterAToolStripMenuItem_Click);
            // 
            // lastProductionFormulaReportToolStripMenuItem
            // 
            this.lastProductionFormulaReportToolStripMenuItem.Name = "lastProductionFormulaReportToolStripMenuItem";
            this.lastProductionFormulaReportToolStripMenuItem.Size = new System.Drawing.Size(406, 26);
            this.lastProductionFormulaReportToolStripMenuItem.Text = "Last Production Active Formula Report";
            this.lastProductionFormulaReportToolStripMenuItem.Click += new System.EventHandler(this.lastProductionFormulaReportToolStripMenuItem_Click);
            // 
            // consumerComplaintTDBYearlyReportToolStripMenuItem
            // 
            this.consumerComplaintTDBYearlyReportToolStripMenuItem.Name = "consumerComplaintTDBYearlyReportToolStripMenuItem";
            this.consumerComplaintTDBYearlyReportToolStripMenuItem.Size = new System.Drawing.Size(406, 26);
            this.consumerComplaintTDBYearlyReportToolStripMenuItem.Text = "Consumer Complaint TDB Yearly Report";
            this.consumerComplaintTDBYearlyReportToolStripMenuItem.Click += new System.EventHandler(this.consumerComplaintTDBYearlyReportToolStripMenuItem_Click);
            // 
            // oEEToolStripMenuItem
            // 
            this.oEEToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oEETransactionsToolStripMenuItem,
            this.oEEModificationToolStripMenuItem,
            this.oEEActivityMasterToolStripMenuItem,
            this.activityRelationMasterToolStripMenuItem,
            this.oEETMTMasterToolStripMenuItem,
            this.oEEPUEExcelUploadToolStripMenuItem});
            this.oEEToolStripMenuItem.ForeColor = System.Drawing.Color.LightSlateGray;
            this.oEEToolStripMenuItem.Name = "oEEToolStripMenuItem";
            this.oEEToolStripMenuItem.Size = new System.Drawing.Size(60, 28);
            this.oEEToolStripMenuItem.Text = "OEE";
            // 
            // oEETransactionsToolStripMenuItem
            // 
            this.oEETransactionsToolStripMenuItem.Name = "oEETransactionsToolStripMenuItem";
            this.oEETransactionsToolStripMenuItem.Size = new System.Drawing.Size(310, 26);
            this.oEETransactionsToolStripMenuItem.Text = "OEE Transactions";
            this.oEETransactionsToolStripMenuItem.Click += new System.EventHandler(this.oEETransactionsToolStripMenuItem_Click);
            // 
            // oEEModificationToolStripMenuItem
            // 
            this.oEEModificationToolStripMenuItem.Enabled = false;
            this.oEEModificationToolStripMenuItem.Name = "oEEModificationToolStripMenuItem";
            this.oEEModificationToolStripMenuItem.Size = new System.Drawing.Size(310, 26);
            this.oEEModificationToolStripMenuItem.Text = "OEE Modification";
            this.oEEModificationToolStripMenuItem.Visible = false;
            this.oEEModificationToolStripMenuItem.Click += new System.EventHandler(this.oEEModificationToolStripMenuItem_Click);
            // 
            // oEEActivityMasterToolStripMenuItem
            // 
            this.oEEActivityMasterToolStripMenuItem.Name = "oEEActivityMasterToolStripMenuItem";
            this.oEEActivityMasterToolStripMenuItem.Size = new System.Drawing.Size(310, 26);
            this.oEEActivityMasterToolStripMenuItem.Text = "OEE Activity Master";
            this.oEEActivityMasterToolStripMenuItem.Click += new System.EventHandler(this.oEEActivityMasterToolStripMenuItem_Click);
            // 
            // activityRelationMasterToolStripMenuItem
            // 
            this.activityRelationMasterToolStripMenuItem.Name = "activityRelationMasterToolStripMenuItem";
            this.activityRelationMasterToolStripMenuItem.Size = new System.Drawing.Size(310, 26);
            this.activityRelationMasterToolStripMenuItem.Text = "OEE Activity Relation Master";
            this.activityRelationMasterToolStripMenuItem.Click += new System.EventHandler(this.activityRelationMasterToolStripMenuItem_Click);
            // 
            // oEETMTMasterToolStripMenuItem
            // 
            this.oEETMTMasterToolStripMenuItem.Name = "oEETMTMasterToolStripMenuItem";
            this.oEETMTMasterToolStripMenuItem.Size = new System.Drawing.Size(310, 26);
            this.oEETMTMasterToolStripMenuItem.Text = "OEE TMT Master";
            this.oEETMTMasterToolStripMenuItem.Click += new System.EventHandler(this.oEETMTMasterToolStripMenuItem_Click);
            // 
            // oEEPUEExcelUploadToolStripMenuItem
            // 
            this.oEEPUEExcelUploadToolStripMenuItem.Name = "oEEPUEExcelUploadToolStripMenuItem";
            this.oEEPUEExcelUploadToolStripMenuItem.Size = new System.Drawing.Size(310, 26);
            this.oEEPUEExcelUploadToolStripMenuItem.Text = "OEE PUR Excel Upload";
            this.oEEPUEExcelUploadToolStripMenuItem.Click += new System.EventHandler(this.oEEPUEExcelUploadToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autoLineOEETransationToolStripMenuItem,
            this.lineOEEFGMasterToolStripMenuItem,
            this.lineOEEActivityMasterToolStripMenuItem,
            this.lineOEEMachineMasterToolStripMenuItem,
            this.lineOEEActivityRelationMasterToolStripMenuItem,
            this.uploadLineOEEMasterToolStripMenuItem,
            this.lineOEEDataJunctionReportToolStripMenuItem,
            this.lineOEEBreakDownReportToolStripMenuItem,
            this.viewUploadLineOEEMasterToolStripMenuItem,
            this.lineOEEUPTdbReportToolStripMenuItem,
            this.lineOEEGraphReportToolStripMenuItem,
            this.settingToolStripMenuItem,
            this.demoToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(99, 28);
            this.toolStripMenuItem1.Text = "Line OEE";
            // 
            // autoLineOEETransationToolStripMenuItem
            // 
            this.autoLineOEETransationToolStripMenuItem.Name = "autoLineOEETransationToolStripMenuItem";
            this.autoLineOEETransationToolStripMenuItem.Size = new System.Drawing.Size(349, 26);
            this.autoLineOEETransationToolStripMenuItem.Text = "Line OEE Transation";
            this.autoLineOEETransationToolStripMenuItem.Click += new System.EventHandler(this.autoLineOEETransationToolStripMenuItem_Click);
            // 
            // lineOEEFGMasterToolStripMenuItem
            // 
            this.lineOEEFGMasterToolStripMenuItem.Name = "lineOEEFGMasterToolStripMenuItem";
            this.lineOEEFGMasterToolStripMenuItem.Size = new System.Drawing.Size(349, 26);
            this.lineOEEFGMasterToolStripMenuItem.Text = "Line OEE FG Master";
            this.lineOEEFGMasterToolStripMenuItem.Click += new System.EventHandler(this.lineOEEFGMasterToolStripMenuItem_Click);
            // 
            // lineOEEActivityMasterToolStripMenuItem
            // 
            this.lineOEEActivityMasterToolStripMenuItem.Name = "lineOEEActivityMasterToolStripMenuItem";
            this.lineOEEActivityMasterToolStripMenuItem.Size = new System.Drawing.Size(349, 26);
            this.lineOEEActivityMasterToolStripMenuItem.Text = "Line OEE Master";
            this.lineOEEActivityMasterToolStripMenuItem.Click += new System.EventHandler(this.lineOEEActivityMasterToolStripMenuItem_Click);
            // 
            // lineOEEMachineMasterToolStripMenuItem
            // 
            this.lineOEEMachineMasterToolStripMenuItem.Name = "lineOEEMachineMasterToolStripMenuItem";
            this.lineOEEMachineMasterToolStripMenuItem.Size = new System.Drawing.Size(349, 26);
            this.lineOEEMachineMasterToolStripMenuItem.Text = "Line OEE Machine Master";
            this.lineOEEMachineMasterToolStripMenuItem.Click += new System.EventHandler(this.lineOEEMachineMasterToolStripMenuItem_Click);
            // 
            // lineOEEActivityRelationMasterToolStripMenuItem
            // 
            this.lineOEEActivityRelationMasterToolStripMenuItem.Name = "lineOEEActivityRelationMasterToolStripMenuItem";
            this.lineOEEActivityRelationMasterToolStripMenuItem.Size = new System.Drawing.Size(349, 26);
            this.lineOEEActivityRelationMasterToolStripMenuItem.Text = "Line OEE Activity Relation Master";
            this.lineOEEActivityRelationMasterToolStripMenuItem.Click += new System.EventHandler(this.lineOEEActivityRelationMasterToolStripMenuItem_Click);
            // 
            // uploadLineOEEMasterToolStripMenuItem
            // 
            this.uploadLineOEEMasterToolStripMenuItem.Name = "uploadLineOEEMasterToolStripMenuItem";
            this.uploadLineOEEMasterToolStripMenuItem.Size = new System.Drawing.Size(349, 26);
            this.uploadLineOEEMasterToolStripMenuItem.Text = "Upload Line OEE Master";
            this.uploadLineOEEMasterToolStripMenuItem.Click += new System.EventHandler(this.uploadLineOEEMasterToolStripMenuItem_Click);
            // 
            // lineOEEDataJunctionReportToolStripMenuItem
            // 
            this.lineOEEDataJunctionReportToolStripMenuItem.Name = "lineOEEDataJunctionReportToolStripMenuItem";
            this.lineOEEDataJunctionReportToolStripMenuItem.Size = new System.Drawing.Size(349, 26);
            this.lineOEEDataJunctionReportToolStripMenuItem.Text = "Line OEE Data Junction Report";
            this.lineOEEDataJunctionReportToolStripMenuItem.Click += new System.EventHandler(this.lineOEEDataJunctionReportToolStripMenuItem_Click);
            // 
            // lineOEEBreakDownReportToolStripMenuItem
            // 
            this.lineOEEBreakDownReportToolStripMenuItem.Name = "lineOEEBreakDownReportToolStripMenuItem";
            this.lineOEEBreakDownReportToolStripMenuItem.Size = new System.Drawing.Size(349, 26);
            this.lineOEEBreakDownReportToolStripMenuItem.Text = "Line OEE BreakDown Report";
            this.lineOEEBreakDownReportToolStripMenuItem.Click += new System.EventHandler(this.lineOEEBreakDownReportToolStripMenuItem_Click);
            // 
            // viewUploadLineOEEMasterToolStripMenuItem
            // 
            this.viewUploadLineOEEMasterToolStripMenuItem.Name = "viewUploadLineOEEMasterToolStripMenuItem";
            this.viewUploadLineOEEMasterToolStripMenuItem.Size = new System.Drawing.Size(349, 26);
            this.viewUploadLineOEEMasterToolStripMenuItem.Text = "View Upload Line OEE Master";
            this.viewUploadLineOEEMasterToolStripMenuItem.Click += new System.EventHandler(this.viewUploadLineOEEMasterToolStripMenuItem_Click);
            // 
            // lineOEEUPTdbReportToolStripMenuItem
            // 
            this.lineOEEUPTdbReportToolStripMenuItem.Name = "lineOEEUPTdbReportToolStripMenuItem";
            this.lineOEEUPTdbReportToolStripMenuItem.Size = new System.Drawing.Size(349, 26);
            this.lineOEEUPTdbReportToolStripMenuItem.Text = "Line OEE Report";
            this.lineOEEUPTdbReportToolStripMenuItem.Click += new System.EventHandler(this.lineOEEUPTdbReportToolStripMenuItem_Click);
            // 
            // lineOEEGraphReportToolStripMenuItem
            // 
            this.lineOEEGraphReportToolStripMenuItem.Name = "lineOEEGraphReportToolStripMenuItem";
            this.lineOEEGraphReportToolStripMenuItem.Size = new System.Drawing.Size(349, 26);
            this.lineOEEGraphReportToolStripMenuItem.Text = "Line OEE Graph Report";
            this.lineOEEGraphReportToolStripMenuItem.Click += new System.EventHandler(this.lineOEEGraphReportToolStripMenuItem_Click);
            // 
            // settingToolStripMenuItem
            // 
            this.settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            this.settingToolStripMenuItem.Size = new System.Drawing.Size(349, 26);
            this.settingToolStripMenuItem.Text = "Setting";
            this.settingToolStripMenuItem.Click += new System.EventHandler(this.settingToolStripMenuItem_Click);
            // 
            // imageComparisionToolStripMenuItem
            // 
            this.imageComparisionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imageComparisonToolStripMenuItem});
            this.imageComparisionToolStripMenuItem.Name = "imageComparisionToolStripMenuItem";
            this.imageComparisionToolStripMenuItem.Size = new System.Drawing.Size(148, 28);
            this.imageComparisionToolStripMenuItem.Text = "Image Compare";
            this.imageComparisionToolStripMenuItem.Click += new System.EventHandler(this.imageComparisionToolStripMenuItem_Click);
            // 
            // imageComparisonToolStripMenuItem
            // 
            this.imageComparisonToolStripMenuItem.Name = "imageComparisonToolStripMenuItem";
            this.imageComparisonToolStripMenuItem.Size = new System.Drawing.Size(229, 26);
            this.imageComparisonToolStripMenuItem.Text = "Image Comparison";
            this.imageComparisonToolStripMenuItem.Click += new System.EventHandler(this.imageComparisonToolStripMenuItem_Click);
            // 
            // reagentMgtToolStripMenuItem
            // 
            this.reagentMgtToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reagentSupplierMasterToolStripMenuItem,
            this.reagentSupplierPOMappingMasterToolStripMenuItem,
            this.reagentMasterToolStripMenuItem,
            this.reagentTransactionToolStripMenuItem,
            this.reaToolStripMenuItem,
            this.reagentModificationToolStripMenuItem,
            this.reagentConsumptionToolStripMenuItem,
            this.reagentAvailableStockReportToolStripMenuItem,
            this.reagentDetailsReportToolStripMenuItem,
            this.reagentReorderLevelReportToolStripMenuItem,
            this.reagentLabelRePrintReportToolStripMenuItem});
            this.reagentMgtToolStripMenuItem.Name = "reagentMgtToolStripMenuItem";
            this.reagentMgtToolStripMenuItem.Size = new System.Drawing.Size(143, 28);
            this.reagentMgtToolStripMenuItem.Text = "Reagent Mgmt.";
            // 
            // reagentSupplierMasterToolStripMenuItem
            // 
            this.reagentSupplierMasterToolStripMenuItem.Name = "reagentSupplierMasterToolStripMenuItem";
            this.reagentSupplierMasterToolStripMenuItem.Size = new System.Drawing.Size(382, 26);
            this.reagentSupplierMasterToolStripMenuItem.Text = "Reagent Supplier Master";
            this.reagentSupplierMasterToolStripMenuItem.Click += new System.EventHandler(this.reagentSupplierMasterToolStripMenuItem_Click);
            // 
            // reagentSupplierPOMappingMasterToolStripMenuItem
            // 
            this.reagentSupplierPOMappingMasterToolStripMenuItem.Name = "reagentSupplierPOMappingMasterToolStripMenuItem";
            this.reagentSupplierPOMappingMasterToolStripMenuItem.Size = new System.Drawing.Size(382, 26);
            this.reagentSupplierPOMappingMasterToolStripMenuItem.Text = "Reagent Supplier PO Mapping Master";
            this.reagentSupplierPOMappingMasterToolStripMenuItem.Click += new System.EventHandler(this.reagentSupplierPOMappingMasterToolStripMenuItem_Click);
            // 
            // reagentMasterToolStripMenuItem
            // 
            this.reagentMasterToolStripMenuItem.Name = "reagentMasterToolStripMenuItem";
            this.reagentMasterToolStripMenuItem.Size = new System.Drawing.Size(382, 26);
            this.reagentMasterToolStripMenuItem.Text = "Reagent Master";
            this.reagentMasterToolStripMenuItem.Click += new System.EventHandler(this.reagentMasterToolStripMenuItem_Click);
            // 
            // reagentTransactionToolStripMenuItem
            // 
            this.reagentTransactionToolStripMenuItem.Name = "reagentTransactionToolStripMenuItem";
            this.reagentTransactionToolStripMenuItem.Size = new System.Drawing.Size(382, 26);
            this.reagentTransactionToolStripMenuItem.Text = "Reagent Transaction";
            this.reagentTransactionToolStripMenuItem.Click += new System.EventHandler(this.reagentTransactionToolStripMenuItem_Click);
            // 
            // reaToolStripMenuItem
            // 
            this.reaToolStripMenuItem.Name = "reaToolStripMenuItem";
            this.reaToolStripMenuItem.Size = new System.Drawing.Size(382, 26);
            this.reaToolStripMenuItem.Text = "Reagent Standardization";
            this.reaToolStripMenuItem.Visible = false;
            this.reaToolStripMenuItem.Click += new System.EventHandler(this.reaToolStripMenuItem_Click);
            // 
            // reagentModificationToolStripMenuItem
            // 
            this.reagentModificationToolStripMenuItem.Name = "reagentModificationToolStripMenuItem";
            this.reagentModificationToolStripMenuItem.Size = new System.Drawing.Size(382, 26);
            this.reagentModificationToolStripMenuItem.Text = "Reagent Modification";
            this.reagentModificationToolStripMenuItem.Click += new System.EventHandler(this.reagentModificationToolStripMenuItem_Click);
            // 
            // reagentConsumptionToolStripMenuItem
            // 
            this.reagentConsumptionToolStripMenuItem.Name = "reagentConsumptionToolStripMenuItem";
            this.reagentConsumptionToolStripMenuItem.Size = new System.Drawing.Size(382, 26);
            this.reagentConsumptionToolStripMenuItem.Text = "Reagent Consumption";
            this.reagentConsumptionToolStripMenuItem.Click += new System.EventHandler(this.reagentConsumptionToolStripMenuItem_Click);
            // 
            // reagentAvailableStockReportToolStripMenuItem
            // 
            this.reagentAvailableStockReportToolStripMenuItem.Name = "reagentAvailableStockReportToolStripMenuItem";
            this.reagentAvailableStockReportToolStripMenuItem.Size = new System.Drawing.Size(382, 26);
            this.reagentAvailableStockReportToolStripMenuItem.Text = "Reagent Available Stock Report";
            this.reagentAvailableStockReportToolStripMenuItem.Click += new System.EventHandler(this.reagentAvailableStockReportToolStripMenuItem_Click);
            // 
            // reagentDetailsReportToolStripMenuItem
            // 
            this.reagentDetailsReportToolStripMenuItem.Name = "reagentDetailsReportToolStripMenuItem";
            this.reagentDetailsReportToolStripMenuItem.Size = new System.Drawing.Size(382, 26);
            this.reagentDetailsReportToolStripMenuItem.Text = "Reagent Details Report";
            this.reagentDetailsReportToolStripMenuItem.Click += new System.EventHandler(this.reagentDetailsReportToolStripMenuItem_Click);
            // 
            // reagentReorderLevelReportToolStripMenuItem
            // 
            this.reagentReorderLevelReportToolStripMenuItem.Name = "reagentReorderLevelReportToolStripMenuItem";
            this.reagentReorderLevelReportToolStripMenuItem.Size = new System.Drawing.Size(382, 26);
            this.reagentReorderLevelReportToolStripMenuItem.Text = "Reagent Reorder Level Report";
            this.reagentReorderLevelReportToolStripMenuItem.Visible = false;
            this.reagentReorderLevelReportToolStripMenuItem.Click += new System.EventHandler(this.reagentReorderLevelReportToolStripMenuItem_Click);
            // 
            // reagentLabelRePrintReportToolStripMenuItem
            // 
            this.reagentLabelRePrintReportToolStripMenuItem.Name = "reagentLabelRePrintReportToolStripMenuItem";
            this.reagentLabelRePrintReportToolStripMenuItem.Size = new System.Drawing.Size(382, 26);
            this.reagentLabelRePrintReportToolStripMenuItem.Text = "Reagent Label Re Print Report";
            this.reagentLabelRePrintReportToolStripMenuItem.Click += new System.EventHandler(this.reagentLabelRePrintReportToolStripMenuItem_Click);
            // 
            // menuStripScoop
            // 
            this.menuStripScoop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.menuStripScoop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuStripScoop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.masterToolStripMenuItem,
            this.transactionToolStripMenuItem,
            this.tDBToolStripMenuItem,
            this.detailToolStripMenuItem});
            this.menuStripScoop.Location = new System.Drawing.Point(0, 0);
            this.menuStripScoop.Name = "menuStripScoop";
            this.menuStripScoop.Size = new System.Drawing.Size(878, 28);
            this.menuStripScoop.TabIndex = 4;
            this.menuStripScoop.Text = "menuStrip1";
            this.menuStripScoop.Visible = false;
            // 
            // masterToolStripMenuItem
            // 
            this.masterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lineSamplingPointMasterToolStripMenuItem,
            this.lineSamplingPointInfoToolStripMenuItem1,
            this.scoopTestMethodMasterToolStripMenuItem});
            this.masterToolStripMenuItem.ForeColor = System.Drawing.Color.LightSlateGray;
            this.masterToolStripMenuItem.Name = "masterToolStripMenuItem";
            this.masterToolStripMenuItem.Size = new System.Drawing.Size(78, 24);
            this.masterToolStripMenuItem.Text = "Master";
            // 
            // lineSamplingPointMasterToolStripMenuItem
            // 
            this.lineSamplingPointMasterToolStripMenuItem.Name = "lineSamplingPointMasterToolStripMenuItem";
            this.lineSamplingPointMasterToolStripMenuItem.Size = new System.Drawing.Size(299, 30);
            this.lineSamplingPointMasterToolStripMenuItem.Text = "Line Sampling Point Master";
            this.lineSamplingPointMasterToolStripMenuItem.Click += new System.EventHandler(this.lineSamplingPointMasterToolStripMenuItem_Click);
            // 
            // lineSamplingPointInfoToolStripMenuItem1
            // 
            this.lineSamplingPointInfoToolStripMenuItem1.Name = "lineSamplingPointInfoToolStripMenuItem1";
            this.lineSamplingPointInfoToolStripMenuItem1.Size = new System.Drawing.Size(299, 30);
            this.lineSamplingPointInfoToolStripMenuItem1.Text = "Line-SamplingPoint Info";
            this.lineSamplingPointInfoToolStripMenuItem1.Click += new System.EventHandler(this.lineSamplingPointInfoToolStripMenuItem1_Click);
            // 
            // scoopTestMethodMasterToolStripMenuItem
            // 
            this.scoopTestMethodMasterToolStripMenuItem.Name = "scoopTestMethodMasterToolStripMenuItem";
            this.scoopTestMethodMasterToolStripMenuItem.Size = new System.Drawing.Size(299, 30);
            this.scoopTestMethodMasterToolStripMenuItem.Text = "Scoop Test Method Master";
            this.scoopTestMethodMasterToolStripMenuItem.Click += new System.EventHandler(this.scoopTestMethodMasterToolStripMenuItem_Click);
            // 
            // transactionToolStripMenuItem
            // 
            this.transactionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uPToolStripMenuItem,
            this.uPAuthorityToolStripMenuItem,
            this.qualityAuthorityToolStripMenuItem});
            this.transactionToolStripMenuItem.ForeColor = System.Drawing.Color.LightSlateGray;
            this.transactionToolStripMenuItem.Name = "transactionToolStripMenuItem";
            this.transactionToolStripMenuItem.Size = new System.Drawing.Size(112, 24);
            this.transactionToolStripMenuItem.Text = "Transaction";
            // 
            // uPToolStripMenuItem
            // 
            this.uPToolStripMenuItem.Name = "uPToolStripMenuItem";
            this.uPToolStripMenuItem.Size = new System.Drawing.Size(308, 30);
            this.uPToolStripMenuItem.Text = "Finished good test UP";
            this.uPToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uPToolStripMenuItem.Click += new System.EventHandler(this.uPToolStripMenuItem_Click);
            // 
            // uPAuthorityToolStripMenuItem
            // 
            this.uPAuthorityToolStripMenuItem.Name = "uPAuthorityToolStripMenuItem";
            this.uPAuthorityToolStripMenuItem.Size = new System.Drawing.Size(308, 30);
            this.uPAuthorityToolStripMenuItem.Text = "UP Authority-FG Test Up";
            this.uPAuthorityToolStripMenuItem.Click += new System.EventHandler(this.uPAuthorityToolStripMenuItem_Click);
            // 
            // qualityAuthorityToolStripMenuItem
            // 
            this.qualityAuthorityToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.qualityAuthorityToolStripMenuItem.Name = "qualityAuthorityToolStripMenuItem";
            this.qualityAuthorityToolStripMenuItem.Size = new System.Drawing.Size(308, 30);
            this.qualityAuthorityToolStripMenuItem.Text = "Quality Authority-Fg Test UP";
            this.qualityAuthorityToolStripMenuItem.Click += new System.EventHandler(this.qualityAuthorityToolStripMenuItem_Click);
            // 
            // tDBToolStripMenuItem
            // 
            this.tDBToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tDBToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.globalFGTDBToolStripMenuItem,
            this.fGLineTDBReportToolStripMenuItem});
            this.tDBToolStripMenuItem.Name = "tDBToolStripMenuItem";
            this.tDBToolStripMenuItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tDBToolStripMenuItem.Size = new System.Drawing.Size(56, 24);
            this.tDBToolStripMenuItem.Text = "TDB";
            // 
            // globalFGTDBToolStripMenuItem
            // 
            this.globalFGTDBToolStripMenuItem.Name = "globalFGTDBToolStripMenuItem";
            this.globalFGTDBToolStripMenuItem.Size = new System.Drawing.Size(236, 30);
            this.globalFGTDBToolStripMenuItem.Text = "Global FG TDB";
            this.globalFGTDBToolStripMenuItem.Click += new System.EventHandler(this.globalFGTDBToolStripMenuItem_Click);
            // 
            // fGLineTDBReportToolStripMenuItem
            // 
            this.fGLineTDBReportToolStripMenuItem.Name = "fGLineTDBReportToolStripMenuItem";
            this.fGLineTDBReportToolStripMenuItem.Size = new System.Drawing.Size(236, 30);
            this.fGLineTDBReportToolStripMenuItem.Text = "FG Line TDB Report";
            this.fGLineTDBReportToolStripMenuItem.Click += new System.EventHandler(this.fGLineTDBReportToolStripMenuItem_Click);
            // 
            // detailToolStripMenuItem
            // 
            this.detailToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.detailToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fGAnalysisReportToolStripMenuItem,
            this.fGTransactionAnalysisReportToolStripMenuItem,
            this.fGAnalysisNotDoneReportToolStripMenuItem});
            this.detailToolStripMenuItem.Name = "detailToolStripMenuItem";
            this.detailToolStripMenuItem.Size = new System.Drawing.Size(69, 24);
            this.detailToolStripMenuItem.Text = "Detail";
            // 
            // fGAnalysisReportToolStripMenuItem
            // 
            this.fGAnalysisReportToolStripMenuItem.Name = "fGAnalysisReportToolStripMenuItem";
            this.fGAnalysisReportToolStripMenuItem.Size = new System.Drawing.Size(331, 30);
            this.fGAnalysisReportToolStripMenuItem.Text = "FG_Analysis_Report";
            this.fGAnalysisReportToolStripMenuItem.Click += new System.EventHandler(this.fGAnalysisReportToolStripMenuItem_Click_1);
            // 
            // fGTransactionAnalysisReportToolStripMenuItem
            // 
            this.fGTransactionAnalysisReportToolStripMenuItem.Name = "fGTransactionAnalysisReportToolStripMenuItem";
            this.fGTransactionAnalysisReportToolStripMenuItem.Size = new System.Drawing.Size(331, 30);
            this.fGTransactionAnalysisReportToolStripMenuItem.Text = "FG_Transaction_Analysis_Report";
            this.fGTransactionAnalysisReportToolStripMenuItem.Visible = false;
            this.fGTransactionAnalysisReportToolStripMenuItem.Click += new System.EventHandler(this.fGTransactionAnalysisReportToolStripMenuItem_Click);
            // 
            // fGAnalysisNotDoneReportToolStripMenuItem
            // 
            this.fGAnalysisNotDoneReportToolStripMenuItem.Name = "fGAnalysisNotDoneReportToolStripMenuItem";
            this.fGAnalysisNotDoneReportToolStripMenuItem.Size = new System.Drawing.Size(331, 30);
            this.fGAnalysisNotDoneReportToolStripMenuItem.Text = "FG_Analysis_NotDoneReport";
            this.fGAnalysisNotDoneReportToolStripMenuItem.Click += new System.EventHandler(this.fGAnalysisNotDoneReportToolStripMenuItem_Click);
            // 
            // menuStripSubCon
            // 
            this.menuStripSubCon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.menuStripSubCon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuStripSubCon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3,
            this.toolStripMenuItem7,
            this.toolStripMenuItem13,
            this.toolStripMenuItem16,
            this.modificationToolStripMenuItem});
            this.menuStripSubCon.Location = new System.Drawing.Point(0, 0);
            this.menuStripSubCon.Name = "menuStripSubCon";
            this.menuStripSubCon.Size = new System.Drawing.Size(1179, 28);
            this.menuStripSubCon.TabIndex = 5;
            this.menuStripSubCon.Text = "menuStrip1";
            this.menuStripSubCon.Visible = false;
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem4});
            this.toolStripMenuItem3.ForeColor = System.Drawing.Color.LightSlateGray;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(78, 24);
            this.toolStripMenuItem3.Text = "Master";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(345, 30);
            this.toolStripMenuItem4.Text = "FG Subcontactor Supplier Master";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem9,
            this.toolStripMenuItem10,
            this.toolStripMenuItem11,
            this.toolStripMenuItem12});
            this.toolStripMenuItem7.ForeColor = System.Drawing.Color.LightSlateGray;
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(112, 24);
            this.toolStripMenuItem7.Text = "Transaction";
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(234, 30);
            this.toolStripMenuItem9.Text = "Bulk Test Details";
            this.toolStripMenuItem9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripMenuItem9.Visible = false;
            this.toolStripMenuItem9.Click += new System.EventHandler(this.toolStripMenuItem9_Click);
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(234, 30);
            this.toolStripMenuItem10.Text = "Preservative Test";
            this.toolStripMenuItem10.Visible = false;
            this.toolStripMenuItem10.Click += new System.EventHandler(this.toolStripMenuItem10_Click);
            // 
            // toolStripMenuItem11
            // 
            this.toolStripMenuItem11.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolStripMenuItem11.Name = "toolStripMenuItem11";
            this.toolStripMenuItem11.Size = new System.Drawing.Size(234, 30);
            this.toolStripMenuItem11.Text = "Microbiology Test";
            this.toolStripMenuItem11.Visible = false;
            this.toolStripMenuItem11.Click += new System.EventHandler(this.toolStripMenuItem11_Click);
            // 
            // toolStripMenuItem12
            // 
            this.toolStripMenuItem12.Name = "toolStripMenuItem12";
            this.toolStripMenuItem12.Size = new System.Drawing.Size(234, 30);
            this.toolStripMenuItem12.Text = "Finished Good Test";
            this.toolStripMenuItem12.Click += new System.EventHandler(this.toolStripMenuItem12_Click);
            // 
            // toolStripMenuItem13
            // 
            this.toolStripMenuItem13.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripMenuItem13.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem14,
            this.toolStripMenuItem15});
            this.toolStripMenuItem13.Name = "toolStripMenuItem13";
            this.toolStripMenuItem13.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStripMenuItem13.Size = new System.Drawing.Size(56, 24);
            this.toolStripMenuItem13.Text = "TDB";
            // 
            // toolStripMenuItem14
            // 
            this.toolStripMenuItem14.Name = "toolStripMenuItem14";
            this.toolStripMenuItem14.Size = new System.Drawing.Size(236, 30);
            this.toolStripMenuItem14.Text = "Global FG TDB";
            this.toolStripMenuItem14.Click += new System.EventHandler(this.toolStripMenuItem14_Click);
            // 
            // toolStripMenuItem15
            // 
            this.toolStripMenuItem15.Name = "toolStripMenuItem15";
            this.toolStripMenuItem15.Size = new System.Drawing.Size(236, 30);
            this.toolStripMenuItem15.Text = "FG Line TDB Report";
            this.toolStripMenuItem15.Visible = false;
            // 
            // toolStripMenuItem16
            // 
            this.toolStripMenuItem16.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripMenuItem16.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem17,
            this.toolStripMenuItem18,
            this.retainerLocationReportToolStripMenuItem1,
            this.finishedGoodSummaryReportToolStripMenuItem,
            this.fGMfgWoAnalysisReportToolStripMenuItem});
            this.toolStripMenuItem16.Name = "toolStripMenuItem16";
            this.toolStripMenuItem16.Size = new System.Drawing.Size(69, 24);
            this.toolStripMenuItem16.Text = "Detail";
            // 
            // toolStripMenuItem17
            // 
            this.toolStripMenuItem17.Name = "toolStripMenuItem17";
            this.toolStripMenuItem17.Size = new System.Drawing.Size(338, 30);
            this.toolStripMenuItem17.Text = "FG_Analysis_Report";
            this.toolStripMenuItem17.Click += new System.EventHandler(this.toolStripMenuItem17_Click);
            // 
            // toolStripMenuItem18
            // 
            this.toolStripMenuItem18.Name = "toolStripMenuItem18";
            this.toolStripMenuItem18.Size = new System.Drawing.Size(338, 30);
            this.toolStripMenuItem18.Text = "FG_Analysis_NotDoneReport";
            this.toolStripMenuItem18.Visible = false;
            // 
            // retainerLocationReportToolStripMenuItem1
            // 
            this.retainerLocationReportToolStripMenuItem1.Name = "retainerLocationReportToolStripMenuItem1";
            this.retainerLocationReportToolStripMenuItem1.Size = new System.Drawing.Size(338, 30);
            this.retainerLocationReportToolStripMenuItem1.Text = "Retainer Location Report";
            this.retainerLocationReportToolStripMenuItem1.Click += new System.EventHandler(this.retainerLocationReportToolStripMenuItem1_Click);
            // 
            // finishedGoodSummaryReportToolStripMenuItem
            // 
            this.finishedGoodSummaryReportToolStripMenuItem.Name = "finishedGoodSummaryReportToolStripMenuItem";
            this.finishedGoodSummaryReportToolStripMenuItem.Size = new System.Drawing.Size(338, 30);
            this.finishedGoodSummaryReportToolStripMenuItem.Text = "Finished Good Summary Report";
            this.finishedGoodSummaryReportToolStripMenuItem.Click += new System.EventHandler(this.finishedGoodSummaryReportToolStripMenuItem_Click_1);
            // 
            // fGMfgWoAnalysisReportToolStripMenuItem
            // 
            this.fGMfgWoAnalysisReportToolStripMenuItem.Name = "fGMfgWoAnalysisReportToolStripMenuItem";
            this.fGMfgWoAnalysisReportToolStripMenuItem.Size = new System.Drawing.Size(338, 30);
            this.fGMfgWoAnalysisReportToolStripMenuItem.Text = "FG_MfgWo_Analysis_Report";
            this.fGMfgWoAnalysisReportToolStripMenuItem.Click += new System.EventHandler(this.fGMfgWoAnalysisReportToolStripMenuItem_Click);
            // 
            // modificationToolStripMenuItem
            // 
            this.modificationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.finishGoodTestToolStripMenuItem});
            this.modificationToolStripMenuItem.ForeColor = System.Drawing.Color.LightSlateGray;
            this.modificationToolStripMenuItem.Name = "modificationToolStripMenuItem";
            this.modificationToolStripMenuItem.Size = new System.Drawing.Size(124, 24);
            this.modificationToolStripMenuItem.Text = "Modification";
            // 
            // finishGoodTestToolStripMenuItem
            // 
            this.finishGoodTestToolStripMenuItem.Name = "finishGoodTestToolStripMenuItem";
            this.finishGoodTestToolStripMenuItem.Size = new System.Drawing.Size(234, 30);
            this.finishGoodTestToolStripMenuItem.Text = "Finished Good Test";
            this.finishGoodTestToolStripMenuItem.Click += new System.EventHandler(this.finishGoodTestToolStripMenuItem_Click);
            // 
            // demoToolStripMenuItem
            // 
            this.demoToolStripMenuItem.Name = "demoToolStripMenuItem";
            this.demoToolStripMenuItem.Size = new System.Drawing.Size(349, 26);
            this.demoToolStripMenuItem.Text = "Demo";
            this.demoToolStripMenuItem.Click += new System.EventHandler(this.demoToolStripMenuItem_Click);
            // 
            // FrmMain
            // 
            this.AllowDrop = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(210)))), ((int)(((byte)(226)))));
            this.BackgroundImage = global::QTMS.Properties.Resources.loreal_bg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1247, 662);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStripScoop;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.menuStripADMINH.ResumeLayout(false);
            this.menuStripADMINH.PerformLayout();
            this.menuStripFDAH.ResumeLayout(false);
            this.menuStripFDAH.PerformLayout();
            this.menuStripPMH.ResumeLayout(false);
            this.menuStripPMH.PerformLayout();
            this.menuStripRMH.ResumeLayout(false);
            this.menuStripRMH.PerformLayout();
            this.menuStripQTMSH.ResumeLayout(false);
            this.menuStripQTMSH.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            this.menuStripMettler.ResumeLayout(false);
            this.menuStripMettler.PerformLayout();
            this.menuStripLineValidation.ResumeLayout(false);
            this.menuStripLineValidation.PerformLayout();
            this.menuStripOther.ResumeLayout(false);
            this.menuStripOther.PerformLayout();
            this.menuStripScoop.ResumeLayout(false);
            this.menuStripScoop.PerformLayout();
            this.menuStripSubCon.ResumeLayout(false);
            this.menuStripSubCon.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        #region "MAIN METHOD"

        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMain());
            //Application.Run(new FrmBarcodeTest());
        }

        #endregion

        #region "DECLARATION"

        static public int LoginID;
        static public string UserType;
        static public int UserTypeID;

        //static public SerialPort mySerialPort = new SerialPort("COM1");

        BusinessFacade.UserManagement_Class UserManagement_Class_Obj = new BusinessFacade.UserManagement_Class();


        #endregion


        public string GetVersion()
        {
            string ourVersion = string.Empty;
            //if running the deployed application, you can get the version
            // from the ApplicationDeployment information. If you try
            // to access this when you are running in Visual Studio, it will not work.
            #region changed by sanjiv on 13-Jan-2014 to get version from database
            //if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
            //{
            //    ourVersion = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
            //}
            //else
            //{
            //    Assembly asm = Assembly.GetExecutingAssembly();

            //    if (asm != null)
            //    {
            //        ourVersion = asm.GetName().Version.ToString();
            //    }
            //}

            DataSet dsVersion = UserManagement_Class_Obj.Select_tblSoftwareVersion();
            if (dsVersion.Tables.Count > 0)
            {
                if (dsVersion.Tables[0].Rows.Count > 0)
                {
                    ourVersion = Convert.ToString(dsVersion.Tables[0].Rows[0]["version"]);
                }
            }
            #endregion



            return ourVersion;
        }
        public void GetCompanyName()
        {
            string ourVersion = string.Empty;
            //if running the deployed application, you can get the version
            // from the ApplicationDeployment information. If you try
            // to access this when you are running in Visual Studio, it will not work.
            #region changed by sanjiv on 13-Jan-2014 to get version from database
            //if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
            //{
            //    ourVersion = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
            //}
            //else
            //{
            //    Assembly asm = Assembly.GetExecutingAssembly();

            //    if (asm != null)
            //    {
            //        ourVersion = asm.GetName().Version.ToString();
            //    }
            //}

            DataSet dsCompany = UserManagement_Class_Obj.Select_GetCompanyDetails();
            if (dsCompany.Tables.Count > 0)
            {
                if (dsCompany.Tables[0].Rows.Count > 0)
                {
                    GlobalVariables.companyName = Convert.ToString(dsCompany.Tables[0].Rows[0]["CompanyName"]);
                    GlobalVariables.Address1 = Convert.ToString(dsCompany.Tables[0].Rows[0]["Address1"]);
                    GlobalVariables.Address2 = Convert.ToString(dsCompany.Tables[0].Rows[0]["Address2"]);
                    GlobalVariables.Address3 = Convert.ToString(dsCompany.Tables[0].Rows[0]["Address3"]);
                    GlobalVariables.City = Convert.ToString(dsCompany.Tables[0].Rows[0]["City"]);
                    GlobalVariables.FIName = Convert.ToString(dsCompany.Tables[0].Rows[0]["FIName"]);
                }
            }
            #endregion




        }
        #region "LOAD METHOD"

        private void FrmMain_Load(object sender, EventArgs e)
        {
            try
            {
                //set version info               
                //if (ApplicationDeployment.IsNetworkDeployed)
                //{                   
                //    this.lblVersion.Text = String.Format(this.lblVersion.Text, ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString(4));
                //}


                Painter.PaintMDI(this);

                #region UnUsed
                //MdiClient ctlMDI;
                //foreach (Control ctl in this.Controls)
                //{
                //    try
                //    {
                //        if (ctl is MdiClient)
                //        {
                //            // Attempt to cast the control to type MdiClient.
                //            ctlMDI = (MdiClient)ctl;

                //            // Set the BackColor of the MdiClient control.
                //            ctlMDI.BackColor = this.BackColor;
                //        }
                //    }
                //    catch (InvalidCastException exc)
                //    {
                //        // Catch and ignore the error if casting failed.
                //    }
                //} 
                #endregion


                ToolStripManager.Renderer = new Office2007Renderer();
                GetCompanyName();
                this.Text = this.Text + "QTMS-"+GlobalVariables.City+" Version-" + GetVersion() + "  ";
              //  this.Text = this.Text + "QTMS Test-" + GlobalVariables.City + " Version-" + GetVersion() + "  ";
                // Set CompanyName & Address

                // GlobalVariables.companyName = "L'OREAL INDIA Pvt.Ltd.";
                //GlobalVariables.companyAddress = "Gut No. 426,Mahalunge-Ingle.\r\nChakan Talegaon Road Taluka-KHED,\r\nCHAKAN-410 501, Dist-PUNE,MAHARASHTRA"; // "Kairee Systems,\r\n 501 Sanskruti Mantra, Vijay Nagar Colony,\r\n 2056 Sadashiv Peth, Pune,\r\n Maharashtra, India - 411030"; 

                GlobalVariables.companyAddress = GlobalVariables.Address1 + "\r\n" + GlobalVariables.Address2 + "\r\n" + GlobalVariables.Address3;//+CHAKAN-410 501, Dist-PUNE,MAHARASHTRA"; // "Kairee Systems,\r\n 501 Sanskruti Mantra, Vijay Nagar Colony,\r\n 2056 Sadashiv Peth, Pune,\r\n Maharashtra, India - 411030"; 

                //DataSet dsVer = new DataSet();
                //dsVer = UserManagement_Class_Obj.Select_tblSoftwareVersion();
                //if (dsVer.Tables[0].Rows[0]["version"].ToString() !=  ConfigurationSettings.AppSettings.Get("Version").ToString())
                //{
                //    MessageBox.Show("Older Version Exists...! \nPlease upgrade your version..", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    Application.Exit();
                //}

                UserData userData_Obj = new UserData();
                FrmLogin loginF = new FrmLogin();
                bool flag = true;

                string parentFormName = "";
                while (flag)
                {
                    if (DialogResult.OK == loginF.ShowDialog())
                    {
                        DataSet ds = new DataSet();
                        UserManagement_Class_Obj.Login = loginF.Login;
                        UserManagement_Class_Obj.Password = loginF.PassWard;
                        ds = UserManagement_Class_Obj.Select_User();

                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            LoginID = Convert.ToInt32(ds.Tables[0].Rows[0]["UserID"]);
                            //Following data used for Image compare software
                            GlobalVariables.uid = LoginID;
                            GlobalVariables.uname = UserManagement_Class_Obj.Login;
                            GlobalVariables.pwd = EncryptString(UserManagement_Class_Obj.Password, "kairee");


                            //UserType = Convert.ToString(ds.Tables[0].Rows[0]["UserType"]).Trim();
                            UserTypeID = Convert.ToInt32(ds.Tables[0].Rows[0]["UserTypeID"]);
                            GlobalVariables.utypeid = UserTypeID;
                            btnLogin.Text = ds.Tables[0].Rows[0]["UserName"].ToString().Trim();
                            if (Convert.ToInt32(ds.Tables[0].Rows[0]["UserTypeID"].ToString()) == UserTypeID)
                            {
                                DataTable Dt = new DataTable();
                                userData_Obj.userid = Convert.ToInt32(ds.Tables[0].Rows[0]["UserID"]);

                                Dt = userData_Obj.ShowUserWiseFormPermission();
                                if (Dt.Rows.Count > 0)
                                {
                                    DissableAllForms();//First Dissable All Form Names in menu strip  

                                    foreach (DataRow dr in Dt.Rows)
                                    {
                                        DataTable dtForm = new DataTable();
                                        userData_Obj.formid = Convert.ToInt32(dr["ParentID"]);
                                        dtForm = userData_Obj.ShowFormNameByParentID();
                                        if (dtForm.Rows.Count > 0)
                                        {
                                            parentFormName = dtForm.Rows[0]["FormName"].ToString();
                                        }
                                        if (parentFormName.Contains("Scoop"))
                                        {

                                        }
                                        //EnableMenu(dr["FormName"].ToString());
                                        EnableMenu(dr["FormName"].ToString(), parentFormName);//assign userwise form permission
                                    }
                                    flag = false;


                                    //if (GlobalVariables.City != "BADDI")
                                    //{
                                    //    btnLineValidation.Visible = false;
                                    //    btnMettler.Visible = false;
                                    //}
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid Username and Password");
                            //this.Close();                            
                            flag = true;
                        }
                        #region Old Code
                        //if (ds.Tables[0].Rows.Count > 0)
                        //{
                        //    flag = false;


                        //    if (ds.Tables[0].Rows[0]["UserType"].ToString() == "A")
                        //    {
                        //        //Manage permissions
                        //        menuStripADMINH.Enabled = true;

                        //        //QTMS
                        //        menuStripQTMSH.Enabled = true;

                        //        //RM
                        //        menuStripRMH.Enabled = true;

                        //        //PM
                        //        menuStripPMH.Enabled = true;

                        //        //FDA
                        //        menuStripFDAH.Enabled = true;

                        //        //other
                        //        menuStripOther.Enabled = true;
                        //    }
                        //    else if (ds.Tables[0].Rows[0]["UserType"].ToString() == "M")
                        //    {
                        //        //Manage permissions
                        //        menuStripADMINH.Enabled = false;

                        //        //QTMS
                        //        menuStripQTMSH.Enabled = true;

                        //        //RM
                        //        menuStripRMH.Enabled = true;

                        //        //PM
                        //        menuStripPMH.Enabled = true;

                        //        //FDA
                        //        menuStripFDAH.Enabled = true;

                        //        //other
                        //        menuStripOther.Enabled = true;
                        //    }
                        //    else if (ds.Tables[0].Rows[0]["UserType"].ToString() == "U")
                        //    {
                        //        //Manage permissions
                        //        menuStripADMINH.Enabled = false;

                        //        //QTMS
                        //        menuStripQTMSH.Enabled = true;
                        //        QTMSHmasterToolStripMenuItem.Enabled = false;

                        //        //RM
                        //        menuStripRMH.Enabled = true;
                        //        rMHMasterToolStripMenuItem.Enabled = false;

                        //        //PM
                        //        menuStripPMH.Enabled = true;
                        //        pMHMasterToolStripMenuItem.Enabled = false;

                        //        //FDA
                        //        menuStripFDAH.Enabled = true;
                        //        fDAHmasterToolStripMenuItem.Enabled = false;

                        //        //other
                        //        menuStripOther.Enabled = true;
                        //        OthermasterToolStripMenuItem.Enabled = false;
                        //    }
                        //    else if (ds.Tables[0].Rows[0]["UserType"].ToString() == "N")
                        //    {
                        //        //Manage permissions
                        //        menuStripADMINH.Enabled = false;

                        //        //QTMS
                        //        menuStripQTMSH.Enabled = true;
                        //        QTMSHmasterToolStripMenuItem.Enabled = false;
                        //        QTMSHmodificationToolStripMenuItem.Enabled = false;

                        //        //RM
                        //        menuStripRMH.Enabled = true;
                        //        rMHMasterToolStripMenuItem.Enabled = false;
                        //        RMHmodificationToolStripMenuItem.Enabled = false;

                        //        //PM
                        //        menuStripPMH.Enabled = true;
                        //        pMHMasterToolStripMenuItem.Enabled = false;
                        //        PMHmodificationToolStripMenuItem.Enabled = false;

                        //        //FDA
                        //        menuStripFDAH.Enabled = true;
                        //        fDAHmasterToolStripMenuItem.Enabled = false;
                        //        FDAHmodificationToolStripMenuItem.Enabled = false;

                        //        //other
                        //        menuStripOther.Enabled = true;
                        //        OthermasterToolStripMenuItem.Enabled = false;

                        //    }

                        //}
                        #endregion
                    }
                    else
                    {
                        //break;
                        Application.Exit();
                    }
                }

                AppSettingsReader reader = new AppSettingsReader();
                //GlobalVariables.CurrentFolder = string.Format("{0:yyyy}", System.DateTime.Now);
                #region FTP Details initializaton
                GlobalVariables.FTPHost = reader.GetValue("FTPHost", Type.GetType("System.String")).ToString();
                GlobalVariables.FTPPort = Convert.ToInt32(reader.GetValue("FTPPort", Type.GetType("System.String")));
                GlobalVariables.FTPUsername = reader.GetValue("FTPUsername", Type.GetType("System.String")).ToString();
                GlobalVariables.FTPPassword = reader.GetValue("FTPPassword", Type.GetType("System.String")).ToString();
                GlobalVariables.FTPDirectory = reader.GetValue("FTPDirectory", Type.GetType("System.String")).ToString();
                #endregion

                //MakeDir(GlobalVariables.CurrentFolder);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Application.Exit();
            }
        }

        private void MakeDir(string dirName)
        {
            FtpWebResponse response = null;
            Stream ftpStream = null;
            try
            {
                FtpWebRequest reqFTP;
                string[] Files = GetFileList();
                ArrayList arrDirectories = new ArrayList();
                if (Files != null)
                {
                    foreach (string dir in Files)
                    {
                        arrDirectories.Add(dir);
                    }
                }
                if (!arrDirectories.Contains(dirName))
                {
                    // dirName = name of the directory to create.
                    reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + GlobalVariables.FTPHost + "/" + GlobalVariables.FTPDirectory + "/" + dirName));
                    reqFTP.Method = WebRequestMethods.Ftp.MakeDirectory;
                    reqFTP.UseBinary = true;
                    reqFTP.KeepAlive = false;
                    reqFTP.Proxy = null;
                    reqFTP.Credentials = new NetworkCredential(GlobalVariables.FTPUsername, GlobalVariables.FTPPassword);
                    response = (FtpWebResponse)reqFTP.GetResponse();
                    ftpStream = response.GetResponseStream();
                }
            }
            catch (Exception ex)
            {
                if (ftpStream != null)
                {
                    ftpStream.Close();
                }
                if (response != null)
                {
                    response.Close();
                }
            }
        }

        public string[] GetFileList()
        {
            string[] downloadFiles;
            StringBuilder result = new StringBuilder();
            WebResponse response = null;
            StreamReader reader = null;
            try
            {
                FtpWebRequest reqFTP;
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + GlobalVariables.FTPHost + "/" + GlobalVariables.FTPDirectory + "/"));
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(GlobalVariables.FTPUsername, GlobalVariables.FTPPassword);
                reqFTP.Method = WebRequestMethods.Ftp.ListDirectory;
                reqFTP.Proxy = null;
                reqFTP.KeepAlive = false;
                reqFTP.UsePassive = false;
                response = reqFTP.GetResponse();
                reader = new StreamReader(response.GetResponseStream());
                string line = reader.ReadLine();
                while (line != null)
                {
                    result.Append(line);
                    result.Append("\n");
                    line = reader.ReadLine();
                }
                // to remove the trailing '\n'
                result.Remove(result.ToString().LastIndexOf('\n'), 1);
                return result.ToString().Split('\n');
            }
            catch (Exception ex)
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (response != null)
                {
                    response.Close();
                }
                downloadFiles = null;
                return downloadFiles;
            }
        }
        // Using key for Encryption

        public static string EncryptString(string strText, string key)
        {
            try
            {
                byte[] buffer = new MD5CryptoServiceProvider().ComputeHash(Encoding.ASCII.GetBytes(key));
                TripleDESCryptoServiceProvider provider = new TripleDESCryptoServiceProvider();
                provider.Key = buffer;
                provider.Mode = CipherMode.ECB;
                byte[] bytes = Encoding.ASCII.GetBytes(strText);
                string str = Convert.ToBase64String(provider.CreateEncryptor().TransformFinalBlock(bytes, 0, bytes.Length));
                provider = null;
                return str;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // Using key for decryption
        public static string DecryptString(string strText, string key)
        {
            try
            {
                byte[] buffer = new MD5CryptoServiceProvider().ComputeHash(Encoding.ASCII.GetBytes(key));
                TripleDESCryptoServiceProvider provider = new TripleDESCryptoServiceProvider();
                provider.Key = buffer;
                provider.Mode = CipherMode.ECB;
                byte[] inputBuffer = Convert.FromBase64String(strText);
                return Encoding.ASCII.GetString(provider.CreateDecryptor().TransformFinalBlock(inputBuffer, 0, inputBuffer.Length));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void EnableMenu(string mnuName, string mnuParentFormName)//assign userwise form permission
        {
            switch (mnuParentFormName)
            {
                case "FG":
                    #region FG Enable Form List
                    //Master
                    switch (mnuName)
                    {
                        case "Physico-Chemical Test Master":
                            testMasterToolStripMenuItem.Visible = true;
                            break;

                        case "Packing Test Master":
                            packingTestMasterToolStripMenuItem.Visible = true;
                            break;

                        case "Bulk Technical Family Master":
                            bulkTechnicalFamilyMasterToolStripMenuItem1.Visible = true;
                            break;

                        case "Packing Family Master":
                            packingFamilyMasterToolStripMenuItem.Visible = true;
                            break;

                        case "FG Global Family Master":
                            fGGlobalFamilyMasterToolStripMenuItem1.Visible = true;
                            break;

                        case "Formula Master":
                            formulaMasterToolStripMenuItem.Visible = true;
                            break;

                        case "Line Master":
                            lineMasterToolStripMenuItem.Visible = true;
                            break;

                        case "Tank Master":
                            tankMasterToolStripMenuItem.Visible = true;
                            break;

                        case "Vessel Master":
                            vesselMasterToolStripMenuItem.Visible = true;
                            break;

                        case "Preservative Master":
                            preservativeMasterToolStripMenuItem1.Visible = true;
                            break;

                        case "Preservative Method Master":
                            preservativeMethodMasterToolStripMenuItem1.Visible = true;
                            break;

                        case "Finish Good Master":
                            finishGoodMasterToolStripMenuItem.Visible = true;
                            break;

                        case "FG Family Method Master":
                            //fGFamilyMethodMasterToolStripMenuItem.Visible = true;
                            break;

                        case "Finish Good Method Master":
                            finishGoodMethodMasterToolStripMenuItem.Visible = true;
                            break;

                        case "FG Physico-Chemical Test Method Master":
                            fGPhysicoChemicalTestMethodMasterToolStripMenuItem.Visible = true;
                            break;
                        case "HPLC Reference Mgmt":
                            hPLCReferenceMgmtToolStripMenuItem.Visible = true;
                            break;
                        case "FG Reference Management":
                            fGReferenceManagementToolStripMenuItem1.Visible = true;
                            break;
                        case "FG Out Source":
                            fGOutSourceToolStripMenuItem.Visible = true;
                            break;

                        default:

                            break;
                    }


                    //Transaction
                    switch (mnuName)
                    {
                        case "Adjustment Transaction":
                            adjustmentTransactionToolStripMenuItem.Visible = true;
                            break;

                        case "Bulk Test Details":
                            bulkTestDetailsToolStripMenuItem.Visible = true;
                            break;

                        case "Line Sample Packing Details":
                            lineSamplePackingDetailsToolStripMenuItem.Visible = true;
                            break;

                        case "Line Sample Details":
                            lineSampleDetailsToolStripMenuItem.Visible = true;
                            break;

                        case "Preservative Test":
                            preservativeTestToolStripMenuItem.Visible = true;
                            break;

                        case "Microbiology Test":
                            microbiologyTestToolStripMenuItem.Visible = true;
                            break;

                        case "Kit Details":
                            kitDetailsToolStripMenuItem2.Visible = true;
                            break;

                        case "SF Details":
                            sFDetailsToolStripMenuItem.Visible = true;
                            break;

                        case "Finished Good Test":
                            finishedGoodTestToolStripMenuItem.Visible = true;
                            break;

                        case "Finished Good Treatment":
                            finishedGoodTreatmentToolStripMenuItem.Visible = true;
                            break;

                        case "Finished Good Test SF Packing":
                            finishedGoodTestSFPackingToolStripMenuItem.Visible = true;
                            break;

                        case "FG Release Dossier":
                            fGReleaseDossierToolStripMenuItem.Visible = true;
                            break;
                        case "AOC Sheet":
                            aOCSheetToolStripMenuItem.Visible = true;
                            break;
                        case "Tank Selection":
                            tankSelectionToolStripMenuItem.Visible = true;
                            break;

                        case "Stability Test":
                            stabilityTestToolStripMenuItem.Visible = true;
                            break;

                        case "Stability Test Configuration":
                            stabilityTestConfigurationToolStripMenuItem.Visible = true;
                            break;

                        case "Ageing Test":
                            ageingTestToolStripMenuItem.Visible = true;
                            break;

                        default:
                            break;
                    }



                    //Modification
                    switch (mnuName)
                    {
                        case "Bulk Test Details":
                            bulkTestDetailsToolStripMenuItem1.Visible = true;
                            break;

                        case "Line Sample Packing":
                            lineSamplePackingToolStripMenuItem.Visible = true;
                            break;

                        case "Line Sample Details":
                            lineSampleDetailsToolStripMenuItem1.Visible = true;
                            break;

                        case "Preservative Test":
                            preservativeTestToolStripMenuItem1.Visible = true;
                            break;

                        case "Microbiology Test":
                            microbiologyTestToolStripMenuItem1.Visible = true;
                            break;

                        case "Kit Details":
                            kitDetailsToolStripMenuItem3.Visible = true;
                            break;

                        case "Finished Good Test":
                            finishedGoodTestToolStripMenuItem2.Visible = true;
                            break;
                        default:
                            break;
                    }


                    //Master Reports
                    switch (mnuName)
                    {
                        case "Formula History Report":
                            formulaHistoryReportToolStripMenuItem.Visible = true;
                            break;

                        case "FG Formula History Report":
                            fGFormulaHistoryReportToolStripMenuItem.Visible = true;
                            break;

                        case "Formula Description Report":
                            formulaDescriptionReportToolStripMenuItem.Visible = true;
                            break;

                        case "Bulk Test Report":
                            bulkTestReportToolStripMenuItem1.Visible = true;
                            break;

                        case "Test Method Master Report":
                            testMethodMasterReportToolStripMenuItem1.Visible = true;
                            break;

                        case "FG Test Method Master Report":
                            fGTestMethodMasterReportToolStripMenuItem2.Visible = true;
                            break;

                        case "FG Out Source Report":
                            fGOutSourceReportToolStripMenuItem.Visible = true;
                            break;

                        default:
                            break;
                    }



                    //Detail Report
                    switch (mnuName)
                    {
                        case "Bulk Analysis Report":
                            bulkAnalysisReportToolStripMenuItem1.Visible = true;
                            break;

                        case "Bulk Transaction Report":
                            bulkTransactionReportToolStripMenuItem1.Visible = true;
                            break;

                        case "Line Sample Details Report":
                            lineSampleDetailsReportToolStripMenuItem.Visible = true;
                            break;

                        case "Preservative Test Report":
                            preservativeTestReportToolStripMenuItem.Visible = true;
                            break;

                        case "Microbiology Test Report":
                            microbiologyTestReportToolStripMenuItem.Visible = true;
                            break;

                        case "FG Analysis Report":
                            fGAnalysisReportToolStripMenuItem1.Visible = true;
                            break;

                        case "FG Analysis BMR Report":
                            fGAnalysisBMRReportToolStripMenuItem.Visible = true;
                            break;
                        case "FG Pending Report":
                            fGPendingReportToolStripMenuItem.Visible = true;
                            break;
                        case "FG Bulk Rejection Details Report":
                            fGBulkRejectionDetailsReportToolStripMenuItem.Visible = true;
                            break;
                        default:
                            break;
                    }


                    //Summary Report
                    switch (mnuName)
                    {
                        case "Bulk Test Details Report":
                            bulkTestDetailsReportToolStripMenuItem.Visible = true;
                            break;

                        case "Bulk Test Non BPC Report":
                            bulkTestNonBPCReportToolStripMenuItem.Visible = true;
                            break;

                        case "Bulk Test New Launch Report":
                            bulkTestNewLaunchReportToolStripMenuItem.Visible = true;
                            break;

                        case "Bulk Test Non Validated Report":
                            bulkTestNonValidatedReportToolStripMenuItem.Visible = true;
                            break;

                        case "BMR Pre-Summary Report":
                            bMRPreSummaryReportToolStripMenuItem.Visible = true;
                            break;

                        case "BMR Summary Report":
                            bMRSummaryReportToolStripMenuItem.Visible = true;
                            break;

                        case "Bulk Pending Report":
                            bulkPendingReportToolStripMenuItem.Visible = true;
                            break;

                        case "Line Packing Details Report":
                            linePackingDetailsReportToolStripMenuItem.Visible = true;
                            break;

                        case "Line Sample Summary Report":
                            lineSampleSummaryReportToolStripMenuItem.Visible = true;
                            break;

                        case "Preservative Summary Report":
                            preservativeSummaryReportToolStripMenuItem.Visible = true;
                            break;

                        case "Microbiology Summary Report":
                            microbiologySummaryReportToolStripMenuItem.Visible = true;
                            break;

                        case "Finished Good Transaction Report":
                            finishedGoodTransactionReportToolStripMenuItem.Visible = true;
                            break;

                        case "Finished Good Summary Report":
                            finishedGoodSummaryReportToolStripMenuItem1.Visible = true;
                            break;

                        case "Finished Good Non BPC Report":
                            finishedGoodNonBPCReportToolStripMenuItem.Visible = true;
                            break;

                        case "FG Bulk Pending Report":
                            fGBulkPendingReportToolStripMenuItem.Visible = true;
                            break;

                        case "QStatus Summary Report":
                            qStatusSummaryReportToolStripMenuItem.Visible = true;
                            break;

                        case "Lot Dossier Summary Report":
                            lotDossierSummaryReportToolStripMenuItem.Visible = true;
                            break;

                        case "FG Report":
                            fGReportToolStripMenuItem.Visible = true;
                            break;

                        case "FG Rejection Note":
                            rejectionNoteFGToolStripMenuItem.Visible = true;
                            break;

                        case "Analysis Summary Report":
                            analysisSummaryReportToolStripMenuItem.Visible = true;
                            break;

                        case "FG Release Dossier":
                            fGReleaseDossierToolStripMenuItem1.Visible = true;
                            break;

                        case "FG Reference Mgmt Summary Report":
                            fGRefToolStripMenuItem.Visible = true;
                            break;

                        default:
                            break;
                    }


                    //TDB
                    switch (mnuName)
                    {
                        case "Bulk TDB Report":
                            bulkTDBReportToolStripMenuItem.Visible = true;
                            break;

                        case "Microbiology TDB Report":
                            microbiologyTDBReportToolStripMenuItem.Visible = true;
                            break;

                        case "Global FG TDB Report":
                            globalFGTDBReportToolStripMenuItem1.Visible = true;
                            break;

                        case "FG Line Details TDB Report":
                            fGLineDetailsTDBReportToolStripMenuItem.Visible = true;
                            break;

                        case "Filling and Packing Quality Report":
                            fillingAndPackingQualityReportToolStripMenuItem1.Visible = true;
                            break;
                        default:
                            break;
                    }


                    //Dossier
                    switch (mnuName)
                    {
                        case "Pre Lot Dossier Report":
                            preLotDossierReportToolStripMenuItem.Visible = true;
                            break;

                        case "Lot Dossier Report":
                            lotDossierReportToolStripMenuItem.Visible = true;
                            break;

                        case "Lot Dossier Detail Report":
                            lotDossierDetailReportToolStripMenuItem1.Visible = true;
                            break;

                        case "BMR Lot Dossier Report":
                            bMRLotDossierReportToolStripMenuItem.Visible = true;
                            break;
                        default:
                            break;
                    }



                    #endregion

                    break;
                case "RM":
                    #region RM Enable Form List
                    //Master
                    switch (mnuName)
                    {
                        case "RM Supplier Master":
                            rMSupplierMasterToolStripMenuItem1.Visible = true;
                            break;

                        case "RM Family Master":
                            rMFamilyMasterToolStripMenuItem1.Visible = true;
                            break;
                        case "RM Parameter Master":
                            rMParameterMasterToolStripMenuItem1.Visible = true;
                            break;

                        case "RM Parameter Description Master":
                            rMParameterDescriptionMasterToolStripMenuItem.Visible = true;
                            break;

                        case "RM Code Master":
                            rMCodeMasterToolStripMenuItem1.Visible = true;
                            break;

                        case "RM Code Test Method Master":
                            rMCodeTestMethodMasterToolStripMenuItem1.Visible = true;
                            break;

                        case "RM Code Retainer Label":
                            rMCodeRetainerLabelToolStripMenuItem.Visible = true;
                            break;
                        case "RM Safety Symbol Master":
                            rMSafetySymbolMasterToolStripMenuItem.Visible = true;
                            break;
                        case "RM Retainer Location Master":
                            rMRetainerLocationMasterToolStripMenuItem.Visible = true;
                            break;
                        default:
                            break;

                    }



                    //Transaction
                    switch (mnuName)
                    {
                        case "RM Sampling":
                            rMSamplingToolStripMenuItem1.Visible = true;
                            break;

                        case "RM Transaction":
                            rMTransactionToolStripMenuItem1.Visible = true;
                            break;

                        case "RM Status Change":
                            rMStatusChangeToolStripMenuItem1.Visible = true;
                            break;

                        case "RM Validity Report":
                            rMValidityReportToolStripMenuItem1.Visible = true;
                            break;
                        case "RM Microbiology Test":
                            rMMicrobiologyTestToolStripMenuItem.Visible = true;
                            break;
                        default:
                            break;
                    }

                    //Modification
                    switch (mnuName)
                    {
                        case "RM Microbiology Test Modification":
                            rMMicrobiologyTestModificationToolStripMenuItem.Visible = true;
                            break;
                        default:
                            break;
                    }
                    //Reports
                    switch (mnuName)
                    {
                        case "RM Code History Report":
                            rMCodeHistoryReportToolStripMenuItem.Visible = true;
                            break;

                        case "RM Test Method Master Report":
                            rMTestMethodMasterReportToolStripMenuItem1.Visible = true;
                            break;

                        case "RM Transaction Report":
                            rMTransactionReportToolStripMenuItem1.Visible = true;
                            break;

                        case "RM Supllier Report Received Report":
                            rMSupllierReportReceivedReportToolStripMenuItem.Visible = true;
                            break;

                        case "RM Family TDB Report":
                            rMTDBReportToolStripMenuItem1.Visible = true;
                            break;

                        case "RM Supplier TDB Report":
                            rMSupplierTDBReportToolStripMenuItem.Visible = true;
                            break;

                        case "Pending RM Report":
                            pendingRMReportToolStripMenuItem.Visible = true;
                            break;

                        case "RM Analysis Report":
                            rMAnalysisReportToolStripMenuItem1.Visible = true;
                            break;

                        case "RM Validity Analysis Report":
                            rMValidityAnalysisReportToolStripMenuItem1.Visible = true;
                            break;
                        case "RM MicrobiologyTest_Report":
                            rMMicrobiologyTestReportToolStripMenuItem.Visible = true;
                            break;
                        case "RM RetainerLocation Report":
                            rMRetainerLocationReportToolStripMenuItem.Visible = true;
                            break;
                        case "RM Parameterwise Report":
                            rMParameterwiseReportToolStripMenuItem.Visible = true;
                            break;
                        case "RM Control Type Report":
                            rMControlTypeReportToolStripMenuItem.Visible = true;
                            break;
                        case "RM Code Report":
                            rMCodeReportToolStripMenuItem.Visible = true;
                            break;
                        case "RM Alignment Report":
                            rMAlignmentReportToolStripMenuItem.Visible = true;
                            break;
                        default:
                            break;
                    }


                    #endregion

                    break;
                case "PM":
                    #region PM Enable Form List
                    //Master
                    switch (mnuName)
                    {
                        case "PM Supplier Master":
                            pMSupplierMasterToolStripMenuItem.Visible = true;
                            break;
                        case "PM Family Master":
                            pMFamilyMasterToolStripMenuItem.Visible = true;
                            break;
                        case "PM Code Master":
                            pMCodeMasterToolStripMenuItem.Visible = true;
                            break;
                        case "PM Test Master":
                            pMTestMasterToolStripMenuItem1.Visible = true;
                            break;
                        case "PM Test Method Master":
                            pMTestMethodMasterToolStripMenuItem1.Visible = true;
                            break;
                        case "BAG Upload":
                            bAGManagementToolStripMenuItem.Visible = true;
                            break;
                        default:
                            break;

                    }


                    //Transaction
                    switch (mnuName)
                    {
                        case "PM Transaction":
                            pMTransactionToolStripMenuItem2.Visible = true;
                            break;
                        case "PM Status Change":
                            // pMStatusChangeToolStripMenuItem.Visible = true;
                            break;
                        case "PM Defect Note":
                            pMDefectNoteToolStripMenuItem.Visible = true;
                            break;
                        case "PM Treatment":
                            //pMTreatmentToolStripMenuItem.Visible = true;
                            break;
                        case "PM Reanalysis":
                            pMReanalysisToolStripMenuItem.Visible = true;
                            break;
                        case "PM Supplier Corrective Note":
                            pMSupplierCorrectiveNoteToolStripMenuItem.Visible = true;
                            break;
                        case "BAG Viewer":
                            bagViewertoolStrip.Visible = true;
                            break;
                        default:
                            break;
                    }


                    //Modification
                    switch (mnuName)
                    {
                        case "PM Modification":
                            pMModificationToolStripMenuItem.Visible = true;
                            break;
                        default:
                            break;

                    }



                    //Reports
                    switch (mnuName)
                    {
                        case "PM Code Description Report":
                            pMCodeDescriptionReportToolStripMenuItem.Visible = true;
                            break;
                        case "PM Test Method Master Report":
                            pMTestMethodMasterReportToolStripMenuItem.Visible = true;
                            break;
                        case "PM Transaction Report":
                            pMTransactionReportToolStripMenuItem.Visible = true;
                            break;
                        case "PM New Launch Report":
                            pMNewLaunchReportToolStripMenuItem.Visible = true;
                            break;
                        case "PM Supplier Report Received Report":
                            pMSupplierReportReceivedReportToolStripMenuItem.Visible = true;
                            break;
                        case "PM Defect Note Detail Report":
                            pMDefectNoteDetailReportToolStripMenuItem.Visible = true;
                            break;
                        case "PM Rejection Detail Report":
                            pMRejectionDetailReportToolStripMenuItem1.Visible = true;
                            break;
                        case "PM TDB Report":
                            pMTDBReportToolStripMenuItem1.Visible = true;
                            break;
                        case "PM Supplier TDB Report":
                            pMSupplierTDBReportToolStripMenuItem1.Visible = true;
                            break;
                        case "PM Family TDB Report":
                            pMFamilyTDBReportToolStripMenuItem1.Visible = true;
                            break;
                        case "PM Analysis":
                            pMAnalysisToolStripMenuItem1.Visible = true;
                            break;
                        case "PM COC List":
                            pMCOCListToolStripMenuItem1.Visible = true;
                            break;
                        case "PM COC Transaction Report":
                            pMCOCTransactionReportToolStripMenuItem.Visible = true;
                            break;
                        case "PM Defect Note":
                            pMDefectNoteToolStripMenuItem1.Visible = true;
                            break;
                        case "PM Rejection Note":
                            pMRejectionNoteToolStripMenuItem.Visible = true;
                            break;
                        case "PM COC History Report":
                            pMCOCHistoryReportToolStripMenuItem.Visible = true;
                            break;
                        case "PM Component History Report":
                            pMComponentHistoryReportToolStripMenuItem.Visible = true;
                            break;
                        default:
                            break;
                    }


                    #endregion

                    break;
                case "FDA":
                    #region FDA Enable Form List
                    //Master
                    switch (mnuName)
                    {
                        case "FDA Master":
                            fDAMasterToolStripMenuItem.Visible = true;
                            break;
                        default:
                            break;
                    }


                    //Transaction
                    switch (mnuName)
                    {
                        case "FDA Transaction":
                            fDATransactionToolStripMenuItem.Visible = true;
                            break;
                        default:
                            break;
                    }
                    //Modification
                    switch (mnuName)
                    {
                        case "FDA Modification":
                            fDAModificationToolStripMenuItem.Visible = true;
                            break;
                        default:
                            break;
                    }

                    //Reports
                    switch (mnuName)
                    {
                        case "Oxidation Hair Dye":
                            oxidationHairDyeToolStripMenuItem.Visible = true;
                            break;
                        default:
                            break;
                    }


                    #endregion

                    break;
                case "OTHER":
                    #region OTHERS Enable Form List
                    //Master 
                    switch (mnuName)
                    {
                        case "Retainer Location Master":
                            retainerLocationMasterToolStripMenuItem1.Visible = true;
                            break;
                        case "Instrument Master":
                            instrumentMasterToolStripMenuItem1.Visible = true;
                            break;
                        case "Country Master":
                            countryMasterToolStripMenuItem.Visible = true;
                            break;
                        case "Reference Location Master":
                            locationMasterToolStripMenuItem.Visible = true;
                            break;
                        case "MOM Master":
                            mOMMasterToolStripMenuItem.Visible = true;
                            break;
                        case "Annex Tank Master":
                            AnnextureTankMaster.Visible = true;
                            break;
                        case "Quality Issue Master":
                            QualityIssueMaster.Visible = true;
                            break;
                        case "Document Master":
                            DocumentMaster.Visible = true;
                            break;
                        case "Agitation Master":
                            AgitationMaster.Visible = true;
                            break;
                        case "Nature of AC Ref Master":
                            nAtureofACRefMasterToolStripMenuItem.Visible = true;
                            break;
                        case "AC Material Ref Master":
                            aCMaterialRefMasterToolStripMenuItem.Visible = true;
                            break;
                        default:
                            break;
                    }

                    //Transaction
                    switch (mnuName)
                    {
                        case "Consumer Complaint":
                            consumerComplaintToolStripMenuItem.Visible = true;
                            break;
                        case "Water Analysis":
                            waterAnalysisToolStripMenuItem1.Visible = true;
                            break;
                        case "Compatibility":
                            compatibilityToolStripMenuItem1.Visible = true;
                            break;
                        case "Reference Sample Management":
                            referenceSampleManageToolStripMenuItem.Visible = true;
                            break;
                        case "Reference Sample Management (RM)":
                            referenceSampleManagementRMToolStripMenuItem.Visible = true;
                            break;
                        case "Plantwise water analysis":
                            plantwiseWaterAnalysisToolStripMenuItem.Visible = true;
                            break;
                        default:
                            break;
                    }

                    //OEE
                    switch (mnuName)
                    {
                        case "OEE Activity Master":
                            oEEActivityMasterToolStripMenuItem.Visible = true;
                            break;
                        case "OEE Activity Relation Master":
                            activityRelationMasterToolStripMenuItem.Visible = true;
                            break;
                        case "OEE Transactions":
                            oEETransactionsToolStripMenuItem.Visible = true;
                            break;
                        case "OEE TMT Master":
                            oEETMTMasterToolStripMenuItem.Visible = true;
                            break;
                        case "OEE Modification":
                            //oEEModificationToolStripMenuItem.Visible = true;
                            break;

                        default:
                            break;

                    }
                    // Line OEE
                    switch (mnuName)
                    {
                        case "Line OEE Transation":
                            autoLineOEETransationToolStripMenuItem.Visible = true;
                            break;
                        case "Line OEE FG Master":
                            lineOEEFGMasterToolStripMenuItem.Visible = true;
                            break;
                        case "Line OEE Master":
                            lineOEEActivityMasterToolStripMenuItem.Visible = true;
                            break;
                        case "Line OEE Activity Relation Master":
                            lineOEEActivityRelationMasterToolStripMenuItem.Visible = true;
                            break;
                        case "Upload Line OEE Master":
                            uploadLineOEEMasterToolStripMenuItem.Visible = true;
                            break;
                        case "Line OEE Data Junction Report":
                            lineOEEDataJunctionReportToolStripMenuItem.Visible = true;
                            break;
                        case "View Upload Line OEE Master":
                            viewUploadLineOEEMasterToolStripMenuItem.Visible = true;
                            break;
                        case "Line OEE Report":
                            lineOEEUPTdbReportToolStripMenuItem.Visible = true;
                            break;
                        case "Line OEE Graph Report":
                            lineOEEGraphReportToolStripMenuItem.Visible = true;
                            break;

                        default:
                            break;
                    }

                    //Image Comparison
                    switch (mnuName)
                    {
                        case "Image Comparison":
                            imageComparisonToolStripMenuItem.Visible = true;
                            break;
                        default:
                            break;
                    }

                    //Reagent Management
                    switch (mnuName)
                    {
                        case "Reagent Master":
                            reagentMasterToolStripMenuItem.Visible = true;
                            break;
                        case "Reagent Transaction":
                            reagentTransactionToolStripMenuItem.Visible = true;
                            break;
                        case "Reagent Standardization":
                            reaToolStripMenuItem.Visible = true;
                            break;
                        case "Reagent Consumption":
                            reagentConsumptionToolStripMenuItem.Visible = true;
                            break;
                        case "Reagent Modification":
                            reagentModificationToolStripMenuItem.Visible = true;
                            break;
                        case "Reagent Available Stock Report":
                            reagentAvailableStockReportToolStripMenuItem.Visible = true;
                            break;
                        case "Reagent Details Report":
                            reagentDetailsReportToolStripMenuItem.Visible = true;
                            break;
                        case "Reagent Reorder Level Report":
                            reagentReorderLevelReportToolStripMenuItem.Visible = true;
                            break;

                        default:
                            break;
                    }

                    //Reports
                    switch (mnuName)
                    {
                        case "Consumer Complaint Summary Report":
                            consumerComplaintSummaryReportToolStripMenuItem.Visible = true;
                            break;
                        case "Consumer Complaint Analysis Report":
                            consumerComplaintAnalysisReportToolStripMenuItem1.Visible = true;
                            break;
                        case "Consumer Complaint TDB Report":
                            consumerComplaintTDBReportToolStripMenuItem1.Visible = true;
                            break;
                        case "Water Analysis Report":
                            waterAnalysisReportToolStripMenuItem1.Visible = true;
                            break;
                        case "Monthly Water Analysis Report":
                            monthlyWaterAnalysisReportToolStripMenuItem.Visible = true;
                            break;
                        case "OEE Analysis Report":
                            oEEAnalysisReportToolStripMenuItem.Visible = true;
                            break;
                        case "MOM Report":
                            mOMReportToolStripMenuItem.Visible = true;
                            break;
                        case "FG Ref Sample Mgmt Detail Report":
                            fGRefSampleMgmtDetailReportToolStripMenuItem.Visible = true;
                            break;
                        case "RM Ref Sample Mgmt Detail Report":
                            rMRefSampleMgmtDetailReportToolStripMenuItem.Visible = true;
                            break;
                        case "OEE Detail Process Report":
                            oEEDetailProcessReportToolStripMenuItem.Visible = true;
                            break;
                        case "Ref Sample Mgmt Summary Report":
                            refSampleMgmtSummaryReportToolStripMenuItem.Visible = true;
                            break;
                        case "Physico Chemical Water Analysis Report":
                            physicoChemicalWaterAToolStripMenuItem.Visible = true;
                            break;
                        case "Last Production Active Formula Report":
                            lastProductionFormulaReportToolStripMenuItem.Visible = true;
                            break;
                        default:
                            break;
                    }


                    #endregion

                    break;
                case "ADMIN":
                    #region ADMIN Enable Form List
                    //Manage Permissions
                    switch (mnuName)
                    {
                        case "User Management":
                            userManagementToolStripMenuItem.Visible = true;
                            break;
                        case "User Permission":
                            userPermissionToolStripMenuItem.Visible = true;
                            break;
                        case "Group Master":
                            groupMasterToolStripMenuItem.Visible = true;
                            break;
                        case "User Group Master Relation":
                            userGroupMasterRelationToolStripMenuItem.Visible = true;
                            break;
                        case "Change Password":
                            changePasswordToolStripMenuItem.Visible = true;
                            break;
                        default:
                            break;
                    }


                    #endregion

                    break;

                case "SCOOP":
                    {
                        #region SCOOP Enable Form
                        // Master
                        switch (mnuName)
                        {
                            case "Line Sampling Point Master":
                                lineSamplingPointMasterToolStripMenuItem.Visible = true;
                                break;
                            case "Scoop Test Method Master":
                                scoopTestMethodMasterToolStripMenuItem.Visible = true;
                                break;
                            case "Line-SamplingPoint Info":
                                lineSamplingPointInfoToolStripMenuItem1.Visible = true;
                                break;
                            default:
                                break;
                        }
                        //Transaction
                        switch (mnuName)
                        {
                            case "Finished good test UP":
                                uPToolStripMenuItem.Visible = true;
                                break;
                            case "UP Authority":
                                uPAuthorityToolStripMenuItem.Visible = true;
                                break;
                            case "Quality Authority":
                                qualityAuthorityToolStripMenuItem.Visible = true;
                                break;
                            //case "Final Approval":
                            //    finalApprovalToolStripMenuItem.Visible = true;
                            //    break;
                            default:
                                break;
                        }
                        //Detail
                        switch (mnuName)
                        {
                            case "FG_Analysis_Report":
                                fGAnalysisReportToolStripMenuItem.Visible = true;
                                break;


                            case "FG_Analysis_NotDoneReport":
                                fGAnalysisNotDoneReportToolStripMenuItem.Visible = true;
                                break;
                            default:
                                break;

                        }

                        #endregion
                    }
                    break;

                case "SubContractor":
                    #region SubContractor Enable Form List
                    //Master Permissions
                    switch (mnuName)
                    {
                        case "FG SubContractor":
                            toolStripMenuItem4.Visible = true;
                            break;

                        default:
                            break;
                    }
                    //Transaction Permissions
                    switch (mnuName)
                    {
                        case "Finished Good Test":
                            toolStripMenuItem12.Visible = true;
                            break;

                        default:
                            break;
                    }
                    //Modification Permissions
                    switch (mnuName)
                    {
                        case "Finished Good Test":
                            finishGoodTestToolStripMenuItem.Visible = true;
                            break;

                        default:
                            break;
                    }
                    //Detail Permissions
                    switch (mnuName)
                    {
                        case "FG Anlysis Report":
                            toolStripMenuItem17.Visible = true;
                            break;

                        default:
                            break;
                    }
                    //TDB Permissions
                    switch (mnuName)
                    {
                        case "Global FG TDB":
                            toolStripMenuItem14.Visible = true;
                            break;

                        default:
                            break;
                    }
                    #endregion
                    break;
                default:
                    break;
            }





        }

        private void DissableAllForms()
        {
            #region FG Disable Form List
            //Master
            testMasterToolStripMenuItem.Visible = false;
            packingTestMasterToolStripMenuItem.Visible = false;
            bulkTechnicalFamilyMasterToolStripMenuItem1.Visible = false;
            packingFamilyMasterToolStripMenuItem.Visible = false;
            fGGlobalFamilyMasterToolStripMenuItem1.Visible = false;
            formulaMasterToolStripMenuItem.Visible = false;
            lineMasterToolStripMenuItem.Visible = false;
            tankMasterToolStripMenuItem.Visible = false;
            vesselMasterToolStripMenuItem.Visible = false;
            preservativeMasterToolStripMenuItem1.Visible = false;
            preservativeMethodMasterToolStripMenuItem1.Visible = false;
            finishGoodMasterToolStripMenuItem.Visible = false;
            fGFamilyMethodMasterToolStripMenuItem.Visible = false;
            finishGoodMethodMasterToolStripMenuItem.Visible = false;
            fGPhysicoChemicalTestMethodMasterToolStripMenuItem.Visible = false;
            fGOutSourceToolStripMenuItem.Visible = false;
            //Transaction
            adjustmentTransactionToolStripMenuItem.Visible = false;
            bulkTestDetailsToolStripMenuItem.Visible = false;
            lineSamplePackingDetailsToolStripMenuItem.Visible = false;
            lineSampleDetailsToolStripMenuItem.Visible = false;
            preservativeTestToolStripMenuItem.Visible = false;
            microbiologyTestToolStripMenuItem.Visible = false;
            kitDetailsToolStripMenuItem2.Visible = false;
            sFDetailsToolStripMenuItem.Visible = false;
            finishedGoodTestToolStripMenuItem.Visible = false;
            finishedGoodTreatmentToolStripMenuItem.Visible = false;
            finishedGoodTestSFPackingToolStripMenuItem.Visible = false;
            fGReleaseDossierToolStripMenuItem.Visible = false;
            hPLCReferenceMgmtToolStripMenuItem.Visible = false;
            fGReferenceManagementToolStripMenuItem1.Visible = false;
            aOCSheetToolStripMenuItem.Visible = false;
            tankSelectionToolStripMenuItem.Visible = false;
            //Modification
            bulkTestDetailsToolStripMenuItem1.Visible = false;
            lineSamplePackingToolStripMenuItem.Visible = false;
            lineSampleDetailsToolStripMenuItem1.Visible = false;
            preservativeTestToolStripMenuItem1.Visible = false;
            microbiologyTestToolStripMenuItem1.Visible = false;
            kitDetailsToolStripMenuItem3.Visible = false;
            finishedGoodTestToolStripMenuItem2.Visible = false;

            //Master Reports
            formulaHistoryReportToolStripMenuItem.Visible = false;
            fGFormulaHistoryReportToolStripMenuItem.Visible = false;
            formulaDescriptionReportToolStripMenuItem.Visible = false;
            bulkTestReportToolStripMenuItem1.Visible = false;
            testMethodMasterReportToolStripMenuItem1.Visible = false;
            fGTestMethodMasterReportToolStripMenuItem2.Visible = false;
            fGOutSourceReportToolStripMenuItem.Visible = false;

            //Detail Report
            bulkAnalysisReportToolStripMenuItem1.Visible = false;
            bulkTransactionReportToolStripMenuItem1.Visible = false;
            lineSampleDetailsReportToolStripMenuItem.Visible = false;
            preservativeTestReportToolStripMenuItem.Visible = false;
            microbiologyTestReportToolStripMenuItem.Visible = false;
            fGAnalysisReportToolStripMenuItem1.Visible = false;
            fGAnalysisBMRReportToolStripMenuItem.Visible = false;
            fGPendingReportToolStripMenuItem.Visible = false;
            fGBulkRejectionDetailsReportToolStripMenuItem.Visible = false;
            //Summary Report
            bulkTestDetailsReportToolStripMenuItem.Visible = false;
            bulkTestNonBPCReportToolStripMenuItem.Visible = false;
            bulkTestNewLaunchReportToolStripMenuItem.Visible = false;
            bulkTestNonValidatedReportToolStripMenuItem.Visible = false;
            bMRPreSummaryReportToolStripMenuItem.Visible = false;
            bMRSummaryReportToolStripMenuItem.Visible = false;
            bulkPendingReportToolStripMenuItem.Visible = false;
            linePackingDetailsReportToolStripMenuItem.Visible = false;
            lineSampleSummaryReportToolStripMenuItem.Visible = false;
            preservativeSummaryReportToolStripMenuItem.Visible = false;
            microbiologySummaryReportToolStripMenuItem.Visible = false;
            finishedGoodTransactionReportToolStripMenuItem.Visible = false;
            finishedGoodSummaryReportToolStripMenuItem1.Visible = false;
            finishedGoodNonBPCReportToolStripMenuItem.Visible = false;
            fGBulkPendingReportToolStripMenuItem.Visible = false;
            qStatusSummaryReportToolStripMenuItem.Visible = false;
            lotDossierSummaryReportToolStripMenuItem.Visible = false;
            fGReportToolStripMenuItem.Visible = false;
            rejectionNoteFGToolStripMenuItem.Visible = false;
            analysisSummaryReportToolStripMenuItem.Visible = false;
            fGReleaseDossierToolStripMenuItem1.Visible = false;
            fGRefToolStripMenuItem.Visible = false;
            //TDB
            bulkTDBReportToolStripMenuItem.Visible = false;
            microbiologyTDBReportToolStripMenuItem.Visible = false;
            globalFGTDBReportToolStripMenuItem1.Visible = false;
            fGLineDetailsTDBReportToolStripMenuItem.Visible = false;
            fillingAndPackingQualityReportToolStripMenuItem1.Visible = false;
            //Dossier
            preLotDossierReportToolStripMenuItem.Visible = false;
            lotDossierReportToolStripMenuItem.Visible = false;
            lotDossierDetailReportToolStripMenuItem1.Visible = false;
            bMRLotDossierReportToolStripMenuItem.Visible = false;

            #endregion

            #region RM Disable Form List
            //Master
            rMSupplierMasterToolStripMenuItem1.Visible = false;
            rMFamilyMasterToolStripMenuItem1.Visible = false;
            rMParameterMasterToolStripMenuItem1.Visible = false;
            rMParameterDescriptionMasterToolStripMenuItem.Visible = false;
            rMCodeMasterToolStripMenuItem1.Visible = false;
            rMCodeTestMethodMasterToolStripMenuItem1.Visible = false;
            rMCodeRetainerLabelToolStripMenuItem.Visible = false;
            rMSafetySymbolMasterToolStripMenuItem.Visible = false;
            rMRetainerLocationMasterToolStripMenuItem.Visible = false;
            //Transaction
            rMSamplingToolStripMenuItem1.Visible = false;
            rMTransactionToolStripMenuItem1.Visible = false;
            rMStatusChangeToolStripMenuItem1.Visible = false;
            rMValidityReportToolStripMenuItem1.Visible = false;
            rMMicrobiologyTestToolStripMenuItem.Visible = false;
            //Modifiction
            rMMicrobiologyTestModificationToolStripMenuItem.Visible = false;
            //Reports
            rMCodeHistoryReportToolStripMenuItem.Visible = false;
            rMTestMethodMasterReportToolStripMenuItem1.Visible = false;
            rMTransactionReportToolStripMenuItem1.Visible = false;
            rMSupllierReportReceivedReportToolStripMenuItem.Visible = false;
            rMTDBReportToolStripMenuItem1.Visible = false;
            rMSupplierTDBReportToolStripMenuItem.Visible = false;
            pendingRMReportToolStripMenuItem.Visible = false;
            rMAnalysisReportToolStripMenuItem1.Visible = false;
            rMValidityAnalysisReportToolStripMenuItem1.Visible = false;
            rMMicrobiologyTestReportToolStripMenuItem.Visible = false;
            rMRetainerLocationReportToolStripMenuItem.Visible = false;
            rMParameterwiseReportToolStripMenuItem.Visible = false;
            rMControlTypeReportToolStripMenuItem.Visible = false;
            rMCodeReportToolStripMenuItem.Visible = false;
            rMAlignmentReportToolStripMenuItem.Visible = false;

            #endregion

            #region PM Disable Form List
            //Master
            pMSupplierMasterToolStripMenuItem.Visible = false;
            pMFamilyMasterToolStripMenuItem.Visible = false;
            pMCodeMasterToolStripMenuItem.Visible = false;
            pMTestMasterToolStripMenuItem1.Visible = false;
            pMTestMethodMasterToolStripMenuItem1.Visible = false;
            bAGManagementToolStripMenuItem.Visible = false;

            //Transaction
            pMTransactionToolStripMenuItem2.Visible = false;
            pMStatusChangeToolStripMenuItem.Visible = false;
            pMDefectNoteToolStripMenuItem.Visible = false;
            pMTreatmentToolStripMenuItem.Visible = false;
            pMReanalysisToolStripMenuItem.Visible = false;
            pMSupplierCorrectiveNoteToolStripMenuItem.Visible = false;
            bagViewertoolStrip.Visible = false;

            //Modification
            pMModificationToolStripMenuItem.Visible = false;

            //Reports
            pMCodeDescriptionReportToolStripMenuItem.Visible = false;
            pMTestMethodMasterReportToolStripMenuItem.Visible = false;
            pMTransactionReportToolStripMenuItem.Visible = false;
            pMNewLaunchReportToolStripMenuItem.Visible = false;
            pMSupplierReportReceivedReportToolStripMenuItem.Visible = false;
            pMDefectNoteDetailReportToolStripMenuItem.Visible = false;
            pMRejectionDetailReportToolStripMenuItem1.Visible = false;
            pMTDBReportToolStripMenuItem1.Visible = false;
            pMSupplierTDBReportToolStripMenuItem1.Visible = false;
            pMFamilyTDBReportToolStripMenuItem1.Visible = false;
            pMAnalysisToolStripMenuItem1.Visible = false;
            pMCOCListToolStripMenuItem1.Visible = false;
            pMCOCTransactionReportToolStripMenuItem.Visible = false;
            pMDefectNoteToolStripMenuItem1.Visible = false;
            pMRejectionNoteToolStripMenuItem.Visible = false;
            pMCOCHistoryReportToolStripMenuItem.Visible = false;
            pMComponentHistoryReportToolStripMenuItem.Visible = false;
            #endregion

            #region FDA Disable Form List
            //Master
            fDAMasterToolStripMenuItem.Visible = false;
            //Transaction
            fDATransactionToolStripMenuItem.Visible = false;
            //Modification
            fDAModificationToolStripMenuItem.Visible = false;
            //Reports
            oxidationHairDyeToolStripMenuItem.Visible = false;
            #endregion

            #region OTHERS Disable Form List
            //Master 
            retainerLocationMasterToolStripMenuItem1.Visible = false;
            instrumentMasterToolStripMenuItem1.Visible = false;
            countryMasterToolStripMenuItem.Visible = false;
            locationMasterToolStripMenuItem.Visible = false;
            mOMMasterToolStripMenuItem.Visible = false;
            AnnextureTankMaster.Visible = false;
            QualityIssueMaster.Visible = false;
            DocumentMaster.Visible = false;
            AgitationMaster.Visible = false;
            nAtureofACRefMasterToolStripMenuItem.Visible = false;
            aCMaterialRefMasterToolStripMenuItem.Visible = false;
            //Transaction 
            consumerComplaintToolStripMenuItem.Visible = false;
            waterAnalysisToolStripMenuItem1.Visible = false;
            compatibilityToolStripMenuItem1.Visible = false;
            referenceSampleManageToolStripMenuItem.Visible = false;
            referenceSampleManagementRMToolStripMenuItem.Visible = false;
            //OEE
            oEEActivityMasterToolStripMenuItem.Visible = false;
            activityRelationMasterToolStripMenuItem.Visible = false;
            oEETransactionsToolStripMenuItem.Visible = false;
            oEETMTMasterToolStripMenuItem.Visible = false;
            oEEModificationToolStripMenuItem.Visible = false;

            //Image Comparison
            //imageComparisionToolStripMenuItem.Visible = false;
            imageComparisonToolStripMenuItem.Visible = false;

            //Line OEE
            //toolStripMenuItem1.Visible = false;
            autoLineOEETransationToolStripMenuItem.Visible = false;
            lineOEEActivityMasterToolStripMenuItem.Visible = false;
            lineOEEActivityRelationMasterToolStripMenuItem.Visible = false;
            uploadLineOEEMasterToolStripMenuItem.Visible = false;
            lineOEEDataJunctionReportToolStripMenuItem.Visible = false;
            viewUploadLineOEEMasterToolStripMenuItem.Visible = false;
            lineOEEUPTdbReportToolStripMenuItem.Visible = false;
            lineOEEGraphReportToolStripMenuItem.Visible = false;
            lineOEEFGMasterToolStripMenuItem.Visible = false;

            //Reagent Management
            reagentMasterToolStripMenuItem.Visible = false;
            reagentTransactionToolStripMenuItem.Visible = false;
            reaToolStripMenuItem.Visible = false;
            reagentConsumptionToolStripMenuItem.Visible = false;
            reagentModificationToolStripMenuItem.Visible = false;
            reagentAvailableStockReportToolStripMenuItem.Visible = false;
            reagentDetailsReportToolStripMenuItem.Visible = false;
            reagentReorderLevelReportToolStripMenuItem.Visible = false;



            //Reports
            consumerComplaintSummaryReportToolStripMenuItem.Visible = false;
            consumerComplaintAnalysisReportToolStripMenuItem1.Visible = false;
            consumerComplaintTDBReportToolStripMenuItem1.Visible = false;
            waterAnalysisReportToolStripMenuItem1.Visible = false;
            monthlyWaterAnalysisReportToolStripMenuItem.Visible = false;
            oEEAnalysisReportToolStripMenuItem.Visible = false;
            mOMReportToolStripMenuItem.Visible = false;
            fGRefSampleMgmtDetailReportToolStripMenuItem.Visible = false;
            rMRefSampleMgmtDetailReportToolStripMenuItem.Visible = false;
            oEEDetailProcessReportToolStripMenuItem.Visible = false;
            refSampleMgmtSummaryReportToolStripMenuItem.Visible = false;
            physicoChemicalWaterAToolStripMenuItem.Visible = false;
            lastProductionFormulaReportToolStripMenuItem.Visible = false;
            plantwiseWaterAnalysisToolStripMenuItem.Visible = false;
            #endregion

            #region ADMIN Disable Form List
            //Manage Permissions
            userManagementToolStripMenuItem.Visible = false;
            userPermissionToolStripMenuItem.Visible = false;
            groupMasterToolStripMenuItem.Visible = false;
            userGroupMasterRelationToolStripMenuItem.Visible = false;
            changePasswordToolStripMenuItem.Visible = false;
            #endregion

            #region SCOOP disable Form List

            lineSamplingPointMasterToolStripMenuItem.Visible = false;

            scoopTestMethodMasterToolStripMenuItem.Visible = false;

            lineSamplingPointInfoToolStripMenuItem1.Visible = false;

            uPToolStripMenuItem.Visible = false;

            uPAuthorityToolStripMenuItem.Visible = false;

            qualityAuthorityToolStripMenuItem.Visible = false;

            // finalApprovalToolStripMenuItem.Visible = false;

            fGAnalysisReportToolStripMenuItem.Visible = false;

            fGAnalysisNotDoneReportToolStripMenuItem.Visible = false;

            #endregion

            #region SubContractor disable Form List

            toolStripMenuItem4.Visible = false;
            toolStripMenuItem12.Visible = false;
            finishGoodTestToolStripMenuItem.Visible = false;
            toolStripMenuItem17.Visible = false;
            toolStripMenuItem14.Visible = false;

            #endregion

        }

        #endregion

        #region "EXIT"
        private void toolStripButtonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region "MENU CLICK EVENTS"
        private void testMasterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Forms.FrmTestMaster frm = new Forms.FrmTestMaster();            

            Forms.FrmTestMaster_PhyChe frm = Forms.FrmTestMaster_PhyChe.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void bulkTechnicalFamilyMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Forms.FrmBulkTechnicalFamilyMaster frm = new FrmBulkTechnicalFamilyMaster();

            Forms.FrmBulkTechnicalFamilyMaster frm = Forms.FrmBulkTechnicalFamilyMaster.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void formulaMasterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Forms.FrmFormulaNoMaster frm = new FrmFormulaNoMaster();

            Forms.FrmMOMMaster frm = Forms.FrmMOMMaster.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void packingFamilyMasterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Forms.FrmPackingFamilyMaster frm = new FrmPackingFamilyMaster();

            Forms.FrmPackingFamilyMaster frm = Forms.FrmPackingFamilyMaster.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void lineMasterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Forms.FrmLineMaster frm = new FrmLineMaster();

            Forms.FrmLineMaster frm = Forms.FrmLineMaster.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void tankMasterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Forms.FrmTankMaster frm = new FrmTankMaster();

            Forms.FrmTankMaster frm = Forms.FrmTankMaster.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void vesselMasterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Forms.FrmVesselMaster frm = new FrmVesselMaster();

            Forms.FrmVesselMaster frm = Forms.FrmVesselMaster.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void preservativeMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Forms.FrmPreservativeMaster frm = new FrmPreservativeMaster();

            Forms.FrmPreservativeMaster frm = Forms.FrmPreservativeMaster.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void preservativeMethodMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Forms.FrmPreservativeMethodMaster frm = new FrmPreservativeMethodMaster();

            Forms.FrmPreservativeMethodMaster frm = Forms.FrmPreservativeMethodMaster.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void finishGoodMasterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //FrmFinishedGoodMaster frm = new FrmFinishedGoodMaster();

            Forms.FrmFinishedGoodMaster frm = Forms.FrmFinishedGoodMaster.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void fGFamilyMethodMasterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Forms.FrmFgFamMethodMaster frm = new FrmFgFamMethodMaster();

            Forms.FrmFgFamMethodMaster frm = new Forms.FrmFgFamMethodMaster();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void finishGoodMethodMasterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Forms.FrmFinishedGoodMethodMaster_New frm = new FrmFinishedGoodMethodMaster_New();

            Forms.FrmFinishedGoodMethodMaster_New frm = Forms.FrmFinishedGoodMethodMaster_New.GetInstance();
            frm.WindowState = FormWindowState.Maximized;
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void fGPhysicoChemicalTestMethodMasterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Forms.FrmFGPhyCheTestMethodMaster frm = new FrmFGPhyCheTestMethodMaster();

            Forms.FrmFGPhyCheTestMethodMaster frm = Forms.FrmFGPhyCheTestMethodMaster.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void fDATransactionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Transactions.FrmFDATransaction frm = QTMS.Transactions.FrmFDATransaction.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void fDAMasterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Forms.FrmFDAMaster frm = QTMS.Forms.FrmFDAMaster.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void bulkTestDetailsToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            //Transactions.FrmBulkTestDetailsTransaction frm = new QTMS.Transactions.FrmBulkTestDetailsTransaction(LoginID);

            Transactions.FrmBulkTestDetailsTransaction frm = Transactions.FrmBulkTestDetailsTransaction.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void lineSamplePackingDetailsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Transactions.FrmLineSamplePackingDetails frm = new QTMS.Transactions.FrmLineSamplePackingDetails(LoginID);

            Transactions.FrmLineSamplePackingDetails frm = Transactions.FrmLineSamplePackingDetails.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void lineSampleDetailsToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            //Transactions.FrmLineSampling frm = new QTMS.Transactions.FrmLineSampling(LoginID);

            Transactions.FrmLineSampling frm = Transactions.FrmLineSampling.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void preservativeTestToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            //Transactions.FrmPreservativeTest frm = new QTMS.Transactions.FrmPreservativeTest(LoginID);

            Transactions.FrmPreservativeTest frm = Transactions.FrmPreservativeTest.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void microbiologyTestToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            //Transactions.FrmMicrobiologyTest frm = new QTMS.Transactions.FrmMicrobiologyTest(LoginID);

            Transactions.FrmMicrobiologyTest frm = Transactions.FrmMicrobiologyTest.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void kitDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Transactions.FrmKit frm = new QTMS.Transactions.FrmKit();

            Transactions.FrmKitDetails frm = Transactions.FrmKitDetails.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void finishedGoodTestToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Transactions.FrmFinishedGoodTest frm = new QTMS.Transactions.FrmFinishedGoodTest(LoginID);

            Transactions.FrmFinishedGoodTest frm = Transactions.FrmFinishedGoodTest.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void finishedGoodTreatmentToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Transactions.FrmFinishedGoodTestTreatment fm = new QTMS.Transactions.FrmFinishedGoodTestTreatment(LoginID);

            Transactions.FrmFinishedGoodTestTreatment frm = Transactions.FrmFinishedGoodTestTreatment.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void formulaHistoryReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void bulkTestReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void bulkTestDetailsReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void bulkAnalysisReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void bulkTDBReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Reports_Forms.Report frm = new QTMS.Reports_Forms.Report("BulkTDB");
            frm.MdiParent = this;
            frm.Show();
        }

        private void linePackingDetailsReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }



        private void lineSampleDetailsReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void preservativeTestReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }



        private void microbiologyTestReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void microbiologyTDBReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Reports_Forms.FrmMicrobiology_Report frm = new QTMS.Reports_Forms.FrmMicrobiology_Report("MicrobiologyTDB");
            frm.MdiParent = this;
            frm.Show();
        }

        private void fGTestMethodMasterReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void TestMethodMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void finishedGoodTransactionReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void fGAnalysisReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void globalFGTDBReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.Report frm = new QTMS.Reports_Forms.Report("GlobalFGTDB");
            frm.MdiParent = this;
            frm.Show();
        }

        private void fillingAndPackingQualityReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.Report frm = new QTMS.Reports_Forms.Report("FillingPackingQuality");
            frm.MdiParent = this;
            frm.Show();
        }

        private void fillingAndPackingTransactionReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void preLotDossierReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void lotDossierReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void lotDossierSummaryReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void bulkTestDetailsToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Transactions.FrmBulkTestDetailsModification frm = Transactions.FrmBulkTestDetailsModification.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void lineSamplePackingToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Transactions.FrmLineSamplePackingDetailsModification frm = Transactions.FrmLineSamplePackingDetailsModification.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void lineSampleDetailsToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Transactions.FrmLineSamplingModification frm = Transactions.FrmLineSamplingModification.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void preservativeTestToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Transactions.FrmPreservativeTestModification frm = Transactions.FrmPreservativeTestModification.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void microbiologyTestToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Transactions.FrmMicrobiologyTestModification frm = new QTMS.Transactions.FrmMicrobiologyTestModification();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void kitDetailsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Transactions.FrmKitDetailsModification frm = Transactions.FrmKitDetailsModification.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void finishedGoodTestCorrectionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Transactions.FrmFinishedGoodTestModification frm = Transactions.FrmFinishedGoodTestModification.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void transactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transactions.FrmConsumerComplaintTransaction frm = QTMS.Transactions.FrmConsumerComplaintTransaction.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void rMSupplierMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Forms.FrmRMSupplierMaster frm = Forms.FrmRMSupplierMaster.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();

        }

        private void rMFamilyMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.FrmRMFamilyMaster frm = Forms.FrmRMFamilyMaster.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void rMCodeMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.FrmRMCodeMaster frm = Forms.FrmRMCodeMaster.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void rMParameterMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.FrmRMParaMaster frm = Forms.FrmRMParaMaster.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void RMDescMastertoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Forms.FrmRMDescMaster frm = Forms.FrmRMDescMaster.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }


        private void rMCodeTestMethodMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.FrmRMCodeTestMethodMaster frm = Forms.FrmRMCodeTestMethodMaster.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void rMSamplingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transactions.FrmRMSamplingMaster frm = Transactions.FrmRMSamplingMaster.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void rMTransactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transactions.FrmRMTransaction frm = QTMS.Transactions.FrmRMTransaction.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void rMStatusChangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transactions.FrmRMStatusChange frm = Transactions.FrmRMStatusChange.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void rMValidityReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transactions.FrmRMValidityReport frm = QTMS.Transactions.FrmRMValidityReport.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void pMSupplierMasterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Forms.FrmPMSupplierMaster frm = Forms.FrmPMSupplierMaster.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void pMFamilyMasterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Forms.FrmPMFamilyMaster frm = Forms.FrmPMFamilyMaster.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void pMMasterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Forms.FrmPMCodeMaster frm = Forms.FrmPMCodeMaster.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void pMTestMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Forms.FrmPMTestMaster frm = Forms.FrmPMTestMaster.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void pMPeriodicTestMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.FrmPMTestMethodMaster frm = Forms.FrmPMTestMethodMaster.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void pMTransactionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Transactions.FrmPMTransaction frm = QTMS.Transactions.FrmPMTransaction.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void pMStatusChangeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Transactions.FrmPMStatusChange frm = QTMS.Transactions.FrmPMStatusChange.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void pMTreatmentToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Transactions.FrmPMTreatment frm = QTMS.Transactions.FrmPMTreatment.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void rMTestMethodMasterReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.FrmRMTestMethodMaster_Report frm = new QTMS.Reports_Forms.FrmRMTestMethodMaster_Report("RMTestMethodMasterReport");
            frm.MdiParent = this;
            frm.Show();
        }

        private void rMTransactionReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.Report frm = new QTMS.Reports_Forms.Report("RMTransaction");
            frm.MdiParent = this;
            frm.Show();
        }

        private void rMTDBReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.Report frm = new QTMS.Reports_Forms.Report("RMTDB");
            frm.MdiParent = this;
            frm.Show();
        }




        private void rMAnalysisReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.FrmRM_Analysis_Report frm = new QTMS.Reports_Forms.FrmRM_Analysis_Report("RM_Analysis");
            frm.MdiParent = this;
            frm.Show();
        }

        private void rMValidityAnalysisReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.Report frm = new QTMS.Reports_Forms.Report("RMValidity_Analysis");
            frm.MdiParent = this;
            frm.Show();
        }

        private void PMTestMethodMasterReportToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Reports_Forms.FrmPMTestMethodMaster_Report frm = new QTMS.Reports_Forms.FrmPMTestMethodMaster_Report("PMTestMethodMasterReport");
            frm.MdiParent = this;
            frm.Show();
        }

        private void pMTransactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.Report frm = new QTMS.Reports_Forms.Report("PMTransaction");
            frm.MdiParent = this;
            frm.Show();
        }

        private void pMRejectionDetailReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.Report frm = new QTMS.Reports_Forms.Report("PMRejection_Detail");
            frm.MdiParent = this;
            frm.Show();
        }

        private void pMAnalysisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.FrmPMAnalysis_Report frm = new QTMS.Reports_Forms.FrmPMAnalysis_Report();
            frm.MdiParent = this;
            frm.Show();
        }

        private void pMTDBReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.Report frm = new QTMS.Reports_Forms.Report("PM_TDB");
            frm.MdiParent = this;
            frm.Show();
        }

        private void pMSupplierTDBReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.Report frm = new QTMS.Reports_Forms.Report("PM_Supplier_TDB");
            frm.MdiParent = this;
            frm.Show();
        }

        private void pMFamilyTDBReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.Report frm = new QTMS.Reports_Forms.Report("PM_Family_TDB");
            frm.MdiParent = this;
            frm.Show();
        }

        private void fDAAnalysisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.FrmFDA_Analysis_Report frm = new QTMS.Reports_Forms.FrmFDA_Analysis_Report();
            frm.MdiParent = this;
            frm.Show();
        }

        private void pMCOCListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.Report frm = new QTMS.Reports_Forms.Report("PM_COCList");
            frm.MdiParent = this;
            frm.Show();
        }

        private void toolStripMenuItemManagePermissions_Click(object sender, EventArgs e)
        {
            //QTMS.FrmUserManagement fm = new FrmUserManagement();
            //fm.MdiParent = this;
            //fm.Show();
            //frmUsers fm = new frmUsers();
            //fm.MdiParent = this;
            //fm.Show();
        }

        #endregion



        private void rMTransactionCorrectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transactions.FrmRMTransactionModification frm = new QTMS.Transactions.FrmRMTransactionModification();
            frm.MdiParent = this;
            frm.Show();
        }

        private void fGGlobalFamilyMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.FrmFGGlobalFamilyMaster frm = new QTMS.Forms.FrmFGGlobalFamilyMaster();
            frm.MdiParent = this;
            frm.Show();
        }


        private void lineSampleSummaryReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Reports_Forms.Report frm = new QTMS.Reports_Forms.Report("LineSamplingSummary");
            frm.MdiParent = this;
            frm.Show();
        }

        private void microbiologySummaryReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.FrmMicrobiology_Report frm = new QTMS.Reports_Forms.FrmMicrobiology_Report("MicrobiologySummary");
            frm.MdiParent = this;
            frm.Show();
        }

        private void lotDossierSummaryReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Reports_Forms.FrmLotDossierReport frm = new QTMS.Reports_Forms.FrmLotDossierReport("LotDossierSummary");
            frm.MdiParent = this;
            frm.Show();
        }

        private void finishedGoodSummaryReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.Report frm = new QTMS.Reports_Forms.Report("FinishedGoodSummary");
            frm.MdiParent = this;
            frm.Show();
        }

        private void bulkTestDetailsReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Reports_Forms.Report frm = new QTMS.Reports_Forms.Report("BulkTestDetail");
            frm.MdiParent = this;
            frm.Show();
        }

        private void linePackingDetailsReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Reports_Forms.Report frm = new QTMS.Reports_Forms.Report("LinePacking");
            frm.MdiParent = this;
            frm.Show();
        }

        private void formulaHistoryReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Reports_Forms.FrmFormulaHistoryReport frm = new QTMS.Reports_Forms.FrmFormulaHistoryReport("FormulaHistory");
            frm.MdiParent = this;
            frm.Show();
        }

        private void bulkTestReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.FrmBulkTestReport frm = new QTMS.Reports_Forms.FrmBulkTestReport("BulkTest");
            frm.MdiParent = this;
            frm.Show();
        }

        private void testMethodMasterReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.FrmTestMethodMaster_Report frm = new QTMS.Reports_Forms.FrmTestMethodMaster_Report("TestMethodMasterReport");
            frm.MdiParent = this;
            frm.Show();
        }

        private void fGTestMethodMasterReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Reports_Forms.FrmFGTestMethodMaster_Report frm = new QTMS.Reports_Forms.FrmFGTestMethodMaster_Report("FGTestMethodMasterReport");
            frm.MdiParent = this;
            frm.Show();
        }

        private void bulkAnalysisReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.FrmBulkAnalysis_Report frm = new QTMS.Reports_Forms.FrmBulkAnalysis_Report("BulkAnalysis");
            frm.MdiParent = this;
            frm.Show();
        }

        private void bulkTransactionReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.Report frm = new QTMS.Reports_Forms.Report("BulkTransaction");
            frm.MdiParent = this;
            frm.Show();
        }

        private void lineSampleDetailsReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Reports_Forms.Report frm = new QTMS.Reports_Forms.Report("LineSampling");
            frm.MdiParent = this;
            frm.Show();
        }

        private void preservativeTestReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Reports_Forms.Report frm = new QTMS.Reports_Forms.Report("PreservativeTest");
            frm.MdiParent = this;
            frm.Show();
        }

        private void microbiologyTestReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Reports_Forms.FrmMicrobiology_Report frm = new QTMS.Reports_Forms.FrmMicrobiology_Report("MicrobiologyTest");
            frm.MdiParent = this;
            frm.Show();
        }

        private void finishedGoodTransactionReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Reports_Forms.Report frm = new QTMS.Reports_Forms.Report("FinishedGoodTest");
            frm.MdiParent = this;
            frm.Show();
        }

        private void fGAnalysisReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.FrmFGAnalysisReport frm = new QTMS.Reports_Forms.FrmFGAnalysisReport("FGAnalysis");
            frm.MdiParent = this;
            frm.Show();
        }

        private void preLotDossierReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Reports_Forms.FrmPreLotDossierReport frm = new QTMS.Reports_Forms.FrmPreLotDossierReport("PreLotDossier");
            frm.MdiParent = this;
            frm.Show();
        }

        private void lotDossierReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Reports_Forms.FrmLotDossierReport frm = new QTMS.Reports_Forms.FrmLotDossierReport("LotDossier");
            frm.MdiParent = this;
            frm.Show();
        }

        private void lotDossierDetailReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.FrmLotDossierReport frm = new QTMS.Reports_Forms.FrmLotDossierReport("LotDossierDetail");
            frm.MdiParent = this;
            frm.Show();
        }

        private void toolStripButtonQTMS_Click(object sender, EventArgs e)
        {
            menuStripQTMSH.Visible = true;
            menuStripRMH.Visible = false;
            menuStripPMH.Visible = false;
            menuStripFDAH.Visible = false;
            menuStripADMINH.Visible = false;
            menuStripMettler.Visible = false;
        }

        private void toolStripButtonRM_Click(object sender, EventArgs e)
        {
            menuStripQTMSH.Visible = false;
            menuStripRMH.Visible = true;
            menuStripPMH.Visible = false;
            menuStripFDAH.Visible = false;
            menuStripADMINH.Visible = false;
            menuStripMettler.Visible = false;
        }

        private void toolStripButtonPM_Click(object sender, EventArgs e)
        {
            menuStripQTMSH.Visible = false;
            menuStripRMH.Visible = false;
            menuStripPMH.Visible = true;
            menuStripFDAH.Visible = false;
            menuStripADMINH.Visible = false;
            menuStripMettler.Visible = false;
        }

        private void toolStripButtonFDA_Click(object sender, EventArgs e)
        {
            menuStripQTMSH.Visible = false;
            menuStripRMH.Visible = false;
            menuStripPMH.Visible = false;
            menuStripFDAH.Visible = true;
            menuStripADMINH.Visible = false;
            menuStripMettler.Visible = false;
        }

        private void toolStripButtonADMIN_Click(object sender, EventArgs e)
        {
            menuStripQTMSH.Visible = false;
            menuStripRMH.Visible = false;
            menuStripPMH.Visible = false;
            menuStripFDAH.Visible = false;
            menuStripADMINH.Visible = true;
            menuStripMettler.Visible = false;
        }

        private void testMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.FrmTestMaster_PhyChe frm = Forms.FrmTestMaster_PhyChe.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void packingTestMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.FrmTestMaster_Packing frm = Forms.FrmTestMaster_Packing.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void bulkTechnicalFamilyMasterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Forms.FrmBulkTechnicalFamilyMaster frm = Forms.FrmBulkTechnicalFamilyMaster.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void formulaMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.FrmFormulaNoMaster frm = new QTMS.Forms.FrmFormulaNoMaster();

            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void packingFamilyMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.FrmPackingFamilyMaster frm = Forms.FrmPackingFamilyMaster.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void lineMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.FrmLineMaster frm = Forms.FrmLineMaster.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void tankMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.FrmTankMaster frm = Forms.FrmTankMaster.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void vesselMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.FrmVesselMaster frm = Forms.FrmVesselMaster.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void preservativeMasterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Forms.FrmPreservativeMaster frm = Forms.FrmPreservativeMaster.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void preservativeMethodMasterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Forms.FrmPreservativeMethodMaster frm = Forms.FrmPreservativeMethodMaster.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void finishGoodMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.FrmFinishedGoodMaster frm = Forms.FrmFinishedGoodMaster.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void fGFamilyMethodMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.FrmFgFamMethodMaster frm = new Forms.FrmFgFamMethodMaster();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void finishGoodMethodMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.FrmFinishedGoodMethodMaster_New frm = Forms.FrmFinishedGoodMethodMaster_New.GetInstance();
            frm.WindowState = FormWindowState.Maximized;
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void fGPhysicoChemicalTestMethodMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.FrmFGPhyCheTestMethodMaster frm = Forms.FrmFGPhyCheTestMethodMaster.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void fGGlobalFamilyMasterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Forms.FrmFGGlobalFamilyMaster frm = Forms.FrmFGGlobalFamilyMaster.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }



        private void instrumentMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void compatibilityToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void adjustmentTransactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transactions.FrmAdjustmentTransaction frm = Transactions.FrmAdjustmentTransaction.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }


        private void bulkTestDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transactions.FrmBulkTestDetailsTransaction frm = Transactions.FrmBulkTestDetailsTransaction.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void lineSamplePackingDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transactions.FrmLineSamplePackingDetails frm = Transactions.FrmLineSamplePackingDetails.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void lineSampleDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transactions.FrmLineSampling frm = Transactions.FrmLineSampling.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void preservativeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transactions.FrmPreservativeTest frm = Transactions.FrmPreservativeTest.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void microbiologyTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transactions.FrmMicrobiologyTest frm = Transactions.FrmMicrobiologyTest.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void kitDetailsToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Transactions.FrmKitDetails frm = Transactions.FrmKitDetails.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void sFDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transactions.FrmSFDetails frm = Transactions.FrmSFDetails.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void finishedGoodTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transactions.FrmFinishedGoodTest frm = Transactions.FrmFinishedGoodTest.GetInstance();
            //Transactions.frmNormalQuality frm = new QTMS.Transactions.frmNormalQuality.
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void finishedGoodTreatmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transactions.FrmFinishedGoodTestTreatment frm = Transactions.FrmFinishedGoodTestTreatment.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void finishedGoodTestSFPackingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transactions.FrmFinishedGoodTestSFPacking frm = Transactions.FrmFinishedGoodTestSFPacking.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void fGReleaseDossierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transactions.FrmFGReleaseDossier frm = Transactions.FrmFGReleaseDossier.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void bulkTestDetailsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Transactions.FrmBulkTestDetailsModification frm = Transactions.FrmBulkTestDetailsModification.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void lineSamplePackingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transactions.FrmLineSamplePackingDetailsModification frm = Transactions.FrmLineSamplePackingDetailsModification.GetInstance();
            //Thread th = new Thread(new ThreadStart(frm.Bind_Details));
            //th.Start();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void lineSampleDetailsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Transactions.FrmLineSamplingModification frm = Transactions.FrmLineSamplingModification.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void preservativeTestToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Transactions.FrmPreservativeTestModification frm = Transactions.FrmPreservativeTestModification.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void microbiologyTestToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Transactions.FrmMicrobiologyTestModification frm = new QTMS.Transactions.FrmMicrobiologyTestModification();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void kitDetailsToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Transactions.FrmKitDetailsModification frm = Transactions.FrmKitDetailsModification.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }
        private void sFDetailsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Transactions.FrmSFDetailsModification frm = Transactions.FrmSFDetailsModification.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }
        private void finishedGoodTestToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Transactions.FrmFinishedGoodTestModification frm = Transactions.FrmFinishedGoodTestModification.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void transactionToolStripMenuItem5_Click(object sender, EventArgs e)
        {

        }

        private void transactionToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void rMSupplierMasterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Forms.FrmRMSupplierMaster frm = Forms.FrmRMSupplierMaster.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void rMFamilyMasterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Forms.FrmRMFamilyMaster frm = Forms.FrmRMFamilyMaster.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void rMParameterMasterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Forms.FrmRMParaMaster frm = Forms.FrmRMParaMaster.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void rMParameterDescriptionMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.FrmRMDescMaster frm = Forms.FrmRMDescMaster.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void rMCodeMasterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Forms.FrmRMCodeMaster frm = Forms.FrmRMCodeMaster.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void rMCodeTestMethodMasterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Forms.FrmRMCodeTestMethodMaster frm = Forms.FrmRMCodeTestMethodMaster.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void rMRetainerLabelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.FrmRMCodeRetainerLabel frm = Forms.FrmRMCodeRetainerLabel.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }
        private void rMSafetySymbolMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.FrmSafetySymbol frm = Forms.FrmSafetySymbol.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void rMRetainerLocationMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Forms.FrmRMRetainerLocationMaster frm = Forms.FrmRMRetainerLocationMaster.GetInstance();
                frm.MdiParent = this;
                frm.Show();
                frm.Activate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void rMSamplingToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Transactions.FrmRMSamplingMaster frm = Transactions.FrmRMSamplingMaster.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void rMTransactionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Transactions.FrmRMTransaction frm = QTMS.Transactions.FrmRMTransaction.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void rMStatusChangeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Transactions.FrmRMStatusChange frm = Transactions.FrmRMStatusChange.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void rMValidityReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Transactions.FrmRMValidityReport frm = QTMS.Transactions.FrmRMValidityReport.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }
        private void rMMicrobiologyTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transactions.FrmRMMicrobiologyTest frm = QTMS.Transactions.FrmRMMicrobiologyTest.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void rMMicrobiologyTestModificationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transactions.FrmRMMicrobiologyTestModification frm = QTMS.Transactions.FrmRMMicrobiologyTestModification.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }
        private void pMSupplierMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.FrmPMSupplierMaster frm = Forms.FrmPMSupplierMaster.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void pMFamilyMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.FrmPMFamilyMaster frm = Forms.FrmPMFamilyMaster.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void pMCodeMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.FrmPMCodeMaster frm = Forms.FrmPMCodeMaster.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void pMTestMasterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Forms.FrmPMTestMaster frm = Forms.FrmPMTestMaster.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void pMTestMethodMasterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Forms.FrmPMTestMethodMaster frm = Forms.FrmPMTestMethodMaster.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void pMTransactionToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Transactions.FrmPMTransaction frm = QTMS.Transactions.FrmPMTransaction.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void pMStatusChangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transactions.FrmPMStatusChange frm = QTMS.Transactions.FrmPMStatusChange.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void pMReanalysisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transactions.FrmPMReanalysis frm = QTMS.Transactions.FrmPMReanalysis.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void pMTreatmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transactions.FrmPMTreatment frm = QTMS.Transactions.FrmPMTreatment.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void pMDefectNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transactions.FrmPMDefectNote frm = QTMS.Transactions.FrmPMDefectNote.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void pMModificationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transactions.FrmPMModification frm = QTMS.Transactions.FrmPMModification.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void fDAMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.FrmFDAMaster frm = QTMS.Forms.FrmFDAMaster.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void fDATransactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transactions.FrmFDATransaction frm = QTMS.Transactions.FrmFDATransaction.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void fDAModificationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transactions.FrmFDAModification frm = QTMS.Transactions.FrmFDAModification.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void aDMINToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void formulaHistoryReportToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Reports_Forms.FrmFormulaHistoryReport frm = new QTMS.Reports_Forms.FrmFormulaHistoryReport("FormulaHistory");
            frm.MdiParent = this;
            frm.Show();
        }

        private void fGFormulaHistoryReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.FrmFormulaHistoryFG_Report frm = new QTMS.Reports_Forms.FrmFormulaHistoryFG_Report("FGFormulaHistory");
            frm.MdiParent = this;
            frm.Show();
        }

        private void formulaDescriptionReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.FrmFormulaDescriptionReport frm = new QTMS.Reports_Forms.FrmFormulaDescriptionReport();
            frm.MdiParent = this;
            frm.Show();
        }

        private void bulkTestReportToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            Reports_Forms.FrmBulkTestReport frm = new QTMS.Reports_Forms.FrmBulkTestReport("BulkTest");
            frm.MdiParent = this;
            frm.Show();
        }

        private void testMethodMasterReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Reports_Forms.FrmTestMethodMaster_Report frm = new QTMS.Reports_Forms.FrmTestMethodMaster_Report("TestMethodMasterReport");
            frm.MdiParent = this;
            frm.Show();
        }

        private void fGTestMethodMasterReportToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Reports_Forms.FrmFGTestMethodMaster_Report frm = new QTMS.Reports_Forms.FrmFGTestMethodMaster_Report("FGTestMethodMasterReport");
            frm.MdiParent = this;
            frm.Show();
        }

        private void bulkAnalysisReportToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            Reports_Forms.FrmBulkAnalysis_Report frm = new QTMS.Reports_Forms.FrmBulkAnalysis_Report("BulkAnalysis");
            frm.MdiParent = this;
            frm.Show();
        }

        private void bulkTransactionReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Reports_Forms.Report frm = new QTMS.Reports_Forms.Report("BulkTransaction");
            frm.MdiParent = this;
            frm.Show();
        }

        private void lineSampleDetailsReportToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Reports_Forms.Report frm = new QTMS.Reports_Forms.Report("LineSampling");
            frm.MdiParent = this;
            frm.Show();
        }

        private void preservativeTestReportToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Reports_Forms.FrmPreservativeTest_Report frm = new QTMS.Reports_Forms.FrmPreservativeTest_Report("PreservativeTest");
            frm.MdiParent = this;
            frm.Show();
        }

        private void microbiologyTestReportToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Reports_Forms.FrmMicrobiology_Report frm = new QTMS.Reports_Forms.FrmMicrobiology_Report("MicrobiologyTest");
            frm.MdiParent = this;
            frm.Show();
        }

        private void fGAnalysisReportToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            Reports_Forms.FrmFGAnalysisReport frm = new QTMS.Reports_Forms.FrmFGAnalysisReport("FGAnalysis");
            frm.MdiParent = this;
            frm.Show();
        }

        private void fGAnalysisBMRReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.FrmFGAnalysis_BMR_Report frm = new QTMS.Reports_Forms.FrmFGAnalysis_BMR_Report("FGAnalysisBMR");
            frm.MdiParent = this;
            frm.Show();
        }

        private void bulkTestDetailsReportToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Reports_Forms.Report frm = new QTMS.Reports_Forms.Report("BulkTestDetail");
            frm.MdiParent = this;
            frm.Show();
        }

        private void bulkTestNonBPCReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.Report frm = new QTMS.Reports_Forms.Report("BulkTest_NonBPC");
            frm.MdiParent = this;
            frm.Show();
        }

        private void bulkTestNewLaunchReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.Report frm = new QTMS.Reports_Forms.Report("BulkTest_NewLaunch");
            frm.MdiParent = this;
            frm.Show();
        }

        private void bulkTestNonValidatedReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.Report frm = new QTMS.Reports_Forms.Report("BulkTest_NonValidated");
            frm.MdiParent = this;
            frm.Show();
        }

        private void bMRSummaryReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.FrmBMR_Report frm = new QTMS.Reports_Forms.FrmBMR_Report("BMR");
            frm.MdiParent = this;
            frm.Show();
        }

        private void bMRPreSummaryReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.Report frm = new QTMS.Reports_Forms.Report("BMRPreSummary");
            frm.MdiParent = this;
            frm.Show();
        }

        private void qStatusSummaryReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.Report frm = new QTMS.Reports_Forms.Report("QStatus");
            frm.MdiParent = this;
            frm.Show();
        }

        private void fGReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.Report frm = new QTMS.Reports_Forms.Report("FG_Report");
            frm.MdiParent = this;
            frm.Show();
        }

        private void linePackingDetailsReportToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Reports_Forms.Report frm = new QTMS.Reports_Forms.Report("LinePacking");
            frm.MdiParent = this;
            frm.Show();
        }

        private void lineSampleSummaryReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.Report frm = new QTMS.Reports_Forms.Report("LineSamplingSummary");
            frm.MdiParent = this;
            frm.Show();
        }

        private void preservativeSummaryReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.Report frm = new QTMS.Reports_Forms.Report("PreservativeTest_Summary");
            frm.MdiParent = this;
            frm.Show();
        }

        private void microbiologySummaryReportToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Reports_Forms.FrmMicrobiology_Report frm = new QTMS.Reports_Forms.FrmMicrobiology_Report("MicrobiologySummary");
            frm.MdiParent = this;
            frm.Show();
        }

        private void finishedGoodTransactionReportToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Reports_Forms.Report frm = new QTMS.Reports_Forms.Report("FinishedGoodTest");
            frm.MdiParent = this;
            frm.Show();
        }

        private void finishedGoodSummaryReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Reports_Forms.Report frm = new QTMS.Reports_Forms.Report("FinishedGoodSummary");
            frm.MdiParent = this;
            frm.Show();
        }

        private void finishedGoodNonBPCReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.Report frm = new QTMS.Reports_Forms.Report("FinishedGood_NonBPC");
            frm.MdiParent = this;
            frm.Show();
        }

        private void bulkPendingReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.Report frm = new QTMS.Reports_Forms.Report("Bulk_Pending");
            frm.MdiParent = this;
            frm.Show();
        }

        private void fGBulkPendingReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.Report frm = new QTMS.Reports_Forms.Report("FGBulk_Pending");
            frm.MdiParent = this;
            frm.Show();
        }

        private void lotDossierSummaryReportToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Reports_Forms.FrmLotDossierSummaryReport frm = new QTMS.Reports_Forms.FrmLotDossierSummaryReport("LotDossierSummary");
            frm.MdiParent = this;
            frm.Show();
        }

        private void rejectionNoteFGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.FrmRejectionNote_FG frm = new QTMS.Reports_Forms.FrmRejectionNote_FG("RejectionNote_FG");
            frm.MdiParent = this;
            frm.Show();
        }

        private void analysisSummaryReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.Report frm = new QTMS.Reports_Forms.Report("Analysis_Summary");
            frm.MdiParent = this;
            frm.Show();
        }

        private void fGReleaseDossierToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Reports_Forms.FrmFGReleaseDossier_Report frm = new QTMS.Reports_Forms.FrmFGReleaseDossier_Report("FGReleaseDossier");
            frm.MdiParent = this;
            frm.Show();
        }

        private void bulkTDBReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.Report frm = new QTMS.Reports_Forms.Report("BulkTDB");
            frm.MdiParent = this;
            frm.Show();
        }

        private void microbiologyTDBReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.FrmMicrobiology_Report frm = new QTMS.Reports_Forms.FrmMicrobiology_Report("MicrobiologyTDB");
            frm.MdiParent = this;
            frm.Show();
        }

        private void globalFGTDBReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Reports_Forms.Report frm = new QTMS.Reports_Forms.Report("GlobalFGTDB");
            frm.MdiParent = this;
            frm.Show();
        }

        private void fGLineDetailsTDBReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.Report frm = new QTMS.Reports_Forms.Report("FG_LineDetails_TDB");
            frm.MdiParent = this;
            frm.Show();
        }

        private void fillingAndPackingQualityReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Reports_Forms.Report frm = new QTMS.Reports_Forms.Report("FillingPackingQuality");
            frm.MdiParent = this;
            frm.Show();
        }

        private void preLotDossierReportToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Reports_Forms.FrmPreLotDossierReport frm = new QTMS.Reports_Forms.FrmPreLotDossierReport("PreLotDossier");
            frm.MdiParent = this;
            frm.Show();
        }

        private void lotDossierReportToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Reports_Forms.FrmLotDossierReport frm = new QTMS.Reports_Forms.FrmLotDossierReport("LotDossier");
            frm.MdiParent = this;
            frm.Show();
        }

        private void lotDossierDetailReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Reports_Forms.FrmLotDossierReport frm = new QTMS.Reports_Forms.FrmLotDossierReport("LotDossierDetail");
            frm.MdiParent = this;
            frm.Show();
        }

        private void bMRLotDossierReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.FrmLotDossier_BMR_Report frm = new QTMS.Reports_Forms.FrmLotDossier_BMR_Report("LotDossierBMR");
            frm.MdiParent = this;
            frm.Show();
        }

        private void rMCodeHistoryReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.FrmRMCodeHistory_Report frm = new QTMS.Reports_Forms.FrmRMCodeHistory_Report("RMCodeHistory");
            frm.MdiParent = this;
            frm.Show();
        }

        private void rMTestMethodMasterReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Reports_Forms.FrmRMTestMethodMaster_Report frm = new QTMS.Reports_Forms.FrmRMTestMethodMaster_Report("RMTestMethodMasterReport");
            frm.MdiParent = this;
            frm.Show();
        }

        private void rMTransactionReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Reports_Forms.FrmTransactionReport frm = new QTMS.Reports_Forms.FrmTransactionReport("RMTransaction");
            frm.MdiParent = this;
            frm.Show();
        }

        private void rMSupllierReportReceivedReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.Report frm = new QTMS.Reports_Forms.Report("RM_SupplierReportReceived");
            frm.MdiParent = this;
            frm.Show();
        }
        private void rMMicrobiologyTestReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.FrmMicrobiology_Report frm = new QTMS.Reports_Forms.FrmMicrobiology_Report("RMMicrobiologyTest");
            frm.MdiParent = this;
            frm.Show();
        }

        private void rMTDBReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Reports_Forms.Report frm = new QTMS.Reports_Forms.Report("RMTDB");
            frm.MdiParent = this;
            frm.Show();
        }

        private void rMSupplierTDBReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.Report frm = new QTMS.Reports_Forms.Report("RM_Supplier_TDB");
            frm.MdiParent = this;
            frm.Show();
        }

        private void pendingRMReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.Report frm = new QTMS.Reports_Forms.Report("RMPending");
            frm.MdiParent = this;
            frm.Show();
        }

        private void rMAnalysisReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Reports_Forms.FrmRM_Analysis_Report frm = new QTMS.Reports_Forms.FrmRM_Analysis_Report("RM_Analysis");
            frm.MdiParent = this;
            frm.Show();
        }

        private void rMValidityAnalysisReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Reports_Forms.Report frm = new QTMS.Reports_Forms.Report("RMValidity_Analysis");
            frm.MdiParent = this;
            frm.Show();
        }
        private void rMRetainerLocationReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.FrmRMRetainerLocation_Report frm = new QTMS.Reports_Forms.FrmRMRetainerLocation_Report("RMRetainerLocation_Report");
            frm.MdiParent = this;
            frm.Show();
        }
        private void pMCodeDescriptionReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.FrmPMCodeDescriptionReport frm = new QTMS.Reports_Forms.FrmPMCodeDescriptionReport();
            frm.MdiParent = this;
            frm.Show();
        }

        private void pMTestMethodMasterReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.FrmPMTestMethodMaster_Report frm = new QTMS.Reports_Forms.FrmPMTestMethodMaster_Report("PMTestMethodMasterReport");
            frm.MdiParent = this;
            frm.Show();
        }

        private void pMTransactionReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.Report frm = new QTMS.Reports_Forms.Report("PMTransaction");
            frm.MdiParent = this;
            frm.Show();
        }

        private void pMNewLaunchReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.Report frm = new QTMS.Reports_Forms.Report("PM_NewLaunch");
            frm.MdiParent = this;
            frm.Show();
        }

        private void pMSupplierReportReceivedReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.Report frm = new QTMS.Reports_Forms.Report("PM_SupplierReportReceived");
            frm.MdiParent = this;
            frm.Show();
        }

        private void pMDefectNoteDetailReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.Report frm = new QTMS.Reports_Forms.Report("PMDefectNote_Detail");
            frm.MdiParent = this;
            frm.Show();
        }

        private void pMRejectionDetailReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Reports_Forms.Report frm = new QTMS.Reports_Forms.Report("PMRejection_Detail");
            frm.MdiParent = this;
            frm.Show();
        }

        private void pMTDBReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Reports_Forms.Report frm = new QTMS.Reports_Forms.Report("PM_TDB");
            frm.MdiParent = this;
            frm.Show();
        }

        private void pMSupplierTDBReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Reports_Forms.Report frm = new QTMS.Reports_Forms.Report("PM_Supplier_TDB");
            frm.MdiParent = this;
            frm.Show();
        }

        private void pMFamilyTDBReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Reports_Forms.Report frm = new QTMS.Reports_Forms.Report("PM_Family_TDB");
            frm.MdiParent = this;
            frm.Show();
        }

        private void pMAnalysisToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Reports_Forms.FrmPMAnalysis_Report frm = new QTMS.Reports_Forms.FrmPMAnalysis_Report();
            frm.MdiParent = this;
            frm.Show();
        }

        private void pMCOCListToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Reports_Forms.Report frm = new QTMS.Reports_Forms.Report("PM_COCList");
            frm.MdiParent = this;
            frm.Show();
        }

        private void pMCOCTransactionReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.Report frm = new QTMS.Reports_Forms.Report("PM_COC_Transaction");
            frm.MdiParent = this;
            frm.Show();
        }

        private void pMDefectNoteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Reports_Forms.FrmPM_Note frm = new QTMS.Reports_Forms.FrmPM_Note("DefectNote_PM");
            frm.MdiParent = this;
            frm.Show();
        }

        private void pMRejectionNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.FrmPM_Note frm = new QTMS.Reports_Forms.FrmPM_Note("RejectionNote_PM");
            frm.MdiParent = this;
            frm.Show();
        }

        private void oxidationHairDyeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.FrmFDA_Analysis_Report frm = new QTMS.Reports_Forms.FrmFDA_Analysis_Report();
            frm.MdiParent = this;
            frm.Show();
        }



        private void retainerLocationMasterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Forms.FrmRetainerLocationMaster frm = Forms.FrmRetainerLocationMaster.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void instrumentMasterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Forms.FrmInstrumentMaster frm = Forms.FrmInstrumentMaster.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void oEEActivityMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.FrmOEEActivityMaster frm = Forms.FrmOEEActivityMaster.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void activityRelationMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.FrmOEEActivityRelationMaster frm = Forms.FrmOEEActivityRelationMaster.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void oEETMTMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Forms.FrmOEETmtMaster frm = Forms.FrmOEETmtMaster.GetInstance();
                frm.MdiParent = this;
                frm.Show();
                frm.Activate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void countryMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.FrmCountryMaster frm = Forms.FrmCountryMaster.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }
        private void locationMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.FrmLocationMaster frm = Forms.FrmLocationMaster.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }
        private void consumerComplaintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transactions.FrmConsumerComplaintTransaction frm = QTMS.Transactions.FrmConsumerComplaintTransaction.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void waterAnalysisToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Transactions.FrmWaterAnalysis frm = QTMS.Transactions.FrmWaterAnalysis.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void compatibilityToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Transactions.FrmCompatibility frm = Transactions.FrmCompatibility.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void referenceSampleManageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transactions.FrmRSManagement frm = Transactions.FrmRSManagement.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void referenceSampleManagementRMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transactions.FrmRefSampleMgmtRMTransaction frm = Transactions.FrmRefSampleMgmtRMTransaction.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }
        private void oEETransactionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transactions.FrmOEETransaction frm = Transactions.FrmOEETransaction.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void oEEModificationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transactions.FrmOEEModification frm = Transactions.FrmOEEModification.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void consumerComplaintSummaryReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.ComplaintSummary_Report frm = new QTMS.Reports_Forms.ComplaintSummary_Report("ComplaintSummary");
            frm.MdiParent = this;
            frm.Show();
        }

        private void consumerComplaintAnalysisReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Reports_Forms.FrmComplaintAnalysis_Report frm = new QTMS.Reports_Forms.FrmComplaintAnalysis_Report("ComplaintAnalysis");
            frm.MdiParent = this;
            frm.Show();
        }

        private void consumerComplaintTDBReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Reports_Forms.FrmComplaint_TDB_Report frm = new QTMS.Reports_Forms.FrmComplaint_TDB_Report("Complaint_TDB");
            frm.MdiParent = this;
            frm.Show();
        }

        private void waterAnalysisReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Reports_Forms.FrmWaterAnalysis_Report frm = new QTMS.Reports_Forms.FrmWaterAnalysis_Report("WaterAnalysis");
            frm.MdiParent = this;
            frm.Show();
        }

        private void monthlyWaterAnalysisReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.FrmWaterAnalysisSampling_Report frm = new QTMS.Reports_Forms.FrmWaterAnalysisSampling_Report("Monthly Water Analysis Report");
            frm.MdiParent = this;
            frm.Show();
        }

        private void oEEAnalysisReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.FrmOEEAnalysis frm = new QTMS.Reports_Forms.FrmOEEAnalysis("OEE Analysis Report");
            frm.MdiParent = this;
            frm.Show();
        }
        private void fGRefSampleMgmtDetailReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.FrmFGRefSampleMgmtReport frm = new QTMS.Reports_Forms.FrmFGRefSampleMgmtReport("FG RSMgmt Detail Report");
            frm.MdiParent = this;
            frm.Show();
        }
        private void rMRefSampleMgmtDetailReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.FrmRMCodeHistory_Report frm = new QTMS.Reports_Forms.FrmRMCodeHistory_Report("RM RSMgmt Detail Report");
            frm.MdiParent = this;
            frm.Show();
        }
        private void userManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //QTMS.FrmUserManagement fm = new FrmUserManagement();
            //fm.MdiParent = this;
            //fm.Show();

            frmUsers fm = new frmUsers();
            fm.MdiParent = this;
            fm.Show();
        }
        private void userPermissionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserTypePermission fm = new frmUserTypePermission();
            fm.MdiParent = this;
            fm.Show();
        }


        private void btnFG_Click(object sender, EventArgs e)
        {
            lblMenuName.Text = "FG";
            menuStripQTMSH.Visible = true;
            menuStripRMH.Visible = false;
            menuStripPMH.Visible = false;
            menuStripFDAH.Visible = false;
            menuStripOther.Visible = false;
            menuStripADMINH.Visible = false;
            menuStripScoop.Visible = false;
            menuStripLineValidation.Visible = menuStripSubCon.Visible = false;
            menuStripMettler.Visible = false;
        }

        private void btnRM_Click(object sender, EventArgs e)
        {
            lblMenuName.Text = "RM";
            menuStripQTMSH.Visible = false;
            menuStripRMH.Visible = true;
            menuStripPMH.Visible = false;
            menuStripFDAH.Visible = false;
            menuStripOther.Visible = false;
            menuStripADMINH.Visible = false;
            menuStripScoop.Visible = false;
            menuStripLineValidation.Visible = menuStripSubCon.Visible = false;
            menuStripMettler.Visible = false;
        }

        private void btnPM_Click(object sender, EventArgs e)
        {
            lblMenuName.Text = "PM";
            menuStripQTMSH.Visible = false;
            menuStripRMH.Visible = false;
            menuStripPMH.Visible = true;
            menuStripFDAH.Visible = false;
            menuStripOther.Visible = false;
            menuStripADMINH.Visible = false;
            menuStripScoop.Visible = false;
            menuStripLineValidation.Visible = menuStripSubCon.Visible = false;
            menuStripMettler.Visible = false;
        }

        private void btnFDA_Click(object sender, EventArgs e)
        {
            lblMenuName.Text = "FDA";
            menuStripQTMSH.Visible = false;
            menuStripRMH.Visible = false;
            menuStripPMH.Visible = false;
            menuStripFDAH.Visible = true;
            menuStripOther.Visible = false;
            menuStripADMINH.Visible = false;
            menuStripScoop.Visible = false;
            menuStripLineValidation.Visible = menuStripSubCon.Visible = false;
            menuStripMettler.Visible = false;
        }

        private void btnOTHER_Click(object sender, EventArgs e)
        {
            lblMenuName.Text = "OTHER";
            menuStripQTMSH.Visible = false;
            menuStripRMH.Visible = false;
            menuStripPMH.Visible = false;
            menuStripFDAH.Visible = false;
            menuStripOther.Visible = true;
            menuStripADMINH.Visible = false;
            menuStripScoop.Visible = false;
            menuStripLineValidation.Visible = menuStripSubCon.Visible = false;
            menuStripMettler.Visible = false;
        }

        private void btnADMIN_Click(object sender, EventArgs e)
        {
            lblMenuName.Text = "ADMIN";
            menuStripQTMSH.Visible = false;
            menuStripRMH.Visible = false;
            menuStripPMH.Visible = false;
            menuStripFDAH.Visible = false;
            menuStripOther.Visible = false;
            menuStripADMINH.Visible = true;
            menuStripScoop.Visible = false;
            menuStripLineValidation.Visible = menuStripSubCon.Visible = false;
            menuStripMettler.Visible = false;
        }

        private void MOMMastertoolStripMenuItem2_Click(object sender, EventArgs e)
        {

            //Forms.FrmMomMaster frm=new QTMS.Forms.FrmMomMaster();
            //frm.MdiParent = this;
            //frm.Show();
            //frm.Activate();
        }

        private void mOMMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Forms.FrmMOMMaster frm = new QTMS.Forms.FrmMOMMaster();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void mOMReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.frmMOMReport frm = new QTMS.Reports_Forms.frmMOMReport();
            frm.MdiParent = this;
            frm.Show();
        }

        private void AnnextureTankMaster_Click(object sender, EventArgs e)
        {
            Forms.FrmAnnextureTankMaster frm = new QTMS.Forms.FrmAnnextureTankMaster();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void QualityIssueMaster_Click(object sender, EventArgs e)
        {
            Forms.frmQualityIssueMaster frm = new QTMS.Forms.frmQualityIssueMaster();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void AgitationMaster_Click(object sender, EventArgs e)
        {
            Forms.frmAgitationMaster frm = new QTMS.Forms.frmAgitationMaster();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void DocumentMaster_Click(object sender, EventArgs e)
        {
            Forms.frmDocumentMaster frm = new QTMS.Forms.frmDocumentMaster();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void retainerLocationReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.FrmFGRetainerSampleLocation_Report frm = new QTMS.Reports_Forms.FrmFGRetainerSampleLocation_Report("Retainer Sample Location");
            frm.MdiParent = this;
            frm.Show();
        }

        private void imageComparisionToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void oEEDetailProcessReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.FrmOEEDetailProcessReport frm = new QTMS.Reports_Forms.FrmOEEDetailProcessReport();
            frm.MdiParent = this;
            frm.Show();
        }

        private void imageComparisonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QTMS.ImageComparision.FrmImageComparision objFrmImageComparision = new QTMS.ImageComparision.FrmImageComparision();
            objFrmImageComparision.MdiParent = this;
            objFrmImageComparision.Show();
        }

        private void autoLineOEETransationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //pnlLineOEE.Visible = true;
            //QTMS.User_Control.ucLineOEE objLineOEE = new QTMS.User_Control.ucLineOEE();
            //pnlLineOEE.Controls.Add(objLineOEE);
            Transactions.FrmLineOEETransaction objLineOEE = Transactions.FrmLineOEETransaction.GetInstance();
            objLineOEE.MdiParent = this;
            objLineOEE.Show();
            objLineOEE.Activate();
        }

        private void lineOEEActivityMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.FrmLineOEEMaster objLineOEE = Forms.FrmLineOEEMaster.GetInstance();
            objLineOEE.MdiParent = this;
            objLineOEE.Show();
            objLineOEE.Activate();
        }

        private void mOMSignaRoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmMOMRoles objMOMRoles = Forms.frmMOMRoles.GetInstance();
            objMOMRoles.MdiParent = this;
            objMOMRoles.Show();
            objMOMRoles.Activate();
        }

        private void uploadLineOEEMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.FrmUploadLineOEEMaster obj = Forms.FrmUploadLineOEEMaster.GetInstance();
            obj.MdiParent = this;
            obj.Show();
            obj.Activate();
        }

        private void lineOEEActivityRelationMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.FrmLineOEEActivityRelationMaster obj = Forms.FrmLineOEEActivityRelationMaster.GetInstance();
            obj.MdiParent = this;
            obj.Show();
            obj.Activate();
        }

        private void lineOEEDataJunctionReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.FrmLineOEEDataJunctionReport obj = new Reports_Forms.FrmLineOEEDataJunctionReport();
            obj.MdiParent = this;
            obj.Show();
        }

        private void lineOEEFGMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.FrmLineOEEFGMaster obj = Forms.FrmLineOEEFGMaster.GetInstance();
            obj.MdiParent = this;
            obj.Show();
            obj.Activate();
        }

        private void viewUploadLineOEEMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.FrmViewUploadLineOEEMaster obj = Forms.FrmViewUploadLineOEEMaster.GetInstance();
            obj.MdiParent = this;
            obj.Show();
            obj.Activate();
        }

        private void lineOEEUPTdbReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //contain multiple reports
            Reports_Forms.frmLineOEEUPTdbReport obj = new Reports_Forms.frmLineOEEUPTdbReport();
            obj.MdiParent = this;
            obj.Show();
        }

        private void lineOEEGraphReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLineOEEGraphReport obj = new FrmLineOEEGraphReport();
            obj.MdiParent = this;
            obj.Show();
            obj.Activate();
        }

        private void rMParameterwiseReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.FrmRMParameterReport frm = new QTMS.Reports_Forms.FrmRMParameterReport("RM Parameter");
            frm.MdiParent = this;
            frm.Show();
        }

        private void rMControlTypeReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.FrmRMControlTypeReport frm = new QTMS.Reports_Forms.FrmRMControlTypeReport("RM Control Type");
            frm.MdiParent = this;
            frm.Show();
        }

        private void groupMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.FrmGroupMailMaster obj = Forms.FrmGroupMailMaster.GetInstance();
            obj.MdiParent = this;
            obj.Show();
            obj.Activate();
        }

        private void userGroupMasterRelationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.FrmUserGroupRelationmaster obj = Forms.FrmUserGroupRelationmaster.GetInstance();
            obj.MdiParent = this;
            obj.Show();
            obj.Activate();
        }

        private void refSampleMgmtSummaryReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.Report frm = new QTMS.Reports_Forms.Report("RSMgmt_Summary");
            frm.MdiParent = this;
            frm.Show();
        }

        private void fGReferenceManagementToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Transactions.FrmFGReferenceManagement frm = Transactions.FrmFGReferenceManagement.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void physicoChemicalWaterAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.FrmWaterAnalysis_Report frm = new QTMS.Reports_Forms.FrmWaterAnalysis_Report("PhysicoChemicalWaterAnalysis");
            frm.MdiParent = this;
            frm.Show();
        }

        private void pMSupplierCorrectiveNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transactions.frmSupplierCorrectiveNote frm = QTMS.Transactions.frmSupplierCorrectiveNote.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void hPLCReferenceMgmtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transactions.frmHPLCReferenceMgmt frm = QTMS.Transactions.frmHPLCReferenceMgmt.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void pMCOCHistoryReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.FrmPMCOCHistory frm = new Reports_Forms.FrmPMCOCHistory("PMCOCHistory");
            frm.MdiParent = this;
            frm.Show();
        }

        private void transactionReagentReciptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // FrmReagentTransaction.cs
        }

        private void reagentMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.FrmReagentMaster obj = Forms.FrmReagentMaster.GetInstance();
            obj.MdiParent = this;
            obj.Show();
            obj.Activate();
        }

        private void reagentTransactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transactions.FrmReagentTransaction obj = Transactions.FrmReagentTransaction.GetInstance();
            obj.MdiParent = this;
            obj.Show();
            obj.Activate();
        }

        private void reaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transactions.FrmReagentStandardazation obj = Transactions.FrmReagentStandardazation.GetInstance();
            obj.MdiParent = this;
            obj.Show();
            obj.Activate();
        }

        private void reagentConsumptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transactions.FrmReagentConsumption obj = Transactions.FrmReagentConsumption.GetInstance();
            obj.MdiParent = this;
            obj.Show();
            obj.Activate();
        }

        private void dimensionParameterMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.FrmDimensionParameterMaster obj = Forms.FrmDimensionParameterMaster.GetInstance();
            obj.MdiParent = this;
            obj.Show();
            obj.Activate();
        }

        private void reagentModificationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transactions.FrmReagentModification obj = Transactions.FrmReagentModification.GetInstance();
            obj.MdiParent = this;
            obj.Show();
            obj.Activate();
        }

        private void reagentAvailableStockReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.FrmReagentStockReport obj = Reports_Forms.FrmReagentStockReport.GetInstance();
            obj.MdiParent = this;
            obj.Show();
            obj.Activate();
        }

        private void reagentDetailsReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.FrmReagentDetails obj = Reports_Forms.FrmReagentDetails.GetInstance();
            obj.MdiParent = this;
            obj.Show();
            obj.Activate();
        }

        private void reagentReorderLevelReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.FrmReagentRorderLevel obj = Reports_Forms.FrmReagentRorderLevel.GetInstance();
            obj.MdiParent = this;
            obj.Show();
            obj.Activate();
        }

        private void lastProductionFormulaReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.FrmLastProductionFormulaReport frm = new Reports_Forms.FrmLastProductionFormulaReport();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void aOCSheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transactions.FrmAOCSheet obj = Transactions.FrmAOCSheet.GetInstance();
            obj.MdiParent = this;
            obj.Show();
            obj.Activate();
        }

        private void nAtureofACRefMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Forms.FrmNatureofACMaster frm = new Forms.FrmNatureofACMaster();
            //always use this method because it will check is this object null and then it will create object otherwise it will just show it will not create object
            Forms.FrmNatureofACMaster frm = Forms.FrmNatureofACMaster.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void aCMaterialRefMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Forms.FrmMaterialRefMaster frm = new Forms.FrmMaterialRefMaster();
            Forms.FrmMaterialRefMaster frm = Forms.FrmMaterialRefMaster.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void fGPendingReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.FrmFGPendingReport frm = Reports_Forms.FrmFGPendingReport.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.FrmChangeUserPassword obj = new Forms.FrmChangeUserPassword();
            obj.MdiParent = this;
            obj.Show();
            obj.Activate();
        }

        private void fGBulkRejectionDetailsReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.FrmFGBulkRejectionDetailReport frm = new QTMS.Reports_Forms.FrmFGBulkRejectionDetailReport("BulkRejectionDetails");
            frm.MdiParent = this;
            frm.Show();
        }

        private void rMCodeReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Reports_Forms.FrmRMCode_Report frm = new QTMS.Reports_Forms.FrmRMCode_Report("RM_Report");
            Reports_Forms.FRM_RM_CodeReport2 frm = new FRM_RM_CodeReport2();
            frm.MdiParent = this;
            frm.Show();
        }

        private void consumerComplaintTDBYearlyReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.FrmComplaint_TDB_Report_Yearly frm = new QTMS.Reports_Forms.FrmComplaint_TDB_Report_Yearly("Complaint_TDB_Report_Yearly");
            frm.MdiParent = this;
            frm.Show();
        }

        private void pMRejectionDetailReportNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.Report frm = new QTMS.Reports_Forms.Report("PMRejection_Detail_Report_New");
            frm.MdiParent = this;
            frm.Show();
        }

        private void fGRefToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.Report frm = new QTMS.Reports_Forms.Report("FGMgmt_Summary");
            frm.MdiParent = this;
            frm.Show();

        }

        private void bAGManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.BAG frm = Forms.BAG.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //Transactions.BAGViewer frm = Transactions.BAGViewer.GetInstance();
            //frm.MdiParent = this;
            //frm.Show();
            //frm.Activate();
        }

        private void rMAlignmentRreportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.FrmRM_Alignment_Report frm = new FrmRM_Alignment_Report();
            frm.MdiParent = this;
            frm.Show();
        }

        //private void plant2ToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    Transactions.FrmWaterAnalysis_Plant2 frm = QTMS.Transactions.FrmWaterAnalysis_Plant2.GetInstance();
        //    frm.MdiParent = this;
        //    frm.Show();
        //    frm.Activate();
        //}

        //private void plant1ToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    Transactions.FrmWaterAnalysis frm = QTMS.Transactions.FrmWaterAnalysis.GetInstance();
        //    frm.MdiParent = this;
        //    frm.Show();
        //    frm.Activate();
        //}

        private void plant3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transactions.FrmWaterAnalysis_Plant3 frm = QTMS.Transactions.FrmWaterAnalysis_Plant3.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void plantwiseWaterAnalysisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transactions.FrmWaterAnalysis_Plant2 frm = QTMS.Transactions.FrmWaterAnalysis_Plant2.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void pMComponentHistoryReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.FrmPM_Component_History_Report frm = new FrmPM_Component_History_Report();
            frm.MdiParent = this;
            frm.Show();
        }
        //private void unitMasterToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    Forms.FrmUnitMaster frm = Forms.FrmUnitMaster.GetInstance();
        //    frm.MdiParent = this;
        //    frm.Show();
        //    frm.Activate();
        //}

        //private void lineSamplingMasterToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    Forms.FrmScoopSamplingPointMaster frm = FrmScoopSamplingPointMaster.GetInstance();// new FrmScoopSamplingPointMaster();
        //    frm.MdiParent = this;
        //    frm.Show();
        //    frm.Activate();
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            lblMenuName.Text = "Scoop";
            menuStripQTMSH.Visible = false;
            menuStripRMH.Visible = false;
            menuStripPMH.Visible = false;
            menuStripFDAH.Visible = false;
            menuStripOther.Visible = false;
            menuStripLineValidation.Visible = menuStripADMINH.Visible = false;
            menuStripScoop.Visible = true;
        }

        private void lineSamplingPointMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmScoopSamplingPointMaster frm = FrmScoopSamplingPointMaster.GetInstance(); // new FrmScoopSamplingPointMaster();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void uPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmScoopUP frm = FrmScoopUP.GetInstance(); // new QTMS.Transactions.FrmScoopUP();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void scoopTestMethodMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmScoopTestMethodMaster frm = frmScoopTestMethodMaster.GetInstance(); // new frmScoopTestMethodMaster();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void lineSamplingPointInfoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmLine_SamplingPointDetails frm = new frmLine_SamplingPointDetails();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void uPAuthorityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmScoopUPAuthority frm = frmScoopUPAuthority.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void qualityAuthorityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmScoopQualityAuthority frm = frmScoopQualityAuthority.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void QTMSHmasterToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void finalApprovalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFinishedGoodTestUPFinal frm = FrmFinishedGoodTestUPFinal.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void globalFGTDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.FrmScoopReport frm = new FrmScoopReport("GlobalFGTDB");
            frm.MdiParent = this;
            frm.Show();
        }

        private void fGLineTDBReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.FrmScoopReport frm = new FrmScoopReport("FGLineTDB");
            frm.MdiParent = this;
            frm.Show();
        }

        private void fGAnalysisReportToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            QTMS.Scoop.ReportForms.FrmFGAnalysis_Report frm = new QTMS.Scoop.ReportForms.FrmFGAnalysis_Report();
            frm.MdiParent = this;
            frm.Show();
        }

        private void fGAnalysisNotDoneReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QTMS.Scoop.ReportForms.FrmFGanalysisNotDoneReport frm = new QTMS.Scoop.ReportForms.FrmFGanalysisNotDoneReport();
            frm.MdiParent = this;
            frm.Show();
        }

        private void rMRejectionNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRM_Rejection_Note frm = new FrmRM_Rejection_Note();
            frm.MdiParent = this;
            frm.Show();
        }

        private void Mnu_fGSupplierMaster_Click(object sender, EventArgs e)
        {
            FrmFGSupplierMaster frm = new FrmFGSupplierMaster();
            frm.MdiParent = this;
            frm.Show();
        }

        private void bulkTestDeailsSubcontractToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transactions.FrmBulkTestDetailsTransactionSubContract frm = Transactions.FrmBulkTestDetailsTransactionSubContract.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void finishedGoodTestQuality1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transactions.FrmFinishedGoodTestBADDI frm = Transactions.FrmFinishedGoodTestBADDI.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();

        }

        private void btnSubCon_Click(object sender, EventArgs e)
        {
            lblMenuName.Text = "Sub Contractor";
            menuStripQTMSH.Visible = false;
            menuStripRMH.Visible = false;
            menuStripPMH.Visible = false;
            menuStripFDAH.Visible = false;
            menuStripOther.Visible = false;
            menuStripADMINH.Visible = false;
            menuStripLineValidation.Visible = menuStripScoop.Visible = false;
            menuStripSubCon.Visible = true;
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            FrmFGSupplierMaster frm = new FrmFGSupplierMaster();
            frm.MdiParent = this;
            frm.Show();
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {

            Transactions.FrmBulkTestDetailsTransactionSubContract frm = Transactions.FrmBulkTestDetailsTransactionSubContract.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            Transactions.FrmPreservativeTestSubContract frm = Transactions.FrmPreservativeTestSubContract.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();

        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            Transactions.FrmMicrobiologyTestSubContract frm = Transactions.FrmMicrobiologyTestSubContract.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();

        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            Transactions.FrmFinishedGoodTestBADDI frm = Transactions.FrmFinishedGoodTestBADDI.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void finishGoodTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transactions.FrmFinishedGoodTestModification_SubContract frmMod = Transactions.FrmFinishedGoodTestModification_SubContract.GetInstance();
            frmMod.MdiParent = this;
            frmMod.Show();
            frmMod.Activate();
        }

        private void toolStripMenuItem17_Click(object sender, EventArgs e)
        {
            Reports_Forms.FrmFGAnylysisReport_SubContract frmFGAny = new QTMS.Reports_Forms.FrmFGAnylysisReport_SubContract("FGAnalysis");
            frmFGAny.MdiParent = this;
            frmFGAny.Show();
            frmFGAny.Activate();
        }

        private void toolStripMenuItem14_Click(object sender, EventArgs e)
        {
            Reports_Forms.Report_TDB frm = new QTMS.Reports_Forms.Report_TDB("Global_FG_TDB");
            frm.MdiParent = this;
            frm.Show();
        }

        private void fGTransactionAnalysisReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QTMS.Scoop.ReportForms.FrmFG_Transaction_Analysis_Report frm = new QTMS.Scoop.ReportForms.FrmFG_Transaction_Analysis_Report();
            frm.MdiParent = this;
            frm.Show();
        }

        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLineOEESetting frm = new FrmLineOEESetting();
            frm.MdiParent = this;
            frm.Show();
        }

        private void tRRMCodeHalalReport_Click(object sender, EventArgs e)
        {
            SubContracttor_Report.FrmRMCode_Report frm = new SubContracttor_Report.FrmRMCode_Report();
            frm.MdiParent = this;
            frm.Show();
        }

        private void retainerLocationReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SubContracttor_Report.FrmFGRetainerSampleLocation_Report_Subcontract frm = new QTMS.SubContracttor_Report.FrmFGRetainerSampleLocation_Report_Subcontract("Retainer Sample Location");
            frm.MdiParent = this;
            frm.Show();
        }

        private void finishedGoodSummaryReportToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            SubContracttor_Report.FrmFinishedGoodSummary_Report_Subcontract frm = new QTMS.SubContracttor_Report.FrmFinishedGoodSummary_Report_Subcontract("FinishedGoodSummary Report");
            frm.MdiParent = this;
            frm.Show();
        }

        private void fGMfgWoAnalysisReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.FrmFGAnylysisReport_MfgWo_SubContract frm = new QTMS.Reports_Forms.FrmFGAnylysisReport_MfgWo_SubContract("FGAnylysis_MfgWo Report");
            frm.MdiParent = this;
            frm.Show();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            Reports_Forms.FrmFGRetainerSampleLocation_Report_PkgWo frm = new QTMS.Reports_Forms.FrmFGRetainerSampleLocation_Report_PkgWo("Retainer Sample Location");
            frm.MdiParent = this;
            frm.Show();
        }

        private void aOCReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.Report frm = new QTMS.Reports_Forms.Report("AOC_Report");
            frm.MdiParent = this;
            frm.Show();
        }

        private void testFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmOOSReport frm = new FrmOOSReport("OOS Report", -1);
            frm.MdiParent = this;
            frm.Show();

            //FrmTest frm = new FrmTest();
            //frm.MdiParent = this;
            //frm.Show();


        }

        private void btnLineValidation_Click(object sender, EventArgs e)
        {
            lblMenuName.Text = "Line Validation";
            menuStripQTMSH.Visible = false;
            menuStripRMH.Visible = false;
            menuStripPMH.Visible = false;
            menuStripFDAH.Visible = false;
            menuStripOther.Visible = false;
            menuStripADMINH.Visible = false;
            menuStripScoop.Visible = false;
            menuStripSubCon.Visible = false;
            menuStripLineValidation.Visible = true;
            menuStripMettler.Visible = false;
        }


        private void lineValidationTransactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLineValidationMasterNew frm = FrmLineValidationMasterNew.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void LineValidationTransactionformtoolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void LineValidationmodificationToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void lineTransactionToolStripMenuItem_Click(object sender, EventArgs e)
        {           
            //FrmLineTransaction frm = new FrmLineTransaction(IsForModify);
            FrmLineTransactionNew frm = FrmLineTransactionNew.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void lineTransactionModificationToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            FrmLineTransactionModification frm = FrmLineTransactionModification.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void lineViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLineView frm = FrmLineView.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void lineTransactionReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.LineValidation.FrmLineTransactionReport frm = Reports_Forms.LineValidation.FrmLineTransactionReport.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void LineValidationtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            LineValidation.FrmLineMaster frm = LineValidation.FrmLineMaster.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void HistorytoolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLineTransactionRejectionReport frm = FrmLineTransactionRejectionReport.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void rMBarcodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.FrmRMBarcodeReport frm = Reports_Forms.FrmRMBarcodeReport.GetInstance("RMBarcodeReport");
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void oOSLogReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.Report frm = new QTMS.Reports_Forms.Report("OOS_Log_Report");
            frm.MdiParent = this;
            frm.Show();
        }

        private void oOSDetailsReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmOOSReport frm = new FrmOOSReport("OOS Report", -1);
            frm.MdiParent = this;
            frm.Show();
        }

        private void lineDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLineDetail frm = FrmLineDetail.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void lineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.LineValidation.FrmLineValidationMasterReport frm = Reports_Forms.LineValidation.FrmLineValidationMasterReport.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();   
        }

        private void lineRejectionHistoryReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLineTransactionRejectionReport frm = FrmLineTransactionRejectionReport.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();   
        }

        private void consumerComplaintResponceReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.ComplaintSummary_Report frm = new QTMS.Reports_Forms.ComplaintSummary_Report("ComplaintResponce");
            frm.MdiParent = this;
            frm.Show();
        }

        private void fGDueReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.Report frm = new QTMS.Reports_Forms.Report("FinishedGoodDue");
            frm.MdiParent = this;
            frm.Show();
        }

        private void rMDueReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.Report frm = new QTMS.Reports_Forms.Report("RMDue");
            frm.MdiParent = this;
            frm.Show();
        }

        private void pMDueReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.Report frm = new QTMS.Reports_Forms.Report("PMDue");
            frm.MdiParent = this;
            frm.Show();
        }

        private void fGMasterReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.FrmFinishedGoodsDetails_Report frm = new QTMS.Reports_Forms.FrmFinishedGoodsDetails_Report("FGMaster_Report");
            frm.MdiParent = this;
            frm.Show();
        }

        private void formulaMasterReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.FrmFinishedGoodsDetails_Report frm = new QTMS.Reports_Forms.FrmFinishedGoodsDetails_Report("FormulaMaster_Report");
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnMettler_Click(object sender, EventArgs e)
        {
            lblMenuName.Text = "Mettler";
            menuStripQTMSH.Visible = false;
            menuStripRMH.Visible = false;
            menuStripPMH.Visible = false;
            menuStripFDAH.Visible = false;
            menuStripOther.Visible = false;
            menuStripADMINH.Visible = false;
            menuStripScoop.Visible = false;
            menuStripLineValidation.Visible = menuStripSubCon.Visible = false;
            menuStripMettler.Visible = true;

           
        }

        private void oEEPUEExcelUploadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
                this.ActiveMdiChild.Close();
            Forms.FrmOEEPURUpload frm = new FrmOEEPURUpload();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void madeLastProductionFormulaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
                this.ActiveMdiChild.Close();
            FrmLastproductionformulmade frm = new FrmLastproductionformulmade();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void bulkQuaterReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
                this.ActiveMdiChild.Close();
            FrmBulkQuater_Report frm = new FrmBulkQuater_Report();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void bulkValidateNonvalidatedMenuItem6_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
                this.ActiveMdiChild.Close();
            FrmBulkBatchsizeValidate_Report frm = new FrmBulkBatchsizeValidate_Report();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void retainerLocationDistractedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
                this.ActiveMdiChild.Close();
            FrmRetainerLocationDistracted frm = new FrmRetainerLocationDistracted();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void destructionDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
                this.ActiveMdiChild.Close();
            Reports_Forms.FrmDectructionDetails frm = new QTMS.Reports_Forms.FrmDectructionDetails("Destruction Location Details");
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void DestructedLocation_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
                this.ActiveMdiChild.Close();
            Reports_Forms.Report frm = new QTMS.Reports_Forms.Report("DestructedLocation");
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void fGOutSourceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
                this.ActiveMdiChild.Close();
            FrmFGOutSource frm = new FrmFGOutSource();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void fGOutSourceReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
                this.ActiveMdiChild.Close();
            FrmFGOutSource_Report frm = new FrmFGOutSource_Report();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void rMRejectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
                this.ActiveMdiChild.Close();
            Reports_Forms.FrmRM_Rejection_Note_Details frm = new QTMS.Reports_Forms.FrmRM_Rejection_Note_Details("Rejection Note Details");
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void tankSelectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
                this.ActiveMdiChild.Close();
            FrmTankSelection frm = new FrmTankSelection();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void tankSelectionReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
                this.ActiveMdiChild.Close();
            Reports_Forms.FrmTankSelectionReport frm = new QTMS.Reports_Forms.FrmTankSelectionReport("Tank Selection Report");
            frm.MdiParent = this;
            frm.Show();
        }

        private void fDARMAnalysisReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.FrmRM_Analysis_Report frm = new QTMS.Reports_Forms.FrmRM_Analysis_Report("FDA_RM_Analysis");
            frm.MdiParent = this;
            frm.Show();
        }

        private void reagentSupplierMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
                this.ActiveMdiChild.Close();
            Forms.FrmReagentSupplierMaster frm = Forms.FrmReagentSupplierMaster.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void reagentSupplierPOMappingMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
                this.ActiveMdiChild.Close();
            Forms.FrmReagentSupplierPOMappingMaster frm = Forms.FrmReagentSupplierPOMappingMaster.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void normalWeightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
                this.ActiveMdiChild.Close();
            //Forms.FrmMettler frm = new FrmMettler();
            FrmMettlerAutoWeight frm = new FrmMettlerAutoWeight();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
            this.panelMenu.BackColor = Color.FromArgb(224, 238, 243);
        }

        private void tareWeightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
                this.ActiveMdiChild.Close();
            //FrmMettlerTareWeight frm = new FrmMettlerTareWeight();
            FrmMettlerTareWeight_New frm = new FrmMettlerTareWeight_New();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
            this.panelMenu.BackColor = Color.FromArgb(224, 238, 243);
        }

        private void reagentLabelRePrintReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
                this.ActiveMdiChild.Close();
            FrmReagentLabelReprint_Report frm = new FrmReagentLabelReprint_Report();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
            this.panelMenu.BackColor = Color.FromArgb(224, 238, 243);
        }

        private void PendingDestructLocationtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.FrmFGRetainerSampleLocation_Report frm = new QTMS.Reports_Forms.FrmFGRetainerSampleLocation_Report("Pending Destructed Location");
            frm.MdiParent = this;
            frm.Show();
        }

        private void sPCMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
                this.ActiveMdiChild.Close();
            FrmSPCMaster frm = new FrmSPCMaster();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
            this.panelMenu.BackColor = Color.FromArgb(224, 238, 243);
        }

        private void manualWeightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
                this.ActiveMdiChild.Close();
            //FrmMettlerManualWeight frm = new FrmMettlerManualWeight();
            FrmMettlerManualWeight_New frm = new FrmMettlerManualWeight_New();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
            this.panelMenu.BackColor = Color.FromArgb(224, 238, 243);
        }

        private void FGDeclarationLotNoReporttoolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.Report frm = new QTMS.Reports_Forms.Report("DeclarationLotNo");
            frm.MdiParent = this;
            frm.Show();
        }

        private void panelMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void stabilityTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transactions.FrmStabilityTest frm = Transactions.FrmStabilityTest.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void stabiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.FrmStabilityTest_Report frm = new QTMS.Reports_Forms.FrmStabilityTest_Report("StabilityTest_Report");
            frm.MdiParent = this;
            frm.Show();
        }

        private void stabilityTestConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transactions.FrmStabilityTestConfiguration frm = Transactions.FrmStabilityTestConfiguration.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void ageingTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transactions.FrmAgeingTest frm = Transactions.FrmAgeingTest.GetInstance();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void ageingTestReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.FrmAgeingTest_Report frm = new QTMS.Reports_Forms.FrmAgeingTest_Report("AgeingTest_Report");
            frm.MdiParent = this;
            frm.Show();
        }

        private void stabilityTraceEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Forms.FrmStabilityTraceReport frm = new QTMS.Reports_Forms.FrmStabilityTraceReport();
            frm.MdiParent = this;
            frm.Show();
        }

        private void lineOEEMachineMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
                this.ActiveMdiChild.Close();
            FrmLineOEEMachineMaster frm = new FrmLineOEEMachineMaster();
            frm.MdiParent = this;
            frm.Show();
        }

        private void lineOEEBreakDownReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
                this.ActiveMdiChild.Close();
            FrmLineOEEBreackDownReport frm = new FrmLineOEEBreackDownReport();
            frm.MdiParent = this;
            frm.Show();
        }

        public void demoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Transactions.frmHourWiseActivity frm = new Transactions.frmHourWiseActivity();
            //frm.MdiParent = this;
            //frm.Show();
        }
        

        

       



    }
}
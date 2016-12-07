﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnifiedMedicalLanguageSystem.Models.Enums
{
    public enum RootSource
    {
        /// <summary>
        /// Alternative Billing Concepts
        /// </summary>
        ALT,
        /// <summary>
        /// Authorized Osteopathic Thesaurus
        /// </summary>
        AOT,
        /// <summary>
        /// Anatomical Therapeutic Chemical Classification System 
        /// </summary>
        ATC,
        /// <summary>
        /// Clinical Care Classification
        /// </summary>
        CCC,
        /// <summary>
        /// Clinical Classifications Software
        /// </summary>
        CCS_10,
        /// <summary>
        /// Current Dental Terminology
        /// </summary>
        CDT,
        /// <summary>
        /// Consumer Health Vocabulary
        /// </summary>
        CHV,
        /// <summary>
        /// Medical Entities Dictionary
        /// </summary>
        CPM,
        /// <summary>
        /// Current Procedural Terminology
        /// </summary>
        CPT,
        /// <summary>
        /// CRISP Thesaurus
        /// </summary>
        CSP,
        /// <summary>
        /// Vaccines Administered
        /// </summary>
        CVX,
        /// <summary>
        /// German translation of ICD10
        /// </summary>
        DMDICD10,
        /// <summary>
        /// DrugBank
        /// </summary>
        DRUGBANK,
        /// <summary>
        /// Diagnostic and Statistical Manual of Mental Disorders, Fifth Edition (DSM-5)
        /// </summary>
        [RootSourceInfo("DSM-5")]
        DSM_5,
        /// <summary>
        /// Foundational Model of Anatomy Ontology
        /// </summary>
        FMA,
        /// <summary>
        /// Gene Ontology
        /// </summary>
        GO,
        /// <summary>
        /// Gold Standard Drug Database
        /// </summary>
        GS,
        /// <summary>
        /// Current Dental Terminology (CDT)
        /// </summary>
        HCDT,
        /// <summary>
        /// Healthcare Common Procedure Coding System
        /// </summary>
        HCPCS,
        /// <summary>
        /// HCPCS Version of Current Procedural Terminology (CPT)
        /// </summary>
        HCPT,
        /// <summary>
        /// HUGO Gene Nomenclature Committee
        /// </summary>
        HGNC,
        /// <summary>
        /// HL7 Vocabulary Version 2.5
        /// </summary>
        [RootSourceInfo("HL7V2.5")]
        HL7V2_5,
        /// <summary>
        /// HL7 Vocabulary Version 3.0
        /// </summary>
        [RootSourceInfo("HL7V3.0")]
        HL7V3_0,
        /// <summary>
        /// Human Phenotype Ontology
        /// </summary>
        HPO,
        /// <summary>
        /// ICD10
        /// </summary>
        ICD10,
        /// <summary>
        /// ICD10, American English Equivalents 	
        /// </summary>
        ICD10AE,
        /// <summary>
        /// International Statistical Classification of Diseases and Related Health Problems, 10th Revision, Australian Modification
        /// </summary>
        ICD10AM,
        ICD10AMAE,
        ICD10CM,
        ICD10DUT,
        ICD10PCS,
        ICD9CM,
        ICF,
        [RootSourceInfo("ICF-CY")]
        ICF_CY,
        ICNP,
        ICPC2EDUT,
        ICPC2EENG,
        ICPC2ICD10DUT,
        ICPC2ICD10ENG,
        ICPC2P,
        KCD5,
        LCH_NW,
        LNC,
        [RootSourceInfo("LNC-DE-AT")]
        LNC_DE_AT,
        [RootSourceInfo("LNC-DE-CH")]
        LNC_DE_CH,
        [RootSourceInfo("LNC-DE-DE")]
        LNC_DE_DE,
        [RootSourceInfo("LNC-EL-GR")]
        LNC_EL_GR,
        [RootSourceInfo("LNC-ES-AR")]
        LNC_ES_AR,
        [RootSourceInfo("LNC-ES-CH")]
        LNC_ES_CH,
        [RootSourceInfo("LNC-ES-ES")]
        LNC_ES_ES,
        [RootSourceInfo("LNC-ET-EE")]
        LNC_ET_EE,
        [RootSourceInfo("LNC-FR-BE")]
        LNC_FR_BE,
        [RootSourceInfo("LNC-FR-CA")]
        LNC_FR_CA,
        [RootSourceInfo("LNC-FR-CH")]
        LNC_FR_CH,
        [RootSourceInfo("LNC-FR-FR")]
        LNC_FR_FR,
        [RootSourceInfo("LNC-IT-CH")]
        LNC_IT_CH,
        [RootSourceInfo("LNC-IT-IT")]
        LNC_IT_IT,
        [RootSourceInfo("LNC-KO-KR")]
        LNC_KO_KR,
        [RootSourceInfo("LNC-NL-NL")]
        LNC_NL_NL,
        [RootSourceInfo("LNC-PT-BR")]
        LNC_PT_BR,
        [RootSourceInfo("LNC-RU-RU")]
        LNC_RU_RU,
        [RootSourceInfo("LNC-TR-TR")]
        LNC_TR_TR,
        [RootSourceInfo("LNC-ZH-CN")]
        LNC_ZH_CN,
        MDDB,
        MDR,
        MDRCZE,
        MDRDUT,
        MDRFRE,
        MDRGER,
        MDRHUN,
        MDRITA,
        MDRJPN,
        MDRPOR,
        MDRSPA,
        MEDCIN,
        MEDLINEPLUS,
        MMSL,
        MMX,
        MSH,
        MSHCZE,
        MSHDUT,
        MSHFIN,
        MSHFRE,
        MSHGER,
        MSHITA,
        MSHJPN,
        MSHLAV,
        MSHNOR,
        MSHPOL,
        MSHPOR,
        MSHRUS,
        MSHSCR,
        MSHSPA,
        MSHSWE,
        MTH,
        MTHCMSFRF,
        MTHHH,
        MTHICD9,
        MTHICPC2EAE,
        MTHICPC2ICD10AE,
        MTHSPL,
        MVX,
        [RootSourceInfo("NANDA-I")]
        NANDA_I,
        NCBI,
        NCI,
        NCI_BRIDG,
        NCI_BioC,
        NCI_CDC,
        NCI_CDISC,
        NCI_CRCH,
        NCI_CTCAE,
        [RootSourceInfo("NCI_CTEP-SDC")]
        NCI_CTEP_SDC,
        NCI_CareLex,
        NCI_DCP,
        NCI_DICOM,
        NCI_DTP,
        NCI_FDA,
        NCI_GAIA,
        NCI_GENC,
        NCI_ICH,
        NCI_JAX,
        NCI_KEGG,
        [RootSourceInfo("NCI_NCI-GLOSS")]
        NCI_NCI_GLOSS,
        [RootSourceInfo("NCI_NCI-HL7")]
        NCI_NCI_HL7,
        NCI_NCPDP,
        NCI_NICHD,
        [RootSourceInfo("NCI_PI-RADS")]
        NCI_PI_RADS,
        NCI_PID,
        NCI_RENI,
        NCI_UCUM,
        NCI_ZFin,
        NDDF,
        NDFRT,
        NDFRT_FDASPL,
        NDFRT_FMTSME,
        NEU,
        NIC,
        NOC,
        NUCCPT,
        OMIM,
        OMS,
        PDQ,
        PNDS,
        PSY,
        RXNORM,
        SCTSPA,
        SNOMEDCT_US,
        SNOMEDCT_VET,
        SOP,
        SPN,
        SRC,
        TKMT,
        UMD,
        USPMG,
        UWDA,
        VANDF
    }
}
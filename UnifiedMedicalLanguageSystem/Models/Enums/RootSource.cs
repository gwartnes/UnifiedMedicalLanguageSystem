namespace UnifiedMedicalLanguageSystem
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
        ICD10AM,        /// <summary>        /// International Statistical Classification of Diseases and Related Health Problems, Australian Modification, Americanized English Equivalents        /// </summary>
        ICD10AMAE,        /// <summary>        /// International Classification of Diseases, 10th Edition, Clinical Modification        /// </summary>
        ICD10CM,        /// <summary>        /// ICD10, Dutch Translation        /// </summary>
        ICD10DUT,        /// <summary>        /// ICD-10-PCS        /// </summary>
        ICD10PCS,        /// <summary>        /// International Classification of Diseases, Ninth Revision, Clinical Modification        /// </summary>
        ICD9CM,        /// <summary>        /// International Classification of Functioning, Disability and Health        /// </summary>
        ICF,        /// <summary>        /// International Classification of Functioning, Disability and Health for Children and Youth        /// </summary>
        [RootSourceInfo("ICF-CY")]
        ICF_CY,        /// <summary>        /// International Classification for Nursing Practice        /// </summary>
        ICNP,        /// <summary>        /// International Classification of Primary Care 2nd Edition, Electronic, 2E, Dutch Translation        /// </summary>
        ICPC2EDUT,        /// <summary>        /// International Classification of Primary Care 2nd Edition, Electronic, 2E        /// </summary>
        ICPC2EENG,        /// <summary>        /// ICPC2-ICD10 Thesaurus, Dutch Translation        /// </summary>
        ICPC2ICD10DUT,        /// <summary>        /// ICPC2 - ICD10 Thesaurus        /// </summary>
        ICPC2ICD10ENG,        /// <summary>        /// ICPC-2 PLUS        /// </summary>
        ICPC2P,        /// <summary>        /// Korean Standard Classification of Disease Version 5        /// </summary>
        KCD5,        /// <summary>        /// Library of Congress Subject Headings, Northwestern University Subset        /// </summary>
        LCH_NW,        /// <summary>        /// LOINC and its 20 translations        /// </summary>
        LNC,        /// <summary>        /// LOINC and its 20 translations        /// </summary>
        [RootSourceInfo("LNC-DE-AT")]
        LNC_DE_AT,        /// <summary>        /// LOINC and its 20 translations        /// </summary>
        [RootSourceInfo("LNC-DE-CH")]
        LNC_DE_CH,        /// <summary>        /// LOINC and its 20 translations        /// </summary>
        [RootSourceInfo("LNC-DE-DE")]
        LNC_DE_DE,        /// <summary>        /// LOINC and its 20 translations        /// </summary>
        [RootSourceInfo("LNC-EL-GR")]
        LNC_EL_GR,        /// <summary>        /// LOINC and its 20 translations        /// </summary>
        [RootSourceInfo("LNC-ES-AR")]
        LNC_ES_AR,        /// <summary>        /// LOINC and its 20 translations        /// </summary>
        [RootSourceInfo("LNC-ES-CH")]
        LNC_ES_CH,        /// <summary>        /// LOINC and its 20 translations        /// </summary>
        [RootSourceInfo("LNC-ES-ES")]
        LNC_ES_ES,        /// <summary>        /// LOINC and its 20 translations        /// </summary>
        [RootSourceInfo("LNC-ET-EE")]
        LNC_ET_EE,        /// <summary>        /// LOINC and its 20 translations        /// </summary>
        [RootSourceInfo("LNC-FR-BE")]
        LNC_FR_BE,        /// <summary>        /// LOINC and its 20 translations        /// </summary>
        [RootSourceInfo("LNC-FR-CA")]
        LNC_FR_CA,        /// <summary>        /// LOINC and its 20 translations        /// </summary>
        [RootSourceInfo("LNC-FR-CH")]
        LNC_FR_CH,        /// <summary>        /// LOINC and its 20 translations        /// </summary>
        [RootSourceInfo("LNC-FR-FR")]
        LNC_FR_FR,        /// <summary>        /// LOINC and its 20 translations        /// </summary>
        [RootSourceInfo("LNC-IT-CH")]
        LNC_IT_CH,        /// <summary>        /// LOINC and its 20 translations        /// </summary>
        [RootSourceInfo("LNC-IT-IT")]
        LNC_IT_IT,        /// <summary>        /// LOINC and its 20 translations        /// </summary>
        [RootSourceInfo("LNC-KO-KR")]
        LNC_KO_KR,        /// <summary>        /// LOINC and its 20 translations        /// </summary>
        [RootSourceInfo("LNC-NL-NL")]
        LNC_NL_NL,        /// <summary>        /// LOINC and its 20 translations        /// </summary>
        [RootSourceInfo("LNC-PT-BR")]
        LNC_PT_BR,        /// <summary>        /// LOINC and its 20 translations        /// </summary>
        [RootSourceInfo("LNC-RU-RU")]
        LNC_RU_RU,        /// <summary>        /// LOINC and its 20 translations        /// </summary>
        [RootSourceInfo("LNC-TR-TR")]
        LNC_TR_TR,        /// <summary>        /// LOINC and its 20 translations        /// </summary>
        [RootSourceInfo("LNC-ZH-CN")]
        LNC_ZH_CN,        /// <summary>        /// Master Drug Data Base        /// </summary>
        MDDB,        /// <summary>        /// Medical Dictionary for Regulatory Activities Terminology (MedDRA) and its 9 translations        /// </summary>
        MDR,        /// <summary>        /// Medical Dictionary for Regulatory Activities Terminology (MedDRA) and its 9 translations        /// </summary>
        MDRCZE,        /// <summary>        /// Medical Dictionary for Regulatory Activities Terminology (MedDRA) and its 9 translations        /// </summary>
        MDRDUT,        /// <summary>        /// Medical Dictionary for Regulatory Activities Terminology (MedDRA) and its 9 translations        /// </summary>
        MDRFRE,        /// <summary>        /// Medical Dictionary for Regulatory Activities Terminology (MedDRA) and its 9 translations        /// </summary>
        MDRGER,        /// <summary>        /// Medical Dictionary for Regulatory Activities Terminology (MedDRA) and its 9 translations        /// </summary>
        MDRHUN,        /// <summary>        /// Medical Dictionary for Regulatory Activities Terminology (MedDRA) and its 9 translations        /// </summary>
        MDRITA,        /// <summary>        /// Medical Dictionary for Regulatory Activities Terminology (MedDRA) and its 9 translations        /// </summary>
        MDRJPN,        /// <summary>        /// Medical Dictionary for Regulatory Activities Terminology (MedDRA) and its 9 translations        /// </summary>
        MDRPOR,        /// <summary>        /// Medical Dictionary for Regulatory Activities Terminology (MedDRA) and its 9 translations        /// </summary>
        MDRSPA,        /// <summary>        /// MEDCIN        /// </summary>
        MEDCIN,        /// <summary>        /// MedlinePlus Health Topics        /// </summary>
        MEDLINEPLUS,        /// <summary>        /// Multum MediSource Lexicon        /// </summary>
        MMSL,        /// <summary>        /// Micromedex RED BOOK        /// </summary>
        MMX,        /// <summary>        /// Medical Subject Headings and its 15 translations        /// </summary>
        MSH,        /// <summary>        /// Medical Subject Headings and its 15 translations        /// </summary>
        MSHCZE,        /// <summary>        /// Medical Subject Headings and its 15 translations        /// </summary>
        MSHDUT,        /// <summary>        /// Medical Subject Headings and its 15 translations        /// </summary>
        MSHFIN,        /// <summary>        /// Medical Subject Headings and its 15 translations        /// </summary>
        MSHFRE,        /// <summary>        /// Medical Subject Headings and its 15 translations        /// </summary>
        MSHGER,        /// <summary>        /// Medical Subject Headings and its 15 translations        /// </summary>
        MSHITA,        /// <summary>        /// Medical Subject Headings and its 15 translations        /// </summary>
        MSHJPN,        /// <summary>        /// Medical Subject Headings and its 15 translations        /// </summary>
        MSHLAV,        /// <summary>        /// Medical Subject Headings and its 15 translations        /// </summary>
        MSHNOR,        /// <summary>        /// Medical Subject Headings and its 15 translations        /// </summary>
        MSHPOL,        /// <summary>        /// Medical Subject Headings and its 15 translations        /// </summary>
        MSHPOR,        /// <summary>        /// Medical Subject Headings and its 15 translations        /// </summary>
        MSHRUS,        /// <summary>        /// Medical Subject Headings and its 15 translations        /// </summary>
        MSHSCR,        /// <summary>        /// Medical Subject Headings and its 15 translations        /// </summary>
        MSHSPA,        /// <summary>        /// Medical Subject Headings and its 15 translations        /// </summary>
        MSHSWE,        /// <summary>        /// UMLS Metathesaurus        /// </summary>
        MTH,        /// <summary>        /// Metathesaurus Forms of CMS Formulary Reference File        /// </summary>
        MTHCMSFRF,        /// <summary>        /// Metathesaurus HCPCS Hierarchical Terms        /// </summary>
        MTHHH,        /// <summary>        /// International Classification of Diseases, Ninth Revision, Clinical Modification, Metathesaurus additional entry terms        /// </summary>
        MTHICD9,        /// <summary>        /// International Classification of Primary Care 2nd Edition, Electronic, 2E, American English Equivalents        /// </summary>
        MTHICPC2EAE,        /// <summary>        /// ICPC2 - ICD10 Thesaurus, American English Equivalents        /// </summary>
        MTHICPC2ICD10AE,        /// <summary>        /// Metathesaurus FDA Structured Product Labels        /// </summary>
        MTHSPL,        /// <summary>        /// Manufacturers of Vaccines        /// </summary>
        MVX,        /// <summary>        /// NANDA-I Taxonomy II        /// </summary>
        [RootSourceInfo("NANDA-I")]
        NANDA_I,        /// <summary>        /// NCBI Taxonomy        /// </summary>
        NCBI,        /// <summary>        /// NCI Thesaurus and its 26 subsources        /// </summary>
        NCI,        /// <summary>        /// NCI Thesaurus and its 26 subsources        /// </summary>
        NCI_BRIDG,        /// <summary>        /// NCI Thesaurus and its 26 subsources        /// </summary>
        NCI_BioC,        /// <summary>        /// NCI Thesaurus and its 26 subsources        /// </summary>
        NCI_CDC,        /// <summary>        /// NCI Thesaurus and its 26 subsources        /// </summary>
        NCI_CDISC,        /// <summary>        /// NCI Thesaurus and its 26 subsources        /// </summary>
        NCI_CRCH,        /// <summary>        /// NCI Thesaurus and its 26 subsources        /// </summary>
        NCI_CTCAE,        /// <summary>        /// NCI Thesaurus and its 26 subsources        /// </summary>
        [RootSourceInfo("NCI_CTEP-SDC")]
        NCI_CTEP_SDC,        /// <summary>        /// NCI Thesaurus and its 26 subsources        /// </summary>
        NCI_CareLex,        /// <summary>        /// NCI Thesaurus and its 26 subsources        /// </summary>
        NCI_DCP,        /// <summary>        /// NCI Thesaurus and its 26 subsources        /// </summary>
        NCI_DICOM,        /// <summary>        /// NCI Thesaurus and its 26 subsources        /// </summary>
        NCI_DTP,        /// <summary>        /// NCI Thesaurus and its 26 subsources        /// </summary>
        NCI_FDA,        /// <summary>        /// NCI Thesaurus and its 26 subsources        /// </summary>
        NCI_GAIA,        /// <summary>        /// NCI Thesaurus and its 26 subsources        /// </summary>
        NCI_GENC,        /// <summary>        /// NCI Thesaurus and its 26 subsources        /// </summary>
        NCI_ICH,        /// <summary>        /// NCI Thesaurus and its 26 subsources        /// </summary>
        NCI_JAX,        /// <summary>        /// NCI Thesaurus and its 26 subsources        /// </summary>
        NCI_KEGG,        /// <summary>        /// NCI Thesaurus and its 26 subsources        /// </summary>
        [RootSourceInfo("NCI_NCI-GLOSS")]
        NCI_NCI_GLOSS,        /// <summary>        /// NCI Thesaurus and its 26 subsources        /// </summary>
        [RootSourceInfo("NCI_NCI-HL7")]
        NCI_NCI_HL7,        /// <summary>        /// NCI Thesaurus and its 26 subsources        /// </summary>
        NCI_NCPDP,        /// <summary>        /// NCI Thesaurus and its 26 subsources        /// </summary>
        NCI_NICHD,        /// <summary>        /// NCI Thesaurus and its 26 subsources        /// </summary>
        [RootSourceInfo("NCI_PI-RADS")]
        NCI_PI_RADS,        /// <summary>        /// NCI Thesaurus and its 26 subsources        /// </summary>
        NCI_PID,        /// <summary>        /// NCI Thesaurus and its 26 subsources        /// </summary>
        NCI_RENI,        /// <summary>        /// NCI Thesaurus and its 26 subsources        /// </summary>
        NCI_UCUM,        /// <summary>        /// NCI Thesaurus and its 26 subsources        /// </summary>
        NCI_ZFin,        /// <summary>        /// FDB MedKnowledge (formerly NDDF Plus)        /// </summary>
        NDDF,        /// <summary>        /// National Drug File        /// </summary>
        NDFRT,        /// <summary>        /// National Drug File - FDASPL        /// </summary>
        NDFRT_FDASPL,        /// <summary>        /// National Drug File - FMTSME        /// </summary>
        NDFRT_FMTSME,        /// <summary>        /// NeuroNames        /// </summary>
        NEU,        /// <summary>        /// Nursing Interventions Classification (NIC)        /// </summary>
        NIC,        /// <summary>        /// Nursing Outcomes Classification        /// </summary>
        NOC,        /// <summary>        /// National Uniform Claim Committee - Health Care Provider Taxonomy        /// </summary>
        NUCCPT,        /// <summary>        /// Online Mendelian Inheritance in Man        /// </summary>
        OMIM,        /// <summary>        /// Omaha System        /// </summary>
        OMS,        /// <summary>        /// Physician Data Query        /// </summary>
        PDQ,        /// <summary>        /// Perioperative Nursing Data Set        /// </summary>
        PNDS,        /// <summary>        /// Thesaurus of Psychological Index Terms        /// </summary>
        PSY,        /// <summary>        /// RxNorm Vocabulary        /// </summary>
        RXNORM,        /// <summary>        /// SNOMED Clinical Terms, Spanish Language Edition        /// </summary>
        SCTSPA,        /// <summary>        /// US Edition of SNOMED CT®        /// </summary>
        SNOMEDCT_US,        /// <summary>        /// Veterinary Extension to SNOMED CT®        /// </summary>
        SNOMEDCT_VET,        /// <summary>        /// Source of Payment Typology        /// </summary>
        SOP,        /// <summary>        /// Standard Product Nomenclature        /// </summary>
        SPN,        /// <summary>        /// Metathesaurus Source Terminology Names        /// </summary>
        SRC,        /// <summary>        /// Traditional Korean Medical Terms        /// </summary>
        TKMT,        /// <summary>        /// UMDNS: product category thesaurus        /// </summary>
        UMD,        /// <summary>        /// USP Model Guidelines        /// </summary>
        USPMG,        /// <summary>        /// University of Washington Digital Anatomist        /// </summary>
        UWDA,        /// <summary>        /// Veterans Health Administration National Drug File        /// </summary>
        VANDF
    }
}

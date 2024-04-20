using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Globalization;
using TextBoxTime;

#pragma warning disable CS1591
namespace MyBiblioCDs
{
    /// <summary>
    /// For the creation of dictionaries.
    /// </summary>
    public static class Languages
    {
        static public string old_btnsaveInfo = string.Empty;
        static public string btnCancel = string.Empty;
        static public string btnListFiles = string.Empty;
        static public string btnNote = string.Empty;
        static public string btnsave = string.Empty;
        static public string btnSaveAll = string.Empty;
        static public string btnStop = string.Empty;
        static public string ChkNotIncludeAutorun = string.Empty;
        static public string chkWordIndex = string.Empty;
        static public string lbCdName = string.Empty;
        static public string lbCdNummer = string.Empty;
        static public string lbCreationDate = string.Empty;
        static public string lbMediaType = string.Empty;
        static public string lbPosCD = string.Empty;
        static public string lbSelectDrive = string.Empty;
        static public string lbCdNote = string.Empty;
        static public string menuEdit = string.Empty;
        static public string menuitCancel = string.Empty;
        static public string menuitExit = string.Empty;
        static public string menuFile = string.Empty;
        static public string menuitNew = string.Empty;
        static public string menuitSaveAll = string.Empty;
        static public string menuitSaveInfo = string.Empty;
        static public string menuitSavePreview = string.Empty;
        static public string menuitShowExplorer = string.Empty;
        static public string menuTools = string.Empty;
        static public string msgSecurityException = string.Empty;
        static public string msgThekeyIsLocked = string.Empty;
        static public string toolpHideInfo = string.Empty;
        static public string toolpRightClickForZoom = string.Empty;
        static public string toolpSavesInfo = string.Empty;
        static public string toolpShowInfo = string.Empty;
        static public string menuitLanguage = string.Empty;
        static public string toolpListandAnalyzeFiles = string.Empty;
        static public string msgUnauthorizedAccessException = string.Empty;
        static public string menuitOptions = string.Empty;
        static public string menuitAbout = string.Empty;
        static public string msgFormatTimeIncorrect = string.Empty;
        static public string msgInternetConnection = string.Empty;
        static public string msgCDNotFound = string.Empty;
        static public string msgNameCDnotFound = string.Empty;
        static public string msgNameArtistNotFound = string.Empty;
        static public string nameCaptionmsgBox = string.Empty;
        static public string msgNameLandNotFound = string.Empty;
        static public string nameCaptionLand = string.Empty;
        static public string nameCapGenre = string.Empty;
        static public string msgGenreMiss = string.Empty;
        static public string msgMissngData = string.Empty;
        static public string msgFormatDatencorrect = string.Empty;
        static public string msgTracksNum = string.Empty;
        static public string capInfo = string.Empty;
        static public string msgInsertCdName = string.Empty;
        static public string namCapCdMiss = string.Empty;
        static public string msgProblDBConnection = string.Empty;
        static public string nameCaptionTitle = string.Empty;
        static public string msgTitlenotFound = string.Empty;
        static public string TimeError = string.Empty;
        static public string frmt = string.Empty;
        static public string QUQ = string.Empty;
        static public string ProblemDB = string.Empty;

        static public void Dictionary(string lang)
        {
            //Thread.CurrentThread.CurrentCulture = new CultureInfo(lang);
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(lang);
            old_btnsaveInfo                         = Properties.Vocabolury.Dict.bntsaveInfo;
            btnCancel                               = Properties.Vocabolury.Dict.btnCancel;
            btnListFiles                            = Properties.Vocabolury.Dict.btnListFiles;
            btnNote                                 = Properties.Vocabolury.Dict.btnNote;
            btnsave                                 = Properties.Vocabolury.Dict.btnsave;
            btnSaveAll                              = Properties.Vocabolury.Dict.btnSaveAll;
            btnStop                                 = Properties.Vocabolury.Dict.btnStop;
            ChkNotIncludeAutorun                    = Properties.Vocabolury.Dict.ChkNotIncludeAutorun;
            chkWordIndex                            = Properties.Vocabolury.Dict.chkWordIndex;
            lbCdName                                = Properties.Vocabolury.Dict.lbCdName;
            lbCdNummer                              = Properties.Vocabolury.Dict.lbCdNummer;
            lbCreationDate                          = Properties.Vocabolury.Dict.lbCreationDate;
            lbMediaType                             = Properties.Vocabolury.Dict.lbMediaType;
            lbPosCD                                 = Properties.Vocabolury.Dict.lbPosCD;
            lbSelectDrive                           = Properties.Vocabolury.Dict.lbSelectDrive;
            lbCdNote                                = Properties.Vocabolury.Dict.ldCdNote;
            menuEdit                                = Properties.Vocabolury.Dict.menuEdit;
            menuitExit                              = Properties.Vocabolury.Dict.menuitExit;
            menuFile                                = Properties.Vocabolury.Dict.menuFile;
            menuitNew                               = Properties.Vocabolury.Dict.menuitNew;
            menuitSaveAll                           = Properties.Vocabolury.Dict.menuitSaveAll;
            menuitSaveInfo                          = Properties.Vocabolury.Dict.menuitSaveInfo;
            menuitSavePreview                       = Properties.Vocabolury.Dict.menuitSavePreview;
            menuitShowExplorer                      = Properties.Vocabolury.Dict.menuitShowExplorer;
            menuitLanguage                          = Properties.Vocabolury.Dict.menuitLanguage;
            menuTools                               = Properties.Vocabolury.Dict.menuTools;
            menuitOptions                           = Properties.Vocabolury.Dict.options;
            menuitAbout                             = Properties.Vocabolury.Dict.menuitAbout;
            menuitCancel                            = Properties.Vocabolury.Dict.menuCancel;
            msgSecurityException                    = Properties.Vocabolury.Dict.msgSecurityException;
            msgThekeyIsLocked                       = Properties.Vocabolury.Dict.msgThekeyIsLocked;
            toolpHideInfo                           = Properties.Vocabolury.Dict.toolpHideInfo;
            toolpRightClickForZoom                  = Properties.Vocabolury.Dict.toolpRightClickForZoom;
            toolpSavesInfo                          = Properties.Vocabolury.Dict.toolpSavesInfo;
            toolpShowInfo                           = Properties.Vocabolury.Dict.toolpShowInfo;
            toolpListandAnalyzeFiles                = Properties.Vocabolury.Dict.toolpListandAnalyzeFiles;
            msgUnauthorizedAccessException          = Properties.Vocabolury.Dict.msgUnauthorizedAccessException;
            msgFormatTimeIncorrect                  = Properties.Vocabolury.Dict.msgFormatTimeIncorrect;
            msgInternetConnection                   = Properties.Vocabolury.Dict.msgInternetConnection;
            msgCDNotFound                           = Properties.Vocabolury.Dict.msgCDNotFound;
            msgNameCDnotFound                       = Properties.Vocabolury.Dict.msgNameCDnotFound;
            msgNameArtistNotFound                   = Properties.Vocabolury.Dict.msgNameArtistNotFound;
            nameCaptionmsgBox                       = Properties.Vocabolury.Dict.nameCaptionmsgBox;
            msgNameLandNotFound                     = Properties.Vocabolury.Dict.msgNameLandNotFound;
            nameCaptionmsgBox                       = Properties.Vocabolury.Dict.nameCaptionmsgBox;
            nameCapGenre                            = Properties.Vocabolury.Dict.nameCapGenre;
            msgGenreMiss                            = Properties.Vocabolury.Dict.msgGenreMiss;
            msgMissngData                           = Properties.Vocabolury.Dict.msgMissngData;
            msgFormatDatencorrect                   = Properties.Vocabolury.Dict.msgFormatDatencorrect;
            msgTracksNum                            = Properties.Vocabolury.Dict.msgTracksNum;
            capInfo                                 = Properties.Vocabolury.Dict.capInfo;
            msgInsertCdName                         = Properties.Vocabolury.Dict.msgInsertCdName;
            namCapCdMiss                            = Properties.Vocabolury.Dict.namCapCdMiss;
            msgProblDBConnection                    = Properties.Vocabolury.Dict.msgProblDBConnection;
            nameCaptionTitle                        = Properties.Vocabolury.Dict.nameCaptionTitle;
            msgTitlenotFound                        = Properties.Vocabolury.Dict.msgTitlenotFound;
            TimeError                               = Properties.Vocabolury.Dict.TimeError;
            frmt                                    = Properties.Vocabolury.Dict.frmt;
            QUQ                                     = Properties.Vocabolury.Dict.QUQ;
            ProblemDB                               = Properties.Vocabolury.Dict.ProblemDB;
            TimeError                               = Properties.Vocabolury.Dict.TimeError;
            frmt                                    = Properties.Vocabolury.Dict.frmt;
        }
    }
}

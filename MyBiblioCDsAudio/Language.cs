using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MyBiblioCDsAudio
{
    public static class Languages
    {
        static public string btninNet                                   = string.Empty;
        static public string btnLocal                                   = string.Empty;
        static public string btnSave                                    = string.Empty;
        static public string CDCoverControl_ContextMnStrip_ChooseThis   = string.Empty;
        static public string CDCoverControl_ContextMnStrip_EditInfo     = string.Empty;
        static public string CDCoverControl_ContextMnStrip_SaveAS       = string.Empty;
        static public string CDCoverControl_CoverCd                     = string.Empty;
        static public string CDCoverControl_File                        = string.Empty;
        static public string CDCoverControl_HideInfoBtn                 = string.Empty;
        static public string CDCoverControl_Name                        = string.Empty;
        static public string CDCoverControl_ShowInfoBtn                 = string.Empty;
        static public string CDCoverControl_SizesCD                     = string.Empty;
        static public string dtgrvwInfoCd_ToolTipText_SelectCD         = string.Empty;
        static public string editarTit_Artist                           = string.Empty;
        static public string editarTit_Title                            = string.Empty;
        static public string editCover_File                             = string.Empty;
        static public string editCover_Name                             = string.Empty;
        static public string editCover_SizeX                            = string.Empty;
        static public string editCover_SizeY                            = string.Empty;
        static public string lbAlbum                                    = string.Empty;
        static public string lbArtist                                   = string.Empty;
        static public string lbBarcode                                  = string.Empty;
        static public string lbCountry                                  = string.Empty;
        static public string lbDate                                     = string.Empty;
        static public string lbGenre                                    = string.Empty;
        static public string lbSearchCover                              = string.Empty;
        static public string lbTitle                                    = string.Empty;
        static public string msgbxCDnotFound                            = string.Empty;
        static public string msgbxcdnotfoundinMBrainz                   = string.Empty;
        static public string TrackDtGrVw_Duration                    = string.Empty;
        static public string TrackDtGrVw_Title                       = string.Empty;
        static public string TrackDtGrVw_TrNum                       = string.Empty;
        static public string menuopen                                   = string.Empty;
        static public string titleGridview1                             = string.Empty;
        static public string countryGridview1                           = string.Empty;
        static public string dateGridview1                              = string.Empty;
        static public string barcodeGridview1                           = string.Empty;
        static public string releaseidGridview1                         = string.Empty;
        static public string msgInsertJear                              = string.Empty;
        static public string msgInternetConnection                      = string.Empty;
        static public string msgCDNotFound                              = string.Empty;
        static public string nameCaptionTitle                           = string.Empty;
        static public string msgNameCDnotFound                          = string.Empty;
        static public string msgNameArtistNotFound                      = string.Empty;
        static public string nameCaptionmsgBox                          = string.Empty;
        static public string msgNameLandNotFound                        = string.Empty;
        static public string nameCaptionLand                            = string.Empty;
        static public string msgGenreMiss                               = string.Empty;
        static public string nameCapGenre                               = string.Empty;
        static public string msgMissngData                              = string.Empty;
        static public string nameCapDate                                = string.Empty;
        static public string msgFormatDatencorrect                      = string.Empty;
        static public string msgcdnotfoundAlternative                   = string.Empty;
        static public string CoverPath                                  = string.Empty;
        static public string FileExists                                 = string.Empty;
        static public string w_OneMoreCellRows                          = string.Empty;

        static public void Dictionary(string lang)
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(lang);
           
            btninNet                                    = Properties.Vocabolury.Dict.btninNet;
            btnLocal                                    = Properties.Vocabolury.Dict.btnLocal;
            btnSave                                     = Properties.Vocabolury.Dict.btnSave;
            dtgrvwInfoCd_ToolTipText_SelectCD          = Properties.Vocabolury.Dict.dtgrvwInfoCd_ToolTipText_SelectCD;
            editarTit_Title                             = Properties.Vocabolury.Dict.editarTit_Title;
            editCover_File                              = Properties.Vocabolury.Dict.editCover_File;
            editCover_Name                              = Properties.Vocabolury.Dict.editCover_Name;
            editCover_SizeX                             = Properties.Vocabolury.Dict.editCover_SizeX;
            editCover_SizeY                             = Properties.Vocabolury.Dict.editCover_SizeY;
            lbAlbum                                     = Properties.Vocabolury.Dict.lbAlbum;
            lbArtist                                    = Properties.Vocabolury.Dict.lbArtist;
            lbBarcode                                   = Properties.Vocabolury.Dict.lbBarcode;
            lbCountry                                   = Properties.Vocabolury.Dict.lbCountry;
            lbDate                                      = Properties.Vocabolury.Dict.lbDate;
            lbGenre                                     = Properties.Vocabolury.Dict.lbGenre;
            lbSearchCover                               = Properties.Vocabolury.Dict.lbSearchCover;
            lbTitle                                     = Properties.Vocabolury.Dict.lbTitle;
            msgbxCDnotFound                             = Properties.Vocabolury.Dict.msgbxCDnotFound;
            msgbxcdnotfoundinMBrainz                    = Properties.Vocabolury.Dict.msgbxcdnotfoundinMBrainz;
            TrackDtGrVw_Duration                     = Properties.Vocabolury.Dict.TrackDtGrVw_Duration;
            TrackDtGrVw_Title                        = Properties.Vocabolury.Dict.TrackDtGrVw_Title;
            TrackDtGrVw_TrNum                        = Properties.Vocabolury.Dict.TrackDtGrVw_TrNum;
            menuopen                                    = Properties.Vocabolury.Dict.menuop;
            titleGridview1                              = Properties.Vocabolury.Dict.titleGridview1;
            countryGridview1                            = Properties.Vocabolury.Dict.countryGridview1;
            dateGridview1                               = Properties.Vocabolury.Dict.dateGridview1;
            barcodeGridview1                            = Properties.Vocabolury.Dict.barcodeGridview1;
            releaseidGridview1                          = Properties.Vocabolury.Dict.releaseidGridview1;
            msgInsertJear                               = Properties.Vocabolury.Dict.msgInsertJear;
            msgInternetConnection                       = Properties.Vocabolury.Dict.msgInternetConnection;
            msgCDNotFound                               = Properties.Vocabolury.Dict.msgCDNotFound;
            msgNameCDnotFound                           = Properties.Vocabolury.Dict.msgNameCDnotFound;
            nameCaptionTitle                            = Properties.Vocabolury.Dict.nameCaptionTitle;
            msgNameArtistNotFound                       = Properties.Vocabolury.Dict.msgNameArtistNotFound;
            nameCaptionmsgBox                           = Properties.Vocabolury.Dict.nameCaptionmsgBox;
            msgNameLandNotFound                         = Properties.Vocabolury.Dict.msgNameLandNotFound;
            nameCaptionLand                             = Properties.Vocabolury.Dict.nameCaptionLand;
            msgGenreMiss                                = Properties.Vocabolury.Dict.msgGenreMiss;
            nameCapGenre                                = Properties.Vocabolury.Dict.nameCapGenre;
            msgMissngData                               = Properties.Vocabolury.Dict.msgMissngData;
            nameCapDate                                 = Properties.Vocabolury.Dict.nameCapDate;
            msgFormatDatencorrect                       = Properties.Vocabolury.Dict.msgFormatDatencorrect;
            msgcdnotfoundAlternative                    = Properties.Vocabolury.Dict.msgcdnotfoundAlternative;
            CoverPath                                   = Properties.Vocabolury.Dict.CoverPath;
            FileExists                                  = Properties.Vocabolury.Dict.FileExists;
            w_OneMoreCellRows                           = Properties.Vocabolury.Dict.w_OneMoreCellRows;
        }
    }
}

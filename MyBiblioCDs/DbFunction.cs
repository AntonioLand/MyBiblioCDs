using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
//using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using PdftoText;
using System.Threading;
// using System.Data.SqlClient;
using System.Data;
using LibVLCSharp.Shared;
using System.Xml.Xsl;
using System.Dynamic;
using static System.Net.WebRequestMethods;
using System.Diagnostics;
// using MySqlConnector;

#pragma warning disable CS1591

// Once the impossible is discarded what remains however improbable must be the truth.
// Una volta scartato l'impossibile quel che resta per quanto improbabile dev'essere la veritá
// Wenn das Unmögliche verworfen wurde, muss das, was übrig bleibt, auch wenn es unwahrscheinlich ist, die Wahrheit sein.
// Una vez descartado lo imposible, lo que queda, por improbable que sea, debe ser la verdad
// İmkânsız olan bir kez bir kenara atıldığında, geriye kalan, ne kadar imkânsız olursa olsun, gerçek olmalıdır
#pragma warning disable IDE1006, IDE0017, CS1591


namespace MyBiblioCDs
{
    /// <summary>
    /// The class is for connection and storage in the DB.
    /// </summary>
    static public class DbFunction
    {
        static readonly string namePC = System.Environment.MachineName;
        public static SqlConnection conn;
        // private static readonly string myConnectionString = @"Data Source=(local)" + @"; Initial Catalog = MyBiblioCDsDB; Integrated Security = True";

        /// <summary>
        /// If the connection is open it does nothing. If not, try opening it. 
        /// </summary>
        /// <returns></returns>
        public static bool connect()
        {
            if((conn != null && conn.State == ConnectionState.Closed) || (conn == null))
            try
            {
                    conn = new SqlConnection(MainForm.myConnectionString);
                    conn.Open();
            }
            catch (Exception ex)
            {
                 MessageBox.Show(ex.Message);
                 return false;
            }
            return true;
        }

        #region Note

        /// <summary>
        /// Save the note to the CD if present
        /// </summary>
        /// <param name="objMF"></param>
        /// <param name="PkCd"></param>
        /// <returns></returns>
        static public int SaveNote(ObjMainForm objMF, int PkCd)
        {
            int PkNote = -1;
            try
            {
                if (objMF.cdnote != null && objMF.cdnote.Length > 0)
                {
                    PkNote = writeNote(objMF.cdnote, PkCd, 0);
                }
            }
            catch (Exception ex)
            {
                LogProj.exception("In SaveNOte - DbFunction: " + ex.Message);
                MessageBox.Show(ex.Message);
                Application.Exit();
            }
            return PkNote;
        }

        /// <summary>
        /// Store notes in the db
        /// </summary>
        /// <param name="notice"></param>
        /// <param name="pkFile"></param>
        /// <param name="notefor">0 = for CD, 1 = for File 2 = for Text</param>
        /// <returns></returns>
        static public int writeNote(string notice, int pkFile, int notefor)
        {
            ApostropheProblem(ref notice);
            string cmd = @"INSERT INTO note (Note, idFile_idNote, typeNt) Values ('" + notice + "', " + pkFile + ", " + notefor + ")";
            return InsertInto(cmd, "note");
        } //End of writeNote
        #endregion // Note

        /// <summary>
        /// Save only the information, of the main Form
        /// </summary>
        /// <param name="objMF"></param>
        /// <returns></returns>
        static public int SaveOnlyInfo(ObjMainForm objMF)
        {
            if (!connect())
                return -1;
            int PKCdNew = -1;
            try
            {
                PKCdNew = writecdnew(objMF);
                SaveNote(objMF, -PKCdNew);

            }
            catch (Exception ex)
            {
                LogProj.exception("In SaveOnlyInfo - DbFunction: " + ex.Message);
                MessageBox.Show(ex.Message);
                Application.Exit();
            }
            conn.Close();
            return PKCdNew;
        }

        /// <summary>
        /// Check what information is present. And stores it in the DB.
        /// </summary>
        /// <param name="objMF"></param>
        /// <returns></returns>
        static public int writecdnew(ObjMainForm objMF)
        {
            string column = string.Empty;
            string VALUES = string.Empty;
            if(objMF.cdname != null && objMF.cdname.Length > 0)
            {
                column += "NameCD, ";
                VALUES += "'" + objMF.cdname + "', ";
            } else
            {
                column += "NameCD, ";
                VALUES += "'" + "NoNaMe" + "', ";
            }
            column += "NumCd";
            VALUES += objMF.cdnum;
            if(objMF.position != null &&  objMF.position.Length > 0)
            {
                column += ", Position";
                VALUES += ", '" + objMF.position + "'";
            }
            if(objMF.createdate != null)
            {
                column += ", CreationDate";
                VALUES += ", '" + objMF.createdate.ToShortDateString() + "'";
            }
            if(objMF.CoverPath != null && objMF.CoverPath != string.Empty)
            {
                column += ", CoverPath";
                VALUES += ", '" + objMF.CoverPath + "'";
            }
            if(objMF.Unic_IDCD != null && objMF.Unic_IDCD != string.Empty)
            {
                column += ", Unic_IDCD";
                VALUES += ", '" + objMF.Unic_IDCD + "'";
            }
            if(objMF.cdtype != -1)
            {
                column += ", CdMediatype";
                VALUES += ", " + objMF.cdtype;
            }
            column += ")";
            VALUES += ")";
            string cmd_0 = @"INSERT INTO cdnew (" + column + " VALUES (" + VALUES;
            LogProj.Info("writecdnew: =>" + cmd_0);
            return (InsertInto(cmd_0, "cdnew"));
        }
        /// <summary>
        /// Writes the names of the artists in the DB. 
        /// </summary>
        /// <param name="artistname"></param>
        /// <returns></returns>
        static public int writeArtist(string artistname)
        {
            int PKArtist = ToSearch("artist", "NameArtist", artistname);
            string cmd;
            if (PKArtist == -1)
            {
                cmd = @"INSERT INTO ARTIST (NameArtist) Values ('" + artistname + "')";
                LogProj.Info("writeArtist: => " + cmd);
                PKArtist =  InsertInto(cmd, "artist");
            }
            return PKArtist;
        }

        /// <summary>
        /// Writes the audio information to the DB.
        /// </summary>
        /// <param name="audioCDToSave"></param>
        /// <param name="objMain"></param>
        /// <param name="label"></param>
        /// <returns></returns>
        static public int writeAllAudio(AudioCD audioCDToSave, ObjMainForm objMain, Label label)
        {
            if(!connect())
                return -1;
            int PkNote = -1;
            int PKArtist = -1;
            if (audioCDToSave.Artist != string.Empty)
                PKArtist = writeArtist(audioCDToSave.Artist);
            objMain.Unic_IDCD = audioCDToSave.Barcode;
            objMain.CoverPath = audioCDToSave.CoverArtF;
            int PKCdNew = writecdnew(objMain);
            if (objMain.cdnote != string.Empty && objMain.cdnote != null)
            {
                PkNote = writeNote(objMain.cdnote, -PKCdNew, 0);
            }
            string cmd = CreateCmd(audioCDToSave, objMain, PKCdNew);
            int PKAudio = InsertInto(cmd, "audiocd");
            cmd = @"Insert INTO audiocd_has_artist (AudioCD_has_Artist, Artist_idArtist) VALUES (" + PKAudio + "," + PKArtist + ")";
            LogProj.Info("writeAllAudio: =>" + cmd);
            InsertInto(cmd, "audiocd_has_artist", false);
            trackInsert(audioCDToSave.tracks, PKAudio);
            conn.Close();
            return PKCdNew;
        } // End writeAllAudio

        /// <summary>
        /// Creates the command for insertion into the audiocd table.
        /// </summary>
        /// <param name="audioCDToSave"></param>
        /// <param name="objMain"></param>
        /// <param name="PKCdNew"></param>
        /// <returns></returns>
        static private string CreateCmd(AudioCD audioCDToSave, ObjMainForm objMain, int PKCdNew)
        {
            string cmd = @"INSERT INTO audiocd (";
            string values = string.Empty;
            if (audioCDToSave.Title != null && audioCDToSave.Title.Length > 0)
            {
                cmd += "Title, ";
                values += "'" + audioCDToSave.Title + "', ";
            }
            if(audioCDToSave.Country != null && audioCDToSave.Country.Length > 0)
            {
                cmd += "Country, ";
                values += "'" + audioCDToSave.Country + "', ";

            }
            if(audioCDToSave.genreMusic != -1)
            {
                cmd += "Genre, ";
                values += audioCDToSave.genreMusic +", ";
            }
            if (audioCDToSave.PublicationDate != null && audioCDToSave.PublicationDate.Length > 0)
            {
                cmd += "PublicationDate, ";
                //values += "'" + audioCDToSave.PublicationDate + "', ";
                values += audioCDToSave.PublicationDate + ", ";
            }
            else
            {
                cmd += "PublicationDate, ";
                values += "'',";
            }
            if(audioCDToSave.Duration.Length != 0)
            {
                string longtimeCD = audioCDToSave.Duration;
                TimeOrNotTime _durationtrack = new TimeOrNotTime();
                _durationtrack.TimeOnly(ref longtimeCD);
                cmd += "Duration, ";
                values += "'" + longtimeCD + "', ";
            }
            if (audioCDToSave.numTracks >= 0 && audioCDToSave.numTracks == audioCDToSave.tracks.Count)
            {
                cmd +=  "NumTracks, ";
                values += audioCDToSave.numTracks;
            }
            else if(audioCDToSave.numTracks != audioCDToSave.tracks.Count)
            {
                cmd += "NumTracks, ";
                values += audioCDToSave.numTracks;
                MessageBox.Show(Languages.msgTracksNum, Languages.capInfo);
            } else if(audioCDToSave.numTracks == 0)
            {
                using (QuestionAndAnswer msg = new QuestionAndAnswer())
                {
                    msg.label1.Text = @"The number of LTracks is missing. Do you want to insert it?";
                    if (msg.ShowDialog() == DialogResult.OK)
                    {
                        cmd += "NumTracks, ";
                        values += " " + msg.label1.Text;
                    }
                }
            }
            cmd += "CdNew_idCdNew";
            values += ", " + PKCdNew.ToString();
            return cmd + ") VALUES (" + values + ")";
        } // End of CreateCmd
        static public int InsertInto(string cmd, string table, bool pk = true)
        {
            if (!connect())
                return -1;
            using (SqlCommand comando = new SqlCommand(cmd, conn))
            {
                try
                {
                    object obj = comando.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    LogProj.exception("InsertInto: " + cmd + ex.Message);
                }
            }
            int newPK = -1;
            if (pk)
                newPK = ReadIdPrimary(table);
            conn.Close();
            LogProj.Info("InsertInto: => " + newPK.ToString());
            return newPK;
        } // End of InsertInto

        /// <summary>
        /// It searches for a value and returns the value of the primary key.
        /// </summary>
        /// <param name="table">The name of the table where to search</param>
        /// <param name="column">The name of the column where to search</param>
        /// <param name="val">The value to be researched</param>
        /// <returns></returns>
        static private int ToSearch(string table, string column, string val)
        {
            string cmd = @"Select * From " + table + " Where " + column + "  =  '" + val + "'";
            int id = -1;
            string PK = "id" + table;
            using (SqlCommand comando = new SqlCommand(cmd, conn))
            {
                try
                {
                    using (SqlDataReader rdr = comando.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            id = (int)rdr[PK];
                        }
                        rdr.Close();
                        rdr.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    LogProj.exception("ToSearch: " + ex.Message);
                }
                LogProj.Info("ToSearch: => " + id.ToString());
                return id;
            }
        } // end of ToSearch

        /// <summary>
        /// Returns the last value of the primary key of the table
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        static private int ReadIdPrimary(string table)
        {
            int ncd = -1;
            try
            {
                string cmd = @"Select max(id" + table + ") From " + table;
                //MySqlCommand comando = new MySqlCommand(cmd, conn);
                SqlCommand comando = new SqlCommand(cmd, conn);
                object ncdd = comando.ExecuteScalar();
                if (ncdd is null)
                    ncd = -1;
                else
                    ncd = (int)ncdd;
                if (ncd > 0)
                    return ncd;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return ncd;
        } // End of ReadIdPrimary


        /// <summary>
        /// Inserts the tracks of the Audio CD
        /// </summary>
        /// <param name="LTracks"></param>
        /// <param name="PKAudio"></param>
        static void trackInsert(List<Track> LTracks, int PKAudio)
        {
            if (!connect())
                return;
            foreach (Track tr in LTracks)
            {
                string cmd_0 = @"INSERT INTO tracks (NumTrack, NameTrack, Duration, AudioCD_IdAudioCD) VALUES (@NumTrack, @NameTrack,  @DURATION, @AudioCD_IdAudioCD)";
                
                using (SqlCommand comando = new SqlCommand(cmd_0, conn))
                {
                    try
                    {
                        comando.Parameters.Add("@NumTrack", SqlDbType.SmallInt).Value = Convert.ToInt16(tr.TrNum);
                        comando.Parameters.Add("@NameTrack", SqlDbType.VarChar).Value = tr.TitleTrack;
                        if(tr.Duration != null && tr.Duration != string.Empty)
                        {
                            string tm = tr.Duration;
                            TimeOrNotTime _durationtrack = new TimeOrNotTime();
                            if (_durationtrack.TimeOnly(ref tm))
                            {
                                tr.Duration= tm;
                                comando.Parameters.Add("@DURATION", SqlDbType.Time).Value = tr.Duration;
                            }
                            else
                                comando.Parameters.Add("@DURATION", SqlDbType.Time).Value = "0:0";
                        }
                        comando.Parameters.Add("@AudioCD_IdAudioCD", SqlDbType.Int).Value = PKAudio;
                        comando.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            conn.Close();
        } // End trackInsert

        private static bool ApostropheProblem(ref string text)
        {
            string result = Regex.Replace(text, "\'", "''");
            if (text.Equals(result, StringComparison.OrdinalIgnoreCase))
                return false;
            text = result;
            return true;
        }

        /// <summary>
        /// Not Used
        /// </summary>
        /// <param name="dirpath"></param>
        /// <param name="infolabel"></param>
        /// <returns></returns>
        static public int SaveDir(string dirpath, Label infolabel)
        {
            if (!connect())
                return -1;
            string cmd = @"INSERT INTO directories (FullPath) VALUES ('" + dirpath + ")";
            int PKdir = InsertInto(cmd, "audiocd");
            conn.Close();
            return PKdir;
        }

        public static int CommonFileInfoCollect(InfoFiles infoFiles, int PkCdNew, StringBuilder insertinto, StringBuilder notecmdInsert) //, List<string> filesToMem)
        {
            string fullname = infoFiles.thisfile.FullName;
            string NameFile = infoFiles.thisfile.Name;
            if (ApostropheProblem(ref fullname))
                ApostropheProblem(ref NameFile);
            bool yesornot = false;
            if (infoFiles.nota != null && infoFiles.nota.Count > 0)
                yesornot = true;
            insertinto.Append("('" + fullname + "', '" + NameFile + "', " +
                         "'" + infoFiles.thisfile.CreationTime.Year + "-" + infoFiles.thisfile.CreationTime.Month + "-" + infoFiles.thisfile.CreationTime.Day + " " + infoFiles.thisfile.CreationTime.Hour + ":" + infoFiles.thisfile.CreationTime.Minute + ":" + infoFiles.thisfile.CreationTime.Second + "', " +
                         "'" + infoFiles.thisfile.LastWriteTime.Year + "-" + infoFiles.thisfile.LastWriteTime.Month + "-" + infoFiles.thisfile.LastWriteTime.Day + " " + infoFiles.thisfile.LastWriteTime.Hour + ":" + infoFiles.thisfile.LastWriteTime.Minute + ":" + infoFiles.thisfile.LastWriteTime.Second + "', " +
                         "'" + infoFiles.thisfile.Extension + "', " + infoFiles.thisfile.Length + "," + "'" + (infoFiles.hashcode != string.Empty ? infoFiles.hashcode : null) + "', " + PkCdNew + ", " + (yesornot == true ? 1 : 0) + "),");
            return 1;
        } // End CommonFileInfo

        public static int CommonFileInfo(InfoFiles infoFiles, int PkCdNew) //, List<string> filesToMem)
        {
            int PkFile;
            int PkNote;
            string insertinto;
            string fullname = infoFiles.thisfile.FullName;
            ApostropheProblem(ref fullname);
            bool yesornot = false;
            if (infoFiles.nota != null && infoFiles.nota.Count > 0)
                yesornot = true;
            insertinto = "INSERT INTO files (FullNameFile, FileName, CreationData, LastModified, Ext, Size, Hashcode, CdNew_idCdNew, Note) VALUES ('" +
                        fullname + "', '" + infoFiles.thisfile.Name + "', " +
                        "'" + infoFiles.thisfile.CreationTime.Year + "-" + infoFiles.thisfile.CreationTime.Month + "-" + infoFiles.thisfile.CreationTime.Day + " " + infoFiles.thisfile.CreationTime.Hour + ":" + infoFiles.thisfile.CreationTime.Minute + ":" + infoFiles.thisfile.CreationTime.Second + "', " +
                        "'" + infoFiles.thisfile.LastWriteTime.Year + "-" + infoFiles.thisfile.LastWriteTime.Month + "-" + infoFiles.thisfile.LastWriteTime.Day + " " + infoFiles.thisfile.LastWriteTime.Hour + ":" + infoFiles.thisfile.LastWriteTime.Minute + ":" + infoFiles.thisfile.LastWriteTime.Second + "', " +
                        "'" + infoFiles.thisfile.Extension + "', " +
                        infoFiles.thisfile.Length + "," +
                        "'" + (infoFiles.hashcode != string.Empty ? infoFiles.hashcode : null) + "', " + PkCdNew + ", " + (yesornot == true ? 1 : 0) + ")";
            PkFile = InsertInto(insertinto, "files");
            if (yesornot)
            {
                foreach (NOTE nt in infoFiles.nota)
                {

                    PkNote = writeNote(nt.textNote.ToString(), PkFile, nt.codenote);
                }
            }
            return PkFile;
        } // CommonFileInfo
        
        /// <summary>
        /// So so ...
        /// </summary>
        /// <param name="objMain"></param>
        /// <returns></returns>
        static public bool insertfilm(ObjMainForm objMain)
        {
            int PKCdNew = DbFunction.SaveOnlyInfo(objMain);
            if (!connect())
                return false;
            string cmd = "INSERT INTO film (TitleFilm, CdNew_idCdNew, CdNew_idCdNew1) VALUES ('" + objMain.cdname + "', " +  PKCdNew + ", " +  PKCdNew + ")";
            InsertInto(cmd, "film", false);
            return true;
        }

        /// <summary>
        /// Stores words from the list in the DB
        /// </summary>
        /// <param name="WordList"></param>
        /// <returns></returns>
        static public bool InsertWord(List<ExtractorWords> WordList)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            List<string> ROWS = new List<string>();
            string cmd1 = string.Empty;
            if (!connect())
                return false;
            foreach (ExtractorWords s in WordList)
            {
                cmd1 += string.Format("('{0}', '{1}'), ", s.numfile.ToString(), s.word);
            }
            cmd1 = cmd1.Remove(cmd1.Length - 2, 2);
            StringBuilder cmd = new StringBuilder("INSERT INTO filenumandword (pkfiles, word) SELECT * From (VALUES ");
            cmd.Append(cmd1);
            cmd = cmd.Append(") as tmp (pkfiles, word)");
            using (SqlCommand myCmd = new SqlCommand(cmd.ToString(), conn))
            {
                try
                {
                    myCmd.CommandType = System.Data.CommandType.Text;
                    int myResult = myCmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    conn.Close();
                    return false;
                }
            }
            conn.Close();
            stopwatch.Stop();
            LogProj.Info("InsertWord = " + stopwatch.Elapsed);
            return true;
        } // End of InsertWord

        /// <summary>
        /// Stores in the DB the words of the program files
        /// </summary>
        /// <param name="WordList"></param>
        /// <returns></returns>
        static public bool InsertWordProg(List<ExtractorWords> WordList)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            List<string> ROWS = new List<string>();
            string cmd1 = string.Empty;
            foreach (ExtractorWords s in WordList)
            {
                cmd1 += string.Format("('{0}', '{1}'), ", s.numfile, s.word);
            }
            cmd1 = cmd1.Remove(cmd1.Length - 2, 2);
            StringBuilder cmd = new StringBuilder("INSERT INTO filenumandword_pro (pkfile, word) VALUES ");
            cmd = cmd.Append(cmd1);
            cmd = cmd.Append(";");

            if (!connect())
                return false;
            try
            {
                using (SqlCommand myCmd = new SqlCommand(cmd.ToString(), conn))
                {
                    myCmd.CommandType = System.Data.CommandType.Text;
                    myCmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn.Close();
            stopwatch.Stop();
            LogProj.Info("InsertWordProg = " + stopwatch.Elapsed);
            return true;
        } // End of InsertWordProg

        /// <summary>
        /// Updates the dictionary within the DB
        /// </summary>
        /// <returns></returns>
        public static bool  UpdateDB()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            if (!connect())
                return false;
            SqlCommand myCmd;
            try
            {
                using (myCmd = new SqlCommand("Update_DB_word", conn))
                {

                    myCmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter param = new SqlParameter("@p1", 0);
                    param.Direction= ParameterDirection.Output;
                    param.DbType= DbType.Int32;
                    myCmd.Parameters.Add(param);
                    object retx = myCmd.ExecuteNonQuery();
                    object v= param.Value;
                   
                    if ((int)v != 4)
                    {
                        MessageBox.Show(Languages.ProblemDB);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.Source);
                MessageBox.Show(ex.ToString());
                return false;
            }
            conn.Close();
            stopwatch.Stop();
            LogProj.Info("UpdateDB = " + stopwatch.Elapsed);

            return true;
        }// End of UpdateDB_ProgWord

        /// <summary>
        /// Updates the word dictionary of program files within the DB
        /// </summary>
        /// <returns></returns>
        public static bool UpdateDB_ProgWord()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            if (!connect())
                return false;
            SqlCommand myCmd;
            try
            {
                using (myCmd = new SqlCommand("UPDATE_DB_WORD_PROG", conn))
                {

                    myCmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter param = new SqlParameter("@p1", 0);
                    param.Direction = ParameterDirection.Output;
                    param.DbType = DbType.Int32;
                    myCmd.Parameters.Add(param);
                    object retx = myCmd.ExecuteNonQuery();
                    object v = param.Value;

                    if ((int)v != 4)
                    {
                        MessageBox.Show("something went wrong because it is not known...");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.Source);
                MessageBox.Show(ex.ToString());
                return false;
            }
            conn.Close();
            stopwatch.Stop();
            LogProj.Info("UpdateDB_ProgWord = " + stopwatch.Elapsed);
            return true;
        } // End of UpdateDB_ProgWord
    }
}

using System;
using System.Windows.Forms;
namespace MyBiblioCDsAudio
{
    static public class MusicBrainz
    {

        static public MainFormAudio mainFormAudio;


        [STAThread]
#pragma warning disable CS0436 

        static public int findCDAudio(Audio_CD thisCD, bool sons)  //serch or not search = sons
#pragma warning restore CS0436 
        {

            if (thisCD is null)
            {
                throw new ArgumentNullException(nameof(thisCD));
            }

            try
            {
                mainFormAudio = new MainFormAudio(thisCD.CoverArtF, ref thisCD, sons);
                
                DialogResult X = mainFormAudio.ShowDialog();
                if (X == DialogResult.OK)
                    return 1;
                else
                {
                    mainFormAudio.Dispose();
                    return 2;
                }
            } catch (AccessViolationException e)
            {
                MessageBox.Show(e.ToString());
                return -1;
            }
        }
    }
}

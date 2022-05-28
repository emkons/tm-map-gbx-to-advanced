using GBX.NET;
using GBX.NET.Engines.Game;
using System.Windows.Forms;
using System;
using System.IO;

class Program
{
    [STAThread]    
    static void Main(string[] args)
    {
        using (OpenFileDialog openFileDialog = new OpenFileDialog())
        {
            var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFileDialog.InitialDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Trackmania", "Maps");
            openFileDialog.Filter = "TM maps (*.Map.Gbx)|*.Map.Gbx";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Multiselect = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (String file in openFileDialog.FileNames) {
                    var filePath = file;

                    var node = GameBox.ParseNode(filePath);

                    if (node is CGameCtnChallenge map)
                    {
                        map.Editor = CGameCtnChallenge.EditorMode.Advanced;
                        map.MapName = map.MapName + "Advanced";

                        var savePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Advanced_" + Path.GetFileName(filePath));
                        map.Save(savePath);
                    }
                }
            }
        }
    }
}

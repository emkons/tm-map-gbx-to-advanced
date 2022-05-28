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

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var filePath = openFileDialog.FileName;

                var node = GameBox.ParseNode(filePath);

                if (node is CGameCtnChallenge map)
                {
                    map.Editor = CGameCtnChallenge.EditorMode.Advanced;

                    var savePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Path.GetFileName(filePath));
                    map.Save(savePath);
                }
            }
        }
    }
}

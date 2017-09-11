using System;
using System.IO;

namespace copyFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            string rutaPrincipal = @"C:\ACL\spm12\toolbox\ACL\Study\StuPaci";
            string rutabackup = @"C:\Users\parivera\OneDrive\ESPOL\Bioingenieria\Studios Navarra\";

            string[][] collec = new string[][] {
                Directory.GetFiles(rutaPrincipal, "*roc*ET.nii", SearchOption.AllDirectories),
                Directory.GetFiles(rutaPrincipal, "xw*.nii", SearchOption.AllDirectories),
                Directory.GetFiles(rutaPrincipal, "w*LOG.nii", SearchOption.AllDirectories)
            };

            for (int i = 0; i < collec.Length; i++)
            {
                foreach (var file in collec[i]) //extrae todos las coincidencias
                {                    
                    var sujetoDir = rutabackup + Directory.GetParent(Path.Combine(Path.GetDirectoryName(file), @"..\..\")).Name;
                    if (!Directory.Exists(sujetoDir))
                    {
                        Directory.CreateDirectory(sujetoDir);
                    }

                    File.Copy(file, Path.Combine(sujetoDir, Path.GetFileName(file)), true);

                    //si se requiere poner en la carpeta padre se debe usar la siguiente funcion
                    //var chess = Path.GetFullPath(Path.Combine(Path.GetDirectoryName(file), @"..\..\"));
                    //File.Copy(file, Path.Combine(chess, Path.GetFileName(file)), true);
                    
                }
            }
            
            Console.Read();
        }
    }
}

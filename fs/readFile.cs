using System.IO;

namespace Fs
{
    class ReadFile{

       /* 
        Constructor used for reading file
       */
        public ReadFile(string filePath){
            try
            {
                Console.WriteLine("\n**** HISTORIQUE des calculs  ****  " );

                using(StreamReader reader = new StreamReader(filePath)){
                string line;
                while((line = reader.ReadLine()) != null){
                    Console.WriteLine("      "+ line + "       ");
                
                }
                
            }
            Console.WriteLine("\n");
            }
            catch (System.Exception ex)
            {
                 new Exception("Erreur de lectures");
            }
        }
        
        /**
            for parse a string array
        */
        static void printList(List<string[]> data){
            
              for(int i = 0; i <= data.Count(); i++){
                    string[] item = data[i];
                    for(int j = 0; j<= item.Count(); j++){
                        Console.Write(item[j]+" \n");
                    }
            }
    }
}
 
}

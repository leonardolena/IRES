using System;

using System.IO;

namespace _
{

    class Program
    {

        static Word[] lista=new Word[1];
        static bool allowcomment;
        static int commentcounter;
        static char[] separator=new char[]{',',';','.','-',' ','<','>','=','(',')','$','&','%','!','^','*','+','/','\n','\t','\r','[',']'};
        static Letter[] list=new Letter[1];
        static void charcontrol(char[] separator,Letter letter){
            bool check=true;
            for(int i=0;i<separator.Length;i++){
                if(letter.name==separator[i]) check=false; 
            }
            if(check){
                letter.occurencies+=1;
                addtolist(letter,list);
            }
        }
        static Letter[] addtolist(Letter letter,Letter[] list){
            bool check=true;
            if(list.Length==1){
                list[0]=letter;
            }
            var newlist=new Letter[list.Length+1];
            for (int i = 0; i < list.Length; i++) {
                if(letter.name!=list[i].name){
                    newlist[i]=list[i];
                }else{
                    list[i].occurencies++;
                    check=false;
                 }
            }
            if(check){
                newlist[^1]=letter;
                return newlist;
            }else return list;
        }
         static Word[] addtolist(Word word,Word[] lista){
            bool check=true;
            if(lista.Length==1){
                lista[0]=word;
            }
            var newlista=new Word[lista.Length+1];
            for (int i = 0; i < lista.Length; i++) {
                if(word.name!=lista[i].name){
                    newlista[i]=lista[i];
                }else{
                    lista[i].occurencies++;
                    check=false;
                 }
            }
            if(check){
                newlista[^1]=word;
                return newlista;
            }else return lista;
        }
        static void extractletter(string[] text){
            foreach (string s in text){
                for(int i=0;i<s.Length;i++){
                    char carattere=s[i];
                    if(s[i]==s[i+1] && s[i]=='/'){
                        if(allowcomment){
                        var next = new Letter {name=carattere };
                        charcontrol(separator, next);
                        }else break;
                    }else{
                        var next = new Letter {name=carattere };
                        charcontrol(separator, next);
                    }
                }
            }
        }
        static void extractword(string[] text){
            foreach (string s in text){
                for(int i=0;i<s.Length;){
                    for(int j=i;j<s.Length;j++){                   
                        var next = new Letter {name=s[j]};
                        for(int k=0;k<separator.Length;k++){
                            if(next.name==separator[i]) {
                                var newword=new Word{
                                    name=s[i..j]
                                };
                            };                       
                        }   
                    }
                }
            }
        }
        static void returntotal(Word[] lista,Letter[] list){
            //non implementato, dovrebbe ritornare le parole e i carattere più usati 
            // e le rispettive occorrenze

        }
        static void Main(string[] args){
            System.Console.WriteLine("inserisci il percorso al file");
            string pathtofile = Console.ReadLine();
            string[] text = File.ReadAllLines(pathtofile);
            extractletter(text);
            extractword(text);
            returntotal(lista,list);
        }
    }
    class Letter{
       
        public char name;
        public int occurencies;
    }
    class Word{
        public string name;
        public int occurencies;
    }


}

using System;
using fun;
using Operation;

// interfaces
using Interface.OperInterface;
using Interface.AdvancedOp;
using Util.Checker;

namespace Application{
    class Calculator {
        
        // import all operations and set to protected static for using
        protected static OperInterface addOp = UtilFactory.Factory.CreateInstace<AddOper>();
        protected static OperInterface subOp = UtilFactory.Factory.CreateInstace<SubOper>();
        protected static OperInterface multiOp = UtilFactory.Factory.CreateInstace<Multiple>();
        protected static OperInterface divideOp = UtilFactory.Factory.CreateInstace<DivideOper>();
        protected static OperInterface moduloOp = UtilFactory.Factory.CreateInstace<ModuloOp>();
        protected static OperInterface compareOp = UtilFactory.Factory.CreateInstace<CompareOp>();

        
        // advanced operations 
        protected static AdvancedOpInterface racineOp = UtilFactory.Factory.CreateInstace<RacineOp>();
        protected static AdvancedOpInterface expoOp = UtilFactory.Factory.CreateInstace<ExpoOp>();


        // Regex Checker
        protected static NumberChecker matchChecker = new NumberChecker();

        //Console.WriteLine(op.Calc(5, 7));
        public static void startApp(){
           Fun.affiche("Start");

            mainLoop();
        }

        // parcour general de l'app
        public static void mainLoop(){
            bool parcourir = true;

            while (parcourir)
            {
                Fun.affiche("Faite votre operation ou cliquer sur q pour quitter");

                string userInput = Fun.getInput();

                if(userInput == "q"){
                    parcourir = false;
                } 
                else{
                    launchCalc(userInput);
                }
            }
        }

        public static void launchCalc(String input){
            
            String finalInput = NumberChecker.checkeAndReturnMatch(input);

            

            // Diviser l'entrer dé [gauche, operation, droite ] : e.g ( 5 //@left +//@operand 7//@right )  
            string[] parts = finalInput.Split(' ');

            // recuperer la valeur à gauche, l'operateur et droite
            double left = double.Parse(parts[0]);
            string operand = parts[1]; 
            double right = double.Parse(parts[2]);

            double result = 0;

            switch(operand){
                case "+":
                    result = addOp.Calc(left, right);
                    break;    
                case "-":
                    result = subOp.Calc(left, right);
                    break;
                case "*":
                    result = multiOp.Calc(left, right);
                    break;    
                case "/":
                    result = divideOp.Calc(left, right);
                    break;
                case "==":
                    result = compareOp.Calc(left, right);
                    break;    
                case "V":
                    result = racineOp.Calc(left);
                    break;    
                case "**":
                    result = expoOp.Calc(left);
                    break;
                case "%":
                    result = moduloOp.Calc(left, right);
                    break;
                default :
                    throw new InvalidOperationException("Operation Invalide");
            }

            Fun.affiche("Resultat = "+ result);

        }   
    }
}
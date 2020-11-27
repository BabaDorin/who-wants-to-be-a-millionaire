using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Printing;
using System.Text;
using WhoWantsToBeAMillionaire.Models;

namespace WhoWantsToBeAMillionaire.Services
{
    class LifelineService
    {
        public List<int> AskAudience(Question question)
        {
            // Pentru intrebarile Easy: Raspunsul corect va avea peste 80% din voturi
            // Pentru intrebarile Medium: Raspunsul corect va avea peste 60% din voturi
            // Pentru intrebarile Hard: Raspunsul corect va avea peste 35% din voturi
            // Pentru intrebarile Einstein: Raspunsul corect va avea peste 20% din voturi

            List<int> results = new List<int>() { 0, 0, 0, 0 };
            Random random = new Random();
            int op1 = 0, op2 = 0, op3 = 0, op4 = 0; // op1 este optiunea castigatoare

            switch (question.DifficultyLevel)
            {
                case DifficultyLevel.Easy:
                    op1 = random.Next(80, 100);  // Optiunea corecta
                    op2 = random.Next(0, 100 - op1);
                    op3 = random.Next(0, 100 - (op1 + op2));
                    op4 = 100 - (op1 + op2 + op3);
                    break;

                case DifficultyLevel.Medium:
                    op1 = random.Next(60, 100);  // Optiunea corecta
                    op2 = random.Next(0, 100 - op1);
                    op3 = random.Next(0, 100 - (op1 + op2));
                    op4 = 100 - (op1 + op2 + op3);
                    break;

                case DifficultyLevel.Hard:
                    op1 = random.Next(35, 100);  // Optiunea corecta
                    op2 = random.Next(0, 100 - op1);
                    op3 = random.Next(0, 100 - (op1 + op2));
                    op4 = 100 - (op1 + op2 + op3);
                    break;

                case DifficultyLevel.Einstein:
                    op1 = random.Next(20, 100);  // Optiunea corecta
                    op2 = random.Next(0, 100 - op1);
                    op3 = random.Next(0, 100 - (op1 + op2));
                    op4 = 100 - (op1 + op2 + op3);
                    break;
            }

            Stack<int> OtherOptions = new Stack<int>();
            OtherOptions.Push(op2);
            OtherOptions.Push(op3);
            OtherOptions.Push(op4);

            int correctOptionId = question.CorrectOptionIndex;

            for (int i = 0; i < correctOptionId; i++)
                results[i] = OtherOptions.Pop();

            results[correctOptionId] = op1;

            for (int i = correctOptionId + 1; i < 4; i++)
                results[i] = OtherOptions.Pop();

            return results;
        }

        

        public void FiftyFifty(Question question)
        {
            // Marcheaza 2 intrebari gresite prin "".

            List<int> idOptiuni = new List<int>() {0, 1, 2, 3};
            idOptiuni.Remove(question.CorrectOptionIndex);

            Random rnd = new Random();

            // Prima optiune care va fi eliminata:
            int op1 = idOptiuni[rnd.Next(0, 3)];
            question.Options[op1] = "";
            idOptiuni.Remove(op1);

            int op2 = idOptiuni[rnd.Next(0, 2)];
            question.Options[op2] = "";
            idOptiuni.Remove(op1);
            return;
        }

        public List<string> CallAFriend(string friendName, string playerName, Question question)
        {
            // Vor exista 3 tipuri de prieteni
            // Primul tip: Nu cunoaste raspunsul si va da 2 raspunsuri absolut aleatorii
            // Al doilea tip: Nu este sigur pe sine, dar cunoaste cate ceva. Acesta va da 2 raspunsuri dintre care unul
            // sigur este cel corect
            // Al treilea tip: Este un bun cunoscator, acesta va da raspunsul corect.

            // Pentru intrebarile Easy:
            //  10% sansa ca prietenul va fin din primul tip
            //  20% ca va fi din al 2-lea tip
            //  70% ca va fi din al 3-lea tip

            // Pentru intrebarile Medium
            //  15% - primul tip
            //  25% - al doilea tip
            //  60% - al treilea tip

            // Pentru intrebarile Hard si Einstein
            //  20% - primul tip
            //  40% - al doilea tip
            //  40% - al treilea tip

            // Functia returneaza o lista ce va contine replicile dupa cum urmeaza:
            // Persoana telefonata: Alo
            // Participant: Salut
            // si tot asa, astfel incat replicile cu indice par sunt ale persoanei telefonate, respectiv cele cu indice impar - 
            // al participantului.

            List<string> r1 = new List<string>() { "Alo?", "Pronto", "Da", "Alo alo", "Hello", "Cine acolo?" };
            List<string> r2 = new List<string>() { 
                $"Salut {friendName}, sunt {playerName}, am nevoie de ajutorul tau",
                $"Buna! ${playerName} te deranjeaza. Daca ma ajuti impartim banutii",
                $"Daca nu ma ajuti ma supar pe tine, cu ${playerName} vorbesti."
            };
            List<string> r3 = new List<string>() { "Zi", "N-am bani", "Ce s-a intamplat?", $"Ce ai ma {playerName}, esti Ok?", "Cu mare placere!" };
            List<string> r4 = new List<string>() { 
                $"Sunt la 'Vrei sa fii Milionar' si sunt blocat la o intrebare",
                $"Vreau sa ma ajuti la o intrebare, apropo sunt la 'Vrei sa fii milionar'!",
                $"Sunt la 'Vrei sa fii milionar', am ajuns la o intrebare mai grea la care doar tu ma poti ajuta."
            };
            List<string> r5 = new List<string> { "Zi", "Ascult cu mare atentie", "Incercam!", "Uoof, pe altcineva n-ai gasit sa suni?", "Nici o problema!" };
            List<string> r6 = new List<string>
            {
                $"Asculta atent aci: {question.QuestionText},  variantele de raspuns: {question.Options[0]}, {question.Options[1]}, {question.Options[2]}, {question.Options[3]}",
                $"Intrebarea e: {question.QuestionText}, astea sunt raspunsurile: {question.Options[0]}, {question.Options[1]}, {question.Options[2]}, {question.Options[3]}",
                $"{question.QuestionText}, sunt sigur ca stii raspunsul dar iti zic si variantele pe care le am aici: {question.Options[0]}, {question.Options[1]}, {question.Options[2]}, {question.Options[3]}",
            };

            List<string> r7_type1 = new List<string>
            {
                $"E usoara intrebarea... E una din optiunile alea. As merge pe primele 2, imi plac cum suna.",
                $"Mi-a dat cu eroare... Nu cunosc, imi pare rau. Eu as alege {question.Options[1]} sau {question.Options[3]}",
                $"Vezi si tu..  {question.Options[1]} sau {question.Options[3]}, sau  {question.Options[0]}, sau {question.Options[2]}, la sigur e una din ele",
                $"Imi pare rau, nu cunosc nici pe aproape raspunsul, ar putea fi optiunea 3 sau 4, dar nu sunt sigur deloc.",
            };
            List<string> r8_type1 = new List<string>
            {
                $"Ok, multumesc!",
                $"Bine :( ",
                $"Eh, aia e. Mergem la risc. Mersi!",
            };

            // Pentru al 2-lea tip stocam 2 raspunsuri intr-o lista, dintre care unul cu siguranta este castigator, dupa care le extragem in mod aleator.
            List<string> options = new List<string>();
            options.Add(question.Options[question.CorrectOptionIndex]);

            List<string> wrongOptions = new List<string>();
            for(int i = 0; i < 4; i++)
                if (i != question.CorrectOptionIndex)
                    wrongOptions.Add(question.Options[i]);
            
            Random rnd = new Random();
            string optiuneGresita = question.Options[rnd.Next(0, 3)];
            options.Add(optiuneGresita);

            int randomIndex = rnd.Next(0, 2);
            string option1 = options[randomIndex];
            options.RemoveAt(randomIndex);
            string option2 = options[0];

            // Acum avem option1 si option2, suntem siguri ca una este varianta corecta, dar nu stim exact care.

            List<string> r7_type2 = new List<string>
            {
                $"La sigur e {option1} sau {option2}",
                $"{option1} sau {option2}, cu siguranta una dintre ele",
                $"Ma inseala memoria, raspunsul e {option1} sau {option2}, cu siguranta.",
            };
            
            List<string> r8_type2 = new List<string>
            {
                $"Ok, multumesc!",
                $"Bine",
                $"Eh, aia e. Mergem la risc. Mersi!",
                $"Multumesc! Urmeaza sa iau o decizie. O Zi buna!",
            };

            string optiuneCorecta = question.Options[question.CorrectOptionIndex];
            List<string> r7_type3 = new List<string>
            {
                $"Nici nu stam la discutii, raspunsul e {optiuneCorecta}",
                $"{optiuneCorecta}, 100%",
                $"Asa intrebari usoare se dau la Vrei sa fii milionar? Raspunsul e {optiuneCorecta}",
                $"Ai nimerit bine! Raspunsul e {optiuneCorecta}",
                $"Prea usoara intrebarea, {optiuneCorecta}",
                $"{optiuneCorecta}, te achiti si cu mine ;)",
                $"{optiuneCorecta}, altceva?"
            };

            List<string> r8_type3 = new List<string>
            {
                $"Te respect! Multumesc",
                $"Prietenul la nevoie se cunoaste, multumesc!",
                $"Raman dator!",
                $"Stiam eu ca sun pe cine trebuie ;)",
                $"Eh, intr-adevar era usoara intrebarea, am vrut doar sa-ti aud vocea",
                $"Am incredere! Merg pe aceasta optiune.",
                $"Nice!",
            };

            List<string> conversatiaFinala = new List<string>();
            conversatiaFinala.Add(r1[rnd.Next(0, r1.Count)]);
            conversatiaFinala.Add(r2[rnd.Next(0, r2.Count)]);
            conversatiaFinala.Add(r3[rnd.Next(0, r3.Count)]);
            conversatiaFinala.Add(r4[rnd.Next(0, r4.Count)]);
            conversatiaFinala.Add(r5[rnd.Next(0, r5.Count)]);
            conversatiaFinala.Add(r6[rnd.Next(0, r6.Count)]);

            int tipPrieten = 0;
            int nrAleator = rnd.Next(1, 101);
            switch (question.DifficultyLevel)
            {
                case DifficultyLevel.Easy: // 10 20 70
                    if (nrAleator <= 10) { tipPrieten = 1;  break; }
                    if (nrAleator <= 30) { tipPrieten = 2;  break; }
                    tipPrieten = 3;
                    break;
                case DifficultyLevel.Medium: // 15 25 60
                    
                    if (nrAleator <= 15) { tipPrieten = 1; break; }
                    if (nrAleator <= 40) { tipPrieten = 2; break; }
                    tipPrieten = 3;
                    break;
                case DifficultyLevel.Hard: // 20 40 40
                case DifficultyLevel.Einstein: // 20 40 40
                    if (nrAleator <= 20) { tipPrieten = 1; break; }
                    if (nrAleator <= 60) { tipPrieten = 2; break; }
                    tipPrieten = 3;
                    break;
            }

            List<string> replica7 = new List<string>(); 
            List<string> replica8 = new List<string>(); 
            switch (tipPrieten)
            {
                case 1: replica7 = r7_type1; replica8 = r8_type1; break;
                case 2: replica7 = r7_type2; replica8 = r8_type2; break;
                case 3: replica7 = r7_type3; replica8 = r8_type3; break;
            }

            conversatiaFinala.Add(replica7[rnd.Next(0, replica7.Count)]);
            conversatiaFinala.Add(replica8[rnd.Next(0, replica8.Count)]);

            return conversatiaFinala;
        }
    }
}

using System;
using System.Collections.Generic;
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

        public List<string> CallAFriend(string friendName)
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

            // Pentru intrebarile UpperMedium
            //  20% - primul tip
            //  30% - al doilea tip
            //  50% - al treilea tip

            // Pentru intrebarile Hard si Einstein
            //  20% - primul tip
            //  40% - al doilea tip
            //  40% - al treilea tip

            throw new NotImplementedException();
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
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using WhoWantsToBeAMillionaire.Models;

namespace WhoWantsToBeAMillionaire.Services
{
    class LifelineService
    {
        public List<int> AskAudience()
        {
            // Pentru intrebarile Easy: Raspunsul corect va avea peste 80% din voturi
            // Pentru intrebarile Medium: Raspunsul corect va avea peste 60% din voturi
            // Pentru intrebarile UpperMedium: Raspunsul corect va avea peste 50% din voturi
            // Pentru intrebarile Hard: Raspunsul corect va avea peste 35% din voturi
            // Pentru intrebarile Einstein: Raspunsul corect va avea peste 20% din voturi
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}

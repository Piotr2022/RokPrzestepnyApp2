using System.ComponentModel.DataAnnotations;

namespace RokPrzestepnyZBaza.Model
{
    public class WpisPrzestepnosci
    {


        public int Id { get; set; }

        [Required(ErrorMessage = "Pole jest obowiązkowe")]
        public int? Rok { set; get; }



        [MaxLength(100, ErrorMessage = "Wprowadzone imię musi mieć co najwyżej {1} znaków")]
        public string? Imie { set; get; }

        public DateTime Data { set; get; }

        public string? Result { set; get; }

        public string? loginID { set; get; }

        public string? Login { set; get; }


        public string on_Czy_Ona()
        {

            if (this.Imie[this.Imie.Length - 1] == 'a')
            {
                return " urodziła";
            }
            else
            {
                return " urodził";
            }
        }


        public bool czy_Przestepny()
        {
            if ((this.Rok % 4 == 0 && this.Rok % 100 != 0) || this.Rok % 400 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string get_Message()
        {
            if(this.Imie != null)
            {
                string on_czy_ona = on_Czy_Ona();
                if (czy_Przestepny() == true)
                {
                    return this.Imie + on_czy_ona + " się w " + this.Rok + " roku. To był rok przestępny.";
                }
                else
                {
                    return this.Imie + on_czy_ona + " się w " + this.Rok + " roku. To nie był rok przestępny.";
                }
            } else
            {

                if (czy_Przestepny() == true)
                {
                    return "Ta osoba pojawiła się na świecie w " + this.Rok + " roku. To był rok przestępny.";
                }
                else
                {
                    return "Ta osoba pojawiła się na świecie w " + this.Rok + " roku. To nie był rok przestępny.";
                }
                
            }
            
        }
    }
}

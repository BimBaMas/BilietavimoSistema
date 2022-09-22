
Menu menu = new Menu();
menu.MenuHandleris();

class Menu
{
    Bilietai bilietai10 = new Bilietai(10);
    Bilietai bilietai20 = new Bilietai(20);
    Bilietai bilietai30 = new Bilietai(30);

    public void MenuHandleris()
    {
        this.PiestiMenu();
        int menu = ArMenuPunktas();
        if (menu == 0)
        {
            Environment.Exit(0);
        }
        if (menu == 3)
        {
            this.Ataskaita();
            this.MenuHandleris();
        }
        else
        {
            this.SubMenuHandleris(menu);
        }
    }

    void SubMenuHandleris(int menu)
    {
        this.PiestiMenu();
        Console.WriteLine("");
        this.PiestiSubMenu();
        int subMenu = this.ArMenuPunktas();
        if (subMenu == 0)
        {
            this.MenuHandleris();
        }
        if (menu == 1)
        {
            this.Parduoti(subMenu);
        }
        if (menu == 2)
        {
            this.Sukurti(subMenu);
        }
        this.SubMenuHandleris(menu);
    }

    void Parduoti(int bilietas)
    {
        int kiekis;
        switch (bilietas)
        {
            case 1:
                Console.Write("Pasirinkta pirkti bilietu po 10 EUR\nIveskite perkamu bilietu kieki (Gryzti i menu iveskite [0]) : ");
                do
                {
                    kiekis = ArTeisingasKiekis();
                    if (kiekis == 0)
                    {
                        this.MenuHandleris();
                    }
                } while (!bilietai10.Pardavimas(kiekis));
                break;
            case 2:
                Console.Write("Pasirinkta pirkti bilietu po 20 EUR\nIveskite perkamu bilietu kieki (Gryzti i menu iveskite [0]): ");
                do
                {
                    kiekis = ArTeisingasKiekis();
                    if (kiekis == 0)
                    {
                        this.MenuHandleris();
                    }
                } while (!bilietai20.Pardavimas(kiekis));
                break;
            case 3:
                Console.Write("Pasirinkta pirkti bilietu po 30 EUR\nIveskite perkamu bilietu kieki (Gryzti i menu iveskite [0]): ");
                do
                {
                    kiekis = ArTeisingasKiekis();
                    if (kiekis == 0)
                    {
                        this.MenuHandleris();
                    }
                } while (!bilietai30.Pardavimas(kiekis));
                break;
            default:
                break;
        }
    }
    
    void Sukurti(int bilietas)
    {
        int kiekis;
        switch (bilietas)
        {
            case 1:
                Console.Write("Pasirinkta sukurti bilietu po 10 EUR\nIveskite kuriamu bilietu kieki : ");
                kiekis = ArTeisingasKiekis();
                if (kiekis == 0)
                {
                    SubMenuHandleris(2);
                }
                bilietai10.Sukurimas(kiekis);
                break;
            case 2:
                Console.Write("Pasirinkta sukurti bilietu po 20 EUR\nIveskite kuriamu bilietu kieki : ");
                kiekis = ArTeisingasKiekis();
                if (kiekis == 0)
                {
                    SubMenuHandleris(2);
                }
                bilietai20.Sukurimas(kiekis);
                break;
            case 3:
                Console.Write("Pasirinkta sukurti bilietu po 30 EUR\nIveskite kuriamu bilietu kieki : ");
                kiekis = ArTeisingasKiekis();
                if (kiekis == 0)
                {
                    SubMenuHandleris(2);
                }
                bilietai30.Sukurimas(kiekis);
                break;
            default:
                break;
        }
    }

    void Ataskaita()
    {
        Console.Clear();
        this.PiestiDuomenis(false);
        this.PiestiDuomenis(true);
        this.PiestiDuomenis(false);
        this.PiestiDuomenis(bilietai10, "Bilietai10");
        this.PiestiDuomenis(false);
        this.PiestiDuomenis(bilietai20, "Bilietai20");
        this.PiestiDuomenis(false);
        this.PiestiDuomenis(bilietai30, "Bilietai30");
        this.PiestiDuomenis(false);
        this.PiestiDuomenis(bilietai10, bilietai20, bilietai30);
        this.PiestiDuomenis(false);
        Console.WriteLine("Noredami testi, spauskite bet kuri mygtuka.");
        Console.ReadKey();
    }

    int ArMenuPunktas()
    {
        int menu = 0;
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out menu) && menu >= 0 && menu <= 3)
            {
                return menu;
            }
            else
            {
                Console.Write("Ivedete neegzistuojanti menu punkta. Bandykite dar karta : ");
            }
        }
    }
    
    int ArTeisingasKiekis()
    {
        int kiekis = -1;
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out kiekis) && kiekis >= 0)
            {
                return kiekis;
            }
            else
            {
                Console.Write("Bilietu kiekis turi buti skaicius didesnis uz 0. Bandykite dar karta : ");
            }
        }
    }
    
    void PiestiMenu()
    {
        Console.Clear();
        Console.Write(">>> Meniu : [1] Pirkti bilietus, [2] Kurti bilietus, [3] Ataskaita [0] Baigti darba : ");
    }
    
    void PiestiSubMenu()
    {
        Console.Write("\t>>> Pasirinkite bil. tipa : [1] po 10 EUR, [2] po 20 EUR, [3] po 30EUR, [0] gryzti i pagrindini meniu : ");
    }
        
    void PiestiDuomenis(bool tekstas)
    {
        if (tekstas)
        {
            Console.WriteLine("|          | Sukurta  | Parduota |   Uzdirbta  | Likutis  |");
        }
        else
        {
            Console.WriteLine("+----------+----------+----------+-------------+----------+");
        }
    }

    void PiestiDuomenis(Bilietai bilietas, string pavadinimas)
    {
        Console.Write("|" + pavadinimas + "|");
        Console.Write(String.Format($"{bilietas.SukurtuBilietuKiekis(),10}|"));
        Console.Write(String.Format($"{bilietas.ParduotuBilietuKiekis(),10}|"));
        Console.Write(String.Format($"{bilietas.Uzdirbta(),10:0.00}EUR|"));
        Console.WriteLine(String.Format($"{bilietas.Likutis(),10}|"));

    }

    void PiestiDuomenis(Bilietai bilietas10, Bilietai bilietas20, Bilietai bilietas30)
    {
        int sukurta = bilietai10.SukurtuBilietuKiekis() + bilietai20.SukurtuBilietuKiekis() + bilietai30.SukurtuBilietuKiekis();
        int parduota = bilietai10.ParduotuBilietuKiekis() + bilietai20.ParduotuBilietuKiekis() + bilietai30.ParduotuBilietuKiekis();
        decimal uzdirbta = bilietai10.Uzdirbta() + bilietai20.Uzdirbta() + bilietai30.Uzdirbta();
        int likutis = bilietai10.Likutis() + bilietai20.Likutis() + bilietai30.Likutis();
        Console.Write("|Is viso   |");
        Console.Write(String.Format($"{sukurta,10}|"));
        Console.Write(String.Format($"{parduota,10}|"));
        Console.Write(String.Format($"{uzdirbta,10:0.00}EUR|"));
        Console.WriteLine(String.Format($"{likutis,10}|"));

    }
}

class Bilietai
{
    int kiekis = 0;
    decimal kaina;
    int sukurta = 0;
    int parduota = 0;

    public Bilietai(decimal kaina)
    {
       this.kaina = kaina;       
    }

    public bool Pardavimas(int kiekis)
    {
        if (ArGalimaParduoti(kiekis))
        {
            this.kiekis -= kiekis;
            this.parduota += kiekis;
            this.Zinutes(0);
            return true;
        }
        else
        {
            this.Zinutes(1);
            return false;
        }
    }
    
    bool ArGalimaParduoti(int kiekis)
    {
        return this.kiekis >= kiekis;
    }

    public int ParduotuBilietuKiekis()
    {
        return this.parduota;
    }
    
    public void Sukurimas(int kiekis)
    {
        this.kiekis += kiekis;
        this.sukurta += kiekis;
        this.Zinutes(2);
    }
    
    public int SukurtuBilietuKiekis()
    {
        return this.sukurta;
    }

    public int Likutis()
    {
        return this.kiekis;
    }

    public decimal Uzdirbta()
    {
        return this.kaina * this.parduota;
    }    
    
    void Zinutes(int zinutesNumeris)
    {
        switch (zinutesNumeris)
        {
            case 0:
                Console.Write("Bilietai sekmingai parduoti\nPaspauskite bet kuri mygtuka.");
                Console.ReadKey();
                break;
            case 1:
                Console.Write($"Apgailestaujame, bet siuo metu tiek bilietu neturime. Likutis : {this.kiekis}\nPasirinkite kita kieki : ");
                break;
            case 2:
                Console.Write("Bilietai sekmingai sukurti.\nPaspauskite bet kuri mygtuka.");
                Console.ReadKey();
                break;
            case 3:
                Console.Write("Kuriamu bilietu kiekis turi buti didesnis uz 0!!!\nBandykite dar karta : ");
                break;

            default:
                break;
        }
    }
}